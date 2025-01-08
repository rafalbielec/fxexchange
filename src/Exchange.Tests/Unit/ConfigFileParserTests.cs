using Exchange.Engine.Abstractions;
using Exchange.Engine.Errors;
using Exchange.Engine.Models;
using Exchange.Engine.Parsers;
using NSubstitute;

namespace Exchange.Tests.Unit;

public class ConfigFileParserTests
{
    [Fact]
    public void ConfigFileExistsNextToExeFileReturnsExchangeRates()
    {
        var mock = Substitute.For<ICurrencyJsonParser>();
        mock.ParseJson(Arg.Any<string>()).Returns(new ExchangeRates(Currency.ALL, []));
        var sut = new ConfigFileParser(mock);
        var result = sut.GetExchangeRates();
        Assert.NotNull(result);
        Assert.Equal(Currency.ALL, result.BaseCurrency);
        Assert.Empty(result.Rates);
    }

    [Fact]
    public void MissingConfigFileResultsInException()
    {
        var mock = Substitute.For<ICurrencyJsonParser>();
        var missingConfigSut = new ConfigFileParser(mock, "missing.json");
        Assert.Throws<ConfigFileMissingException>(() => missingConfigSut.GetExchangeRates());
    }
}