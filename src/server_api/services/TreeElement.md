---
layout: page
title: "TreeElement" 
tags: [TreeElement, AsTreeElement]
---

Այս դասը նախատեսված է ծառի հանգույցի նկարագրման համար։

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

* `TreeId` - Վերադարձնում կամ նշանակում է ծառի ներքին անունը։
* `Key` - Վերադարձնում կամ նշանակում է ծառի հանգույցի կոդը։
* `Comment` - Վերադարձնում կամ նշանակում է ծառի հանգույցի հայերեն անվանումը։
* `EComment` - Վերադարձնում կամ նշանակում է ծառի հանգույցի անգլերեն անվանումը։
* `Path` - Վերադարձնում կամ նշանակում է ծառի մեջ վերադարձնում է հանգույցի ճանապարհը՝ սկսելով ծառի արմատից։
* `Leaf` - Վերադարձնում կամ նշանակում է ծառի հանգույցի տերև հանդիսանալու հայտանիշը։
* `Parent` - Վերադարձնում կամ նշանակում է ծառի հանգույցի ծնող հանդիսանալու հայտանիշը։
* `DocName` - Վերադարձնում կամ նշանակում է ծառի հանգույցի հետ կապակցված փաստաթղթի ներքին անունը։
* `ISN` - Վերադարձնում կամ նշանակում է ծառի հանգույցի հետ կապակցված փաստաթղթի ներքին նույնականացման համարը։
* `Branch` - Վերադարձնում կամ նշանակում է ծառի հանգույցի գրասենյակի կոդը։
* `Depart` - Վերադարձնում կամ նշանակում է ծառի հանգույցի կոդը։
* `ErrorMessage` - Վերադարձնում կամ նշանակում է սխալի հաղորդագրության տեքստը, որը ցույց կտրվի արդեն գոյություն ունեցացող կոդով հանգույց ավելացնելու դեպքում։
