using System;
using System.Runtime.Serialization;

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

    }
}
