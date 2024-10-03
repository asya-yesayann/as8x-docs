---
layout: page
title: "AttachmentContentModel" 
---

Այդ դասը նախատեսված է փաստաթղթին կցվող ֆայլի նկարագրությունը թարմացնելու համար։

Օգտագործվում է [IAttachmentService](../services/IAttachmentService.md).[UpdateContent](../services/IAttachmentService.md#updatecontent) մեթոդով փաստաթղթին ֆայլ նկարագրությունը թարմացնելիս։

**Կարևոր**

Փաստաթղթին ֆայլ կցելու համար անհրաժեշտ է կցվող ֆայլը նախապես պահպանել [ընթացիկ սեսսիայի կոնտեյներ](../services/IStorageService.md#container)-ում [IStorageService](../services/IStorageService.md).[UploadTempBlobAsync](../services/IStorageService.md#uploadtempblobasync) մեթոդով։

```c#
public class AttachmentContentModel 
{
    public AttachmentIdentifier Identifier { get; set; }
    public StorageInfo FileContentStorageInfo { get; set; }
}
```

* `Identifier` - Փաստաթղթի ներքին նույնականացման համարը (isn), որին կցվել է ֆայլը և ֆայլի անունը՝ ներառյալ ընդլայնումը։
* `FileContentStorageInfo` - Ֆայլը պարունակող կոնտեյների և ֆայլի անունները։