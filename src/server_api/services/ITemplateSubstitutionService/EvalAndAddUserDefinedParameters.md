---
title: ITemplateSubstitutionService.EvalAndAddUserDefinedParameters(string, SubstitutionType, PrintTemplateSubstitution, Document.Document) մեթոդ
---

```c#
public Task EvalAndAddUserDefinedParameters(
    string name, SubstitutionType type,
    PrintTemplateSubstitution printTemplateSubstitution,
    Document.Document document)
```

Հաշվարկում է տպելու ձևանմուշի օգտագործողի կողմից նկարագրված պարամետրերը և ավելացնում տպելու ձևանմուշի տեղադրվող արժեքները պարունակող օբյեկտում՝ `printTemplateSubstitution`:

Տե՛ս [Տպելու ձևանմուշի ընդլայնման ձեռնարկ](../../../extensions/definitions/template_substitution_guide.md)։

**Պարամետրեր**

* `name` - Տպելու ձևանմուշի ներքին անուն:
* `type` - [Տպելու ձևանմուշի տիպ][4XTemplateSubstitution]:
* `printTemplateSubstitution` - Տպելու ձևանմուշի տեղադրվող արժեքները պարունակող օբյեկտ։
* `document` - Տպելու ձևանմուշի հետ կապակցված [փաստաթղթի օբյեկտ](../../definitions/document.md)։
  Կարող է փոխանցվել `null`, եթե տպելու ձևը կապված չէ փաստաթղթի հետ։
