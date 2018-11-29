using System.IO;
using System.Net.Mail;

namespace Server.Services
{ 
    public class EmailService : IEmailService
    {
        private SmtpClient client;

        public EmailService()
        {
            client = new SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
            string pickupDirectory = "C:\\Temp";
            client.PickupDirectoryLocation = pickupDirectory;
            bool exists = System.IO.Directory.Exists(pickupDirectory);
            if (!exists)
            {
                System.IO.Directory.CreateDirectory(pickupDirectory);
            }
            
        }

        public void SendEmail(string address, string subject, string body)
        {
            MailMessage registrationConfirmationMessage = new MailMessage();
            MailAddress fromAddress = new MailAddress("admin@kingukongu.com");
            registrationConfirmationMessage.From = fromAddress;
            registrationConfirmationMessage.To.Add(address);
            registrationConfirmationMessage.Body = body;
            registrationConfirmationMessage.IsBodyHtml = true;
            registrationConfirmationMessage.Subject = subject;
            client.Send(registrationConfirmationMessage);
        }
    }
}