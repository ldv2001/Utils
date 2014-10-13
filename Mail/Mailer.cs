using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Utils.Mail
{
    public class Mailer
    {
        private MailMessage _email;
        private static SmtpClient _smtp;

        /// <summary>
        /// Initialise l'e-mail
        /// </summary>
        /// <param name="title">Nom de l'expediteur</param>
        public Mailer(string title)
        {
            _email = new MailMessage
            {
                IsBodyHtml = true,
                BodyEncoding = Encoding.UTF8,
                SubjectEncoding = Encoding.UTF8,
                Subject = title
            };
        }


        /// <summary>
        /// Définit le serveur SMTP par lequel sera envoyé le mail
        /// </summary>
        /// <param name="host">The host.</param>
        /// <param name="port">The port.</param>
        /// <param name="enableSSL">if set to <c>true</c> [enable SSL].</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        public static void SetSMTP(string host,
            int port = 25,
            bool enableSSL = false,
            String userName = "",
            String password = "")
        {
            _smtp = new SmtpClient(host, port)
            {
                EnableSsl = enableSSL,
                Credentials = new NetworkCredential(userName, password)
            };
        }

        public static void SetSMTP(String host,
           String port = "25",
           String enableSSL = "False",
           String userName = "",
           String password = "")
        {
            int _port;
            bool _ssl;

            if (!int.TryParse(port, out _port))
            {
                _port = 25;
            }

            if (!bool.TryParse(enableSSL, out _ssl))
            {
                _ssl = false;
            }

            _smtp = new SmtpClient(host, _port)
            {
                EnableSsl = _ssl,
                Credentials = new NetworkCredential(userName, password)
            };
        }

        /// <summary>
        /// Définit l'adresse d'expéditeur du mail.
        /// </summary>
        /// <param name="email">The email.</param>
        public void SetFrom(string email)
        {
            _email.From = new MailAddress(email);
        }

        /// <summary>
        /// Ajoute une message à l'e-mail
        /// </summary>
        /// <param name="html">Code HTML</param>
        public void SetMessage(string html)
        {
            _email.Body = html;
        }

        /// <summary>
        /// Ajoute un sujet à l'e-mail
        /// </summary>
        /// <param name="subject">Sujet</param>
        public void SetSubject(string subject)
        {
            _email.Subject = subject;
        }

        /// <summary>
        /// Ajoute un destinataire à l'e-mail
        /// </summary>
        /// <param name="email">Adresse e-mail</param>
        public void SetTo(string email)
        {
            _email.To.Add(new MailAddress(email));
        }

        /// <summary>
        /// Ajoute un destinataire à l'e-mail avec son nom
        /// </summary>
        /// <param name="email">Adresse e-mail</param>
        /// <param name="contact">Nom du contact</param>
        public void SetTo(string email, string contact = "")
        {
            _email.To.Add(string.IsNullOrEmpty(contact) ? new MailAddress(email) : new MailAddress(email, contact));
        }

        /// <summary>
        /// Ajoute un destinataire complementaire caché
        /// </summary>
        /// <param name="email"></param>
        public void SetBcc(string email)
        {
            _email.Bcc.Add(new MailAddress(email));
        }

        /// <summary>
        /// Ajoute un destinataire complementaire caché avec son nom
        /// </summary>
        /// <param name="email"></param>
        /// <param name="contact"></param>
        public void SetBcc(string email, string contact)
        {
            _email.Bcc.Add(new MailAddress(email, contact));
        }

        /// <summary>
        /// Ajoute un destinataire caché
        /// </summary>
        /// <param name="email"></param>
        public void SetCc(string email)
        {
            _email.CC.Add(new MailAddress(email));
        }

        /// <summary>
        /// Ajoute un destinataire caché avec son nom
        /// </summary>
        /// <param name="email"></param>
        /// <param name="contact"></param>
        public void SetCc(string email, string contact)
        {
            _email.CC.Add(new MailAddress(email, contact));
        }

        /// <summary>
        /// Ajoute une liste de destinataires
        /// </summary>
        /// <param name="to"></param>
        public void SetTo(List<string> to)
        {
            foreach (var item in to)
            {
                _email.To.Add(new MailAddress(item));
            }
        }

        /// <summary>
        /// Ajoute une liste de destinataires avec leurs nom
        /// </summary>
        /// <param name="to"></param>
        public void SetTo(List<List<string>> to)
        {
            foreach (var item in to)
            {
                _email.To.Add(new MailAddress(item[0], item[1]));
            }
        }

        /// <summary>
        /// Ajoute une liste de destinataires complémentaires
        /// </summary>
        /// <param name="bcc"></param>
        public void SetBcc(List<string> bcc)
        {
            foreach (var item in bcc)
            {
                _email.Bcc.Add(new MailAddress(item));
            }
        }

        /// <summary>
        /// Ajoute une liste de destinataires complémentaires avec leurs nom
        /// </summary>
        /// <param name="bcc"></param>
        public void SetBcc(List<List<string>> bcc)
        {
            foreach (var item in bcc)
            {
                _email.Bcc.Add(new MailAddress(item[0], item[1]));
            }
        }

        /// <summary>
        /// Ajoute une liste de destinataires caché
        /// </summary>
        /// <param name="cc"></param>
        public void SetCc(List<string> cc)
        {
            foreach (var item in cc)
            {
                _email.CC.Add(new MailAddress(item));
            }
        }

        /// <summary>
        /// Ajoute une liste de destinataires caché avec leurs nom
        /// </summary>
        /// <param name="cc"></param>
        public void SetCc(List<List<string>> cc)
        {
            foreach (var item in cc)
            {
                _email.CC.Add(new MailAddress(item[0], item[1]));
            }
        }

        /// <summary>
        /// Ajoute un fichier joint
        /// </summary>
        /// <param name="ms">Fichier</param>
        /// <param name="fileName">Nom</param>
        public long SetAttachement(Stream ms, string fileName)
        {
            var attachement = new Attachment(ms, fileName);
            _email.Attachments.Add(attachement);
            return ms.Length;
        }

        /// <summary>
        /// Envoi de l'e-mail
        /// </summary>
        /// <returns></returns>
        public bool Send()
        {
            try
            {
                _smtp.Send(_email);
                return true;
            }
            catch (Exception ex)
            {
                var _str = ex.Message;
                return false;
            }
        }
    }
}
