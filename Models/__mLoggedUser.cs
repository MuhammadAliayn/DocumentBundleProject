using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InPlace4.Models
{
    class __mLoggedUser
    {
        public string ClientHost { get; set; }
        public string PK_UserEmail { get; set; }
        public string SessionId { get; set; }
        public string UserCompany { get; set; }
        public string Site { get; set; }
        public string Role { get; set; }
        public string JwtToken { get; set; }
        public string JwtStartSession { get; set; }
        public string JwtEndSession { get; set; }
        public string JwtExpiryTimeInMinutes { get; set; }
        public string AlfrescoToken { get; set; }
        public string JsonPostParams { get; set; }
    }
}