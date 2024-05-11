//
using System;
using System.Text;
//
using MailKit.Security;
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
        ///  <list type="table">
        ///   <listheader><term>Examples</term></listheader>
        ///   <item><term>smtp.gmail.com</term></item>
        ///   <item><term>smtp.mail.yahoo.com</term></item>
        ///  </list>
        /// </summary>
        public string SmtpHost { get; set; } = "";
        //
        /// <summary>
        /// An integer port number.
        /// Simple Mail Transfer Protocol (SMTP) used port 25.
        /// SMTP should use port 587 — this is the port for encrypted email 
        /// transmissions using SMTP Secure (SMTPS).
        /// Port 465 is also used sometimes for SMTPS. However, this is an
        /// outdated implementation and port 587 should be used if possible.
        ///  <list type="bullet">
        ///   <listheader><term>Port</term><description>Description</description></listheader>
        ///   <item><term>25</term><description>Unsecured</description></item>
        ///   <item><term>465</term><description>Secured with SSL</description></item>
        ///   <item><term>587</term><description>Secured TLS</description></item>
        ///  </list>
        /// </summary>
        public int SmtpPort { get; set; } = 0;
        //
        /// <summary>
        /// Enum value for SMTP SecureSocketOptions.
        ///  <list type="bullet">
        ///   <listheader><term>Enum</term><description>Value</description></listheader>
        ///   <item><term>None</term><description>0</description></item>
        ///   <item><term>Auto</term><description>1</description></item>
        ///   <item><term>SslOnConnect</term><description>2</description></item>
        ///   <item><term>StartTls</term><description>3</description></item>
        ///   <item><term>StartTlsWhenAvailable</term><description>4</description></item>
        ///  </list>
        /// </summary>
        public SecureSocketOptions SmtpSecureOption { get; set; } = SecureSocketOptions.None;
        //
        /// <summary>
        /// Host name of the IMAP server or relay.
        ///  <list type="table">
        ///   <listheader><term>Examples</term></listheader>
        ///   <item><term>imap.gmail.com</term></item>
        ///   <item><term>imap.mail.yahoo.com</term></item>
        ///  </list>
        /// </summary>
        public string IMapHost { get; set; } = "";
        //
        /// <summary>
        /// An integer port number of the IMAP server.
        ///  <list type="bullet">
        ///   <listheader><term>Port</term><description>Description</description></listheader>
        ///   <item><term>143</term><description>Unsecured</description></item>
        ///   <item><term>993</term><description>Secured port over TLS/SSL</description></item>
        ///  </list>
        /// </summary>
        public int IMapPort { get; set; } = 0;
        //
        /// <summary>
        /// Enum value of SecureSocketOptions for IMAP protocol.
        ///  <list type="bullet">
        ///   <listheader><term>Enum</term><description>Value</description></listheader>
        ///   <item><term>None</term><description>0</description></item>
        ///   <item><term>Auto</term><description>1</description></item>
        ///   <item><term>SslOnConnect</term><description>2</description></item>
        ///   <item><term>StartTls</term><description>3</description></item>
        ///   <item><term>StartTlsWhenAvailable</term><description>4</description></item>
        ///  </list>
        /// </summary>
        public SecureSocketOptions IMapSecureOption { get; set; } = SecureSocketOptions.None;
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
        /// Connect to the email host with app password or user password.
        /// Most likely a 16 letter app password
        /// </summary>
        public string Password { get; set; } = "";
        //
        /// <summary>
        /// Override the default 'to string' with the actual values of the instance.
        /// </summary>
        public override string ToString()
        {
            //
            StringBuilder _return = new StringBuilder("record:[");
            _return.AppendFormat("SmtpHost: {0}, ", this.SmtpHost)
                .AppendFormat("SmtpPort: {0}, ", SmtpPort)
                .AppendFormat("SmtpSecureOption: {0}\n", SmtpSecureOption)
                .AppendFormat("IMapHost: {0}, ", IMapHost)
                .AppendFormat("IMapPort: {0}, ", IMapPort)
                .AppendFormat("IMapSecureOption: {0}\n", IMapSecureOption)
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
