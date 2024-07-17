using BE.Dto.Submission;
using BE.Models;
using BE.Repository.Interface;
using BE.Services.Interfaces;

namespace BE.Services.Implementations
{
    public class SubmissionService : ISubmissionService
    {
        private readonly ISubmissionRepository _submissionRepository;

        public SubmissionService(ISubmissionRepository submissionRepository)
        {
            _submissionRepository = submissionRepository;
        }

        public async Task<Submission> CreateSubmissionAsync(CreateSubmissionDTO createSubmissionDto)
        {
            var submission = new Submission
            {
                Id = Guid.NewGuid().ToString(),
                QuizId = createSubmissionDto.QuizId,
                UserId = createSubmissionDto.UserId,
                Grade = createSubmissionDto.Grade,
                Date = createSubmissionDto.Date ?? DateTime.UtcNow,
                IsPass = createSubmissionDto.IsPass
            };

            return await _submissionRepository.AddAsync(submission);
        }

        public async Task<Submission> UpdateSubmissionAsync(UpdateSubmissionDTO updateSubmissionDto)
        {
            var submission = await _submissionRepository.GetByIdAsync(updateSubmissionDto.Id);
            if (submission == null)
            {
                throw new KeyNotFoundException("Submission not found");
            }

            submission.QuizId = updateSubmissionDto.QuizId;
            submission.UserId = updateSubmissionDto.UserId;
            submission.Grade = updateSubmissionDto.Grade;
            submission.Date = updateSubmissionDto.Date;
            submission.IsPass = updateSubmissionDto.IsPass;

            return await _submissionRepository.UpdateAsync(submission);
        }

        public async Task DeleteSubmissionAsync(string id)
        {
            await _submissionRepository.DeleteAsync(id);
        }

        public async Task<Submission?> GetSubmissionByIdAsync(string id)
        {
            return await _submissionRepository.GetByIdAsync(id);
        }

        public async Task<List<Submission>> GetAllSubmissionsAsync()
        {
            return await _submissionRepository.GetAllAsync();
        }
    }
}
