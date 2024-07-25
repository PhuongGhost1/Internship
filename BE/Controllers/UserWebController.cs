using BE.Attributes;
using BE.Dto.User;
using BE.Dto.User.AdminManagement;
using BE.Dto.User.Instructor;
using BE.Dto.UserLogin;
using BE.Models;
using BE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static BE.Utils.Utils;

namespace BE.Controllers
{
    [Route("api/v1/web/user")]
    [ApiController]
    public class UserWebController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserWebController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("find-user")]
        public async Task<User> GetUserByEmail([FromForm] string email)
        {
            return await _userService.GetUserByEmail(email);
        }

        [HttpGet]
        [Route("login-facebook")]
        public async Task<ReturnLoginDto> LoginWithFaceBook()
        {
            return await _userService.LoginWithFacebook();
        }

        [HttpGet]
        [Route("facebook-response")]
        public async Task<ReturnResponseDto> FacebookResponse()
        {
            return await _userService.FacebookResponse();
        }

        [HttpGet]
        [Route("login-google")]
        public async Task<ReturnLoginDto> LoginWithGoogle()
        {
            return await _userService.LoginWithGoogle();
        }

        [HttpGet]
        [Route("signin-google")]
        public async Task<IActionResult> GoogleResponse()
        {
            return Redirect(await _userService.GoogleResponse());
        }

        [HttpPost]
        [Route("user-login")]
        public async Task<UserLoginToken> Login([FromForm] UserLoginDto userLoginDto)
        {
            return await _userService.Login(userLoginDto);
        }

        [HttpPost]
        [Route("get-user-token")]
        public async Task<User?> GetUserByToken([FromForm] string token)
        {
            return await _userService.GetUserByToken(token);
        }

        [HttpPost]
        [Route("user-register")]
        public async Task<UserLoginToken> Register([FromForm] RegisterDto registerDto)
        {
            return await _userService.Register(registerDto);
        }

        [HttpPut]
        [Route("forgot-password")]
        public async Task<UserLoginToken> Forgot([FromForm] string email, [FromForm] ForgotDto forgotDto)
        {
            return await _userService.Forgot(email, forgotDto);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromForm] CreateUserData data)
        {
            bool status = await _userService.CreateUserData(data.Username, data.Email, data.Password, data.Description, data.Phone, data.Role);
            return Ok(new
            {
                status = "hi"
            });
        }

        [CustomAuthorize("Admin")]
        [HttpGet("get-statistic")]
        public async Task<(int a, int c)> GetUserStatistic()
        {
            return await _userService.GetUserStatisticsAsync();
        }

        //[CustomAuthorize("Admin")]
        [HttpGet("count-total-student-monthly")]
        public async Task<int?> CountAccountsByStudentRoleForMonthAsync()
        {
            return await _userService.CountAccountsByRoleForMonthAsync("Student", new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1));
        }

        //[CustomAuthorize("Admin")]
        [HttpGet("count-total-instructor-monthly")]
        public async Task<int?> CountAccountsByInstructorForMonthAsync()
        {
            return await _userService.CountAccountsByRoleForMonthAsync("Instructor", new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1));
        }

        //[CustomAuthorize("Admin")]
        [HttpGet("get-instructor-percentage-changes-monthly")]
        public async Task<double?> GetPercentageChangeForInstructorAccountsLastMonthAsync()
        {
            return await _userService.GetPercentageChangeForInstructorAccountsLastMonthAsync();
        }

        //[CustomAuthorize("Admin")]
        [HttpGet("get-student-percentage-changes-monthly")]
        public async Task<double?> GetPercentageChangeForStudentAccountsLastMonthAsync()
        {
            return await _userService.GetPercentageChangeForStudentAccountsLastMonthAsync();
        }

        [HttpPut, Route("update-user-status")]
        public async Task<bool> UpdateUserStatusAsync([FromForm] string userId)
        {
            return await _userService.UpdateUserStatusAsync(userId);
        }

        [HttpGet, Route("get-instructors")]
        public async Task<List<UserInfoManageByAdminDto>> GetInstructorsAsync()
        {
            return await _userService.GetUserRoleAsync("Instructor");
        }

        [HttpGet, Route("get-students")]
        public async Task<List<UserInfoManageByAdminDto>> GetStudentAsync()
        {
            return await _userService.GetUserRoleAsync("Student");
        }

        [HttpGet, Route("get-request-feedbacks")]
        public async Task<List<FeedbackRequestDto>> GetFeedbacksManagementByAdminAsync()
        {
            return await _userService.GetFeedbacksManagementByAdminAsync();
        }

        [HttpGet, Route("get-reports")]
        public async Task<List<ReportManagementByAdminDto>> GetReportManagementByAdminDtosAsync()
        {
            return await _userService.GetReportManagementByAdminAsync();
        }

        [HttpPut, Route("update-report-management-status")]
        public async Task<bool> UpdateUserCommentReportStatusAsync([FromForm] string userId, [FromForm] string reportId, [FromForm] string commentId, [FromForm] string courseId)
        {
            return await _userService.UpdateUserCommentReportStatusAsync(userId, reportId, commentId, courseId);
        }

        [HttpPost, Route("update-profile")]
        public async Task<bool> UpdateUserProfile([FromForm] UserProfileDto user)
        {
            return await _userService.UpdateUserProfile(user);
        }

        [HttpPost, Route("get-user-by-id")]
        public async Task<User> GetUserById([FromForm] string id)
        {
            Console.WriteLine(id);
            return null;
        }

        [HttpGet, Route("get-instructor-profile")]
        public async Task<InstructorProfileDto> GetInstructorProfileByInsIdAsync([FromQuery] string insId)
        {
            return await _userService.GetInstructorProfileByInsIdAsync(insId);
        }

        [HttpGet, Route("get-instructor-profile-on-waiting-courses")]
        public async Task<InstructorProfileDto> GetInstructorProfileForWaitingCoursesByInsIdAsync([FromQuery] string insId)
        {
            return await _userService.GetInstructorProfileWithWaitingCourseByInsId(insId);
        }

        [HttpGet, Route("user-profile-to-seen")]
        public async Task<UserProfileBeSeenDto> GetUserProfileBeSeenDataAsync([FromQuery] string userId)
        {
            return await _userService.GetUserProfileBeSeenDataAsync(userId);
        }
    }
}