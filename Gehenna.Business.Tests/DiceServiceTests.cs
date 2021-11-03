using AutoMapper;
using Dice;
using Gehenna.Business.Services;
using Xunit;

namespace Gehenna.Business.Tests
{
    public class DiceServiceTests
    {
        private readonly DiceService _diceService;

        public DiceServiceTests()
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RollResult, Models.GehennaRollResult>();
                cfg.CreateMap<DieResult, Models.GehennaDieResult>();
            });

            var mapper = config.CreateMapper();

            _diceService = new DiceService(mapper);
        }

        [Theory]
        [InlineData("1d6", 1, 6)]
        [InlineData("2d6", 2, 12)]
        [InlineData("1d6+10", 11, 16)]
        [InlineData("1d1000", 1, 1000)]
        [InlineData("1d6+2d4", 3, 14)]
        public void TestRollsValuesInsideMinMaxRange(string diceExpression, int min, int max)
        {
            var result = _diceService.Roll(diceExpression);

            Assert.True(result.Value >= min);
            Assert.True(result.Value <= max);
        }
    }
}
