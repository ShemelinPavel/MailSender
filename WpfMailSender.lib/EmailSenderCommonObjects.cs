using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows;

namespace WpfMailSender.lib
{
    /// <summary>
    /// перечисление - определяет вид информации отображаемой окном сообщений
    /// </summary>
    public enum InfoType { Info, Error };

    /// <summary>
    /// общие/служебные объекты
    /// </summary>
    public static class EmailSenderCommonObjects
    {
        ///// <summary>
        ///// открыть окно сообщений
        ///// </summary>
        ///// <param name="ownWindow">окно-владелец</param>
        ///// <param name="infoMessage">сообщение</param>
        ///// <param name="infoType">тип окна информация/ошибка</param>
        //public static void InfoMessage ( Window ownWindow, string infoMessage , InfoType infoType )
        //{
        //    Window infoWin = new InfoWindow ( infoType );
        //    infoWin.DataContext = infoMessage;
        //    infoWin.Owner = ownWindow;
        //    infoWin.Show ();
        //}

        ///// <summary>
        ///// проверка адресов эл. почты на валидность через рег. выражения
        ///// </summary>
        ///// <param name="emailAddress">проверяемый адрес</param>
        ///// <returns>адрес верен/не верен</returns>
        public static bool ValidEmail ( string emailAddress )
        {
            return Regex.IsMatch
                ( emailAddress, @"\b[A-Z0-9._%+-]+" +
                               @"@[A-Z0-9.-]+\.[A-Z]{2,4}\b",
                               RegexOptions.IgnoreCase );
        }
    }

   
}