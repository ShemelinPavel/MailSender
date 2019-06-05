using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMailSender.lib.Entities;
using WpfMailSender.lib.Services.Interfaces;

namespace WpfMailSender.lib.Services.InMemory
{
    public class MailsListDataInMemory : DataInMemory<MailsList>, IMailsListData
    {
        public override void Edit ( MailsList item )
        {
            MailsList list = GetById ( item.Id );
            if (list is null || ReferenceEquals ( list, item )) return;

            list.Name = item.Name;
            list.Messages = item.Messages;
        }
    }
}