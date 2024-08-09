---
layout: page
title: "FolderElement" 
tags: [FolderElement, AsFoldElement]
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
* `Status` - Վերադարձնում կամ նշանակում է թղթապանակի տարրի վիճակը։ ?
* `Key` - Վերադարձնում կամ նշանակում է թղթապանակի տարրի կոդը։
* `Comment` - Վերադարձնում կամ նշանակում է թղթապանակի տարրի հայերեն անվանումը։
* `EComment` - Վերադարձնում կամ նշանակում է թղթապանակի տարրի հայերեն անվանումը։
* `Spec` - ?
* `DocName` - Վերադարձնում կամ նշանակում է թղթապանակի տարրի հետ կապակցված փաստաթղթի ներքին անունը։
* `ISN` - Վերադարձնում կամ նշանակում է թղթապանակի տարրի հետ կապակցված փաստաթղթի ներքին նույնականացման համարը։
* `ErrorMessage` - Վերադարձնում կամ նշանակում է թղթապանակի տարրի տվյալների պահոցի [FOLDERS](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/Folders.html) աղյուսակում գրանցման ժամանակ առաջացած սխալի հաղորդագրություն։
* `Branch` - Վերադարձնում կամ նշանակում է թղթապանակի տարրի գրասենյակի կոդը։
* `Depart` - Վերադարձնում կամ նշանակում է թղթապանակի բաժնի կոդը։
