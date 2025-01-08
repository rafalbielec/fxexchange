using Exchange.Engine.Abstractions;
using Exchange.Engine.Errors;

namespace Exchange.Engine;

internal sealed class ExchangeEngine(ICurrencyPairParser pairParser,
        IExchangeRatesProvider configParser,
        IExchangeCalculator calculator) : IExchangeEngine
{
    private readonly ICurrencyPairParser pairParser = pairParser;
    private readonly IExchangeRatesProvider configParser = configParser;
    private readonly IExchangeCalculator calculator = calculator;

    public decimal ConvertAmount(string pairName, decimal amount)
    {
        var rates = configParser.GetExchangeRates();
        var baseCurrency = rates.BaseCurrency;

        var pair = pairParser.ParsePairName(pairName);
        if (pair.SourceCurrency != baseCurrency && !rates.Rates.ContainsKey(pair.SourceCurrency))
        {
            throw new UnsupportedCurrencyException(pair.SourceCurrency);
        }

        if (pair.TargetCurrency != baseCurrency && !rates.Rates.ContainsKey(pair.TargetCurrency))
        {
            throw new UnsupportedCurrencyException(pair.TargetCurrency);
        }

        return calculator.CalculateConversionRate(amount, pair, rates);
    }
}