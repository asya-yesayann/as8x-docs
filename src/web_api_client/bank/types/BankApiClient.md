---
layout: page
title: "BankApiClient դաս"
sublinks:
- { title: "Accounts", ref: accounts }
- { title: "Cards", ref: cards }
- { title: "ClientIBOptions", ref: clientiboptions }
- { title: "Clients", ref: clients }
- { title: "LoanApplications", ref: loanapplications }
- { title: "Կոնստրուկտոր", ref: կոնստրուկտոր }
---

## Բովանդակություն

- [Ներածություն](#ներածություն)
- [Կոնստրուկտոր 1](#կոնստրուկտոր) և [Կոնստրուկտոր 2](#կոնստրուկտոր-1)
- [Հատկություններ](#հատկություններ)
  - [Accounts](#accounts)
  - [Cards](#cards)
  - [ClientIBOptions](#clientiboptions)
  - [Clients](#clients)
  - [LoanApplications](#loanapplications)

## Ներածություն

Այս դասը հնարավորություն է տալիս կլիենտ ծրագրից հարցումներ ուղարկել դեպի 8X սերվիս՝ օգտվելով հարցումները կատարող դասերից, որոնք ներառված են որպես հատկություններ:  
Այս դասը ժառանգում է միջուկի [ApiClient](../../types/ApiClient.md) դասից և նախատեսված է ՀԾ-Բանկ համակարգին յուրահատուկ հարցումներ ուղարկելու համար: 
Հասանելի են նաև ծնող [ApiClient](../../types/ApiClient.md) դասի հատկությունները հարցումներ կատարելու համար։

## Կոնստրուկտոր

```c#
public BankApiClient(LoginService loginService, HttpClient httpClient, ILogger logger)
```

Այս կոնստրուկտորը օգտագործվում է, եթե նույնականացումը կատարվում է [LoginService](../../routes/LoginService.md) դասի միջոցով։  
Այն ավելի պարզ է օգտագործման համար։

**Պարամետրեր**

* `loginService` - Նույնականացված [LoginService](../../routes/LoginService.md) դասի օբյեկտ։
* `httpClient` - [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) դասի օբյեկտ, որը կլիենտից անհրաժեշտ Http հարցումներ կատարելու համար է։
* `logger` - [ILogger](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger) դասի օբյեկտ, որը օգտագործվում է հարցումների և արդյունքների լոգավորման համար լոգավորման համար։  
  Կարող է փոխանցվել `null`։

## Կոնստրուկտոր

```c#
public BankApiClient(string baseUrl, string token, HttpClient httpClient, ILogger logger)
```

Այս կոնստրուկտորը օգտագործվում է, եթե նույնականացումը կատարվում է [AuthenticationClient](../../routes/AuthenticationClient.md) դասի միջոցով և ստացվում է նույնականացման թոքեն։  
Այն ավելի բարդ է օգտագործման համար և հնարավորություն դեպքում ցանկալի է օգտագործել մյուս կոնստրուկտորը։

**Պարամետրեր**

* `baseUrl` - 8X սերվիսի հասցե։
* `token` - Նույնականացման թոքեն: 
* `httpClient` - [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) դասի օբյեկտ, որը կլիենտից անհրաժեշտ Http հարցումներ կատարելու համար է։
* `logger` - [ILogger](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger) դասի օբյեկտ, որը օգտագործվում է հարցումների և արդյունքների լոգավորման համար լոգավորման համար։  
  Կարող է փոխանցվել `null`։

## Հատկություններ

### Accounts

```c#
public AccountsRoutes Accounts { get; }
```

Վերադարձնում է [AccountsRoutes](../routes/AccountsRoutes.md) դասի օբյեկտ, որը պարունակում է մեթոդներ հաշիվների տվյալների հետ աշխատանքը ապահովելու համար։

### Cards

```c#
public CardsRoutes Cards { get; }
```

Վերադարձնում է [CardsRoutes](../routes/CardsRoutes.md) դասի օբյեկտ, որը պարունակում է մեթոդներ քարտերի հետ աշխատանքը ապահովելու համար։

### ClientIBOptions

```c#
public ClientIBOptionsRoutes ClientIBOptions { get; }
```

Վերադարձնում է [ClientIBOptionsRoutes](../routes/ClientIBOptionsRoutes.md) դասի օբյեկտ, որը պարունակում է մեթոդներ հաճախորդների ԻԲ կարգավորումների տվյալների հետ աշխատանքը ապահովելու համար։

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
