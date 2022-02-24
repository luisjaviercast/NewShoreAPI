using System;
using System.Collections.Generic;

#nullable disable

namespace NewShoreAPI.Entities
{
    public partial class JourneyFlight
    {
        public int IdJourneyFlights { get; set; }
        public int IdJourney { get; set; }
        public int IdFlight { get; set; }

        public virtual Journey IdJourneyNavigation { get; set; }
    }
}
