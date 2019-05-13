using System;
using System.IO;
using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
//
namespace MimeKit
{
    public static class Extensions
    {
        //
        //  static MimeMessage  From(mimeMessage, fromAddress)
        //  static MimeMessage  From(mimeMessage, fromAddress, name)
        //  static MimeMessage  From(mimeMessage, MailboxAddress)
        //
        #region "From"
        //
        /// <summary>
        /// Set the single from address
        /// </summary>
        /// <param name="mimeMessage">This MimeMessage.</param>
        /// <param name="fromAddress">string of an email address</param>
        /// <returns>this, MimeMessage to allow fluent design.</returns>
        public static MimeMessage From(this MimeMessage mimeMessage, string fromAddress)
        {
            mimeMessage.From.Add(new MailboxAddress(fromAddress));
            return mimeMessage;
        }
        /// <summary>
        /// Set the single from email address
        /// </summary>
        /// <param name="mimeMessage">This MimeMessage.</param>
        /// <param name="fromAddress">string of an email address</param>
        /// <param name="name">display name of the email address</param>
        /// <returns>this, MimeMessage to allow fluent design.</returns>
        public static MimeMessage From(this MimeMessage mimeMessage, string fromAddress, string name)
        {
            mimeMessage.From.Add(new MailboxAddress(fromAddress, name));
            return mimeMessage;
        }
        //
        /// <summary>
        /// Set the single from email address
        /// </summary>
        /// <param name="mimeMessage">This MimeMessage.</param>
        /// <param name="fromAddress">A MailboxAddress, including an email address and the name</param>
        /// <returns>this, MimeMessage to allow fluent design.</returns>
        public static MimeMessage From(this MimeMessage mimeMessage, MailboxAddress fromAddress)
        {
            mimeMessage.From.Add(fromAddress);
            return mimeMessage;
        }
        // 
        #endregion // From
        // 
        //  MimeMessage To(mimeMessage, fromAddress)
        //  MimeMessage To(mimeMessage, fromAddress, name)
        //  MimeMessage To(mimeMessage, MailboxAddress)
        //
        #region "To"
        // 
        /// <summary>
        /// Add a To email address.
        /// </summary>
        /// <param name="mimeMessage">This MimeMessage.</param>
        /// <param name="toAddress">an email address</param>
        /// <returns>this, MimeMessage to allow fluent design.</returns>
        public static MimeMessage To(this MimeMessage mimeMessage, string toAddress)
        {
            mimeMessage.To.Add(new MailboxAddress(toAddress));
            return mimeMessage;
        }
        /// <summary>
        /// Add a to email address.
        /// </summary>
        /// <param name="mimeMessage">This MimeMessage.</param>
        /// <param name="toAddress">an email address</param>
        /// <param name="name">display name of the email address</param>
        /// <returns>this, MimeMessage to allow fluent design.</returns>
        public static MimeMessage To(this MimeMessage mimeMessage, string toAddress, string name)
        {
            mimeMessage.To.Add(new MailboxAddress(toAddress, name));
            return mimeMessage;
        }
        /// <summary>
        /// Add a to email address.
        /// </summary>
        /// <param name="mimeMessage">This MimeMessage.</param>
        /// <param name="toAddress">A MailboxAddress, including an email address and the name</param>
        /// <returns>this, MimeMessage to allow fluent design.</returns>
        public static MimeMessage To(this MimeMessage mimeMessage, MailboxAddress toAddress)
        {
            mimeMessage.To.Add(toAddress);
            return mimeMessage;
        }
        // 
        #endregion // To
        //
        //  MimeMessage CC(mimeMessage, fromAddress)
        //  MimeMessage CC(mimeMessage, fromAddress, name)
        //  MimeMessage CC(mimeMessage, MailboxAddress)
        //
        #region "CC"
        //
        /// <summary>
        /// Add a carbon copy (cc) email address.
        /// </summary>
        /// <param name="mimeMessage">This MimeMessage.</param>
        /// <param name="ccAddress">an email address</param>
        /// <returns>this, MimeMessage to allow fluent design.</returns>
        public static MimeMessage CC(this MimeMessage mimeMessage, string ccAddress)
        {
            mimeMessage.Cc.Add(new MailboxAddress(ccAddress));
            return mimeMessage;
        }
        /// <summary>
        /// Add a carbon copy (cc) email address.
        /// </summary>
        /// <param name="mimeMessage">This MimeMessage.</param>
        /// <param name="ccAddress">an email address</param>
        /// <param name="name">display name of the email address</param>
        /// <returns>this, MimeMessage to allow fluent design.</returns>
        public static MimeMessage CC(this MimeMessage mimeMessage, string ccAddress, string name)
        {
            mimeMessage.Cc.Add(new MailboxAddress(ccAddress, name));
            return mimeMessage;
        }
        /// <summary>
        /// Add a carbon copy (cc) email address.
        /// </summary>
        /// <param name="mimeMessage">This MimeMessage.</param>
        /// <param name="ccAddress">A MailboxAddress, including an email address and the name</param>
        /// <returns>this, MimeMessage to allow fluent design.</returns>
        public static MimeMessage CC(this MimeMessage mimeMessage, MailboxAddress ccAddress)
        {
            mimeMessage.Cc.Add(ccAddress);
            return mimeMessage;
        }
        //
        #endregion // CC
        // 
        //  MimeMessage BCC(mimeMessage, fromAddress)
        //  MimeMessage BCC(mimeMessage, fromAddress, name)
        //  MimeMessage BCC(mimeMessage, MailboxAddress)
        //
        #region "BCC"
        //
        /// <summary>
        /// Add a blind carbon copy (bcc) email address.
        /// </summary>
        /// <param name="mimeMessage">This MimeMessage.</param>
        /// <param name="bccAddress">an email address</param>
        /// <returns>this, MimeMessage to allow fluent design.</returns>
        public static MimeMessage BCC(this MimeMessage mimeMessage, string bccAddress)
        {
            mimeMessage.Bcc.Add(new MailboxAddress(bccAddress));
            return mimeMessage;
        }
        /// <summary>
        /// Add a blind carbon copy (bcc) email address.
        /// </summary>
        /// <param name="mimeMessage">This MimeMessage.</param>
        /// <param name="bccAddress">an email address</param>
        /// <param name="name">display name of the email address</param>
        /// <returns>this, MimeMessage to allow fluent design.</returns>
        public static MimeMessage BCC(this MimeMessage mimeMessage, string bccAddress, string name)
        {
            mimeMessage.Bcc.Add(new MailboxAddress(bccAddress, name));
            return mimeMessage;
        }
        /// <summary>
        /// Add a blind carbon copy (bcc) email address.
        /// </summary>
        /// <param name="mimeMessage">This MimeMessage.</param>
        /// <param name="bccAddress">A MailboxAddress, including an email address and the name</param>
        /// <returns>this, MimeMessage to allow fluent design.</returns>
        public static MimeMessage BCC(this MimeMessage mimeMessage, MailboxAddress bccAddress)
        {
            mimeMessage.Bcc.Add(bccAddress);
            return mimeMessage;
        }
        //
        #endregion // BCC
        //
        //  MimeMessage Subject(mimeMessage, subject)
        //  MimeMessage Body(mimeMessage, bodyBuilder)
        //  BodyBuilder HtmlBody(message)
        //  BodyBuilder TextBody(message)
        //
        #region "Subject and Body"
        //
        /// <summary>
        /// Set the title of email message.
        /// </summary>
        /// <param name="mimeMessage">This MimeMessage.</param>
        /// <param name="subject">the subject line</param>
        /// <returns>this, MimeMessage to allow fluent design.</returns>
        public static MimeMessage Subject(this MimeMessage mimeMessage, string subject)
        {
            mimeMessage.Subject = subject;
            return mimeMessage;
        }
        //
        /// <summary>
        /// Set the body of the email message.
        /// </summary>
        /// <param name="mimeMessage">This MimeMessage.</param>
        /// <param name="bodyBuilder">Email body and any attachments.</param>
        /// <returns>this, MimeMessage to allow fluent design.</returns>
        public static MimeMessage Body(this MimeMessage mimeMessage, BodyBuilder bodyBuilder)
        {
            mimeMessage.Body = bodyBuilder.ToMessageBody();
            return mimeMessage;
        }
        //
        /// <summary>
        /// Set the body of the email message.
        /// </summary>
        /// <param name="message">HTML Email message body.</param>
        /// <returns>A new BodyBuilder to allow fluent design.</returns>
        public static BodyBuilder HtmlBody(string message)
        {
            BodyBuilder body = new BodyBuilder
            {
                HtmlBody = message
            };
            return body;
        }
        //
        /// <summary>
        /// Set the body of the email message with Html content.
        /// </summary>
        /// <param name="message">Text e-mail body</param>
        /// <returns>A new BodyBuilder to allow fluent design.</returns>
        public static BodyBuilder TextBody(string message)
        {
            BodyBuilder body = new BodyBuilder
            {
                TextBody = message
            };
            return body;
        }
        //
        #endregion // Subject and Body
        //
        /// <summary>
        /// Add an attachment to the mail message.
        /// <example> 
        /// This sample shows how to call this constructor.
        /// <code>
        ///  using MimeKit;
        ///  using MailKit.Net.Smtp;
        ///  ...
        ///  MimeMessage _email = (new MimeMessage())
        ///      .From(_fromAddress).To(_toAddress)
        ///      .Subject(_subject).Body(
        ///          Extensions.TextBody(_message)
        ///              .Attachment(_buffer, "Text.txt", "text/plain;charset=utf-8")
        ///      );
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="buffer">byte buffer containing the attachment</param>
        /// <param name="displayName">name placed on the attachment</param>
        /// <param name="mimeType">mime type
        /// <example>mime type examples:
        /// <list type="bullet">
        /// <item><description>application/pdf</description></item>
        /// <item><description>application/ms-excel</description></item>
        /// <item><description>multipart/form-data</description></item>
        /// <item><description>text/html</description></item>
        /// <item><description>text/xml</description></item>
        /// <item><description>text/plain</description></item>
        /// <item><description>image/png</description></item>
        /// <item><description>image/jpeg</description></item>
        /// <item><description>image/gif</description></item>
        /// </list>
        /// </example>
        /// </param>
        /// <returns>return its self</returns>
        public static BodyBuilder Attachment(this BodyBuilder bodyBuilder, byte[] buffer, string displayName, string mimeType)
        {
            //
            string[] _medias = mimeType.Split('/');
            if (_medias.Length != 2)
                throw new ApplicationException("Bad mime type: " + mimeType);
            ContentType _contentType = new ContentType(_medias[0], _medias[1]);
            string[] _parts = _medias[1].Split(';');
            if (_parts.Length == 2)
            {
                _contentType.MediaSubtype = _parts[0];
                if (_parts[1].ToLower().Substring(0, 8) == "charset=")
                {
                    _contentType.Charset = _parts[1].Substring(8);
                }
            }
            //
            try
            {
                bodyBuilder.Attachments.Add(displayName, buffer, _contentType);
            }
            catch (Exception _ex)
            {
                System.Diagnostics.Debug.WriteLine(_ex.Message);
            }
            //
            return bodyBuilder;
        }
        //
        #region "Send"
        //
        public static MimeMessage Send(this MimeMessage mimeMessage, string smtpHost, int port, bool ssl, string userName, string passWord)
        {
            using (SmtpClient _client = new SmtpClient())
            {
                _client.ServerCertificateValidationCallback =
                    (sender, certificate, certChainType, errors) => true;
                _client.AuthenticationMechanisms.Remove("XOAUTH2");
                //
                _client.Connect(smtpHost, port, ssl);
                if (userName != "" && passWord != "")
                    _client.Authenticate(userName, passWord);
                //
                _client.Send(mimeMessage);
                _client.Disconnect(true);
            }
            return mimeMessage;
        }
        public static MimeMessage Send(this MimeMessage mimeMessage, string smtpHost, int port, bool ssl)
        {
            return mimeMessage.Send(smtpHost, port, ssl, "", "");
        }
        public static MimeMessage Send(this MimeMessage mimeMessage)
        {
            return mimeMessage.Send("localhost", 25, false, "", "");
        }
        //
        public async static Task<MimeMessage> SendAsync(this MimeMessage mimeMessage, string smtpHost, int port, bool ssl, string userName, string passWord)
        {
            using (SmtpClient _client = new SmtpClient())
            {
                _client.ServerCertificateValidationCallback =
                    (sender, certificate, certChainType, errors) => true;
                _client.AuthenticationMechanisms.Remove("XOAUTH2");
                //
                await _client.ConnectAsync(smtpHost, port, ssl).ConfigureAwait(false);
                if(userName != "" && passWord != "")
                    await _client.AuthenticateAsync(userName, passWord).ConfigureAwait(false);
                //
                await _client.SendAsync(mimeMessage).ConfigureAwait(false);
                await _client.DisconnectAsync(true).ConfigureAwait(false);
            }
            return mimeMessage;
        }
        public async static Task<MimeMessage> SendAsync(this MimeMessage mimeMessage, string smtpHost, int port, bool ssl)
        {
            return await mimeMessage.SendAsync(smtpHost, port, ssl, "", "");
        }
        public async static Task<MimeMessage> SendAsync(this MimeMessage mimeMessage)
        {
            return await mimeMessage.SendAsync("localhost", 25, false, "", "");
        }
        //
        #endregion // Send
        //
    }
}
