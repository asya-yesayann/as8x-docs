---
title: IDocumentService.FieldsToAnsi(string, Dictionary<string, object>) մեթոդ
---

```c#
public Task<Dictionary<string, object>> FieldsToAnsi(string docType, Dictionary<string, object> fields)
```

<!-- Վերադարձնում է փաստաթղթի դաշտերի արժեքները՝ ձևափոխված  համապատասխան լեզվի ANSI կոդավորման։ -->
Ձևափոխում է ցանցով փոխանցված արժեքների բազմությունը ANSI կոդավորման համարելով, որ դրանք պետք է լինեն փաստաթղթի դաշտերի արժեքներ։ 

Հաշվի է առնվում  
- դաշտը լրացվում է հայերեն, թե ռուսերեն,
- փոխանցող կլինետը օգտագործում է յունկոդ տվյալներ, թե ANSI տվյալներ։

Տե՛ս նաև [FieldToAnsi](FieldToAnsi.md)

**Պարամետրեր**

* `docType` - Փաստաթղթի ներքին անունը (տեսակը)։  
* `fields` - Փաստաթղթի դաշտերի ներքին անունների և արժեքների բազմություն։

<!-- ### GetCaption

```c#
public Task<(string caption, string englishCaption)> GetCaption(string docType)
```

Վերադարձնում է փաստաթղթի հայերեն և անգլերեն անվանումները։

**Պարամետրեր**

* `docType` - Փաստաթղթի տեսակ։ -->
