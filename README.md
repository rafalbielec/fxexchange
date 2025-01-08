# FX Exchange Programming Exercise

The purpose of this exercise is to build a small CLI app that will convert monetary amounts between different currencies. The application has a separate JSON configuration file which holds the foreign exchange values against one base currency but the implementation can be adjusted to pull these values from an external source if needed.

You can run it with the dotnet command. The amounts are expressed with the comma used for the decimal point.

```sh
dotnet run --project src/Exchange
dotnet run --project src/Exchange EUR/DKK 1
dotnet run --project src/Exchange EUR/DKK 2,59
dotnet run --project src/Exchange USD/EUR 35,53
```

## JSON configuration file

The JSON configuration file is called **currencies.json** and it has the following format. The base currency is the Danish Krone and the rest of the currencies are exchange rates against it for 100 DKK.

```json
{
  "baseCurrency": "DKK",
  "exchangeRates": [
    { "name": "EUR", "amount": 743.94 },
    { "name": "USD", "amount": 663.11 },
    { "name": "GBP", "amount": 852.85 },
    { "name": "SEK", "amount": 76.1 },
    { "name": "NOK", "amount": 78.4 },
    { "name": "CHF", "amount": 683.58 },
    { "name": "JPY", "amount": 5.974 }
  ]
}
```

## NuGet packages used

- [IoC.Container](https://github.com/DevTeam/IoCContainer)
- [System.Text.Json](https://www.nuget.org/packages/system.text.json)
- [NSubstitute](https://nsubstitute.github.io)

## Unit and Integration tests

The solution also features a separate xunit test project which contains unit tests and an integration tests.

## Tokei code summary

```sh
cargo install tokei
tokei
```

| Language              | Files | Lines | Code | Comments | Blanks |
|-----------------------|-------|-------|------|----------|--------|
| C#                    | 30    | 887   | 772  | 5        | 110    |
| JSON                  | 3     | 26    | 26   | 0        | 0      |
| Markdown              | 1     | 18    | 0    | 10       | 8      |
| MSBuild               | 3     | 65    | 65   | 0        | 0      |
| Visual Studio Solution| 1     | 34    | 33   | 0        | 1      |
| **Total**             | 38    | 1030  | 896  | 15       | 119    |
