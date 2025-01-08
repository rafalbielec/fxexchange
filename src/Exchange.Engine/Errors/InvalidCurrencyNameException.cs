namespace Exchange.Engine.Errors;

[Serializable]
public class InvalidCurrencyNameException(string name)
    : Exception($"Invalid currency name provided: {name}.")
{
}

