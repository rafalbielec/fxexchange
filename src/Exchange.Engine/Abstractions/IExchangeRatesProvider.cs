using Exchange.Engine.Models;

namespace Exchange.Engine.Abstractions;

public interface IExchangeRatesProvider
{
    /// <summary>
    ///     Provides the configured foreign exchange rates with their base currency.
    /// </summary>
    ExchangeRates GetExchangeRates();
}