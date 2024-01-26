using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAirFreight.Models
{
    internal class Order
    {
        public string Id { get; set; }
        public Airport Destination { get; set; }
        public bool Scheduled { get; set; }
    }
}
