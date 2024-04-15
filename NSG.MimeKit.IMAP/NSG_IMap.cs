// ---------------------------------------------------------------------------
// File: NSG_IMap.cs
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
//
using MailKit;
using MimeKit;
using MailKit.Net.Imap;
using MailKit.Security;
using MailKit.Search;
using System.Runtime.ConstrainedExecution;
//
namespace MimeKit.NSG
{
    //
    /// <summary>
    /// Simple representation of an email message
    /// </summary>
    public class EmailData
    {
        public string Id { get; set; } = "";
        public string Uid { get; set; } = "";
        public string To { get; set; } = "";
        public string Cc { get; set; } = "";
        public string From { get; set; } = "";
        public string Subject { get; set; } = "";
        public string Date { get; set; } = "";
        public string Body { get; set; } = "";
        //
        /// <summary>
        /// Parameterless constructor
        /// </summary>
        public EmailData() { }
        //
        /// <summary>
        /// Conversion from MimeMessage constructor
        /// </summary>
        /// <param name="message"></param>
        /// <param name="uId"></param>
        public EmailData(MimeMessage message, string uId = "")
        {
            string _tos = "";
            string _ccs = "";
            foreach (var _to in message.To)
                _tos += _to.ToString() + " ";
            foreach (var _cc in message.Cc)
                _ccs += _cc.ToString() + " ";
            Id = message.MessageId;
            Uid = uId;
            To = _tos;
            Cc = _ccs;
            From = message.From[0].ToString();
            Subject = message.Subject;
            Date = message.Date.ToString();
            Body = message.TextBody;
        }
        //
        /// <summary>
        /// Create a 'to string'.
        /// </summary>
        public override string ToString()
        {
            return $"Id: {Id}\nUid: {Uid}\nFrom: {From}\nTo: {To}\nCC: {Cc}\nDate: {Date}\n{Subject}\n\n{Body}\n";
        }
    }
    //
    /// <summary>
    /// Set of IMAP retrieval methods:
    /// <list type="bullet">
    /// <item>bool imap_Authenticate(ImapClient client)</item>
    /// <item>Task<List<string>> RetrieveFolders()</item>
    /// <item>Task<List<EmailData>> RetrieveMessagesAfter(string mailBoxFolder, DateTime afterDate)</item>
    /// <item>Task<MimeMessage> GetMessage(string mailBoxFolder, string messageId)</item>
    /// <item>Task<EmailData> GetEmailData(string mailBoxFolder, UniqueId uniqueId)</item>
    /// </list>
    /// </summary>
    public class NSG_IMap
    {
        MimeKit.NSG.EmailSettings _emailSettings;
        //
        /// <summary>
        /// Constructor requiring an EmailSettings class.
        /// </summary>
        /// <param name="emailSettings"></param>
        public NSG_IMap(EmailSettings emailSettings)
        {
            _emailSettings = emailSettings;
        }
        //
        /// <summary>
        /// Connect/authenticate to a IMAP server.
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        protected bool imap_Authenticate(ImapClient client)
        {
            // https://stackoverflow.com/questions/72543208/how-to-use-mailkit-with-google-after-may-30-2022
            //
            if (_emailSettings != null)
            {
                SecureSocketOptions _ssl = SecureSocketOptions.None;
                if (_emailSettings.IMapEnableSsl == true)
                {
                    _ssl = SecureSocketOptions.Auto;
                }
                try
                {
                    client.Connect(_emailSettings.IMapHost, _emailSettings.IMapPort, _ssl);
                    client.Authenticate(_emailSettings.UserEmail, _emailSettings.Password);
                    return true;
                }
                catch (Exception _ex)
                {
                    Console.WriteLine(_ex.Message);
                    throw;
                }
            }
            else
            {
                var _msg = "NSG_IMap: emailSettings is null.";
                Console.WriteLine(_msg);
                throw new Exception(_msg);
            }
            return false;
        }
        //
        /// <summary>
        /// Get all server's folders.
        /// Code based upon the follwing:
        /// https://www.youtube.com/watch?v=qsKJUDyj0uE
        ///   INBOX
        ///   Personal
        ///   Receipts
        ///   Travel
        ///   Work
        ///   [Gmail]
        ///   [Gmail]/All Mail
        ///   [Gmail]/Drafts
        ///   [Gmail]/Important
        ///   [Gmail]/Sent Mail
        ///   [Gmail]/Spam
        ///   [Gmail]/Starred
        ///   [Gmail]/Trash
        ///   philhuhn@yahoo.com
        /// </summary>
        /// <returns>List of strings</returns>
        async public Task<List<string>> RetrieveFolders()
        {
            var _list = new List<string>();
            using (var _client = new ImapClient())
            {
                if (imap_Authenticate(_client))
                {
                    // get all folders ...
                    try
                    {
                        var _folders = await _client.GetFoldersAsync(new FolderNamespace('.', ""));
                        foreach (var _item in _folders)
                        {
                            _list.Add(_item.FullName);
                        }
                    }
                    catch (Exception _ex)
                    {
                        Console.WriteLine(_ex.Message);
                        throw;
                    }
                }
                _client.Disconnect(true);
                _client.Dispose();
            }
            return (_list);
        }
        //
        /// <summary>
        /// Get all email messages for the specific mailbox folder.
        /// </summary>
        /// <param name="mailBoxFolder"></param>
        /// <returns></returns>
        async public Task<List<EmailData>> RetrieveMessages(string mailBoxFolder)
        {
            List<EmailData> _list = new List<EmailData>();
            using (var _client = new ImapClient())
            {
                if (imap_Authenticate(_client))
                {
                    // get a folder ...
                    try
                    {
                        var _folder = await _client.GetFolderAsync(mailBoxFolder);
                        await _folder.OpenAsync(FolderAccess.ReadOnly);
                        foreach (var _item in _folder)
                        {
                            _list.Add(new EmailData(_item));
                        }
                    }
                    catch (Exception _ex)
                    {
                        Console.WriteLine(_ex.Message);
                        throw;
                    }
                }
                _client.Disconnect(true);
                _client.Dispose();
            }
            return (_list);
        }
        //
        /// <summary>
        /// Internal method, assuming opened folder
        /// </summary>
        /// <param name="folder"></param>
        /// <param name="uniqueId"></param>
        /// <returns>EmailData</returns>
        private EmailData GetEmailDataWithUniqueId(IMailFolder folder, UniqueId uniqueId)
        {
            MimeMessage _mimeMessage = folder.GetMessage(uniqueId);
            return new EmailData(_mimeMessage, uniqueId.ToString());
        }
        //
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mailBoxFolder"></param>
        /// <param name="afterDate"></param>
        /// <returns></returns>
        async public Task<List<EmailData>> RetrieveMessagesAfter(string mailBoxFolder, DateTime afterDate)
        {
            List<EmailData> _list = new List<EmailData>();
            using (var _client = new ImapClient())
            {
                if (imap_Authenticate(_client))
                {
                    try
                    {
                        // get specific folder ...
                        IMailFolder _folder = await _client.GetFolderAsync(mailBoxFolder);
                        await _folder.OpenAsync(FolderAccess.ReadOnly);
                        DateSearchQuery _query = SearchQuery.DeliveredAfter(afterDate);
                        foreach (UniqueId _uid in _folder.Search(_query))
                        {
                            _list.Add(GetEmailDataWithUniqueId(_folder, _uid));
                        }
                    }
                    catch (Exception _ex)
                    {
                        Console.WriteLine(_ex.Message);
                        throw;
                    }
                }
                _client.Disconnect(true);
                _client.Dispose();
            }
            return (_list);
        }
        //
        /// <summary>
        /// Get a single MimeMessage via message id
        /// </summary>
        /// <param name="mailBoxFolder"></param>
        /// <param name="messageId"></param>
        /// <returns></returns>
        public async Task<MimeMessage> GetMessage(string mailBoxFolder, string messageId)
        {
            MimeMessage _message;
            using (var _client = new ImapClient())
            {
                imap_Authenticate(_client);
                try
                {
                    // get specific folder ...
                    var _folder = await _client.GetFolderAsync(mailBoxFolder);
                    await _folder.OpenAsync(FolderAccess.ReadOnly);
                    _message = _folder.First(m => m.MessageId == messageId);
                }
                catch (Exception _ex)
                {
                    Console.WriteLine(_ex.Message);
                    throw;
                }
                _client.Disconnect(true);
                _client.Dispose();
            }
            return (_message);
        }
        //
        /// <summary>
        /// Get a single EmailData via unique id
        /// </summary>
        /// <param name="mailBoxFolder"></param>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        public async Task<EmailData> GetEmailData(string mailBoxFolder, UniqueId uniqueId)
        {
            EmailData _message;
            using (var _client = new ImapClient())
            {
                imap_Authenticate(_client);
                try
                {
                    // get specific folder ...
                    var _folder = await _client.GetFolderAsync(mailBoxFolder);
                    await _folder.OpenAsync(FolderAccess.ReadOnly);
                    _message = GetEmailDataWithUniqueId(_folder, uniqueId);
                }
                catch (Exception _ex)
                {
                    Console.WriteLine(_ex.Message);
                    throw;
                }
                _client.Disconnect(true);
                _client.Dispose();
            }
            return (_message);
        }
        //
    }
}
// ---------------------------------------------------------------------------
