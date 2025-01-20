---
layout: page
title: "LoginService դաս" 
sublinks:
- { title: "IsLoggedIn", ref: isloggedin }
- { title: "AuthenticationMode", ref: authenticationmode }
- { title: "Username", ref: username }
- { title: "Name", ref: name }
- { title: "IsAdmin", ref: isadmin }
- { title: "DbName", ref: dbname }
- { title: "Server", ref: server }
- { title: "SessionGuid", ref: sessionguid }
- { title: "ServiceUrlData", ref: serviceurldata }
- { title: "ServiceAddress", ref: serviceaddress }
- { title: "ConfigurationName", ref: configurationname }
- { title: "Suid", ref: suid }
- { title: "TokenValidToUTC", ref: tokenvalidtoutc }
- { title: "RefreshTokenValidToUTC", ref: refreshtokenvalidtoutc }
- { title: "MustChangePassword", ref: mustchangepassword }
- { title: "PasswordState", ref: passwordstate }
- { title: "AuthenticateAsync(ClientId, ClientSecret)", ref: authenticateasync }
- { title: "AuthenticateAsync(X509Certificate2, UserName, Password)", ref: authenticateasyncx509certificate2-username-password }
- { title: "GetToken", ref: gettoken }
- { title: "Logout", ref: logout }
---

## Բովանդակություն

