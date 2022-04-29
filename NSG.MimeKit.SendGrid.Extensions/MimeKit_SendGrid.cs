//
using System;
using MimeKit;
using SendGrid;
using SendGrid.Helpers.Mail;
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
    /// SendGrid message conversion.
    /// </summary>
    public static class SendGridExtensions
    {
        //
        /// <summary>
        /// lambda method to move MimeKit MailboxAddress email address to a 
        /// new SendGrid EmailAddress address.
        /// </summary>
        /// <param name="address">a MailboxAddress email address</param>
        /// <returns>a new SendGrid EmailAddress address</returns>
        public static EmailAddress ConvertToEmailAddress(MailboxAddress address) => new EmailAddress(address.Address, address.Name);
        //
        /// <summary>
        /// lambda method to move SendGrid EmailAddress email address to a 
        /// new MimeKit MailboxAddress address.
        /// </summary>
        /// <param name="address">a SendGrid EmailAddress email address</param>
        /// <returns>a new MimeKit MailboxAddress address</returns>
        public static MailboxAddress ConvertToMailboxAddress(EmailAddress address) => new MailboxAddress(address.Name, address.Email);
        //
        /// <summary>
        /// Convert a SendGridMessage mail message, and load it into a new mime message.
        /// <example>
        /// This sample shows how to call the NewMimeMessage method.
        /// <code>
        ///  // translate the message from SendGridMessage to MimeMessage
        ///  SendGridMessage _sgm = MailHelper.CreateSingleEmail(_from, _to, _subject, _plainTextContent, null);
        ///  MimeMessage _email = SendGridExtensions.NewMailMessage(_sgm);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="sgm">A SendGrid.Helpers.Mail.SendGridMessage mail message.</param>
        /// <returns>A new MimeMessage to allow fluent design.</returns>
        public static MimeMessage NewMimeMessage( SendGridMessage sgm )
        {
            //
            var _mimeMessage = new MimeMessage();
            //
            _mimeMessage.From.Add( ConvertToMailboxAddress(sgm.From) );
            foreach(Personalization per in sgm.Personalizations )
            {
                foreach ( var to in per.Tos )
                    _mimeMessage.To.Add( ConvertToMailboxAddress( to ) );
                if( per.Ccs != null )
                    foreach ( var cc in per.Ccs )
                        _mimeMessage.Cc.Add(ConvertToMailboxAddress(cc));
                if (per.Bccs != null)
                    foreach ( var bcc in per.Bccs )
                        _mimeMessage.Bcc.Add( ConvertToMailboxAddress( bcc ) );
            }
            if (sgm.Subject != null)
                _mimeMessage.Subject = sgm.Subject;
            if (string.IsNullOrEmpty(_mimeMessage.Subject) && sgm.Personalizations.Count > 0)
                _mimeMessage.Subject = sgm.Personalizations[0].Subject;
            //
            // HtmlBody = message
            // or:
            // TextBody = message
            BodyBuilder _body = new BodyBuilder();
            if (sgm.Contents != null && sgm.Contents.Count > 0)
            {
                if( sgm.Contents[0].Type.Contains("html") )
                {
                    _body.HtmlBody = sgm.Contents[0].Value;
                }
                else
                {
                    _body.TextBody = sgm.Contents[0].Value;
                }
            }
            else
            {
                if ( !string.IsNullOrEmpty(sgm.PlainTextContent) )
                {
                    _body.TextBody = sgm.PlainTextContent;
                }
                else
                {
                    _body.HtmlBody = sgm.HtmlContent;
                }
            }
            //
            if (sgm.Attachments != null && sgm.Attachments.Count > 0)
            {
                foreach (var _attachment in sgm.Attachments)
                {
                    string[] _medias = _attachment.Type.Split('/');
                    if (_medias.Length != 2)
                        throw new ApplicationException("Bad mime type: " + _attachment.Type);
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
                    _body.Attachments.Add(_attachment.Filename, Convert.FromBase64String(_attachment.Content), _contentType);
                }
            }
            //
            _mimeMessage.Body = _body.ToMessageBody();
            return _mimeMessage;
        }
        //
    }
}
//
