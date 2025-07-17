---
title: ITemplateSubstitutionService.EvalAndAddUserDefinedParametersEx(string, SubstitutionType, PrintTemplateSubstitutionEx, Document.Document) մեթոդ
---

```c#
public Task EvalAndAddUserDefinedParametersEx(
    string name, SubstitutionType type,
    PrintTemplateSubstitutionEx printTemplateSubstitutionEx,
    Document.Document document)
```

Հաշվարկում է տպելու ձևանմուշի օգտագործողի կողմից նկարագրված պարամետրերը և ավելացնում տպելու ձևանմուշի տեղադրվող արժեքները պարունակող օբյեկտում՝ `printTemplateSubstitution`:

Տե՛ս [Տպելու ձևանմուշի ընդլայնման ձեռնարկ](../../../extensions/definitions/template_substitution_guide.md)։

**Պարամետրեր**

* `name` - Տպելու ձևանմուշի ներքին անուն:
* `type` - [Տպելու ձևանմուշի տիպ][4XTemplateSubstitution]:
* `printTemplateSubstitutionEx` - Տպելու ձևանմուշի տեղադրվող արժեքները տիպիզացված ձևով պարունակող օբյեկտ։
* `document` - Տպելու ձևանմուշի հետ կապակցված [փաստաթղթի օբյեկտ](../../definitions/document.md)։
  Կարող է փոխանցվել `null`, եթե տպելու ձևը կապված չէ փաստաթղթի հետ։
