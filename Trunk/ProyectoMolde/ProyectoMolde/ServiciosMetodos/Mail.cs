using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;

namespace ServiciosMetodos
{

    public class Mail
    {
        private static bool ValidateEmail(string email)
        {
            try
            {
                MailAddress address = new MailAddress(email);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EnviarEmail(string to, string subject, string body, string From = "")
        {
            bool rep = true;

            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();

            string[] correos = to.Split(';');

            foreach (string email in correos)
            {
                if (email != "" && ValidateEmail(email))
                {
                    msg.To.Add(email);
                }
            }

            if (From == "")
            {
                msg.From = new MailAddress("anibalmartinez87@hotmail.com", "Molde", System.Text.Encoding.UTF8);
            }
            else
            {
                msg.From = new MailAddress(From + "@coosalud.com", From.ToUpper(), System.Text.Encoding.UTF8);
            }

            msg.Subject = subject;
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = body;
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();

            try
            {
                client.Send(msg);
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                LogController lc = new LogController();
                lc.guardarLog("Modle", "Mail", "Send", (msg.To + "  " + ex.Message));
            }
            catch (Exception ex)
            {
                LogController lc = new LogController();
                lc.guardarLog("Molde", "Mail", "Send", (msg.To + "  " + ex.Message));
            }
            return rep;
        }


        public bool EnviarEmailConAdjunto(string to, string subject, string body, System.IO.MemoryStream stream, string From = "", string nombreAd = "")
        {
            bool rep = true;

            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            stream.Seek(0, System.IO.SeekOrigin.Begin);

            string nombreAdjunto = nombreAd == "" ? "Respuesta Portabilidad.pdf" : nombreAd + ".pdf";
            Attachment item = new Attachment(stream, nombreAdjunto);

            string[] correos = to.Split(';');

            foreach (string email in correos)
            {
                if (email != "" && ValidateEmail(email))
                {
                    msg.To.Add(email);
                }
            }

            if (From == "")
            {
                msg.From = new MailAddress("sipra@coosalud.com", "SIPRA", System.Text.Encoding.UTF8);
            }
            else
            {
                msg.From = new MailAddress(From + "@coosalud.com", From.ToUpper(), System.Text.Encoding.UTF8);
            }

            msg.Subject = subject;
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = body;
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = true;
            msg.Attachments.Add(item);

            SmtpClient client = new SmtpClient();

            try
            {
                client.Send(msg);
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }

            return rep;
        }

        bool invalid = false;

        public bool IsValidEmail(string strIn)
        {
            invalid = false;
            if (String.IsNullOrEmpty(strIn))
                return false;

            // Use IdnMapping class to convert Unicode domain names.
            try
            {
                strIn = Regex.Replace(strIn, @"(@)(.+)$", this.DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

            if (invalid)
                return false;

            // Return true if strIn is in valid e-mail format.
            try
            {
                return Regex.IsMatch(strIn,
                      @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                      RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        private string DomainMapper(Match match)
        {
            // IdnMapping class with default property values.
            IdnMapping idn = new IdnMapping();

            string domainName = match.Groups[2].Value;
            try
            {
                domainName = idn.GetAscii(domainName);
            }
            catch (ArgumentException)
            {
                invalid = true;
            }
            return match.Groups[1].Value + domainName;
        }

    }


}