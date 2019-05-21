using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMailSender.lib.Entities.Base;
using WpfMailSender.lib.Data.LinqToSQL;

namespace WpfMailSender.lib.Entities
{
    public class RecipientsList: BaseEntity
    {
        public string Description { get; set; }

        public IEnumerable<Recipient> Recipients { get; set; }
    }
}
