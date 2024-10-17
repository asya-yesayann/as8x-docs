---
layout: page
title: "IAccountingService սերվիս" 
tags: Accounting
---

## Բովանդակություն

- [Ներածություն](#ներածություն)
- [Մեթոդներ](#մեթոդներ)
  - [CalculateCacheRem](#calculatecacherem)
  - [CalculateCacheRemFull](#calculatecacheremfull)
  - [Create](#create)
  - [GetLastHI2Rem](#getlasthi2rem)
  - [GetLinkedAccounting](#getlinkedaccounting)

## Ներածություն

IAccountingService դասը նախատեսված է հաշվառման հետ աշխատանքը ապահովելու համար։

## Մեթոդներ

### CalculateCacheRem

```c#
public Task CalculateCacheRem(string accountingType, int isn)
```

Հաշվում է Հաշվառվող օբյեկտի սկզբնական, վերջնական մնացորդները և գրանցում տվյալների պահոցի [HIREST](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/Hirest.html) աղյուսակում։

**Պարամետրեր**

* `accountingType` - Հաշվառման կոդ (ներքին անուն):
* `isn` - Հաշվառման օբյեկտի ներքին նույնականացման համար։

### CalculateCacheRemFull

```c#
public Task CalculateCacheRemFull(string accountingType, DateTime? cacheDate1, DateTime? cacheDate2, 
                                  DateTime? cacheDate3, DateTime? cacheDate4, DateTime? cacheDate5)
```

Հաշվում է հաշվառվող օբյեկտի միջանկյալ մնացորդները նշված ամսաթվերի դրությամբ և գրանցում տվյալների պահոցի [HIREST](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/Hirest.html) աղյուսակում։

**Պարամետրեր**

* `accountingType` - Հաշվառման կոդ (ներքին անուն):
* `cacheDate1` - Առաջին ամսաթիվը, որի համար հաշվարկվում է մնացորդը:
* `cacheDate2` - Երկրորդ ամսաթիվը, որի համար հաշվարկվում է մնացորդը։
* `cacheDate3` - Երրորդ ամսաթիվը, որի համար հաշվարկվում է մնացորդը։
* `cacheDate4` - Չորրորդ ամսաթիվը, որի համար հաշվարկվում է մնացորդը։
* `cacheDate5` - Հինգերորդ ամսաթիվը, որի համար հաշվարկվում է մնացորդը։

### Create 

```c#
public Accounting Create(string name)
```

Ստեղծում է և վերադարձնում [Accounting](../definitions/accounting.md) դասի նոր օբյեկտ։

**Պարամետրեր**

* `name` - Հաշվառման կոդ (ներքին անուն):

### GetLastHI2Rem

```c#
public Task<(decimal AMDRem, decimal CurRem)> GetLastHI2Rem(string accounting, int isn, int isnGl = -1)
```

Վերադարձնում է 
* `AMDRem` - Հաշվառվող օբյեկտի վերջնական մնացորդը դրամային արտարժույթով [HI2](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/Hi2.html) հաշվառումների համար։
* `CurRem` - Հաշվառվող օբյեկտի վերջնական մնացորդը հաշվի արտարժույթով [HI2](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/Hi2.html) հաշվառումների համար։

Մնացորդը կա՛մ գումարային է ըստ բոլոր կուտակող օբյեկտների է, կա՛մ միայն `isnGl`-ով փոխանցվածի։

**Պարամետրեր**

* `accounting` - Հաշվառման կոդ (ներքին անուն):
* `isn` - Հաշվառվող հիմնական օբյեկտի ներքին նույնականացման համար։
* `isnGl` - Հաշվառվող կուտակող օբյեկտի ներքին նույնականացման համար։ Չփոխանցելու դեպքում մեթոդը վերադարձնում է վերջնական գումարային մնացորդը՝ ըստ բոլոր կուտակող օբյեկտների։

### GetLinkedAccounting

```c#
public string GetLinkedAccounting(ref string acc)
```

Վերադարձնում է տրված կոդով հաշվառմանը կից հաշվառման կոդը։

**Պարամետրեր**

* `accounting` - Հաշվառման կոդ (ներքին անուն):
