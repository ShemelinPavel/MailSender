using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMailSender.lib.Entities.Base;

namespace WpfMailSender.lib.Entities
{
    /// <summary>
    /// почтовое сообщение
    /// </summary>
    public class EmailMessage: BaseEntity
    {
        /// <summary>
        /// тема
        /// </summary>
        string subj;

        /// <summary>
        /// содержание письма
        /// </summary>
        string content;

        /// <summary>
        /// тема
        /// </summary>
        public string Subject
        {
            get
            { return this.subj; }
            set
            { this.subj = value; }
        }

        /// <summary>
        /// содержание письма
        /// </summary>
        public string Body
        {
            get
            { return this.content; }
            set
            { this.content = value; }
        }

        /// <summary>
        /// конструктор почтового сообщения
        /// </summary>
        /// <param name="Subj">тема</param>
        /// <param name="Content">содержание</param>
        public EmailMessage ( string Subj, string Content )
        {
            this.Subject = Subj;
            this.Body = Content;
        }
    }
}
