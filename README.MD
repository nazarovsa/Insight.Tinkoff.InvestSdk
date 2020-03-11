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
* *MarketService* - Information about instruments (Rest, implements **[IMarketService](https://github.com/InsightAppDev/Insight.Tinkoff.InvestSdk/blob/master/src/Insight.Tinkoff.InvestSdk/Services/IMarketService.cs)**)
* *OrderService* - Information about limit orders and their placement (Rest, implements **[IOrderService](https://github.com/InsightAppDev/Insight.Tinkoff.InvestSdk/blob/master/src/Insight.Tinkoff.InvestSdk/Services/IOrderService.cs)**)
* *PortfolioService* - Information about portfolio (Rest, implements **[IPortfolioService](https://github.com/InsightAppDev/Insight.Tinkoff.InvestSdk/blob/master/src/Insight.Tinkoff.InvestSdk/Services/IPortfolioService.cs)**)
* *OperationService* - Information about operations (Rest, implements **[IOperationService](https://github.com/InsightAppDev/Insight.Tinkoff.InvestSdk/blob/master/src/Insight.Tinkoff.InvestSdk/Services/IOperationService.cs)**)
* *SandboxService* - Interact with sandbox (Rest, implements **[ISandboxService](https://github.com/InsightAppDev/Insight.Tinkoff.InvestSdk/blob/master/src/Insight.Tinkoff.InvestSdk/Services/ISandboxService.cs)**)
* *UserService* - Information about user (accounts) (Rest, implements **[IUserService](https://github.com/InsightAppDev/Insight.Tinkoff.InvestSdk/blob/master/src/Insight.Tinkoff.InvestSdk/Services/IUserService.cs)**)
* *StreamMarketService* - Interaction woth API throught WebSocket protocol (WebSocket, implements **[IStreamMarketService](https://github.com/InsightAppDev/Insight.Tinkoff.InvestSdk/blob/master/src/Insight.Tinkoff.InvestSdk/Services/IStreamMarketService.cs)**)


All Rest services initializes by **RestConfiguration**:
* *string AccessToken* - Access token
* *string BaseUrl* - Base address, default = "https://api-invest.tinkoff.ru"
* *bool SandboxMode* - Is sandbox enabled, default = true

StreamMarketService initializes by **StreamConfiguration**:
* *string AccessToken* - Access token
* *string Address* - WebSocket address, default = "wss://api-invest.tinkoff.ru/openapi/md/v1/md-openapi/ws"
* *bool ResubscribeOnReconnect* - If true StreamMarketService will remember sended subscriptions and will resubscribe on reconnect

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
