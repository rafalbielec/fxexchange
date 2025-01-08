namespace Exchange.Engine.Errors;

[Serializable]
public class InvalidCurrencyPairException(string pairName)
    : Exception($"Invalid format provided: {pairName}. Please provide currencies as ISO/ISO.")
{
}