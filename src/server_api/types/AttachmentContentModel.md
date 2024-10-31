---
layout: page
title: "AttachmentContentModel" 
---

Դասը պարունակում է փաստաթղթին կցված ֆայլի պարունակությունը փոխելու տվյալներ։

Օգտագործվում է [IAttachmentService](../services/IAttachmentService.md).[UpdateContent](../services/IAttachmentService.md#updatecontent) մեթոդով փաստաթղթին կցված ֆայլը փոխելուց։

Տե՛ս [օրինակը](../examples/IAttachmentService.md#օրինակ-2)։

```c#
public class AttachmentContentModel 
{
    public AttachmentIdentifier Identifier { get; set; }
    public StorageInfo FileContentStorageInfo { get; set; }
}
```

* `Identifier` - Փաստաթղթի ներքին նույնականացման համարը (ISN), որին կցված է ֆայլը և կցված ֆայլի անունը՝ ներառյալ ընդլայնումը։
* `FileContentStorageInfo` - Նոր պարունակությամբ ֆայլի նույնականացուցիչը սերվերային պահոցում։