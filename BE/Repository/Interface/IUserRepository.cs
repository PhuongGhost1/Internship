using BE.Dto.User;
using BE.Dto.User.AdminManagement;
using BE.Dto.User.Instructor;
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
                Task<bool> CreateUserData(string username, string email, string password, string description, string phone, string role);
                Task<User?> GetUserById(string userId);
                Task<(int a, int c)> GetUserStatisticsAsync();
                Task<double?> GetPercentageChangeForStudentAccountsLastMonth();
                Task<double?> GetPercentageChangeForInstructorAccountsLastMonth();
                Task<int?> CountAccountsByRoleForMonth(string roleName, DateTime month);
                Task<List<UserInfoManageByAdminDto>> GetInstructors(string roleName);
                Task<bool> UpdateUserStatus(string userId);
                Task<List<FeedbackRequestDto>> GetFeedbacksManagementByAdmin();
                Task<List<ReportManagementByAdminDto>> GetReportManagementByAdmin();
                Task<bool> UpdateUserCommentReportStatus(string? userId, string reportId, string? commentId, string? courseId);
                Task<List<User?>> GetAllInstructor();

            Task<bool> UpdateUserProfile(UserProfileDto user);
            Task<InstructorProfileDto> GetInstructorProfileByInsId(string insId);
            Task<InstructorProfileDto> GetInstructorProfileWithWaitingCourseByInsId(string insId);
    }
}