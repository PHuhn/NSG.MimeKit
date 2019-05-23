using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//
using SendGrid;
using SendGrid.Helpers.Mail;
//
using MimeKit;
//
namespace NSG.MimeKit_Tests
{
    [TestClass]
    public class MimeKit_SendGrid_Extensions_Tests
    {
        //
        // public static EmailAddress ConvertToEmailAddress(MailboxAddress address) => new EmailAddress(address.Address, address.Name);
        [TestMethod]
        public void SendGrid_ConvertToEmailAddress_Test()
        {
            string _userName = "User Name";
            string _address = "UserName@AnyWhere.com";
            MailboxAddress _mbAddress = new MailboxAddress(_userName, _address);
            EmailAddress _actual = SendGridExtensions.ConvertToEmailAddress(_mbAddress);
            Console.WriteLine(_userName + " " + _address);
            Console.WriteLine(_actual.ToString());
            Assert.AreEqual(_userName, _actual.Name);
            Assert.AreEqual(_address, _actual.Email);
        }
        //
        // public static MailboxAddress ConvertToMailboxAddress(EmailAddress address) => new MailboxAddress(address.Email, address.Name);
        [TestMethod]
        public void SendGrid_ConvertToMailboxAddress_Test()
        {
            string _userName = "User Name";
            string _address = "UserName@AnyWhere.com";
            EmailAddress _ebAddress = new EmailAddress(_address, _userName);
            MailboxAddress _actual = SendGridExtensions.ConvertToMailboxAddress(_ebAddress);
            Console.WriteLine(_userName + " " + _address);
            Console.WriteLine(_actual.ToString());
            Assert.AreEqual(_userName, _actual.Name);
            Assert.AreEqual(_address, _actual.Address);
        }
        //
        // {
        //  contents:[{value:"Hi",type:"text/plain"}],
        //  personalizations:[{
        //   tos:[email:"abuse@internap.com"}],
        //   ccs:[],
        //   bccs:[],
        //   subject:"Denial-of-service attack from 63.251.98.12"
        //  }],
        //  from:{email:"PhilHuhn@yahoo.com",name:"Phil Huhn"},
        //  subject:"Denial-of-service attack from 63.251.98.12",
        //  plainTextConten:""
        // }
        [TestMethod]
        public void SendGrid_NewMailMessage_Deserialize_Test()
        {
            EmailAddress _from = new EmailAddress("PhilH@yahoo.com", "Phil Huhn");
            EmailAddress _to = new EmailAddress("abuse@internap.com", "Abuse Admin");
            string _subject = "Denial-of-service attack from 63.251.98.12";
            string _plainTextContent = "Hi";
            SendGridMessage _sgm = MailHelper.CreateSingleEmail(_from, _to, _subject, _plainTextContent, null);
            MimeMessage _mimeMessage = SendGridExtensions.NewMimeMessage(_sgm);
            Console.WriteLine(_mimeMessage.From[0].ToString());
            Assert.AreEqual("\"Phil Huhn\" <PhilH@yahoo.com>", _mimeMessage.From[0].ToString());
            Assert.AreEqual("\"Abuse Admin\" <abuse@internap.com>", _mimeMessage.To[0].ToString());
            Assert.AreEqual("Denial-of-service attack from 63.251.98.12", _mimeMessage.Subject);
            Assert.AreEqual("Hi", _mimeMessage.TextBody);
        }
        //
        [TestMethod]
        public void SendGrid_NewMailMessage_Test()
        {
            //
            byte[] _buffer = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x00 };
            EmailAddress _from = new EmailAddress("PhilH@yahoo.com", "Phil Huhn");
            EmailAddress _to = new EmailAddress("abuse@internap.com", "Abuse Admin");
            string _subject = "Denial-of-service attack from 63.251.98.12";
            string _plainTextContent = "Hi";
            SendGridMessage _sgMessage = MailHelper.CreateSingleEmail(_from, _to, _subject, _plainTextContent, null);
            // attachment
            _sgMessage.AddAttachment("AbuseReport.txt",
                  Convert.ToBase64String(_buffer),
                  "text/plain",
                  "attachment",
                  "AbuseReport");
            MimeMessage _mimeMessage = SendGridExtensions.NewMimeMessage(_sgMessage);
            //
            Assert.AreEqual("Hi", _mimeMessage.TextBody);
            int _count = 0;
            foreach(MimeEntity _item in _mimeMessage.Attachments)
            {
                _count++;
                Console.WriteLine(_item.ToString());
                Assert.AreEqual("Content-Type: text/plain; name=\"AbuseReport.txt\"", _item.ContentType.ToString());
            }
            Assert.AreEqual(1, _count);
            //
        }
        //
    }
}
//
