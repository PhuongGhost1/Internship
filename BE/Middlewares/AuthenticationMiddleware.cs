
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace BE.Middlewares
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _config;
        public AuthenticationMiddleware(RequestDelegate next, IConfiguration config)
        {
            _next = next;
            _config = config;
        }

        public async Task InvokeAsync(HttpContext context)
        {   
            if (context.Request.Path.StartsWithSegments("/api/v1/web/user/user-login") || context.Request.Path.StartsWithSegments("/api/v1/web/user/user-register"))
            {
                await _next(context);
                return;
            }

            if (!context.Request.Headers.ContainsKey("Authorization"))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Authorization header missing");
                return;
            }

            var token = context.Request.Headers["Authorization"].ToString();
            
            if (!ValidateToken(token))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Invalid token");
                return;
            }

            // var header = context.Request.Headers["Authorization"].ToString();
            // var encodedCreds = header.Substring(6);
            // var creds = Encoding.UTF8.GetString(Convert.FromBase64String(encodedCreds));
            // string[] uidpwd = creds.Split(':');
            // var uid = uidpwd[0];
            // var pwd = uidpwd[1];
            
            // if (uid != "john" || pwd != "password")
            // {
            //     context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            //     await context.Response.WriteAsync("Invalid uidpwd");
            //     return;
            // }

            await _next(context);
        }

        private bool ValidateToken(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_config["JWT:SigningKey"]);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                }, out SecurityToken validatedToken);

                return validatedToken != null;
            }
            catch
            {
                return false;
            }
        }
    }
}