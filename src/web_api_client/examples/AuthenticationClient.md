---
layout: page
title: "AuthenticationClient օրինակ" 
---

Բանալիով կլիենտ ծրագրի օգտագործողի նույնականացման օրինակ:

```c#
private async Task Authenticate()
{
  using var httpClient = new HttpClient();
  var serviceAdress = "https://services8x/dbank6";
  var clientId = 54;
  var secret = "WsAlki3DPVhncIrP0a4r7GhoXAPFvVvFiihP9mOiNhdsgA9azVuZeGCYByRqS7ofJW7HQqswzc0I4dTCt4ycyVLEyuvHmA9U2YscZQvo0cAsvrAf267224JExaYFNRA";
  var userName = "ADMIN";

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
