using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMailSender.lib.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace WpfMailSender.lib.Entities
{
    public class SchedulerTask: BaseEntity
    {
        public DateTime Time { get; set; }

        [Required]
        public virtual Sender Sender { get; set; }

        [Required]
        public virtual Server Server { get; set; }

        [Required]
        public virtual RecipientsList RecipientsList { get; set; }

        [Required]
        public virtual MailsList MailsList { get; set; }
    }
}
