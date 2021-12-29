using MailKit.Net.Smtp;
using MimeKit;
using NLog;
using ServerOPC.Security;
using System;

namespace ServerOPC.Classes
{
    public class Notification
    {      
        private readonly string From = LogManager.Configuration.Variables["from"].OriginalText;
        private static readonly string Email = LogManager.Configuration.Variables["Email"].OriginalText;
        private static readonly string password = LogManager.Configuration.Variables["pwd"].OriginalText;
        private readonly string encryptedPwd = Password.DecryptString(password);
        public void SendMsg(string To,string Subject, string Body)
        {            
            MimeMessage msg = new MimeMessage();
            msg.From.Add(new MailboxAddress(Email, From));
            msg.To.Add(MailboxAddress.Parse(To));
            msg.Subject = Subject;
            msg.Body = new TextPart("plain")
            {
                Text = Body
            };
            
            SmtpClient client = new SmtpClient();                     
            try
            {
                client.Connect("smtp.gmail.com", 465, true);
                client.Authenticate(From, encryptedPwd);
                
                client.Send(msg);
                Console.WriteLine("Email sent!");
                client.Disconnect(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }          

          
        }

        public void SendMsgNOKWithPingNOK(string To,string Subject, string Body)
        {
            MimeMessage msg = new MimeMessage();
            msg.From.Add(new MailboxAddress(Email, From));
            msg.To.Add(MailboxAddress.Parse(To));
            msg.Subject = Subject;
            msg.Body = new TextPart("plain")
            {
                Text = Body
            };

            SmtpClient client = new SmtpClient();
            try
            {
                client.Connect("smtp.gmail.com", 465, true);
                client.Authenticate(From, encryptedPwd);

                client.Send(msg);
                Console.WriteLine("Email sent!");
                client.Disconnect(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
