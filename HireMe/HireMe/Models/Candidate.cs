
using System;
using System.Collections.Generic;
using System.Text;

namespace HireMe.Models
{
    using Newtonsoft.Json;
    public class Candidate
    {
        
        [JsonProperty(PropertyName = "formatted_address")]
        public string Formatted_address { get; set; }
        
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
