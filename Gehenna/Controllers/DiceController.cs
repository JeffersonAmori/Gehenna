using Antlr4.Runtime;
using AutoMapper;
using Dice;
using Gehenna.Interfaces.Services;
using GehennaApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GehennaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiceController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDiceService _diceService;

        public DiceController(IMapper mapper, IDiceService diceService)
        {
            _mapper = mapper;
            _diceService = diceService;
        }

        // GET api/<ValuesController>/1d6
        [HttpGet("{diceExpression}")]
        public ActionResult<GehennaRollResult> Get(string diceExpression)
        {
            try
            {
                return Ok(
                    _mapper.Map<GehennaRollResult>(
                        _diceService.Roll(diceExpression)));
            }
            catch (DiceException diceException)
            {
                if (diceException.InnerException.GetType() == typeof(LexerNoViableAltException) ||
                    diceException.InnerException.GetType() == typeof(InputMismatchException))
                    return BadRequest();

                throw;
            }
        }
    }
}
