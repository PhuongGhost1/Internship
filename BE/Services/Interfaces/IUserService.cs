using BE.Dto.Course;
using BE.Dto.User;
using BE.Dto.User.AdminManagement;
using BE.Dto.User.Instructor;
using BE.Dto.UserLogin;
using BE.Models;
using Microsoft.AspNetCore.Mvc;

namespace BE.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserByEmail(string email);
        Task<ReturnLoginDto> LoginWithFacebook();
        Task<ReturnResponseDto> FacebookResponse();
        Task<ReturnLoginDto> LoginWithGoogle();
        Task<string> GoogleResponse();
        Task<UserLoginToken> Login(UserLoginDto userLoginDto);
        Task<UserLoginToken> Register(RegisterDto registerDto);
        Task<UserLoginToken> Forgot(string email, ForgotDto forgotDto);
        Task<bool> CreateUserData(string username, string email, string password, string description, string phone, string role);
        Task<(int a, int c)> GetUserStatisticsAsync();
        Task<double?> GetPercentageChangeForStudentAccountsLastMonthAsync();
        Task<double?> GetPercentageChangeForInstructorAccountsLastMonthAsync();
        Task<int?> CountAccountsByRoleForMonthAsync(string roleName, DateTime month);
        Task<List<UserInfoManageByAdminDto>> GetUserRoleAsync(string roleName);
        Task<bool> UpdateUserStatusAsync(string userId);
        Task<List<FeedbackRequestDto>> GetFeedbacksManagementByAdminAsync();
        Task<List<ReportManagementByAdminDto>> GetReportManagementByAdminAsync();
        Task<bool> UpdateUserCommentReportStatusAsync(string? userId, string reportId, string? commentId, string? courseId);
        Task<User> GetUserByToken(string token);
        Task<bool> UpdateUserProfile(UserProfileDto user);
        Task<User> GetUSerById(string id);
        Task<InstructorProfileDto> GetInstructorProfileByInsIdAsync(string insId);
        Task<InstructorProfileDto> GetInstructorProfileWithWaitingCourseByInsId(string insId);
        Task<UserProfileBeSeenDto> GetUserProfileBeSeenDataAsync(string userId);
        Task<Role> GetUserRole(string userId);
    }
}
