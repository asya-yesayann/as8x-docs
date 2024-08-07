---
layout: page
title: "GridLoadMode" 
tags: GridLoadMode
---

Այս enum-ը նախատեսված է փաստաթղթի բեռնման ժամանակ աղյուակների բեռնման ռեժիմը սահմանելու համար։

```c#
public enum GridLoadMode
{
    None = 0,
    Full = 1
}
```

**Արժեքների բազմություն**

* `None` - Ոչ մի աղյուսակ չի բեռնվում։
* `Full` - Բեռնվում են բոլոր աղյուսակները։
