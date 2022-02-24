using System;
using System.Collections.Generic;

#nullable disable

namespace NewShoreAPI.Entities
{
    public partial class Flight
    {
        public int IdFlight { get; set; }
        public int IdTransport { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public double? Price { get; set; }

        public virtual Transport IdTransportNavigation { get; set; }
    }
}
