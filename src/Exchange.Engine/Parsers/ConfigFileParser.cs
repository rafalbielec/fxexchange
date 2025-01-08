using Exchange.Engine.Abstractions;
using Exchange.Engine.Errors;
using Exchange.Engine.Models;

namespace Exchange.Engine.Parsers;

internal class ConfigFileParser(ICurrencyJsonParser parser,
        string configFileName = ConfigFileParser.DefaultConfigFileName) : IExchangeRatesProvider
{
    private const string DefaultConfigFileName = "currencies.json";
    private readonly string fileName = configFileName;
    private readonly ICurrencyJsonParser jsonParser = parser;

    public ExchangeRates GetExchangeRates()
    {
        var local = AppDomain.CurrentDomain.BaseDirectory;
        var filePath = Path.Combine(local, fileName);
        var fi = new FileInfo(filePath);
        if (!fi.Exists)
        {
            throw new ConfigFileMissingException(fileName);
        }

        var content = File.ReadAllText(fi.FullName);
        var record = jsonParser.ParseJson(content);

        return record;
    }
}