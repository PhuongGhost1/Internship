using BE.Dto.Email;
using BE.Repository.Interface;
using BE.Services.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace BE.Services.Implementations
{
    public class EmailService : IEmailService
    {
        private readonly IEmailRepository _emailRepo;
        private readonly IUserRepository _userRepo;
        public EmailService(IEmailRepository emailRepo, IUserRepository userRepo)
        {
            _emailRepo = emailRepo;
            _userRepo = userRepo;
        }

        public async Task<EmailSendResultDto> SendEmail(string email, string subject, string htmlBody)
        {
            if(await _userRepo.CheckEmailExist(email)) throw new Exception("User is exist!");

            return await _emailRepo.SendEmail(email, subject, htmlBody);
        }
    }
}