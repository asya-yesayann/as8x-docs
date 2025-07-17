---
title: IDocumentService.StoreFact(Document, Fact) մեթոդ
---

```c#
public Task StoreFact(Document document, Fact fact)
```

Գրանցում է փաստաթղթի հաշվառումը տվյալների պահոցում:
Մեթոդը պետք է կանչել փաստաթղթի [Action](../../definitions/document.md#action) իրադարձության մշակիչից։  
Այս մեթոդի կանչից հետո հաշվառումները անմիջապես չեն գրանցվում տվյալների պահոցում, դրանց գրանցումը կատարվում է միմիայն [Action](../../definitions/document.md#action) իրադարձության մշակիչի ավարտից հետո։

**Պարամետրեր**

* `document` - [Փաստաթղթի օբյեկտ](../../definitions/document.md)։
* `fact` - Գրանցման ենթակա հաշվառում։
