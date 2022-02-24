using NewShoreAPI.Entities;
using System;

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

    }
}
