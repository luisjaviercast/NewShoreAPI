using NewShoreAPI.Entities;
using System;
using System.Linq;


namespace Data_Access_Layer
{
    public class NewShoreDAL
    {
        private NewShoreContext DBContext;

        public NewShoreDAL()
        {
            DBContext = new NewShoreContext();
        }
        public string GetAllFlights()
        {
            return "8007";
        }

        public string GetFlightsByID()
        {
            return "8009";
        }

        public Journey GetJourneyByRoute(string Dept, string Arrv)
        {
            var listJourney = DBContext.Journeys.Where(x => x.Origin == Dept && x.Destination == Arrv);

            Journey JourneyDB = new Journey();

            if (listJourney.Count() != 0) {

                JourneyDB = listJourney.First();
            }

            return JourneyDB;
        }

    }
}
