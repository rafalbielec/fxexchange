using Exchange.Engine.Abstractions;
using Exchange.Engine.Errors;
using Exchange.Engine.Models;

namespace Exchange.Engine.Parsers;

internal class CurrencyPairParser(ICurrencyNameParser nameParser) : ICurrencyPairParser
{
    const char Separator = '/';
    private readonly ICurrencyNameParser nameParser = nameParser;

    public CurrencyPair ParsePairName(string pairName)
    {
        var parts = pairName.Split(Separator, StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length == 2)
        {
            var from = nameParser.ParseName(parts[0]);
            var to = nameParser.ParseName(parts[1]);

            return new CurrencyPair(from, to);
        }

        throw new InvalidCurrencyPairException(pairName);
    }
}