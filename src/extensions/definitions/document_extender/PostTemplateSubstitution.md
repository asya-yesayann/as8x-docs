---
title: DocumentExtender.PostTemplateSubstitution(Document, TemplateSubstitutionEventArgs<TemplateSubstitution>) մեթոդ
---

## Նկարագիր

**Համարժեքը 4x-ում՝** [PostTemplateSubstitution](https://asya-yesayan.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/DocExtenderEvents/PostTemplateSubstitution.html)

**Դաս՝** [DocumentExtender](../document_extender.md)

```c#
public virtual Task PostTemplateSubstitution(Document sender, 
                                             TemplateSubstitutionEventArgs<TemplateSubstitution> args)
```

Մեթոդը կանչվում է միջուկի կողմից, երբ փաստաթղթի համար ձևավորվում է տպման ձև և անջատված է փաստաթղթի [TemplateSubstitutionIsExtended](../../../server_api/definitions/document.md#templatesubstitutionisextended) հատկությունը։ Մեթոդը կանչվում է [TemplateSubstitution](../../../server_api/definitions/document.md#templatesubstitution) մեթոդի կանչից հետո։

Տե՛ս օգտագործման [օրինակը](../examples/PostTemplateSubstitution.md):

**Պարամետրեր**

* `sender` - Տպելու ձևանմուշին կապակցված [փաստաթղթի](../../../server_api/definitions/document.md) օբյեկտ։
* `args` - [TemplateSubstitutionEventArgs](../../types/args/TemplateSubstitutionEventArgs.md) տիպի օբյեկտ։