using BE.Attributes;
using BE.Dto.User;
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
        public async Task<ReturnResponseDto> GoogleResponse()
        {
            return await _userService.GoogleResponse();
        }

        [HttpPost]
        [Route("user-login")]
        public async Task<UserLoginToken> Login([FromForm] UserLoginDto userLoginDto){
            return await _userService.Login(userLoginDto);
        }

        [HttpPost]
        [Route("user-register")]
        public async Task<UserLoginToken> Register([FromForm] RegisterDto registerDto){
            return await _userService.Register(registerDto);
        }

        [HttpPut]
        [Route("forgot-password")]
        public async Task<UserLoginToken> Forgot([FromForm] string email, [FromForm] ForgotDto forgotDto){
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
    }
}