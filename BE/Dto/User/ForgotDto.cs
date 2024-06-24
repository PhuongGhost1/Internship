using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BE.Dto.User
{
    public class ForgotDto
    {
        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "{0} must be above {2} and under {1}")]
        [Display(Name = "Password")]
        public string Password { get; set; } = string.Empty;
        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "{0} must be above {2} and under {1}")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}