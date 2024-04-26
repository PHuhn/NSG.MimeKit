//
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;
//
namespace MimeKit.NSG
{
    //
    /// <summary>
    /// AppSetting.json tree
    /// </summary>
    public class EmailSettings
    {
        //
        /// <summary>
        /// Host name of the SMTP server or relay.
        /// </summary>
        public string SmtpHost { get; set; } = "";
        //
        /// <summary>
        /// An integer port number.
        /// </summary>
        public int SmtpPort { get; set; } = 0;
        //
        /// <summary>
        /// Boolean value for enabling SSL.
        /// </summary>
        public bool EnableSsl { get; set; } = false;
        //
        /// <summary>
        /// Host name of the IMAP server or relay.
        /// Example: imap.gmail.com
        /// </summary>
        public string IMapHost { get; set; } = "";
        //
        /// <summary>
        /// An integer port number of the IMAP server.
        /// Example: 993
        /// </summary>
        public int IMapPort { get; set; } = 0;
        //
        /// <summary>
        /// Boolean value for enabling SSL for IMAP protocol.
        /// </summary>
        public bool IMapEnableSsl { get; set; } = false;
        //
        /// <summary>
        /// Email providers name for in-box mail folder
        /// </summary>
        public string InBox { get; set; } = "";
        //
        /// <summary>
        /// Email providers name for sent mail folder
        /// </summary>
        public string SentBox { get; set; } = "";
        //
        /// <summary>
        /// Connect to the SMTP host with this userName.
        /// </summary>
        public string UserName { get; set; } = "";
        //
        /// <summary>
        /// Connect to the SMTP host with this e-mail address.
        /// </summary>
        public string UserEmail { get; set; } = "";
        //
        /// <summary>
        /// Connect to the email host with user password or app password.
        /// </summary>
        public string Password { get; set; } = "";
        //
        /// <summary>
        /// Create a 'to string'.
        /// </summary>
        public override string ToString()
        {
            //
            StringBuilder _return = new StringBuilder("record:[");
            _return.AppendFormat("SmtpHost: {0}, ", this.SmtpHost)
                .AppendFormat("SmtpPort: {0}, ", SmtpPort)
                .AppendFormat("EnableSsl: {0}\n", EnableSsl)
                .AppendFormat("IMapHost: {0}, ", IMapHost)
                .AppendFormat("IMapPort: {0}, ", IMapPort)
                .AppendFormat("IMapEnableSsl: {0}\n", IMapEnableSsl)
                .AppendFormat("InBox: {0}, ", SmtpHost)
                .AppendFormat("SentBox: {0}\n", SentBox)
                .AppendFormat("UserName: {0}, ", UserName)
                .AppendFormat("UserEmail: {0}, ", UserEmail)
                .AppendFormat("Password (last 4): {0}]", Password.Substring(Math.Max(0, Password.Length - 4)));
            return _return.ToString();
        }
    }
}
//
