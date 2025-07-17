---
title: IDocumentService.CleanDeleted(DateTime, DateTime, string) մեթոդ
---

```c#
public Task CleanDeleted(DateTime startDate, DateTime endDate, string docType = "")
```

Ջնջված փաստաթղթերը լրիվ հեռացնում է համակարգից ըստ ջնջման ժամանակահատվածի։

**Պարամետրեր**

* `startDate` - ժամանակահատվածի սկզբի ամսաթիվ։
* `endDate` - ժամանակահատվածի վերջին ամսաթիվ։
* `docType` - Փաստաթղթի ներքին անունը (տեսակը)։
  Չլրացնելու դեպքում մաքրվում են նշված ժամանակահատվածում հեռացված բոլոր փաստաթղթերը։
