---
layout: page
title: "FolderElement" 
tags: AsFoldElement
---

Այս դասը նախատեսված է թղթապանակի տարրի նկարագրման համար։

Օգտագործվում է [IDocumentService](../services/IDocumentService.md).[StoreInFolder](../services/IDocumentService.md#storeinfolder) և [IFolderService](../services/IFoldersService.md)-ի ֆունկցիաներում։

```c#
public class FolderElement
{
    public string FolderId { get; set; } = string.Empty;
    public FolderStatus Status { get; set; } = FolderStatus.Copy;
    public string Key { get; set; } = string.Empty;
    public string Comment { get; set; } = string.Empty;
    public string EComment { get; set; } = string.Empty;
    public string Spec { get; set; } = string.Empty;
    public string DocName { get; set; } = string.Empty;
    public int ISN { get; set; }
    public string ErrorMessage { get; set; } = string.Empty;
    public string Branch { get; set; } = string.Empty;
    public string Depart { get; set; } = string.Empty;
}
```

* `FolderId` - Թղթապանակի ներքին անունը։
* `Status` - Թղթապանակի տարրի վիճակը։
* `Key` - Թղթապանակի տարրի կոդը։
* `Comment` - Թղթապանակի տարրի հայերեն անվանումը։
* `EComment` - Թղթապանակի տարրի անգլերեն անվանումը։
* `Spec` - Թղթապանակի ազատ լրացման դաշտը, որը սովորաբար օգտագործվում է փաստաթղթի որոշ դաշտերի արժեքների պահման համար։
* `DocName` - Թղթապանակի տարրի հետ կապակցված փաստաթղթի ներքին անունը։
* `ISN` - Թղթապանակի տարրի հետ կապակցված փաստաթղթի ներքին նույնականացման համարը։
* `ErrorMessage` - սխալի հաղորդագրության տեքստը, որը ցույց կտրվի արդեն գոյություն ունեցացող կոդով տարր ավելացնելու դեպքում։
* `Branch` - Թղթապանակի տարրի գրասենյակի կոդը։
* `Depart` - Թղթապանակի բաժնի կոդը։
