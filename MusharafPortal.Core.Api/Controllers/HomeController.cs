using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Musharaf.Portal.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get() =>
            Ok("Hi Zam");
    }
}
