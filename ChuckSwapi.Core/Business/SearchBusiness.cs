using ChuckSwapi.Core.Interface;
using ChuckSwapi.Model;
using ExternalService;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ChuckSwapi.Core.Business
{
    public class SearchBusiness : ISearch
    {
        private readonly IConfiguration _config;
        private readonly IHttpClientFactory _clientFactory;

        public SearchBusiness(IConfiguration config, IHttpClientFactory clientFactory)
        {
            _config = config;
            _clientFactory = clientFactory;
        }

        public async Task<ResponseModel> Search(string param)
        {
            var firstService = await ChuckCategoriesService.SearchCategories(_config, _clientFactory, param);
            var secondService = SwapiPeopleService.SearchStarWarzPeople(_config, param);
            if(firstService.total != 0 && secondService.count != 0)
            {
                var searchList = new List<SearchResponse>();
                var searchResponse1 = new SearchResponse
                {
                    SearchResult = firstService,
                    Url = "https://api.chucknorris.io"
                };
                var searchResponse2 = new SearchResponse
                {
                    SearchResult = secondService,
                    Url = "https://swapi.dev/api"
                };
                searchList.Add(searchResponse1);
                searchList.Add(searchResponse2);

                return new ResponseModel
                {
                    ResponseCode = HttpStatusCode.OK,
                    ResponseData = searchList,
                    ResponseMessage = "Success"
                };
            }
            else if(firstService.total != 0)
            {
                var searchResponse = new SearchResponse
                {
                    SearchResult = firstService,
                    Url = "https://api.chucknorris.io"
                };
                return new ResponseModel
                {
                    ResponseCode = HttpStatusCode.OK,
                    ResponseData = searchResponse,
                    ResponseMessage = "Success"
                };
            }  
            else if(secondService.count != 0)
            {
                var searchResponse = new SearchResponse
                {
                    SearchResult = secondService,
                    Url = "https://swapi.dev/api"
                };
                return new ResponseModel
                {
                    ResponseCode = HttpStatusCode.OK,
                    ResponseData = searchResponse,
                    ResponseMessage = "Success"
                };
            }
            else
            {
                return new ResponseModel
                {
                    ResponseCode = HttpStatusCode.NoContent,
                    ResponseData = null,
                    ResponseMessage = "No Content Found"
                };
            }
        }
    }
}
