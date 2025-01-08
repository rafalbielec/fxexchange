namespace Exchange;

internal sealed class CommandLineParser
{
    public bool CorrectParameters { get; private set; }
    public string CurrencyPair { get; private set; } = string.Empty;
    public decimal CurrencyAmount { get; private set; }

    public CommandLineParser(string[] commandLineArgs)
    {
        if (commandLineArgs is not null && commandLineArgs.Length == 2)
        {
            CurrencyPair = commandLineArgs[0];

            var correct = decimal.TryParse(commandLineArgs[1], out var amount);
            if (correct)
            {
                CurrencyAmount = amount;
                CorrectParameters = !string.IsNullOrEmpty(CurrencyPair);
            }
        }
    }
}