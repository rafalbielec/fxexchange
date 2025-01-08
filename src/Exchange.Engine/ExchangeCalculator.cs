using Exchange.Engine.Abstractions;
using Exchange.Engine.Models;

namespace Exchange.Engine;

internal sealed class ExchangeCalculator : IExchangeCalculator
{
    public decimal CalculateConversionRate(decimal amount, CurrencyPair pair, ExchangeRates rates)
    {
        if (pair.SourceCurrency == pair.TargetCurrency)
            return amount;

        const decimal multiplier = 100.0M;

        if (pair.SourceCurrency == rates.BaseCurrency)
        {
            var conversionRate = rates.Rates[pair.TargetCurrency];
            return amount / conversionRate * multiplier;
        }

        if (pair.TargetCurrency == rates.BaseCurrency)
        {
            var conversionRate = rates.Rates[pair.SourceCurrency];
            return amount * conversionRate / multiplier;
        }

        var firstPerBaseCurrency = rates.Rates[pair.SourceCurrency];
        var secondPerBaseCurrency = rates.Rates[pair.TargetCurrency];

        return amount * firstPerBaseCurrency / secondPerBaseCurrency;
    }
}