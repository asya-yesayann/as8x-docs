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

Փաստաթղթին կարելի է կցել առավելագույնը 10 մբ չափով ֆայլ։

## Մեթոդներ

### Add

```c#
public Task<AttachmentModel> Add(AttachmentAddModel attachment)
```

Կցում է ֆայլը փաստաթղթին, գրանցում տվյալների պահոցի [DOCSATTACH](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/DocsAttach.html) աղյուսակում և վերադարձնում [կցված ֆայլի նկարագրությունը](../types/AttachmentModel.md)։ Տվյալների պահոցում գրանցվում են նաև ավելացման ամսաթիվը, ավելացումը կատարողի և համակարգչի տվյալները։

Փաստաթղթին կարելի է կցել առավելագույնը 10 մբ չափով ֆայլ։

**Պարամետրեր**

* `attachment` - [Կցվող ֆայլի նկարագրություն](../types/AttachmentAddModel.md), որը պարունակում է կցվող ֆայլի տվյալները և փաստաթղթի ներքին նույնականացման համարը (isn):

**Կարևոր**

Փաստաթղթին ֆայլ կցելու համար անհրաժեշտ է կցվող ֆայլը նախապես պահպանել [ընթացիկ սեսսիայի կոնտեյներ](../services/IStorageService.md#container)-ում [IStorageService](IStorageService.md).[UploadTempBlobAsync](IStorageService.md#uploadtempblobasync) մեթոդով։

**Օրինակ**

```c#
private async Task AttachPassportPhotoToClient(string filePath, int isn)
{
    if (!string.IsNullOrWhiteSpace(filePath))
    {
        // ֆայլը դարձնում է byte-երի զանգված և պահում stream-ում
        byte[] fileBytes = await File.ReadAllBytesAsync(filePath);
        using var stream = new MemoryStream(fileBytes);

        // ֆայլը պահում է ընթացիկ սեսսիայի կոնտեյներում և վերադարձնում ֆայլի անունը
        await this.storageService.UploadTempBlobAsync(Path.GetExtension(filePath), out string blobName, stream);

        // ստեղծում է կցված ֆայլի նկարագրությունը
        var attach = new AttachmentAddModel()
        {
            // ֆայլը պարունակող կոնտեյների և ֆայլի անուններ
            FileContentStorageInfo = new StorageInfo
            {
                BlobName = blobName,
                Container = this.storageService.Container // ընթացիկ սեսսիայի կոնտեյներ
            },
            Type = AttachmentTypes.File,
            Comment = "Client's passport",

            // փաստաթղթի isn-ը, որին պետք է կցվի ֆայլ և ինչ անունով պետք է ֆայլը պահվի
            Identifier = new AttachmentIdentifier
            {
                ISN = isn,
                FileName = "Passport.png"
            }
        };

        //կցում է ֆայլը փաստաթղթին
        await this.attachmentService.Add(attach);
    }
}
```

### ChangeComment

```c#
public Task<AttachmentModel> ChangeComment(AttachmentCommentModel attachment)
```

Թարմացնում է փաստաթղթին կցված ֆայլի մեկնաբանությունը տվյալների պահոցի [DOCSATTACH](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/DocsAttach.html) աղյուսակում և վերադարձնում [կցված ֆայլի նկարագրությունը](../types/AttachmentModel.md)։ Տվյալների պահոցում գրանցվում են նաև փոփոխման ամսաթիվը, փոփոխությունը կատարողի և համակարգչի տվյալները։

**Պարամետրեր**

* `attachment` - Փաստաթղթին կցված ֆայլի տվյալները և նոր մեկնաբանությունը պարունակող [մոդել](../types/AttachmentCommentModel.md)։

### Delete

```c#
public Task Delete(int isn, string fileName)
```

Հեռացնում է փաստաթղթին կցված ֆայլը տվյալների պահոցի [DOCSATTACH](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/DocsAttach.html) աղյուսակից՝ ըստ ֆայլի անվան և փաստաթղթի ներքին նույնականացման համարի (isn)։

**Պարամետրեր**

* `isn` - Փաստաթղթի ներքին նույնականացման համար։
* `fileName` - Ֆայլի անունը՝ ներառյալ ֆայլի ընդլայնումը։

### DeleteAll

```c#
public Task DeleteAll(int isn)
```

Հեռացնում է փաստաթղթին կցված բոլոր ֆայլերը տվյալների պահոցի [DOCSATTACH](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/DocsAttach.html) աղյուսակից։

**Պարամետրեր**

* `isn` - Փաստաթղթի ներքին նույնականացման համար։

### Get

```c#
public Task<AttachmentModel> Get(int isn, string fileName)
```

Վերադարձնում է փաստաթղթին [կցված ֆայլի նկարագրությունը](../types/AttachmentModel.md) տվյալների պահոցի [DOCSATTACH](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/DocsAttach.html) աղյուսակից՝ ըստ ֆայլի անվան և փաստաթղթի ներքին նույնականացման համարի (isn)։

**Պարամետրեր**

* `isn` - Փաստաթղթի ներքին նույնականացման համար։
* `fileName` - Ֆայլի անունը՝ ներառյալ ֆայլի ընդլայնումը։

### GetAll

```c#
public Task<List<AttachmentModel>> GetAll(int isn)
```

Վերադարձնում է փաստաթղթին բոլոր [կցված ֆայլերի նկարագրությունները](../types/AttachmentModel.md) տվյալների պահոցի [DOCSATTACH](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/DocsAttach.html) աղյուսակում։

**Պարամետրեր**

* `isn` - Փաստաթղթի ներքին նույնականացման համար։

### GetContent

```c#
public Task<StorageInfo> GetContent(int isn, string fileName)
```

Բեռնում է փաստաթղթին կցված ֆայլը տվյալների պահոցի [DOCSATTACH](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/DocsAttach.html) աղյուսակից և պահում [ընթացիկ սեսսիայի կոնտեյներում](IStorageService.md#container)։ 

Վերադարձնում է ֆայլը պարունակող [կոնտեյների](IStorageService.md#container) և ֆայլի անունները։

**Պարամետրեր**

* `isn` - Փաստաթղթի ներքին նույնականացման համար։
* `fileName` - Կցված ֆայլի անունը՝ ներառյալ ֆայլի ընդլայնումը։

### UpdateContent

```c#
public Task<DateTime> UpdateContent(AttachmentContentModel attachmentContent)
```

Թարմացնում է փաստաթղթին կցված ֆայլի նկարագրությունը տվյալների պահոցի [DOCSATTACH](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/DocsAttach.html) աղյուսակում:

Փաստաթղթին կարելի է կցել առավելագույնը 10 մբ չափով ֆայլ։

**Պարամետրեր**

* `attachment` - [Կցված ֆայլի թարմացված նկարագրությունը](../types/AttachmentContentModel.md)։

**Կարևոր**

Փաստաթղթին կցված ֆայլը թարմացնելու համար անհրաժեշտ է նոր ֆայլը նախապես պահպանել [ընթացիկ սեսսիայի կոնտեյներ](../services/IStorageService.md#container)-ում [IStorageService](IStorageService.md).[UploadTempBlobAsync](IStorageService.md#uploadtempblobasync) մեթոդով։

```c#
private async Task AttachContractToDocument(string contractPath, int isn)
{
    if (!string.IsNullOrWhiteSpace(contractPath))
    {
        // ֆայլը դարձնում է byte-երի զանգված և պահում stream-ում
        byte[] contractBytes = await File.ReadAllBytesAsync(contractPath);
        using var stream = new MemoryStream(contractBytes);

        // ֆայլը պահում է ընթացիկ սեսսիայի կոնտեյներում և վերադարձնում ֆայլի անունը
        await this.storageService.UploadTempBlobAsync(Path.GetExtension(contractPath), out string blobName, stream);   

        // ստեղծում է կցված ֆայլի նկարագրությունը
        var attach = new AttachmentContentModel()
        {
            // ֆայլը պարունակող կոնտեյների և ֆայլի անուններ
            FileContentStorageInfo = new StorageInfo
            {
                BlobName = blobName,
                Container = this.storageService.Container
            },

            // թարմացման ենթակա կցված ֆայլի անունը և ֆայլը պարունակող փաստաթղթի isn-ը
            Identifier = new AttachmentIdentifier
            {
                ISN = isn,
                FileName = "Contract.pdf"
            }
        };
        
        await this.attachmentService.UpdateContent(attach);
    }
}
```

### Copy

```c#
public Task Copy(int copyFromISN, int copyToISN, bool updateExisted = true)
```

Պատճենում է տրված փաստաթղթի կցված ֆայլերը մեկ այլ փաստաթղթի մեջ և գրանցում այն տվյալների պահոցի [DOCSATTACH](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/DocsAttach.html) աղյուսակում։

**Պարամետրեր**

* `copyFromISN` - Փաստաթղթի ներքին նույնականացման համար, որից պետք է պատճենվեն կցված ֆայլերը:
* `copyToISN` - Փաստաթղթի ներքին նույնականացման համար, որտեղ պետք է պատճենվեն կցված ֆայլերը:
* `updateExisted` - `copyToISN` ներքին նույնականացման համարով փաստաթղթին կցված ֆայլերի առկայության դեպքում ֆայլերի վերագրանցման հայտանիշ։
