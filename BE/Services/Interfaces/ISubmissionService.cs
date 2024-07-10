using BE.Dto.Submission;
using BE.Models;
using BE.Dto;

namespace BE.Services.Interfaces
{
    public interface ISubmissionService
    {
        Task<Submission> CreateSubmissionAsync(CreateSubmissionDTO createSubmissionDto);
        Task<Submission> UpdateSubmissionAsync(UpdateSubmissionDTO updateSubmissionDto);
        Task DeleteSubmissionAsync(string id);
        Task<Submission?> GetSubmissionByIdAsync(string id);
        Task<List<Submission>> GetAllSubmissionsAsync();
    }
}
