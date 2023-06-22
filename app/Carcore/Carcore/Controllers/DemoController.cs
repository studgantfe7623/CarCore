using Microsoft.AspNetCore.Mvc;

namespace Carcore.Controllers
{
    [ApiController]
    [Route("demo")]
    public class DemoController : Controller
    {
        [HttpGet]
        public String Get()
        {
            return "Welcome to the Docker World!";
        }
    }
}
