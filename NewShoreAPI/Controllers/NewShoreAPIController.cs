using Business_Logic_Layer;
using Business_Logic_Layer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace NewShoreAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewShoreAPIController : ControllerBase
    {
        private Business_Logic_Layer.NewShoreBL newShoreBLL;

        private readonly ILogger<NewShoreAPIController> _logger;

        //Constructor
        public NewShoreAPIController(ILogger<NewShoreAPIController> logger)
        {
            _logger = logger;
            newShoreBLL = new Business_Logic_Layer.NewShoreBL();
        }

        [HttpGet]
        [Route("GetAllFlights")]
        public string GetAllFlights()
        {
            string myString = newShoreBLL.GetAllFlights();
            return myString;
        }

        [HttpGet]
        [Route("connectAPIFlights")]
        public async Task<string> connectAPIFlights(string Dept, string Arrv)
        {
            NewShoreServices APIService = new NewShoreServices();

            string jResult    = "";
            string JSONresult = "";

            try
            {
                jResult = await APIService.ConsumeAPIFlights();
            }
            catch (WebException Ex)
            {
                throw new System.Web.Http.HttpResponseException(HttpStatusCode.NotFound);
            }            

            var List = JsonConvert.DeserializeObject<List<FlightfromAPIModel>>(jResult);

            List<FlightfromAPIModel> flightList = List.ToList();

            //CHECK IF JOURNEY EXISTS

            JourneyModel myJourney = GetJourneyByRoute(Dept, Arrv);

            // START JOURNEY            
            if (myJourney.IdJourney == 0)
            {
                List<FlightfromAPIModel> flightListOutPut = CalcPathRecursive(flightList, Dept, Arrv);

                myJourney.Origin         = Dept;
                myJourney.Destination    = Arrv;
                myJourney.Price          = flightListOutPut[0].price + flightListOutPut[1].price;
                myJourney.JourneyFlights = flightListOutPut;

                // SERIALIZE TO JSON 
                
                JSONresult = JsonConvert.SerializeObject(myJourney);

                //SAVE JOURNEY TO DB

                int iIdJourney = newShoreBLL.SaveJourney(myJourney);

            }
            else {

                // MAP FROM DB
                 JSONresult = JsonConvert.SerializeObject(myJourney);
            }
            // END JOURNEY

            return JSONresult;

        }

        [HttpGet]
        [Route("GetFlightsByID")]
        public string GetFlightsByID()
        {
            return "8009";
        }
        private List<FlightfromAPIModel> CalcPathRecursive(List<FlightfromAPIModel> flightList, string Dept, string Arrv)
        {
            FlightfromAPIModel DepartureFlight = new FlightfromAPIModel();
            FlightfromAPIModel ArrivalFlight = new FlightfromAPIModel();
            List<FlightfromAPIModel> flightListResult = new List<FlightfromAPIModel>();

            var startFlights = flightList.Where(x => x.departureStation == Dept);

            foreach (var v in startFlights)
            {
                var endFlight = flightList.Where(x => x.departureStation == v.arrivalStation && x.arrivalStation == Arrv);

                if (endFlight.Count() !=0)
                {
                    DepartureFlight = v;
                    ArrivalFlight = endFlight.FirstOrDefault();
                }
            }

            flightListResult.Add(DepartureFlight);

            flightListResult.Add(ArrivalFlight);

            return flightListResult; 

        }

        public JourneyModel GetJourneyByRoute(string Dept, string Arrv)
        {
            JourneyModel bExists = newShoreBLL.GetJourneyByRoute(Dept, Arrv);

            return bExists;

        }




    }
}
