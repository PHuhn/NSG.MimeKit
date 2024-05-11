// ===========================================================================
using System;
using System.Collections.Generic;
//
using NUnit.Framework;
using Microsoft.Extensions.Configuration;
//
using MimeKit.NSG;
using MailKit.Security;
//
namespace NSG.MimeKit_Tests
{
    public class EmailSettings_Config_Tests
    {
        //
        [SetUp]
        public void Setup()
        {
        }
        //
        public static IConfiguration GetAppSettings()
        {
            //
            IConfiguration _config = null;
            Console.WriteLine("GetAppSettings: Entering ...");
            string _appSettings = "appSettings.json";
            try
            {
                _config = new ConfigurationBuilder()
                    .AddJsonFile(_appSettings, optional: true, reloadOnChange: false)
                    .AddUserSecrets<MimeKit_IMap_Tests>()
                    .Build();
                if (_config == null)
                {
                    var _msg = "GetAppSettings: ConfigurationBuilder, Could not find EmailSettings in secrets.json";
                    Console.WriteLine(_msg);
                    throw new Exception(_msg);
                }
            }
            catch (Exception _ex)
            {
                Console.WriteLine(_ex.Message);
                throw;
            }
            return _config;
        }
        //
        public static EmailTo GetEmailTo(string name)
        {
            //
            EmailTo _emailTo;
            try
            {
                IConfiguration _config = GetAppSettings();
                if (_config != null)
                {
                    _emailTo = _config.GetSection(name).Get<EmailTo>();
                }
                else
                {
                    var _msg = "GetEmailSettings: ConfigurationBuilder, Could not find EmailSettings in secrets.json";
                    Console.WriteLine(_msg);
                    throw new Exception(_msg);
                }
            }
            catch (Exception _ex)
            {
                Console.WriteLine(_ex.Message);
                throw;
            }
            return _emailTo;
        }
        //
        public static Dictionary<string, EmailSettings> GetEmailSettingsDict()
        {
            //
            Dictionary<string, EmailSettings> _emailSettingsDict;
            Console.WriteLine("GetEmailSettingsDict: Entering ...");
            try
            {
                IConfiguration _config = GetAppSettings();
                Console.WriteLine($"GetEmailSettings: After config: {_config}");
                //
                if (_config != null)
                {
                    _emailSettingsDict =
                        _config.GetSection("EmailSettings").Get<Dictionary<string, EmailSettings>>();
                }
                else
                {
                    var _msg = "GetEmailSettings: ConfigurationBuilder, Could not find EmailSettings in secrets.json";
                    Console.WriteLine(_msg);
                    throw new Exception(_msg);
                }
            }
            catch (Exception _ex)
            {
                Console.WriteLine(_ex.Message);
                throw;
            }
            return _emailSettingsDict;
        }
        public static EmailSettings GetEmailSettings(string companyName)
        {
            //
            EmailSettings _emailSettings;
            Dictionary<string, EmailSettings> _emailSettingsDict = GetEmailSettingsDict();
            Console.WriteLine("GetEmailSettings: Entering ...");
            if (_emailSettingsDict != null)
            {
                _emailSettings = _emailSettingsDict[companyName];
            }
            else
            {
                var _msg = "GetEmailSettings: Get dictionary returned null.";
                Console.WriteLine(_msg);
                throw new Exception(_msg);
            }
            return _emailSettings;
        }
        //
        [Test]
        public void EmailSettings_Config_ToString_Test()
        {
            // given
            EmailSettings _emailSettings = new EmailSettings() {
                SmtpHost = "smtp.gmail.com",
                SmtpPort = 587,
                SmtpSecureOption = SecureSocketOptions.StartTls,
                IMapHost = "imap.gmail.com",
                IMapPort = 993,
                IMapSecureOption = SecureSocketOptions.StartTlsWhenAvailable,
                InBox = "INBOX",
                SentBox = "[Gmail]/Sent Mail",
                UserName = "Administrator",
                UserEmail = "Phil@gmail.com",
                Password = "iiii vvvv uuuu dbdb"
              };
            // when
            string _emailSettingsStr = _emailSettings.ToString();
            // then
            Console.WriteLine(_emailSettingsStr);
            Assert.That(_emailSettingsStr, Is.Not.Empty);
            //                                                         12345678901234567890
            Assert.That(_emailSettingsStr.Substring(0,17), Is.EqualTo("record:[SmtpHost:"));
            //
        }
        //
        [Test]
        public void EmailSettings_Config_GetEmailSettingsDict_Test()
        {
            // given / when
            Dictionary<string, EmailSettings> _emailSettingsDict = GetEmailSettingsDict();
            // then
            Assert.That(_emailSettingsDict, Is.Not.Null);
            Assert.That(_emailSettingsDict.Count, Is.GreaterThan(1));
            //
        }
        //
        [Test]
        public void EmailSettings_Config_GetEmailSettings_For_Default_Test()
        {
            // given / when
            EmailSettings _emailSettings = GetEmailSettings("Default");
            // then
            Assert.That(_emailSettings, Is.Not.Null);
            Console.WriteLine(_emailSettings.ToString());
            //
        }
        //
        [Test]
        public void EmailSettings_Config_GetEmailSettings_For_NSG_Test()
        {
            // given / when
            EmailSettings _emailSettings = GetEmailSettings("NSG");
            // then
            Assert.That(_emailSettings, Is.Not.Null);
            Console.WriteLine(_emailSettings.ToString());
            //
        }
        //
    }
}
// ===========================================================================
