2.2.4
==========================
Add
--------------------------
* Add Type property to MarketInstrument
* Add FaceValue property to OrderbookRestPayload
* Add Name property to PortfolioPosition
* Add BrokerAccountType enum

Update
-------------------------
* AccountType at Account now have BrokerAccountType type instead string
* Disposed property of StreamService now public with private setter 

Fix
-------------------------
* Fix RestService wrong behavior: now HttpClient sets at ctor, EnsureHttpClientCreated and SetHeaders methods removed; Authorization header now sets at inheritor of RestService - TinkoffRestService.

2.2.3
==========================
Fix
--------------------------
The parameter "figi" with en empty value removed from the path to disable "figi" filter at OperationService.Get


2.2.2
==========================
Update
--------------------------
Add missing currencies:
* Gbp
* Hkd
* Chf
* Jpy
* Cny
* Try


2.2.1
==========================
Add
--------------------------
StreamConfiguration properties:
* ReconnectEnabled - Enable reconnect, bool, default - true
* ReconnectTimeout - Time to reconnect from last message, TimeSpan, default - 30 seconds
* ErrorReconnectTimeout - Reconnect timeout on error,  TimeSpan, default - 60 seconds

Update
--------------------------
StreamConfiguration properties:
* ResubscribeOnReconnect - Now true by default
