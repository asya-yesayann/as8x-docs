---
title: IDBService.TransDeferred հատկություն
---

```c#
public bool TransDeferred { get; set; }
```

Վերադարձնում կամ նշանակում է Fact տիպի օբյեկտների տվյալների պահոցում հետաձգված գրանցման հայտանիշը։
Նախնական արժեքը **true** է։

**true** արժեքի դեպքում [DocumentService](../IDocumentService.md).[StoreFact](../IDocumentService.md#storefact) մեթոդի կանչի արդյունքում հաշվառումները պահվում են փաստաթղթի [StoredFacts](../../definitions/document.md#storedfacts) ցուցակում և գրանցվում տվյալների պահոցում փաստաթղթի գրանցման հետ միասին։ 
**false** արժեքրի դեպքում՝ գրանցվում են անմիջապես։

