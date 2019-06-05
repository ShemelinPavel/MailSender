using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMailSender.lib.Entities.Base;

namespace WpfMailSender.lib.Entities
{
    public class Recipient : NamedEntity, IDataErrorInfo
    {
        public string Email { get; set; }

        string IDataErrorInfo.this[string PropertyName]
        {
            get
            {
                switch (PropertyName)
                {

                    case nameof ( this.Id ): return "";
                    case nameof ( this.Name ):
                        if (this.Name is null) return "Наименование не определено";
                        if (this.Name.Length < 3) return "Длина наименования не может быть меньше 3-х символов";
                        if (this.Name.Length > 35) return "Длина наименования не может быть больше 35-ти символов";
                        return "";
                    case nameof ( this.Email ): return "";
                    default: return "";

                }
            }
        }

        string IDataErrorInfo.Error => "";
    }
}