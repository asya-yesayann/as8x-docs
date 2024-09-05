---
layout: page
title: "FolderElement" 
tags: AsFoldElement
---

Այս դասը նախատեսված է թղթապանակի տարրի նկարագրման համար։

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

* `FolderId` - Վերադարձնում կամ նշանակում է թղթապանակի ներքին անունը։
* `Status` - Վերադարձնում կամ նշանակում է թղթապանակի տարրի վիճակը։
* `Key` - Վերադարձնում կամ նշանակում է թղթապանակի տարրի կոդը։
* `Comment` - Վերադարձնում կամ նշանակում է թղթապանակի տարրի հայերեն անվանումը։
* `EComment` - Վերադարձնում կամ նշանակում է թղթապանակի տարրի անգլերեն անվանումը։
* `Spec` - Վերադարձնում կամ նշանակում է թղթապանակի ազատ լրացման դաշտը, որը սովորաբար օգտագործվում է փաստաթղթի որոշ դաշտերի արժեքների պահման համար։
* `DocName` - Վերադարձնում կամ նշանակում է թղթապանակի տարրի հետ կապակցված փաստաթղթի ներքին անունը։
* `ISN` - Վերադարձնում կամ նշանակում է թղթապանակի տարրի հետ կապակցված փաստաթղթի ներքին նույնականացման համարը։
* `ErrorMessage` - Վերադարձնում կամ նշանակում է սխալի հաղորդագրության տեքստը, որը ցույց կտրվի արդեն գոյություն ունեցացող կոդով տարր ավելացնելու դեպքում։
* `Branch` - Վերադարձնում կամ նշանակում է թղթապանակի տարրի գրասենյակի կոդը։
* `Depart` - Վերադարձնում կամ նշանակում է թղթապանակի բաժնի կոդը։
