---
layout: page
title: "AttachmentAddModel դաս" 
---

Դասը պարունակում է փաստաթղթին նոր ֆայլ կցելու տվյալներ։

Օգտագործվում է [IAttachmentService](../services/IAttachmentService.md).[Add](../services/IAttachmentService.md#add) մեթոդով փաստաթղթին ֆայլ կցելիս։

Տե՛ս [օրինակը](../examples/IAttachmentService.md#օրինակ-1)։

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

* `Identifier` - Փաստաթղթի ներքին նույնականացման համարը (ISN), որին կցվելու է ֆայլը և կցվող ֆայլի անունը՝ ներառյալ ընդլայնումը։
* `Comment` - Կցվող ֆայլի մեկնաբանությունը։
* `Type` - Ֆայլի Կցման ձևը (ֆայլ կամ հղում)։
* `FileContentStorageInfo` - Ֆայլի նույնականացուցիչ սերվերային պահոցում։
* `DocumentType` - Փաստաթղթի տեսակ (ներքին անուն)։
