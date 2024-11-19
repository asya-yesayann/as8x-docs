---
layout: page
title: "ApiClient" 
---

## Բովանդակություն

- [Բովանդակություն](#բովանդակություն)
- [Ներածություն](#ներածություն)
- [Կոնստրուկտոր](#կոնստրուկտոր)
- [Կոնստրուկտոր](#կոնստրուկտոր-1)
- [Հատկություններ](#հատկություններ)
  - [Blob](#blob)
  - [Document](#document)
  - [DPR](#dpr)
  - [Extender](#extender)
  - [Version](#version)

## Ներածություն

`ApiClient` դասը հնարավորություն է տալիս կլիենտ ծրագրից սերվիս հարցումներ ուղարկել՝ օգտվելով հարցումները կատարող դասերից, որոնք ներառված են `ApiClient`-ում որպես հատկություններ:

## Կոնստրուկտոր

```c#
public ApiClient(string baseUrl, string token, HttpClient httpClient, ILogger logger)
```

**Պարամետրեր**

* `baseUrl` - Սերվիսի հասցե, որը օգտագործվելու է `ApiClient` դասի միջոցով կատարվող Http հարցումների Url-ների սահմանման համար։
* `token` - Օգտագործողի տոկենը, որը ստացվել է [նույնականացման](routes/LoginService.md#authenticateasync-1) արդյունքում: 
* `httpClient` - [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) դասի օբյեկտ, որը է կլիենտից անհրաժեշտ Http հարցումներ կատարելու համար։
* `logger` - [ILogger](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger) դասի օբյեկտ, որը նախատեսված է կատարվող Http հարցումներում առաջացած սխալների լոգավորման համար։ 

## Կոնստրուկտոր

```c#
public ApiClient(LoginService loginService, HttpClient httpClient, ILogger logger)
```

**Պարամետրեր**

* `loginService` - [LoginService](routes/LoginService.md) դասի օբյեկտ, որը նախատեսված է ստուգելու օգտագործողի տոկենի վալիդությունը և արդյոք օգատգործողը իրավասություն ունի հարցումը կատարելու։
* `httpClient` - [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) դասի օբյեկտ, որը է կլիենտից անհրաժեշտ Http հարցումներ կատարելու համար։
* `logger` - [ILogger](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger) դասի օբյեկտ, որը նախատեսված է կատարվող Http հարցումներում առաջացած սխալների լոգավորման համար։

## Հատկություններ

### Blob

```c#
public BlobRoutes Blob { get; }
```

Վերադարձնում է `BlobRoutes` դասի օբյեկտ, որը պարունակում է մեթոդներ` կլիենտից [StorageService](../server_api/services/IStorageService.md)-ի մեթոդներին դիմելու համար։ 

### Document

```c#
public DocumentRoutes Document { get; }
```

Վերադարձնում է `DocumentRoutes` դասի օբյեկտ, որը պարունակում է մեթոդներ` կլիենտից փաստաթղթի սերվերային տրամաբանությունը պարունակող [DocumentService](../server_api/services/IDocumentService.md)-ի մեթոդներին դիմելու համար։ 

### DPR

```c#
public DataProcessingRequestRoutes DPR { get; }
```

Վերադարձնում է `DataProcessingRequestRoutes` դասի օբյեկտ, որը պարունակում է մեթոդներ` կլիենտից [DPR](../server_api/definitions/dpr.md)-ի կատարումը ապահովելու համար։ 

### Extender

```c#
public ExtenderRoutes Extender { get; }
```

Վերադարձնում է [ExtenderRoutes](../routes/ExtenderRoutes.md) դասի օբյեկտ, որը պարունակում է մեթոդներ` ընդլայնումների հետ աշխատանքը (ընդլայնման նկարագրության ստացում, ընդլայնման կոդի կոմպիլացում...) ապահովելու համար։

### Version

```c#
public VersionRoutes Version { get; }
```

Վերադարձնում է `VersionRoutes` դասի օբյեկտ, որը պարունակում է մեթոդներ` պրոյեկտների տարբերակների ստացման համար։