---
layout: page
title: "LoanApplicationsRoutes" 
---

## Բովանդակություն

- [Ներածություն](#ներածություն)
- [Մեթոդներ](#մեթոդներ)
  - [GetAll](#getall)
  - [Sign](#sign)
  - [GetPrintForms](#getprintforms)
  - [Create](#create)

## Ներածություն

LoanApplicationsRoutes դասը նախատեսված է վարկային հայտերի հետ աշխատանքը ապահովելու համար։

## Մեթոդներ

### GetAll

```c#
public async Task<GetAllResponse> GetAll(GetAllRequest request)
```

Վերադարձնում է հաճախորդի բոլոր վարկային հայտերի տվյալները։

**Պարամետրեր**

* `request` - Հաճախորդի և վարկային հայտի տվյալները՝ հաճախորդի կոդ, վարկի համար:

### Sign

```c#
public async Task<SignResponse> Sign(SignRequest request)
```

Ստորագրում է վարկային հայտը՝ այն հաստատելով կամ մերժելով և վերադարձնում է հայտի տվյալները։

**Պարամետրեր**

* `request` - Վարկային հայտի տվյալները և կատարվող գործողության տեսակը՝ մերժում կամ հաստատում։

### GetPrintForms

```c#
public async Task<LoanApplications.GetPrintFormsResponse> GetPrintForms(GetPrintFormsRequest request)
```

Վերադարձնում է վարկային հայտի տպելու ձևանմուշների տվյալները և պարունակությունը ցուցակով։

**Պարամետրեր**

* `request` - Վարկային հայտի տվյալները և անհրաժեշտ տպելու ձևանմուշների տեսակների ցուցակը։

### Create

```c#
public async Task<CreateResponse> Create(CreateRequest request)
```

Ստեղծում է վարկային հայտ, որը հաստատելու կամ մերժելու համար անհրաժեշտ է կանչել [Sign](#sign) մեթոդը։

**Պարամետրեր**

* `request` - Բացվող վարկային հայտի տվյալները։




