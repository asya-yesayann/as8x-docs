---
layout: page
title: "DocumentAttribute դաս" 
---

Document ատրիբուտը նախատեսված է [Document](../../definitions/document.md)-ը նկարագրող դասի վրա դնելու համար։

```c#
public class DocumentAttribute
{
    public string Name { get; protected set; }

    public FeatureAvailability IsCancellationSupported { get; set; } = FeatureAvailability.Enabled;

    public FeatureAvailability ShowProgress { get; set; } = FeatureAvailability.Disabled;

    public DocumentAttribute(string name = "")
    {
        this.Name = name;
    }
}
```

* `Name` - [Փաստաթղթի](../../definitions/document.md) ներքին անունը (տեսակը)։ Չլրացնելու դեպքում հանդիսանալու է [փաստաթուղթը](../../definitions/document.md) նկարագրող դասի անունը։
* `ShowProgress` - [Փաստաթղթի](../../definitions/document.md) [գրանցման](../../services/IDocumentService.md#store)/[հեռացման](../../services/IDocumentService.md#delete) ընթացքում պրոգրեսի պատուհանի ցուցադրման հայտանիշ։ Լռությամբ պրոգրեսի պատուհանը չի ցուցադրվում։ 
    * **FeatureAvailability.Enabled** - Պրոգրեսի պատուհանը ցուցադրվում է։
    * **FeatureAvailability.Disabled** - Պրոգրեսի պատուհանը չի ցուցադրվում:
* `IsCancellationSupported` - UI-ից [փաստաթղթի](../../definitions/document.md) [գրանցման](../../services/IDocumentService.md#store)/[հեռացման](../../services/IDocumentService.md#delete) ընթացքում ընդհատման հնարավորության հայտանիշ։ Դադարեցման հնարավորությունը հասանելի է միայն այն դեպքում, երբ ակտիվացված է պրոգրեսի պատուհանի ցուցադրումը (`ShowProgress`)։ Լռությամբ UI-ից ընդհատումը թույլատրված է։
    * **FeatureAvailability.Enabled** - Թույլատրված է ընդհատումը UI-ից։
    * **FeatureAvailability.Disabled** - Արգելված է ընդհատումը UI-ից։

**Օրինակ**

```c#
[Document("Filial", IsCancellationSupported = FeatureAvailability.Disabled, ShowProgress = FeatureAvailability.Enabled)]
public class Filial : Document
{

}
```