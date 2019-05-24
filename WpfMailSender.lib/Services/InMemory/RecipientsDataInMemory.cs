using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMailSender.lib;
using WpfMailSender.lib.Entities;
using WpfMailSender.lib.Services.Interfaces;

namespace WpfMailSender.lib.Services.InMemory
{
    public class RecipientsDataInMemory : DataInMemory<Recipient>, IRecipientsData
    {
        public RecipientsDataInMemory()
        {
            items.AddRange ( EmailSenderSettings.MailSenders.Select ((s, i) => new Recipient { Id = i + 1, Name = s.Name, Email = s.Email } ) );
        }

        public override void Edit ( Recipient item )
        {
            Recipient recipient = GetById ( item.Id );
            if (recipient is null || ReferenceEquals ( recipient, item )) return;

            recipient.Name = item.Name;
            recipient.Email = item.Email;
        }
    }
}
