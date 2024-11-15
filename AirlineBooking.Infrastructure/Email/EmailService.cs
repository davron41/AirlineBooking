using AirlineBooking.Application.Models;
using AirlineBooking.Application.Services.Interfaces;
using AirlineBooking.Infrastructure.Configurations;
using Microsoft.Extensions.Options;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
namespace AirlineBooking.Infrastructure.Email
{
    public class EmailService : IEmailService
    {

        private readonly EmailOptions _options;

        public EmailService(IOptionsMonitor<EmailOptions> options)
        {
            _options = options.CurrentValue;
        }

        public void SendEmailConfirmation(EmailMessage message, UserInfo info)
        {
            var emailMessage = CreateEmailMessage(message, "EmailConfirmation", info);

            Send(emailMessage);
        }

        public void SendResetPassword(EmailMessage message, UserInfo info)
        {
            throw new NotImplementedException();
        }

        public void SendWelcome(EmailMessage message)
        {
            throw new NotImplementedException();
        }

        private void Send(MimeMessage mailMessage)
        {
            using var client = new SmtpClient();

            try
            {
                client.Connect(_options.SmtpServer, _options.Port, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(_options.Username, _options.Password);
                client.Send(mailMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                client.Disconnect(true);
            }
        }
        private MimeMessage CreateEmailMessage(EmailMessage emailMessage, string templateName, UserInfo? userInfo = null, string? inviteSenderName = null)
        {

            var templatePath = Path.Combine(AppContext.BaseDirectory, "Email\\Templates", templateName + ".html");
            var body = File.ReadAllText(templatePath)
                           .Replace("{{invite_sender_name}}", inviteSenderName)
                           .Replace("{{user_name}}", emailMessage.Username)
                           .Replace("{{user_email}}", emailMessage.To)
                           .Replace("{{action_url}}", emailMessage.FallbackUrl)
                           .Replace("{{trial_start_date}}", DateTime.Now.ToString("dd MMMM, yyyy"))
                           .Replace("{{trial_end_date}}", DateTime.Now.AddMonths(1).ToString("dd MMMM, yyyy"))
                           .Replace("{{trial_length}}", "30");

            if (userInfo is not null)
            {
                body = body.Replace("{{operating_system}}", userInfo.OS)
                           .Replace("{{browser_name}}", userInfo.Browser);

            }

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Expense Tracker Manager", "noreply@expense-manager.uz"));
            message.To.Add(new MailboxAddress(emailMessage.Username, emailMessage.To));
            message.Subject = emailMessage.Subject;
            message.Body = new TextPart(TextFormat.Html) { Text = body };

            return message;
        }
    }
}
