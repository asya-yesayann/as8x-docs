---
layout: page
title: "DPRAttribute դաս" 
---

DPR ատրբուտը նախատեսված է [DPR](../definitions/dpr.md)-ը նկարագրող դասի վրա դնելու համար։

public class DPRAttribute
{
    public string Name { get; protected set; }

    public DPRType DPRType { get; set; }

    public string ArmenianCaption { get; set; }

    public string EnglishCaption { get; set; }

    public FeatureAvailability IsCancellationSupported { get; set; } = FeatureAvailability.Enabled;
}

* `Name` - DPR-ի ներքին անունը։ Չլրացնելու դեպքում հանդիսանալու է DPR-ը նկարագրող դասի անունը։
* `DPRType` - DPR-ի տեսակը։
    * **DPRType.Report** - Հաշվետվությունների տվյալների մշակման հարցում
    * **DPRType.OLAP** - Օլապ տվյալների մշակման հարցում
    * **DPRType.JobElement** - Առաջադրանքների տվյալների մշակման հարցում
    * **DPRType.Other** - Այլ տվյալների մշակման հարցում
* `ArmenianCaption` - DPR-ի հայերեն անվանումը:
* `EnglishCaption` - DPR-ի անգլերեն անվանումը:
* `IsCancellationSupported` - Թույլատրված է արդյոք DPR-ի ընդհատումը UI-ից։ Չլրացնելու դեպքում թույլատրվում է ընդհատումը UI-ից։
    * **FeatureAvailability.Enabled** - Թույլատրված է DPR-ի ընդհատումը UI-ից
    * **FeatureAvailability.Disabled** - Արգելված է DPR-ի ընդհատումը UI-ից

**Օրինակ**

```c#
[DPR(DPRType = DPRType.Other, ArmenianCaption = "Փաստաթղթի դաշտերի խմբագրում", EnglishCaption = "Document's fields' edition", 
     IsCancellationSupported = FeatureAvailability.Disabled)]
public class EditDocumentsFields : DataProcessingRequest<EditFieldsResponse, EditFieldsRequest>
{
    //...
}
```