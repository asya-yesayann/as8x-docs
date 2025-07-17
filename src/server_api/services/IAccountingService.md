---
title: "IAccountingService սերվիս"
---

## Ներածություն

IAccountingService դասը նախատեսված է հաշվառման հետ աշխատանքը ապահովելու համար։

## Մեթոդներ

| Անվանում | Նկարագրություն |
|----------|----------------|
| [CalculateCacheRem](IAccountingService/CalculateCacheRem.md) | Հաշվում է Հաշվառվող օբյեկտի սկզբնական, վերջնական մնացորդները և գրանցում տվյալների պահոցի [HIREST](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/Hirest.html) աղյուսակում։ |
| [CalculateCacheRemFull](IAccountingService/CalculateCacheRemFull.md) | Հաշվում է հաշվառվող օբյեկտի միջանկյալ մնացորդները նշված ամսաթվերի դրությամբ և գրանցում տվյալների պահոցի [HIREST](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/Hirest.html) աղյուսակում։ |
| [Create](IAccountingService/Create.md) | Ստեղծում է և վերադարձնում [Accounting](../definitions/accounting.md) դասի նոր օբյեկտ։ |
| [GetLinkedAccounting](IAccountingService/GetLinkedAccounting.md) | Վերադարձնում է տրված կոդով հաշվառմանը կից հաշվառման կոդը։ |

## Հատկություններ

| Անվանում | Նկարագրություն |
|----------|----------------|
| [GetLastHI2Rem](IAccountingService/GetLastHI2Rem.md) | * `AMDRem` - Հաշվառվող օբյեկտի վերջնական մնացորդը դրամային արտարժույթով [HI2](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/Hi2.html) հաշվառումների համար։ |