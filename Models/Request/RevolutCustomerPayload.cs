using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livesoft.Revolut.Models.Request
{
    public class RevolutCustomerPayload
    {
        [JsonProperty("full_name")]
        public string FullName { get; set; }

        [JsonProperty("business_name")]
        public string BusinessName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

    }
}
