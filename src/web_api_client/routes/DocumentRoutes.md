---
layout: page
title: "DocumentRoutes" 
---

## Բովանդակություն

- [Ներածություն](#ներածություն)
- [Մեթոդներ](#մեթոդներ)
  - [Create](#create)
  - [CreateAsync](#createasync)
  - [Delete](#delete)
  - [DeleteAsync](#deleteasync)
  - [Delete](#delete-1)
  - [DeleteAsync](#deleteasync-1)
  - [GetChildren](#getchildren)
  - [GetChildrenAsync](#getchildrenasync)
  - [GetDocumentParents](#getdocumentparents)
  - [GetDocumentParentsAsync](#getdocumentparentsasync)
  - [Load](#load)
  - [LoadAsync](#loadasync)
  - [LoadFromFolder](#loadfromfolder)
  - [LoadFromFolderAsync](#loadfromfolderasync)
  - [Store](#store)
  - [StoreAsync](#storeasync)

## Ներածություն

## Մեթոդներ

### Create

```c#
public DocumentModelSimple Create(string type, DocumentCreateRequestModel createRequestModel)
```

Ստեղծում է նշված ներքին անունով (տեսակի) փաստաթղթի նոր օբյեկտ և վերադարձնում ստեղծված փաստաթղթի տվյալները (դաշտերի, աղյուսակների անունների  արժեքների ցուցակ..)։

**Պարամետրեր**

* `type` - Փաստաթղթի ներքին անունը (տեսակը)։
* `createRequestModel` - Ստեղծվող փաստաթղթի տվյալներ (ծնող փաստաթղթերի isn-ների ցուցակ, [ստեղծման աղբյուր](../../server_api/types/DocumentOrigin.md)...):

### CreateAsync

```c#
public Task<DocumentModelSimple> CreateAsync(string type, DocumentCreateRequestModel createRequestModel, CancellationToken cancellationToken = default)
```

Ստեղծում է նշված ներքին անունով (տեսակի) փաստաթղթի նոր օբյեկտ և վերադարձնում ստեղծված փաստաթղթի տվյալները (դաշտերի, աղյուսակների անունների  արժեքների ցուցակ..)։

**Պարամետրեր**

* `type` - Փաստաթղթի ներքին անունը (տեսակը)։
* `createRequestModel` - Ստեղծվող փաստաթղթի տվյալներ (ծնող փաստաթղթերի isn-ների ցուցակ, [ստեղծման աղբյուր](../../server_api/types/DocumentOrigin.md)...):
* `cancellationToken` - Ընդհատման օբյեկտ:

### Delete

```c#
public DeletedDoc Delete(int isn, DocumentDeleteModel model)
```

Ջնջում է փաստաթուղթը համակարգից։  
Ջնջման ժամանակ հեռացվում են նաև այդ փաստաթղթի բոլոր թղթապանակները, ծառի տարրերը և իր համար գրանցված հաշվառումները։

Եթե փաստաթուղթը ունի ենթափաստաթղթեր, ապա ջնջումը չի կատարվի և կառաջանա սխալ։

Ջնջումը տեղի է ունենում տրանզակցիայի մեջ։

**Պարամետրեր**

* `isn` - Ջնջվող փաստաթղթի ներքին նույնականացման համարը (isn):
* `model` - Ջնջման համար անհրաժեշտ տվյալներ (ամբողջությամբ ջնջել թե մասնակի, ջնջման մեկնաբանություն...)։

### DeleteAsync

```c#
public Task<DeletedDoc> DeleteAsync(int isn, DocumentDeleteModel model, CancellationToken cancellationToken = default)
```

Ջնջում է փաստաթուղթը համակարգից։  
Ջնջման ժամանակ հեռացվում են նաև այդ փաստաթղթի բոլոր թղթապանակները, ծառի տարրերը և իր համար գրանցված հաշվառումները։

Եթե փաստաթուղթը ունի ենթափաստաթղթեր, ապա ջնջումը չի կատարվի և կառաջանա սխալ։

Ջնջումը տեղի է ունենում տրանզակցիայի մեջ։

**Պարամետրեր**

* `isn` - Ջնջվող փաստաթղթի ներքին նույնականացման համարը (isn):
* `model` - Ջնջման համար անհրաժեշտ տվյալներ (ամբողջությամբ ջնջել թե մասնակի, ջնջման մեկնաբանություն...)։
* `cancellationToken` - Ընդհատման օբյեկտ:

### Delete

```c#
public DeletedDoc Delete(DocumentDeleteRequestModel model)
```

Ջնջում է փաստաթուղթը համակարգից։  
Ջնջման ժամանակ հեռացվում են նաև այդ փաստաթղթի բոլոր թղթապանակները, ծառի տարրերը և իր համար գրանցված հաշվառումները։

Եթե փաստաթուղթը ունի ենթափաստաթղթեր, ապա ջնջումը չի կատարվի և կառաջանա սխալ։

Ջնջումը տեղի է ունենում տրանզակցիայի մեջ։

**Պարամետրեր**

* `model` - Ջնջվող փաստաթղթի տվյալներ (ջնջման ենթակա փաստաթղթի օբյեկտ, ամբողջությամբ ջնջել թե մասնակի, ջնջման մեկնաբանություն...):
* `cancellationToken` - Ընդհատման օբյեկտ:

### DeleteAsync

```c#
public Task<DeletedDoc> DeleteAsync(DocumentDeleteRequestModel model, CancellationToken cancellationToken = default)
```

Ջնջում է փաստաթուղթը համակարգից։  
Ջնջման ժամանակ հեռացվում են նաև այդ փաստաթղթի բոլոր թղթապանակները, ծառի տարրերը և իր համար գրանցված հաշվառումները։

Եթե փաստաթուղթը ունի ենթափաստաթղթեր, ապա ջնջումը չի կատարվի և կառաջանա սխալ։

Ջնջումը տեղի է ունենում տրանզակցիայի մեջ։

**Պարամետրեր**

* `model` - Ջնջվող փաստաթղթի տվյալներ (ջնջման ենթակա փաստաթղթի օբյեկտ, ամբողջությամբ ջնջել թե մասնակի, ջնջման մեկնաբանություն...):
* `cancellationToken` - Ընդհատման օբյեկտ:

### GetChildren

```c#
public List<DocumentResponseInfo> GetChildren(int isn, string docType = "", DocumentOrder order = DocumentOrder.UnOrdered, string docTypeLike = "")
```

Վերադարձնում է փաստաթղթի զավակ փաստաթղերի isn-ների ու ներքին անունների (տեսակների) ցուցակը:

Եթե փաստաթուղթը չի ունենում զավակներ, ապա ֆունկցիան վերադարձնում է դատարկ ցուցակ։

**Պարամետրեր**

* `isn` - Ծնող փաստաթղթի ներքին նույնականացման համարը:
* `docType` - Սահմանում է ներառվող կամ չներառվող զավակ փաստաթղթերի տիպերը։  
  Եթե պարամետրը առկա չի, ապա վերադարձվում են բոլոր տիպի զավակ փաստաթղթերի isn-ները ու տեսակները։  
  Ներառվող տիպերի ցուցակը թվարկվում են `+` նշանով սկսելով՝ փաստաթղթի տեսակների անվանումները իրարից առանձնացնելով բացատներով։ 
  Օրինակ՝ `"+KasPr MemOrd SetPr"`։  
  Չներառվող տիպերի ցուցակը թվարկվում են `-` նշանով սկսելով՝ փաստաթղթի տեսակների անվանումները իրարից առանձնացնելով բացատներով։ 
  Օրինակ՝ `"-AccDoc AsTurn"`։  
  Միայն նշված տիպի զավակ փաստաթղթերը վերադարձնելու համար անհրաժեշտ է ավելացնել փաստաթղթի տեսակը։
  Օրինակ՝ `"AccDoc"`:
* `order` - Ըստ զավակ փաստաթղթերի ստեղծման ամսաթվի դասավորման նշան։  
  `DocumentChildrenOrder.UnOrdered` - Չի դասավորվում։  
  `DocumentChildrenOrder.CreationDateAscending` - Դասավորվում է աճման կարգով։  
  `DocumentChildrenOrder.CreationDateDescending` - Դասավորվում է նվազման կարգով։  
* `docTypeLike` - Սահմանում է ներառվող կամ չներառվող զավակ փաստաթղթերի տիպերի ֆիլտր։ 
  Եթե պարամետրը առկա չի, ապա վերադարձվում են բոլոր տիպի զավակների isn-ները ու տեսակները։  
  Ներառվող տիպերի ֆիլտրը `+` նշանով սկսելով։ 
  Օրինակ՝ `"+Acc%"`։  
  Չներառվող տիպերի ֆիլտրը `-` նշանով սկսելով։ 
  Օրինակ՝ `"-Acc%"`։

### GetChildrenAsync

```c#
public Task<List<DocumentResponseInfo>> GetChildrenAsync(int isn, string docType = "", DocumentOrder order = DocumentOrder.UnOrdered, 
                                                         string docTypeLike = "", CancellationToken cancellationToken = default)
```

Վերադարձնում է փաստաթղթի զավակ փաստաթղերի isn-ների ու ներքին անունների (տեսակների) ցուցակը:

Եթե փաստաթուղթը չի ունենում զավակներ, ապա ֆունկցիան վերադարձնում է դատարկ ցուցակ։

**Պարամետրեր**

* `isn` - Ծնող փաստաթղթի ներքին նույնականացման համարը:
* `docType` - Սահմանում է ներառվող կամ չներառվող զավակ փաստաթղթերի տիպերը։  
  Եթե պարամետրը առկա չի, ապա վերադարձվում են բոլոր տիպի զավակ փաստաթղթերի isn-ները ու տեսակները։  
  Ներառվող տիպերի ցուցակը թվարկվում են `+` նշանով սկսելով՝ փաստաթղթի տեսակների անվանումները իրարից առանձնացնելով բացատներով։ 
  Օրինակ՝ `"+KasPr MemOrd SetPr"`։  
  Չներառվող տիպերի ցուցակը թվարկվում են `-` նշանով սկսելով՝ փաստաթղթի տեսակների անվանումները իրարից առանձնացնելով բացատներով։ 
  Օրինակ՝ `"-AccDoc AsTurn"`։  
  Միայն նշված տիպի զավակ փաստաթղթերը վերադարձնելու համար անհրաժեշտ է ավելացնել փաստաթղթի տեսակը։
  Օրինակ՝ `"AccDoc"`:
* `order` - Ըստ զավակ փաստաթղթերի ստեղծման ամսաթվի դասավորման նշան։  
  `DocumentChildrenOrder.UnOrdered` - Չի դասավորվում։  
  `DocumentChildrenOrder.CreationDateAscending` - Դասավորվում է աճման կարգով։  
  `DocumentChildrenOrder.CreationDateDescending` - Դասավորվում է նվազման կարգով։  
* `docTypeLike` - Սահմանում է ներառվող կամ չներառվող զավակ փաստաթղթերի տիպերի ֆիլտր։ 
  Եթե պարամետրը առկա չի, ապա վերադարձվում են բոլոր տիպի զավակների isn-ները ու տեսակները։  
  Ներառվող տիպերի ֆիլտրը `+` նշանով սկսելով։ 
  Օրինակ՝ `"+Acc%"`։  
  Չներառվող տիպերի ֆիլտրը `-` նշանով սկսելով։ 
  Օրինակ՝ `"-Acc%"`։
* `cancellationToken` - Ընդհատման օբյեկտ:

### GetDocumentParents

```c#
public List<DocumentResponseInfo> GetDocumentParents(int isn, DocumentParentsRequestModel model)
```

Վերադարձնում է `List<DocumentResponseInfo>` տիպի օբյեկտ, որը պարունակում փաստաթղթի ծնող փաստաթղերի isn-ների ու ներքին անունների (տեսակների) ցուցակը:

Եթե փաստաթուղթը չի ունենում ծնողներ, ապա ֆունկցիան վերադարձնում է դատարկ ցուցակ։

**Պարամետրեր**

* `isn` - Զավակ փաստաթղթի ներքին նույնականացման համարը:
* `model` - `DocumentParentsRequestModel` տիպի օբյեկտ, որը նախատեսված է վերադարձվող ծնող փաստաթղթերը ֆիլտրելու համար։

### GetDocumentParentsAsync

```c#
public Task<List<DocumentResponseInfo>> GetDocumentParentsAsync(int isn, DocumentParentsRequestModel model, CancellationToken cancellationToken = default)
```

Վերադարձնում է `List<DocumentResponseInfo>` տիպի օբյեկտ, որը պարունակում փաստաթղթի ծնող փաստաթղերի isn-ների ու ներքին անունների (տեսակների) ցուցակը:

Եթե փաստաթուղթը չի ունենում ծնողներ, ապա ֆունկցիան վերադարձնում է դատարկ ցուցակ։

**Պարամետրեր**

* `isn` - Զավակ փաստաթղթի ներքին նույնականացման համարը:
* `model` - `DocumentParentsRequestModel` տիպի օբյեկտ, որը նախատեսված է վերադարձվող ծնող փաստաթղթերը ֆիլտրելու համար։
* `cancellationToken` - Ընդհատման օբյեկտ:

### Load

```c#
public DocumentModelSimple Load(int isn, bool throwExceptionIfDeleted = true, bool lookInArchive = false)
```

Բեռնում է տվյալների պահոցում գոյություն ունեցող փաստաթուղթը ըստ ներքին նույնականացման համարի։

Վերադարձնում է Փաստաթղթի օբյեկտը, եթե հայտնաբերվել է։  
Եթե չի հայտնաբերվել առաջացնում է սխալ կամ վերադարձնում է **null** կախված `throwExceptionIfDeleted` պարամետրից։

**Պարամետրեր**

* `isn` - Բեռնվող փաստաթղթի ներքին նույնականացման համարը։
* `throwExceptionIfDeleted` - Պահանջվող փաստաթղթի հեռացված լինելու դեպքում սխալի առաջացման հայտանիշ։
* `lookInArchive` - Արխիվացված փաստաթղթի բեռնման հայտանիշ։ 
  **true** արժեքի դեպքում փաստաթղթի բեռնումը փորձում է կատարել նաև արխիվային տվյալների պահոցից, եթե այնտեղ նույնպես փաստաթութը առկա չէ, առաջանում է սխալ։ 

### LoadAsync

```c#
public Task<DocumentModelSimple> LoadAsync(int isn, bool throwExceptionIfDeleted = true, bool lookInArchive = false, CancellationToken cancellationToken = default)
```

Բեռնում է տվյալների պահոցում գոյություն ունեցող փաստաթուղթը ըստ ներքին նույնականացման համարի։

Վերադարձնում է Փաստաթղթի օբյեկտը, եթե հայտնաբերվել է։  
Եթե չի հայտնաբերվել առաջացնում է սխալ կամ վերադարձնում է **null** կախված `throwExceptionIfDeleted` պարամետրից։

**Պարամետրեր**

* `isn` - Բեռնվող փաստաթղթի ներքին նույնականացման համարը։
* `throwExceptionIfDeleted` - Պահանջվող փաստաթղթի հեռացված լինելու դեպքում սխալի առաջացման հայտանիշ։
* `lookInArchive` - Արխիվացված փաստաթղթի բեռնման հայտանիշ։ 
  **true** արժեքի դեպքում փաստաթղթի բեռնումը փորձում է կատարել նաև արխիվային տվյալների պահոցից, եթե այնտեղ նույնպես փաստաթութը առկա չէ, առաջանում է սխալ։
* `cancellationToken` - Ընդհատման օբյեկտ:

### LoadFromFolder

```c#
public DocumentModel LoadFromFolder(string folder, string key, bool isExtended = true)
```

Բեռնում է փաստաթուղթը ըստ թղթապանակի և բանալու։ Չհաջողվելու դեպքում վերադարձնում է **null**։

**Պարամետրեր**

* `folder` - Թղթապանակի ներքին անուն։
* `key` - Թղթապանակի տարրի բանալի։
* `isExtended` - Վերադարձվող `DocumentModel`-ում փաստաթղթի դաշտերի ընդլայնված անուններով պահման հայտանիշ։ Ընդլայնված դաշտի օրինակ՝ 
  ```c#
  [DocumentField("State")] // դաշտի տվյալների բազայում գրանցված ներքին անուն
  public string ContrState // դաշտի նոր նշանակված ներքին անուն
  ```
  Պարամետրի true արժեքի դեպքում վերադարձվող `DocumentModel`-ում դաշտերը պահվում են ընդլայնված ներքին անունով (այս օրինակում՝ `ContrState`), հակառակ դեպքում տվյալների բազայում առկա ներքին անունով (այս օրինակում՝ `State`)։

### LoadFromFolderAsync

```c#
public Task<DocumentModel> LoadFromFolderAsync(string folder, string key, bool isExtended = true, CancellationToken cancellationToken = default)
```

Բեռնում է փաստաթուղթը ըստ թղթապանակի և բանալու։ Չհաջողվելու դեպքում վերադարձնում է **null**։

**Պարամետրեր**

* `folder` - Թղթապանակի ներքին անուն։
* `key` - Թղթապանակի տարրի բանալի։
* `isExtended` - Վերադարձվող `DocumentModel`-ում փաստաթղթի դաշտերի ընդլայնված անուններով պահման հայտանիշ։ Ընդլայնված դաշտի օրինակ՝ 
  ```c#
  [DocumentField("State")] // դաշտի տվյալների բազայում գրանցված ներքին անուն
  public string ContrState // դաշտի նոր նշանակված ներքին անուն
  ```
  Պարամետրի true արժեքի դեպքում վերադարձվող `DocumentModel`-ում դաշտերը պահվում են ընդլայնված ներքին անունով (այս օրինակում՝ `ContrState`), հակառակ դեպքում տվյալների բազայում առկա ներքին անունով (այս օրինակում՝ `State`)։
* `cancellationToken` - Ընդհատման օբյեկտ:

### Store

```c#
public DocumentModel Store(DocumentStoreRequestModel model)
```

Կատարում է պարտադիր ստուգումներ և գրանցում փաստաթուղթը տվյալների պահոցում։

**Պարամետրեր**

* `model` - Գրանցվող փաստաթղթի տվյալները ([փաստաթղթի ստուգման մակարդակ](../../server_api/types/DocumentCheckLevel.md), isn, գրանցվող դաշտերի արժեքներ...)։

### StoreAsync

```c#
public Task<DocumentModel> StoreAsync(DocumentStoreRequestModel model, CancellationToken cancellationToken = default)
```

Կատարում է պարտադիր ստուգումներ և գրանցում փաստաթուղթը տվյալների պահոցում։

**Պարամետրեր**

* `model` - Գրանցվող փաստաթղթի տվյալները ([փաստաթղթի ստուգման մակարդակ](../../server_api/types/DocumentCheckLevel.md), isn, գրանցվող դաշտերի արժեքներ...)։
* `cancellationToken` - Ընդհատման օբյեկտ:
