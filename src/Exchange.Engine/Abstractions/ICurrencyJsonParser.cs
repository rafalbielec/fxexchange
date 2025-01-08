using Exchange.Engine.Models;

namespace Exchange.Engine.Abstractions;

public interface ICurrencyJsonParser
{
    ExchangeRates ParseJson(string json);
}