using BE.Models;

namespace BE.Repository.Interface
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();
    }
}