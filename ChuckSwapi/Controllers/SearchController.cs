using ChuckSwapi.Core.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ChuckSwapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearch _search;

        public SearchController(ISearch search)
        {
            _search = search;
        }

        [HttpGet("[action]/{searchParam}")]
        public async Task<IActionResult> Search(string searchParam)
        {
            var response = await _search.Search(searchParam);
            return Ok(response);
        }
    }
}
