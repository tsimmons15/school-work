using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace TranslationProject
{
    //Sets up a data contract, which will mediate the exchange with the server
    [DataContract]
    public class AdmAccessToken
    {
        //The actual "token" member
        [DataMember]
        public string access_token { get; set; }
        //The token type
        [DataMember]
        public string token_type { get; set; }
        //When the token expires
        [DataMember]
        public string expires_in { get; set; }
        //The token's scope
        [DataMember]
        public string scope { get; set; }
    }
}
