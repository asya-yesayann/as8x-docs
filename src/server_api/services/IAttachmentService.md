---
title: "IAttachmentService սերվիս"
---

## Ներածություն

IAttachmentService դասը նախատեսված է փաստաթղթին կցված ֆայլերի հետ աշխատանքը ապահովելու համար։

Փաստաթղթին կարելի է կցել ֆայլ կամ ֆայլի հղում։
Կցվող ֆայլերը գրանցվում են տվյալների պահոցի [DOCSATTACH](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/DocsAttach.html) աղյուսակում։
Փաստաթղթին ֆայլ կցելիս կամ եղած ֆայլը թարմացնելիս տվյալների պահոցում գրանցվում են նաև փոփոխման ամսաթիվը, փոփոխող օգտագործողի և համակարգչի տվյալները։

Փաստաթղթին կարելի է կցել առավելագույնը 10 մբ ծավալով ֆայլ։

## Մեթոդներ

| Անվանում | Նկարագրություն |
|----------|----------------|
| [Add](IAttachmentService/Add.md) | Կցում է ֆայլը փաստաթղթին, գրանցում տվյալների պահոցի [DOCSATTACH](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/DocsAttach.html) աղյուսակում և վերադարձնում [կցված ֆայլի տվյալները](../types/AttachmentModel.md)։ |
| [ChangeComment](IAttachmentService/ChangeComment.md) | Փոխում է փաստաթղթին կցված ֆայլի մեկնաբանությունը և վերադարձնում [կցված ֆայլի տվյալները](../types/AttachmentModel.md)։ |
| [Delete](IAttachmentService/Delete.md) | Հեռացնում է փաստաթղթին կցված ֆայլը՝ ըստ ֆայլի անվան և փաստաթղթի ներքին նույնականացման համարի (ISN)։ |
| [DeleteAll](IAttachmentService/DeleteAll.md) | Հեռացնում է փաստաթղթին կցված բոլոր ֆայլերը։ |
| [Get](IAttachmentService/Get.md) | Վերադարձնում է փաստաթղթին [կցված ֆայլի տվյալները](../types/AttachmentModel.md)՝ ըստ ֆայլի անվան և փաստաթղթի ներքին նույնականացման համարի (ISN)։ |
| [GetAll](IAttachmentService/GetAll.md) | Վերադարձնում է փաստաթղթին կցված բոլոր [ֆայլերի տվյալները](../types/AttachmentModel.md)։ |
| [GetContent](IAttachmentService/GetContent.md) | Բեռնում է փաստաթղթին կցված ֆայլի պարունակությունը տվյալների պահոցից և պահում սերվերային պահոցում [ընթացիկ սեսսիայի կոնտեյներում](IStorageService/Container.md)։ |
| [UpdateContent](IAttachmentService/UpdateContent.md) | Փոխում է փաստաթղթին կցված ֆայլի պարունակությունը: |
| [Copy](IAttachmentService/Copy.md) | Պատճենում է տրված փաստաթղթի կցված ֆայլերը մեկ այլ փաստաթղթի մեջ։ |