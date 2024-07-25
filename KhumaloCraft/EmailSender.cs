using System.Net.Mail;
using System.Net;

namespace KhumaloCraft
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var mail = "maxvanderwalt3@gmail.com";
            var pw = "zygp igvp zhcc fjbc";

            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(mail, pw)
            };

            var mailMessage = new MailMessage(from: mail, to: email,
                subject, htmlMessage)
            {
                IsBodyHtml = true
            };
            return client.SendMailAsync(mailMessage);
        }
    }
}
