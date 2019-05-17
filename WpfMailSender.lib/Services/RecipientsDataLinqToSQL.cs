using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMailSender.lib.Data.LinqToSQL;
using WpfMailSender.lib.Services.Interfaces;

namespace WpfMailSender.lib.Services
{
    public class RecipientsDataLinqToSQL : IRecipientsData
    {
        private readonly MailSenderDB dbcontext;

        public RecipientsDataLinqToSQL (MailSenderDB databaseContext)
        {
            dbcontext = databaseContext;
        }

        public IEnumerable<Recipient> GetAll ()
        {
            return dbcontext.Recipient.ToArray ();
        }
    }
}
