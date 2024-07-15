using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using BE.Models;
using BE.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace BE.Repository.Implementations
{
    public class TokenRepository : ITokenRepository
    {
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _key;
        private readonly CourseOnlContext _context;
        public TokenRepository(IConfiguration config, CourseOnlContext context)
        {

            _config = config;
            _context = context;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SigningKey"]));
        }

        public string CreateRandomNumber(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException("Size must be greater than 0.", nameof(size));
            }

            char[] chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            byte[] data = new byte[size];
            RandomNumberGenerator.Fill(data);

            var result = new StringBuilder(size);
            for (int i = 0; i < size; i++)
            {
                var idx = data[i] % chars.Length;
                result.Append(chars[idx]);
            }

            return result.ToString();
        }

        public string CreateToken(User user)
        {
            var claims = new List<Claim> {
                new Claim("id", user.Id)
            };

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = creds,
                Expires = DateTime.Now.AddDays(1),
                Issuer = _config["Issuer"],
                Audience = _config["Audience"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
        public async Task<User?> DecodeUserToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);
            var claims = jwtToken.Claims;

            User? u = null;

            foreach (var claim in claims)
            {
                if (claim.Type == "id")
                {
                    u = await _context.Users.FirstOrDefaultAsync(u => u.Id == claim.Value);
                }
            }

            return u;
        }
    }
}