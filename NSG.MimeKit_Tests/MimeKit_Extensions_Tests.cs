using System;
using System.Text;
using MimeKit;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
                .From(_fromName, _fromAddress)
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
                .From(_fromName, _fromAddress)
                .To(_toName, _toAddress)
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
                .To(_toName, _toAddress)
                .To(_toName2, _toAddress2)
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
                .CC(_ccName, _ccAddress)
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
                .BCC(_bccName, _bccAddress)
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
    }
}
//
