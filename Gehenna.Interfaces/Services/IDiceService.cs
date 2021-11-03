using Gehenna.Models;

namespace Gehenna.Interfaces.Services
{
    public interface IDiceService
    {
        GehennaRollResult Roll(string diceExpression);
    }
}