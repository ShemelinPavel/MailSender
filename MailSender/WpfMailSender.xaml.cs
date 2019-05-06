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
        public MainWindow ()
        {
            InitializeComponent ();
        }

        private void MenuItem_Close_Click ( object sender, RoutedEventArgs e )
        {
            Close ();
        }

        private void Close_Click ( object sender, RoutedEventArgs e )
        {
            Close ();
        }

        private void Send_Click ( object sender, RoutedEventArgs e )
        {
            SendMail ();
        }

        private void Window_Loaded ( object sender, RoutedEventArgs e )
        {
            InitialSettings ();
        }
        private void InitialSettings ()
        {
            Settings sett = EmailSenderSettings.GetDefaultMailSenderSettings ();
            ServerName.Text = sett.ServerName;
            ServerPort.Text = sett.ServerPort.ToString ();
            ServerUser.Text = sett.ServerUser;
            ServerPassword.Password = sett.ServerPassword;
        }
        private void SendMail ()
        {
            try
            {
                Email email = new Email ( EMailTo.Text, EMailSubj.Text, EMailMessage.Text );
                Settings sett = new Settings ( ServerName.Text, Int32.Parse ( ServerPort.Text ), ServerUser.Text, ServerPassword.Password );

                Email[] emails = new Email[] { email };

                if (!(EmailSendServiceClass.SendEmails ( emails, sett, out string errMessage )))
                {
                    MailSenderCommonObjects.InfoMessage ( this, errMessage, InfoType.Error );
                }
                else
                {
                    MailSenderCommonObjects.InfoMessage ( this, "Отправка почты выполнена.", InfoType.Info );
                }
            }
            catch (ArgumentException e)
            {
                MailSenderCommonObjects.InfoMessage ( this, e.Message, InfoType.Error );
            }
        }
    }
}
