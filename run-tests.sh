cd tests/Insight.Tinkoff.InvestSdk.Tests

echo "{\"AccessToken\": \"${1}\"}" > appsettings.json

dotnet test
