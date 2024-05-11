// ===========================================================================
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
//
using Microsoft.Extensions.Configuration;
//
using MailKit;
using MailKit.Net.Imap;
using MimeKit;
using MimeKit.NSG;
using NUnit.Framework;
using Org.BouncyCastle.Utilities.Encoders;
//
namespace NSG.MimeKit_Tests
{
    public class MimeKit_IMap_Tests
    {
        //
        [SetUp]
        public void Setup()
        {
        }
        //
        [Test]
        public async Task MailKit_IMap_GetEmailSettings_Test()
        {
            // given
            EmailSettings _emailSettings = EmailSettings_Config_Tests.GetEmailSettings("NSG");
            Assert.That(_emailSettings, Is.Not.Null);
            //
        }
        //
        [Test]
        public async Task MailKit_IMap_Get_Folders_Test()
        {
            // given
            EmailSettings _emailSettings = EmailSettings_Config_Tests.GetEmailSettings("NSG");
            Console.WriteLine(_emailSettings);
            NSG_IMap _example = new NSG_IMap(_emailSettings);
            // when
            List<string> _folders = await _example.RetrieveFolders();
            // then
            Console.WriteLine(_folders);
            Assert.That(_folders.Count, Is.GreaterThan(0));
            foreach (string _folder in _folders)
            {
                Console.WriteLine(_folder);
            }
            //
        }
        //
        [Test]
        public async Task MailKit_IMap_Get_Mail_From_Folder_Test()
        {
            // given
            EmailSettings _emailSettings = EmailSettings_Config_Tests.GetEmailSettings("NSG");
            string _folderName = _emailSettings.SentBox;
            NSG_IMap _example = new NSG_IMap(_emailSettings);
            // when
            List<EmailData> _items = await _example.RetrieveMessages(_folderName);
            // then
            Console.WriteLine(_items.Count);
            Assert.That(_items.Count, Is.GreaterThan(0));
            foreach (EmailData _item in _items)
            {
                // {_item.Id} -
                Console.WriteLine($"Id: {_item.Id}\nFrom: {_item.From}\nTo: {_item.To}\nDate: {_item.Date}\n{_item.Subject}\n\n{_item.Body}\n");
            }
            //
        }
        //
        [Test]
        public async Task MailKit_IMap_Get_Mail_From_Folder_AfterDate_Test()
        {
            // given
            EmailSettings _emailSettings = EmailSettings_Config_Tests.GetEmailSettings("NSG");
            string _folderName = _emailSettings.InBox;
            NSG_IMap _example = new NSG_IMap(_emailSettings);
            // when
            List<EmailData> _items = await _example.RetrieveMessagesAfter(_folderName, new DateTime(2024, 4, 1, 0, 0, 0));
            // then
            Console.WriteLine(_items.Count);
            Assert.That(_items.Count, Is.GreaterThan(0));
            foreach (EmailData _item in _items)
            {
                Console.WriteLine(_item.ToString());
            }
            //
        }
        //
        [Test]
        public async Task MailKit_IMap_Get_Mail_Message_By_Id_Test()
        {
            // given
            EmailSettings _emailSettings = EmailSettings_Config_Tests.GetEmailSettings("NSG");
            string _folderName = _emailSettings.InBox;
            string _messageId = "422443090.136304.1712927763040@mail.yahoo.com";
            NSG_IMap _example = new NSG_IMap(_emailSettings);
            // when
            MimeMessage _item = await _example.GetMessage(_folderName, _messageId);
            // then
            Assert.That(_item, Is.Not.Null);
            Console.WriteLine($"{_item.From.ToString()}\n{_item.To.ToString()}\n{_item.Subject}\n{_item.Body}");
            //
        }
        //
        [Test]
        public async Task MailKit_IMap_Get_EmailData_By_Uid_Test()
        {
            // given
            EmailSettings _emailSettings = EmailSettings_Config_Tests.GetEmailSettings("NSG");
            string _folderName = _emailSettings.InBox;
            UniqueId _uid = new UniqueId(837);
            NSG_IMap _example = new NSG_IMap(_emailSettings);
            // when
            EmailData _item = await _example.GetEmailData(_folderName, _uid);
            // then
            Assert.That(_item, Is.Not.Null);
            Console.WriteLine(_item.ToString());
            //
        }
        //
    }
}
// ===========================================================================
