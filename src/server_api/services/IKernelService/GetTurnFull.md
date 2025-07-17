---
title: IKernelService.GetTurnFull(string, int, DateTime, DateTime) մեթոդ
---

```c#
public Task<(decimal DbTurn, decimal DbTurnAMD, 
            decimal CrTurn, decimal CrTurnAMD, 
            decimal Rem, decimal RemAMD, 
            decimal StartRem, decimal StartRemAMD)> GetTurnFull(
    string accounting, int isn, DateTime startDate, DateTime endDate)
```

Վերադարձնում է փաստաթղթի հաշվառման դեբետային և կրեդիտային շրջանառության արժեքները տրված ժամանակաշրջանի համար, ինչպես նաև սկզբնական և վերջնական մնացորդները։

Վերադարձնում է կորտեժ`
* `DbTurn` - Դեբետային շրջանառությունը։
* `DbTurnAMD` - Դեբետային շրջանառության դրամային համարժեքը։
* `CrTurn` - Կրեդիտային շրջանառությունը։
* `CrTurnAMD` - Կրեդիտային շրջանառության դրամային համարժեքը։
* `Rem` - Ժամանակաշրջանի վերջնական մնացորդը։
* `RemAMD` - Ժամանակաշրջանի վերջնական մնացորդի դրամային համարժեքը։
* `StartRem` - Ժամանակաշրջանի սկզբնական մնացորդը։
* `StartRemAMD` - Ժամանակաշրջանի սկզբնական մնացորդի դրամային համարժեքը։

**Պարամետրեր**

* `accounting` - Հաշվառման կոդ (ներքին անուն):
* `isn` - Հաշվառվող օբյեկտի ներքին նույնականացման համար։
* `startDate` - Ժամանակաշրջանի սկզբի ամսաթիվ։
* `endDate` - ժամանակաշրջանի վերջին ամսաթիվ։
