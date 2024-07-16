using BE.Models;

namespace BE.Repository.Interface
{
    public interface IFeedbackRepository
    {
        Task<Feedback> AddAsync(Feedback feedback);
        Task<Feedback> UpdateAsync(Feedback feedback);
        Task DeleteAsync(string id);
        Task<Feedback?> GetByIdAsync(string id);
        Task<List<Feedback>> GetAllAsync();
    }
}
