using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Models;

namespace BE.Repository.Interface
{
    public interface ITokenRepository
    {
        public string CreateToken(User user);
        public string CreateRandomNumber(int length);
        Task<User?> DecodeUserToken(string token);
    }
}