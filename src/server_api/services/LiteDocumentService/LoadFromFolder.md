---
title: LiteDocumentService.LoadFromFolder(string, string, bool) մեթոդ
---

```c#
public Task<LiteDocument> LoadFromFolder(string folderID, 
                                         string folderKey, 
                                         bool loadGrids = false);
```

Բեռնում է փաստաթուղթը տվյալների պահոցից ըստ փաստաթուղթը պարունակող թղթապանակի ներքին անվան և թղթապանակի տարրի կոդի։

Վերադարձնում է փաստաթղթի օբյեկտը, եթե հայտնաբերվել է, հակառակ դեպքում վերադարձնում է **null**:

**Պարամետրեր**

* `folder` - Փաստաթուղթը պարունակող թղթապանակի ներքին անունը։
* `folderKey` - Թղթապանակի տարրի կոդը։
* `loadGrids` - Փաստաթղթի աղյուսակների բեռնման հայտանիշ։
