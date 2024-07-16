using BE.Dto.Feedback;
using BE.Models;

namespace BE.Services.Interfaces
{
    public interface IFeedbackService
    {
        Task<Feedback> CreateFeedbackAsync(CreateFeedbackDTO createFeedbackDto);
        Task<Feedback> UpdateFeedbackAsync(UpdateFeedbackDTO updateFeedbackDto);
        Task DeleteFeedbackAsync(string id);
        Task<Feedback?> GetFeedbackByIdAsync(string id);
        Task<List<Feedback>> GetAllFeedbacksAsync();
    }
}
