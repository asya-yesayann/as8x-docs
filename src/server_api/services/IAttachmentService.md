---
layout: page
title: "IAttachmentService սերվիս" 
---

## Բովանդակություն

- [Ներածություն](#ներածություն)
- [Մեթոդներ](#մեթոդներ)
  - [Add](#add)
  - [ChangeComment](#changecomment)
  - [Delete](#delete)
  - [DeleteAll](#deleteall)
  - [Get](#get)
  - [GetAll](#getall)
  - [GetContent](#getcontent)
  - [UpdateContent](#updatecontent)
  - [Copy](#copy)

## Ներածություն

IAttachmentService դասը նախատեսված է փաստաթղթին կցված ֆայլերի հետ աշխատանքը ապահովելու համար։

Փաստաթղթին կարելի է կցել ֆայլ կամ ֆայլի հղում։
Կցվող ֆայլերը գրանցվում են տվյալների պահոցի [DOCSATTACH](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/DocsAttach.html) աղյուսակում։
Փաստաթղթին ֆայլ կցելիս կամ եղած ֆայլը թարմացնելիս տվյալների պահոցում գրանցվում են նաև փոփոխման ամսաթիվը, փոփոխող օգտագործողի և համակարգչի տվյալները։

Փաստաթղթին կարելի է կցել առավելագույնը 10 մբ ծավալով ֆայլ։

## Մեթոդներ

### Add

```c#
public Task<AttachmentModel> Add(AttachmentAddModel attachment)
```

Կցում է ֆայլը փաստաթղթին, գրանցում տվյալների պահոցի [DOCSATTACH](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/DocsAttach.html) աղյուսակում և վերադարձնում [կցված ֆայլի տվյալները](../types/AttachmentModel.md)։
Տվյալների պահոցում գրանցվում են նաև ավելացման ամսաթիվը, կատարողի և համակարգչի տվյալները։

Փաստաթղթին կարելի է կցել առավելագույնը 10 մբ ծավալով ֆայլ։

Տե՛ս [օրինակը](../examples/IAttachmentService.md#օրինակ-1)։

**Պարամետրեր**

* `attachment` - [Կցվող ֆայլի տվյալներ](../types/AttachmentAddModel.md)՝ փաստաթղթի ISN, ֆայլի անուն, նույնականացուցիչ, մեկնաբանություն, կցման ձև։

<!-- **Կարևոր**

Փաստաթղթին ֆայլ կցելու համար անհրաժեշտ է կցվող ֆայլը նախապես պահպանել սերվերի պահոցումը [IStorageService](IStorageService.md)-ի միջոցով։

**Օրինակ**

Տե՛ս [օրինակը](../examples/IAttachmentService.md#օրինակ-1)։ -->

### ChangeComment

```c#
public Task<AttachmentModel> ChangeComment(AttachmentCommentModel attachment)
```

Փոխում է փաստաթղթին կցված ֆայլի մեկնաբանությունը և վերադարձնում [կցված ֆայլի տվյալները](../types/AttachmentModel.md)։
Տվյալների պահոցում գրանցվում են նաև փոփոխման ամսաթիվը, փոփոխությունը կատարողի և համակարգչի տվյալները։

**Պարամետրեր**

* `attachment` - [Մեկնաբանությունը փոփոխման տվյալներ](../types/AttachmentCommentModel.md)՝ փաստաթղթի ISN, ֆայլի անուն, մեկնաբանություն։

### Delete

```c#
public Task Delete(int isn, string fileName)
```

Հեռացնում է փաստաթղթին կցված ֆայլը՝ ըստ ֆայլի անվան և փաստաթղթի ներքին նույնականացման համարի (ISN)։

**Պարամետրեր**

* `isn` - Փաստաթղթի ներքին նույնականացման համար։
* `fileName` - Ֆայլի անունը՝ ներառյալ ֆայլի ընդլայնումը։

### DeleteAll

```c#
public Task DeleteAll(int isn)
```

Հեռացնում է փաստաթղթին կցված բոլոր ֆայլերը։

**Պարամետրեր**

* `isn` - Փաստաթղթի ներքին նույնականացման համար։

### Get

```c#
public Task<AttachmentModel> Get(int isn, string fileName)
```

Վերադարձնում է փաստաթղթին [կցված ֆայլի տվյալները](../types/AttachmentModel.md)՝ ըստ ֆայլի անվան և փաստաթղթի ներքին նույնականացման համարի (ISN)։

**Պարամետրեր**

* `isn` - Փաստաթղթի ներքին նույնականացման համար։
* `fileName` - Ֆայլի անունը՝ ներառյալ ֆայլի ընդլայնումը։

### GetAll

```c#
public Task<List<AttachmentModel>> GetAll(int isn)
```

Վերադարձնում է փաստաթղթին կցված բոլոր [ֆայլերի տվյալները](../types/AttachmentModel.md)։

**Պարամետրեր**

* `isn` - Փաստաթղթի ներքին նույնականացման համար։

### GetContent

```c#
public Task<StorageInfo> GetContent(int isn, string fileName)
```

Բեռնում է փաստաթղթին կցված ֆայլի պարունակությունը տվյալների պահոցից և պահում սերվերային պահոցում [ընթացիկ սեսսիայի կոնտեյներում](IStorageService.md#container)։ 

Վերադարձնում է ֆայլի նույնականացուցիչը սերվերային պահոցում։

**Պարամետրեր**

* `isn` - Փաստաթղթի ներքին նույնականացման համար։
* `fileName` - Կցված ֆայլի անունը՝ ներառյալ ֆայլի ընդլայնումը։

### UpdateContent

```c#
public Task<DateTime> UpdateContent(AttachmentContentModel attachmentContent)
```

Փոխում է փաստաթղթին կցված ֆայլի պարունակությունը:

Փաստաթղթին կարելի է կցել առավելագույնը 10 մբ ծավալով ֆայլ։

Տե՛ս [օրինակը](../examples/IAttachmentService.md#օրինակ-2)։

**Պարամետրեր**

* `attachment` - [Կցված ֆայլի պարունակության փոփոխման տվյալներ](../types/AttachmentContentModel.md)՝ փաստաթղթի ISN, ֆայլի անունը, նոր պարունակությամբ ֆայլի նույնականացուցիչը սերվերային պահոցում։

<!-- **Կարևոր**

Փաստաթղթին կցված ֆայլը թարմացնելու համար անհրաժեշտ է նոր ֆայլը նախապես պահպանել [ընթացիկ սեսսիայի կոնտեյներ](../services/IStorageService.md#container)-ում [IStorageService](IStorageService.md).[UploadTempBlobAsync](IStorageService.md#uploadtempblobasync) մեթոդով։ -->

### Copy

```c#
public Task Copy(int copyFromISN, int copyToISN, bool updateExisted = true)
```

Պատճենում է տրված փաստաթղթի կցված ֆայլերը մեկ այլ փաստաթղթի մեջ։

**Պարամետրեր**

* `copyFromISN` - Փաստաթղթի ներքին նույնականացման համար, որից պետք է պատճենվեն կցված ֆայլերը:
* `copyToISN` - Փաստաթղթի ներքին նույնականացման համար, որտեղ պետք է պատճենվեն կցված ֆայլերը:
* `updateExisted` - `copyToISN` ներքին նույնականացման համարով փաստաթղթին կցված ֆայլերի առկայության դեպքում ֆայլերի վերագրանցման հայտանիշ։
