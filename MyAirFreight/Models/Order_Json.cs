using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MyAirFreight.Models
{
    internal class Order_Json
    {
        [JsonProperty("order")]
        internal Dictionary<string, Airport_Json> Order { get; set; }
    }
}
