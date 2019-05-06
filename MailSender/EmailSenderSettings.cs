using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMailSender
{
    /// <summary>
    /// настройки почтового сервера
    /// </summary>
    public class Settings
    {
        string srvName;
        int srvPort;
        string srvUser;
        string srvPass;

        public string ServerName
        {
            get
            { return this.srvName; }
            set
            {
                if (value.Replace ( " ", "" ) == "")
                {
                    throw new ArgumentException ( "Не указан почтовый сервер" );
                }
                else
                {
                    this.srvName = value;
                }
            }
        }
        public int ServerPort
        {
            get
            { return this.srvPort; }
            set
            {
                if (value == 0)
                {
                    throw new ArgumentException ( "Не указан  порт почтового сервера" );
                }
                else
                {
                    this.srvPort = value;
                }
            }
        }
        public string ServerUser
        {
            get
            { return this.srvUser; }
            set
            {
                if (value.Replace ( " ", "" ) == "")
                {
                    throw new ArgumentException ( "Не указана учетная запись почты" );
                }
                else if(!(EmailSenderMailObjects.ValidEmail ( value )))
                {
                    throw new ArgumentException ( $"Неверный формат почтового адреса {value}" );
                }
                else
                {
                    this.srvName = value;
                }
            }
        }
        public string ServerPassword
        {
            get
            {
                return this.srvPass;
            }
            set
            {
                this.srvName = value;
            }
        }
        public Settings ( string serverName, int serverPort, string serverUser, string serverPassword )
        {
            this.ServerName = serverName;
            this.ServerPort = serverPort;
            this.srvUser = serverUser;
            this.srvPass = serverPassword;
        }
    }
    static class EmailSenderSettings
    {
        /// <summary>
        /// Получить настройки почт. сервера по умолчанию
        /// </summary>
        /// <returns>Настройки</returns>
        static public Settings GetDefaultMailSenderSettings ()
        {
            Settings sett = new Settings ( "smtp.mail.ru", 465, "pauls0@mail.ru", "" );
            return sett;
        }
    }
}
