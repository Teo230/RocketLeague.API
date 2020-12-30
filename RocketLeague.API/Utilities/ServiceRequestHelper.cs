using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace RocketLeague.API.Utilities
{
    public class ServiceRequestHelper
    {
        private int requestIdCounter;
        private int serviceIdCounter;
        public ServiceRequestHelper()
        {
            requestIdCounter = 0; // Starts at 0, increments for every request and response.
            serviceIdCounter = 1; // Starts at 1, increments for every service.
        }

        //public async void RLGet(string request, string content)
        //{
        //}

        public HttpContent RLPost(dynamic content)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept
                                                .Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                httpClient.DefaultRequestHeaders.Add("User-Agent", Costants.RLUserAgent);
                httpClient.DefaultRequestHeaders.Add("PsyBuildIDt", Costants.RLBuildId);
                httpClient.DefaultRequestHeaders.Add("PsyEnvironment", Costants.RLEnvironment);
                httpClient.DefaultRequestHeaders.Add("PsyRequestID", "PsyNetMessage_X_" + requestIdCounter.ToString());
                httpClient.DefaultRequestHeaders.Add("PsySig", Costants.RLKey);
                var response = httpClient.PostAsync(Costants.RLEndpoint, new StringContent(content.ToString(), Encoding.UTF8,
                            "application/json"))?.Result;

                var responseString = response.Content.ReadAsStringAsync();
                return response.Content;
            }
        }
    }
}
