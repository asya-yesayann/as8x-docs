
## Բովանդակություն

- [Բովանդակություն](#բովանդակություն)
- [Ներածություն](#ներածություն)

## Ներածություն

Այդ դասը նախատեսված է փաստաթղթին կցված ֆայլի մեկնաբանությունը նկարագրելու համար։

Օգտագործվում է [IAttachmentService](IAttachmentService.md).[ChangeComment](IAttachmentService.md#changecomment) մեթոդով փաստաթղթին կցված ֆայլի մեկնաբանությունը թարմացնելիս։

```c#
public class AttachmentCommentModel 
{
    public AttachmentIdentifier Identifier { get; set; }
    public string Comment { get; set; }
}
```

* `Identifier` - Կցված ֆայլը պարունակող փաստաթղթի ներքին նույնականացման համարը (isn) և ֆայլի անունը՝ ներառյալ ընդլայնումը։
* `Comment` - Կցված ֆայլի նոր մեկնաբանությունը։