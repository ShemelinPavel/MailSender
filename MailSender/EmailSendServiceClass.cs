using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace WpfMailSender
{
    /// <summary>
    /// стат. служебный класс службы рассылки
    /// </summary>
    static class EmailSendServiceClass
    {
        /// <summary>
        /// выполенние рассылки почтовых сообщений
        /// </summary>
        /// <param name="mails">массив почтовых сообщений</param>
        /// <param name="sett">текущие настройки</param>
        /// <param name="errMessage">сообщение об ошибке</param>
        /// <returns>задача выполнена да/нет</returns>
        static public bool SendEmails(Email[] mails, MailServer mailServ, out string errMessage)
        {

            foreach (Email email in mails)
            {
                if (!(SendEmail ( email, mailServ, out string errMes )))
                {
                    errMessage = errMes;
                    return false;
                }
            }

            errMessage = "";

            return true;
        }

        /// <summary>
        /// посылка почтового сообщения
        /// </summary>
        /// <param name="email">почтовое сообщение</param>
        /// <param name="sett">настройки</param>
        /// <param name="errorMessage">сообщение об ошибке</param>
        /// <returns>задача выполнена да/нет</returns>
        static bool SendEmail(Email email, MailServer mailServ, out string errorMessage)
        {
            errorMessage = "";

            using (MailMessage mMes = new MailMessage ( mailServ.User, email.To ))
            {

                mMes.Subject = email.Subject;
                mMes.Body = email.Content;
                mMes.IsBodyHtml = false;

                using (SmtpClient sCl = new SmtpClient ( mailServ.Host, mailServ.Port ))
                {
                    sCl.EnableSsl = true;
                    sCl.UseDefaultCredentials = false;
                    sCl.Credentials = new NetworkCredential ( mailServ.User, mailServ.UserPassword );

                    try
                    {
                        sCl.Send ( mMes );
                    }
                    catch(Exception e)
                    {
                        errorMessage = e.Message;
                        return false;
                    }
                }

            }
            return true;
        }
    }
}
