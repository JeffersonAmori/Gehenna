using Dice;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gehenna.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiceController : ControllerBase
    {
        // GET api/<ValuesController>/5
        [HttpGet("{s}")]
        public object Get(string s)
        {
            return JsonConvert.SerializeObject(Roller.Roll(s));
        }
    }
}
