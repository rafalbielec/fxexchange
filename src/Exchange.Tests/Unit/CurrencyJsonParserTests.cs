using Exchange.Engine.Models;
using Exchange.Engine.Parsers;

namespace Exchange.Tests.Unit;

public class CurrencyJsonParserTests
{
    private readonly CurrencyJsonParser sut;

    public CurrencyJsonParserTests()
    {
        sut = new CurrencyJsonParser();
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("\t")]
    public void EmptyJsonResultsInException(string json)
    {
        Assert.Throws<System.Text.Json.JsonException>(() => sut.ParseJson(json));
    }

    [Fact]
    public void InvalidJsonResultsInException()
    {
        const string exchangeRatesJson = @"
        {
            ""baseCurrency"" ""DKK"",
            ""exchangeRates"": [
                { ""name"": ""EUR"", ""amount"": 743.94 },
            ]
        }";

        Assert.Throws<System.Text.Json.JsonException>(() => sut.ParseJson(exchangeRatesJson));
    }

    [Fact]
    public void ParseJsonReturnsModel()
    {
        const string exchangeRatesJson = @"
        {
            ""baseCurrency"": ""DKK"",
            ""exchangeRates"": [
                { ""name"": ""EUR"", ""amount"": 743.94 },
                { ""name"": ""USD"", ""amount"": 663.11 },
                { ""name"": ""GBP"", ""amount"": 852.85 },
                { ""name"": ""SEK"", ""amount"": 76.1 },
                { ""name"": ""PLN"", ""amount"": 0 },
                { ""name"": ""NOK"", ""amount"": 78.4 },
                { ""name"": ""CHF"", ""amount"": 683.58 },
                { ""name"": ""JPY"", ""amount"": 5.974 }
            ]
        }";

        var result = sut.ParseJson(exchangeRatesJson);
        Assert.NotNull(result);
        Assert.Equal(Currency.DKK, result.BaseCurrency);
        Assert.Equal(743.94m, result.Rates[Currency.EUR]);
        Assert.Equal(663.11m, result.Rates[Currency.USD]);
        Assert.Equal(852.85m, result.Rates[Currency.GBP]);
        Assert.Equal(76.1m, result.Rates[Currency.SEK]);
        Assert.Equal(0.0m, result.Rates[Currency.PLN]);
        Assert.Equal(78.4m, result.Rates[Currency.NOK]);
        Assert.Equal(683.58m, result.Rates[Currency.CHF]);
        Assert.Equal(5.974m, result.Rates[Currency.JPY]);
    }
}