---
title: IDocumentService.StoreInTree(Document, TreeElement) մեթոդ
---

```c#
public void StoreInTree(Document document, TreeElement treeElement)
```

Գրանցում է ծառի տարրը տվյալների պահոցում:
Մեթոդը հարկավոր է կանչել միմիայն փաստաթղթի [Folders](../../definitions/document.md#folders) իրադարձության մշակիչի մեջ։  
Ծառի տարրերը անմիջապես չեն գրանցվում տվյալների պահոցում անմիջապես, գրանցումները կատարվում են [Folders](../../definitions/document.md#folders) իրադարձության մշակիչի ավարտից հետո։

**Պարամետրեր**

* `document` - [Փաստաթղթի օբյեկտ](../../definitions/document.md)։
* `treeElement` - [Ծառի տարր](../../types/TreeElement.md):