- [Ներածություն](#ներածություն)
- [Հատկություններ](#հատկություններ)
  - [AuthenticationMode](#authenticationmode)
  - [ConfigurationName](#configurationname)
  - [DbName](#dbname)
  - [IsLoggedIn](#isloggedin)
  - [IsAdmin](#isadmin)
  - [MustChangePassword](#mustchangepassword)
  - [Name](#name)
  - [PasswordState](#passwordstate)
  - [RefreshTokenValidToUTC](#refreshtokenvalidtoutc)
  - [Server](#server)
  - [ServiceUrlData](#serviceurldata)
  - [ServiceAddress](#serviceaddress)
  - [SessionGuid](#sessionguid)
  - [Suid](#suid)
  - [Username](#username)
  - [TokenValidToUTC](#tokenvalidtoutc)
- [Մեթոդներ](#մեթոդներ)
  - [AuthenticateAsync(ClientId, ClientSecret)](#authenticateasyncclientid-clientsecret)
  - [AuthenticateAsync(X509Certificate2, UserName, Password)](#authenticateasyncx509certificate2-username-password)
  - [GetToken](#gettoken)
  - [Logout](#logout)

## Ներածություն

LoginService դասը նախատեսված է 8X սերվիսին միացման ժամանակ նույնականացնելու համար։ 
Դասը նաև ապահովում է նույնականացման [թոքենի](#gettoken) արդի լինելը։

8X սերվիսին որևէ ծրագրից միանալու համար անհրաժեշտ է նախապես սահմանել [API Client](../api_client.md)։

Նույնականացումից հետո օգտագործվում է [ApiClient](../types/ApiClient.md) ստեղծելու և դրա միջոցով սերվիսին հարցումներ կատարելու համար։

Տե՛ս օգտագործման [օրինակը](../examples/LoginService.md)։

## Հատկություններ

### IsLoggedIn

```c#
public bool IsLoggedIn { get; }
```

Նույնականացումից հետո ցույց է տալիս, արդյոք նույնականացված է, թե ոչ։

### AuthenticationMode

```c#
public AuthenticationMode? AuthenticationMode { get; private set; }
```

Նույնականացումից հետո վերադարձնում է նույնականացման եղանակը։

* `AuthenticationMode.ArmSoft` - SQL նույնականացում
* `AuthenticationMode.AD` - Active Directory նույնականացում

### Username

```c#
public string Username { get; private set; }
```

Նույնականացումից հետո վերադարձնում է նույնականացված օգտագործողի մուտքանունը։

### Name

```c#
public string Name { get; private set; }
```

Նույնականացումից հետո վերադարձնում է նույնականացված օգտագործողի անունը։

### IsAdmin

```c#
public bool IsAdmin { get; private set; }
```

Նույնականացումից հետո վերադարձնում է նույնականացված օգտագործողի ադմինիստրատոր հանդիսանալու հայտանիշը։

### DbName

```c#
public string DbName { get; private set; }
```

Նույնականացումից հետո վերադարձնում է հիմնական տվյալների պահոցի անունը։

### Server

```c#
public string Server { get; private set; }
```

Նույնականացումից հետո վերադարձնում է [տվյալների պահոցը](#dbname) պարունակող սերվերի անունը։

### SessionGuid

```c#
public string SessionGuid { get; private set; }
```

Նույնականացումից հետո վերադարձնում է օգտագործողի համակարգ մուտք գործման արդյունքում բացված [սեսսիայի](../../server_api/types/SessionInfo.md) id-ն։

### ServiceUrlData

```c#
public ServiceUrlData ServiceUrlData { get; private set; }
```

Նույնականացումից հետո վերադարձնում է սերվիսի միացման վերաբերյալ տվյալներ (Host Name, Port, Tls, Url)։

### ServiceAddress

```c#
public string ServiceAddress { get; private set; }
```

Նույնականացումից հետո վերադարձնում է սերվիսի հասցեն։

### ConfigurationName

```c#
public string ConfigurationName { get; private set; }
```

Նույնականացումից հետո վերադարձնում է [AuthenticateAsync](#authenticateasyncclientid-clientsecret) կանչին փոխանցված համապատասխան պարամետրը։ 
Այն ինֆորմատիվ բնույթ է կրում։

### Suid

```c#
public short Suid { get; private set; }
```

Նույնականացումից հետո վերադարձնում է նույնականացված օգտագործողի ներքին համարը (կոդ)։

### TokenValidToUTC

```c#
public DateTime TokenValidToUTC { get; private set; }
```

Նույնականացումից հետո վերադարձնում է ստեղծված թոքենի վավերականության ավարտի ամսաթիվը/ժամանակը։

### RefreshTokenValidToUTC

```c#
public DateTime RefreshTokenValidToUTC { get; private set; }
```

Նույնականացումից հետո վերադարձնում է ստեղծված թարմացման թոքենի վավերականության ավարտի ամսաթիվը/ժամանակը։

### MustChangePassword

```c#
public bool MustChangePassword { get; private set; }
```

Նույնականացումից հետո ցույց է տալիս, արդյոք օգտագործողը պարտավոր է փոխել իր գաղտնաբառը։

### PasswordState

```c#
public PasswordState? PasswordState { get; private set; }
```

Նույնականացումից հետո վերադարձնում է նույնականացված օգտագործողի գաղտնաբառի վիճակը։

* `Normal` - Գաղտնաբառը վավեր է։
* `PasswordChangedByAdmin` - Գաղտնաբառը նշանակվել է ադմինիստրատորի կողմից և ենթակա է փոփոխման:
* `PasswordExpired` - Գաղտնաբառի օգտագործման ժամկետը լրացել է։

## Մեթոդներ

### AuthenticateAsync(ClientId, ClientSecret)

```c#
public Task<Exception> AuthenticateAsync(string serviceAddress, HttpClient httpClient, 
                                         ILogger logger, short apiClientId, string secret, 
                                         string username, string configurationName = "", 
                                         CancellationToken cancellationToken = default)
```

Նույնականացնում է ինտեգրման ծրագրի համար ստեղծված բանալիով ([API Client](../api_client.md))։

Նույնականացման ձախողման դեպքում վերադարձնում է առաջացած սխալը, հակառակ դեպքում վերադարձնում է null:

**Պարամետրեր**

* `serviceAddress` - 8X սերվիսի հասցեն։
* `httpClient` - [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) դասի օբյեկտ, որը նախատեսված է նույնականացման և նույնականացումից հետո Http հարցումներ կատարելու համար է։
  Օբյեկտը հարկավոր է բաց պահել քանի դեռ կատարվում են հարցումներ։
* `logger` - [ILogger](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger) դասի օբյեկտ, որը օգտագործվում է հարցումների և արդյունքների լոգավորման համար լոգավորման համար։  
  Կարող է փոխանցվել `null`։
* `apiClientId` - Կլիենտ ծրագրի id-ն (API Client Id)։
* `secret` - Կլիենտ ծրագրի բանալի (API Client Secret)։
* `username` - Օգտագործողի մուտքանունը (ներքին անունը)։
* `configurationName` - Այս պարամետրի արժեքը փոխանցվում է [ConfigurationName](#configurationname) հատկությանը:
  Այն ինֆորմատիվ բնույթ է կրում։
* `cancellationToken` - Ընդհատման օբյեկտ։

**Օրինակ**

Տե՛ս օգտագործման [օրինակը](../examples/LoginService.md#բանալիով-կլիենտ-ծրագրի-օգտագործողի-նույնականացման-օրինակ)։

### AuthenticateAsync(X509Certificate2, UserName, Password)

```c#
public Task<Exception> AuthenticateAsync(string serviceAddress, HttpClient httpClient, 
                                         ILogger logger, X509Certificate2 x509Certificate2, 
                                         short apiClientId, string username, string password, 
                                         string configurationName = "", 
                                         CancellationToken cancellationToken = default)
```

Նույնականացնում է օգտագործողի մուտքանունով և գաղտնաբառով, պահանջվում է սերտիֆիկատի առկայություն ([API Client](../api_client.md))։

Նույնականացման ձախողման դեպքում վերադարձնում է առաջացած սխալը, հակառակ դեպքում վերադարձնում է null:

**Պարամետրեր**

* `serviceAddress` - 8X սերվիսի հասցեն։
* `httpClient` - [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) դասի օբյեկտ, որը նախատեսված է նույնականացման և նույնականացումից հետո Http հարցումներ կատարելու համար է։
  Օբյեկտը հարկավոր է բաց պահել քանի դեռ կատարվում են հարցումներ։
* `logger` - [ILogger](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger) դասի օբյեկտ, որը օգտագործվում է հարցումների և արդյունքների լոգավորման համար լոգավորման համար։  
  Կարող է փոխանցվել `null`։
* `x509Certificate2` - Սերտիֆիկատ, որն օգտագործվում է կլիենտ ծրագրի նույնականացման համար:
* `apiClientId` - Կլիենտ ծրագրի id-ն (API Client Id)։
* `username` - Օգտագործողի մուտքանունը։
* `password` - Օգտագործողի գաղտնաբառը։
* `configurationName` - Այս պարամետրի արժեքը փոխանցվում է [ConfigurationName](#configurationname) հատկությանը:
  Այն ինֆորմատիվ բնույթ է կրում։
* `cancellationToken` - Ընդհատման օբյեկտ։

### GetToken

```c#
public string GetToken(TimeSpan? timeSpan = null)
```

Նույնականացումից հետո վերադարձնում է ստեղծված թոքենը։
Օգտագործվում է [ApiClient](../types/ApiClient.md) ստեղծելու համար։

Թոքենի վավերականության ժամկետի ավարտի դեպքում թոքենը ավտոմատ թարմացվում է և վերադարձվում թարմացված թոքենը։

**Պարամետրեր**

* `timeSpan` - Եթե թոքենի վավերականության ավարտին մնացել է ավելի քիչ ժամանակ, քան նշված է այս պարամետրում, ապա թոքենը թարմացնում է և վերադարձնում է թարմացված թոքենը։ 
  Դատարկ արժեքի դեպքում տոկենը թարմացնում է այն դեպքում, երբ տոկենի վավերականության ավարտին մնացել է 2 րոպե կամ ավելի քիչ ժամանակ։

### Logout

```c#
public void Logout()
```

Դուրս է հանում ընթացիկ օգտագործողին համակարգից, փակում օգտագործողի [սեսսիան](../../server_api/types/SessionInfo.md) և հեռացնում [սեսսիայի](../../server_api/types/SessionInfo.md) ընթացքում առաջացած ժամանակավոր ֆայլերը, ընդհատում է ընթացիկ առաջադրանքները։







