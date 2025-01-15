---
layout: page
title: "AccountsRoutes դաս" 
sublinks:
- { title: "CreateGeneralAccForCli", ref: creategeneralaccforcli }
---

## Բովանդակություն

- [Ներածություն](#ներածություն)
- [Մեթոդներ](#մեթոդներ)
  - [CreateGeneralAccForCli](#creategeneralaccforcli)

## Ներածություն

AccountsRoutes դասը պարունակում է մեթոդներ հաշիվների տվյալների հետ աշխատանքը ապահովելու համար։
Այն հասանելի է [BankApiClient](../types/BankApiClient.md) դասի միջից։

## Մեթոդներ

### CreateGeneralAccForCli

```c#
public Task<CreateGeneralAccResponse> CreateGeneralAccForCli(CreateGeneralAccRequest request)
```

Ստեղծում է հաճախորդի հաշվարկային հաշիվ ստանալով հաճախորդին և արժույթը։
Վերադարձնում ստեղծված հաշվի համարը։

**Պարամետրեր**

* `request` - Ավելացվող հաճախորդի տվյալներ։

**Օրինակ**

Տե՛ս օգտագործման [օրինակը](../examples/AccountsRoutes.md#օրինակ-1)։
