using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMailSender.lib.Data.LinqToSQL;

namespace WpfMailSender.lib.Services.Interfaces
{
    public interface IRecipientsData
    {
        IEnumerable<Recipient> GetAll ();

        int Create ( Recipient recipient );

        void Write ( Recipient recipient );

        void Save ();
    }
}
