using BE.Models;

namespace BE.Repository.Interface
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();
        Task<User> GetUsers(User user);
    }
}