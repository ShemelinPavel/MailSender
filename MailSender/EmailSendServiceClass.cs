using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace WpfMailSender
{
    static class EmailSendServiceClass
    {
        static public bool SendEmails(Email[] mails, Settings sett, out string errMessage)
        {

            foreach (Email email in mails)
            {
                if (!(SendEmail ( email, sett, out string errMes )))
                {
                    errMessage = errMes;
                    return false;
                }
            }

            errMessage = "";

            return true;
        }

        static bool SendEmail(Email email, Settings sett, out string errorMessage)
        {
            errorMessage = "";

            using (MailMessage mMes = new MailMessage ( sett.ServerUser, email.To ))
            {

                mMes.Subject = email.Subject;
                mMes.Body = email.Content;
                mMes.IsBodyHtml = false;

                using (SmtpClient sCl = new SmtpClient ( sett.ServerName, sett.ServerPort ))
                {
                    sCl.EnableSsl = true;
                    sCl.UseDefaultCredentials = false;
                    sCl.Credentials = new NetworkCredential ( sett.ServerUser, sett.ServerPassword );

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
