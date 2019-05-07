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
        /// <summary>
        /// почтовый сервер
        /// </summary>
        string srvName;

        /// <summary>
        /// порт почт. сервера
        /// </summary>
        int srvPort;

        /// <summary>
        /// почтовый аккаунт (адрес) с которого идет рассылка
        /// </summary>
        string srvUser;

        /// <summary>
        /// пароль почтового аккаунта с которого идет рассылка
        /// </summary>
        string srvPass;

        /// <summary>
        /// почтовый сервер
        /// </summary>
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

        /// <summary>
        /// порт почт. сервера
        /// </summary>
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
        
        /// <summary>
        /// почтовый аккаунт (адрес) с которого идет рассылка
        /// </summary>
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
                else if(!(EmailSenderCommonObjects.ValidEmail ( value )))
                {
                    throw new ArgumentException ( $"Неверный формат почтового адреса {value}" );
                }
                else
                {
                    this.srvName = value;
                }
            }
        }

        /// <summary>
        /// пароль почтового аккаунта с которого идет рассылка
        /// </summary>
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

        /// <summary>
        /// конструтор настроек почт. сервера
        /// </summary>
        /// <param name="serverName">имя сервера</param>
        /// <param name="serverPort">порт сервера</param>
        /// <param name="serverUser">аккаунт рассылки</param>
        /// <param name="serverPassword">пароль аккаунта рассылки</param>
        public Settings ( string serverName, int serverPort, string serverUser, string serverPassword )
        {
            this.ServerName = serverName;
            this.ServerPort = serverPort;
            this.srvUser = serverUser;
            this.srvPass = serverPassword;
        }
    }
    /// <summary>
    /// стат. класс настроек почт. сервера
    /// </summary>
    static class EmailSenderSettings
    {
        /// <summary>
        /// Получить настройки почт. сервера по умолчанию
        /// </summary>
        /// <returns>Настройки</returns>
        static public Settings GetDefaultMailSenderSettings ()
        {
            Settings sett = new Settings ( "smtp.mail.ru", 25, "", "" );
            return sett;
        }
    }
}
