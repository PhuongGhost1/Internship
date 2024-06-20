using System.Net;
using BE.Dto.UserLogin;
using BE.Models;
using BE.Repository.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;

namespace BE.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        private readonly ITokenService _tokenService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _config;

        public UserController(IUserRepository userRepo, UserManager<User> userManager, SignInManager<User> signInManager, ITokenService tokenService, IConfiguration config)
        {
            _userRepo = userRepo;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _config = config;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var users = await _userRepo.GetUsers();

            if(users == null) return BadRequest("Chua co user nao trong he thong!");
            
            return Ok(users);
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var user = await _userRepo.GetUserByEmail(email);

            if(user == null) return NotFound();

            return Ok(user);
        }

        [HttpGet("login-facebook")]
        public IActionResult LoginWithFaceBook(){
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var properties = new AuthenticationProperties{
                RedirectUri = Url.Action("FacebookResponse")
            };

            return Challenge(properties, FacebookDefaults.AuthenticationScheme);
        }

        [HttpGet("facebook-response")]
        public async Task<IActionResult> FacebookResponse(){
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            if(!result.Succeeded) return BadRequest("Error during Facebook Authenticated");

            var claims = result.Principal.Identities
                                .FirstOrDefault()?.Claims.Select(claim => new {
                                    claim.Type,
                                    claim.Value
                                });

            var claimsJson = JsonConvert.SerializeObject(claims);
            var redirectUrl = $"http://localhost:5173/login-success?claims={WebUtility.UrlEncode(claimsJson)}";
            return Redirect(redirectUrl);
        }

        [HttpGet("login-google")]
        public IActionResult LoginWithGoogle()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var clientId = _config["Google:ClientId"];
            if (string.IsNullOrEmpty(clientId))
            {
                return BadRequest("Google Client ID is missing in the configuration.");
            }

            var redirectUri = Url.Action("GoogleResponse", "User", null, Request.Scheme);
            if (string.IsNullOrEmpty(redirectUri))
            {
                return BadRequest("Failed to generate redirect URI.");
            }

            var scope = "openid profile email";
            var state = Guid.NewGuid().ToString(); 

            try
            {
                var authUrl = $"https://accounts.google.com/o/oauth2/v2/auth/oauthchooseaccount?client_id={Uri.EscapeDataString(clientId)}&scope={Uri.EscapeDataString(scope)}&response_type=code&redirect_uri={Uri.EscapeDataString(redirectUri)}&code_challenge=MipAebOUST-P-4dHjpTDzhy5Hl8h0dlaGD9yXMQkOuc&code_challenge_method=S256&state={Uri.EscapeDataString(state)}&service=lso&o2v=2&ddm=0&flowName=GeneralOAuthFlow";
                return Ok(new { url = authUrl });
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest($"Error generating authentication URL: {ex.Message}");
            }
        }

        [HttpGet("signin-google")]
        public IActionResult GoogleResponse(){
            var code = Request.Query["code"];
            var state = Request.Query["state"];
            if (string.IsNullOrEmpty(code) || string.IsNullOrEmpty(state))
            {
                return BadRequest("Invalid response from Google.");
            }

            return Ok("Google OAuth callback received");
        }

        // [HttpGet("google-response")]
        // public async Task<IActionResult> GoogleResponse(){
        //     if(!ModelState.IsValid) return BadRequest(ModelState);

        //     var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            
        //     if(!result.Succeeded) return BadRequest("Errors during google authenticated");

        //     var claims = result.Principal.Identities
        //                         .FirstOrDefault()?.Claims.Select(claim => new {
        //                             claim.Type,
        //                             claim.Value
        //                         });

        //     var claimsJson = JsonConvert.SerializeObject(claims);
        //     var redirectUrl = $"http://localhost:5173/login-success?claims={WebUtility.UrlEncode(claimsJson)}";
        //     return Redirect(redirectUrl);
        // }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto){
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email.ToLower() == userLoginDto.Email.ToLower());

            if(user == null) return Unauthorized("User not found!");

            var result = await _signInManager.CheckPasswordSignInAsync(user, userLoginDto.Password, false); 

            if(!result.Succeeded) return Unauthorized("Email or Password wrong!");

            return Ok(new UserLoginToken{
                Token = _tokenService.CreateToken(user)
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto){
            try
            {
                if(!ModelState.IsValid) return BadRequest(ModelState);

                var user = new User{
                    UserName = registerDto.UserName,
                    Email = registerDto.Email
                };

                var createUser = await _userManager.CreateAsync(user, registerDto.Password);

                if(createUser.Succeeded){
                    return Ok(new UserLoginToken{
                        Token = _tokenService.CreateToken(user)
                    });
                }else{
                    return StatusCode(401, "Cannot create");
                }
            }
            catch (Exception e)
            {
                return StatusCode(401, e);
            }
        }
    }
}