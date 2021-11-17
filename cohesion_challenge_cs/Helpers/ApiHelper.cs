﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;

namespace cohesion_challenge_cs.src.helpers
{
    public class ApiHelper
    {
        private static RestClient restClient { get; set; }
        private static IRestResponse response { get; set; }
        private static RestRequest restRequest { get; set; }

        public IRestResponse Get(string endpoint, Dictionary<string, string> queryParams, string token)
        {
            restClient = new RestClient(endpoint);
            restRequest = new RestRequest();

            if(!token.Equals(""))
            {
                restRequest.AddHeader("X-App-Token", token);
            }

            foreach(KeyValuePair<string, string> param in queryParams)
            {
                restRequest.AddParameter(param.Key, param.Value);
            }

            response = restClient.Execute(restRequest);
            Console.WriteLine(JsonConvert.SerializeObject(response.Content, Formatting.Indented));

            return response;
        }
    }
}
