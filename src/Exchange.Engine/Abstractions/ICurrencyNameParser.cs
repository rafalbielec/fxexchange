using Exchange.Engine.Models;

namespace Exchange.Engine.Abstractions;

public interface ICurrencyNameParser
{
    Currency ParseName(string name);
}