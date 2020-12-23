
using System;

using System.Text;

namespace HireMe.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    public class Address
    {
        [JsonProperty(PropertyName = "candidates")]
        public List<Candidate> Candidates { get; set; }

        
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        public void method()
        {
            
        }
    }
}
