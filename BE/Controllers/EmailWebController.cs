using BE.Dto.Email;
using BE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BE.Controllers
{
    [Route("api/v1/web/email")]
    [ApiController]
    public class EmailWebController
    {
        private readonly IEmailService _emailService;
        public EmailWebController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("register-email/{registerEmail}")]
        public async Task<EmailSendResultDto> RegisterEmail([FromRoute] string regiEmail){ //EmailDto emailDto
            return await _emailService.SendEmail(regiEmail, "Xac nhan dia chi email qua phan dang ki", "<a href='http://localhost:5173/signup'>Nhan tai day</a>");
        }

        [HttpPost("forgot-email/{forgotEmail}")]
        public async Task<EmailSendResultDto> ForgotEmail([FromRoute] string forgotEmail){ //EmailDto emailDto
            return await _emailService.SendEmail(forgotEmail, "Xac nhan dia chi email qua phan thay doi mat khau", "<a href='http://localhost:5173/forgotPass'>Nhan tai day</a>");
        }
    }
}