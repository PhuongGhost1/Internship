using System.Security.Policy;
using BE.Dto.Follow;
using BE.Dto.User;
using BE.Models;
using BE.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using BE.Dto.Follow;
using BE.Dto.ImageD;
using BE.Dto.Course;

namespace BE.Repository.Implementations
{
     public class FollowRepository : IFollowRepository
     {
          private readonly CourseOnlContext _context;
          public FollowRepository(CourseOnlContext context)
          {
               _context = context;
          }
          public async Task<FollowingDto> GetFollowing(string UserId)
          {
               var followEntries = await _context.Follows
               .Include(f => f.Follower)
                    .ThenInclude(u => u.Images)
               .Include(f => f.Followed)
                    .ThenInclude(u => u.Images)
               .Where(f => f.FollowedId == UserId || f.FollowerId == UserId)
               .ToListAsync();

               if (followEntries == null || !followEntries.Any())
               {
                    return null;
               }

               var followerList = followEntries
                    .Where(f => f.FollowedId == UserId)
                    .Select(f => new UserInfoManageByAdminDto
                    {
                         Id = f.Follower.Id,
                         Email = f.Follower.Email,
                         Name = f.Follower.Username,
                         IsVisible = f.Follower.IsVisible,
                         Images = f.Follower.Images
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
                         Phone = f.Follower.Phone,
                         CreateAt = f.Follower.CreateAt,
                         Description = f.Follower.Description,
                         Courses = f.Follower.Courses
                                        .Select(c => new CourseForAdminDto
                                        {
                                             Id = c.Id,
                                             Name = c.Name,
                                             Rating = c.Rating,
                                             Price = c.Price,
                                             Status = c.Status,
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
                                                       .ToList(),
                                             User = c.User != null ? new UserInfoManageByAdminDto
                                             {
                                                  Id = c.User.Id,
                                                  Email = c.User.Email,
                                                  Name = c.User.Username,
                                                  IsVisible = c.User.IsVisible,
                                                  Images = c.User.Images
                                                                 .OrderByDescending(i => i.CreatedAt)
                                                                 .Select(i => new ImageForAdminDto
                                                                 {
                                                                      Id = i.Id,
                                                                      Url = i.Url,
                                                                      Type = i.Type,
                                                                      LastUpdated = i.CreatedAt
                                                                 }).Take(1).ToList(),
                                                  Phone = c.User.Phone,
                                                  CreateAt = c.User.CreateAt,
                                                  Description = c.User.Description
                                             } : null
                                        }).ToList(),
                         CoursesCount = f.Follower.Courses.Where(x => x.UserId == f.FollowerId).Count()
                    })
                    .Distinct()
                    .ToList();

               var followedList = followEntries
                    .Where(f => f.FollowerId == UserId)
                    .Select(f => new UserInfoManageByAdminDto
                    {
                         Id = f.Followed.Id,
                         Email = f.Followed.Email,
                         Name = f.Followed.Username,
                         IsVisible = f.Followed.IsVisible,
                         Images = f.Followed.Images
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
                         Phone = f.Followed.Phone,
                         CreateAt = f.Followed.CreateAt,
                         Description = f.Followed.Description,
                         Courses = f.Followed.Courses
                                        .Select(c => new CourseForAdminDto
                                        {
                                             Id = c.Id,
                                             Name = c.Name,
                                             Rating = c.Rating,
                                             Price = c.Price,
                                             Status = c.Status,
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
                                                       .ToList(),
                                             User = c.User != null ? new UserInfoManageByAdminDto
                                             {
                                                  Id = c.User.Id,
                                                  Email = c.User.Email,
                                                  Name = c.User.Username,
                                                  IsVisible = c.User.IsVisible,
                                                  Images = c.User.Images
                                                                 .OrderByDescending(i => i.CreatedAt)
                                                                 .Select(i => new ImageForAdminDto
                                                                 {
                                                                      Id = i.Id,
                                                                      Url = i.Url,
                                                                      Type = i.Type,
                                                                      LastUpdated = i.CreatedAt
                                                                 }).Take(1).ToList(),
                                                  Phone = c.User.Phone,
                                                  CreateAt = c.User.CreateAt,
                                                  Description = c.User.Description
                                             } : null
                                        }).ToList(),
                         CoursesCount = f.Followed.Courses.Where(x => x.UserId == f.FollowedId).Count()
                    })
                    .Distinct()
                    .ToList();

               return new FollowingDto
               {
                    FollowingListOfUserId = UserId,
                    FollowFolloweds = followedList,
                    FollowFollowers = followerList,
               };
          }

          //---------------------CRUD--------------------------//
          public async Task<Follow?> CreateFollow(Follow follow)
          {
               await _context.Follows.AddAsync(follow);
               await _context.SaveChangesAsync();
               return follow;
          }

          public async Task<bool> DeleteFollow(string followId)
          {
               var follow = await _context.Follows.FindAsync(followId);

               if (follow == null) return false;

               _context.Follows.Remove(follow);
               await _context.SaveChangesAsync();
               return true;
          }

          public async Task<List<Follow>> GetAllFollows()
          {
               return await _context.Follows.ToListAsync();
          }

          public async Task<Follow?> GetFollowById(string followId)
          {
               return await _context.Follows.FirstOrDefaultAsync(follow => follow.Id == followId);
          }

          public async Task<Follow?> UpdateFollow(Follow follow)
          {
               _context.Follows.Update(follow);
               await _context.SaveChangesAsync();
               return follow;
          }
     }
}
