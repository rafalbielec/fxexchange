using System.Text.Json;
using System.Text.Json.Serialization;
using Exchange.Engine.Abstractions;
using Exchange.Engine.Models;

namespace Exchange.Engine.Parsers;

internal class CurrencyJsonParser : ICurrencyJsonParser
{
    internal record ExchangeRateEntry
    {
        [JsonPropertyName("name")] public Currency Name { get; init; }
        [JsonPropertyName("amount")] public decimal Amount { get; init; }
    }

    internal record ExchangeRateBase
    {
        [JsonPropertyName("baseCurrency")] public Currency BaseCurrency { get; init; }
        [JsonPropertyName("exchangeRates")] public List<ExchangeRateEntry> ExchangeRates { get; init; } = [];
    }

    public ExchangeRates ParseJson(string json)
    {
        var model = JsonSerializer.Deserialize<ExchangeRateBase>(json)
            ?? throw new JsonException("Invalid JSON provided.");

        var exchangeRatesDict = model.ExchangeRates.ToDictionary(er => er.Name, er => er.Amount);
        var currencyExchange = new ExchangeRates(model.BaseCurrency, exchangeRatesDict);

        return currencyExchange;
    }
}