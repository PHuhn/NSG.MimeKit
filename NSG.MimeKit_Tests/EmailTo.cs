// ===========================================================================
using System;
//
namespace NSG.MimeKit_Tests
{
    //
    /// <summary>
    /// An account information for sending to.
    /// Example secrets.json data:
    ///  {
    ///   "EmailSettings": {
    ///   ...
    ///   },
    ///   "gmail": {
    ///     "UserName": "Phil (gmail)",
    ///     "UserEmail": "Phil@gmail.com"
    ///   },
    ///   "yahoo": {
    ///     "UserName": "Phil (Yahoo)",
    ///     "UserEmail": "Phil@yahoo.com"
    ///   }
    ///  }
    /// </summary>
    public class EmailTo
    {
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
    }
}
// ===========================================================================
