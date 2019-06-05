using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WpfMailSender.lib.Entities;
using WpfMailSender.lib.Services.Interfaces;
using System.Net;
using System.Net.Mail;

namespace WpfMailSender.lib.Services
{
    public class SmtpEmailSenderService : IEmailSenderService
    {
        public IEmailSender CreateSender(Server server)
        {
            return new SmtpEmailSender(server.Host, server.Port, server.UseSSL, server.User, server.UserPassword);
        }
    }

    public class SmtpEmailSender : IEmailSender
    {
        private readonly string adress;
        private readonly int port;
        private readonly bool useSSL;
        private readonly string login;
        private readonly string password;

        public SmtpEmailSender(string Adress, int Port, bool UseSSL, string Login, string Password)
        {
            this.adress = Adress;
            this.port = Port;
            this.useSSL = UseSSL;
            this.login = Login;
            this.password = Password;
        }

        public void Send(EmailMessage message, Sender from, Recipient to)
        {
            using (var client = new SmtpClient(adress, port) { Credentials = new NetworkCredential(login, password) })
            {
                using (var mes = new MailMessage())
                {
                    mes.From = new MailAddress(from.Email, from.Name);
                    mes.To.Add(new MailAddress(to.Email, to.Name));
                    mes.Subject = message.Subject;
                    mes.Body = message.Body;

                    client.Send(mes);
                }
            }
        }

        public void Send(EmailMessage message, Sender from, IEnumerable<Recipient> to)
        {
            foreach (var item in to)
            {
                Send(message, from, item);
            }
        }

        public async Task SendAsync(EmailMessage message, Sender from, Recipient to)
        {
            using (var client = new SmtpClient(adress, port) { Credentials = new NetworkCredential(login, password) })
            {
                using (var mes = new MailMessage())
                {
                    mes.From = new MailAddress(from.Email, from.Name);
                    mes.To.Add(new MailAddress(to.Email, to.Name));
                    mes.Subject = message.Subject;
                    mes.Body = message.Body;

                    await client.SendMailAsync(mes).ConfigureAwait(false);
                }
            }
        }

        public async Task SendAsync(EmailMessage message, Sender from, IEnumerable<Recipient> to)
        {
            await Task.WhenAll(to.Select(o => SendAsync(message, from, o)));

        }

        public void SendParallel(EmailMessage message, Sender from, IEnumerable<Recipient> to)
        {
            foreach (var item in to)
            {
                ThreadPool.QueueUserWorkItem(_ => Send(message, from, item));
            }
        }
    }
}
