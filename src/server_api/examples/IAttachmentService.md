---
layout: page
title: "Օրինակ IAttachmentService" 
sublinks:
- { title: "Օրինակ AttachmentAddModel, IStorageService", ref: օրինակ-1 }
- { title: "Օրինակ AttachmentContentModel, IStorageService", ref: օրինակ-2 }
---

## Բովանդակություն
- [Փաստաթղթին նոր ֆայլի կցման օրինակ](#օրինակ-1)
- [Փաստաթղթին կցված ֆայլի պարունակության փոփոխություն](#օրինակ-2)

## Օրինակ 1

Փաստաթղթին նոր ֆայլի կցման օրինակ։

```c#
public async Task AttachPassportPhotoToClient(int isn, string fileName, byte[] fileContent)
{
    // ֆայլը պահում է ընթացիկ սեսսիայի կոնտեյներում
    await this.storageService.UploadBlobAsync(this.storageService.Container, fileName, fileContent);

    // կցվող ֆայլի տվյալներ
    var attach = new AttachmentAddModel
    {
        // ֆայլը պարունակող կոնտեյների և ֆայլի անուններ
        FileContentStorageInfo = new StorageInfo
        {
            BlobName = fileName,
            Container = this.storageService.Container
        },

        Type = AttachmentTypes.File,
        Comment = "Client's passport",

        // փաստաթղթի isn-ը, որին պետք է կցվի ֆայլ և ինչ անունով պետք է ֆայլը պահվի
        Identifier = new AttachmentIdentifier
        {
            ISN = isn,
            FileName = fileName
        }
    };

    //կցում է ֆայլը փաստաթղթին
    await this.attachmentService.Add(attach);
}
```


## Օրինակ 2

Փաստաթղթին կցված ֆայլի պարունակության փոփոխություն։

```c#
public async Task UpdateAttachment(int isn, string fileName, byte[] fileContent)
{
    // ֆայլը պահում է ընթացիկ սեսսիայի կոնտեյներում
    await this.storageService.UploadBlobAsync(this.storageService.Container, fileName, fileContent);

    // ֆայլի պարունակության փոփոխման տվյալներ
    var attach = new AttachmentContentModel
    {
        // ֆայլը պարունակող կոնտեյների և ֆայլի անուններ
        FileContentStorageInfo = new StorageInfo
        {
            BlobName = fileName,
            Container = this.storageService.Container
        },

        // փաստաթղթի isn-ը և փոփոխման ենթակա կցված ֆայլի անունը
        Identifier = new AttachmentIdentifier
        {
            ISN = isn,
            FileName = fileName
        }
    };

    // փոխում է կցված ֆայլի պարունակությունը
    await this.attachmentService.UpdateContent(attach);
}
```