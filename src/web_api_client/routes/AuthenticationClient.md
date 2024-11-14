---
layout: page
title: "AuthenticationClient" 
---

## Բովանդակություն

- [Ներածություն](#ներածություն)
- [Կոնստրուկտոր](#կոնստրուկտոր)
- [Մեթոդներ](#մեթոդներ)
  - [AuthenticateWithCertificateAsync](#authenticatewithcertificateasync)
  - [AuthenticateWithSecretAsync](#authenticatewithsecretasync)

## Ներածություն

8X սերվիս լոգին լինելու համար անհրաժեշտ է նախապես սահմանել մուտք գործող կլիենտ ծրագիր։

Այն անհրաժեշտ է ստեղծել 4X կամ 8X համակարգի UI-ից "**API Client-ներ**" դիտելու ձևից "**Ավելացնել**" կոնտեքստային ֆունկցիայով՝ նշելով կլիենտի վավերականացման եղանակը (սերտիֆիկատով կամ բանալիով) և նկարագրելով Json ֆորմատի **Manifest** ֆայլ, որը սահմանում է կլիենտ ծրագրի իրավասությունները և սահմանափակումները (որ օգտագործողները կարող են մուտք գործել համակարգ, որ տվյալների աղբյուրներին, փաստաթղթերին, DPR-ներին կարող են դիմել ու որ API կանչերը կատարել)։

![api_client_add](../images/api_client_add.png)

Իսկ կլիենտի ծրագրի միջոցով մուտք գործող օգտագործողի նույնականացումը կատարվում է այս դասի մեթոդների միջոցով։

## Կոնստրուկտոր

```c#
public class AuthenticationClient(string baseUrl, HttpClient httpClient, ILogger logger)
```

**Պարամետրեր**

* `baseUrl` - Սերվիսի հասցեն։
* `httpClient` - [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient) դասի օբյեկտ, որը նախատեսված է `AuthenticationClient` դասի մեթոդների միջոցով նույնականացման ընթացքում դեպի Web API հարցումներ կատարելու համար։
* `logger` - [ILogger](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger) դասի օբյեկտ, որը նախատեսված է `AuthenticationClient` դասի մեթոդների միջոցով նույնականացման ընթացքում առաջացած սխալների լոգավորման համար։ 

## Մեթոդներ

### AuthenticateWithCertificateAsync

```c#
public Task<CertificateAuthenticateResponse> AuthenticateWithCertificateAsync(CertificateAuthenticateRequest certificateAuthenticateRequest, CancellationToken cancellationToken = default)
```

Նույնականացնում է սերտիֆիկատով նույնականացված կլիենտ ծրագրի օգտագործողի մուտքը համակարգ։ Նույնականացման հաջողման դեպքում վերադարձնում է [օգտագործողի տվյալները և տոկեն՝ դեպի սերվիս հարցումներ կատարելու համար](../types/CertificateAuthenticateResponse.md), հակառակ դեպքում վերադարձնում է սխալ։

**Պարամետրեր**

* `certificateAuthenticateRequest` - [Նույնականացման ենթակա օգտագործողի և այն ծրագրի տվյալները, որով օգտագործողը մուտք է գործում համակարգ](../types/CertificateAuthenticateRequest.md)։
* `cancellationToken` - Ընդհատման տոկեն։

### AuthenticateWithSecretAsync

```c#
public Task<AuthenticateResponse> AuthenticateWithSecretAsync(string username, short apiClientId, string secret, CancellationToken cancellationToken = default)
```

Նույնականացնում է բանալիով նույնականացված կլիենտ ծրագրի օգտագործողի մուտքը համակարգ։ Նույնականացման հաջողման դեպքում վերադարձնում է [օգտագործողի տվյալները և տոկեն՝ դեպի սերվիս հարցումներ կատարելու համար](../types/AuthenticateResponse.md), հակառակ դեպքում վերադարձնում է սխալ։

**Պարամետրեր**

* `username` - Օգտագործողի մուտքանունը (ներքին անունը)։
* `apiClientId` - Կլիենտ ծրագրի id-ն, որով մուտք է գործում օգտագործողը։
* `secret` - Կլիենտ ծրագրի բանալին։
* `cancellationToken` - Ընդհատման տոկեն։

**Օրինակ**

```c#
private async Task Authenticate()
{
  using var httpClient = new HttpClient();
  var serviceAdress = "https://services8x/dbank6";

  var secret = "WsAlki3DPVhncIrP0a4r7GhoXAPFvVvFiihP9mOiNhdsgA9azVuZeGCYByRqS7ofJW7HQqswzc0I4dTCt4ycyVLEyuvHmA9U2YscZQvo0cAsvrAf267224JExaYFNRA";
  var userName = "ADMIN";
  var clientId = 54;

  // ստեղծում է AuthenticationClient դասի օբյեկտ՝ փոխանցելով սերվիսի հասցեն ու HttpClient դասի օբյեկտ՝ Web API-ին հարցումները ապահովելու համար
  var client = new AuthenticationClient(httpClient, serviceAdress, null);

  // նույնականացնում է բանալիով կլիենտ ծրագրի օգտագործողին AuthenticateWithSecretAsync մեթոդի միջոցով՝
  // փոխանցելով օգտագործողի մուտքանունը, կլիենտ ծրագրի id-ն ու բանալին
  var authenticateResponse = await client.AuthenticateWithSecretAsync(userName, clientId, secret);

  // նույնականացման արդյունքում վերադարձված օբյեկտի Token հատկությունն ենք ստանում, 
  // որը անհրաժեշտ է կլիենտից սերվիս կատարվող հարցումների նույնականացման համար
  var token = authenticateResponse.Token;
}
```
