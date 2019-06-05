using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMailSender.lib.Data.LinqToSQL
{
    public partial class Recipient
    {
        partial void OnDescriptionChanging ( string value )
        {
            if (value is null) throw new ArgumentNullException ( nameof ( value ) );
            if (value == string.Empty) throw new InvalidOperationException ( "Наименование не может быть пустым" );
        }
    }
}
