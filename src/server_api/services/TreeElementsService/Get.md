---
title: TreeElementsService.Get(string, string, bool) մեթոդ
---

```c#
public Task<TreeElement> Get(string treeId, string key, bool useCache = true)
```

Բեռնում է [ծառի տարրը](../../types/TreeElement.md) տվյալների պահոցից կամ քեշից, եթե ծառը քեշավոևվող է։

**Պարամետրեր**

* `treeId` - Ծառի ներքին անունը։
* `key` - Ծառի հանգույցի կոդը։
* `useCache` - Քեշում առկայության դեպքում քեշից բեռնման հայտանիշ։
