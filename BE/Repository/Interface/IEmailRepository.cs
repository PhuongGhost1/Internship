using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.Email;

namespace BE.Repository.Interface
{
    public interface IEmailRepository
    {
        Task<EmailSendResultDto> SendEmail(string emailTo, string subject, string htmlBody); //EmailDto emailDto
    }
}