---
title: IDocumentService.StoreInFolder(Document, FolderElement) մեթոդ
---

```c#
public void StoreInFolder(Document document, FolderElement folderElement)
```

Գրանցում է թղթապանակի տարրը տվյալների պահոցում:
Մեթոդը հարկավոր է կանչել միմիայն փաստաթղթի [Folders](../../definitions/document.md#folders) իրադարձության մշակիչի մեջ։  
Թղթապանակի տարրերը անմիջապես չեն գրանցվում տվյալների պահոցում անմիջապես, գրանցումները կատարվում են [Folders](../../definitions/document.md#folders) իրադարձության մշակիչի ավարտից հետո։

**Պարամետրեր**

* `document` - [Փաստաթղթի օբյեկտ](../../definitions/document.md)։
* `folderElement` - [Թղթապանակի տարր](../../types/FolderElement.md)։
