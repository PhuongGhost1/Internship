using System.Net;
using System.Net.Http.Headers;
using BE.Dto.User;
using BE.Dto.User.AdminManagement;
using BE.Dto.User.Instructor;
using BE.Dto.UserLogin;
using BE.Models;
using BE.Repository.Interface;
using BE.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<double?> GetPercentageChangeForInstructorAccountsLastMonthAsync()
        {
            return await _userRepo.GetPercentageChangeForInstructorAccountsLastMonth();
        }

        public async Task<double?> GetPercentageChangeForStudentAccountsLastMonthAsync()
        {
            return await _userRepo.GetPercentageChangeForStudentAccountsLastMonth();
        }

        public async Task<int?> CountAccountsByRoleForMonthAsync(string roleName, DateTime month)
        {
            return await _userRepo.CountAccountsByRoleForMonth(roleName, month);
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

        public async Task<(int a, int c)> GetUserStatisticsAsync()
        {
            return await _userRepo.GetUserStatisticsAsync();
        }

        public async Task<string> GoogleResponse()
        {
            var request = _httpContextAccessor.HttpContext?.Request;
            if (request == null)
            {
                throw new Exception("HTTP Request is not available.");
            }

            var code = request.Query["code"];
            var state = request.Query["state"];

            if (string.IsNullOrEmpty(code) || string.IsNullOrEmpty(state))
            {
                throw new Exception("Invalid Google response");
            }

            GoogleTokenResponse tokenResponse;
            try
            {
                tokenResponse = await GetGoogleAccessTokenAsync(code);
            }
            catch (Exception ex)
            {
                // Log the exception
                throw new Exception("Failed to get Google access token: " + ex.Message);
            }

            if (tokenResponse == null || string.IsNullOrEmpty(tokenResponse.AccessToken))
            {
                throw new Exception("Failed to retrieve access token from Google");
            }

            GoogleUserInfo userInfo;
            try
            {
                userInfo = await GetGoogleUserInfoAsync(tokenResponse.AccessToken);
            }
            catch (Exception ex)
            {
                // Log the exception
                throw new Exception("Failed to get user info from Google: " + ex.Message);
            }

            if (userInfo == null)
            {
                throw new Exception("Failed to retrieve user info from Google");
            }

            User user;
            try
            {
                user = await _userRepo.GetUserLoginGoogle(userInfo.Email);
                if (user == null)
                {
                    await _userRepo.CreateUserGoogle(userInfo.Email);
                    user = await _userRepo.GetUserLoginGoogle(userInfo.Email);
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                throw new Exception("Failed to handle user data: " + ex.Message);
            }
            var token = _tokenRepo.CreateToken(user);

            var redirectUrl = $"http://localhost:5173/sign-in?token={Uri.EscapeDataString(token)}";

            return redirectUrl;
        }

        private async Task<GoogleTokenResponse> GetGoogleAccessTokenAsync(string code)
        {
            using (var httpClient = new HttpClient())
            {
                var requestParams = new Dictionary<string, string>
        {
            { "code", code },
            { "client_id", _config["Google:ClientId"] },
            { "client_secret", _config["Google:ClientSecret"] },
            { "redirect_uri", $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}/api/v1/web/user/signin-google" },
            { "grant_type", "authorization_code" }
        };

                var requestContent = new FormUrlEncodedContent(requestParams);
                var response = await httpClient.PostAsync("https://oauth2.googleapis.com/token", requestContent);

                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<GoogleTokenResponse>(responseContent);
            }
        }

        private async Task<GoogleUserInfo> GetGoogleUserInfoAsync(string accessToken)
        {
            using (var httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "https://www.googleapis.com/oauth2/v2/userinfo");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                var response = await httpClient.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<GoogleUserInfo>(responseContent);
            }
        }


        public async Task<UserLoginToken> Login(UserLoginDto userLoginDto)
        {
            var user = await _userRepo.CheckUserLogin(userLoginDto.Username, userLoginDto.Password);

            if (user == null)
            {
                return new UserLoginToken
                {
                    Token = null
                };
            }

            return new UserLoginToken
            {
                Token = _tokenRepo.CreateToken(user)
            };
        }

        public async Task<User?> GetUserByToken(string token)
        {
            return await _tokenRepo.DecodeUserToken(token);
        }

        public async Task<ReturnLoginDto> LoginWithFacebook()
        {
            var properties = new AuthenticationProperties
            {
                RedirectUri = _httpContextAccessor.HttpContext.Request.Host + "/User/FacebookResponse"
            };

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

            var redirectUri = "http://localhost:5144/api/v1/web/user/signin-google";

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

        public async Task<List<UserInfoManageByAdminDto>> GetUserRoleAsync(string roleName)
        {
            var result = await _userRepo.GetInstructors(roleName);

            if (result == null || result.Count == 0) return new List<UserInfoManageByAdminDto>();

            return result;
        }

        public async Task<bool> UpdateUserStatusAsync(string userId)
        {
            var user = await _userRepo.GetUserById(userId);

            if (user == null) throw new Exception("Unable to find user!");

            return await _userRepo.UpdateUserStatus(userId);
        }

        public async Task<List<FeedbackRequestDto>> GetFeedbacksManagementByAdminAsync()
        {
            var feedback = await _userRepo.GetFeedbacksManagementByAdmin();

            if (feedback == null || feedback.Count == 0) return new List<FeedbackRequestDto>();

            return feedback;
        }

        public async Task<List<ReportManagementByAdminDto>> GetReportManagementByAdminAsync()
        {
            var reports = await _userRepo.GetReportManagementByAdmin();

            if (reports == null || reports.Count == 0) return new List<ReportManagementByAdminDto>();

            return reports;
        }

        public async Task<bool> UpdateUserCommentReportStatusAsync(string? userId, string reportId, string? commentId, string? courseId)
        {
            return await _userRepo.UpdateUserCommentReportStatus(userId, reportId, commentId, courseId);
        }

        public async Task<bool> UpdateUserProfile(UserProfileDto user)
        {
            return await _userRepo.UpdateUserProfile(user);
        }

        public async Task<User> GetUSerById(string id)
        {
            return await _userRepo.GetUserById(id);
        }

        public async Task<InstructorProfileDto> GetInstructorProfileByInsIdAsync(string insId)
        {
            var user = await _userRepo.GetUserById(insId);

            if (user == null) return new InstructorProfileDto();

            return await _userRepo.GetInstructorProfileByInsId(insId);
        }

        public async Task<InstructorProfileDto> GetInstructorProfileWithWaitingCourseByInsId(string insId)
        {
            var user = await _userRepo.GetUserById(insId);

            if (user == null) return new InstructorProfileDto();

            return await _userRepo.GetInstructorProfileWithWaitingCourseByInsId(insId);
        }
    }
}
