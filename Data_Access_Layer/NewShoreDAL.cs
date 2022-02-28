using Data_Access_Layer.Models;
using NewShoreAPI.Entities;
using Newtonsoft.Json;
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

        public int SaveJourney(string myJourney)
        {
            var JourneyDz = JsonConvert.DeserializeObject<JourneyModel>(myJourney);
            int iResult = 1;
            return iResult;
        }

        }
}
