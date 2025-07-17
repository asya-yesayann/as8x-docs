---
title: IKernelService.GetTurnHI2(string, int, int, DateTime, DateTime, string, int) մեթոդ
---

```c#
public Task<(decimal DbTurn, decimal DbTurnAMD, decimal CrTurn, decimal CrTurnAMD)> GetTurnHI2(
    string accounting, int isn, int isnGl, DateTime startDate, DateTime endDate, 
    string codeOper = "", int baseIsn = -1)
```

Վերադարձնում է փաստաթղթի [HI2](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/Hi2.html) աղյուսակում գրանցվող հաշվառման դեբետային և կրեդիտային շրջանառության արժեքները ըստ տրված կուտակող օբյեկտի և տրված ժամանակաշրջանի համար։

Վերադարձնում է կորտեժ`
* `DbTurn` - Դեբետային շրջանառության արժեքը։
* `DbTurnAMD` - Դեբետային շրջանառության արժեքը դրամային համարժեքը։
* `CrTurn` - Կրեդիտային շրջանառության արժեքը։
* `CrTurnAMD` - Կրեդիտային շրջանառության արժեքը դրամային համարժեքը։

**Պարամետրեր**

* `accounting` - Հաշվառման կոդ (ներքին անուն):
* `isn` - Հաշվառվող օբյեկտի ներքին նույնականացման համար։
* `isnGl` - Կուտակող օբյեկտի ներքին նույնականացման համար։
* `startDate` - Ժամանակաշրջանի սկզբի ամսաթիվ։
* `endDate` - ժամանակաշրջանի վերջին ամսաթիվ։
* `codeOper` - Հաշվառման գործողության կոդը, որի շրջանառությունները կվերադարձվի։
* `baseIsn` - Հիմքային փաստաթղթի ներքին նույնականացման համար։
