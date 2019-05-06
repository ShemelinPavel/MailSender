using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WpfMailSender
{

    static public class EmailSenderMailObjects
    {
        public static bool ValidEmail ( string emailAddress )
        {
            return Regex.IsMatch
                ( emailAddress, @"\b[A-Z0-9._%+-]+" +
                               @"@[A-Z0-9.-]+\.[A-Z]{2,4}\b",
                               RegexOptions.IgnoreCase );
        }
    }

    public class Email
    {
        string to;
        string subj;
        string content;

        public string To
        {
            get
            { return this.to; }
            set
            {
                if (value.Replace ( " ", "" ) == "")
                {
                    throw new ArgumentException ( "Поле письма <Кому> не заполнено" );
                }
                else if (!(EmailSenderMailObjects.ValidEmail ( value )))
                {
                    throw new ArgumentException ( $"Неверный формат почтового адреса {value}" );
                }
                else
                {
                    this.to = value;
                }
            }
        }
        public string Subject
        {
            get
            { return this.subj; }
            set
            { this.subj = value; }
        }
        public string Content
        {
            get
            { return this.content; }
            set
            { this.content = value; }
        }

        public Email ( string To, string Subj, string Content )
        {
            this.To = To;
            this.Subject = Subj;
            this.Content = Content;
        }
    }
}
