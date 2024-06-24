using BE.Dto.User;
using BE.Dto.UserLogin;
using BE.Models;

namespace BE.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserByEmail(string email);
        Task<ReturnLoginDto> LoginWithFacebook();
        Task<ReturnResponseDto> FacebookResponse();
        Task<ReturnLoginDto> LoginWithGoogle();
        Task<ReturnResponseDto> GoogleResponse();
        Task<UserLoginToken> Login(UserLoginDto userLoginDto);
        Task<UserLoginToken> Register(RegisterDto registerDto);
        Task<UserLoginToken> Forgot(string email, ForgotDto forgotDto);
    }
}