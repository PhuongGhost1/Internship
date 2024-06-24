using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BE.Dto.UserLogin
{
    public class RegisterDto
    {
        [Required]
        public string UserName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "{0} must be above {2} and under {1}")]
        [Display(Name = "Password")]
        public string Password { get; set; } = string.Empty;
    }
}