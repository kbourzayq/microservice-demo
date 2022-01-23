using Microsoft.AspNetCore.Mvc;

namespace CommandsService.Controllers
{
    [Route("api/cmd/[controller]")]
    [ApiController]
    public class PlatformsController:ControllerBase
    {
        public PlatformsController()
        {
            
        }
        [HttpPost]
        public ActionResult TestInboundConnection()
        {
            System.Console.WriteLine("---> Inbound POST...");
            return Ok("Inbound test done !");
        }
    }
}