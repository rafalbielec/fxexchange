namespace Exchange.Engine.Models;

public record ExchangeRates(Currency BaseCurrency, Dictionary<Currency, decimal> Rates);