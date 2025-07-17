---
title: ITemplateSubstitutionService.GetReadyTemplateSubstitution(Document.Document, string, SubstitutionType, Dictionary<string, object>) մեթոդ
---

```c#
public Task<ITemplateSubstitution> GetReadyTemplateSubstitution(
    Document.Document document,
    string templateName,
    SubstitutionType templateType,
    Dictionary<string, object> parameters)
```

Հաշվարկում է փաստաթղթին կապակցված տպելու ձևանմուշի տեղադրվող արժեքները, օգտագործողի կողմից նկարագրված պարամետրերը և վերադարձնում տպելու ձևանմուշի տեղադրվող արժեքները պարունակող օբյեկտը։

Տե՛ս [օրինակը](../../examples/ITemplateSubstitutionService.md#օրինակ-1)։

**Պարամետրեր**

* `document` - Տպելու ձևանմուշի հետ կապակցված [փաստաթուղթ](../../definitions/document.md)։
* `templateName` - Տպելու ձևանմուշի ներքին անունը։
* `templateType` - [Տպելու ձևանմուշի տիպ][4XTemplateSubstitution]:
* `parameters` - Տպելու ձևանմուշի լրացման պարամետրերի Dictionary, որտեղ բանալին՝ պարամետրի անունն է, իսկ արժեքը՝ պարամետրի արժեքը: 
  Այս պարամետրի արժեքը փոխանցվելու է տպելու ձևանմուշի տեղադրվող արժեքները հաշվարկող [TemplateSubstitution](../../definitions/document.md#templatesubstitution) իրադարձության մշակիչին։
