using BE.Dto.User;
using BE.Dto.UserLogin;
using BE.Models;
using BE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BE.Controllers
{
    [Route("api/v1/web/user")]
    [ApiController]
    public class UserWebController
    {
        private readonly IUserService _userService;
        public UserWebController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("find-user/{email}")]
        public async Task<User> GetUserByEmail([FromRoute] string email)
        {
           return await _userService.GetUserByEmail(email);
        }

        [HttpGet("login-facebook")]
        public async Task<ReturnLoginDto> LoginWithFaceBook(){
            return await _userService.LoginWithFacebook();
        }

        [HttpGet("facebook-response")]
        public async Task<ReturnResponseDto> FacebookResponse(){
            return await _userService.FacebookResponse();
        }

        [HttpGet("login-google")]
        public async Task<ReturnLoginDto> LoginWithGoogle()
        {
            return await _userService.LoginWithGoogle();
        }

        [HttpGet("signin-google")]
        public async Task<ReturnResponseDto> GoogleResponse(){
           return await _userService.GoogleResponse(); 
        }

        [HttpPost("login")]
        public async Task<UserLoginToken> Login([FromBody] UserLoginDto userLoginDto){
            return await _userService.Login(userLoginDto);
        }

        [HttpPost("register")]
        public async Task<UserLoginToken> Register([FromBody] RegisterDto registerDto){
            return await _userService.Register(registerDto);
        }

        [HttpPut("forgot/{email}")]
        public async Task<UserLoginToken> Forgot([FromRoute] string email, [FromBody] ForgotDto forgotDto){
            return await _userService.Forgot(email, forgotDto);
        }
    }
}