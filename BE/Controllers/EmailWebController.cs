using BE.Attributes;
using BE.Dto.Email;
using BE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BE.Controllers
{
    [ApiController]
    [Route("api/v1/web/email")]
    [ApiExplorerSettings(GroupName = "Email")]
    public class EmailWebController : ControllerBase
    {
        private readonly IEmailService _emailService;
        public EmailWebController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [CustomAuthorize("Student")]
        [HttpPost]
        [Route("register-email")]
        public async Task<EmailSendResultDto> RegisterEmail([FromForm] EmailDto emailDto){ //EmailDto emailDto
            return await _emailService.SendEmail(emailDto);
        }

        [CustomAuthorize("Student")]
        [HttpPost]
        [Route("forgot-email")]
        public async Task<EmailSendResultDto> ForgotEmail([FromForm] EmailDto emailDto){ //EmailDto emailDto
            return await _emailService.SendEmail(emailDto);
        }
    }
}