---
title: IAttachmentService.Add(AttachmentAddModel) մեթոդ
---

```c#
public Task<AttachmentModel> Add(AttachmentAddModel attachment)
```

Կցում է ֆայլը փաստաթղթին, գրանցում տվյալների պահոցի [DOCSATTACH](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/DocsAttach.html) աղյուսակում և վերադարձնում [կցված ֆայլի տվյալները](../../types/AttachmentModel.md)։
Տվյալների պահոցում գրանցվում են նաև ավելացման ամսաթիվը, կատարողի և համակարգչի տվյալները։

Փաստաթղթին կարելի է կցել առավելագույնը 10 մբ ծավալով ֆայլ։

Տե՛ս [օրինակը](../../examples/IAttachmentService.md#օրինակ-1)։

**Պարամետրեր**

* `attachment` - [Կցվող ֆայլի տվյալներ](../../types/AttachmentAddModel.md)՝ փաստաթղթի ISN, ֆայլի անուն, նույնականացուցիչ, մեկնաբանություն, կցման ձև։

<!-- **Կարևոր**

Փաստաթղթին ֆայլ կցելու համար անհրաժեշտ է կցվող ֆայլը նախապես պահպանել սերվերի պահոցումը [IStorageService](IStorageService.md)-ի միջոցով։

**Օրինակ**

Տե՛ս [օրինակը](../../examples/IAttachmentService.md#օրինակ-1)։ -->
