using Exchange.Engine.Models;

namespace Exchange.Engine.Abstractions;

public interface IExchangeCalculator
{
    /// <summary>
    ///     Converts the provided amount into the target currency configured in the <see cref="CurrencyPair"/> instance.
    /// </summary>
    /// <param name="amount">Monetary amount like 299.99M</param>
    /// <param name="pair">Source and target currency</param>
    /// <param name="rates">Exchange rates against base currency</param>
    /// <returns>Converted amount in the target currency</returns>
    decimal CalculateConversionRate(decimal amount, CurrencyPair pair, ExchangeRates rates);
}