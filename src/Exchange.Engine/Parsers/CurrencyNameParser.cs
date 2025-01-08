using Exchange.Engine.Abstractions;
using Exchange.Engine.Errors;
using Exchange.Engine.Models;

namespace Exchange.Engine.Parsers;

internal sealed class CurrencyNameParser : ICurrencyNameParser
{
    public Currency ParseName(string name)
    {
        var result = Enum.TryParse<Currency>(name,
                true, out var currency);

        if (result)
            return currency;

        throw new InvalidCurrencyNameException(name);
    }
}