---
title: IAttachmentService.ChangeComment(AttachmentCommentModel) մեթոդ
---

```c#
public Task<AttachmentModel> ChangeComment(AttachmentCommentModel attachment)
```

Փոխում է փաստաթղթին կցված ֆայլի մեկնաբանությունը և վերադարձնում [կցված ֆայլի տվյալները](../../types/AttachmentModel.md)։
Տվյալների պահոցում գրանցվում են նաև փոփոխման ամսաթիվը, փոփոխությունը կատարողի և համակարգչի տվյալները։

**Պարամետրեր**

* `attachment` - [Մեկնաբանությունը փոփոխման տվյալներ](../../types/AttachmentCommentModel.md)՝ փաստաթղթի ISN, ֆայլի անուն, մեկնաբանություն։
