---
layout: page
title: "AttachmentCommentModel դաս" 
---

Դասը պարունակում է փաստաթղթին կցված ֆայլի մեկնաբանությունը փոխելու տվյալներ։

Օգտագործվում է [IAttachmentService](../services/IAttachmentService.md).[ChangeComment](../services/IAttachmentService.md#changecomment) մեթոդով փաստաթղթին կցված ֆայլի մեկնաբանությունը փոխելուց։

```c#
public class AttachmentCommentModel 
{
    public AttachmentIdentifier Identifier { get; set; }
    public string Comment { get; set; }
}
```

* `Identifier` - Փաստաթղթի ներքին նույնականացման համարը (ISN), որին կցված է ֆայլը և կցված ֆայլի անունը՝ ներառյալ ընդլայնումը։
* `Comment` - Կցված ֆայլի նոր մեկնաբանությունը։
