using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.Email;

namespace BE.Services.Interfaces
{
    public interface IEmailService
    {
        Task<EmailSendResultDto> SendEmail(EmailDto emailDto);
    }
}