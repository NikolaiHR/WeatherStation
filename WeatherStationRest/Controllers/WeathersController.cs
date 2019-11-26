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
        List<Forecast> _forecasts = new List<Forecast>()
        {
            new Forecast(67.66, 454.435, 44.69),
            new Forecast(4, 5, 6)
        };

        [HttpGet]
        [Route("Current")]
        public Forecast CurrentWeather()
        {
            return _forecasts[_forecasts.Count - 1];
        }

        // GET: api/Weathers
        [HttpGet]
        public IEnumerable<Forecast> Get()
        {
            return _forecasts;
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
            _forecasts.Add(forecast);
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
