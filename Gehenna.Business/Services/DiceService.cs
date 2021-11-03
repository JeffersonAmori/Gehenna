using AutoMapper;
using Dice;
using Gehenna.Interfaces.Services;
using Gehenna.Models;

namespace Gehenna.Business.Services
{
    public class DiceService : IDiceService
    {
        private readonly IMapper _mapper;

        public DiceService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public GehennaRollResult Roll(string diceExpression)
        {
            return _mapper.Map<GehennaRollResult>(
                Roller.Roll(diceExpression));
        }
    }
}