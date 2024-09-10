---
layout: page
title: "TreeElement" 
tags: AsTreeElement
---

## Ծառի տարր օբյեկտ

Այս դասը նախատեսված է ծառի հանգույցի նկարագրման համար։

Օգտագործվում է [IDocumentService](IDocumentService.md).[StoreInTree](IDocumentService.md#storeintree)  և [TreeElementsService](TreeElementsService.md#addnode)-ի ֆունկցիաներում։

```c#
public class TreeElement
{
    public string TreeId { get; set; } = string.Empty;
    public string Key { get; set; } = string.Empty;
    public string Comment { get; set; } = string.Empty;
    public string EComment { get; set; } = string.Empty;
    public string Path { get; set; } = string.Empty;
    public string Leaf { get; set; } = string.Empty;
    public string Parent { get; set; } = string.Empty;
    public string DocName { get; set; } = string.Empty;
    public int ISN { get; set; } = -1;
    public string Branch { get; set; } = string.Empty;
    public string Depart { get; set; } = string.Empty;
    public string ErrorMessage { get; set; } = string.Empty;
}
```

* `TreeId` - Ծառի ներքին անունը։
* `Key` - Ծառի հանգույցի կոդը։
* `Comment` - Ծառի հանգույցի հայերեն անվանումը։
* `EComment` - Ծառի հանգույցի անգլերեն անվանումը։
* `Path` - Ծառի մեջ վերադարձնում է հանգույցի ճանապարհը՝ սկսելով ծառի արմատից։
* `Leaf` - Ծառի հանգույցի տերև հանդիսանալու հայտանիշը։
* `Parent` - Ծառի հանգույցի ծնող հանդիսանալու հայտանիշը։
* `DocName` - Ծառի հանգույցի հետ կապակցված փաստաթղթի ներքին անունը։
* `ISN` - Ծառի հանգույցի հետ կապակցված փաստաթղթի ներքին նույնականացման համարը։
* `Branch` - Ծառի հանգույցի գրասենյակի կոդը։
* `Depart` - Ծառի հանգույցի բաժնի կոդը։
* `ErrorMessage` - Սխալի հաղորդագրության տեքստը, որը ցույց կտրվի արդեն գոյություն ունեցացող կոդով հանգույց ավելացնելու դեպքում։
