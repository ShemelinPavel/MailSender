using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMailSender.lib.Entities.Base
{
    public abstract class Human : NamedEntity
    {
        [Required]
        public string Email { get; set; }
    }
}
