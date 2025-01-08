using System.Globalization;
using Exchange.Engine;
using Exchange.Engine.Abstractions;
using Exchange.Engine.Errors;
using IoC;

namespace Exchange;

internal static class Program
{
    private static void Main(string[] args)
    {
        // The numeric format adheres to Central Europe with the comma used as the decimal point.
        // For example, 12,99 would be used for the amount of 13.00 minus 0.01.
        var cultureInfo = new CultureInfo("pl-PL");
        CultureInfo.DefaultThreadCurrentCulture = cultureInfo;

        var parser = new CommandLineParser(args);
        if (!parser.CorrectParameters)
        {
            Console.WriteLine("Usage: Exchange <currency pair> <amount to exchange>");
            return;
        }

        using var container = Container
            .Create().Using<EngineConfiguration>();

        var engine = container.Resolve<IExchangeEngine>();

        var pair = parser.CurrencyPair;
        var amount = parser.CurrencyAmount;

        try
        {
            var converted = engine.ConvertAmount(pair, amount);
            var formattedAmount = $"{converted.ToString("N4", CultureInfo.CurrentCulture)}";

            Console.WriteLine(formattedAmount);
        }
        catch (Exception ex) when (ex is InvalidCurrencyPairException
                || ex is InvalidCurrencyNameException
                || ex is UnsupportedCurrencyException)
        {
            Console.Error.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Application error {ex.GetType().Name}: {ex.Message}");

            const int errorExitCode = -1;
            Environment.Exit(errorExitCode);
        }
    }
}