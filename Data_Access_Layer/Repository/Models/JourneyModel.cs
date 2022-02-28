using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Access_Layer.Models
{
    public class JourneyModel
    {
        public int IdJourney { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public double? Price { get; set; }
        public virtual ICollection<FlightfromAPIModel> JourneyFlights { get; set; }
    }
}
