using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required, MaxLength(256)]
        public string Subject { get; set; }

        /// <summary>
        /// содержание письма
        /// </summary>
        public string Body { get; set; }

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
