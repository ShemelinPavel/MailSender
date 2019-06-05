using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMailSender.lib.Entities;

namespace WpfMailSender.lib.Services.Interfaces
{
    public interface IEmailSender
    {
        void Send(EmailMessage message, Sender from,  Recipient to);
        void Send(EmailMessage message, Sender from, IEnumerable<Recipient> to);
        void SendParallel(EmailMessage message, Sender from, IEnumerable<Recipient> to);
        Task SendAsync(EmailMessage message, Sender from, Recipient to);
        Task SendAsync(EmailMessage message, Sender from, IEnumerable<Recipient> to);
    }
}
