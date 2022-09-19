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
    public class PeopleBusiness : IPeople
    {
        private readonly IConfiguration _config;
        private readonly IHttpClientFactory _clientfactory;

        public PeopleBusiness(IConfiguration config, IHttpClientFactory clientfactory)
        {
            _config = config;
            _clientfactory = clientfactory;
        }

        public ResponseModel GetAllStarWarzPeople()
        {
            var response = SwapiPeopleService.GetStarWarzPeople(_config);
            if (response.count == 0)
                return new ResponseModel
                {
                    ResponseCode = HttpStatusCode.NoContent,
                    ResponseData = null,
                    ResponseMessage = "No Data Found"
                };

            return new ResponseModel
            {
                ResponseCode = HttpStatusCode.OK,
                ResponseData = response,
                ResponseMessage = "Success"
            };
        }
    }
}
