using Exchange.Engine.Abstractions;
using Exchange.Engine.Errors;
using Exchange.Engine.Models;
using Exchange.Engine.Parsers;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace Exchange.Tests.Unit;

public class CurrencyPairParserTests
{
    private readonly CurrencyPairParser sut;

    public CurrencyPairParserTests()
    {
        var mock = Substitute.For<ICurrencyNameParser>();
        mock.ParseName("DKK").Returns(Currency.DKK);
        mock.ParseName("USD").Returns(Currency.USD);
        mock.ParseName("EUR").Returns(Currency.EUR);
        mock.ParseName("TST").Throws(new InvalidCurrencyNameException("TST"));
        sut = new CurrencyPairParser(mock);
    }

    [Theory]
    [InlineData("AAA")]
    [InlineData("AAA;CUR")]
    [InlineData("")]
    [InlineData("/USD")]
    [InlineData("EUR/")]
    [InlineData("USD\\EUR")]
    [InlineData("USD:EUR")]
    public void InvalidPairFormatResultsInException(string name)
    {
        Assert.Throws<InvalidCurrencyPairException>(() => sut.ParsePairName(name));
    }

    [Theory]
    [InlineData("TST/TST")]
    [InlineData("TST/USD")]
    [InlineData("USD/TST")]
    public void InvalidCurrencyNameResultsInException(string name)
    {
        Assert.Throws<InvalidCurrencyNameException>(() => sut.ParsePairName(name));
    }

    [Theory]
    [InlineData("DKK/USD", Currency.DKK, Currency.USD)]
    [InlineData("DKK/EUR", Currency.DKK, Currency.EUR)]
    [InlineData("EUR/USD", Currency.EUR, Currency.USD)]
    [InlineData("USD/DKK", Currency.USD, Currency.DKK)]
    [InlineData("EUR/DKK", Currency.EUR, Currency.DKK)]
    public void ParseNameReturnsEnum(string name, Currency first, Currency second)
    {
        var result = sut.ParsePairName(name);
        Assert.Equal(first, result.SourceCurrency);
        Assert.Equal(second, result.TargetCurrency);
    }
}