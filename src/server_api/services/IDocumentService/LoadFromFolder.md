---
title: IDocumentService.LoadFromFolder(string, string, GridLoadMode, bool, Type, bool) մեթոդ
---

```c#
public Task<Document> LoadFromFolder(string folder, string key, GridLoadMode gridLoadMode = GridLoadMode.Full,
                                     bool loadImagesAndMemos = true, Type instanceType = null, bool loadParents = false)
```

Բեռնում է փաստաթուղթը ըստ թղթապանակի և բանալու։

**Պարամետրեր**

* `folder` - Թղթապանակի ներքին անուն։
* `key` - Թղթապանակի տարրի բանալի։
* `gridLoadMode` - [Աղյուսակների բեռնման հայտանիշ](../../types/GridLoadMode.md)։
* `loadImagesAndMemos` - Նկարների ու մեծ մուտքագրման դաշտերի բեռնման հայտանիշ։ 
* `instanceType` - Փաստաթղթի նկարագրված դաս 8X-ում, [Document](../../definitions/document.md) դասի ժառանգ։։
* `loadParents` - Ծնող փաստաթղթերի ISN-ների ցուցակի բեռնման հայտանիշ։
