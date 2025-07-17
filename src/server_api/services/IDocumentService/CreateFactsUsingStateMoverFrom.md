---
title: IDocumentService.CreateFactsUsingStateMoverFrom(Document, int) մեթոդ
---

```c#
public Task CreateFactsUsingStateMoverFrom(Document document, int state)
```

Ֆունկցիան կանչելուց հետո [Action](../../definitions/document.md#action)-ում [StoreFact](#storefact) ֆունկցիայով գրանցվող հաշվառումների ստեղծող օգատգործող է լրացվում այն օգտագործողը, որը վերջինն է փաստաթուղթը բերել նշված վիճակ։

**Պարամետրեր**

* `document` - [Փաստաթղթի օբյեկտ](../../definitions/document.md)։
* `state` - Այն վիճակը, որը վերջին անգամ հասցնող օգտագործողը լրացվելու է, որպես գրանցվող հաշվառումների ստեղծող:
