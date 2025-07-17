---
title: IKernelService.GetTurnBetween(string, int, DateTime, DateTime, string, bool) մեթոդ
---

```c#
public Task<List<(DateTime Date, decimal DbTurn, decimal DbTurnAMD, 
                  decimal CrTurn, decimal CrTurnAMD)>> GetTurnBetween(
    string accounting, int isn, DateTime startDate, DateTime endDate, 
    string codeOper = "", bool bNotShowSameClAccTurn = false)
```

Վերադարձնում է փաստաթղթի հաշվառվման ամենօրյա շրջանառությունների ցուցակ նշված ժամանակահատվածի համար։

Վերադարձնում է կորտեժների ցուցակ՝
* `Date` - Միջակայքից ամսաթիվ, որով առկա է շրջանառություն։
* `DbTurn` - Դեբետային շրջանառությունը նշված ամսաթվով։
* `DbTurnAMD` - Դեբետային շրջանառության դրամային համարժեքը նշված ամսաթվով։
* `CrTurn` - Կրեդիտային շրջանառությունը նշված ամսաթվով։
* `CrTurnAMD` - Կրեդիտային շրջանառության դրամային համարժեքը նշված ամսաթվով։

**Պարամետրեր**

* `accounting` - Հաշվառման կոդ (ներքին անուն):
* `isn` - Հաշվառվող օբյեկտի ներքին նույնականացման համար։
* `startDate` - Ժամանակաշրջանի սկզբի ամսաթիվ։
* `endDate` - ժամանակաշրջանի վերջին ամսաթիվ։
* `codeOper` - Հաշվառման գործողության կոդը, որի շրջանառությունները կվերադարձվի։
* `bNotShowSameClAccTurn` - **true** արժեքի դեպքում ֆիլտրվում են և չեն վերադարձվում հաճախորդի սեփական հաշիվների միջև գործողությունները։
