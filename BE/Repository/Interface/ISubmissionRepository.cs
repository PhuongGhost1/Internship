using BE.Models;

namespace BE.Repository.Interface
{
    public interface ISubmissionRepository
    {
    Task<Submission> AddAsync(Submission Submission);
     Task<Submission> UpdateAsync(Submission Submission);
    Task DeleteAsync(string id);
    Task<Submission?> GetByIdAsync(string id);
    Task<List<Submission>> GetAllAsync();
    }
}
