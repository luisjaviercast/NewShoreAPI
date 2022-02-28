using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Access_Layer.Models
{
    public class FlightfromAPIModel
    {
        public string  flightNumber { get; set; }
        public string  flightCarrier { get; set; }
        public string  departureStation { get; set; }
        public string  arrivalStation { get; set; }
        public double? price { get; set; }
    }
}
