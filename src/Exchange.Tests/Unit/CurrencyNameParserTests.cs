using Exchange.Engine.Errors;
using Exchange.Engine.Models;
using Exchange.Engine.Parsers;

namespace Exchange.Tests.Unit;

public class CurrencyNameParserTests
{
    private readonly CurrencyNameParser sut;

    public CurrencyNameParserTests()
    {
        sut = new CurrencyNameParser();
    }

    [Theory]
    [InlineData("AAA")]
    [InlineData("")]
    [InlineData("/")]
    [InlineData("\\")]
    [InlineData(" ")]
    [InlineData("2*")]
    public void InvalidCurrencyNameResultsInException(string name)
    {
        Assert.Throws<InvalidCurrencyNameException>(() => sut.ParseName(name));
    }

    [Theory]
    [InlineData("DKK", Currency.DKK)]
    [InlineData("USD", Currency.USD)]
    [InlineData("EUR", Currency.EUR)]
    [InlineData("GBP", Currency.GBP)]
    [InlineData("JPY", Currency.JPY)]
    [InlineData("CAD", Currency.CAD)]
    [InlineData("AUD", Currency.AUD)]
    [InlineData("CHF", Currency.CHF)]
    [InlineData("SEK", Currency.SEK)]
    [InlineData("IMP", Currency.IMP)]
    public void ParseNameReturnsEnum(string name, Currency expected)
    {
        var result = sut.ParseName(name);
        Assert.Equal(expected, result);
    }
}