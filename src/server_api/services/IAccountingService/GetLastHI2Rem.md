---
title: IAccountingService.GetLastHI2Rem(string, int, int) մեթոդ
---

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
