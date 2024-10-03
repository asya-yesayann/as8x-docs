---
layout: page
title: "AttachmentCommentModel" 
---

Այդ դասը նախատեսված է փաստաթղթին կցված ֆայլի մեկնաբանությունը նկարագրելու համար։

Օգտագործվում է [IAttachmentService](../services/IAttachmentService.md).[ChangeComment](../services/IAttachmentService.md#changecomment) մեթոդով փաստաթղթին կցված ֆայլի մեկնաբանությունը թարմացնելիս։

```c#
public class AttachmentCommentModel 
{
    public AttachmentIdentifier Identifier { get; set; }
    public string Comment { get; set; }
}
```

* `Identifier` - Կցված ֆայլը պարունակող փաստաթղթի ներքին նույնականացման համարը (isn) և ֆայլի անունը՝ ներառյալ ընդլայնումը։
* `Comment` - Կցված ֆայլի նոր մեկնաբանությունը։