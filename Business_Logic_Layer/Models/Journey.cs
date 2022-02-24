using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Logic_Layer.Models
{
    class Journey
    {
        public int IdJourney { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public double? Price { get; set; }
    }
}
