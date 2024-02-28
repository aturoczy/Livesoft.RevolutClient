using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livesoft.RevolutClient.Models.Response
{
    public class RevolutBillingAddress
    {
        [JsonProperty("street_line_1")]
        public string Street1 { get; set; }

        [JsonProperty("street_line_2")]
        public string Street2 { get; set; }

        [JsonProperty("post_code")]
        public string PostCode { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; set; }
    }
}
