using BE.Dto.User;
using BE.Dto.UserLogin;
using BE.Models;
using BE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BE.Controllers
{
    [ApiController]
    [Route("api/v1/web/user")]
    public class UserWebController
    {
        private readonly IUserService _userService;
        public UserWebController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("{email}")]
        public async Task<User> GetUserByEmail([FromRoute] string email)
        {
           return await _userService.GetUserByEmail(email);
        }

        [HttpGet("login-facebook")]
        public Task LoginWithFaceBook(){
            return _userService.LoginWithFacebook();
        }

        [HttpGet("facebook-response")]
        public async Task<string> FacebookResponse(){
            return await _userService.FacebookResponse();
        }

        [HttpGet("login-google")]
        public Task<string> LoginWithGoogle()
        {
            return _userService.LoginWithGoogle();
        }

        [HttpGet("signin-google")]
        public Task GoogleResponse(){
           return _userService.GoogleResponse(); 
        }

        [HttpPost("login")]
        public async Task<UserLoginToken> Login([FromBody] UserLoginDto userLoginDto){
            return await _userService.Login(userLoginDto);
        }

        [HttpPost("register")]
        public async Task<UserLoginToken> Register([FromBody] RegisterDto registerDto){
            return await _userService.Register(registerDto);
        }

        [HttpPut("forgot")]
        [Route("{email}")]
        public async Task<UserLoginToken> Forgot([FromRoute] string email, [FromBody] ForgotDto forgotDto){
            return await _userService.Forgot(email, forgotDto);
        }
    }
}