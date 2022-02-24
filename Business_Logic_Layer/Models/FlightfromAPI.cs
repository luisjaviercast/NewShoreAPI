﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Logic_Layer.Models
{
    public class FlightfromAPI
    {
        public string  flightNumber { get; set; }
        public string  flightCarrier { get; set; }
        public string  departureStation { get; set; }
        public string  arrivalStation { get; set; }
        public double? price { get; set; }
    }
}
