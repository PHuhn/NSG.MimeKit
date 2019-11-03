using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.Configuration;
using MimeKit;
//
namespace NSG.MimeKit_Tests
{
    [TestClass]
    public class MimeKit_Extensions_Tests
    {
        //
        [TestMethod]
        public void MimeKit_Extensions_NewMimeMessage01_Test()
        {
            //
            MimeMessage _email = Extensions.NewMimeMessage()
                .From("FromUser1@somewhere.com");
            Console.WriteLine(_email);
            Assert.IsNotNull(_email);
            //
        }
        //
        //  static MimeMessage  From(fromAddress)
        //  static MimeMessage  From(fromAddress, name)
        //  static MimeMessage  From( MailboxAddress )
        //
        #region "From"
        //
        [TestMethod]
        public void MimeKit_Extensions_From01_Test()
        {
            //
            string _fromAddress = "FromUser1@somewhere.com";
            string _toName = "ToUser1";
            string _toAddress = "ToUser1@somewhere.com";
            string _subject = "Subject 1";
            MimeMessage _email = (new MimeMessage())
                .From(_fromAddress)
                .To(_toName, _toAddress)
                .Subject(_subject);
            string _actual = _email.From[0].ToString();
            string _expected = _fromAddress;
            Console.WriteLine(_expected + " " + _actual);
            Assert.AreEqual(_expected, _actual);
            //
        }
        //
        [TestMethod]
        public void MimeKit_Extensions_From02_Test()
        {
            //
            string _fromName = "FromUser2";
            string _fromAddress = "FromUser2@somewhere.com";
            string _toName = "ToUser2";
            string _toAddress = "ToUser2@somewhere.com";
            string _subject = "Subject 2";
            MimeMessage _email = (new MimeMessage())
                .From(_fromAddress, _fromName)
                .To(_toName, _toAddress)
                .Subject(_subject);
            string _actual = _email.From[0].ToString();
            string _expected = string.Format("\"{0}\" <{1}>", _fromName, _fromAddress);
            Console.WriteLine(_expected + " " + _actual);
            Assert.AreEqual(_expected, _actual);
            //
        }
        //
        [TestMethod]
        public void MimeKit_Extensions_From03_Test()
        {
            //
            string _fromName = "FromUser3";
            string _fromAddress = "FromUser3@somewhere.com";
            string _toName = "ToUser3";
            string _toAddress = "ToUser3@somewhere.com";
            string _subject = "Subject 3";
            MimeMessage _email = (new MimeMessage())
                .From(new MailboxAddress(_fromName, _fromAddress))
                .To(_toName, _toAddress)
                .Subject(_subject);
            string _actual = _email.From[0].ToString();
            string _expected = string.Format("\"{0}\" <{1}>", _fromName, _fromAddress);
            Console.WriteLine(_expected + " " + _actual);
            Assert.AreEqual(_expected, _actual);
            //
        }
        //
        #endregion // From
        //
        //  MimeMessage To(fromAddress)
        //  MimeMessage To(fromAddress, name)
        //  MimeMessage To( MailboxAddress )
        //  To(fromAddress, name).To(fromAddress, name)
        //
        #region "To"
        // 
        [TestMethod]
        public void MimeKit_Extensions_To01_Test()
        {
            //
            string _fromName = "FromUser1";
            string _fromAddress = "FromUser1@somewhere.com";
            // string _toName = "ToUser1";
            string _toAddress = "ToUser1@somewhere.com";
            string _subject = "Subject 1";
            MimeMessage _email = (new MimeMessage())
                .From(_fromName, _fromAddress)
                .To(_toAddress)
                .Subject(_subject);
            string _actual = _email.To[0].ToString();
            string _expected = _toAddress;
            Console.WriteLine(_expected + " " + _actual);
            Assert.AreEqual(_expected, _actual);
            //
        }
        //
        [TestMethod]
        public void MimeKit_Extensions_To02_Test()
        {
            //
            string _fromName = "FromUser2";
            string _fromAddress = "FromUser2@somewhere.com";
            string _toName = "ToUser2";
            string _toAddress = "ToUser2@somewhere.com";
            string _subject = "Subject 2";
            MimeMessage _email = (new MimeMessage())
                .From(_fromAddress, _fromName)
                .To(_toAddress, _toName)
                .Subject(_subject);
            string _actual = _email.To[0].ToString();
            string _expected = string.Format("\"{0}\" <{1}>", _toName, _toAddress);
            Console.WriteLine(_expected + " " + _actual);
            Assert.AreEqual(_expected, _actual);
            //
        }
        //
        [TestMethod]
        public void MimeKit_Extensions_To03_Test()
        {
            //
            string _fromName = "FromUser3";
            string _fromAddress = "FromUser3@somewhere.com";
            string _toName = "ToUser3";
            string _toAddress = "ToUser3@somewhere.com";
            string _subject = "Subject 3";
            MimeMessage _email = (new MimeMessage())
                .From(_fromName, _fromAddress)
                .To(new MailboxAddress(_toName, _toAddress))
                .Subject(_subject);
            string _actual = _email.To[0].ToString();
            string _expected = string.Format("\"{0}\" <{1}>", _toName, _toAddress);
            Console.WriteLine(_expected + " " + _actual);
            Assert.AreEqual(_expected, _actual);
            //
        }
        //
        [TestMethod]
        public void MimeKit_Extensions_To04_Test()
        {
            //
            string _toName = "ToUser4";
            string _toAddress = "ToUser4@somewhere.com";
            string _toName2 = "ToUser4-2";
            string _toAddress2 = "ToUser4-2@somewhere.com";
            string _subject = "Subject 4";
            MimeMessage _email = (new MimeMessage())
                .To(_toAddress, _toName)
                .To(_toAddress2, _toName2)
                .Subject(_subject);
            string _actual = _email.To[0].ToString();
            string _expected = string.Format("\"{0}\" <{1}>", _toName, _toAddress);
            Console.WriteLine(_expected + " " + _actual);
            Assert.AreEqual(_expected, _actual);
            //
            string _actual2 = _email.To[1].ToString();
            string _expected2 = string.Format("\"{0}\" <{1}>", _toName2, _toAddress2);
            Console.WriteLine(_expected2 + " " + _actual2);
            Assert.AreEqual(_expected2, _actual2);
            //
        }
        //
        #endregion // To
        //
        //  MimeMessage CC(fromAddress)
        //  MimeMessage CC(fromAddress, name)
        //  MimeMessage CC( MailboxAddress )
        //
        #region "CC"
        //
        [TestMethod]
        public void MimeKit_Extensions_CC01_Test()
        {
            //
            string _fromName = "FromUser1";
            string _fromAddress = "FromUser1@somewhere.com";
            // string _ccName = "CcUser1";
            string _ccAddress = "CcUser1@somewhere.com";
            string _subject = "Subject 1";
            MimeMessage _email = (new MimeMessage())
                .From(_fromName, _fromAddress)
                .CC(_ccAddress)
                .Subject(_subject);
            string _actual = _email.Cc[0].ToString();
            string _expected = _ccAddress;
            Console.WriteLine(_expected + " " + _actual);
            Assert.AreEqual(_expected, _actual);
            //
        }
        //
        [TestMethod]
        public void MimeKit_Extensions_CC02_Test()
        {
            //
            string _fromName = "FromUser2";
            string _fromAddress = "FromUser2@somewhere.com";
            string _ccName = "CcUser2";
            string _ccAddress = "CcUser2@somewhere.com";
            string _subject = "Subject 2";
            MimeMessage _email = (new MimeMessage())
                .From(_fromName, _fromAddress)
                .CC(_ccAddress, _ccName)
                .Subject(_subject);
            string _actual = _email.Cc[0].ToString();
            string _expected = string.Format("\"{0}\" <{1}>", _ccName, _ccAddress);
            Console.WriteLine(_expected + " " + _actual);
            Assert.AreEqual(_expected, _actual);
            //
        }
        //
        [TestMethod]
        public void MimeKit_Extensions_CC03_Test()
        {
            //
            string _fromName = "FromUser3";
            string _fromAddress = "FromUser3@somewhere.com";
            string _ccName = "CcUser3";
            string _ccAddress = "CcUser3@somewhere.com";
            string _subject = "Subject 3";
            MimeMessage _email = (new MimeMessage())
                .From(_fromName, _fromAddress)
                .CC(new MailboxAddress(_ccName, _ccAddress))
                .Subject(_subject);
            string _actual = _email.Cc[0].ToString();
            string _expected = string.Format("\"{0}\" <{1}>", _ccName, _ccAddress);
            Console.WriteLine(_expected + " " + _actual);
            Assert.AreEqual(_expected, _actual);
            //
        }
        //
        #endregion // CC
        //
        //  MimeMessage BCC(fromAddress)
        //  MimeMessage BCC(fromAddress, name)
        //  MimeMessage BCC( MailboxAddress )
        //
        #region "BCC"
        //
        [TestMethod]
        public void MimeKit_Extensions_BCC01_Test()
        {
            //
            string _fromName = "FromUser1";
            string _fromAddress = "FromUser1@somewhere.com";
            // string _bccName = "BccUser1";
            string _bccAddress = "BccUser1@somewhere.com";
            string _subject = "Subject 1";
            MimeMessage _email = (new MimeMessage())
                .From(_fromName, _fromAddress)
                .BCC(_bccAddress)
                .Subject(_subject);
            string _actual = _email.Bcc[0].ToString();
            string _expected = _bccAddress;
            Console.WriteLine(_expected + " " + _actual);
            Assert.AreEqual(_expected, _actual);
            //
        }
        //
        [TestMethod]
        public void MimeKit_Extensions_BCC02_Test()
        {
            //
            string _fromName = "FromUser2";
            string _fromAddress = "FromUser2@somewhere.com";
            string _bccName = "BccUser2";
            string _bccAddress = "BccUser2@somewhere.com";
            string _subject = "Subject 2";
            MimeMessage _email = (new MimeMessage())
                .From(_fromName, _fromAddress)
                .BCC(_bccAddress, _bccName)
                .Subject(_subject);
            string _actual = _email.Bcc[0].ToString();
            string _expected = string.Format("\"{0}\" <{1}>", _bccName, _bccAddress);
            Console.WriteLine(_expected + " " + _actual);
            Assert.AreEqual(_expected, _actual);
            //
        }
        //
        [TestMethod]
        public void MimeKit_Extensions_BCC03_Test()
        {
            //
            string _fromName = "FromUser3";
            string _fromAddress = "FromUser3@somewhere.com";
            string _bccName = "BccUser3";
            string _bccAddress = "BccUser3@somewhere.com";
            string _subject = "Subject 3";
            MimeMessage _email = (new MimeMessage())
                .From(_fromName, _fromAddress)
                .BCC(new MailboxAddress(_bccName, _bccAddress))
                .Subject(_subject);
            string _actual = _email.Bcc[0].ToString();
            string _expected = string.Format("\"{0}\" <{1}>", _bccName, _bccAddress);
            Console.WriteLine(_expected + " " + _actual);
            Assert.AreEqual(_expected, _actual);
            //
        }
        //
        #endregion // BCC
        //
        [TestMethod]
        public void MimeKit_Extensions_Subject01_Test()
        {
            //
            string _fromAddress = "FromUser1@somewhere.com";
            string _toAddress = "ToUser1@somewhere.com";
            string _subject = "Subject 1";
            MimeMessage _email = (new MimeMessage())
                .From(_fromAddress).To(_toAddress).Subject(_subject);
            string _actual = _email.Subject;
            string _expected = _subject;
            Console.WriteLine(_expected + " " + _actual);
            Assert.AreEqual(_expected, _actual);
            //
        }
        //
        [TestMethod]
        public void MimeKit_Extensions_TextBody01_Test()
        {
            //
            string _fromAddress = "FromUser1@somewhere.com";
            string _toAddress = "ToUser1@somewhere.com";
            string _subject = "Subject 1";
            string _message = "Text message 1";
            MimeMessage _email = (new MimeMessage())
                .From(_fromAddress).To(_toAddress)
                .Subject(_subject).Body(Extensions.TextBody(_message));
            string _actual = _email.TextBody;
            string _expected = _message;
            Console.WriteLine(_expected + " " + _actual);
            Assert.AreEqual(_expected, _actual);
            //
        }
        //
        [TestMethod]
        public void MimeKit_Extensions_HtmlBody01_Test()
        {
            //
            string _fromAddress = "FromUser1@somewhere.com";
            string _toAddress = "ToUser1@somewhere.com";
            string _subject = "Subject 1";
            string _message = "HTML message 1";
            MimeMessage _email = (new MimeMessage())
                .From(_fromAddress).To(_toAddress)
                .Subject(_subject).Body(Extensions.HtmlBody(_message));
            string _actual = _email.HtmlBody;
            string _expected = _message;
            Console.WriteLine(_expected + " " + _actual);
            Assert.AreEqual(_expected, _actual);
            //
        }
        //
        [TestMethod]
        public void MimeKit_Extensions_Attachment01_Test()
        {
            //
            string _fromAddress = "FromUser1@somewhere.com";
            string _toAddress = "ToUser1@somewhere.com";
            string _subject = "Subject 1";
            string _message = "See attachment:";
            byte[] _buffer = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x00 };
            MimeMessage _email = (new MimeMessage())
                .From(_fromAddress).To(_toAddress)
                .Subject(_subject).Body(
                    Extensions.TextBody(_message)
                        .Attachment(_buffer, "Text.txt", "text/plain;charset=utf-8")
                );
            string _actual = _email.TextBody;
            string _expected = _message;
            Console.WriteLine(_expected + " " + _actual);
            Assert.AreEqual(_expected, _actual);
            foreach (var _attachment in _email.Attachments)
                Console.WriteLine(_attachment.ToString());
            //
        }
        //
        [TestMethod]
        public void MimeKit_Extensions_SendAsync01_Test()
        {
            //
            string _fromAddress = "FromUser1@somewhere.com";
            string _toAddress = "ToUser1@somewhere.com";
            string _subject = "Subject 1";
            string _message = "See attachment:";
            byte[] _buffer = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x00 };
            Task<MimeMessage> _email = (new MimeMessage())
                .From(_fromAddress).To(_toAddress)
                .Subject(_subject).Body(
                    Extensions.TextBody(_message)
                        .Attachment(_buffer, "Text.txt", "text/plain;charset=utf-8")
                ).SendAsync(); // "localhost", 25, false, "", "");
            string _actual = _email.Result.TextBody;
            string _expected = _message;
            Console.WriteLine(_expected + " " + _actual);
            Assert.AreEqual(_expected, _actual);
            foreach (var _attachment in _email.Result.Attachments)
                Console.WriteLine(_attachment.ToString());
            //
        }
        //
        [TestMethod]
        public void MimeKit_Extensions_Config_SendAsync02_Test()
        {
            //
            string appSettings = "appsettings.json";
            if (appSettings != "")
                if (!File.Exists(appSettings))
                    throw new FileNotFoundException($"Settings file: {appSettings} not found.");
            IConfiguration _config = new ConfigurationBuilder()
                .AddJsonFile(appSettings, optional: true, reloadOnChange: false)
                .Build();
            //
            MimeKit.NSG.EmailSettings _emailSettings =
                _config.GetSection("EmailSettings").Get<MimeKit.NSG.EmailSettings>();
            string _toAddress = "ToUser1@somewhere.com";
            string _subject = "Subject 1";
            string _message = "Text message 1";
            Task<MimeMessage> _email = Extensions.NewMimeMessage()
                .From(_emailSettings.UserEmail, _emailSettings.UserName).To(_toAddress)
                .Subject(_subject).Body(Extensions.TextBody(_message))
                .SendAsync(_emailSettings);
            string _actual = _email.Result.TextBody;
            string _expected = _message;
            Console.WriteLine(_expected + " " + _actual);
            Assert.AreEqual(_expected, _actual);
            //
        }
        //
        [TestMethod]
        public void MimeKit_Extensions_EmailToString01_Test()
        {
            //
            string _toName = "ToUser4";
            string _toAddress = "To4@sw.com";
            string _toName2 = "To4-2";
            string _toAddress2 = "To4-2@sw.com";
            string _subject = "Subject 4";
            MimeMessage _email = (new MimeMessage())
                .From("P@any.net")
                .To(_toAddress, _toName)
                .To(_toAddress2, _toName2)
                .Subject(_subject).Body(Extensions.TextBody("Text message 4"));
            string _actual = _email.EmailToString();
            string _expected = "From: P@any.net, To: 'ToUser4' <To4@sw.com> 'To4-2' <To4-2@sw.com> , Subject: Subject 4, Body: Text message 4 ";
            Console.WriteLine(_expected + " " + _actual);
            Assert.AreEqual(_expected, _actual);
            //
        }
        //
        [TestMethod]
        public void MimeKit_Extensions_EmailToString02_Test()
        {
            //
            string _toName = "ToUser2";
            string _toAddress = "To2@sw.com";
            string _ccName = "Cc2";
            string _ccAddress = "Cc2@sw.com";
            string _subject = "Subject 2";
            byte[] _buffer = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x00 };
            MimeMessage _email = (new MimeMessage())
                .From("P@any.net")
                .To(_toAddress, _toName)
                .CC(_ccAddress, _ccName)
                .Subject(_subject).Body(
                    Extensions.TextBody("Text message 2")
                        .Attachment(_buffer, "Text.txt", "text/plain;charset=utf-8")
                    );
            string _actual = _email.EmailToString();
            string _expected =
                "From: P@any.net, To: 'ToUser2' <To2@sw.com> , CC: 'Cc2' <Cc2@sw.com> , Subject: Subject 2, Body: Text message 2 , Attachment: Content-Type: text/plain; charset=\"utf-8\"; name=\"Text.txt\" ";
            Console.WriteLine(_expected + " " + _actual);
            Assert.AreEqual(_expected, _actual);
            //
        }
        //
    }
}
//
