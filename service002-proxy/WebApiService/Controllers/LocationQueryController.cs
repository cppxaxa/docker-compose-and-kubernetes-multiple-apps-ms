using LocationQueryLib;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationQueryController : ControllerBase
    {
        private readonly IConfiguration configuration;
        public LocationQueryController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // GET: api/<ValuesController>
        [HttpGet("examples")]
        public ILocationQueryExamples GetExamples()
        {
            var client = new LocationQueryClient(
                configuration.GetSection("appSettings")["nearbyPlacesSourceHost"].ToString(),
                configuration.GetSection("appSettings")["nearbyPlacesSourcePort"].ToString()
                );
            return client.GetExamples();
        }

        // GET api/<ValuesController>?lat=20.1&lon=73.1&miles=2
        [HttpGet()]
        public ILocationQueryResponse Get(double lat, double lon, int miles)
        {
            var client = new LocationQueryClient(
                configuration.GetSection("appSettings")["nearbyPlacesSourceHost"].ToString(),
                configuration.GetSection("appSettings")["nearbyPlacesSourcePort"].ToString()
                );
            return client.Query(new LocationQueryRequest
            {
                Lat = lat,
                Lon = lon,
                Miles = miles
            });
        }
    }
}
