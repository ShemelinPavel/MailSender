using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMailSender.lib.Entities;
using WpfMailSender.lib.Services.Interfaces;

namespace WpfMailSender.lib.Services.InMemory
{
    public class RecipientsListDataInMemory : DataInMemory<RecipientsList>, IRecipientsListData
    {
        public override void Edit ( RecipientsList item )
        {
            RecipientsList list = GetById ( item.Id );
            if (list is null || ReferenceEquals ( list, item )) return;

            list.Name = item.Name;
            list.Recipients = item.Recipients;
        }
    }
}