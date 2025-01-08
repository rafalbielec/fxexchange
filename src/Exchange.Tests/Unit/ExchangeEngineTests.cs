using Exchange.Engine;
using Exchange.Engine.Abstractions;
using Exchange.Engine.Errors;
using Exchange.Engine.Models;
using NSubstitute;

namespace Exchange.Tests.Unit;

public class ExchangeEngineTests
{
    private const string DefaultPairName = "DKK/EUR";
    private const string UnsupportedSourcePairName = "USD/DKK";
    private const string UnsupportedTargetPairName = "DKK/USD";
    private readonly ExchangeEngine sut;

    public ExchangeEngineTests()
    {
        var pairParser = Substitute.For<ICurrencyPairParser>();
        pairParser.ParsePairName(DefaultPairName).Returns(new CurrencyPair(Currency.DKK, Currency.EUR));
        pairParser.ParsePairName(UnsupportedSourcePairName).Returns(new CurrencyPair(Currency.USD, Currency.DKK));
        pairParser.ParsePairName(UnsupportedTargetPairName).Returns(new CurrencyPair(Currency.DKK, Currency.USD));
        var configParser = Substitute.For<IExchangeRatesProvider>();
        var currencyRates = new Dictionary<Currency, decimal>
        {
            { Currency.EUR, 0.0M }
        };
        var rates = new ExchangeRates(Currency.DKK, currencyRates);
        configParser.GetExchangeRates().Returns(rates);
        var calculator = Substitute.For<IExchangeCalculator>();
        calculator.CalculateConversionRate(100M, new CurrencyPair(Currency.DKK, Currency.EUR), rates).Returns(123M);
        sut = new ExchangeEngine(pairParser, configParser, calculator);
    }

    [Fact]
    public void CalculatesConversionRate()
    {
        var result = sut.ConvertAmount(DefaultPairName, 100M);
        Assert.Equal(123M, result);
    }

    [Fact]
    public void CannotConvertUnsupportedSourceCurrencyInPair()
    {
        Assert.Throws<UnsupportedCurrencyException>(() => sut.ConvertAmount(UnsupportedSourcePairName, 100M));
    }

    [Fact]
    public void CannotConvertUnsupportedTargetCurrencyInPair()
    {
        Assert.Throws<UnsupportedCurrencyException>(() => sut.ConvertAmount(UnsupportedTargetPairName, 100M));
    }
}