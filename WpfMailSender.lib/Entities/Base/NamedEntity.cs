using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WpfMailSender.lib.Entities.Base
{
    public class NamedEntity : BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
