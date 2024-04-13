using System;
using System.Threading.Tasks;
using System.Linq;
//
using NUnit.Framework;
using Newtonsoft.Json;
//
using SendGrid;
using SendGrid.Helpers.Mail;
using MimeKit;
//
namespace NSG.MimeKit_Tests
{
    public class MimeKit_SendGrid_Extensions_Tests
    {
        //
        // public static EmailAddress ConvertToEmailAddress(MailboxAddress address) => new EmailAddress(address.Address, address.Name);
        [Test]
        public void SendGrid_ConvertToEmailAddress_Test()
        {
            string _userName = "User Name";
            string _address = "UserName@AnyWhere.com";
            MailboxAddress _mbAddress = new MailboxAddress(_userName, _address);
            EmailAddress _actual = SendGridExtensions.ConvertToEmailAddress(_mbAddress);
            Console.WriteLine(_userName + " " + _address);
            Console.WriteLine(_actual.ToString());
            Assert.That(_actual.Name, Is.EqualTo(_userName));
            Assert.That(_actual.Email, Is.EqualTo(_address));
        }
        //
        // public static MailboxAddress ConvertToMailboxAddress(EmailAddress address) => new MailboxAddress(address.Email, address.Name);
        [Test]
        public void SendGrid_ConvertToMailboxAddress_Test()
        {
            string _userName = "User Name";
            string _address = "UserName@AnyWhere.com";
            EmailAddress _ebAddress = new EmailAddress(_address, _userName);
            MailboxAddress _actual = SendGridExtensions.ConvertToMailboxAddress(_ebAddress);
            Console.WriteLine(_userName + " " + _address);
            Console.WriteLine(_actual.ToString());
            Assert.That(_actual.Name, Is.EqualTo(_userName));
            Assert.That(_actual.Address, Is.EqualTo(_address));
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
        [Test]
        public void SendGrid_NewMailMessage_Deserialize_Test()
        {
            EmailAddress _from = new EmailAddress("PhilH@yahoo.com", "Phil Huhn");
            EmailAddress _to = new EmailAddress("abuse@internap.com", "Abuse Admin");
            string _subject = "Denial-of-service attack from 63.251.98.12";
            string _plainTextContent = "Hi";
            SendGridMessage _sgm = MailHelper.CreateSingleEmail(_from, _to, _subject, _plainTextContent, null);
            MimeMessage _mimeMessage = SendGridExtensions.NewMimeMessage(_sgm);
            Console.WriteLine(_mimeMessage.From[0].ToString());
            Assert.That(_mimeMessage.From[0].ToString(), Is.EqualTo("\"Phil Huhn\" <PhilH@yahoo.com>"));
            Assert.That(_mimeMessage.To[0].ToString(), Is.EqualTo("\"Abuse Admin\" <abuse@internap.com>"));
            Assert.That(_mimeMessage.Subject, Is.EqualTo("Denial-of-service attack from 63.251.98.12"));
            Assert.That(_mimeMessage.TextBody, Is.EqualTo("Hi"));
        }
        //
        [Test]
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
            Assert.That(_mimeMessage.TextBody, Is.EqualTo("Hi"));
            int _count = 0;
            foreach(MimeEntity _item in _mimeMessage.Attachments)
            {
                _count++;
                Console.WriteLine(_item.ToString());
                Assert.That(_item.ContentType.ToString(), Is.EqualTo("Content-Type: text/plain; name=\"AbuseReport.txt\""));
            }
            Assert.That(_count, Is.EqualTo(1));
            //
        }
        //
        [Test]
        public void SendGrid_NewMailMessage_Json_Test()
        {
            //
            string _sgString = @"{""content"":[{""value"":""Hi Stop the intrusion from your IP address 54.183.209.144."",""type"":""text/plain""}],""Personalizations"":[{""to"":[{""Name"":"""",""Email"":""abuse@amazonaws.com""}],""Ccs"":[],""Bccs"":[],""Subject"":""ViewState probe from 54.183.209.144""}],""From"":{""email"":""PhilHuhn@yahoo.com"",""name"":""Phil Huhn""},""Subject"":""ViewState probe from 54.183.209.144"",""Attachments"":[],""HtmlContent"":"""",""PlainTextContent"":""""}";
            SendGridMessage _sgMessage = JsonConvert.DeserializeObject<SendGridMessage>(_sgString);

            // (_from, _to, _subject, _plainTextContent, null);
            MimeMessage _mimeMessage = SendGridExtensions.NewMimeMessage(_sgMessage);
            //
            Assert.That(_mimeMessage.To.Mailboxes.FirstOrDefault().Address, Is.EqualTo("abuse@amazonaws.com"));
            Assert.That(_mimeMessage.From.Mailboxes.FirstOrDefault().Address, Is.EqualTo("PhilHuhn@yahoo.com"));
            Assert.That(_mimeMessage.Subject, Is.EqualTo("ViewState probe from 54.183.209.144"));
            Assert.That(_mimeMessage.TextBody, Is.EqualTo("Hi Stop the intrusion from your IP address 54.183.209.144.") );
            //
        }
        //
    }
}
//
