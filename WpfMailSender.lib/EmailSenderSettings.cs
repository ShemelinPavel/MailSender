using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMailSender.lib.Entities;

namespace WpfMailSender.lib
{
    /// <summary>
    /// стат. класс настроек почт. сервера
    /// </summary>
    public static class EmailSenderSettings
    {
        /// <summary>
        /// почтовые серверы
        /// </summary>
        public static List<Server> MailServers { get; } = new List<Server>
        {
                new Server("Mail.ru", "smtp.mail.ru", 25, "test@mail.ru", "", true ),
                new Server ( "Gmail.com", "smtp.gmail.com", 25, "test@gmail.com", "", true )
        };

        /// <summary>
        /// отправители почт. сообщений
        /// </summary>
        public static List<Sender> MailSenders { get; } = new List<Sender>
        {
                new Sender{ Name = "Тест 1", Email = "test.mail.ru"},
                new Sender { Name = "Тест 2", Email = "test.gmail.com" }
        };
    }
}
