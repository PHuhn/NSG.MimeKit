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
        public string SmtpHost { get; set; }
        //
        /// <summary>
        /// An integer port number.
        /// </summary>
        public int SmtpPort { get; set; }
        //
        /// <summary>
        /// Boolean value for enabling SSL.
        /// </summary>
        public bool EnableSsl { get; set; }
        //
        /// <summary>
        /// Connect to the SMTP host with this userName.
        /// </summary>
        public string UserName { get; set; }
        //
        /// <summary>
        /// Connect to the SMTP host with this e-mail address.
        /// </summary>
        public string UserEmail { get; set; }
        //
        /// <summary>
        /// Connect to the SMTP host with this user name's password.
        /// </summary>
        public string Password { get; set; }
        //
    }
}
//
