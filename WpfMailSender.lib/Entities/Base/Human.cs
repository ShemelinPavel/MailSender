﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMailSender.lib.Entities.Base
{
    public abstract class Human : NamedEntity
    {
        public string Email { get; set; }
    }
}
