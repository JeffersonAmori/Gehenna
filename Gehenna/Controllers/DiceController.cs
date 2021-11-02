﻿using Antlr4.Runtime;
using AutoMapper;
using Dice;
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

        public DiceController(IMapper mapper)
        {
            _mapper = mapper;
        }

        // GET api/<ValuesController>/1d6
        [HttpGet("{s}")]
        public ActionResult<GehennaRollResult> Get(string s)
        {
            try
            {
                return _mapper.Map<GehennaRollResult>(Roller.Roll(s));
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
