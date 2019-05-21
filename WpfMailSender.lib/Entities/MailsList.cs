using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMailSender.lib.Entities.Base;

namespace WpfMailSender.lib.Entities
{
    class MailsList: BaseEntity
    {
        public string Description { get; set; }

        public IEnumerable<EmailMessage> Messages { get; set; }
    }
}