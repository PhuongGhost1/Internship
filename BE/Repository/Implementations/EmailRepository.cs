using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using BE.Repository.Interface;
using BE.Dto.Email;

namespace BE.Repository.Implementations
{
    public class MailSettings
    {
        public string Mail { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }

    }
    public class EmailRepository : IEmailRepository
    {
        private readonly MailSettings _mailSettings;
        private readonly ILogger<EmailRepository> _logger;

        public EmailRepository(IOptions<MailSettings> mailSettings, ILogger<EmailRepository> logger)
        {
            _mailSettings = mailSettings.Value;
            _logger = logger;
        }

        public async Task<EmailSendResultDto> SendEmail(string emailTo, string subject, string htmlBody)
        {
            var message = new MimeMessage();
            message.Sender = new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Mail);
            message.From.Add(new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Mail));
            message.To.Add(MailboxAddress.Parse(emailTo));
            message.Subject = subject;

            var builder = new BodyBuilder
            {
                HtmlBody = htmlBody
            };
            message.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();

            try
            {
                smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
                await smtp.SendAsync(message);
                smtp.Disconnect(true);

                _logger.LogInformation("Email sent to " + emailTo);

                return new EmailSendResultDto
                {
                    Success = true,
                    Message = "Email sent successfully.",
                    ErrorDetails = null,
                    Timestamp = DateTime.UtcNow
                };
            }
            catch (Exception ex)
            {
                System.IO.Directory.CreateDirectory("mailssave");
                var emailSaveFile = string.Format(@"mailssave/{0}.eml", Guid.NewGuid());
                await message.WriteToAsync(emailSaveFile);

                _logger.LogInformation("Failed to send email, saved at - " + emailSaveFile);
                _logger.LogError(ex.Message);

                return new EmailSendResultDto
                {
                    Success = false,
                    Message = "Failed to send email.",
                    ErrorDetails = ex.Message,
                    Timestamp = DateTime.UtcNow
                };
            }
        }
    }
}