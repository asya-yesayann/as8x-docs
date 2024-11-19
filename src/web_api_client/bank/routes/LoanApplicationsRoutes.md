---
layout: page
title: "LoanApplicationsRoutes" 
---

## Բովանդակություն

- [Ներածություն](#ներածություն)
- [Մեթոդներ](#մեթոդներ)
  - [Create](#create)
  - [GetAll](#getall)
  - [GetPrintForms](#getprintforms)
  - [Sign](#sign)

## Ներածություն

LoanApplicationsRoutes դասը նախատեսված է վարկային հայտերի հետ աշխատանքը ապահովելու համար։

## Մեթոդներ

### Create

```c#
public async Task<CreateResponse> Create(CreateRequest request)
```

Ստեղծում է վարկային հայտ, որը հաստատելու կամ մերժելու համար անհրաժեշտ է կանչել [Sign](#sign) մեթոդը։

**Պարամետրեր**

* `request` - Բացվող վարկային հայտի տվյալները։

**Օրինակ**

Տե՛ս օգտագործման [օրինակը](../examples/LoanApplicationsRoutes.md#վարկային-հայտի-ստեղծման-օրինակ)։

### GetAll

```c#
public async Task<GetAllResponse> GetAll(GetAllRequest request)
```

Վերադարձնում է հաճախորդի բոլոր վարկային հայտերի տվյալները։

**Պարամետրեր**

* `request` - Հաճախորդի և վարկային հայտի տվյալները՝ հաճախորդի կոդ, վարկի համար:

### GetPrintForms

```c#
public async Task<LoanApplications.GetPrintFormsResponse> GetPrintForms(GetPrintFormsRequest request)
```

Վերադարձնում է վարկային հայտի տպելու ձևանմուշների տվյալները և պարունակությունը ցուցակով։

**Պարամետրեր**

* `request` - Վարկային հայտի տվյալները և անհրաժեշտ տպելու ձևանմուշների տեսակների ցուցակը։

**Օրինակ**

Տե՛ս օգտագործման [օրինակը](../examples/LoanApplicationsRoutes.md#վարկային-հայտի-տպելու-ձևանմուշների-վերադարձման-և-օգտագործման-օրինակ)։

### Sign

```c#
public async Task<SignResponse> Sign(SignRequest request)
```

Ստորագրում է վարկային հայտը՝ այն հաստատելով կամ մերժելով և վերադարձնում է հայտի տվյալները։

**Պարամետրեր**

* `request` - Վարկային հայտի տվյալները և կատարվող գործողության տեսակը՝ մերժում կամ հաստատում։

**Օրինակ**

Տե՛ս օգտագործման [օրինակը](../examples/LoanApplicationsRoutes.md#վարկային-հայտի-ստորագրման-օրինակ)։




