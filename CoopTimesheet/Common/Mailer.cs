/***************************************************************************************************
 *                                                                                                 *
 * SMTP Email Wrapper Class                                                                        *
 *                                                                                                 *
 * Author: John Priestley                                                                          *
 *         Group Software Development Team                                                         *
 *                                                                                                 *
 * History                                                                                         *
 *                                                                                                 *
 * 11 Nov 2010   1.02  JP  Implemented IDisposable interface                                       *
 * 11 Nov 2010   1.01  JP  Added checks for blank email addresses being added to the email lists   *
 * 10 Nov 2010   1.00  JP  First Release                                                           *
 *                                                                                                 *
 ***************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MailerTest
{
    public class Mailer : IDisposable
    {
        #region [  Classes  ]
        /// <summary>
        /// Host Details
        /// </summary>
        private class MailerHost
        {
            public string Host { get; set; }
            public int Port { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
        }

        private class MailerRecipient
        {
            public string Email { get; set; }
            public string DisplayName { get; set; }
        }
       #endregion

        #region [  Variables  ]
        private List<MailerHost> _host = new List<MailerHost>();
        private List<MailerRecipient> _to = new List<MailerRecipient>();
        private List<MailerRecipient> _cc = new List<MailerRecipient>();
        private List<MailerRecipient> _bcc = new List<MailerRecipient>();
        private List<string> _attachment = new List<string>();
        private MailerRecipient _from = new MailerRecipient();
        #endregion

        #region [  SMTP Host  ]
        /// <summary>
        /// Clear SMTP Host list
        /// </summary>
        public void ClearSMTPHostList()
        {
            _host.Clear();
        }

        /// <summary>
        /// Add SMTP Host to the host list
        /// </summary>
        /// <param name="host">SMTP server address</param>
        public void AddSMTPHost(string host)
        {
            this.AddSMTPHost(host, 0, "", "");
        }

        /// <summary>
        /// Add SMTP Host to the host list
        /// </summary>
        /// <param name="host">SMTP server address</param>
        /// <param name="port">SMTP port number</param>
        public void AddSMTPHost(string host, int port)
        {
            this.AddSMTPHost(host, port, "", "");
        }

        /// <summary>
        /// Add SMTP Host to the host list
        /// </summary>
        /// <param name="host">SMTP server address</param>
        /// <param name="username">Username for SMTP</param>
        /// <param name="password">Password for SMTP</param>
        public void AddSMTPHost(string host, string username, string password)
        {
            this.AddSMTPHost(host, 0, username, password);
        }

        /// <summary>
        /// Add SMTP Host to the host list
        /// </summary>
        /// <param name="host">SMTP server address</param>
        /// <param name="port">SMTP port number</param>
        /// <param name="username">Username for SMTP</param>
        /// <param name="password">Password for SMTP</param>
        public void AddSMTPHost(string host, int port, string username, string password)
        {
            MailerHost mailerHost = new MailerHost();
            mailerHost.Host = host;
            mailerHost.Port = port;
            mailerHost.Username = username;
            mailerHost.Password = password;

            _host.Add(mailerHost);
        }
        #endregion

        #region [  To List  ]
        /// <summary>
        /// Clear To List
        /// </summary>
        public void ClearToList()
        {
            _to.Clear();
        }

        /// <summary>
        /// Add email address to the To list
        /// </summary>
        /// <param name="email">Email address</param>
        public void AddTo(string email)
        {
            if (email.Trim().Length == 0) { return; }
            this.AddTo(email, "");
        }

        /// <summary>
        /// Add email address to the To List
        /// </summary>
        /// <param name="email">Email address</param>
        /// <param name="displayName">Display name</param>
        public void AddTo(string email, string displayName)
        {
            if (email.Trim().Length == 0) { return; }
            MailerRecipient mr = new MailerRecipient();
            mr.Email = email;
            mr.DisplayName = displayName;
            _to.Add(mr);
        }

        /// <summary>
        /// Add a list of email addresses separated by a semi-colon to the To list
        /// fred.bloggs@email.com;john.smith@email.com
        /// </summary>
        /// <param name="emails">Email addresses</param>
        public void ToList(string emails)
        {
            if (emails.Trim().Length == 0) { return; }
            this.ToList(emails, ";");
        }

        /// <summary>
        /// Add a list of email addresses to the To list
        /// fred.bloggs@email.com;john.smith@email.com
        /// </summary>
        /// <param name="emails">Email addresses</param>
        /// <param name="separator">Separator</param>
        public void ToList(string emails, string separator)
        {
            if (emails.Trim().Length == 0) { return; }

            char[] separators = separator.ToCharArray();
            string[] emailList = emails.Split(separators);

            foreach (string email in emailList)
            {
                this.AddTo(email.Trim());
            }
        }
        #endregion

        #region [  CC List  ]
        /// <summary>
        /// Clear CC List
        /// </summary>
        public void ClearCcList()
        {
            _cc.Clear();
        }

        /// <summary>
        /// Add email address to the CC list
        /// </summary>
        /// <param name="email">Email address</param>
        public void AddCc(string email)
        {
            if (email.Trim().Length == 0) { return; }
            this.AddCc(email, "");
        }

        /// <summary>
        /// Add email address to the CC List
        /// </summary>
        /// <param name="email">Email address</param>
        /// <param name="displayName">Display name</param>
        public void AddCc(string email, string displayName)
        {
            if (email.Trim().Length == 0) { return; }

            MailerRecipient mr = new MailerRecipient();
            mr.Email = email;
            mr.DisplayName = displayName;
            _cc.Add(mr);
        }

        /// <summary>
        /// Add a list of email addresses separated by a semi-colon to the CC list
        /// fred.bloggs@email.com;john.smith@email.com
        /// </summary>
        /// <param name="emails">Email addresses</param>
        public void CcList(string emails)
        {
            if (emails.Trim().Length == 0) { return; }
            this.CcList(emails, ";");
        }

        /// <summary>
        /// Add a list of email addresses to the CC list
        /// fred.bloggs@email.com;john.smith@email.com
        /// </summary>
        /// <param name="emails">Email addresses</param>
        /// <param name="separator">Separator</param>
        public void CcList(string emails, string separator)
        {
            if (emails.Trim().Length == 0) { return; }

            char[] separators = separator.ToCharArray();
            string[] emailList = emails.Split(separators);

            foreach (string email in emailList)
            {
                this.AddCc(email.Trim());
            }
        }
        #endregion

        #region [  BCC List  ]
        /// <summary>
        /// Clear CC List
        /// </summary>
        public void ClearBccList()
        {
            _bcc.Clear();
        }

        /// <summary>
        /// Add email address to the BCC list
        /// </summary>
        /// <param name="email">Email address</param>
        public void AddBcc(string email)
        {
            if (email.Trim().Length == 0) { return; }
            this.AddBcc(email, "");
        }

        /// <summary>
        /// Add email address to the BCC List
        /// </summary>
        /// <param name="email">Email address</param>
        /// <param name="displayName">Display name</param>
        public void AddBcc(string email, string displayName)
        {
            if (email.Trim().Length == 0) { return; }

            MailerRecipient mr = new MailerRecipient();
            mr.Email = email;
            mr.DisplayName = displayName;
            _bcc.Add(mr);
        }

        /// <summary>
        /// Add a list of email addresses separated by a semi-colon to the BCC list
        /// fred.bloggs@email.com;john.smith@email.com
        /// </summary>
        /// <param name="emails">Email addresses</param>
        public void BccList(string emails)
        {
            if (emails.Trim().Length == 0) { return; }
            this.BccList(emails, ";");
        }

        /// <summary>
        /// Add a list of email addresses to the BCC list
        /// fred.bloggs@email.com;john.smith@email.com
        /// </summary>
        /// <param name="emails">Email addresses</param>
        /// <param name="separator">Separator</param>
        public void BccList(string emails, string separator)
        {
            if (emails.Trim().Length == 0) { return; }

            char[] separators = separator.ToCharArray();
            string[] emailList = emails.Split(separators);

            foreach (string email in emailList)
            {
                this.AddBcc(email.Trim());
            }
        }
        #endregion

        #region [  From List  ]
        /// <summary>
        /// From settings
        /// </summary>
        /// <param name="email">From email address</param>
        public void From(string email)
        {
            this.From(email, "");
        }

        /// <summary>
        /// From settings
        /// </summary>
        /// <param name="email">From email address</param>
        /// <param name="displayName">Display name</param>
        public void From(string email, string displayName)
        {
            _from.Email = email;
            _from.DisplayName = displayName;
        }
        #endregion

        #region [  Attachment List  ]
        /// <summary>
        /// Clear attachment list
        /// </summary>
        public void ClearAttachments()
        {
            _attachment.Clear();
        }

        /// <summary>
        /// Add a file to the attachment list
        /// </summary>
        /// <param name="filename">Filename</param>
        public void AddAttachment(string filename)
        {
            _attachment.Add(filename);
        }
        #endregion

        #region [  Send Email  ]
        public bool SendEmail(string subject, string message, bool isMessageHTML)
        {
            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
            System.Net.Mail.MailAddress addr;

            // To List
            foreach (MailerRecipient mr in _to)
            {
                if (mr.Email.Length > 0)
                {
                    if (mr.DisplayName.Length == 0)
                    {
                        addr = new System.Net.Mail.MailAddress(mr.Email);
                    }
                    else
                    {
                        addr = new System.Net.Mail.MailAddress(mr.Email, mr.DisplayName);
                    }
                    mailMessage.To.Add(addr);
                }
            }

            // From
            if (_from.DisplayName.Length == 0)
            {
                addr = new System.Net.Mail.MailAddress(_from.Email);
            }
            else
            {
                addr = new System.Net.Mail.MailAddress(_from.Email, _from.DisplayName);
            }
            mailMessage.From = addr;

            // CC List
            foreach (MailerRecipient mr in _cc)
            {
                if (mr.Email.Length > 0)
                {
                    if (mr.DisplayName.Length == 0)
                    {
                        addr = new System.Net.Mail.MailAddress(mr.Email);
                    }
                    else
                    {
                        addr = new System.Net.Mail.MailAddress(mr.Email, mr.DisplayName);
                    }
                    mailMessage.CC.Add(addr);
                }
            }

            // BCC List
            foreach (MailerRecipient mr in _bcc)
            {
                if (mr.Email.Length > 0)
                {
                    if (mr.DisplayName.Length == 0)
                    {
                        addr = new System.Net.Mail.MailAddress(mr.Email);
                    }
                    else
                    {
                        addr = new System.Net.Mail.MailAddress(mr.Email, mr.DisplayName);
                    }
                    mailMessage.Bcc.Add(addr);
                }
            }

            // Subject
            mailMessage.Subject = subject;

            // Body
            mailMessage.IsBodyHtml = isMessageHTML;
            mailMessage.Body = message;

            // File Attachments
            foreach (string filename in _attachment)
            {
                if (filename.Length > 0) { mailMessage.Attachments.Add(new System.Net.Mail.Attachment(filename)); }
            }

            // Send Email
            System.Net.Mail.SmtpClient smtp;

            bool emailSent = false;

            foreach (MailerHost host in _host )
            {
                if (host.Host.Length > 0)
                {
                    smtp = new System.Net.Mail.SmtpClient(host.Host);
                    if (host.Port != 0) { smtp.Port = host.Port; }

                    // Set credentials if there is a username assigned to the smtp host
                    if (host.Username.Length != 0)
                    {
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new System.Net.NetworkCredential(host.Username, host.Password);
                    }

                    try
                    {
                        smtp.Send(mailMessage);

                        //smtp.Dispose();
                        smtp = null;
                        emailSent = true;
                        break;  // Break out of the loop if sending the email was successful
                    }
                    catch { }
                }
            }

            // Clean Up - Attachements
            foreach (System.Net.Mail.Attachment att in mailMessage.Attachments)
            {
                att.Dispose();
            }

            // Clean Up - BCC
            mailMessage.Bcc.Clear();

            // Clean Up - CC
            mailMessage.CC.Clear();

            // Clean Up - To
            mailMessage.To.Clear();

            // Clean Up - Mail Message
            mailMessage.Dispose();
            mailMessage = null;

            // Finished
            return emailSent;
        }
        #endregion

        #region [  IDisposable  ]
        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            if (_host != null)
            {
                _host.Clear();
                _host = null;
            }

            if (_to != null)
            {
                _to.Clear();
                _to = null;
            }

            if (_cc != null)
            {
                _cc.Clear();
                _cc = null;
            }

            if (_bcc != null)
            {
                _bcc.Clear();
                _bcc = null;
            }

            if (_attachment != null)
            {
                _attachment.Clear();
                _attachment = null;
            }

            _from = null;
        }
        #endregion
    }
}
