---
title: RODocumentService.Load(int, bool, bool, bool, bool) մեթոդ
---

```c#
public Task<RODocument> Load(int isn,
                             bool loadGrids = true,
                             bool throwExceptionIfDeleted = true,
                             bool lookInArc = true,
                             bool loadImagesAndMemos = false)
```

Բեռնում է փաստաթուղթը տվյալների պահոցից ըստ փաստաթղթի ներքին նույնականացման համարի։

Վերադարձնում է [քեշավորվող փաստաթղթի](../../types/RODocument.md) օբյեկտը, եթե հայտնաբերվել է։
Եթե չի հայտնաբերվել առաջացնում է սխալ կամ վերադարձնում է **null** կախված throwExceptionIfDeleted պարամետրից։

**Պարամետրեր**

* `isn` - Բեռնվող փաստաթղթի ներքին նույնականացման համարը։
* `loadGrids` - Փաստաթղթի աղյուսակների բեռնման հայտանիշ։
* `throwExceptionIfDeleted` - Պահանջվող փաստաթղթի հեռացված լինելու դեպքում սխալի գեներացման հայտանիշ։ 
* `lookInArc` - Արխիվացված փաստաթղթի բեռնման հայտանիշ։ **true** արժեքի դեպքում փաստաթուղթը հիմնական պահոցում չգտնելու դեպքում փորձում է բեռնել նաև արխիվային տվյալների պահոցից։
* `loadImagesAndMemos` - Փաստաթղթի նկարների ու մեծ մուտքագրման դաշտերի (մեմո) բեռնման հայտանիշ։
