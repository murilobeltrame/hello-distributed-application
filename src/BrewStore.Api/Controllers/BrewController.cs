using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BrewStore.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BrewController: ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromQuery]string brand)
        {
            return Ok();
        }
    }
}