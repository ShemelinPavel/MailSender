using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace MailSender.ConsoleTest
{
    class Program
    {
        static void Main ( string[] args )
        {

            try
            {
                using (MailMessage mMes = new MailMessage ( "", "" ))
                {

                    mMes.Subject = "Test";
                    mMes.Body = "test mail";
                    mMes.IsBodyHtml = false;

                    using (SmtpClient sCl = new SmtpClient ( "smtp.mail.ru", 25 ))
                    {
                        sCl.EnableSsl = true;
                        sCl.UseDefaultCredentials = false;
                        sCl.Credentials = new NetworkCredential ( "", "" );

                        sCl.Send ( mMes );
                        Console.WriteLine ( "Письмо отправлено." );
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine ( $"Ошибка выполнения: {e.Message}" );
            }
            Console.ReadKey ();
        }
    }
}
