using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.AutorizationProvider
{
    public class JWTTOken
    {
        
            public string Secret { get; set; }
            public string Issuer { get; set; }
            public string Audience { get; set; }
            public int AccessTokenExpiration { get; set; }
            public int RefreshTokenExpiration { get; set; }
    }
}