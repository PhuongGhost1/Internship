using BE.Dto.Course;
using BE.Dto.ImageD;
using BE.Dto.Notification;
using BE.Dto.Payment;
using BE.Dto.Payment.CartCourse;
using BE.Dto.Payment.PaymentCourse;
using BE.Dto.Role;
using BE.Dto.RoleUser;
using BE.Dto.User;
using BE.Dto.User.AdminManagement;
using BE.Models;
using BE.Repository.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using static BE.Utils.Utils;

namespace BE.Repository.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly CourseOnlContext _context;

        public UserRepository(CourseOnlContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckEmailExist(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email.ToLower() == email.ToLower());
        }

        public async Task<bool> CheckPasswordExist(string password)
        {
            return await _context.Users.AnyAsync(u => u.Password.ToLower() == password.ToLower());
        }

        public async Task<bool> CheckUserExistById(string userId)
        {
            return await _context.Users.AnyAsync(u => u.Id.ToLower() == userId.ToLower());
        }

        public async Task<User?> CheckUserLogin(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => (u.Username == username || u.Email == username) && u.Password == password);

            if (user == null) return null;

            return user;
        }

        public async Task<User?> CreateUser(User user)
        {
            await _context.Users.AddAsync(user);

            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<bool> CreateUserData(string username, string email, string password, string description, string phone, string role)
        {
            try
            {
                string IdUser = GenerateIdModel("user");
                var user = new User
                {
                    Id = IdUser,
                    Username = username,
                    Email = email,
                    Password = password,
                    Description = description,
                    Phone = phone,
                    CreateAt = GetTimeNow(),
                    Wallet = 0,
                    IsVisible = true,
                };
                _context.Users.Add(user);
                var roleuser = new RoleUser
                {
                    Id = GenerateIdModel("roleuser"),
                    Role = await _context.Roles.FirstOrDefaultAsync(u => u.Name == role),
                    User = user,
                    UpdateDate = GetTimeNow(),
                    Status = 1
                };
                _context.RoleUsers.Add(roleuser);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());

            if (user == null) return null;

            return user;
        }

        public async Task<User?> GetUserById(string userId)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task<User?> UpdateUser(ForgotDto forgotDto, string email)
        {
            var userModel = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (userModel == null) return null;

            userModel.Password = forgotDto.Password;

            await _context.SaveChangesAsync();

            return userModel;
        }

        public async Task<(int a, int c)> GetUserStatisticsAsync()
        {
            var now = DateTime.UtcNow;
            var thirtyDaysAgo = now.AddDays(-30);
            var sixtyDaysAgo = now.AddDays(-60);

            int a = await _context.Users //ngày đăng kí nằm trong khoảng 30 ngày trc tính từ ngày hiện tại
                                .Where(user => user.CreateAt >= thirtyDaysAgo)
                                .CountAsync();

            int b = await _context.Users  //ngày đăng kí nằm trong khoảng 60 ngày trc và 30 ngày trc tính từ ngày hiện tại
                                .Where(user => user.CreateAt >= sixtyDaysAgo && user.CreateAt < thirtyDaysAgo)
                                .CountAsync();

            int c = b == 0 ? 0 : (int)Math.Round((a * 100.0 / b) - 100);

            return (a, c);
        }

        private async Task<double?> GetPercentageChangeForRoleAccountsLastMonth(string roleName)
        {
            var currentDate = DateTime.UtcNow;
            var currentMonth = new DateTime(currentDate.Year, currentDate.Month, 1);
            var previousMonth = currentMonth.AddMonths(-1);

            var currentMonthCount = await CountAccountsByRoleForMonth(roleName, currentMonth);
            var previousMonthCount = await CountAccountsByRoleForMonth(roleName, previousMonth);

            if (previousMonthCount == 0) return currentMonthCount > 0 ? 100 : 0;

            if (currentMonthCount == null || previousMonthCount == null) return 0;

            var percentageChange = ((currentMonthCount.Value - previousMonthCount.Value) / (double)previousMonthCount.Value) * 100;

            var formattedPercentageChange = Math.Round(percentageChange, 2);

            return formattedPercentageChange;
        }

        public async Task<double?> GetPercentageChangeForStudentAccountsLastMonth()
        {
            return await GetPercentageChangeForRoleAccountsLastMonth("Student");
        }

        public async Task<double?> GetPercentageChangeForInstructorAccountsLastMonth()
        {
            return await GetPercentageChangeForRoleAccountsLastMonth("Instructor");
        }

        public async Task<int?> CountAccountsByRoleForMonth(string roleName, DateTime month)
        {
            var startOfMonth = new DateTime(month.Year, month.Month, 1);
            var endOfMonth = startOfMonth.AddMonths(1).AddTicks(-1);

            var roleId = await _context.Roles
                                    .Where(role => role.Name == roleName)
                                    .Select(role => role.Id)
                                    .FirstOrDefaultAsync();

            if (string.IsNullOrEmpty(roleId)) return null;

            var accountCount = await _context.RoleUsers
                                            .Where(ur => ur.RoleId == roleId)
                                            .Join(_context.Users, ur => ur.UserId, u => u.Id, (ur, u) => u)
                                            .Where(u => u.CreateAt >= startOfMonth && u.CreateAt <= endOfMonth)
                                            .CountAsync();
            return accountCount;
        }

        public async Task<List<UserInfoManageByAdminDto>> GetInstructors(string roleName)
        {
            var instructors = await _context.Users
                .Where(u => u.RoleUsers.Any(ru => ru.Role.Name == roleName))
                .Select(u => new UserInfoManageByAdminDto
                {
                    Id = u.Id,
                    Email = u.Email,
                    Name = u.Username,
                    IsVisible = u.IsVisible,
                    Images = u.Images
                                    .Where(i => i.UserId == u.Id)
                                    .OrderByDescending(i => i.CreatedAt)
                                    .Select(i => new ImageForAdminDto
                                    {
                                        Id = i.Id,
                                        Url = i.Url,
                                        Type = i.Type,
                                        LastUpdated = i.CreatedAt
                                    })
                                    .Take(1)
                                    .ToList(),
                    Phone = u.Phone,
                    CreateAt = u.CreateAt,
                    Description = u.Description,
                    RoleUsers = u.RoleUsers.Select(ru => new RoleUserDto
                    {
                        Roles = new List<RoleDto>
                        {
                            new RoleDto { Name = ru.Role.Name }
                        }
                    }).ToList(),
                    Notifications = u.NotificationReceiveds.Select(n => new NotificationDto
                    {
                        Description = n.Description,
                        DateUp = n.DateUp,
                        Type = n.Type,
                        Course = n.Course != null ? new CourseForAdminDto
                        {
                            Id = n.Course.Id,
                            Name = n.Course.Name,
                            Rating = n.Course.Rating,
                            Price = n.Course.Price,
                            Images = n.Course.Images
                                    .OrderByDescending(i => i.CreatedAt)
                                    .Select(i => new ImageForAdminDto
                                    {
                                        Id = i.Id,
                                        Url = i.Url,
                                        Type = i.Type,
                                        LastUpdated = i.CreatedAt
                                    })
                                    .Take(1)
                                    .ToList()
                        } : null
                    }).ToList(),
                    Courses = u.Courses.Select(c => new CourseForAdminDto
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Rating = c.Rating,
                        Price = c.Price,
                        Images = c.Images
                                    .OrderByDescending(i => i.CreatedAt)
                                    .Select(i => new ImageForAdminDto
                                    {
                                        Id = i.Id,
                                        Url = i.Url,
                                        Type = i.Type,
                                        LastUpdated = i.CreatedAt
                                    })
                                    .Take(1)
                                    .ToList()
                    }).ToList(),
                    Payments = u.Payments.Select(p => new PaymentDto
                    {
                        PaymentCourses = p.PaymentCourses.Select(pc => new PaymentCourseDto
                        {
                            CartCourseDto = pc.Cartcourse != null ? new CartCourseDto
                            {
                                CourseForAdminDto = pc.Cartcourse.Course != null ? new CourseForAdminDto
                                {
                                    Id = pc.Cartcourse.Course.Id,
                                    Name = pc.Cartcourse.Course.Name,
                                    Rating = pc.Cartcourse.Course.Rating,
                                    Price = pc.Cartcourse.Course.Price,
                                    Images = pc.Cartcourse.Course.Images
                                                .OrderByDescending(i => i.CreatedAt)
                                                .Select(i => new ImageForAdminDto
                                                {
                                                    Id = i.Id,
                                                    Url = i.Url,
                                                    Type = i.Type,
                                                    LastUpdated = i.CreatedAt
                                                })
                                                .Take(1)
                                                .ToList()
                                } : null
                            } : null
                        }).ToList(),
                        Total = p.Total
                    }).ToList()
                })
                .ToListAsync();

            return instructors;
        }

        public async Task<bool> UpdateUserStatus(string userId)
        {
            var user = await _context.Users.FindAsync(userId);

            if (user == null) return false;

            if (user.IsVisible == true)
            {
                user.IsVisible = false;
            }
            else
            {
                user.IsVisible = true;
            }

            _context.Users.Update(user);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<FeedbackRequestDto>> GetFeedbacksManagementByAdmin()
        {
            var feedback = await _context.Feedbacks
                                        .Select(f => new FeedbackRequestDto
                                        {
                                            Id = f.Id,
                                            Title = f.Title,
                                            Description = f.Description,
                                            IsRead = f.IsRead,
                                            UserRequest = new UserRequestManagementByAdminDto
                                            {
                                                Id = f.User.Id,
                                                Username = f.User.Username,
                                                Email = f.User.Email,
                                                Password = f.User.Password,
                                                Description = f.User.Description,
                                                Phone = f.User.Phone,
                                                CreateAt = f.User.CreateAt,
                                                Images = f.User.Images
                                                            .Where(i => i.UserId == f.User.Id)
                                                            .OrderByDescending(i => i.CreatedAt)
                                                            .Select(i => new ImageForAdminDto
                                                            {
                                                                Id = i.Id,
                                                                Url = i.Url,
                                                                Type = i.Type,
                                                                LastUpdated = i.CreatedAt
                                                            })
                                                            .Take(1)
                                                            .ToList(),
                                                RoleUserReqs = f.User.RoleUsers.Select(ru => new RoleUserRequestDto
                                                {
                                                    Id = ru.Id,
                                                    RoleId = ru.RoleId,
                                                    UserId = ru.UserId,
                                                    Status = ru.Status
                                                }).ToList(),
                                            }
                                        }).ToListAsync();

            return feedback;
        }

        public async Task<List<ReportManagementByAdminDto>> GetReportManagementByAdmin()
        {
            var reports = await _context.Reports
            .Include(r => r.Course)
            .ThenInclude(c => c.Images)
            .Include(r => r.Comment)
            .ThenInclude(cm => cm.User)
            .Include(r => r.ReportedUser)
            .Include(r => r.Reporter)
            .Select(r => new ReportManagementByAdminDto
            {
                Id = r.Id,
                Courses = r.Course != null ? new CourseForAdminDto
                {
                    Id = r.Course.Id,
                    Name = r.Course.Name,
                    Rating = r.Course.Rating,
                    Price = r.Course.Price,
                    Description = r.Course.Description,
                    CreatedAt = r.Course.CreateAt,
                    UpdatedAt = r.Course.UpdateAt,
                    IsVisible = r.Course.IsVisible,
                    Images = r.Course.Images
                                .OrderByDescending(i => i.CreatedAt)
                                .Select(i => new ImageForAdminDto
                                {
                                    Id = i.Id,
                                    Url = i.Url,
                                    Type = i.Type,
                                    LastUpdated = i.CreatedAt
                                }).Take(1).ToList(),
                    User = r.Course.User != null ? new UserInfoManageByAdminDto
                    {
                        Id = r.Course.User.Id,
                        Email = r.Course.User.Email,
                        Name = r.Course.User.Username,
                        IsVisible = r.Course.User.IsVisible,
                        Images = r.Course.Images
                                        .OrderByDescending(i => i.CreatedAt)
                                        .Select(i => new ImageForAdminDto
                                        {
                                            Id = i.Id,
                                            Url = i.Url,
                                            Type = i.Type,
                                            LastUpdated = i.CreatedAt
                                        }).Take(1).ToList(),
                        Phone = r.Course.User.Phone,
                        CreateAt = r.Course.CreateAt,
                        Description = r.Course.User.Description
                    } : null
                } : null,
                Comments = r.Comment != null ? new CommentManagementByAdminDto
                {
                    Id = r.Comment.Id,
                    Courses = r.Comment.Course != null ? new CourseForAdminDto
                    {
                        Id = r.Comment.Course.Id,
                        Name = r.Comment.Course.Name,
                        Rating = r.Comment.Course.Rating,
                        Price = r.Comment.Course.Price,
                        Description = r.Comment.Course.Description,
                        IsVisible = r.Comment.Course.IsVisible,
                        CreatedAt = r.Comment.Course.CreateAt,
                        UpdatedAt = r.Comment.Course.UpdateAt,
                        Images = r.Comment.Course.Images
                                        .OrderByDescending(i => i.CreatedAt)
                                        .Select(i => new ImageForAdminDto
                                        {
                                            Id = i.Id,
                                            Url = i.Url,
                                            Type = i.Type,
                                            LastUpdated = i.CreatedAt
                                        }).Take(1).ToList()
                    } : null,
                    Users = r.Comment.User != null ? new UserInfoManageByAdminDto
                    {
                        Id = r.Comment.User.Id,
                        Email = r.Comment.User.Email,
                        Name = r.Comment.User.Username,
                        IsVisible = r.Comment.User.IsVisible,
                        Images = r.Comment.User.Images
                                        .OrderByDescending(i => i.CreatedAt)
                                        .Select(i => new ImageForAdminDto
                                        {
                                            Id = i.Id,
                                            Url = i.Url,
                                            Type = i.Type,
                                            LastUpdated = i.CreatedAt
                                        }).Take(1).ToList(),
                        Phone = r.Comment.User.Phone,
                        CreateAt = r.Comment.User.CreateAt,
                        Description = r.Comment.User.Description
                    } : null,
                    Rating = r.Comment.Rating,
                    Comment1 = r.Comment.Comment1,
                    CreatedAt = r.Comment.CreatedAt,
                    IsVisible = r.Comment.IsVisible
                } : null,
                ReportedUser = r.ReportedUser != null ? new UserInfoManageByAdminDto
                {
                    Id = r.ReportedUser.Id,
                    Email = r.ReportedUser.Email,
                    Name = r.ReportedUser.Username,
                    IsVisible = r.ReportedUser.IsVisible,
                    Images = r.ReportedUser.Images
                                    .OrderByDescending(i => i.CreatedAt)
                                    .Select(i => new ImageForAdminDto
                                    {
                                        Id = i.Id,
                                        Url = i.Url,
                                        Type = i.Type,
                                        LastUpdated = i.CreatedAt
                                    }).Take(1).ToList(),
                    Phone = r.ReportedUser.Phone,
                    CreateAt = r.ReportedUser.CreateAt,
                    Description = r.ReportedUser.Description,
                    RoleUsers = r.ReportedUser.RoleUsers.Select(ru => new RoleUserDto
                    {
                        Roles = new List<RoleDto>
                        {
                            new RoleDto { Name = ru.Role.Name }
                        }
                    }).ToList(),
                } : null,
                Reporter = r.Reporter != null ? new UserInfoManageByAdminDto
                {
                    Id = r.Reporter.Id,
                    Email = r.Reporter.Email,
                    Name = r.Reporter.Username,
                    IsVisible = r.Reporter.IsVisible,
                    Images = r.Reporter.Images
                                    .OrderByDescending(i => i.CreatedAt)
                                    .Select(i => new ImageForAdminDto
                                    {
                                        Id = i.Id,
                                        Url = i.Url,
                                        Type = i.Type,
                                        LastUpdated = i.CreatedAt
                                    }).Take(1).ToList(),
                    Phone = r.Reporter.Phone,
                    CreateAt = r.Reporter.CreateAt,
                    Description = r.Reporter.Description
                } : null,
                Title = r.Title,
                Message = r.Message,
                Status = r.Status
            })
            .ToListAsync();

            return reports;
        }

        public async Task<bool> UpdateUserCommentReportStatus(string userId, string reportId, string commentId, string courseId)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var user = string.IsNullOrEmpty(userId) ? null : await _context.Users.FindAsync(userId);
                var report = await _context.Reports.FindAsync(reportId);
                var course = await _context.Courses.FindAsync(courseId);
                var comment = string.IsNullOrEmpty(commentId) ? null : await _context.Comments.FindAsync(commentId);

                if (report == null || course == null)
                {
                    transaction.Rollback();
                    return false;
                }

                var reportedUser = await _context.Users.FindAsync(userId);
                if (reportedUser == null)
                {
                    transaction.Rollback();
                    return false;
                }

                if (user != null)
                {
                    reportedUser.IsVisible = !user.IsVisible;
                    _context.Users.Update(reportedUser);
                }

                report.Status = 1;
                _context.Reports.Update(report);

                if (user == null || comment == null)
                {
                    course.IsVisible = !course.IsVisible;
                    _context.Courses.Update(course);
                }

                if (comment != null)
                {
                    comment.IsVisible = !comment.IsVisible;
                    _context.Comments.Update(comment);
                }

                await _context.SaveChangesAsync();
                transaction.Commit();

                return true;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Console.WriteLine($"Concurrency error: {ex.Message}");
                transaction.Rollback();
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating status: {ex.Message}");
                transaction.Rollback();
                return false;
            }
        }
        public async Task<bool> UpdateUserProfile(UserProfileDto user)
        {
            try
            {
                var userUpdate = await _context.Users
                                        .Include(i => i.Images)
                                        .FirstOrDefaultAsync(u => u.Id == user.UserId);
                if (userUpdate != null)
                {
                    userUpdate.Name = user.Name;
                    userUpdate.Username = user.Username;
                    userUpdate.Dob = user.DOB;
                    userUpdate.Description = user.Description;
                    userUpdate.Gender = user.Gender;
                    if (userUpdate.Images.IsNullOrEmpty())
                    {
                        userUpdate.Images.Add(
                            new Image
                            {
                                Id = GenerateIdModel("image"),
                                UserId = user.UserId,
                                CreatedAt = GetTimeNow(),
                                Type = "Avatar",
                                Url = await UploadImgUserToFirebase(user.Image, user.UserId, "Avatar")
                            }
                        );
                    }
                    else
                    {
                        foreach (var image in userUpdate.Images)
                        {
                            image.Url = await UploadImgUserToFirebase(user.Image, user.UserId, "Avatar");
                            image.CreatedAt = GetTimeNow();
                        }
                    }

                    _context.Users.Update(userUpdate);
                    await _context.SaveChangesAsync();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error update user profile: {e.Message}");
                return false;
            }
        }
    }
}