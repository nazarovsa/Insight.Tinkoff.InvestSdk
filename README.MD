Unofficial Tinkoff Invest .Net Sdk
====================
[![Build Status](https://travis-ci.org/InsightAppDev/Insight.Tinkoff.InvestSdk.svg?branch=master)](https://travis-ci.org/InsightAppDev/Insight.Tinkoff.InvestSdk)
[![nuget version](https://img.shields.io/nuget/v/Insight.Tinkoff.InvestSdk)](https://www.nuget.org/packages/Insight.Tinkoff.InvestSdk/)
[![Nuget](https://img.shields.io/nuget/dt/Insight.Tinkoff.InvestSDK?color=%2300000)](https://www.nuget.org/packages/Insight.Tinkoff.InvestSdk/)

About
-------------------
Данное sdk предназначено для взаимодействия с [OpenApi Тинькофф Инвестиций](https://tinkoffcreditsystems.github.io/invest-openapi/). Так как на момент публикации [официального sdk](https://github.com/TinkoffCreditSystems/invest-openapi-csharp-sdk) больше половины работы над данным проектом было закончено, я решил, что буду пользоваться им и поддерживать по мере возможности. Вопросы и предложения прошу в [Issues](https://github.com/InsightAppDev/TinkoffInvestNetSdk/issues).

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

Все Rest сервисы инициализируются объектом конфигурации типа **RestConfiguration**:
* *string AccessToken* - Токен доступа к API
* *string BaseUrl* - Базовый адрес API, default = "https://api-invest.tinkoff.ru"
* *bool SandboxMode* - Признак активна ли песочница, default = true

StreamMarketService инициализируется объектом конфигурации типа **StreamConfiguration**:
* *string AccessToken* - Токен доступа к API
* *string Address* - Адрес, по которому доступен WebSocket, default = "wss://api-invest.tinkoff.ru/openapi/md/v1/md-openapi/ws"

StreamMarketService
--------------------
Механизм взаимодействия взят из [официального sdk](https://github.com/TinkoffCreditSystems/invest-openapi-csharp-sdk). StreamMarketService реализует интерфейс IStreamMarketService:
```
public interface IStreamMarketService
{
    Task Send(IWsMessage message);

    IObservable<WsMessage> AsObservable();
}
```

Соотвественно метод Send служит для отправки сообщений на подписку/отписку от событий. Классы сообщений реализуют интерфейс *IWsMessage*: *SubscribeCandleMessage*, *UnsubscribeCandleMessage*, *SubscribeOrderBookMessage*, *UnsubscribeOrderBookMessage*, *SubscribeInstrumentInfoMessage*, *UnsubscribeInstrumentInfoMessage*, *CandleMessage*, *OrderBookMessage*, *InstrumentInfoMessage*. 
giМетод AsObservable() реализован с помощью [System.Reactive](https://www.nuget.org/packages/System.Reactive/), а именно с помощью *Observable.FromEventPattern*, благодаря этому вы получаете Push коллекцию, в которую будут приходить сообщения типа IWsMessage (*CandleMessage*, *OrderBookMessage*, *InstrumentInfoMessage*). На выходе сообщения десериализуются в правильный тип на основе свойства Event интерфейса IWsMessage, вы можете использовать Pattern Matching. Пример кода:
```
public sealed class Program {
  private StreamConfiguration _config;
  
  public Program(StreamConfiguration config) {
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
            case CandleMessage message:
              Console.WriteLine($"type: {message}, figi: {message.Payload.Figi}");
              break;
            default:
              Console.WriteLine("Unknown message type");
              break;
          }
        }, ex => { throw ex; })
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
      
      subscription?.Dispose();
    }
  }
}
```

Тесты
---------------
Вы можете запустить примитивные тесты для Rest сервисов добавив в файл [Insight.Tinkoff.Invest.Tests/appsettings.json](https://github.com/InsightAppDev/TinkoffInvestNetSdk/blob/master/Insight.Tinkoff.Invest.Tests/appsettings.json) токен для сандбокса. По дефолту изменения файла игнорируются в .gitignore
