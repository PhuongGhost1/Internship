using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.Email;

namespace BE.Repository.Interface
{
    public interface IEmailService
    {
        Task SendEmail(string emailTo, string subject, string htmlBody); //EmailDto emailDto
    }
}