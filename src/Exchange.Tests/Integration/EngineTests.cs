using Exchange.Engine;
using Exchange.Engine.Abstractions;
using Exchange.Engine.Parsers;

namespace Exchange.Tests.Integration;

public class EngineTests
{
    [Theory]
    [InlineData("DKK/EUR", 100, 100)]
    [InlineData("EUR/DKK", 100, 100)]
    [InlineData("EUR/EUR", 1, 1)]
    [InlineData("USD/USD", 2, 2)]
    [InlineData("GBP/GBP", 3.5238, 3.5238)]
    [InlineData("DKK/USD", 100, 50)]
    [InlineData("USD/DKK", 100, 200)]
    [InlineData("DKK/GBP", 100, 33.3333)]
    public void E2E_ExchangeEngineConvertsAmounts(string pairName, decimal amount, decimal expected)
    {
        ICurrencyNameParser nameParser = new CurrencyNameParser();
        ICurrencyPairParser pairParser = new CurrencyPairParser(nameParser);
        ICurrencyJsonParser jsonParser = new CurrencyJsonParser();
        IExchangeRatesProvider configParser = new ConfigFileParser(jsonParser);
        IExchangeCalculator calculator = new ExchangeCalculator();
        var sut = new ExchangeEngine(pairParser, configParser, calculator);
        var result = sut.ConvertAmount(pairName, amount);
        var rounded = decimal.Round(result, 4);
        Assert.Equal(expected, rounded);
    }
}