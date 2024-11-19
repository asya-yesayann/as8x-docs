---
layout: page
title: "ClientsRoutes" 
---

## Բովանդակություն

- [Ներածություն](#ներածություն)
- [Մեթոդներ](#մեթոդներ)
  - [CreatePhysicalClientByFullData](#createphysicalclientbyfulldata)

## Ներածություն

ClientsRoutes դասը նախատեսված է հաճախորդների տվյալների հետ աշխատանքը ապահովելու համար։

## Մեթոդներ

### CreatePhysicalClientByFullData

```c#
public Task<CreatePhysicalClientByFullDataResponse> CreatePhysicalClientByFullData(CreatePhysicalClientByFullDataRequest request)
```

Ավելացնում է նոր հաճախորդ և վերադարձնում հաճախորդի հիմնական տվյալներ՝ հաճախորդի կոդ, ստեղված հաճախորդի վիճակը վերջնական է թե ոչ։


**Պարամետրեր**

* `request` - Ավելացվող հաճախորդի տվյալներ։

**Օրինակ**

Տե՛ս օգտագործման [օրինակը](../examples/ClientsRoutes.md#նոր-ֆիզ-անձ-հաճախորդի-ստեղծման-օրինակ)։