---
layout: page
title: "LoginService օրինակ" 
---

Բանալիով կլիենտ ծրագրի օգտագործողի նույնականացման օրինակ:

```c#
using var httpClient = new HttpClient();
var loginService = new LoginService();

var serviceAdress = "https://services8x/dbank6";
var apiClientId = 51;
var secret = "WsAlki3DPVhncIrP0a4r7GhoXAPFvVvFiihP9mOiNhdsgA9azVuZeGCYByRqS7ofJW7HQqswzc0I4dTCt4ycyVLEyuvHmA9U2YscZQvo0cAsvrAf267224JExaYFNRA";
var userName = "ADMIN";

// նույնականացնում է 51 id-ով և բանալիով նույնականացվող կլիենտ ծրագրի ADMIN մուտքանունով օգտագործողին 
loginService.Authenticate(serviceAdress, httpClient, null, apiClientId, secret, userName);
```