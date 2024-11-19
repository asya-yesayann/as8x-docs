---
layout: page
title: "LoginService" 
---

## Բովանդակություն

- [Բովանդակություն](#բովանդակություն)
- [Ներածություն](#ներածություն)
- [Հատկություններ](#հատկություններ)
  - [IsLoggedIn](#isloggedin)
  - [AuthenticationMode](#authenticationmode)
  - [Username](#username)
  - [Name](#name)
  - [IsAdmin](#isadmin)
  - [DbName](#dbname)
  - [Server](#server)
  - [SessionGuid](#sessionguid)
  - [ServiceUrlData](#serviceurldata)
  - [ServiceAddress](#serviceaddress)
  - [ConfigurationName](#configurationname)
  - [Suid](#suid)
  - [TokenValidToUTC](#tokenvalidtoutc)
  - [RefreshTokenValidToUTC](#refreshtokenvalidtoutc)
  - [MustChangePassword](#mustchangepassword)
  - [PasswordState](#passwordstate)
- [Մեթոդներ](#մեթոդներ)
  - [AuthenticateAsync](#authenticateasync)
  - [Authenticate](#authenticate)
  - [AuthenticateAsync](#authenticateasync-1)
  - [Authenticate](#authenticate-1)
  - [GetToken](#gettoken)
  - [Logout](#logout)

## Ներածություն

LoginService դասը նախատեսված է մուտք գործող օգտագործողին նույնականացնելու և դուրս գալու ֆունկցիոնալությունը ապահովելու համար։

## Հատկություններ

### IsLoggedIn

```c#
public bool IsLoggedIn { get; }
```

Ցույց է տալիս, արդյոք ընթացիկ պահին կա համակարգ մուտք գործած օգտագործող։

### AuthenticationMode

```c#
public AuthenticationMode? AuthenticationMode { get; private set; }
```

Վերադարձնում է նույնականացված օգտագործողի նույնականացման եղանակը։

* `AuthenticationMode.ArmSoft` - SQL նույնականացում
* `AuthenticationMode.AD` - Active Directory նույնականացում

### Username

```c#
public string Username { get; private set; }
```

Վերադարձնում է նույնականացված օգտագործողի մուտքանունը։

### Name

```c#
public string Name { get; private set; }
```

Վերադարձնում է նույնականացված օգտագործողի անունը։

### IsAdmin

```c#
public bool IsAdmin { get; private set; }
```

Վերադարձնում է նույնականացված օգտագործողի ադմինիստրատոր հանդիսանալու հայտանիշը։

### DbName

```c#
public string DbName { get; private set; }
```

Վերադարձնում է այն տվյալների պահոցի անունը, որտեղ ուղղվում են օգտագործողի մուտքի արդյունքում բացված [սեսսիայում](../../server_api/types/SessionInfo.md) կատարվող բոլոր հարցումները։

### Server

```c#
public string Server { get; private set; }
```

Վերադարձնում է [տվյալների պահոցը](#dbname) պարունակող սերվերի անունը։

### SessionGuid

```c#
public string SessionGuid { get; private set; }
```

Վերադարձնում է օգտագործողի համակարգ մուտք գործման արդյունքում բացված [սեսսիայի](../../server_api/types/SessionInfo.md) id-ն։

### ServiceUrlData

```c#
public ServiceUrlData ServiceUrlData { get; private set; }
```

Վերադարձնում է այն սերվիսի տվյալները, որին ուղարկվելու են նույնականացման և նույնականացման արդյունքում բացված [սեսսիայի](../../server_api/types/SessionInfo.md) ընթացքում կատարվող Http հարցումները։

### ServiceAddress

```c#
public string ServiceAddress { get; private set; }
```

Վերադարձնում է այն սերվիսի հասցեն, որին ուղարկվելու են նույնականացման և նույնականացման արդյունքում բացված [սեսսիայի](../../server_api/types/SessionInfo.md) ընթացքում կատարվող Http հարցումները։

Սերվիսի հասցեն անհրաժեշտ է նախապես սահմանել [appsettings.json](../../project/appsettings_json.md) կոնֆիգուրացիոն ֆայլի [Storage](../../project/appsettings_json.md#storage) բաժնի `BaseUri` դաշտում։

### ConfigurationName

```c#
public string ConfigurationName { get; private set; }
```

Այս հատկության արժեքը ցուցադրվում է 8X-ի Status bar-ում։ Սովորաբար որպես արժեք փոխանցվում է տվյալների պահոցի կոնֆիգուրացիայի անունը (օր. Daily build test_bank):

### Suid

```c#
public short Suid { get; private set; }
```

Վերադարձնում է նույնականացված օգտագործողի ներքին համարը (կոդ)։

### TokenValidToUTC

```c#
public DateTime TokenValidToUTC { get; private set; }
```

Վերադարձնում է օգտագործողի նույնականացման արդյունքում ստեղծված տոկենի վավերականության ավարտի ամսաթիվը/ժամանակը։

### RefreshTokenValidToUTC

```c#
public DateTime RefreshTokenValidToUTC { get; private set; }
```

Վերադարձնում է օգտագործողի նույնականացման արդյունքում ստեղծված թարմացման տոկենի վավերականության ավարտի ամսաթիվը/ժամանակը։

### MustChangePassword

```c#
public bool MustChangePassword { get; private set; }
```

Ցույց է տալիս, արդյոք օգտագործողը պարտավոր է փոխել իր գաղտնաբառը՝ համակարգ մուտք գործելուց հետո։

### PasswordState

```c#
public PasswordState? PasswordState { get; private set; }
```

Վերադարձնում է նույնականացված օգտագործողի գաղտնաբառի վիճակը։

* `PasswordState.` - Գաղտնաբառը վավեր է։
* `PasswordState.` - Գաղտնաբառը նշանակվել է ադմինի կողմից և ենթակա է փոփոխման:
* `PasswordState.` - Գաղտնաբառը ժամկետանց է։

## Մեթոդներ

### AuthenticateAsync

```c#
public Task<Exception> AuthenticateAsync(string serviceAddress, HttpClient httpClient, 
                                         ILogger logger, X509Certificate2 x509Certificate2, 
                                         short apiClientId, string username, string password, 
                                         string configurationName = "", CancellationToken cancellationToken = default)
```

Նույնականացնում է սերտիֆիկատով նույնականացված կլիենտ ծրագրի օգտագործողի մուտքը համակարգ։

Նույնականացման ձախողման դեպքում վերադարձնում է առաջացած սխալը, հակառակ դեպքում վերադարձնում է null:

Նույնականացման արդյունքում առաջացած տոկենը ստանալու համար անհրաժեշտ է կանչել [GetToken](#gettoken) մեթոդը։

**Պարամետրեր**

* `serviceAddress` - Սերվիսի հասցեն, որին ուղարկվելու են նույնականացման և նույնականացման արդյունքում բացված [սեսսիայի](../../server_api/types/SessionInfo.md) ընթացքում կատարվող Http հարցումները։
* `httpClient` - [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) դասի օբյեկտ, որը նախատեսված է նույնականացման և նույնականացման արդյունքում բացված [սեսսիայի](../../server_api/types/SessionInfo.md) ընթացքում անհրաժեշտ Http հարցումներ կատարելու համար։
* `logger` - [ILogger](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger) դասի օբյեկտ, որը նախատեսված է նույնականացման և նույնականացման արդյունքում բացված [սեսսիայի](../../server_api/types/SessionInfo.md) ընթացքում կատարվող Http հարցումներում առաջացած սխալների լոգավորման համար։ 
* `x509Certificate2` - Սերտիֆիկատ, որն օգտագործվում է կլիենտ ծրագրի նույնականացման համար:
* `apiClientId` - Կլիենտ ծրագրի id-ն։
* `username` - Կլիենտ ծրագրի օգտագործողի մուտքանունը, որով նույնականացվում է։
* `password` - Օգտագործողի գաղտնաբառը։
* `configurationName` - Այս պարամետրի արժեքը փոխանցվում է [ConfigurationName](#configurationname) հատկությանը և ցուցադրվում է 8X-ի Status bar-ում։ Սովորաբար որպես արժեք փոխանցվում է տվյալների պահոցի կոնֆիգուրացիայի անունը (օր. Daily build test_bank):
* `cancellationToken` - Ընդհատման օբյեկտ։

### Authenticate

```c#
public Exception Authenticate(string serviceAddress, HttpClient httpClient, 
                              ILogger logger, X509Certificate2 x509Certificate2, 
                              short apiClientId, string username, string password, 
                              string configurationName = "")
```

Նույնականացնում է սերտիֆիկատով նույնականացված կլիենտ ծրագրի օգտագործողի մուտքը համակարգ։

Նույնականացման ձախողման դեպքում վերադարձնում է առաջացած սխալը, հակառակ դեպքում վերադարձնում է null:

Նույնականացման արդյունքում առաջացած տոկենը ստանալու համար անհրաժեշտ է կանչել [GetToken](#gettoken) մեթոդը։

**Պարամետրեր**

* `serviceAddress` - Սերվիսի հասցեն, որին ուղարկվելու են նույնականացման և նույնականացման արդյունքում բացված [սեսսիայի](../../server_api/types/SessionInfo.md) ընթացքում կատարվող Http հարցումները։
* `httpClient` - [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) դասի օբյեկտ, որը նախատեսված է նույնականացման և նույնականացման արդյունքում բացված [սեսսիայի](../../server_api/types/SessionInfo.md) ընթացքում անհրաժեշտ Http հարցումներ կատարելու համար։
* `logger` - [ILogger](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger) դասի օբյեկտ, որը նախատեսված է նույնականացման և նույնականացման արդյունքում բացված [սեսսիայի](../../server_api/types/SessionInfo.md) ընթացքում կատարվող Http հարցումներում առաջացած սխալների լոգավորման համար։ 
* `x509Certificate2` - Սերտիֆիկատ, որն օգտագործվում է կլիենտ ծրագրի նույնականացման համար:
* `apiClientId` - Կլիենտ ծրագրի id-ն։
* `username` - Կլիենտ ծրագրի օգտագործողի մուտքանունը, որով նույնականացվում է։
* `password` - Օգտագործողի գաղտնաբառը։
* `configurationName` - Այս պարամետրի արժեքը փոխանցվում է [ConfigurationName](#configurationname) հատկությանը և ցուցադրվում է 8X-ի Status bar-ում։ Սովորաբար որպես արժեք փոխանցվում է տվյալների պահոցի կոնֆիգուրացիայի անունը (օր. Daily build test_bank):

### AuthenticateAsync

```c#
public Task<Exception> AuthenticateAsync(string serviceAddress, HttpClient httpClient, 
                                         ILogger logger, short apiClientId, string secret, 
                                         string username, string configurationName = "", 
                                         CancellationToken cancellationToken = default)
```

Նույնականացնում է բանալիով նույնականացված կլիենտ ծրագրի օգտագործողի մուտքը համակարգ։

Նույնականացման ձախողման դեպքում վերադարձնում է առաջացած սխալը, հակառակ դեպքում վերադարձնում է null:

Նույնականացման արդյունքում առաջացած տոկենը ստանալու համար անհրաժեշտ է կանչել [GetToken](#gettoken) մեթոդը։

**Պարամետրեր**

* `serviceAddress` - Սերվիսի հասցեն, որին ուղարկվելու են նույնականացման և նույնականացման արդյունքում բացված [սեսսիայի](../../server_api/types/SessionInfo.md) ընթացքում կատարվող Http հարցումները։
* `httpClient` - [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) դասի օբյեկտ, որը նախատեսված է նույնականացման և նույնականացման արդյունքում բացված [սեսսիայի](../../server_api/types/SessionInfo.md) ընթացքում անհրաժեշտ Http հարցումներ կատարելու համար։
* `logger` - [ILogger](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger) դասի օբյեկտ, որը նախատեսված է նույնականացման և նույնականացման արդյունքում բացված [սեսսիայի](../../server_api/types/SessionInfo.md) ընթացքում կատարվող Http հարցումներում առաջացած սխալների լոգավորման համար։ 
* `apiClientId` - Կլիենտ ծրագրի id-ն։
* `secret` - Բանալի, որն օգտագործվում է կլիենտ ծրագրի նույնականացման համար:
* `username` - Կլիենտ ծրագրի օգտագործողի մուտքանունը, որով նույնականացվում է։
* `configurationName` - Այս պարամետրի արժեքը փոխանցվում է [ConfigurationName](#configurationname) հատկությանը և ցուցադրվում է 8X-ի Status bar-ում։ Սովորաբար որպես արժեք փոխանցվում է տվյալների պահոցի կոնֆիգուրացիայի անունը (օր. Daily build test_bank):
* `cancellationToken` - Ընդհատման օբյեկտ։

**Օրինակ**

Տե՛ս օգտագործման [օրինակը](../examples/LoginService.md#բանալիով-կլիենտ-ծրագրի-օգտագործողի-նույնականացման-օրինակ)։

### Authenticate

```c#
public Exception Authenticate(string serviceAddress, HttpClient httpClient, 
                              ILogger logger, short apiClientId, string secret, 
                              string username, string configurationName = "")
```

Նույնականացնում է բանալիով նույնականացված կլիենտ ծրագրի օգտագործողի մուտքը համակարգ։

Նույնականացման ձախողման դեպքում վերադարձնում է առաջացած սխալը, հակառակ դեպքում վերադարձնում է null:

Նույնականացման արդյունքում առաջացած տոկենը ստանալու համար անհրաժեշտ է կանչել [GetToken](#gettoken) մեթոդը։

**Պարամետրեր**

* `serviceAddress` - Սերվիսի հասցեն, որին ուղարկվելու են նույնականացման և նույնականացման արդյունքում բացված [սեսսիայի](../../server_api/types/SessionInfo.md) ընթացքում կատարվող Http հարցումները։
* `httpClient` - [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) դասի օբյեկտ, որը նախատեսված է նույնականացման և նույնականացման արդյունքում բացված [սեսսիայի](../../server_api/types/SessionInfo.md) ընթացքում անհրաժեշտ Http հարցումներ կատարելու համար։
* `logger` - [ILogger](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger) դասի օբյեկտ, որը նախատեսված է նույնականացման և նույնականացման արդյունքում բացված [սեսսիայի](../../server_api/types/SessionInfo.md) ընթացքում կատարվող Http հարցումներում առաջացած սխալների լոգավորման համար։ 
* `apiClientId` - Կլիենտ ծրագրի id-ն։
* `secret` - Բանալի, որն օգտագործվում է կլիենտ ծրագրի նույնականացման համար:
* `username` - Կլիենտ ծրագրի օգտագործողի մուտքանունը, որով նույնականացվում է։
* `configurationName` - Այս պարամետրի արժեքը փոխանցվում է [ConfigurationName](#configurationname) հատկությանը և ցուցադրվում է 8X-ի Status bar-ում։ Սովորաբար որպես արժեք փոխանցվում է տվյալների պահոցի կոնֆիգուրացիայի անունը (օր. Daily build test_bank):

**Օրինակ**

Տե՛ս օգտագործման [օրինակը](../examples/LoginService.md#բանալիով-կլիենտ-ծրագրի-օգտագործողի-նույնականացման-օրինակ)։

### GetToken

```c#
public string GetToken(TimeSpan? timeSpan = null)
```

Վերադարձնում է օգտագործողի նույնականացման արդյունքում ստեղծված տոկենը, որը օգտագործվում է օգտագործողի կողմից կատարված հարցումների նույնականացման համար։

Տոկենի վավերականության ժամկետի ավարտի դեպքում տոկենը ավտոմատ թարմացվում է և վերադարձվում թարմացված տոկենը։

**Պարամետրեր**

* `timeSpan` - Եթե տոկենի վավերականության ավարտին մնացել է ավելի քիչ ժամանակ, քան նշված է այս պարամետրում, ապա տոկենը թարմացնում է և վերադարձնում է թարմացված տոկենը։ Դատարկ արժեքի դեպքում տոկենը թարմացնում է այն դեպքում, երբ տոկենի վավերականության ավարտին մնացել է 2 րոպե կամ ավելի քիչ ժամանակ։

### Logout

```c#
public void Logout()
```

Դուրս է հանում ընթացիկ օգտագործողին համակարգից, փակում օգտագործողի [սեսսիան](../../server_api/types/SessionInfo.md) և հեռացնում [սեսսիայի](../../server_api/types/SessionInfo.md) ընթացքում առաջացած ժամանակավոր ֆայլերը, ընդհատում ընթացիկ job-երը։







