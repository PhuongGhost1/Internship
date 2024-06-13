using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Models;

namespace BE.Dto.UserLogin
{
    public static class UserLoginRequestDto
    {
        public static User ToGetUser(this UserLoginDto userLoginDto){
            return new User{
                Email = userLoginDto.Email,
                Password = userLoginDto.Password
            };
        }
    }
}