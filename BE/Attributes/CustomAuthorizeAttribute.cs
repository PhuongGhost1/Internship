using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BE.Attributes
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute, IAsyncAuthorizationFilter
    {
        private readonly string[] _roles;

        public CustomAuthorizeAttribute(params string[] roles)
        {
            _roles = roles;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;
            if (!user.Identity.IsAuthenticated)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var roleService = context.HttpContext.RequestServices.GetService(typeof(IRoleService)) as IRoleService;
            var userId = user.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;

            if (userId == null)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var userRoles = await roleService.GetUserRoleAsync(userId);

            if (!_roles.Any(role => userRoles.Contains(role)))
            {
                context.Result = new ForbidResult();
                return;
            }
        }
    }
}