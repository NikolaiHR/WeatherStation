using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLib;

namespace WeatherStationRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeathersController : ControllerBase
    {
        List<Forecast> _forecast = new List<Forecast>();

        //[HttpGet]
        //[Route("CurrentWeather")]
        //public Forecast CurrentWeather()
        //{

        //}

        // GET: api/Weathers
        [HttpGet]
        public IEnumerable<Forecast> Get()
        {
            return _forecast;
        }

        // GET: api/Weathers/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Weathers
        [HttpPost]
        public void Post([FromBody] Forecast forecast)
        {
            _forecast.Add(forecast);
        }

        // PUT: api/Weathers/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string forecast)
        //{

        //}

        // DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
