using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FIT5032_Assignment_30533651.Utils
{
    public class EmailSender
    {
        private const String API_KEY = "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";

        public void Send(String toEmail, String subject, String contents)
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("971823352@qq.com", "Go Volleyball!");
            var to = new EmailAddress(toEmail, "");
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = client.SendEmailAsync(msg);
        }
    }
}