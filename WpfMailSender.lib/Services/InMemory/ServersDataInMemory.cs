using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMailSender.lib.Entities;
using WpfMailSender.lib.Services.Interfaces;

namespace WpfMailSender.lib.Services.InMemory
{
    public class ServersDataInMemory : DataInMemory<Server>, IServersData
    {
        public ServersDataInMemory ()
        {
            items.AddRange ( EmailSenderSettings.MailServers );
        }
        public override void Edit ( Server item )
        {
            Server server = GetById ( item.Id );
            if (server is null || ReferenceEquals ( server, item )) return;

            server.Name = item.Name;
            server.Host = item.Host;
            server.Port = item.Port;
            server.User = item.User;
            server.UserPassword = item.UserPassword;
            server.UseSSL = item.UseSSL;
        }
    }
}