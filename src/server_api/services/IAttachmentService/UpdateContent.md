---
title: IAttachmentService.UpdateContent(AttachmentContentModel) մեթոդ
---

```c#
public Task<DateTime> UpdateContent(AttachmentContentModel attachmentContent)
```

Փոխում է փաստաթղթին կցված ֆայլի պարունակությունը:

Փաստաթղթին կարելի է կցել առավելագույնը 10 մբ ծավալով ֆայլ։

Տե՛ս [օրինակը](../../examples/IAttachmentService.md#օրինակ-2)։

**Պարամետրեր**

* `attachment` - [Կցված ֆայլի պարունակության փոփոխման տվյալներ](../../types/AttachmentContentModel.md)՝ փաստաթղթի ISN, ֆայլի անունը, նոր պարունակությամբ ֆայլի նույնականացուցիչը սերվերային պահոցում։

<!-- **Կարևոր**

Փաստաթղթին կցված ֆայլը թարմացնելու համար անհրաժեշտ է նոր ֆայլը նախապես պահպանել [ընթացիկ սեսսիայի կոնտեյներ](../../services/IStorageService.md#container)-ում [IStorageService](IStorageService.md).[UploadTempBlobAsync](IStorageService.md#uploadtempblobasync) մեթոդով։ -->
