using Microsoft.AspNetCore.Mvc;
using System;

namespace Rehborn.AspNetCore.Mvc.Tests
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        [HttpGet]
        public string Get()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
