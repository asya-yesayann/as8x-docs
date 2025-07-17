---
title: IDocumentService.Store(Document, DocumentCheckLevel, string) մեթոդ
---

```c#
public Task Store(Document document, 
                  DocumentCheckLevel checkLevel = DocumentCheckLevel.None, 
                  string logComment = "")
```

Անցկացնում է պարտադիր ստուգումներ և գրանցում փաստաթուղթը տվյալների պահոցում։

**Պարամետրեր**

* `document` - [Փաստաթղթի օբյեկտ](../../definitions/document.md)։
* `checkLevel` - [Փաստաթղթի ստուգման մակարդակը](../../types/DocumentCheckLevel.md)։
* `logComment` - Փաստաթղթի պատմության մեջ գրանցվող հաղորդագրությունը։
