using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiService.Controllers
{
    [Route("/")]
    [ApiController]
    public class IndexController : ControllerBase
    {
        // GET api/<ValuesController>?lat=20.1&lon=73.1&miles=2
        [HttpGet()]
        public string Get()
        {
            return "try /swagger";
        }
    }
}
