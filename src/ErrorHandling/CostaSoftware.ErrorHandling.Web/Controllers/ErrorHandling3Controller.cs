using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CostaSoftware.ErrorHandling.Web.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CostaSoftware.ErrorHandling.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorHandling3Controller : ControllerBase
    {
        private readonly ILogger<ErrorHandling3Controller> logger;

        public ErrorHandling3Controller(ILogger<ErrorHandling3Controller> logger)
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
            throw new SomeException("An error occurred...");
        }
    }
}
