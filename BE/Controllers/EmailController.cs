using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.Email;
using BE.Repository.Interface;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;

namespace BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly IUserRepository _userRepo;
        public EmailController(IEmailService emailService, IUserRepository userRepo)
        {
            _emailService = emailService;
            _userRepo = userRepo;
        }

        [HttpPost("register-email/{email}")]
        public async Task<IActionResult> RegisterEmail([FromRoute] string email){ //EmailDto emailDto
            if(!ModelState.IsValid) return BadRequest(ModelState);

            if(await _userRepo.CheckEmailExist(email)) return Unauthorized("User is exist!");

            await _emailService.SendEmail(email, "Xac nhan dia chi email qua phan dang ki", "<a href='http://localhost:5173/signup'>Nhan tai day</a>");
            return Ok();
        }

        [HttpPost("forgot-email/{email}")]
        public async Task<IActionResult> ForgotEmail([FromRoute] string email){ //EmailDto emailDto
            if(!ModelState.IsValid) return BadRequest(ModelState);

            if(!await _userRepo.CheckEmailExist(email)) return Unauthorized("User is not exist!");

            await _emailService.SendEmail(email, "Xac nhan dia chi email qua phan thay doi mat khau", "<a href='http://localhost:5173/forgotPass'>Nhan tai day</a>");
            return Ok();
        }
    }
}