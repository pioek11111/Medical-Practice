using System.Net;
using System.Net.Mail;
using System.Text;
using SportsStore.Domain.Abstract;
using MedicalPractice.Domain.Entities;

namespace SportsStore.Domain.Concrete
{
    public class EmailSettings
    {
        public string MailToAddress = "zamowienia@przyklad.pl";
        public string MailFromAddress = "sklepsportowy@przyklad.pl";
        public bool UseSsl = true;
        public string Username = "UżytkownikSmtp";
        public string Password = "HasłoSmtp";
        public string ServerName = "smtp.przyklad.pl";
        public int ServerPort = 587;
        public bool WriteAsFile = true;
        public string FileLocation = @"c:\sports_store_emails";
    }

    public class EmailOrderProcessor : IOrderProcessor
    {
        private EmailSettings emailSettings;
        public EmailOrderProcessor(EmailSettings settings)
        {
            emailSettings = settings;
        }
        public void ProcessOrder(Cart cart, VisitDetails visitInfo)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = emailSettings.UseSsl;
                smtpClient.Host = emailSettings.ServerName;
                smtpClient.Port = emailSettings.ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials
                = new NetworkCredential(emailSettings.Username, emailSettings.Password);
                if (emailSettings.WriteAsFile)
                {
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = emailSettings.FileLocation;
                    smtpClient.EnableSsl = false;
                }
                StringBuilder body = new StringBuilder()
                .AppendLine("Nowe zamówienie")
                .AppendLine("---")
                .AppendLine("Produkty:");
                foreach (var line in cart.List)
                {
                    
                    var subtotal = line.Price;
                    body.AppendFormat("{0} (wartość: {1:c}", line.Name, subtotal);
                }
                body.AppendFormat("Wartość całkowita: {0:c}", cart.ComputeTotalValue())
                .AppendLine("---")
                .AppendLine("Wysyłka dla:")
                .AppendLine(visitInfo.Name)
                .AppendLine(visitInfo.Surname)
                .AppendLine(visitInfo.Pesel)
                .AppendLine(visitInfo.BirthdayDate)
                .AppendLine("---");
                MailMessage mailMessage = new MailMessage(
                emailSettings.MailFromAddress, // od
                emailSettings.MailToAddress, // do
                "Otrzymano nowe zamówienie!", // temat
                body.ToString()); // treść
                if (emailSettings.WriteAsFile)
                {
                    mailMessage.BodyEncoding = Encoding.ASCII;
                }
                smtpClient.Send(mailMessage);
            }
        }
    }
}