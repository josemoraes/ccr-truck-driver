using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace truckapp01.Models
{
    public class SupportPoint
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }

        [JsonProperty("alert_codes_that_attends")]
        public List<int> AlertCodesThatAttends { get; set; }
    }
}
