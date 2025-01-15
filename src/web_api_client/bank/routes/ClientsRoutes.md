---
layout: page
title: "ClientsRoutes դաս" 
sublinks:
- { title: "CreateClientFromEkeng", ref: createclientfromekeng }
- { title: "CreatePhysicalClientByFullData", ref: createphysicalclientbyfulldata }
---

## Բովանդակություն

- [Ներածություն](#ներածություն)
- [Մեթոդներ](#մեթոդներ)
  - [CreateClientFromEkeng](#createclientfromekeng)
  - [CreatePhysicalClientByFullData](#createphysicalclientbyfulldata)

## Ներածություն

ClientsRoutes դասը պարունակում է մեթոդներ հաճախորդների տվյալների հետ աշխատանքը ապահովելու համար։
Այն հասանելի է [BankApiClient](../types/BankApiClient.md) դասի միջից։

## Մեթոդներ

### CreateClientFromEkeng

```c#
public Task<CreatePhysicalClientByFullDataResponse> CreateClientFromEkeng(
    CreateClientFromEkengRequest request)
```

Ստեղծում է ֆիզ. անձ հաճախորդ ստանալով նույնականացման փաստաթղթի համարը (սոց.քարտ, անձնագիր...), իսկ հիմնական տվյալները ստանալով [ԷԿԵՆԳ](https://www.ekeng.am) համակարգից:
Եթե այդ տվյալներով հաճախորդ առկա է համակարգում, ապա նոր հաճախորդ չի ստեղծվում։
Վերադարձնում հաճախորդի ստեղծված լինելու մասին տվյալներ՝ հաճախորդի կոդ, ստեղված հաճախորդի վիճակը վերջնական է, թե ոչ։

**Պարամետրեր**

* `request` - Ավելացվող հաճախորդի տվյալներ։

**Օրինակ**

Տե՛ս օգտագործման [օրինակը](../examples/ClientsRoutes.md#օրինակ-1)։

### CreatePhysicalClientByFullData

```c#
public Task<CreatePhysicalClientByFullDataResponse> CreatePhysicalClientByFullDat(
    CreatePhysicalClientByFullDataRequest request)
```

Ստեղծում է նոր ֆիզ. անձ հաճախորդ ըստ հաճախորդի հիմնական տվյալների։ 
Վերադարձնում հաճախորդի ստեղծված լինելու մասին տվյալներ՝ հաճախորդի կոդ, ստեղված հաճախորդի վիճակը վերջնական է, թե ոչ։

**Պարամետրեր**

* `request` - Ավելացվող հաճախորդի տվյալներ։

**Օրինակ**

Տե՛ս օգտագործման [օրինակը](../examples/ClientsRoutes.md#օրինակ-2)։
