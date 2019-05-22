using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMailSender.lib.Entities.Base
{
    public abstract class Human : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
