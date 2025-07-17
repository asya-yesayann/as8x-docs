---
title: IFactService.SetAccCrd(Fact, string, bool) մեթոդ
---

```c#
public Task SetAccCrd(Fact fact, string value, bool uncheck = false);
```

Նշանակում է գործառնության կրեդիտային հաշիվը։

**Պարամետրեր**

* `fact` - Գործառնության օբյեկտ։
* `value` - Վերագրվող արժեք։
* `uncheck` - `false` արժեքի դեպքում ստուգվում է վերագրվող հաշվի առկայությունը [հաշվառում](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Defs/Accounting.html) համակարգային նկարագրության AccFolder թղթապանակում, որտեղ նշվում են դեբետի կամ կրեդիտի թղթակցությանը մասնակցող հաշիվները։
