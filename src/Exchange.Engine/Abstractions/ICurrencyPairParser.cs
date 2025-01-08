using Exchange.Engine.Errors;
using Exchange.Engine.Models;

namespace Exchange.Engine.Abstractions;

public interface ICurrencyPairParser
{
    /// <summary>
    ///     Parse currency names in the following format "CUR/CUR".
    ///     Throws an <see cref="InvalidCurrencyPairException"/> if the format is invalid.
    /// </summary>
    /// <param name="name">For example DKK/EUR</param>
    CurrencyPair ParsePairName(string name);
}