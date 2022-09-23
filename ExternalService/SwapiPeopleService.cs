using ChuckSwapi.Model;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ExternalService
{
    public static class SwapiPeopleService
    {
        public static PeopleResponse GetStarWarzPeople(IConfiguration config)
        {
            var client = new RestClient(config.GetValue<string>("ChuckSwapi:SwapiUrl"));

            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = JsonConvert.DeserializeObject<PeopleResponse>(response.Content);
                return result;
            }
            else
            {
                throw new Exception(response.Content);
            }
        }

        public static SwapiSearchResponse SearchStarWarzPeople(IConfiguration config, string param)
        {
            var client = new RestClient(String.Format(config.GetValue<string>("ChuckSwapi:SearchSwapi"), param));

            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = JsonConvert.DeserializeObject<SwapiSearchResponse>(response.Content);
                return result;
            }
            else
            {
                throw new Exception(response.Content);
            }
        }
    }
}


