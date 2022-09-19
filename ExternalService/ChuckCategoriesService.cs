using ChuckSwapi.Model;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ExternalService
{
    public static class ChuckCategoriesService
    {
        public static async Task<List<string>> GetAllCategories(IConfiguration config, IHttpClientFactory clientFactory)
        {
            var resourceuri = config.GetValue<string>("ChuckSwapi:ChuckCategories");
            var client = clientFactory.CreateClient("Chucks Client");

            var response = await client.GetAsync(resourceuri);
            var decodeResponse = response.Content.ReadAsStringAsync().Result;

            if(response.StatusCode == HttpStatusCode.OK)
            {
                var result = JsonConvert.DeserializeObject<List<string>>(decodeResponse);
                return result;
            }
            else
            {
                throw new Exception(decodeResponse);
            }
        }
    }
}
