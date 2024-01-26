using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MyAirFreight.Program;

namespace MyAirFreight.Models
{
    internal class Flight
    {
        public int Id {  get; set; }
        public Airport Departure { get; set; }
        public Airport Arrival { get; set; }
        public int Day {  get; set; }
        public int Capability { get; set; }
    }
}
