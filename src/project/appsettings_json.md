---
layout: page
title: "appsettings.json: Կարգավորման ֆայլ"
tags: [Settings, appsettings]
---

## Բովանդակություն

* [Նախաբան](#նախաբան)
* Բաժիններ
  * [additionalSettings](#additionalsettings)
  * [AllowedHosts](#allowedhosts)
  * [Autentication](#autentication)
  * [db](#db)
  * [Hangfire](#hangfire)
  * [IsHangfireServer](#ishangfireserver)
  * [JwtConfig](#jwtconfig)
  * [redisCachingSettings](#rediscachingsettings)
  * [redisCachedItems](#rediscacheditems)
  * [Serilog](#serilog)
  * [Storage](#storage)
  
## Նախաբան

[appsettings.json](https://learn.microsoft.com/en-us/iis-administration/configuration/appsettings.json)-ը նախատեսված է AS-8X հարթակի ծրագրերի [կարգավորման պարամետրերը](https://learn.microsoft.com/en-us/dotnet/core/extensions/configuration) պահելու համար, ինչպիսիք են տվյալների բազայի SqlConnection-ը, լոգավորման կարգավորումները, ...:

## additionalSettings

Նախկինում համակարգ մուտ գործելու համար անհրաժեշտ էր միայն մուտքանուն և գաղտնաբառ։
Հիմա բացի մուտքանունից և գաղտնաբառից անհրաժեշտ է նաև

```c#
"additionalSettings": {
    "disableOldLogins": false
}
```

**Պարամետրեր**
* `disableOldLogins` - 

## AllowedHosts

```c#
"AllowedHosts": "*"
```

**Պարամետրեր**
* `AllowedHosts` - 

## Autentication

```c#
    "Autentication": {
        "Alternative": "AD",
        "AD": {
            "Authority": "https://login.microsoftonline.com/armsoft.am",
            "ClientId": "158u5wn2-2n95-14nm-22b2-9694efe14vae",
            "RedirectUri": "https://armsoft.am/b2bAdminTool",
            "TokenMapping": "oid",
            "ResourceID": "https://armsoft.am/Cloud"
        },
        "ADFS": {
            "Authority": "https://adfs.armsoft.am/adfs",
            "ClientId": "v04c6fd-4220-14e6-n315-f147ac852c18",
            "RedirectUri": "https://localhost:44322",
            "TokenMapping": "sid"
        }
    }
```

## Hangfire

Hangfire-ը գրադարան է, որը նախատեսված է background job-երի հերթի դրման և կատարման մեխանիզմը ապահովելու համար։

```c#
"Hangfire": {
    "server": "TEST-SERVER",
    "database": "test_db",
    "login": "test-user",
    "password": "test-password",
    "workerCount": 10,
    "expirationInDays": 1
}
```

**Պարամետրեր**
* `server` - Սերվերի անունը, որտեղ գտնվում է Hangfire-ի տվյալների բազան:
* `database` - Տվյալների բազայի անունը, որը օգտագործում է Hangfire-ը:
* `login` -  Տվյալների բազայի սերվերին մուտք գործելու համար օգտագործվող մուտքանունը։
* `password` - Տվյալների բազայի սերվերին մուտք գործելու համար օգտագործվող գաղտնաբառը։
* `workerCount` - Նշում է ֆոնային աշխատող thread-երի քանակը, որոնք Hangfire-ը պետք է օգտագործի առաջադրանքները մշակելու համար։
* `expirationInDays` - Նշում է օրերի քանակը, որից հետո մշակված առաջադրանքները կհամարվեն ժամկետանց և կջնջվեն տվյալների բազայից։

## IsHangfireServer

```c#
"IsHangfireServer": false
```

## JwtConfig

```c#
"JwtConfig": {
    "secret": "7V{)Grmn0/12cx^TY<gnl.568",
    "issuer": "test_db",
    "expirationInMinutes": 1440,
    "refreshExpirationInMinutes": 43200
},
```

**Պարամետրեր**
* `secret` - JWT տոկենի վավերականացման ու ստորագրման համար նախատեսված բանալի
* `issuer` - Տոկենը թողարկող տվյալների բազայի անունը։
* `expirationInMinutes` -  Տոկենի  վավերականության տևողությունը րոպեներով։
* `refreshExpirationInMinutes` - Թարմացման տոկենի վավերականության տևողությունը րոպեներով:

## redisCachingSettings

Redis-ը 

```c#
"redisCachingSettings": {
    "enabled": false,
    "connectionString": "dockerub1:6379,password=mypassword"
}
```

**Պարամետրեր**
* `enabled` - Redis-ով տվյալների քեշավորման հայտանիշ։
* `connectionString` - Redis սերվերին միացման Connection string-ը, որի արժեքը պետք է լինի հետևյալ ֆորմատի՝ "hostname : port, password = yourPassword"

### redisCachedItems

Այս պահին համակարգում քեշավորվում են փաստաթղթի մետատվյալները, 
```c#
"rediscacheditems": {
    "documentMetadata": {
        "enabled": true,
        "lifetime": "1.00:00:00"
    },
    "monitoring": {
        "enabled": true,
        "lifetime": "0.00:01:00"
    },
    "parameters": {
        "enabled": true,
        "lifetime": "1.00:00:00"
    }
}
```

## db

Այս բաժինը նախատեսված է տվյալների բազայի կարգավորումները պահելու համար։

```c#
"db": {
    "server": "TEST-SERVER",
    "database": "test_db",
    "login": "test-user",
    "password": "test-password",
    "customerId": "100000",
    "encrypt": false
}
```

**Պարամետրեր**
* `server` - Սերվերի անուն։
* `database` - Սերվերում գտնվող տվյալների բազայի անուն։
* `login` - Տվյալների բազայի սերվերին մուտք գործելու համար օգտագործվող մուտքանունը։
* `password` - Տվյալների բազայի սերվերին մուտք գործելու համար օգտագործվող գաղտնաբառը։
* `customerId` - Պատվիրատուի նույնակացման համար
* `encrypt` - 

## Storage

Սահմանում է 

```json
"Storage": {
    "BaseUri": "http://localhost:1026/",
    "Directory": "C:\\Storage\\Files\\"
}
```

**Պարամետրեր**
* `BaseUri` - 
* `Directory` - 

## Serilog

[Serilog](https://serilog.net/)-ը լոգավորման գրադարան է։ AS-8X համակարգում օգտագործվում է ծրագրում առաջացած սխալների, խափանումների հավաքագրման և երկար տևող պրոցեսների(տվյալների աղբյուրների, DPR-ների, Job-երի կատարում, ...) մասին տեղեկատվության գրանցման համար։

AS-8X համակարգում տրված է հնարավորություն լոգը գրանցելու Console-ում, ֆայլում, Seq-ում։

Ֆայլում և Seq-ում գրանցումը ապահովելու համար անհրաժեշտ է appsettings.json ֆայլի `Serilog`-ում բաժնում ավելացնել `WriteTo` ենթաբաժին` նշելով լոգի գրանցման վայրը ու դրան հատուկ արգումենտները։

Ֆայլում գրանցում 
```c#
 "WriteTo": [
     {
         "Name": "File",
         "Args": {
             "path": "./logs/log.json",
             "rollingInterval": "Day",
             "formatter": "Serilog.Formatting.Compact.CompactJsonFormatter, Serilog.Formatting.Compact"
         }
     }
```
* `Name` - լոգի գրանցման վայր
* `Args` - գրանցման ֆայլի կարգավորումները
	* path - ֆայլի ճանապարհը
	* rollingInterval - 
	* formatter - 
