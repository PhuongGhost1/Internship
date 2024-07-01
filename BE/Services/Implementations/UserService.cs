using System.Net;
using BE.Dto.User;
using BE.Dto.UserLogin;
using BE.Models;
using BE.Repository.Interface;
using BE.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Facebook;
using Newtonsoft.Json;

namespace BE.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly ITokenRepository _tokenRepo;
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IUserRepository userRepo, ITokenRepository tokenRepo, IConfiguration config,
                        IHttpContextAccessor httpContextAccessor)
        {
            _userRepo = userRepo;
            _tokenRepo = tokenRepo;
            _config = config;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> CreateUserData(string username, string email, string password, string description, string phone, string role)
        {
            return await _userRepo.CreateUserData(username, email, password, description, phone, role);
        }

        public async Task<ReturnResponseDto> FacebookResponse()
        {
            var result = await _httpContextAccessor.HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            if (!result.Succeeded)
            {
                throw new Exception("Error during Facebook authentication");
            }

            var claims = result.Principal.Identities
                                .FirstOrDefault()?.Claims.Select(claim => new
                                {
                                    claim.Type,
                                    claim.Value
                                });

            var claimsJson = JsonConvert.SerializeObject(claims);
            var redirectUrl = $"http://localhost:5173/login-success?claims={WebUtility.UrlEncode(claimsJson)}";
            return new ReturnResponseDto
            {

            };
        }

        public async Task<UserLoginToken> Forgot(string email, ForgotDto forgotDto)
        {
            try
            {
                if (!await _userRepo.CheckEmailExist(email))
                {
                    throw new Exception("Email not found");
                }

                if (forgotDto.ConfirmPassword != forgotDto.Password)
                {
                    throw new Exception("Confirmed password does not match the password");
                }

                if (await _userRepo.CheckPasswordExist(forgotDto.Password))
                {
                    throw new Exception("The new password cannot be the same as the old password");
                }

                var user = await _userRepo.UpdateUser(forgotDto, email);

                if (user != null)
                {
                    return new UserLoginToken
                    {
                        Token = _tokenRepo.CreateToken(user)
                    };
                }
                else
                {
                    throw new Exception("Unable to create");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _userRepo.GetUserByEmail(email);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            return user;
        }

        public async Task<ReturnResponseDto> GoogleResponse()
        {
            var code = _httpContextAccessor.HttpContext.Request.Query["code"];
            var state = _httpContextAccessor.HttpContext.Request.Query["state"];
            if (string.IsNullOrEmpty(code) || string.IsNullOrEmpty(state))
            {
                throw new Exception("Invalid Google response");
            }

            return new ReturnResponseDto
            {
                Code = code,
                State = state
            };
        }

        public async Task<UserLoginToken> Login(UserLoginDto userLoginDto)
        {
            var user = await _userRepo.CheckUserLogin(userLoginDto.Username, userLoginDto.Password);

            if (user == null)
            {
                throw new Exception("Incorrect username or password");
            }

            return new UserLoginToken
            {
                Token = _tokenRepo.CreateToken(user)
            };
        }

        public async Task<ReturnLoginDto> LoginWithFacebook()
        {
            var properties = new AuthenticationProperties
            {
                RedirectUri = _httpContextAccessor.HttpContext.Request.Host + "/User/FacebookResponse"
            };

            // return await _httpContextAccessor.HttpContext.ChallengeAsync(FacebookDefaults.AuthenticationScheme, properties);
            return new ReturnLoginDto
            {

            };
        }

        public async Task<ReturnLoginDto> LoginWithGoogle()
        {
            var clientId = _config["Google:ClientId"];
            if (string.IsNullOrEmpty(clientId))
            {
                throw new Exception("Google Client ID is missing in the configuration");
            }

            var redirectUri = _httpContextAccessor.HttpContext.Request.Host + "/User/GoogleResponse";
            if (string.IsNullOrEmpty(redirectUri))
            {
                throw new Exception("Failed to generate the redirect URI");
            }

            var scope = "openid profile email";
            var state = Guid.NewGuid().ToString();

            try
            {
                var authUrl = $"https://accounts.google.com/o/oauth2/v2/auth?client_id={Uri.EscapeDataString(clientId)}&scope={Uri.EscapeDataString(scope)}&response_type=code&redirect_uri={Uri.EscapeDataString(redirectUri)}&state={Uri.EscapeDataString(state)}";

                return new ReturnLoginDto
                {
                    ReturnAuthUrl = authUrl
                };
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception($"Error generating authentication URL: {ex.Message}");
            }
        }

        public async Task<UserLoginToken> Register(RegisterDto registerDto)
        {
            try
            {
                if (await _userRepo.CheckEmailExist(registerDto.Email))
                {
                    throw new Exception("Email already exists");
                }

                var user = new User
                {
                    Id = _tokenRepo.CreateRandomNumber(20),
                    Username = registerDto.UserName,
                    Email = registerDto.Email,
                    Password = registerDto.Password,
                    CreateAt = DateTime.Now
                };

                var createdUser = await _userRepo.CreateUser(user);

                if (createdUser != null)
                {
                    return new UserLoginToken
                    {
                        Token = _tokenRepo.CreateToken(user)
                    };
                }
                else
                {
                    throw new Exception("Unable to create user");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
