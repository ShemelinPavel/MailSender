using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfMailSender
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// конструктор окна
        /// </summary>
        public MainWindow ()
        {
            InitializeComponent ();
        }

        /// <summary>
        /// обработчик события нажатия пункта "Close" в меню
        /// </summary>
        /// <param name="sender">объект-инициатор</param>
        /// <param name="e">параметры события</param>
        private void MenuItem_Close_Click ( object sender, RoutedEventArgs e )
        {
            Close ();
        }

        /// <summary>
        /// обработчик события нажатия кнопки "Закрыть"
        /// </summary>
        /// <param name="sender">объект-инициатор</param>
        /// <param name="e">параметры события</param>
        private void Close_Click ( object sender, RoutedEventArgs e )
        {
            Close ();
        }

        /// <summary>
        /// обработчик события нажатия кнопки "Послать"
        /// </summary>
        /// <param name="sender">объект-инициатор</param>
        /// <param name="e">параметры события</param>
        private void Send_Click ( object sender, RoutedEventArgs e )
        {
            SendMail ();
        }

        /// <summary>
        /// обрабочик события загрузка формы
        /// </summary>
        /// <param name="sender">объект-инициатор</param>
        /// <param name="e">параметры события</param>
        private void Window_Loaded ( object sender, RoutedEventArgs e )
        {
            InitialSettings ();
        }

        /// <summary>
        /// заполнить реквизиты формы настройками
        /// </summary>
        private void InitialSettings ()
        {
            Settings sett = EmailSenderSettings.GetDefaultMailSenderSettings ();
            ServerName.Text = sett.ServerName;
            ServerPort.Text = sett.ServerPort.ToString ();
            ServerUser.Text = sett.ServerUser;
            ServerPassword.Password = sett.ServerPassword;
        }

        /// <summary>
        /// послать почтовое сообщение
        /// </summary>
        private void SendMail ()
        {
            try
            {
                Email email = new Email ( EMailTo.Text, EMailSubj.Text, EMailMessage.Text );
                Settings sett = new Settings ( ServerName.Text, Int32.Parse ( ServerPort.Text ), ServerUser.Text, ServerPassword.Password );

                Email[] emails = new Email[] { email };

                if (!(EmailSendServiceClass.SendEmails ( emails, sett, out string errMessage )))
                {
                    EmailSenderCommonObjects.InfoMessage ( this, errMessage, InfoType.Error );
                }
                else
                {
                    EmailSenderCommonObjects.InfoMessage ( this, "Отправка почты выполнена.", InfoType.Info );
                }
            }
            catch (ArgumentException e)
            {
                EmailSenderCommonObjects.InfoMessage ( this, e.Message, InfoType.Error );
            }
        }
    }
}
