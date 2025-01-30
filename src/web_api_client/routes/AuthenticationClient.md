---
layout: page
title: "AuthenticationClient" 
sublinks:
- { title: "AuthenticateWithCertificateAsync", ref: authenticatewithcertificateasync }
- { title: "AuthenticateWithSecretAsync", ref: authenticatewithsecretasync }
---

## Բովանդակություն

- [Ներածություն](#ներածություն)
- [Կոնստրուկտոր](#կոնստրուկտոր)
- [Մեթոդներ](#մեթոդներ)
  - [AuthenticateWithCertificateAsync](#authenticatewithcertificateasync)
  - [AuthenticateWithSecretAsync](#authenticatewithsecretasync)

## Ներածություն

AuthenticationClient դասը նախատեսված է 8X սերվիսին միացման ժամանակ նույնականացնելու համար։ 

Հնարավորության դեպքում նախընտրելի է օգտագործել [LoginService](LoginService.md) դասը նույնականացման համար։

8X սերվիսին որևէ ծրագրից միանալու համար անհրաժեշտ է նախապես սահմանել [API Client](../api_client.md)։

Նույնականացումից հետո օգտագործվում է [ApiClient](../types/ApiClient.md) ստեղծելու և դրա միջոցով սերվիսին հարցումներ կատարելու համար։

Տե՛ս օգտագործման [օրինակը](../examples/AuthenticationClient.md)։

## Կոնստրուկտոր

```c#
public AuthenticationClient(string baseUrl, HttpClient httpClient, ILogger logger)
```

**Պարամետրեր**

* `baseUrl` - 8X սերվիսի հասցեն։
* `httpClient` - [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) դասի օբյեկտ, որը նախատեսված է նույնականացման և նույնականացումից հետո Http հարցումներ կատարելու համար է։
  Օբյեկտը հարկավոր է բաց պահել քանի դեռ կատարվում են հարցումներ։
* `logger` - [ILogger](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger) դասի օբյեկտ, որը օգտագործվում է հարցումների և արդյունքների լոգավորման համար լոգավորման համար։  
  Կարող է փոխանցվել `null`։

## Մեթոդներ

### AuthenticateWithCertificateAsync

```c#
public Task<CertificateAuthenticateResponse> AuthenticateWithCertificateAsync(
    CertificateAuthenticateRequest certificateAuthenticateRequest, 
    CancellationToken cancellationToken = default)
```

Նույնականացնում է օգտագործողի մուտքանունով և գաղտնաբառով, պահանջվում է սերտիֆիկատի առկայություն ([API Client](../api_client.md))։

Նույնականացման հաջողման դեպքում վերադարձնում է [օգտագործողի տվյալները և թոքեն՝ դեպի սերվիս հարցումներ կատարելու համար](../types/CertificateAuthenticateResponse.md), հակառակ դեպքում առաջացնում է սխալ։

**Պարամետրեր**

* `certificateAuthenticateRequest` - [Օգտագործողի և API Client-ի տվյալները](../types/CertificateAuthenticateRequest.md)։
* `cancellationToken` - Ընդհատման օբյեկտ։

### AuthenticateWithSecretAsync

```c#
public Task<AuthenticateResponse> AuthenticateWithSecretAsync(
    string username, short apiClientId, string secret, 
    CancellationToken cancellationToken = default)
```

Նույնականացնում է ինտեգրման ծրագրի համար ստեղծված բանալիով ([API Client](../api_client.md))։

Նույնականացման հաջողման դեպքում վերադարձնում է [օգտագործողի տվյալները և թոքեն՝ դեպի սերվիս հարցումներ կատարելու համար](../types/AuthenticateResponse.md), հակառակ դեպքում առաջացնում է սխալ։

**Պարամետրեր**

* `username` - Օգտագործողի մուտքանունը (ներքին անունը)։
* `apiClientId` - Կլիենտ ծրագրի id-ն (API Client Id)։
* `secret` - Կլիենտ ծրագրի բանալի (API Client Secret)։
* `cancellationToken` - Ընդհատման օբյեկտ։

**Օրինակ**

Տե՛ս օգտագործման [օրինակը](../examples/AuthenticationClient.md)։
