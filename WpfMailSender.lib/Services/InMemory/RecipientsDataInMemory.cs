using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMailSender.lib.Data.LinqToSQL;
using WpfMailSender.lib.Services.Interfaces;

namespace WpfMailSender.lib.Services.InMemory
{
    public class RecipientsDataInMemory : DataInMemory<Recipient>, IRecipientsData
    {
        public override void Edit ( Recipient item )
        {
            Recipient recipient = GetById ( item.Id );
            if (recipient is null || ReferenceEquals ( recipient, item )) return;

            recipient.Description = item.Description;
            recipient.Email = item.Email;
        }
    }
}
