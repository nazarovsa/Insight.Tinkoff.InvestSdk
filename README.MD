Unofficial Tinkoff Invest .Net Sdk
====================
[![nuget version](https://img.shields.io/nuget/v/Insight.Tinkoff.InvestSdk)](https://www.nuget.org/packages/Insight.Tinkoff.InvestSdk/)

Get started
--------------------
Для начала вам необходимо получить токен, процедура подробно описана [здесь](https://github.com/TinkoffCreditSystems/invest-openapi-csharp-sdk#где-взять-токен-аутентификации)

Структура SDK
--------------------
Взаимодействие с API происходит через следующие сервисы:
* *MarketService* - Получение информации об инструментах (Rest, реализует **[IMarketService](https://github.com/InsightAppDev/TinkoffInvestNetSdk/blob/master/Insight.Tinkoff.Invest/Domain/Services/IMarketService.cs)**)
* *OrderService* - Получение информации о лимитных заявках, а также их размещение (Rest, реализует **[IOrderService](https://github.com/InsightAppDev/TinkoffInvestNetSdk/blob/master/Insight.Tinkoff.Invest/Domain/Services/IOrderService.cs)**)
* *PortfolioService* - Получение информации о портфолио (Rest, реализует **[IPortfolioService](https://github.com/InsightAppDev/TinkoffInvestNetSdk/blob/master/Insight.Tinkoff.Invest/Domain/Services/IPortfolioService.cs)**)
* *OperationService* - Получение информации об операциях (Rest, реализует **[IOperationService](https://github.com/InsightAppDev/TinkoffInvestNetSdk/blob/master/Insight.Tinkoff.Invest/Domain/Services/IOperationService.cs)**)
* *SandboxService* - Взаимодействие с песочницей (Rest, реализует **[ISandboxService](https://github.com/InsightAppDev/TinkoffInvestNetSdk/blob/master/Insight.Tinkoff.Invest/Domain/Services/ISandboxService.cs)**)
* *StreamMarketService* - Взаимодействие с API по протоколу WebSocket (WebSocket, Реализует **[IStreamMarketService](https://github.com/InsightAppDev/TinkoffInvestNetSdk/blob/master/Insight.Tinkoff.Invest/Domain/Services/IStreamMarketService.cs)**)

Все Rest сервисы инициализируются объектом конфигурации типа **TinkoffRestServiceConfiguration**, он содержит в себе 3 свойства:
* *string AccessToken* - Токен доступа к API
* *string BaseUrl* - Базовый адрес API, default = "https://api-invest.tinkoff.ru"
* *bool SandboxMode* - Признак активна ли песочница, default = true

StreamMarketService инициализируется объектом конфигурации типа **StreamMarketServiceConfiguration**:
* *string Token* - Токен доступа к API
* *string Address* - Адрес, по которому доступен WebSocket

StreamMarketService
--------------------
Данный сервис реализует интерфейс IStreamMarketService:
```
public interface IStreamMarketService
{
    Task Send(IWsMessage message);

    IObservable<WsMessage> AsObservable();
}
```

Соотвественно метод Send служит для отправки сообщений на подписку/отписку от событий. Типы отправляемых сообщений реализуют интерфейс *IWsMessage*: *SubscribeCandleMessage*, *UnsubscribeCandleMessage*, *SubscribeOrderBookMessage*, *UnsubscribeOrderBookMessage*, *SubscribeInstrumentInfoMessage*, *UnsubscribeInstrumentInfoMessage*;
Метод AsObservable() реализован с помощью [System.Reactive](https://www.nuget.org/packages/System.Reactive/), а именно с помощью *Observable.FromEventPattern*, на выходе вы получаете Push коллекцию, в которую будут приходить сообщения типа *WsMessage*: *CandleMessage*, *OrderBookMessage*, *InstrumentInfoMessage*. На выходе сообщения десериализуются в правильный тип на основе свойства Event, вы можете использовать Pattern Matching. Пример кода:
```
public sealed class Programm {
  private StreamMarketServiceConfiguration _config;
  
  public Programm(StreamMarketServiceConfiguration config) {
    if(config == null)
      throw new ArgumentNullException(nameof(config));
      
    _config = config;
  }
  
  public async Task DoWork() {
    using (var client = new StreamMarketService(_config))
    {
      IDisposable subscription = client
        .AsObservable()
        .Do(x =>
        {
          switch (x)
          {
            case OrderBookMessage message:
              Console.WriteLine($"type: {message}, figi: {message.Payload.Figi}");
              break;
            case CandleMessage message:
              Console.WriteLine($"type: {message}, figi: {message.Payload.Figi}");
              break;
            case InstrumentInfoMessage message:
              Console.WriteLine($"type: {message}, figi: {message.Payload.Figi}");
              break;
            default:
              Console.WriteLine("Unknown message type");
              break;
          }
        }, ex => { throw ex; })
        .RetryAfterDelay(TimeSpan.FromSeconds(1))
        .Subscribe();
    
      await client.Send(new SubscribeCandleMessage
      {
        Figi = "{figi}",
        Interval = CandleInterval.Minute
      });

      await Task.Delay(1000 * 5);

      await client.Send(new UnsubscribeCandleMessage()
      {
        Figi = "{figi}",
        Interval = CandleInterval.Minute
      });
      
      subscription?.Dispose()
    }
  }
}
```
Важно: 
* *AsObservable* сам откроет соединение, поэтому если вы вызовете его до метода *Send*, то соединение открывать не нужно.
* *RetryAfterDelay* - лечит разрыв соединения.
