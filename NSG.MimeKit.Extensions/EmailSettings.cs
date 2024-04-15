//
using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
//
