using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMailSender.lib.Data.LinqToSQL
{
    partial class Recipient : IDataErrorInfo
    {
        string IDataErrorInfo.this[string PropertyName]
        {
            get
            {
                switch (PropertyName)
                {

                    case nameof ( this.Id ): return "";
                    case nameof ( this.Description ):
                        if (this.Description is null) return "Наименование не определено";
                        if (this.Description.Length < 3) return "Длина наименования не может быть меньше 3-х символов";
                        if (this.Description.Length > 35) return "Длина наименования не может быть больше 35-ти символов";
                        return "";
                    case nameof ( this.Email ): return "";
                    default: return "";

                }
            }
        }

        string IDataErrorInfo.Error => "";

        partial void OnDescriptionChanging ( string value )
        {
            if (value is null) throw new ArgumentNullException ( nameof ( value ) );
            if(value == string.Empty) throw new InvalidOperationException ( "Наименование не может быть пустым" );
        }
    }


}
