---
title: IAttachmentService.Get(int, string) մեթոդ
---

```c#
public Task<AttachmentModel> Get(int isn, string fileName)
```

Վերադարձնում է փաստաթղթին [կցված ֆայլի տվյալները](../../types/AttachmentModel.md)՝ ըստ ֆայլի անվան և փաստաթղթի ներքին նույնականացման համարի (ISN)։

**Պարամետրեր**

* `isn` - Փաստաթղթի ներքին նույնականացման համար։
* `fileName` - Ֆայլի անունը՝ ներառյալ ֆայլի ընդլայնումը։
