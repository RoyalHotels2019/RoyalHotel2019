using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using HotelLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestTempProvider.DBUtil;

namespace RestTempProvider.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TempSensorController : ControllerBase
    {
        TempSensorManager manager = new TempSensorManager();


        // POST: api/TempSensor
        [HttpPost]
        public bool Post([FromBody] TemperaturData data)
        {
            return manager.Post(data);
        }

    }
}
