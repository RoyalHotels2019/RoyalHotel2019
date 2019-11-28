using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestTempProvider.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TempSensorController : ControllerBase
    {


        private static List<Temperaturmaaling> templist = new List<Temperaturmaaling>()
        {
            //new Temperaturmaaling;
        };
            
        // GET: api/TempSensor
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/TempSensor/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TempSensor
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/TempSensor/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
