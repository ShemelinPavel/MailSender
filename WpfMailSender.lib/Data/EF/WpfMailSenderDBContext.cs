using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMailSender.lib.Entities;

namespace WpfMailSender.lib.Data.EF
{
    public class WpfMailSenderDBContext: DbContext
    {

        public DbSet<Sender> Senders { get; set; }
        public DbSet<Recipient> Recipients { get; set; }
        public DbSet<RecipientsList> RecipientsLists { get; set; }
        public DbSet<Server> Servers { get; set; }
        public DbSet<SchedulerTask> SchedulerTasks { get; set; }
        public DbSet<EmailMessage> EmailMessages { get; set; }
        public DbSet<MailsList> MailsLists { get; set; }

        public WpfMailSenderDBContext(): this("name=WpfMailSenderDBContext")
        {

        }

        public WpfMailSenderDBContext(string ConnectionString): base(ConnectionString)
        {

        }

    }
}
