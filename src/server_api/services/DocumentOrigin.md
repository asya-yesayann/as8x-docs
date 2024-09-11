---
layout: page
title: "DocumentOrigin" 
tags: DocumentOrigin
---

## Փաստաթղթի ստեղծման աղբյուր

Այս enum-ը նախատեսված է փաստաթղթի փաստաթղթի ստեղծման աղբյուրի սահմանման համար։

```c#
public enum DocumentOrigin
{
    Unknown = 0,
    As4xUI = 1,
    As4xScript = 2,
    AsService = 3,
    As8xUI = 4,
    As8xUICode = 5
}
```

**Արժեքների բազմություն**

* `Unknown` - Փաստաթղթի ստեղծման աղբյուրը անհայտ է։
* `As4xUI` - Փաստաթուղթը ստեղծվել է 4X UI-ում:
* `As4xScript` - Փաստաթուղթը ստեղծվել է 4X սկրիպտում:
* `AsService` - Փաստաթուղթը ստեղծվել է 8X սերվիսում:
* `As8xUI` - Փաստաթուղթը ստեղծվել է 8X UI-ում:
* `As8xUICode` - Փաստաթուղթը ստեղծվել է 8X UI-ի կոդում:
