﻿namespace Library.Services.Implementations
{
    using Microsoft.Extensions.Options;
    using Models.EmailSender;
    using System;
    using System.Net;
    using System.Net.Mail;
    using System.Threading.Tasks;

    using static ServicesConstants;

    public class EmailSender : IEmailSender
    {
        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public AuthMessageSenderOptions Options { get; }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            this.Execute(email, subject, message).Wait();

            return Task.FromResult(0);

        }

        public async Task Execute(string email, string message, string subject)
        {
            try
            {
                string toEmail = string.IsNullOrEmpty(email)
                    ? Options.ToEmail
                    : email;

                MailMessage mail = new MailMessage()
                {
                    From = new MailAddress(Options.UsernameEmail, SenderInformation)
                };

                mail.To.Add(new MailAddress(toEmail));
                mail.Subject = message;
                mail.Body = subject;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                using (SmtpClient smtp = new SmtpClient(Options.PrimaryDomain, Options.PrimaryPort))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(Options.UsernameEmail, Options.UsernamePassword);
                    smtp.EnableSsl = true;
                    
                    await smtp.SendMailAsync(mail);
                }
            }
            catch (Exception)
            {               
            }
        }
    }
}