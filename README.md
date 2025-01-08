# FX Exchange Programming Exercise

The purpose of this exercise is to build a small CLI app which will convert monetary amounts between different currencies. The application has a separate JSON configuration file which holds the foreign exchange values against one base currency but the implementation can be adjusted to pull these values from an external source if needed.

You can run it with the dotnet command

```sh
dotnet run --project src/Exchange
dotnet run --project src/Exchange EUR/DKK 1
```

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

