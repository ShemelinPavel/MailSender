﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMailSender.lib.Entities.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WpfMailSender.lib.Entities
{
    /// <summary>
    /// настройки почтового сервера
    /// </summary>
    public class Server: NamedEntity
    {

        /// <summary>
        /// хост почтового сервера
        /// </summary>
        string srvHost;

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
        /// использовать SSL
        /// </summary>
        bool srvUseSSL;

        /// <summary>
        /// почтовый сервер
        /// </summary>
        [Required]
        public string Host
        {
            get
            {
                return this.srvHost;
            }
            set
            {
                if (value.Replace ( " ", "" ) == "")
                {
                    throw new ArgumentException ( "Не указан почтовый сервер" );
                }
                else
                {
                    this.srvHost = value;
                }
            }
        }

        /// <summary>
        /// порт почт. сервера
        /// </summary>
        [DefaultValue(25)]
        public int Port
        {
            get
            {
                return this.srvPort;
            }
            set
            {
                if (value == 0)
                {
                    throw new ArgumentException ( "Не указан порт почтового сервера" );
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
        [Required]
        public string User
        {
            get
            {
                return this.srvUser;
            }
            set
            {
                if (value.Replace ( " ", "" ) == "")
                {
                    throw new ArgumentException ( "Не указана учетная запись почты" );
                }
                else if (!(EmailSenderCommonObjects.ValidEmail ( value )))
                {
                    throw new ArgumentException ( $"Неверный формат почтового адреса {value}" );
                }
                else
                {
                    this.srvUser = value;
                }
            }
        }

        /// <summary>
        /// пароль почтового аккаунта с которого идет рассылка
        /// </summary>
        public string UserPassword
        {
            get
            {
                return this.srvPass;
            }
            set
            {
                this.srvPass = value;
            }
        }

        /// <summary>
        /// использовать SSL
        /// </summary>
        [DefaultValue(false)]
        public bool UseSSL
        {
            get
            {
                return this.srvUseSSL;
            }
            set
            {
                this.srvUseSSL = value;
            }
        }

        /// <summary>
        /// конструтор почт. сервера
        /// </summary>
        /// <param name="descr">описание сервера</param>
        /// <param name="host">хост сервера</param>
        /// <param name="port">порт сервера</param>
        /// <param name="user">аккаунт рассылки</param>
        /// <param name="userPass">пароль аккаунта рассылки</param>
        /// <param name="useSSL">использование SSL</param>
        public Server ( string descr, string host, int port, string user, string userPass, bool useSSL = false )
        {
            base.Name = descr;
            this.Host = host;
            this.Port = port;
            this.User = user;
            this.UserPassword = userPass;
            this.UseSSL = useSSL;
        }
    }
}
