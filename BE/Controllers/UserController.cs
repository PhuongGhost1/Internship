using BE.Dto.UserLogin;
using BE.Models;
using BE.Repository.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public UserController(IUserRepository userRepo, UserManager<User> userManager, SignInManager<User> signInManager, ITokenService tokenService)
        {
            _userRepo = userRepo;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepo.GetUsers();
            return Ok(users);
        }

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