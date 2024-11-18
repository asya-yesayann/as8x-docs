---
layout: page
title: "BankBankApiClient" 
---

## Բովանդակություն

- [Բովանդակություն](#բովանդակություն)
- [Ներածություն](#ներածություն)
- [Կոնստրուկտոր](#կոնստրուկտոր)
- [Կոնստրուկտոր](#կոնստրուկտոր-1)
- [Հատկություններ](#հատկություններ)
  - [Clients](#clients)
  - [LoanApplications](#loanapplications)

## Ներածություն

`BankApiClient` դասը ժառանգում է [ApiClient](../../types/ApiClient.md) դասից և նախատեսված է ՀԾ-Բանկ համակարգին յուրահատուկ հարցումներ ուղարկելու համար: 
Այս դասը հնարավորություն է տալիս կլիենտ ծրագրից սերվիս հարցումներ ուղարկել՝ օգտվելով հարցումները կատարող դասերից, որոնք ներառված են `BankApiClient`-ում որպես հատկություններ:

## Կոնստրուկտոր

```c#
public BankApiClient(string baseUrl, string token, HttpClient httpClient, ILogger logger)
```

**Պարամետրեր**

* `baseUrl` - Սերվիսի հասցե, որը օգտագործվելու է `BankApiClient` դասի միջոցով կատարվող Http հարցումների Url-ների սահմանման համար։
* `token` - Օգտագործողի տոկենը, որը ստացվել է [նույնականացման](routes/LoginService.md#authenticateasync-1) արդյունքում: 
* `httpClient` - [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) դասի օբյեկտ, որը է կլիենտից անհրաժեշտ Http հարցումներ կատարելու համար։
* `logger` - [ILogger](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger) դասի օբյեկտ, որը նախատեսված է կատարվող Http հարցումներում առաջացած սխալների լոգավորման համար։ 

## Կոնստրուկտոր

```c#
public BankApiClient(LoginService loginService, HttpClient httpClient, ILogger logger)
```

**Պարամետրեր**

* `loginService` - [LoginService](routes/LoginService.md) դասի օբյեկտ, որը նախատեսված է ստուգելու օգտագործողի տոկենի վալիդությունը և արդյոք օգատգործողը իրավասություն ունի հարցումը կատարելու։
* `httpClient` - [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) դասի օբյեկտ, որը է կլիենտից անհրաժեշտ Http հարցումներ կատարելու համար։
* `logger` - [ILogger](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger) դասի օբյեկտ, որը նախատեսված է կատարվող Http հարցումներում առաջացած սխալների լոգավորման համար։

## Հատկություններ

### Clients

```c#
public ClientsRoutes Clients { get; }
```

Վերադարձնում է [ClientsRoutes](../routes/ClientsRoutes.md) դասի օբյեկտ, որը պարունակում է մեթոդներ հաճախորդների տվյալների հետ աշխատանքը ապահովելու համար։

### LoanApplications

```c#
public LoanApplicationsRoutes LoanApplications { get; }
```

Վերադարձնում է [LoanApplicationsRoutes](../routes/LoanApplicationsRoutes.md) դասի օբյեկտ, որը պարունակում է մեթոդներ վարկային հայտերի հետ աշխատանքը ապահովելու համար։



