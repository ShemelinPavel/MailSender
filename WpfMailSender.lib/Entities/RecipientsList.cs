using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMailSender.lib.Entities.Base;
using WpfMailSender.lib.Entities;

namespace WpfMailSender.lib.Entities
{
    public class RecipientsList: NamedEntity
    {
        public virtual IEnumerable<Recipient> Recipients { get; set; }
    }
}
