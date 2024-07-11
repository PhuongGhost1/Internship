using BE.Dto.User;
using BE.Models;
using BE.Repository.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

        public async Task<User?> UpdateUser(ForgotDto forgotDto, string email)
        {
            var userModel = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (userModel == null) return null;

            userModel.Password = forgotDto.Password;

            await _context.SaveChangesAsync();

            return userModel;
        }
    }
}