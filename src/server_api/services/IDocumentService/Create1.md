---
title: IDocumentService.Create(int, DocumentOrigin) մեթոդ
---

```c#
public Task<T> Create<T>(int parentISN, 
                         DocumentOrigin origin = DocumentOrigin.AsService
                         ) where T : Document
```
<!-- public Task<T> Create<T>(int parentISN, DocumentOrigin origin = DocumentOrigin.AsService, params object[] parameters) where T : Document -->

Ստեղծում է նշված տիպի փաստաթղթի նոր օբյեկտ։

**Պարամետրեր**

* `T` - Փաստաթղթի նկարագրված դաս 8X-ում, [Document](../../definitions/document.md) դասի ժառանգ։
* `parentISN` - Փաստաթղթի ծնող փաստաթղթի ISN-ը:
* `origin` - [Փաստաթղթի ստեղծման աղբյուրը](../../types/DocumentOrigin.md):
<!-- * `parameters` - Արգումենտների զանգված, որոնք փոխանցվում են փաստաթղթի կոնստրուկտորին և պիտի թվով, հերթականությամբ, տիպերով համընկնեն կանչվող կոնստրուկտորի շարահյուսությանը։
Չփոխանցելու դեպքում փաստաթղթի նոր օբյեկտը ստեղծվելու է պարամետրեր չպարունակող կոնստրուկտորի միջոցով։ -->
