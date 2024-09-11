---
layout: page
title: "StoreMode" 
---

## Փաստաթղթի պահպանման ռեժիմը

Այս դասը նախատեսված է փաստաթղթի պահպանման ռեժիմի սահմանման համար։  
Տե՛ս [Document](../definitions/document.md).[StoreMode](../definitions/document.md#storemode) հատկությունը։


```c#
public enum StoreMode
{
    Draft = 0,
    StartProcessing = 1,
    ContinueProcessing = 2,
    SecondInput = 3,
    NotConfirmed = 4,
    Confirmed = 5,
    Import = 6
}
```

**Արժեքների բազմություն**

- `Draft` - Փաստաթուղթը պահվում է 0 վիճակով։
- `StartProcessing` - Փաստաթուղթը պահվում է և սկսվում է անցումը 0-ից 1:
- `ContinueProcessing` - Փաստաթուղթը պահվում է և շարունակվում գործընթացը։
- `SecondInput` - Փաստաթղթի կրկնակի մուտքագրում։
- `NotConfirmed` - Փաստաթուղթը մերժվել է։
- `Confirmed` - Փաստաթուղթը վավերացվում է։
- `Import` - Փաստաթղթի ներմուծում։
