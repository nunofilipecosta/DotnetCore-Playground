using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CostaSoftware.ErrorHandling.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorHandling2Controller : ControllerBase
    {
        private readonly ILogger<ErrorHandling2Controller> logger;

        public ErrorHandling2Controller(ILogger<ErrorHandling2Controller> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var data = GetData();
            return Ok(data);

        }

        private object GetData()
        {
            throw new Exception("An error occurred...");
        }
    }
}
