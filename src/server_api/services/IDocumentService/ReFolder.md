---
title: IDocumentService.ReFolder(Document, StoreMode) մեթոդ
---

```c#
public Task ReFolder(Document document, StoreMode mode)
```

Իրականացնում է փաստաթղթի վերաինդեքսավորումը թղթապանակներում:
Այսինքն առաջացնում է [Folders](../../definitions/document.md#folders) իրադարձությունը և համապատասխան մշակիչը։

**Պարամետրեր**

* `document` - [Փաստաթղթի օբյեկտ](../../definitions/document.md)։
* `mode` - [Փաստաթղթի պահպանման ռեժիմը](../../types/StoreMode.md)։
  Տե՛ս [Document](../../definitions/document.md).[StoreMode](../../definitions/document.md#storemode) հատկությունը։
