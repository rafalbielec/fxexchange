using Exchange.Engine.Abstractions;
using Exchange.Engine.Parsers;
using IoC;

namespace Exchange.Engine;

public class EngineConfiguration : IConfiguration
{
    public IEnumerable<IToken> Apply(IMutableContainer container)
    {
        yield return container.
            Bind<IExchangeCalculator>().To<ExchangeCalculator>().
            Bind<IExchangeRatesProvider>().To<ConfigFileParser>().
            Bind<ICurrencyJsonParser>().To<CurrencyJsonParser>().
            Bind<ICurrencyPairParser>().To<CurrencyPairParser>().
            Bind<ICurrencyNameParser>().To<CurrencyNameParser>().
            Bind<IExchangeEngine>().To<ExchangeEngine>();
    }
}