---
title: IDocumentService.MakeParentLink(Document, int, bool) մեթոդ
---

```c#
public Task MakeParentLink(Document document, int parentIsn, bool removeExistingLinks = true)
```

Ընթացիկ փաստաթղթի համար սահմանում է ծնողի հետ կապ։ 
Ընթացիկ փաստաթուղթը կարող է դեռ գրանցված չլինել տվյալների պահոցում։

Մեթոդը նախատեսված է [Action](../../definitions/document.md#action) իրադարձության մշակիչում կանչելու համար։  
Եթե փաստաթուղթը տվյալների պահոցում դեռ գրանցված չէ, ապա այս մեթոդի կանչից հետո ծնող-զավակ կապերը անմիջապես չեն գրանցվում տվյալների պահոցում, դրանց գրանցումը կատարվում է [Action](../../definitions/document.md#action) իրադարձության մշակիչի ավարտից հետո։

**Պարամետրեր**

* `document` - [Փաստաթղթի օբյեկտ](../../definitions/document.md)։
* `parentIsn` - Ծնող փաստաթղթի ներքին նույնականացման համար։
* `removeExistingLinks` - `true` արժեքի դեպքում ստեղծվող կապը լինում է միակը և նախորդ եղած կապերը հեռացվում են։
  `false` արժեքի դեպքում ծնողների ցուցակում ավելանում է ևս մեկը։
