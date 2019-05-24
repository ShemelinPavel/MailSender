using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMailSender.lib.Entities;
using WpfMailSender.lib.Services.Interfaces;

namespace WpfMailSender.lib.Services.LinqToSQL
{
    public class RecipientsDataLinqToSQL : IRecipientsData
    {
        private readonly Data.LinqToSQL.MailSenderDB dbcontext;

        public RecipientsDataLinqToSQL ( Data.LinqToSQL.MailSenderDB databaseContext )
        {
            dbcontext = databaseContext;
        }

        public IEnumerable<Recipient> GetAll ()
        {
            return dbcontext.Recipient.Select ( r => new Recipient { Id = r.Id, Name = r.Description, Email = r.Email } );
        }

        public int Add ( Recipient recipient )
        {
            if (dbcontext.Recipient.Any ( r => r.Id == recipient.Id )) return recipient.Id;
            dbcontext.Recipient.InsertOnSubmit ( new Data.LinqToSQL.Recipient
            {
                Id = recipient.Id,
                Description = recipient.Name,
                Email = recipient.Email
            }
            );

            Save ();
            return recipient.Id;
        }

        public void Edit ( Recipient recipient )
        {
            Data.LinqToSQL.Recipient db_recip = dbcontext.Recipient.FirstOrDefault ( r => r.Id == recipient.Id );
            if(db_recip is null)
            {
                Add ( recipient );
                return;
            }

            db_recip.Id = recipient.Id;
            db_recip.Description = recipient.Name;
            db_recip.Email = recipient.Email;

            Save ();
        }

        public void Save () => dbcontext.SubmitChanges ();

        public Recipient GetById ( int id )
        {
            Data.LinqToSQL.Recipient db_recip = dbcontext.Recipient.FirstOrDefault ( i => i.Id == id );

            return new Recipient
            {
                Id = db_recip.Id,
                Name = db_recip.Description,
                Email = db_recip.Email
            };
        }

        public void Remove ( int id )
        {
            Data.LinqToSQL.Recipient db_recip = dbcontext.Recipient.FirstOrDefault ( r => r.Id == id );
            if (db_recip is null) return;

            dbcontext.Recipient.DeleteOnSubmit ( db_recip );
            Save ();
        }
    }
}
