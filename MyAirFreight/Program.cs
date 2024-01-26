using System;
using System.Collections.Generic;
using System.IO;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyAirFreight.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MyAirFreight
{
    internal class Program
    {
        static List<Flight> lstFlight = new List<Flight>();
        static List<Order> lstOrder = new List<Order>();

        static void Main(string[] args)
        {
            var p = new Program();
            p.LoadFlights();

            //Output Flights
            Console.WriteLine("*************** User Story #1 *******************");
            for (int i = 0; i < lstFlight.Count; i++)
            {
                Console.WriteLine("Flight:" + lstFlight[i].Id + ", Departure:" + lstFlight[i].Departure.Code + ", Arrival:" + lstFlight[i].Arrival.Code + ", Day:" + lstFlight[i].Day);

            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("*************** User Story #2 *******************");


            //Output Order Shipping
            string filepath = ConfigurationManager.AppSettings.Get("JsonFilePath");
            using (StreamReader file = new StreamReader("C:\\Project\\MyAirFreight\\coding-assigment-orders.json"))
            {
                try
                {
                    string json = file.ReadToEnd();
                    json = "{\"order\":" + json + "}"; //create correct json formaat for deserilization
                    var serializerSettings = new JsonSerializerSettings
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    };

                    Order_Json order_json =  JsonConvert.DeserializeObject<Order_Json>(json, serializerSettings) ;
                    var myorders = order_json.Order;

                    //map to order list from order_json
                    foreach (var order in myorders)
                    {
                        Order oOrder = new Order();
                        oOrder.Id = order.Key;
                        oOrder.Destination = new Airport() { Code = order.Value.Destination };
                        oOrder.Scheduled = false;
                        lstOrder.Add(oOrder);
                    }

                    //loop through order list and output order shipping info
                    foreach(var order in lstOrder)
                    {
                        foreach(var flight in lstFlight)
                        {
                            if(flight.Arrival.Code == order.Destination.Code)
                            {
                                if (flight.Capability > 0 && !order.Scheduled)
                                {
                                    flight.Capability -= 1;
                                    order.Scheduled = true;
                                    Console.WriteLine("order:" + order.Id + ", FlightNmber:" + flight.Id + ", Departure:" + flight.Departure.Code + ", Arrival:" + flight.Arrival.Code + ", Day:" + flight.Day);
                                   
                                }                              
                            }
                            
                        }
                        if(!order.Scheduled)
                        {
                            Console.WriteLine("order:" + order.Id + ", FlightNmber: not scheduled");
                        }                    

                    }
                }
                catch(Exception)
                {
                    Console.Write("Problem reading file");
                }
            }
        }

        private void LoadFlights()
        {           
            lstFlight.Add(new Flight() { Id = 1, Departure = new Airport() { Code = "YUL", Name = "Montreal" }, Arrival = new Airport() { Code = "YYZ", Name ="Toronto" }, Day = 1, Capability = 20 });
            lstFlight.Add(new Flight() { Id = 2, Departure = new Airport { Code = "YUL", Name = "Montreal" }, Arrival = new Airport { Code = "YYC", Name = "Calgary" }, Day = 1, Capability = 20 });
            lstFlight.Add(new Flight() { Id = 3, Departure = new Airport { Code = "YUL", Name = "Montreal" }, Arrival = new Airport { Code = "YVR", Name = "Vancouver" }, Day = 1, Capability = 20 });
            lstFlight.Add(new Flight() { Id = 4, Departure = new Airport { Code = "YUL", Name = "Montreal" }, Arrival = new Airport { Code = "YYZ", Name = "Toronto" }, Day = 2, Capability = 20 });
            lstFlight.Add(new Flight() { Id = 5, Departure = new Airport { Code = "YUL", Name = "Montreal" }, Arrival = new Airport { Code = "YYC", Name = "Calgary" }, Day = 2, Capability = 20 });
            lstFlight.Add(new Flight() { Id = 6, Departure = new Airport { Code = "YUL", Name = "Montreal" }, Arrival = new Airport { Code = "YVR", Name = "Vancouver" }, Day = 2, Capability = 20 });

        }

        private void OutputFlights()
        {
            for(int i=0; i<lstFlight.Count;i++ )
            {
                Console.WriteLine("Flight:" + lstFlight[i].Id + ", Departure:" + lstFlight[i].Departure.Code + ", Arrival:" + lstFlight[i].Arrival.Code + ", Day:" + lstFlight[i].Day);

            }
        }

        
    }
}
