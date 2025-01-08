using Exchange.Engine.Models;

namespace Exchange.Engine.Errors;

[Serializable]
public class UnsupportedCurrencyException(Currency name)
    : Exception($"Currency {name} is not configured in the config file.")
{
}