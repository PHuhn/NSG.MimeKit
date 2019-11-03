using System;
using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
using System.Linq;
//
namespace MimeKit
{
    //
    /// <summary>
    /// Namespace of MimeKit. MimeKit is an external namespace from the 
    /// MailKit/MimeKit libraries. This appends to the MimeKit namespace
    /// and extends the MimeMessage and BodyBuilder classes.
    /// </summary>
    [System.Runtime.CompilerServices.CompilerGenerated]
    class NamespaceDoc
    {
    }
    //
    /// <summary>
    /// Fluent extension methods for MimeMessage and BodyBuilder classes
    /// in the MimeKit library.
    /// </summary>
    public static class Extensions
    {
        //
        //  MimeMessage NewMimeMessage()
        //
        #region "NewMimeMessage"
        //
        /// <summary>
        /// Create a new MimeMessage class to hold an email message.
        /// <example>
        /// To invoke NewMimeMessage as follows:
        /// <code>
        ///  ...
        ///  using MimeKit;
        ///  ...
        ///      MimeMessage _email = Extensions.NewMimeMessage();
        /// </code>
        /// </example>
        /// </summary>
        /// <returns>A new MimeMessage to allow fluent design.</returns>
        public static MimeMessage NewMimeMessage()
        {
            return new MimeMessage();
        }
        //
        #endregion // NewMimeMessage
        //
        //  MimeMessage From(this mimeMessage, fromAddress)
        //  MimeMessage From(this mimeMessage, fromAddress, name)
        //  MimeMessage From(this mimeMessage, MailboxAddress)
        //
        #region "From"
        //
        /// <summary>
        /// Set the from address with a string of a single email address.
        /// </summary>
        /// <param name="mimeMessage">This MimeMessage.</param>
        /// <param name="fromAddress">string of an email address</param>
        /// <returns>this, MimeMessage to allow fluent design.</returns>
        public static MimeMessage From(this MimeMessage mimeMessage, string fromAddress)
        {
            mimeMessage.From.Add(new MailboxAddress(fromAddress));
            return mimeMessage;
        }
        //
        /// <summary>
        /// Set the from address with two strings.
        /// </summary>
        /// <param name="mimeMessage">This MimeMessage.</param>
        /// <param name="fromAddress">string of an email address</param>
        /// <param name="name">display name of the email address</param>
        /// <returns>this, MimeMessage to allow fluent design.</returns>
        public static MimeMessage From(this MimeMessage mimeMessage, string fromAddress, string name)
        {
            mimeMessage.From.Add(new MailboxAddress(name, fromAddress));
            return mimeMessage;
        }
        //
        /// <summary>
        /// Set the from address with an email address structure.
        /// </summary>
        /// <param name="mimeMessage">This MimeMessage.</param>
        /// <param name="fromAddress">A MailboxAddress class, including an email address and the name</param>
        /// <returns>this, MimeMessage to allow fluent design.</returns>
        public static MimeMessage From(this MimeMessage mimeMessage, MailboxAddress fromAddress)
        {
            mimeMessage.From.Add(fromAddress);
            return mimeMessage;
        }
        // 
        #endregion // From
        // 
        //  MimeMessage To(this mimeMessage, fromAddress)
        //  MimeMessage To(this mimeMessage, fromAddress, name)
        //  MimeMessage To(this mimeMessage, MailboxAddress)
        //
        #region "To"
        //
        /// <summary>
        /// Set a To address with a string of a single email address.
        /// </summary>
        /// <param name="mimeMessage">This MimeMessage.</param>
        /// <param name="toAddress">an email address</param>
        /// <returns>this, MimeMessage to allow fluent design.</returns>
        public static MimeMessage To(this MimeMessage mimeMessage, string toAddress)
        {
            mimeMessage.To.Add(new MailboxAddress(toAddress));
            return mimeMessage;
        }
        //
        /// <summary>
        /// Set a To address with two strings.
        /// </summary>
        /// <param name="mimeMessage">This MimeMessage.</param>
        /// <param name="toAddress">an email address</param>
        /// <param name="name">display name of the email address</param>
        /// <returns>this, MimeMessage to allow fluent design.</returns>
        public static MimeMessage To(this MimeMessage mimeMessage, string toAddress, string name)
        {
            mimeMessage.To.Add(new MailboxAddress(name, toAddress));
            return mimeMessage;
        }
        //
        /// <summary>
        /// Set a To address with an email address structure.
        /// </summary>
        /// <param name="mimeMessage">This MimeMessage.</param>
        /// <param name="toAddress">A MailboxAddress class, including an email address and the name</param>
        /// <returns>this, MimeMessage to allow fluent design.</returns>
        public static MimeMessage To(this MimeMessage mimeMessage, MailboxAddress toAddress)
        {
            mimeMessage.To.Add(toAddress);
            return mimeMessage;
        }
        // 
        #endregion // To
        //
        //  MimeMessage CC(this mimeMessage, fromAddress)
        //  MimeMessage CC(this mimeMessage, fromAddress, name)
        //  MimeMessage CC(this mimeMessage, MailboxAddress)
        //
        #region "CC"
        //
        /// <summary>
        /// Set a carbon copy (cc) email address with a string of a single email address.
        /// </summary>
        /// <param name="mimeMessage">This MimeMessage.</param>
        /// <param name="ccAddress">an email address</param>
        /// <returns>this, MimeMessage to allow fluent design.</returns>
        public static MimeMessage CC(this MimeMessage mimeMessage, string ccAddress)
        {
            mimeMessage.Cc.Add(new MailboxAddress(ccAddress));
            return mimeMessage;
        }
        //
        /// <summary>
        /// Set a carbon copy (cc) email address with two strings.
        /// </summary>
        /// <param name="mimeMessage">This MimeMessage.</param>
        /// <param name="ccAddress">an email address</param>
        /// <param name="name">display name of the email address</param>
        /// <returns>this, MimeMessage to allow fluent design.</returns>
        public static MimeMessage CC(this MimeMessage mimeMessage, string ccAddress, string name)
        {
            mimeMessage.Cc.Add(new MailboxAddress(name, ccAddress));
            return mimeMessage;
        }
        //
        /// <summary>
        /// Set a carbon copy (cc) email address with an email address structure.
        /// </summary>
        /// <param name="mimeMessage">This MimeMessage.</param>
        /// <param name="ccAddress">A MailboxAddress class, including an email address and the name</param>
        /// <returns>this, MimeMessage to allow fluent design.</returns>
        public static MimeMessage CC(this MimeMessage mimeMessage, MailboxAddress ccAddress)
        {
            mimeMessage.Cc.Add(ccAddress);
            return mimeMessage;
        }
        //
        #endregion // CC
        // 
        //  MimeMessage BCC(this mimeMessage, fromAddress)
        //  MimeMessage BCC(this mimeMessage, fromAddress, name)
        //  MimeMessage BCC(this mimeMessage, MailboxAddress)
        //
        #region "BCC"
        //
        /// <summary>
        /// Set a blind carbon copy (bcc) email address with a string of a single email address.
        /// </summary>
        /// <param name="mimeMessage">This MimeMessage.</param>
        /// <param name="bccAddress">an email address</param>
        /// <returns>this, MimeMessage to allow fluent design.</returns>
        public static MimeMessage BCC(this MimeMessage mimeMessage, string bccAddress)
        {
            mimeMessage.Bcc.Add(new MailboxAddress(bccAddress));
            return mimeMessage;
        }
        //
        /// <summary>
        /// Set a blind carbon copy (bcc) email address with two strings.
        /// </summary>
        /// <param name="mimeMessage">This MimeMessage.</param>
        /// <param name="bccAddress">an email address</param>
        /// <param name="name">display name of the email address</param>
        /// <returns>this, MimeMessage to allow fluent design.</returns>
        public static MimeMessage BCC(this MimeMessage mimeMessage, string bccAddress, string name)
        {
            mimeMessage.Bcc.Add(new MailboxAddress(name, bccAddress));
            return mimeMessage;
        }
        //
        /// <summary>
        /// Set a blind carbon copy (bcc) email address with an email address structure.
        /// </summary>
        /// <param name="mimeMessage">This MimeMessage.</param>
        /// <param name="bccAddress">A MailboxAddress class, including an email address and the name</param>
        /// <returns>this, MimeMessage to allow fluent design.</returns>
        public static MimeMessage BCC(this MimeMessage mimeMessage, MailboxAddress bccAddress)
        {
            mimeMessage.Bcc.Add(bccAddress);
            return mimeMessage;
        }
        //
        #endregion // BCC
        //
        //  MimeMessage Subject(this mimeMessage, subject)
        //  MimeMessage Body(this mimeMessage, bodyBuilder)
        //
        #region "Subject and Body"
        //
        /// <summary>
        /// Set the title of an email message.
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
        #endregion // Subject and Body
        //
        //  BodyBuilder HtmlBody(message)
        //  BodyBuilder TextBody(message)
        //  BodyBuilder Attachment(this bodyBuilder, buffer, displayName, mimeType)
        //
        #region "BodyBuilder class"
        //
        /// <summary>
        /// Set the body of the email message.
        /// <example>
        /// To invoke HtmlBody as follows:
        /// <code>
        ///  ...
        ///  using MimeKit;
        ///  ...
        ///      BodyBuilder _bodyBuilder = Extensions.HtmlBody("html text");
        ///  ...
        /// </code>
        /// Or a more complete example as follows:
        /// <code>
        ///  MimeMessage _email = Extensions.NewMimeMessage()
        ///      .From(_fromAddress).To(_toAddress)
        ///      .Subject(_subject).Body(Extensions.TextBody(_message));
        /// </code>
        /// </example>
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
        /// <example>
        /// To invoke TextBody as follows:
        /// <code>
        ///  ...
        ///  using MimeKit;
        ///  ...
        ///      BodyBuilder _bodyBuilder = Extensions.TextBody("plain text");
        ///  ...
        /// </code>
        /// </example>
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
        /// <summary>
        /// Add an attachment to the mail message.
        /// <example>
        /// This sample shows how to call attachment.
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
        /// <param name="displayName">name placed on the attachment</param>
        /// <param name="buffer">byte buffer containing the attachment</param>
        /// <param name="bodyBuilder">this BodyBuilder</param>
        /// <param name="mimeType">mime type
        /// <example>mime type examples:
        /// <list type="bullet">
        /// <item><description>application/pdf</description></item>
        /// <item><description>application/ms-excel</description></item>
        /// <item><description>multipart/form-data</description></item>
        /// <item><description>text/html</description></item>
        /// <item><description>text/xml</description></item>
        /// <item><description>text/plain;charset=utf-8</description></item>
        /// <item><description>image/png</description></item>
        /// <item><description>image/jpeg</description></item>
        /// <item><description>image/gif</description></item>
        /// </list>
        /// </example>
        /// </param>
        /// <returns>this, BodyBuilder to allow fluent design.</returns>
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
        #endregion // BodyBuilder class
        //
        //  MimeMessage Send(this mimeMessage, smtpHost, port, ssl, userName, passWord)
        //  MimeMessage Send(this mimeMessage, smtpHost, port, ssl)
        //  MimeMessage Send(this mimeMessage)
        //  MimeMessage SendAsync(this mimeMessage, smtpHost, port, ssl, userName, passWord)
        //  MimeMessage SendAsync(this mimeMessage, smtpHost, port, ssl)
        //  MimeMessage SendAsync(this mimeMessage)
        //
        #region "Send"
        //
        /// <summary>
        /// Synchronously send a (this) MimeMessage via the MailKit's SmtpClient.
        /// </summary>
        /// <param name="mimeMessage">This MimeMessage.</param>
        /// <param name="smtpHost">Host name of the SMTP server or relay.</param>
        /// <param name="port">An integer port number.</param>
        /// <param name="ssl">Boolean value for enabling SSL.</param>
        /// <param name="userName">Connect to the SMTP host with this userName.</param>
        /// <param name="passWord">Connect to the SMTP host with this user name's password.</param>
        /// <returns>this, MimeMessage to allow fluent design.</returns>
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
        //
        /// <summary>
        /// Synchronously send a (this) MimeMessage via the MailKit's SmtpClient.
        /// <note type="note">
        /// This will invoke the following method:
        /// Send(this mimeMessage, smtpHost, port, ssl, userName, passWord)
        /// The above invocation assumes the following parameters:
        /// <list type="bullet">
        /// <item><description>A userName of empty string.</description></item>
        /// <item><description>A passWord of empty string.</description></item>
        /// </list>
        /// </note>
        /// </summary>
        /// <param name="mimeMessage">This MimeMessage.</param>
        /// <param name="smtpHost">Host name of the SMTP server or relay.</param>
        /// <param name="port">An integer port number.</param>
        /// <param name="ssl">Boolean value for enabling SSL.</param>
        /// <returns>this, MimeMessage to allow fluent design.</returns>
        public static MimeMessage Send(this MimeMessage mimeMessage, string smtpHost, int port, bool ssl)
        {
            return mimeMessage.Send(smtpHost, port, ssl, "", "");
        }
        //
        /// <summary>
        /// Synchronously send a (this) MimeMessage via the MailKit's SmtpClient.
        /// <note type="note">
        /// This will invoke the following method:
        /// Send(this mimeMessage, smtpHost, port, ssl, userName, passWord)
        /// The above invocation assumes the following parameters:
        /// <list type="bullet">
        /// <item><description>A smtpHost of localhost.</description></item>
        /// <item><description>A SMTP port number of 25.</description></item>
        /// <item><description>An enable SSL of false.</description></item>
        /// <item><description>A userName of empty string.</description></item>
        /// <item><description>A passWord of empty string.</description></item>
        /// </list>
        /// </note>
        /// </summary>
        /// <param name="mimeMessage">This MimeMessage.</param>
        /// <returns>this, MimeMessage to allow fluent design.</returns>
        public static MimeMessage Send(this MimeMessage mimeMessage)
        {
            return mimeMessage.Send("localhost", 25, false, "", "");
        }
        //
        /// <summary>
        /// Asynchronously send a (this) MimeMessage via the MailKit's SmtpClient.
        /// </summary>
        /// <param name="mimeMessage">This MimeMessage.</param>
        /// <param name="smtpHost">Host name of the SMTP server or relay.</param>
        /// <param name="port">An integer port number.</param>
        /// <param name="ssl">Boolean value for enabling SSL.</param>
        /// <param name="userName">Connect to the SMTP host with this userName.</param>
        /// <param name="passWord">Connect to the SMTP host with this user name's password.</param>
        /// <returns>this, MimeMessage to allow fluent design.</returns>
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
        //
        /// <summary>
        /// Asynchronously send a (this) MimeMessage via the MailKit's SmtpClient.
        /// <note type="note">
        /// This will invoke the following method:
        /// SendAsync(this mimeMessage, smtpHost, port, ssl, userName, passWord)
        /// The above invocation assumes the following parameters:
        /// <list type="bullet">
        /// <item><description>A userName of empty string.</description></item>
        /// <item><description>A passWord of empty string.</description></item>
        /// </list>
        /// </note>
        /// </summary>
        /// <param name="mimeMessage">This MimeMessage.</param>
        /// <param name="smtpHost">Host name of the SMTP server or relay.</param>
        /// <param name="port">An integer port number.</param>
        /// <param name="ssl">Boolean value for enabling SSL.</param>
        /// <returns>this, MimeMessage to allow fluent design.</returns>
        public async static Task<MimeMessage> SendAsync(this MimeMessage mimeMessage, string smtpHost, int port, bool ssl)
        {
            return await mimeMessage.SendAsync(smtpHost, port, ssl, "", "");
        }
        //
        /// <summary>
        /// Asynchronously send a (this) MimeMessage via the MailKit's SmtpClient.
        /// <note type="note">
        /// This will invoke the following method:
        /// SendAsync(this mimeMessage, smtpHost, port, ssl, userName, passWord)
        /// The above invocation assumes the following parameters:
        /// <list type="bullet">
        /// <item><description>A smtpHost of localhost.</description></item>
        /// <item><description>A SMTP port number of 25.</description></item>
        /// <item><description>An enable SSL of false.</description></item>
        /// <item><description>A userName of empty string.</description></item>
        /// <item><description>A passWord of empty string.</description></item>
        /// </list>
        /// </note>
        /// </summary>
        /// <param name="mimeMessage">This MimeMessage.</param>
        /// <returns>this, MimeMessage to allow fluent design.</returns>
        public async static Task<MimeMessage> SendAsync(this MimeMessage mimeMessage)
        {
            return await mimeMessage.SendAsync("localhost", 25, false, "", "");
        }
        //
        /// <summary>
        /// Asynchronously send a (this) MimeMessage via the MailKit's SmtpClient.
        /// <note type="note">
        /// This will invoke the following method:
        /// SendAsync(this mimeMessage, smtpHost, port, ssl, userName, passWord)
        /// </note>
        /// </summary>
        /// <param name="mimeMessage">This MimeMessage.</param>
        /// <param name="emailSettings">Email settings configuration class.</param>
        /// <returns>this, MimeMessage to allow fluent design.</returns>
        public async static Task<MimeMessage> SendAsync(this MimeMessage mimeMessage, MimeKit.NSG.EmailSettings emailSettings)
        {
            return await mimeMessage.SendAsync(emailSettings.SmtpHost, emailSettings.SmtpPort, emailSettings.EnableSsl, emailSettings.UserName, emailSettings.Password);
        }
        //
        #endregion // Send
        //
        //  string EmailToString(this mimeMessage)
        //
        #region "Email ToString"
        //
        /// <summary>
        /// Format a string of the current mail message
        /// </summary>
        /// <returns>formated string of a mail message</returns>
        public static string EmailToString(this MimeMessage mimeMessage)
        {
            //
            string _attachments = string.Join("", mimeMessage.Attachments.Select(_a => ", Attachment: " + _a.ContentType + " ").ToList());
            string _tos = string.Join("", mimeMessage.To.Mailboxes.Select(_t => string.Format("'{0}' <{1}> ", _t.Name, _t.Address)).ToList());
            string _ccs = string.Join("", mimeMessage.Cc.Mailboxes.Select(_t => string.Format("'{0}' <{1}> ", _t.Name, _t.Address)).ToList());
            if (!string.IsNullOrEmpty(_ccs))
                _ccs = "CC: " + _ccs + ", ";
            //
            string _message = mimeMessage.TextBody;
            if (string.IsNullOrEmpty(_message))
                _message = mimeMessage.HtmlBody;
            return String.Format("From: {0}, To: {1}, {2}Subject: {3}, Body: {4} {5}",
                mimeMessage.From.ToString(),
                _tos, _ccs, mimeMessage.Subject, _message, _attachments);
        }
        //
        #endregion // Email ToString
        //
    }
}
