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
    public class ErrorHandling1Controller : ControllerBase
    {
        private readonly ILogger<ErrorHandling1Controller> logger;

        public ErrorHandling1Controller(ILogger<ErrorHandling1Controller> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var data = GetData();
                return Ok(data);
            }
            catch (Exception exception)
            {
                this.logger.LogError(exception.Message);
                return StatusCode(500);
            }
        }

        private object GetData()
        {
            throw new Exception("An error occurred...");
        }
    }
}
