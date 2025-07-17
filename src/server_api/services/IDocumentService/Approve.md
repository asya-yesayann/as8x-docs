---
title: IDocumentService.Approve(Document, DocumentCheckLevel, string) մեթոդ
---

```c#
public Task Approve(Document document, 
                    DocumentCheckLevel checkLevel = DocumentCheckLevel.None, 
                    string logComment = "")
```

Հաստատում է փաստաթուղթը և գրանցում տվյալների պահոցում։

**Պարամետրեր**

* `document` - [Փաստաթղթի օբյեկտ](../../definitions/document.md)։
* `checkLevel` - [Փաստաթղթի գրանցման եղանակ](../../types/DocumentCheckLevel.md)։
* `logComment` - Փաստաթղթի պատմության մեջ գրանցվող հաղորդագրություն։

<!-- ### CheckAndStore

```c#
public Task CheckAndStore(Document document,
                          StoreMode mode,
                          DocumentCheckLevel checkLevel = DocumentCheckLevel.None,
                          int stateBeforeCallPostMessage = 0,
                          string logComment = "")
```

Անցկացնում է պարտադիր ստուգումներ և սահմանված ռեժիմով գրանցում փաստաթուղթը տվյալների պահոցում։

**Պարամետրեր**

* `document` - [Փաստաթղթի օբյեկտ](../../definitions/document.md)։
* `mode` - [Փաստաթղթի պահպանման ռեժիմը](StoreMode.md)։
* `checkLevel` - [Փաստաթղթի ստուգման մակարդակը](DocumentCheckLevel.md)։
* `stateBeforeCallPostMessage` - Փաստաթղթի վիճակը PostMessage մեթոդի կանչից առաջ։
* `logComment` - Փաստաթղթի պատմության մեջ գրանցվող հաղորդագրություն։ -->
