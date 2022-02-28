using Business_Logic_Layer.Models;
using System;
using System.Net.Http;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace Business_Logic_Layer
{
    public class NewShoreServices
    {
        public async Task<string> ConsumeAPIFlights()
        {
            
            string strResponse;
           
            using (var httpClient = new HttpClient())
            {
                // API NEWSHORE LEVEL 0
                using (var response = await httpClient.GetAsync("https://recruiting-api.newshore.es/api/flights/0"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                     strResponse = apiResponse.ToString();                   
                }
            }           

            return strResponse;


        }

        
    }
}

