---
title: IFactService.SetAccDeb(Fact, string, bool) մեթոդ
---

```c#
public Task SetAccDeb(Fact fact, string value, bool uncheck = false);
```

Նշանակում է գործառնության դեբետային հաշիվը։

**Պարամետրեր**

* `fact` - Գործառնության օբյեկտ։
* `value` - Վերագրվող արժեք։
* `uncheck` - `false` արժեքի դեպքում ստուգվում է վերագրվող հաշվի առկայությունը [հաշվառում](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Defs/Accounting.html) համակարգային նկարագրության AccFolder թղթապանակում, որտեղ նշվում են դեբետի կամ կրեդիտի թղթակցությանը մասնակցող հաշիվները։
