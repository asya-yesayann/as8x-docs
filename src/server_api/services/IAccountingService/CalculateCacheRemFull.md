---
title: IAccountingService.CalculateCacheRemFull(string, DateTime?, DateTime?, DateTime?, DateTime?, DateTime?) մեթոդ
---

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
