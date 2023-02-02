using System.Net.Mail;
using TuraIntranet.Data.Backoffice.Koss;

namespace TuraIntranet.Services
{
    public class EmailService
    {
        private Dictionary<string, string> _emails;
        private string _smtp;

        public EmailService()
        {
            this._emails = new()
            {
                {"noReplyMail_sv", "noreply@turascandinavia.com" },
                {"replyMail_sv", "noreply@turascandinavia.com" }
            };

            IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();

            //this._smtp = "192.168.1.26";
            this._smtp = configuration.GetValue<string>("smtp-server");
        }

        public bool SendEmail(KossRma rma, string text, bool replyable)
        {
            string MailKey = replyable ? "replyMail_" : "noReplyMail_";
            MailKey += rma.Country;

            string MailFrom = string.Empty;
            if (this._emails.TryGetValue(MailKey, out string from))
            {
                MailFrom = from;
            }
            else
            {
                MailFrom = "noreply@turascandinavia.com";
            }
            //string MailTo = rma.Email;
            string MailTo = rma.Email;
            string smtp = this._smtp ?? "192.168.1.26";

            try
            {
                var msg = new MailMessage();
                msg.From = new MailAddress(MailFrom);
                msg.To.Add(new MailAddress(MailTo));
                msg.Subject = "My Porta Pro";
                msg.Body = text;
                msg.IsBodyHtml = false;
                var client = new SmtpClient(smtp, 25);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;

                client.Send(msg);

                msg.Dispose();
                client.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }

            rma.ReplyDate = DateTime.Now;
            rma.CustomReply = text;

            //Update rma

            return true;
        }
    }
}
