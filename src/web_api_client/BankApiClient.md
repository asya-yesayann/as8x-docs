---
layout: page
title: "BankApiClient" 
---

## Բովանդակություն

- [Ներածություն](#ներածություն)
- [Կոնստրուկտոր](#կոնստրուկտոր)
- [Հատկություններ](#հատկություններ)
  - [Document](#document)
  - [Version](#version)
  - [DPR](#dpr)
  - [Document](#document-1)

## Ներածություն

BankApiClient դասը նախատեսված է կլիենտ ծրագրից դեպի սերվիս հարցումներ ուղարկող դասերին դիմելու համար, որոնք ավելացված են որպես հատկություններ։

## Կոնստրուկտոր

```c#
public BankApiClient(LoginService loginService, HttpClient httpClient, ILogger logger)
```

**Պարամետրեր**

* `loginService` - [LoginService](routes/LoginService.md) դասի օբյեկտ, որը նախատեսված է ստուգելու օգտագործողի տոկենի վալիդությունը և արդյոք օգատգործողը իրավասություն ունի հարցումը կատարելու։
* `httpClient` - [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) դասի օբյեկտ, որը է կլիենտից անհրաժեշտ Http հարցումներ կատարելու համար։
* `logger` - [ILogger](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger) դասի օբյեկտ, որը նախատեսված է կատարվող Http հարցումներում առաջացած սխալների լոգավորման համար։ 

## Հատկություններ

### Document

```c#
public DocumentRoutes Document { get; }
```

Վերադարձնում է `DocumentRoutes` դասի օբյեկտ, որը պարունակում է մեթոդներ` կլիենտից փաստաթղթի սերվերային տրամաբանությունը պարունակող [DocumentService](../server_api/services/IDocumentService.md)-ի մեթոդներին դիմելու համար։ 

### Version

```c#
public VersionRoutes Version { get; }
```

Վերադարձնում է `VersionRoutes` դասի օբյեկտ, որը պարունակում է մեթոդներ` պրոյեկտների տարբերակների ստացման համար։

### DPR

```c#
public DataProcessingRequestRoutes DPR { get; }
```

Վերադարձնում է `DataProcessingRequestRoutes` դասի օբյեկտ, որը պարունակում է մեթոդներ` կլիենտից [DPR](../server_api/definitions/dpr.md)-ի կատարումը ապահովելու համար։ 

### Document

```c#
public BlobRoutes Blob { get; }
```

Վերադարձնում է `BlobRoutes` դասի օբյեկտ, որը պարունակում է մեթոդներ` կլիենտից [StorageService](../server_api/services/IStorageService.md)-ի մեթոդներին դիմելու համար։ 