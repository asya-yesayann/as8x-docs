---
layout: page
title: "LoanApplicationsRoutes դաս" 
sublinks:
- { title: "Create", ref: create }
- { title: "GetAll", ref: getall }
- { title: "GetPrintForms", ref: getprintforms }
- { title: "Sign", ref: sign }
---

## Բովանդակություն

- [Ներածություն](#ներածություն)
- [Մեթոդներ](#մեթոդներ)
  - [Create](#create)
  - [GetAll](#getall)
  - [GetPrintForms](#getprintforms)
  - [Sign](#sign)

## Ներածություն

LoanApplicationsRoutes դասը պարունակում է մեթոդներ հաճախորդների տվյալների հետ աշխատանքը ապահովելու համար։
Այն հասանելի է [BankApiClient](../types/BankApiClient.md) դասի միջից։

## Մեթոդներ

### Create

```c#
public async Task<CreateResponse> Create(CreateRequest request)
```

Ստեղծում է վարկային հայտ ըստ հաճախորդի հայտի տվյալների։

**Պարամետրեր**

* `request` - Բացվող վարկային հայտի տվյալները։

**Օրինակ**

Տե՛ս օգտագործման [օրինակը](../examples/LoanApplicationsRoutes.md#օրինակ-1)։

### GetAll

```c#
public async Task<GetAllResponse> GetAll(GetAllRequest request)
```

Վերադարձնում է հաճախորդի բոլոր վարկային հայտերի տվյալները։

**Պարամետրեր**

* `request` - Հաճախորդի և վարկային հայտի տվյալները՝ հաճախորդի կոդ, վարկի համար:

**Օրինակ**

Տե՛ս օգտագործման [օրինակը](../examples/LoanApplicationsRoutes.md#օրինակ-4)։

### GetPrintForms

```c#
public async Task<LoanApplications.GetPrintFormsResponse> GetPrintForms(GetPrintFormsRequest request)
```

Վերադարձնում է վարկային հայտի լրացված տպելու ձևանմուշների տվյալները և պարունակությունը ցուցակով։
Հնարավոր է ստանալ «Պայմանագիրը», «Արբիտրաժային համաձայնագիրը» և «Անհատական թերթիկ»։

**Պարամետրեր**

* `request` - Վարկային հայտի կոդը և անհրաժեշտ տպելու ձևանմուշների տեսակների ցուցակը։

**Օրինակ**

Տե՛ս օգտագործման [օրինակը](../examples/LoanApplicationsRoutes.md#օրինակ-3)։

### Sign

```c#
public async Task<SignResponse> Sign(SignRequest request)
```

Հաստատում կամ մերժում վարկային հայտը, եթե այն գտնվում է համապատասխան վիճակում։

**Պարամետրեր**

* `request` - Վարկային հայտի տվյալները և կատարվող գործողության տեսակը՝ մերժում կամ հաստատում։

**Օրինակ**

Տե՛ս օգտագործման [օրինակը](../examples/LoanApplicationsRoutes.md#օրինակ-2)։
