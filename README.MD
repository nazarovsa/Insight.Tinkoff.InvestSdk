Unofficial Tinkoff Invest .Net Sdk
====================
[![Build Status](https://travis-ci.org/InsightAppDev/Insight.Tinkoff.InvestSdk.svg?branch=master)](https://travis-ci.org/InsightAppDev/Insight.Tinkoff.InvestSdk)
[![nuget version](https://img.shields.io/nuget/v/Insight.Tinkoff.InvestSdk)](https://www.nuget.org/packages/Insight.Tinkoff.InvestSdk/)
[![Nuget](https://img.shields.io/nuget/dt/Insight.Tinkoff.InvestSDK?color=%2300000)](https://www.nuget.org/packages/Insight.Tinkoff.InvestSdk/)

About
-------------------
This is sdk for interact with [Tinkoff Invest OpenApi](https://tinkoffcreditsystems.github.io/invest-openapi/). Please, write your questions and suggestions to [issues](https://github.com/InsightAppDev/TinkoffInvestNetSdk/issues).

Get started
-------------------- 
Firstly get access token - [description of procedure](https://github.com/TinkoffCreditSystems/invest-openapi-csharp-sdk#где-взять-токен-аутентификации)

Structure of SDK
--------------------
Interaction with the API occurs through the following services:
* *MarketService* - Information about instruments (Rest, implements **[IMarketService](https://github.com/InsightAppDev/TinkoffInvestNetSdk/blob/master/Insight.Tinkoff.Invest/Domain/Services/IMarketService.cs)**)
* *OrderService* - Information about limit orders and their placement (Rest, implements **[IOrderService](https://github.com/InsightAppDev/TinkoffInvestNetSdk/blob/master/Insight.Tinkoff.Invest/Domain/Services/IOrderService.cs)**)
* *PortfolioService* - Information about portfolio (Rest, implements **[IPortfolioService](https://github.com/InsightAppDev/TinkoffInvestNetSdk/blob/master/Insight.Tinkoff.Invest/Domain/Services/IPortfolioService.cs)**)
* *OperationService* - Information about operations (Rest, implements **[IOperationService](https://github.com/InsightAppDev/TinkoffInvestNetSdk/blob/master/Insight.Tinkoff.Invest/Domain/Services/IOperationService.cs)**)
* *SandboxService* - Interact with sandbox (Rest, implements **[ISandboxService](https://github.com/InsightAppDev/TinkoffInvestNetSdk/blob/master/Insight.Tinkoff.Invest/Domain/Services/ISandboxService.cs)**)
* *StreamMarketService* - Interaction woth API throught WebSocket protocol (WebSocket, implements **[IStreamMarketService](https://github.com/InsightAppDev/TinkoffInvestNetSdk/blob/master/Insight.Tinkoff.Invest/Domain/Services/IStreamMarketService.cs)**)

Все Rest сервисы инициализируются объектом конфигурации типа **RestConfiguration**:
* *string AccessToken* - Токен доступа к API
* *string BaseUrl* - Базовый адрес API, default = "https://api-invest.tinkoff.ru"
* *bool SandboxMode* - Признак активна ли песочница, default = true

StreamMarketService инициализируется объектом конфигурации типа **StreamConfiguration**:
* *string AccessToken* - Токен доступа к API
* *string Address* - Адрес, по которому доступен WebSocket, default = "wss://api-invest.tinkoff.ru/openapi/md/v1/md-openapi/ws"

StreamMarketService
--------------------
StreamMarketService implements IStreamMarketService:
```
public interface IStreamMarketService
{
    Task Send(IWsMessage message);

    IObservable<WsMessage> AsObservable();
}
```

Send method alows you to send subcribe and unsubscrive messages. Messages types implements *IWsMessage*: *SubscribeCandleMessage*, *UnsubscribeCandleMessage*, *SubscribeOrderBookMessage*, *UnsubscribeOrderBookMessage*, *SubscribeInstrumentInfoMessage*, *UnsubscribeInstrumentInfoMessage*, *CandleMessage*, *OrderBookMessage*, *InstrumentInfoMessage*. 
AsObservable() implemented via [System.Reactive](https://www.nuget.org/packages/System.Reactive/), it gives you Push collection, which will receive messages of type IWsMessage (*CandleMessage*, *OrderBookMessage*, *InstrumentInfoMessage*). Messages deserializes into right type using Event property, you can use Pattern Matching. Example:
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

Tests
---------------
Tests running automatically by Travis 