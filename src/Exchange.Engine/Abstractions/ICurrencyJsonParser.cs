using Exchange.Engine.Models;

namespace Exchange.Engine.Abstractions;

public interface ICurrencyJsonParser
{
    /// <summary>
    ///     Parsers the configuration file JSON content and returns an <see cref="ExchangeRates"/> instance.
    /// </summary>
    /// <param name="json">Configuration JSON content</param>
    ExchangeRates ParseJson(string json);
}