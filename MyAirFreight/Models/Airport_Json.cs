using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MyAirFreight.Models
{
    internal class Airport_Json
    {
        [JsonProperty("destination")]
        internal string Destination {  get; set; }
    }
}
