---
title: IKernelService.LastHI2OpDate(string, int, int, DateTime?, string) մեթոդ
---

```c#
public Task<DateTime?> LastHI2OpDate(string accCode, int isn = -1, 
                                     int glIsn = -1, DateTime? upToDate = null, 
                                     string op = "")
```

Վերադարձնում է փաստաթղթի [HI2](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/Hi2.html) աղյուսակում գրանցվող հաշվառման վերջին նշանակված գործողության ամսաթիվը, որը ստեղծվել է հաշվառման նշված կոդով մինչև նշված ամսաթիվը ներառյալ։

**Պարամետրեր**

* `accCode` - Հաշվառման կոդ (ներքին անուն):
* `isn` - Հաշվառվող օբյեկտի ներքին նույնականացման համար։
* `glIsn` - Կուտակող օբյեկտի ներքին նույնականացման համար։
* `upToDate` - Ամսաթիվը, մինչև որը կատարվում է որոնումը։ 
  Եթե պարամետրը տրված չէ, ապա վերադառնում է տվյալ հաշվառման մեջ վերջին գործողության ամսաթիվը։
* `op` - Հաշվառման որոնվող գործողություն։
