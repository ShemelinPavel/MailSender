using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMailSender.lib.Entities;
using WpfMailSender.lib.Services.Interfaces;

namespace WpfMailSender.lib.Services.InMemory
{
    public class EmailMessagesDataInMemory : DataInMemory<EmailMessage>, IEmailMessageData
    {
        public override void Edit ( EmailMessage item )
        {
            EmailMessage message = GetById ( item.Id );
            if (message is null || ReferenceEquals ( message, item )) return;

            message.Subject = item.Subject;
            message.Body = item.Body;
        }
    }
}