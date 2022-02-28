using Business_Logic_Layer.Models;
using System;
using System.Runtime.Serialization;
using NewShoreAPI.Entities;
using Newtonsoft.Json;

namespace Business_Logic_Layer
{
    public class NewShoreBL
    {
        private Data_Access_Layer.NewShoreDAL newShoreDALL;

        public NewShoreBL()

        {
            newShoreDALL = new Data_Access_Layer.NewShoreDAL();
        }
        public string GetAllFlights()
        {
            string myString = newShoreDALL.GetAllFlights();
            return myString;
        }

        public string GetFlightsByID()
        {
            return "8009";
        }

        public JourneyModel GetJourneyByRoute(string Dept, string Arrv)
        {
            Journey JourneyDB = newShoreDALL.GetJourneyByRoute( Dept,  Arrv);

            JourneyModel journeyModelResult = new JourneyModel();

            return journeyModelResult;
        }

        public int SaveJourney(JourneyModel myJourney)
        {
            string JSONresult = JsonConvert.SerializeObject(myJourney);

            int iResult = newShoreDALL.SaveJourney(JSONresult);
            
            return iResult;
        }

    }
}
