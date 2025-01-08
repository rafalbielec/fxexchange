using Exchange.Engine.Errors;
using Exchange.Engine.Models;

namespace Exchange.Engine.Abstractions;

public interface ICurrencyNameParser
{
    /// <summary>
    ///     Parses the name of the currency and returns its enum equivalent
    ///     or throws an <see cref="InvalidCurrencyNameException"/> if the name is not found.
    /// </summary>
    /// <param name="name">Name like EUR</param>
    Currency ParseName(string name);
}