using BE.Dto.User;
using BE.Models;

namespace BE.Repository.Interface
{
    public interface IUserRepository
    {
        Task<User?> CreateUser(User user);
        Task<User?> UpdateUser(ForgotDto forgotDto, string email);
        Task<User?> GetUserByEmail(string email);
        Task<User?> CheckUserLogin(string username, string password);
        Task<bool> CheckPasswordExist(string password);
        Task<bool> CheckEmailExist(string email);
        Task<bool> CheckUserExistById(string userId);
        Task<bool> CreateUserData(string username, string email, string password, string description, string phone, )
    }
}