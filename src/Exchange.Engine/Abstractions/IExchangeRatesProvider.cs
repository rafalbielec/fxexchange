using Exchange.Engine.Models;

namespace Exchange.Engine.Abstractions;

public interface IExchangeRatesProvider
{
    ExchangeRates GetExchangeRates();
}