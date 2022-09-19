using ChuckSwapi.Core.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ChuckSwapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChuckController : ControllerBase
    {
        private readonly ICategory _category;

        public ChuckController(ICategory category)
        {
            _category = category;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Categories()
        {
            var response = await _category.GetAllCategories();
            return Ok(response);
        }
    }
}
