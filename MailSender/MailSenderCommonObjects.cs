using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfMailSender
{
    public enum InfoType { Info, Error };

    public static class MailSenderCommonObjects
    {
        public static void InfoMessage ( Window ownWindow, string infoMessage , InfoType infoType )
        {
            Window errWin = new InfoWindow ( infoType );
            errWin.DataContext = infoMessage;
            errWin.Owner = ownWindow;
            errWin.Show ();
        }
    }
}
