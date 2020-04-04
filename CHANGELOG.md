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