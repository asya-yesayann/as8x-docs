---
layout: page
title: "ApiClient դաս" 
sublinks:
- { title: "Blob", ref: blob }
- { title: "Document", ref: document }
- { title: "DPR", ref: dpr }
- { title: "Extender", ref: extender }
- { title: "Version", ref: version }
---

## Բովանդակություն

- [Ներածություն](#ներածություն)
- [Կոնստրուկտոր 1](#կոնստրուկտոր) և [Կոնստրուկտոր 2](#կոնստրուկտոր-1)
- [Հատկություններ](#հատկություններ)
  - [Blob](#blob)
  - [Document](#document)
  - [DPR](#dpr)
  - [Extender](#extender)
  - [Version](#version)

## Ներածություն

Այս դասը հնարավորություն է տալիս կլիենտ ծրագրից հարցումներ ուղարկել դեպի 8X սերվիս՝ օգտվելով հարցումները կատարող դասերից, որոնք ներառված են որպես հատկություններ:

Այս օբյեկտի փոխարեն ցանկալի է օգտագործել ժառանգ դասերից որևէ մեկը (Օրինակ՝ [BankApiClient](../bank/types/BankApiClient.md))։

## Կոնստրուկտոր

```c#
public ApiClient(LoginService loginService, HttpClient httpClient, ILogger logger)
```

Այս կոնստրուկտորը օգտագործվում է, եթե նույնականացումը կատարվում է [LoginService](../routes/LoginService.md) դասի միջոցով։  
Այն ավելի պարզ է օգտագործման համար։

**Պարամետրեր**

* `loginService` - Նույնականացված [LoginService](routes/LoginService.md) դասի օբյեկտ։
* `httpClient` - [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) դասի օբյեկտ, որը կլիենտից անհրաժեշտ Http հարցումներ կատարելու համար է։
* `logger` - [ILogger](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger) դասի օբյեկտ, որը օգտագործվում է հարցումների և արդյունքների լոգավորման համար լոգավորման համար։  
  Կարող է փոխանցվել `null`։

## Կոնստրուկտոր

```c#
public ApiClient(string baseUrl, string token, HttpClient httpClient, ILogger logger)
```

Այս կոնստրուկտորը օգտագործվում է, եթե նույնականացումը կատարվում է [AuthenticationClient](../routes/AuthenticationClient.md) դասի միջոցով և ստացվում է նույնականացման թոքեն։  
Այն ավելի բարդ է օգտագործման համար և հնարավորություն դեպքում ցանկալի է օգտագործել մյուս կոնստրուկտորը։

**Պարամետրեր**

* `baseUrl` - 8X սերվիսի հասցե։
* `token` - Նույնականացման թոքեն: 
* `httpClient` - [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) դասի օբյեկտ, որը կլիենտից անհրաժեշտ Http հարցումներ կատարելու համար է։
* `logger` - [ILogger](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger) դասի օբյեկտ, որը օգտագործվում է հարցումների և արդյունքների լոգավորման համար լոգավորման համար։  
  Կարող է փոխանցվել `null`։

## Հատկություններ

### Blob

```c#
public BlobRoutes Blob { get; }
```

Վերադարձնում է [BlobRoutes](../routes/BlobRoutes.md) դասի օբյեկտ, որը պարունակում է մեթոդներ սերվերում պահպանված ֆայլերի հետ աշխատանքը ապահովելու համար։

### Document

```c#
public DocumentRoutes Document { get; }
```

Վերադարձնում է [DocumentRoutes](../routes/DocumentRoutes.md) դասի օբյեկտ, որը պարունակում է մեթոդներ փաստաթղթերի հետ աշխատանքը ապահովելու համար։

### DPR

```c#
public DataProcessingRequestRoutes DPR { get; }
```

Վերադարձնում է [DataProcessingRequestRoutes](../routes/DataProcessingRequestRoutes.md) դասի օբյեկտ, որը պարունակում է մեթոդներ տվյալների մշակման հարցումների հետ աշխատանքը ապահովելու համար։

### Extender

```c#
public ExtenderRoutes Extender { get; }
```

Վերադարձնում է [ExtenderRoutes](../routes/ExtenderRoutes.md) դասի օբյեկտ, որը պարունակում է մեթոդներ ընդլայնումների հետ աշխատանքը (ընդլայնման նկարագրության ստացում, ընդլայնման կոդի կոմպիլացում...) ապահովելու համար։

### Version

```c#
public VersionRoutes Version { get; }
```

Վերադարձնում է `VersionRoutes` դասի օբյեկտ, որը պարունակում է մեթոդներ պրոյեկտների տարբերակների ստացման համար։