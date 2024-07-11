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

        public async Task<EmailSendResultDto> SendEmail(EmailDto emailDto)
        {
            if(await _userRepo.CheckEmailExist(emailDto.To)) throw new Exception("User is exist!");

            return await _emailRepo.SendEmail(emailDto.To, emailDto.Subject, emailDto.Body);
        }
    }
}