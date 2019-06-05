using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMailSender.lib.Entities.Base;

namespace WpfMailSender.lib.Entities
{
    public class MailsList : NamedEntity
    {
        public virtual IEnumerable<EmailMessage> Messages { get; set; }
    }
}