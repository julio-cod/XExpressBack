using Microsoft.AspNetCore.Mvc;

namespace XExpressBack._1.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("XExpress API Running... " + DateTime.Now);
        }
    }
}
