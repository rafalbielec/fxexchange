using Exchange.Engine.Models;

namespace Exchange.Engine.Abstractions;

public interface ICurrencyPairParser
{
    CurrencyPair ParsePairName(string name);
}