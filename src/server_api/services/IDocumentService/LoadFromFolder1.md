---
title: IDocumentService.LoadFromFolder(string, string, GridLoadMode,
                                 bool, bool) մեթոդ
---

```c#
public Task<T> LoadFromFolder<T>(string folder, string key, GridLoadMode gridLoadMode = GridLoadMode.Full,
                                 bool loadImagesAndMemos = true, bool loadParents = false) where T : Document
```

Բեռնում է փաստաթուղթը ըստ թղթապանակի և բանալու։

**Պարամետրեր**

* `T` - Փաստաթղթի նկարագրված դաս 8X-ում, [Document](../../definitions/document.md) դասի ժառանգ։
* `folder` - Թղթապանակի ներքին անուն։
* `key` - Թղթապանակի տարրի բանալի։
* `gridLoadMode` - [Աղյուսակների բեռնման հայտանիշ](../../types/GridLoadMode.md)։
* `loadImagesAndMemos` - Նկարների ու մեծ մուտքագրման դաշտերի բեռնման հայտանիշ։ 
* `loadParents` - Ծնող փաստաթղթերի ISN-ների ցուցակի բեռնման հայտանիշ։
