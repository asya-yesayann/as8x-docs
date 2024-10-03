---
layout: page
title: "AttachmentAddModel" 
---

Այդ դասը նախատեսված է փաստաթղթին կցվող ֆայլը նկարագրելու համար։

Օգտագործվում է [IAttachmentService](../services/IAttachmentService.md).[Add](../services/IAttachmentService.md#add) մեթոդով փաստաթղթին ֆայլ կցելիս։

**Կարևոր**

Փաստաթղթին ֆայլ կցելու համար անհրաժեշտ է կցվող ֆայլը նախապես պահպանել [ընթացիկ սեսսիայի կոնտեյներ](../services/IStorageService.md#container)-ում [IStorageService](../services/IStorageService.md).[UploadTempBlobAsync](../services/IStorageService.md#uploadtempblobasync) մեթոդով։

```c#
public class AttachmentAddModel
{
    public AttachmentIdentifier Identifier { get; set; }
    public string Comment { get; set; } = string.Empty;
    public AttachmentTypes Type { get; set; }
    public StorageInfo FileContentStorageInfo { get; set; }
    public string DocumentType { get; set; } = string.Empty;
}
```

* `Identifier` - Փաստաթղթի ներքին նույնականացման համարը (isn), որին կցվել է ֆայլը և ֆայլի անունը՝ ներառյալ ընդլայնումը։
* `Comment` - Կցվող ֆայլի մեկնաբանությունը։
* `Type` - Կցվող ֆայլի տեսակ։
* `FileContentStorageInfo` - Ֆայլը պարունակող կոնտեյների և ֆայլի անունները։
* `DocumentType` - Փաստաթղթի տեսակ (ներքին անուն)։