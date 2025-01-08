using Exchange.Engine;
using Exchange.Engine.Models;

namespace Exchange.Tests.Unit;

public class ExchangeCalculatorTests
{
    private readonly ExchangeCalculator sut = new();

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(99.23)]
    [InlineData(0.0)]
    public void ConvertingSameCurrencyResultsInSourceAmount(decimal amount)
    {
        var pair = new CurrencyPair(Currency.EUR, Currency.EUR);
        var currencyRates = new Dictionary<Currency, decimal>();
        var rates = new ExchangeRates(Currency.PLN, currencyRates);
        var result = sut.CalculateConversionRate(amount, pair, rates);

        Assert.Equal(amount, result);
    }

    [Fact]
    public void ConvertingEurToUsdResultsInRatioAgainstBaseCurrency()
    {
        var pair = new CurrencyPair(Currency.EUR, Currency.USD);
        var currencyRates = new Dictionary<Currency, decimal>
        {
            { Currency.EUR, 2.0M },
            { Currency.USD, 4.0M }
        };
        var rates = new ExchangeRates(Currency.PLN, currencyRates);
        var result = sut.CalculateConversionRate(50.0M, pair, rates);

        Assert.Equal(25M, result);
    }

    [Fact]
    public void ConvertingBaseToEurResultsInAccurateAmount()
    {
        var pair = new CurrencyPair(Currency.EUR, Currency.DKK);
        var currencyRates = new Dictionary<Currency, decimal>
        {
            { Currency.EUR, 743.94M }
        };
        var rates = new ExchangeRates(Currency.DKK, currencyRates);
        var result = sut.CalculateConversionRate(1.0M, pair, rates);

        Assert.Equal(7.4394M, result);
    }

    [Fact]
    public void ConvertingEurToBaseResultsInAccurateAmount()
    {
        var pair = new CurrencyPair(Currency.DKK, Currency.EUR);
        var currencyRates = new Dictionary<Currency, decimal>
        {
            { Currency.EUR, 743.94M }
        };
        var rates = new ExchangeRates(Currency.DKK, currencyRates);
        var result = sut.CalculateConversionRate(100.0M, pair, rates);
        var rounded = decimal.Round(result, 4);
        Assert.Equal(13.4419M, rounded);
    }
}