---
layout: page
title: "AttachmentModel" 
---

Այդ դասը նախատեսված է փաստաթղթին կցված ֆայլի նկարագրությունը վերադարձնելու համար։

Օգտագործվում է [IAttachmentService](../services/IAttachmentService.md)-ի [Get](../services/IAttachmentService.md#get), [GetAll](../services/IAttachmentService.md#getall) մեթոդներով փաստաթղթին կցավծ ֆայլ(եր)ի նկարագրություն(ներ)ը վերադարձնելիս, [Add](../services/IAttachmentService.md#add), [ChangeComment](../services/IAttachmentService.md#changecomment) մեթոդների կանչի արդյունքում ստեղծված կցված ֆայլի նկարագրությունը վերադարձնելու համար։ 

```c#
public class AttachmentModel 
{
    public string FileName { get; set; }
    public string Comment { get; set; }
    public AttachmentTypes Type { get; set; }
    public string Username { get; set; }
    public DateTime? LastModifiedDate { get; set; }
    public string ComputerName { get; set; }
    public int Size { get; set; }
}
```

* `Identifier` - Կցված ֆայլի անունը՝ ներառյալ ընդլայնումը։
* `Comment` - Կցված ֆայլի մեկնաբանություն։
* `Type` - Կցված ֆայլի տեսակ (ֆայլ կամ հղում)։
* `Username` - Կցված ֆայլում վերջին փոփոխություն կատարած օգտագործողի համար (կոդ)։
* `LastModifiedDate` - Կցված ֆայլում վերջին փոփոխության ամսաթիվը/ժամանակ։
* `ComputerName` - Համակարգչի անունը, որից կատարվել է կցված ֆայլում վերջին փոփոխությունը։
* `Size` - Կցված ֆայլի չափը բայթերով։