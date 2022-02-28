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

            if (listJourney.Any())            {

                JourneyDB = listJourney.First();

                var jFlights = DBContext.JourneyFlights.Where(x => x.IdJourney == JourneyDB.IdJourney).ToList();

                JourneyDB.JourneyFlights = jFlights;

            }

            return JourneyDB;
        }

        public int SaveJourney(string myJourney)
        {
            var JourneyDz = JsonConvert.DeserializeObject<JourneyModel>(myJourney);

            int iResult = 0;
            var iJourney = new Journey();

            iJourney.IdJourney   = JourneyDz.IdJourney;
            iJourney.Origin      = JourneyDz.Origin;
            iJourney.Destination = JourneyDz.Destination;
            iJourney.Price       = JourneyDz.Price;
            

            try
            {
                DBContext.Journeys.Add(iJourney);

                DBContext.SaveChanges();

                iResult = iJourney.IdJourney;

                foreach (FlightfromAPIModel f in JourneyDz.JourneyFlights)
                {
                    SaveJourneyFlights(f, iResult);
                }


            }
            catch
            {
                SystemException myExp = new SystemException();
            }

            return iResult;
        }

        public int SaveJourneyFlights(FlightfromAPIModel myFlight, int idJourney)
        {
            int iResult = 0;

            var iFlight = new JourneyFlight();

            iFlight.IdFlight         = System.Convert.ToInt32(myFlight.flightNumber);
            iFlight.IdJourney        = idJourney;
            iFlight.IdJourneyFlights = 0;
            

            try
            {
                DBContext.JourneyFlights.Add(iFlight);
                iResult = DBContext.SaveChanges();


            }
            catch
            {
                SystemException myExp = new SystemException();
            }

            return iResult;
        }
    }
}
