using System;
using System.Web.Http;

namespace dotnet_windows_app.Controllers
{
    public class HomeController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(new
            {
                message = "Hello World from .NET Framework on Windows Cloud Foundry!",
                timestamp = DateTime.UtcNow,
                platform = Environment.OSVersion.ToString()
            });
        }

        [HttpGet]
        [Route("health")]
        public IHttpActionResult Health()
        {
            return Ok(new { status = "healthy" });
        }
    }
}

