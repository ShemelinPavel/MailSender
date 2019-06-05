using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMailSender.lib.Entities;
using WpfMailSender.lib.Services.Interfaces;


namespace WpfMailSender.lib.Services.InMemory
{
    public class SendersDataInMemory : DataInMemory<Sender>, ISendersData
    {
        public SendersDataInMemory ()
        {
            items.AddRange ( EmailSenderSettings.MailSenders );
        }

        public override void Edit ( Sender item )
        {
            Sender sender = GetById ( item.Id );
            if (sender is null || ReferenceEquals ( sender, item )) return;

            sender.Name = item.Name;
            sender.Email = item.Email;
        }
    }
}