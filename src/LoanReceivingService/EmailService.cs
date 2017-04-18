using System;
using MailKit;
using MailKit.Net.Smtp;
using MimeKit;
using MailKit.Security;

namespace LoanReceivingService
{
    public class EmailService
    {
        public static void SendEmail(string message)
        {

            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("sarvesh", "sarvesh189@gmail.com"));
            emailMessage.To.Add(new MailboxAddress("sarveshT", "sarvesh189@gmail.com"));
            emailMessage.Subject = "Amazon SES test (SMTP interface accessed using C#)";
            emailMessage.Body = new TextPart("plain") { Text = message};

            using (var client = new SmtpClient())
            {
                //  

                // client.LocalDomain = "ses-smtp-user.20170406-173508";

                client.Connect("email-smtp.us-west-2.amazonaws.com", 587, SecureSocketOptions.StartTls);

                //  client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate("accesskey", "security");
                client.Send(emailMessage);

                client.Disconnect(true);
            }





            //       Console.Write("Press any key to continue...");
            //     Console.ReadKey();
        }
    }
}

