using System;

namespace Core.Utilities.Security.Jwt
{
    public class AccessToken
    {
        public string TokenKey { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
