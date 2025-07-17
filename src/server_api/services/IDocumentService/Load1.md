---
title: IDocumentService.Load(int, GridLoadMode, bool, bool, bool, bool, bool) մեթոդ
---

```c#
public Task<T> Load<T>(int isn, GridLoadMode gridLoadMode = GridLoadMode.Full, 
                       bool loadImagesAndMemos = true, bool lockTableRow = false, 
                       bool throwExceptionIfDeleted = true, bool lookInArc = true, 
                       bool loadParents = false) where T : Document
```

Բեռնում է տվյալների պահոցում գոյություն ունեցող փաստաթուղթը ըստ ներքին նույնականացման համարի։

Վերադարձնում է Փաստաթղթի օբյեկտը, եթե հայտնաբերվել է։  
Եթե չի հայտնաբերվել առաջացնում է սխալ կամ վերադարձնում է **null** կախված `throwExceptionIfDeleted` պարամետրից։

**Պարամետրեր**

* `T` - Փաստաթղթի նկարագրված դաս 8X-ում, [Document](../../definitions/document.md) դասի ժառանգ։
* `isn` - Բեռնվող փաստաթղթի ներքին նույնականացման համարը։
* `gridLoadMode` - [Աղյուսակների բեռնման հայտանիշ](../../types/GridLoadMode.md)։
* `loadImagesAndMemos` - Նկարների ու մեծ մուտքագրման դաշտերի բեռնման հայտանիշ։ 
* `lockTableRow` - Տվյալների պահոցում արգելափակման (lock) միացման հայտանիշ։ 
  **true** արժեքի դեպքում դրվում է թարմացման (update) արգելափակում։ 
* `throwExceptionIfDeleted` - Պահանջվող փաստաթղթի հեռացված լինելու դեպքում սխալի առաջացման հայտանիշ։ 
* `lookInArc` - Արխիվացված փաստաթղթի բեռնման հայտանիշ։ 
  **true** արժեքի դեպքում փաստաթղթի բեռնումը փորձում է կատարել նաև արխիվային տվյալների պահոցից, եթե այնտեղ նույնպես փաստաթութը առկա չէ, առաջանում է սխալ։ 
* `loadParents` - Ծնող փաստաթղթերի ISN-ների ցուցակի բեռնման հայտանիշ։
