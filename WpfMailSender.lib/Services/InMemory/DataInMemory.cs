using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMailSender.lib.Entities.Base;
using WpfMailSender.lib.Services.Interfaces;


namespace WpfMailSender.lib.Services.InMemory
{
    public abstract class DataInMemory<T> : IDataService<T> where T : BaseEntity
    {
        protected readonly List<T> items = new List<T> ();

        public int Add ( T item )
        {
            if (items.Contains ( item )) return 0;
            item.Id = items.Count == 0 ? 1 : items.Max ( i => i.Id ) + 1;
            items.Add ( item );
            return item.Id;
        }

        public abstract void Edit ( T item );
        

        public IEnumerable<T> GetAll () => items;

        public T GetById ( int id )
        {
            if (id < 0) throw new ArgumentOutOfRangeException ( nameof ( id ), id, "Значение id должно быть больше 0" );
            return items.FirstOrDefault ( i => i.Id == id );
        }

        public void Remove ( int id )
        {
            T removeitem = GetById ( id );
            if(!(removeitem is null)) items.Remove ( removeitem );
        }

        public void Save ()
        {
        }
    }
}
