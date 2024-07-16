using BE.Dto.Feedback;
using BE.Models;
using BE.Repository.Interface;
using BE.Services.Interfaces;

namespace BE.Services.Implementations
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbackService(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        public async Task<Feedback> CreateFeedbackAsync(CreateFeedbackDTO createFeedbackDto)
        {
            var feedback = new Feedback
            {
                Id = Guid.NewGuid().ToString(),
                UserId = createFeedbackDto.UserId,
                Title = createFeedbackDto.Title,
                Description = createFeedbackDto.Description,
                IsRead = createFeedbackDto.IsRead,
            };

            return await _feedbackRepository.AddAsync(feedback);
        }

        public async Task<Feedback> UpdateFeedbackAsync(UpdateFeedbackDTO updateFeedbackDto)
        {
            var feedback = await _feedbackRepository.GetByIdAsync(updateFeedbackDto.Id);
            if (feedback == null)
            {
                throw new KeyNotFoundException("Feedback not found");
            }

            feedback.UserId = updateFeedbackDto.UserId;
            feedback.Title = updateFeedbackDto.Title;
            feedback.Description = updateFeedbackDto.Description;
            feedback.IsRead = updateFeedbackDto.IsRead;

            return await _feedbackRepository.UpdateAsync(feedback);
        }

        public async Task DeleteFeedbackAsync(string id)
        {
            await _feedbackRepository.DeleteAsync(id);
        }

        public async Task<Feedback?> GetFeedbackByIdAsync(string id)
        {
            return await _feedbackRepository.GetByIdAsync(id);
        }

        public async Task<List<Feedback>> GetAllFeedbacksAsync()
        {
            return await _feedbackRepository.GetAllAsync();
        }
    }
}
