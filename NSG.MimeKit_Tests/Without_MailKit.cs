// ===========================================================================
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
//
using Microsoft.Extensions.Configuration;
//
using MimeKit.NSG;
using NUnit.Framework;
//
namespace NSG.MimeKit_Tests
{
    public class Without_MailKit
    {
        //
        [SetUp]
        public void Setup()
        {
        }
        //
        [Test]
        public async Task Without_RetrieveFolders()
        {
            //
            string _settingsName = "Yahoo";
            EmailSettings _emailSettings = EmailSettings_Config_Tests.GetEmailSettings(_settingsName);
            var _list = new List<string>();
            using (var _client = new MailKit.Net.Imap.ImapClient())
            {
                // get all folders ...
                try
                {
                    _client.Connect(_emailSettings.IMapHost, _emailSettings.IMapPort, true);
                    _client.Authenticate(_emailSettings.UserEmail, _emailSettings.Password);
                    var _folders = await _client.GetFoldersAsync(new MailKit.FolderNamespace('.', ""));
                    foreach (var _item in _folders)
                    {
                        _list.Add(_item.FullName);
                        Console.WriteLine(_item.FullName);
                    }
                }
                catch (Exception _ex)
                {
                    Assert.Fail(_ex.Message);
                    throw;
                }
                _client.Disconnect(true);
                _client.Dispose();
                Assert.That(_list.Count, Is.GreaterThan(2));
            }
        }
        //
        [Test]
        public async Task Real_MailMessage_Send_Test()
        {
            //
            string _settingsName = "Yahoo";
            EmailTo _emailTo = EmailSettings_Config_Tests.GetEmailTo("gmail");
            EmailSettings _emailSettings = EmailSettings_Config_Tests.GetEmailSettings(_settingsName);
            var _from = new MailAddress(_emailSettings.UserEmail, _emailSettings.UserName);
            var _to = new MailAddress(_emailTo.UserEmail, _emailTo.UserName);
            string _subject = $"Test email from Net-Incident ({_settingsName})";
            string _message = $"Test text message use configuration {_settingsName}.";
            Console.WriteLine($"Settings: {_emailSettings}");
            try
            {
                MailMessage _email = new MailMessage(_from, _to)
                {
                    Subject = _subject,
                    Body = _message,
                    IsBodyHtml = false
                };
                Console.WriteLine($"Message: {_email}");
                using (var _client = new System.Net.Mail.SmtpClient()
                {
                    Host = _emailSettings.SmtpHost,
                    Port = _emailSettings.SmtpPort,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(_emailSettings.UserEmail, _emailSettings.Password)
                })
                {
                    _client.Send(_email);
                };
                _email.Dispose();
                Assert.That(_email, Is.Not.Null);
            }
            catch ( Exception _ex )
            {
                Assert.Fail( _ex.Message );
                throw;
            }
            //
        }
        //
    }
}
// ===========================================================================
