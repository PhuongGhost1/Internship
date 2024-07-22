using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.Cart;

namespace BE.Dto.User
{
    public class UserCartDto
    {
        public string? Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public List<CartDTO> Carts { get; set; } = new List<CartDTO>();
    }
}