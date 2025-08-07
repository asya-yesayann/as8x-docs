---
title: DocumentExtender.PostTemplateSubstitutionEx(Document, TemplateSubstitutionEventArgs<TemplateSubstitution>) մեթոդ
---

## Նկարագիր

**Համարժեքը 4x-ում՝** [PostTemplateSubstitution]https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/DocExtenderEvents/PostTemplateSubstitution.html

**Դաս՝** [DocumentExtender](../document_extender.md)

```c#
public virtual Task PostTemplateSubstitutionEx(Document sender, 
                                               TemplateSubstitutionEventArgs<TemplateSubstitution> args)
```

Մեթոդը կանչվում է միջուկի կողմից, երբ փաստաթղթի համար ձևավորվում է տպման ձև և միացված է փաստաթղթի [TemplateSubstitutionIsExtended](../../../server_api/definitions/document.md#templatesubstitutionisextended) հատկությունը։ Մեթոդը կանչվում է [TemplateSubstitutionEx](../../../server_api/definitions/document.md#templatesubstitution) մեթոդի կանչից հետո։

**Պարամետրեր**

* `sender` - Տպելու ձևանմուշին կապակցված [փաստաթղթի](../../../server_api/definitions/document.md) օբյեկտ։
* `args` - [TemplateSubstitutionEventArgs](../../types/args/TemplateSubstitutionEventArgs.md) տիպի օբյեկտ։