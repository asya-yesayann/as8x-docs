---
title: IDocumentService.Create(string, List<int>, Type, DocumentOrigin) մեթոդ
---

```c#
public Task<Document> Create(string typeName, 
                             List<int> parentISN = null, 
                             Type instanceType = null, 
                             DocumentOrigin origin = DocumentOrigin.AsService)
```
<!-- public Task<Document> Create(string typeName, List<int> parentISN = null, Type instanceType = null, DocumentOrigin origin = DocumentOrigin.AsService, params object[] parameters) -->

Ստեղծում է նշված ներքին անունով (տեսակի) փաստաթղթի նոր օբյեկտ։

**Պարամետրեր**

* `typeName` - Փաստաթղթի ներքին անուն (տեսակ)։
* `parentsISN` - Փաստաթղթի ծնող փաստաթղթերի ISN-ների ցուցակ:
* `instanceType` - Փաստաթղթի նկարագրված դաս 8X-ում, [Document](../../definitions/document.md) դասի ժառանգ։։
* `origin` - [Փաստաթղթի ստեղծման աղբյուրը](../../types/DocumentOrigin.md):
<!-- * `parameters` - Արգումենտների զանգված, որոնք փոխանցվում են փաստաթղթի կոնստրուկտորին և պիտի թվով, հերթականությամբ, տիպերով համընկնեն կանչվող կոնստրուկտորի շարահյուսությանը։
Չփոխանցելու դեպքում փաստաթղթի նոր օբյեկտը ստեղծվելու է պարամետրեր չպարունակող կոնստրուկտորի միջոցով։ -->
