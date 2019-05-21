using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMailSender.lib.Entities.Base;

namespace WpfMailSender.lib.Entities
{
    class SchedulerTask: BaseEntity
    {
        public DateTime Time { get; set; }

        public Sender Sender { get; set; }

        public Server Server { get; set; }

        public RecipientsList RecipientsList { get; set; }

        public MailsList MailsList { get; set; }
    }
}
