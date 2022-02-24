using Business_Logic_Layer;
using Business_Logic_Layer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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

            string jResult = await APIService.ConsumeAPIFlights();

            //dynamic json = JsonConvert.DeserializeObject(jResult);

            var List = JsonConvert.DeserializeObject<List<FlightfromAPI>>(jResult);

            List<FlightfromAPI> flightList = List.ToList();

            // START JOURNEY
            FlightfromAPI DepartureFlight = new FlightfromAPI();
            FlightfromAPI ArrivalFlight   = new FlightfromAPI();

            var startFlights = flightList.Where(x => x.departureStation == Dept);

            foreach (var v in startFlights)
            {
                var endFlight = flightList.Where(x => x.departureStation == v.arrivalStation && x.arrivalStation == Arrv);
                
                if (endFlight != null)
                {
                    DepartureFlight = v;
                    ArrivalFlight = endFlight.FirstOrDefault();
                }
            }

            
            // END JOURNEY

            return jResult;

        }

        [HttpGet]
        [Route("GetFlightsByID")]
        public string GetFlightsByID()
        {
            return "8009";
        }

        

       
    }
}
