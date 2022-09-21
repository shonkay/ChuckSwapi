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
    public class CategoryBusiness : ICategory
    {
        private readonly IConfiguration _config;
        private readonly IHttpClientFactory _clientFactory;

        public CategoryBusiness(IConfiguration config, IHttpClientFactory clientFactory )
        {
            _config = config;
            _clientFactory = clientFactory;
        }

        public async Task<ResponseModel> GetAllCategories()
        {
            var response = await ChuckCategoriesService.GetAllCategories(_config, _clientFactory);
            if (response.Count() == 0)
                return new ResponseModel
                {
                    ResponseCode = HttpStatusCode.NoContent,
                    ResponseData = null,
                    ResponseMessage = "No Data Found"
                };
            var categories = new List<Category>();
            int CatId = 0;
            foreach(var category in response)
            {
                CatId++;
                var entity = new Category
                {
                    CategoryName = category,
                    DateCreated = DateTime.Now.ToString(),
                    Id = CatId,
                    Status = "Created"
                };
                categories.Add(entity);
            }
            return new ResponseModel
            {
                ResponseCode = HttpStatusCode.OK,
                ResponseData = categories,
                ResponseMessage = "Success"
            };
        }
    }
}
