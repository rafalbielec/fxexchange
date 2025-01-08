using Exchange.Engine.Models;

namespace Exchange.Engine.Abstractions;

public interface IExchangeCalculator
{
    decimal CalculateConversionRate(decimal amount, CurrencyPair pair, ExchangeRates rates);
}