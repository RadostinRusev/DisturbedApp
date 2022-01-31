using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Messages
{
    public class ResposnseMessage
    {
        [JsonProperty(PropertyName = "code")]
        public object Code { get; set; }
        [JsonProperty(PropertyName = "Body", NullValueHandling = NullValueHandling.Ignore)]
        public object Body { get; set; }
        [JsonProperty(PropertyName = "Error", NullValueHandling = NullValueHandling.Ignore)]
        public object Error { get; set; }

    }
}