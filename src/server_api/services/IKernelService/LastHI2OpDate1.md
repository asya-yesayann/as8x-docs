---
title: IKernelService.LastHI2OpDate(List<string>, int, int, DateTime?, string) մեթոդ
---

```c#
public Task<DateTime?> LastHI2OpDate(List<string> accCodes, int isn = -1, 
                                     int glIsn = -1, DateTime? upToDate = null, 
                                     string op = "")
```

Վերադարձնում է փաստաթղթի [HI2](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/Hi2.html) աղյուսակում գրանցվող հաշվառման վերջին նշանակված գործողության ամսաթիվը, որը ստեղծվել է հաշվառման նշված կոդերով մինչև նշված ամսաթիվը ներառյալ։

**Պարամետրեր**

* `accCodes` - Հաշվառումների կոդերի ցուցակ:
* `isn` - Հաշվառվող օբյեկտի ներքին նույնականացման համար։
* `glIsn` - Կուտակող օբյեկտի ներքին նույնականացման համար։
* `upToDate` - Ամսաթիվը, մինչև որը կատարվում է որոնումը։ 
  Եթե պարամետրը տրված չէ, ապա վերադառնում է տվյալ հաշվառման մեջ վերջին գործառույթի ամսաթիվը։
* `op` - Հաշվառման որոնվող գործողություն։
