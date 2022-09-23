using ChuckSwapi.Core.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ChuckSwapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SwapiController : ControllerBase
    {
        private readonly IPeople _people;

        public SwapiController(IPeople people)
        {
            _people = people;
        }

        [HttpGet("[action]")]
        public IActionResult People()
        {
            var response =  _people.GetAllStarWarzPeople();
            return Ok(response);
        }
    }
}
