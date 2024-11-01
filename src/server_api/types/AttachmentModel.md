---
layout: page
title: "AttachmentModel դաս" 
---

Դասը պարունակում է փաստաթղթին կցված ֆայլի տվյալները։

Օգտագործվում է [IAttachmentService](../services/IAttachmentService.md)-ի [Get](../services/IAttachmentService.md#get), [GetAll](../services/IAttachmentService.md#getall) մեթոդներով փաստաթղթին կցված ֆայլերի տվյալները վերադարձնելիս, [Add](../services/IAttachmentService.md#add), [ChangeComment](../services/IAttachmentService.md#changecomment) մեթոդների կանչի արդյունքում ստեղծված կցված ֆայլի տվյալները վերադարձնելու համար։ 

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

* `FileName` - Կցված ֆայլի անունը՝ ներառյալ ընդլայնումը։
* `Comment` - Կցված ֆայլի մեկնաբանություն։
* `Type` - Կցված ֆայլի ձևը (ֆայլ կամ հղում)։
* `Username` - Կցված ֆայլում վերջին փոփոխություն կատարած օգտագործողի համար (կոդ)։
* `LastModifiedDate` - Կցված ֆայլում վերջին փոփոխության ամսաթիվը/ժամանակ։
* `ComputerName` - Համակարգչի անունը, որից կատարվել է կցված ֆայլում վերջին փոփոխությունը։
* `Size` - Կցված ֆայլի չափը բայթերով։
