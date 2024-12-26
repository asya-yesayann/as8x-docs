---
layout: page
title: "IDocumentService սերվիս" 
tags: [AsDoc, Doc, DocumentService]
sublinks:
- { title: "Approve", ref: approve }
- { title: "CheckProcessingMode", ref: checkprocessingmode }
- { title: "CleanDeleted", ref: cleandeleted }
- { title: "Copy", ref: copy }
- { title: "Create", ref: create }
- { title: "Create", ref: create-1 }
- { title: "Create", ref: create-2 }
- { title: "CreateFactsUsingStateMoverFrom", ref: createfactsusingstatemoverfrom }
- { title: "CreateParentLinkDB", ref: createparentlinkdb }
- { title: "CreateParentLinksDB", ref: createparentlinksdb }
- { title: "CreationDate", ref: creationdate }
- { title: "CutChildLink", ref: cutchildlink }
- { title: "CutParentLink", ref: cutparentlink }
- { title: "Delete", ref: delete }
- { title: "Delete", ref: delete-1 }
- { title: "DeserializeRequestBody", ref: deserializerequestbody }
- { title: "ExistInDb", ref: existindb }
- { title: "FieldToAnsi", ref: fieldtoansi }
- { title: "FieldsToAnsi", ref: fieldstoansi }
- { title: "GetDocsInfo", ref: getdocsinfo }
- { title: "GetDocumentChildren", ref: getdocumentchildren }
- { title: "GetDocumentParents", ref: getdocumentparents }
- { title: "GetDocumentState", ref: getdocumentstate }
- { title: "GetDocumentStatus", ref: getdocumentstatus }
- { title: "GetDocumentType", ref: getdocumenttype }
- { title: "GetDocumentTypeFromFolder", ref: getdocumenttypefromfolder }
- { title: "GetGrandChildren", ref: getgrandchildren }
- { title: "GetParentIsn", ref: getparentisn }
- { title: "GetParentIsn", ref: getparentisn-1 }
- { title: "GetPassedState", ref: getpassedstate }
- { title: "GetPassedState", ref: getpassedstate-1 }
- { title: "GetPassedState", ref: getpassedstate-2 }
- { title: "GetPassedState", ref: getpassedstate-3 }
- { title: "GetProcessingModes", ref: getprocessingmodes }
- { title: "GetSUIDAndDate", ref: getsuidanddate }
- { title: "HiDelete", ref: hidelete }
- { title: "HiDeleteAll", ref: hideleteall }
- { title: "HiParDelete", ref: hipardelete }
- { title: "IsArchived", ref: isarchived }
- { title: "Load", ref: load }
- { title: "Load", ref: load-1 }
- { title: "LoadFromFolder", ref: loadfromfolder }
- { title: "LoadFromFolder", ref: loadfromfolder-1 }
- { title: "MakeParentLink", ref: makeparentlink }
- { title: "ReFolder", ref: refolder }
- { title: "Store", ref: store }
- { title: "StoreFact", ref: storefact }
- { title: "StoreInFolder", ref: storeinfolder }
- { title: "StoreInTree", ref: storeintree }
---

## Բովանդակություն

- [Ներածություն](#ներածություն)
- [Մեթոդներ](#մեթոդներ)
  - [Approve](#approve)
  <!-- - [CheckAndStore](#checkandstore) -->
  - [CheckProcessingMode](#checkprocessingmode)
  - [CleanDeleted](#cleandeleted)
  - [Copy](#copy)
  - [Create](#create)
  - [Create](#create-1)
  - [Create](#create-2)
  - [CreateFactsUsingStateMoverFrom](#createfactsusingstatemoverfrom)
  - [CreateParentLinkDB](#createparentlinkdb)
  - [CreateParentLinksDB](#createparentlinksdb)
  - [CreationDate](#creationdate)
  - [CutChildLink](#cutchildlink)
  - [CutParentLink](#cutparentlink)
  <!-- - [DecodeDocLogState](#decodedoclogstate) -->
  - [Delete](#delete)
  - [Delete](#delete-1)
  <!-- - [DeleteAll](#deleteall) -->
  - [DeserializeRequestBody](#deserializerequestbody)
  - [ExistInDb](#existindb)
  - [FieldToAnsi](#fieldtoansi)
  - [FieldsToAnsi](#fieldstoansi)
  <!-- - [GetCaption](#getcaption) -->
  - [GetDocsInfo](#getdocsinfo)
  - [GetDocumentChildren](#getdocumentchildren)
  - [GetDocumentParents](#getdocumentparents)
  - [GetDocumentState](#getdocumentstate)
  - [GetDocumentStatus](#getdocumentstatus)
  - [GetDocumentType](#getdocumenttype)
  - [GetDocumentTypeFromFolder](#getdocumenttypefromfolder)
  - [GetGrandChildren](#getgrandchildren)
  - [GetParentIsn](#getparentisn)
  - [GetParentIsn](#getparentisn-1)
  - [GetPassedState](#getpassedstate)
  - [GetPassedState](#getpassedstate-1)
  - [GetPassedState](#getpassedstate-2)
  - [GetPassedState](#getpassedstate-3)
  <!-- - [GetParentIsn](#getparentisn-2) -->
  - [GetProcessingModes](#getprocessingmodes)
  - [GetSUIDAndDate](#getsuidanddate)
  - [HiDelete](#hidelete)
  - [HiDeleteAll](#hideleteall)
  - [HiParDelete](#hipardelete)
  - [IsArchived](#isarchived)
  - [Load](#load)
  - [Load](#load-1)
  - [LoadFromFolder](#loadfromfolder)
  - [LoadFromFolder](#loadfromfolder-1)
  - [MakeParentLink](#makeparentlink)
  - [ReFolder](#refolder)
  - [Store](#store)
  - [StoreFact](#storefact)
  - [StoreInFolder](#storeinfolder)
  - [StoreInTree](#storeintree)
  
## Ներածություն

IDocumentService դասը նախատեսված է փաստաթղթի ([Document](../definitions/document.md)) հետ աշխատանքը ապահովելու համար։


## Մեթոդներ

### Approve

```c#
public Task Approve(Document document, 
                    DocumentCheckLevel checkLevel = DocumentCheckLevel.None, 
                    string logComment = "")
```

Հաստատում է փաստաթուղթը և գրանցում տվյալների պահոցում։

**Պարամետրեր**

* `document` - [Փաստաթղթի օբյեկտ](../definitions/document.md)։
* `checkLevel` - [Փաստաթղթի գրանցման եղանակ](../types/DocumentCheckLevel.md)։
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

* `document` - [Փաստաթղթի օբյեկտ](../definitions/document.md)։
* `mode` - [Փաստաթղթի պահպանման ռեժիմը](StoreMode.md)։
* `checkLevel` - [Փաստաթղթի ստուգման մակարդակը](DocumentCheckLevel.md)։
* `stateBeforeCallPostMessage` - Փաստաթղթի վիճակը PostMessage մեթոդի կանչից առաջ։
* `logComment` - Փաստաթղթի պատմության մեջ գրանցվող հաղորդագրություն։ -->

### CheckProcessingMode

```c#
public Task CheckProcessingMode(string docType)
```

Ստուգում է տրված տեսակի փաստաթղթերի գրանցման/հեռացման հնարավորությունը 8X սերվիսում (փաստաթղթի կատարման ռեժիմը (ProcessingMode) չլինի `0`)։
`0` լինելու դեպքում առաջանում է սխալ։

**Պարամետրեր**

* `docType` - Փաստաթղթի ներքին անունը (տեսակը)։

### CleanDeleted

```c#
public Task CleanDeleted(DateTime startDate, DateTime endDate, string docType = "")
```

Ջնջված փաստաթղթերը լրիվ հեռացնում է համակարգից ըստ ջնջման ժամանակահատվածի։

**Պարամետրեր**

* `startDate` - ժամանակահատվածի սկզբի ամսաթիվ։
* `endDate` - ժամանակահատվածի վերջին ամսաթիվ։
* `docType` - Փաստաթղթի ներքին անունը (տեսակը)։
  Չլրացնելու դեպքում մաքրվում են նշված ժամանակահատվածում հեռացված բոլոր փաստաթղթերը։

### Copy

```c#
public Task<Document> Copy(int isn, object beforeCopyParam = null, int copyDocMode = 0)
```

Ստեղծում է արդեն գոյություն ունեցող փաստաթղթի պատճեն օբյեկտը։
Տրված ISN-ով փաստաթուղթը բեռնում է տվյալների պահոցից, որի հիման վրա ստեղծում է պատճեն օբյեկտը։

**Պարամետրեր**

* `isn` - Պատճենման ենթակա փաստաթղթի ներքին նույնականացման համար:
* `beforeCopyParam` - Տվյալ պարամետրի արժեքը փոխանցվում է փաստաթղթի [BeforeCopy](../definitions/document.md#beforecopy) իրադարձության մշակիչին։ 
* `copyDocMode` - Փաստաթղթի պատճենման ռեժիմ։ 
  `0` - Պատճենվում են բոլոր դաշտերի արժեքները։  
  `1` - Պատճենման ռեժիմը կախված է փաստաթղթի նկարագրության [CopyAsRepeatable](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Defs/doc.md) հատկության արժեքից։  
  `2` - Պատճենվում են միայն այն դաշտերը, որոնք պարունակում են `N` հայտանիշը։  

### Create

```c#
public Task<T> Create<T>(List<int> parentsISN = null, 
                         DocumentOrigin origin = DocumentOrigin.AsService
                         ) where T : Document
```
<!-- public Task<T> Create<T>(List<int> parentsISN = null, DocumentOrigin origin = DocumentOrigin.AsService, params object[] parameters) where T : Document -->

Ստեղծում է նշված տիպի փաստաթղթի նոր օբյեկտ։

**Պարամետրեր**

* `T` - Փաստաթղթի նկարագրված դաս 8X-ում, [Document](../definitions/document.md) դասի ժառանգ։
* `parentsISN` - Փաստաթղթի ծնող փաստաթղթերի ISN-ների ցուցակ:
* `origin` - [Փաստաթղթի ստեղծման աղբյուրը](../types/DocumentOrigin.md):
<!-- * `parameters` - Արգումենտների զանգված, որոնք փոխանցվում են փաստաթղթի կոնստրուկտորին և պիտի թվով, հերթականությամբ, տիպերով համընկնեն կանչվող կոնստրուկտորի շարահյուսությանը։
Չփոխանցելու դեպքում փաստաթղթի նոր օբյեկտը ստեղծվելու է պարամետրեր չպարունակող կոնստրուկտորի միջոցով։ -->

### Create

```c#
public Task<T> Create<T>(int parentISN, 
                         DocumentOrigin origin = DocumentOrigin.AsService
                         ) where T : Document
```
<!-- public Task<T> Create<T>(int parentISN, DocumentOrigin origin = DocumentOrigin.AsService, params object[] parameters) where T : Document -->

Ստեղծում է նշված տիպի փաստաթղթի նոր օբյեկտ։

**Պարամետրեր**

* `T` - Փաստաթղթի նկարագրված դաս 8X-ում, [Document](../definitions/document.md) դասի ժառանգ։
* `parentISN` - Փաստաթղթի ծնող փաստաթղթի ISN-ը:
* `origin` - [Փաստաթղթի ստեղծման աղբյուրը](../types/DocumentOrigin.md):
<!-- * `parameters` - Արգումենտների զանգված, որոնք փոխանցվում են փաստաթղթի կոնստրուկտորին և պիտի թվով, հերթականությամբ, տիպերով համընկնեն կանչվող կոնստրուկտորի շարահյուսությանը։
Չփոխանցելու դեպքում փաստաթղթի նոր օբյեկտը ստեղծվելու է պարամետրեր չպարունակող կոնստրուկտորի միջոցով։ -->

### Create

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
* `instanceType` - Փաստաթղթի նկարագրված դաս 8X-ում, [Document](../definitions/document.md) դասի ժառանգ։։
* `origin` - [Փաստաթղթի ստեղծման աղբյուրը](../types/DocumentOrigin.md):
<!-- * `parameters` - Արգումենտների զանգված, որոնք փոխանցվում են փաստաթղթի կոնստրուկտորին և պիտի թվով, հերթականությամբ, տիպերով համընկնեն կանչվող կոնստրուկտորի շարահյուսությանը։
Չփոխանցելու դեպքում փաստաթղթի նոր օբյեկտը ստեղծվելու է պարամետրեր չպարունակող կոնստրուկտորի միջոցով։ -->

### CreateFactsUsingStateMoverFrom

```c#
public Task CreateFactsUsingStateMoverFrom(Document document, int state)
```

Ֆունկցիան կանչելուց հետո [Action](../definitions/document.md#action)-ում [StoreFact](#storefact) ֆունկցիայով գրանցվող հաշվառումների ստեղծող օգատգործող է լրացվում այն օգտագործողը, որը վերջինն է փաստաթուղթը բերել նշված վիճակ։

**Պարամետրեր**

* `document` - [Փաստաթղթի օբյեկտ](../definitions/document.md)։
* `state` - Այն վիճակը, որը վերջին անգամ հասցնող օգտագործողը լրացվելու է, որպես գրանցվող հաշվառումների ստեղծող:

### CreateParentLinkDB

```c#
public Task CreateParentLinkDB(int isn, int parentIsn = -1)
```

Փաստաթղթերի միջև ստեղծում է ծնող-զավակ կապ։ 
Ֆունկցիան ստեղծում է կապը անմիջապես տվյալների պահոցում։ 
Զավակ փաստաթուղթը պետք է գրանցված լինի տվյալների պահոցում։

Ի տարբերություն [MakeParentLink](#makeparentlink)-ի այս ֆունկցիան կարելի է կանչել ամենուրեք։

**Պարամետրեր**

* `isn` - Զավակ փաստաթղթի ներքին նույնականացման համար:
* `parentIsn` - Ծնող փաստաթղթի ներքին նույնականացման համար։

### CreateParentLinksDB

```c#
public  Task CreateParentLinksDB(int isn, List<int> parentsIsn)
```

Փաստաթղթի և տրված ծնող փաստաթղթերի միջև ստեղծում է ծնող-զավակ կապ։ 
Ֆունկցիան ստեղծում է կապը անմիջապես տվյալների պահոցում։ 
Զավակ փաստաթուղթը պետք է գրանցված լինի տվյալների պահոցում։

Ի տարբերություն  [MakeParentLink](#makeparentlink)-ի այս ֆունկցիան կարելի է կանչել ամենուրեք։

**Պարամետրեր**

* `isn` - Զավակ փաստաթղթի ներքին նույնականացման համար:
* `parentIsn` - Ծնող փաստաթղթերի ներքին նույնականացման համարների ցուցակ։

### CreationDate

```c#
public Task<(DateTime CreationDate, short SUID)> CreationDate(int isn, bool isNotRiseErrWhenNoRow = false)
```

Վերադարձնում է փաստաթղթի ստեղծման ամսաթիվը և ստեղծողի ներքին համարը։

**Պարամետրեր**

* `isn` - Փաստաթղթի ներքին նույնականացման համար:
* `isNotRiseErrWhenNoRow` - Պահանջվող փաստաթղթի չգտնվելու դեպքում սխալի առաջացման հայտանիշ։
  `true` արժեքի դեպքում տվյալների պահոցում փաստաթղթի բացակայության ժամանակ վերադարձնում է `01/01/1900` և `-1` արժեքները:

### CutChildLink

```c#
public Task CutChildLink(int isn, int childIsn = -1)
```

Ջնջում է փաստաթղթի և իրա զավակների միջև կապերը, կամ մեկ նշված զավակ փաստաթղթի հետ կապը։

**Պարամետրեր**

* `isn` - Այն փաստաթղթի ներքին նույնականացման համարը, որի համար խզվում է զավակների հետ կապը։
* `childIsn` - Մեկ զավակի ներքին նույնականացման համար, այդ զավակի կապը կզելու համար։
  Եթե պարամետրը փոխանցված չէ, ապա կապը խզվում է բոլոր առկա զավակների հետ։

### CutParentLink

```c#
public Task CutParentLink(int isn, int parentIsn = -1)
```

Ջնջում է փաստաթղթի և իրա ծնողների միջև կապերը, կամ մեկ նշված ծնող փաստաթղթի հետ կապը։

**Պարամետրեր**

* `isn` - Այն փաստաթղթի ներքին նույնականացման համարը, որի համար խզվում է կապը ծնողի հետ։
* `parentIsn` - Մեկ ծնողի ներքին նույնականացման համար, այդ ծնողի կապը կզելու համար։
  Եթե պարամետրը փոխանցված չէ, ապա կապը խզվում է բոլոր առկա ծնողների հետ։

<!-- ### DecodeDocLogState

```c#
public string DecodeDocLogState(string operationCode, string comment)
```

Վերադարձնում է փաստաթղթի պատմությունում գրանցված գործողության կոդին համապատասխան հաղորդագրությունը՝ աջից ավելացնելով `comment` պարամետրում գրված հաղորդագրությունը ծրագրի ընթացիկ լեզվով։

**Պարամետրեր**

* `operationCode` - Փաստաթղթի պատմությունում գրանցված գործողության կոդ։
* `comment` - Լրացուցիչ հաղորդագրություն։
-->

### Delete

```c#
public Task<DeletedDoc> Delete(int isn,
                               bool fullDelete,
                               string comment,
                               bool callDelete = true,
                               bool inheritedDelete = false)
```

Ջնջում է փաստաթուղթը համակարգից։  
Ջնջվող փաստաթղթերի համար առաջանում է [Delete](../definitions/document.md#delete) իրադարձությունը, ապա փաստաթղթի վիճակը դառնում է 999, որից հետո այդ փաստաթուղթը հայտնվում է ջնջված փաստաթղթերի թղթապանակում։ 
Ջնջման ժամանակ հեռացվում են նաև այդ փաստաթղթի բոլոր թղթապանակները, ծառի տարրերը և իր համար գրանցված հաշվառումները։

Եթե փաստաթուղթը ունի ենթափաստաթղթեր, ապա ջնջումը չի կատարվի և կառաջանա սխալ։

Ջնջումը տեղի է ունենում տրանզակցիայի մեջ։

**Պարամետրեր**

* `isn` - Ջնջվող փաստաթղթի ներքին նույնականացման համարը:
* `fullDelete` - Փաստաթղթի վերջնական ջնջման հայտանիշ։  
  Վերջնական ջնջման ժամանակ փաստաթուղթը ջնջվում է բոլոր միջուկային աղյուսակներից՝ [DOCP](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/DocP.html), [FOLDERS](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Folders.html), [TREES](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Trees.html), [HIPAR](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/HiPar.html), [HIREST](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Hirest.html), [HIREST2](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Hirest2.html), [ACCESS](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Access.html), [HI](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Hi.html) և [HI2](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Hi2.html)։  
  Ոչ վերջնական ջնջման ժամանակ փաստաթուղթը մնում է [DOCS](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Docs.html), [DOCLOG](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/DocLog.html), [DOCSG](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/DocsG.html), [DOCSIM](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Docsim.html) աղյուսակների մեջ և վիճակը լինում է 999:
* `comment` - Փաստաթղթի պատմության մեջ գրանցվող ջնջման մեկնաբանություն։
* `callDelete` - Փաստաթղթի [Delete](../definitions/document.md#delete) իրադարձությունը կանչելու հայտանիշ։ 
* `inheritedDelete` - `true` արժեքի դեպքում փաստաթղթի պատմության մեջ գրվում է, որ փաստաթուղթը ջնջվել է այլ փաստաթղթի ջնջման ընթացքում։ 
  Տվյալների պահոցում ջնջման կոդը լինում է `H`, հակառակ դեպքում `D`։

### Delete

```c#
public Task<DeletedDoc> Delete(Document document,
                               bool fullDelete,
                               string comment,
                               bool callDelete = true,
                               bool inheritedDelete = false)
```

Ջնջում է փաստաթուղթը համակարգից։  
Ջնջվող փաստաթղթերի համար առաջանում է [Delete](../definitions/document.md#delete) իրադարձությունը, ապա փաստաթղթի վիճակը դառնում է 999, որից հետո այդ փաստաթուղթը հայտնվում է ջնջված փաստաթղթերի թղթապանակում։ 
Ջնջման ժամանակ հեռացվում են նաև այդ փաստաթղթի բոլոր թղթապանակները, ծառի տարրերը և իր համար գրանցված հաշվառումները։

Եթե փաստաթուղթը ունի ենթափաստաթղթեր, ապա ջնջումը չի կատարվի և կառաջանա սխալ։

Ջնջումը տեղի է ունենում տրանզակցիայի մեջ։

**Պարամետրեր**

* `document` - Ջնջվող [փաստաթուղթ](../definitions/document.md)։
* `fullDelete` - Փաստաթղթի վերջնական ջնջման հայտանիշ։  
  Վերջնական ջնջման ժամանակ փաստաթուղթը ջնջվում է բոլոր միջուկային աղյուսակներից՝ [DOCP](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/DocP.html), [FOLDERS](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Folders.html), [TREES](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Trees.html), [HIPAR](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/HiPar.html), [HIREST](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Hirest.html), [HIREST2](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Hirest2.html), [ACCESS](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Access.html), [HI](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Hi.html) և [HI2](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Hi2.html)։  
  Ոչ վերջնական ջնջման ժամանակ փաստաթուղթը մնում է [DOCS](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Docs.html), [DOCLOG](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/DocLog.html), [DOCSG](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/DocsG.html), [DOCSIM](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Docsim.html) աղյուսակների մեջ և վիճակը լինում է 999:
* `comment` - Փաստաթղթի պատմության մեջ գրանցվող ջնջման մեկնաբանություն։
* `callDelete` - Փաստաթղթի [Delete](../definitions/document.md#delete) իրադարձությունը կանչելու հայտանիշ։ 
* `inheritedDelete` - `true` արժեքի դեպքում փաստաթղթի պատմության մեջ գրվում է, որ փաստաթուղթը ջնջվել է այլ փաստաթղթի ջնջման ընթացքում։ 
  Տվյալների պահոցում ջնջման կոդը լինում է `H`, հակառակ դեպքում `D`։

<!-- ### DeleteAll

```c#
public Task DeleteAll(List<int> isnList, bool fullDelete, string comment, bool callDelete = true, bool inheritedDelete = false)
```

Ջնջում է տրված փաստաթղթերը համակարգից հերթականաությամբ։ Եթե որևէ փաստաթուղթ հնարավոր չէ ջնջել, կառաջանա սխալ և հաջորդ փաստաթղթերը չեն ջնջվի։

Ջնջվող փաստաթղթերի համար առաջանում է [Delete](../definitions/document.md#delete) իրադարձությունը, ապա փաստաթղթերի վիճակը դառնում է 999, որից հետո այդ փաստաթուղթը հայտնվում է ջնջված փաստաթղթերի թղթապանակում։ 
Ջնջման ժամանակ հեռացվում են նաև այդ փաստաթղթերի բոլոր թղթապանակները, ծառի տարրերը և իր համար գրանցված հաշվառումները։

Եթե փաստաթուղթերը ունեն ենթափաստաթղթեր, ապա ջնջումը չի կատարվի և կառաջանա սխալ։

Ջնջումը տեղի է ունենում տրանզակցիայի մեջ։

**Պարամետրեր**

* `document` - Ջնջվող փաստաթղթերի ներքին նույնականացման համարների ցուցակ։
* `fullDelete` - Փաստաթղթերի վերջնական ջնջման հայտանիշ։  
  Վերջնական ջնջման ժամանակ փաստաթղթերը ջնջվում է բոլոր միջուկային աղյուսակներից՝ [DOCP](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/DocP.html), [FOLDERS](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Folders.html), [TREES](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Trees.html), [HIPAR](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/HiPar.html), [HIREST](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Hirest.html), [HIREST2](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Hirest2.html), [ACCESS](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Access.html), [HI](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Hi.html) և [HI2](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Hi2.html)։  
  Ոչ վերջնական ջնջման ժամանակ փաստաթղթերը մնում են [DOCS](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Docs.html), [DOCLOG](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/DocLog.html), [DOCSG](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/DocsG.html), [DOCSIM](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Docsim.html) աղյուսակներում և վիճակը լինում է 999:
* `comment` - Փաստաթղթերի պատմության մեջ գրանցվող ջնջման մեկնաբանություն:
* `callDelete` - Փաստաթղթերի [Delete](../definitions/document.md#delete) իրադարձությունը կանչելու հայտանիշ։ 
* `inheritedDelete` - `true` արժեքի դեպքում փաստաթղթերի պատմության մեջ գրվում է, որ փաստաթղթերը ջնջվել են այլ փաստաթղթի ջնջման ընթացքում։ 
  Տվյալների պահոցում ջնջման կոդը լինում է `H`, հակառակ դեպքում `D`։ -->

### DeserializeRequestBody

```c#
public Task<Document> DeserializeRequestBody(DocumentModel request, bool isExtended = false)
```

նախատեսված է կլիենտից դեպի սերվեր փաստաթղթի ուղարկման ժամանակ դեսերիալիզազիայի և [Document](../definitions/document.md) տիպի օբյեկտի վերածեու համար։  

Սովորաբար օգտագործվում է փաստաթղթի [DeserializeComplexObjects](../definitions/document.md#deserializecomplexobjects) մշակիչի մեջ։

**Պարամետրեր**

* `request` - Փաստաթղթի ցանցով փոխանցվող օբյեկտ։
* `isExtended` - Ցույց է տալիս արդյոք փաստաթղթի դաշտերը պետք է բերվեն `ANSI` կոդավորման և հեռացվեն ավելորդ բացակները, թե ոչ։

### ExistInDb

```c#
public Task<bool> ExistInDb(int isn)
```

Ստուգում է փաստաթղթի առկայությունը տվյալների պահոցում։

**Պարամետրեր**

* `isn` - Փաստաթղթի ներքին նույնականացման համար:

### FieldToAnsi

```c#
public  Task<object> FieldToAnsi(string docType, string name, object value)
```

<!-- Վերադարձնում է փաստաթղթի դաշտի արժեքը՝ձևափոխված համապատասխան լեզվի ANSI կոդավորման։ -->
Ձևափոխում է ցանցով փոխանցված արժեքը ANSI կոդավորման համարելով, որ այն պետք է լինի փաստաթղթի դաշտի արժեք։  

Հաշվի է առնվում  
- դաշտը լրացվում է հայերեն, թե ռուսերեն,
- փոխանցող կլինետը օգտագործում է յունկոդ տվյալներ, թե ANSI տվյալներ։

**Պարամետրեր**

* `docType` - Փաստաթղթի ներքին անունը (տեսակը)։  
* `name` - Դաշտի ներքին անուն։
* `value` - Ցանցով փոխանցված արժեք։

**Օրինակ**
Երբ ունենք [Տվյալների մշակման հարցում](../definitions/dpr.md), որը պարամետրեր է ստանում թե՛ յունիկոդով աշխատող կիենտից, թե՛ ANSI-ով աշխատող կլիենտից, ապա ստացված պարամետրերը կարիք է լինում ձևափոխել ANSI-ի կախված կլիենտի տեսակից։

<!-- CreateFinalCalculationsForSelectedRows DPR-ի մեջ  -->
**Օրինակ**
```c#
private async Task CreateVacationFromHR(Request.EmployeeFinalCalculation emplData, Request request)
{
    var docWgLvOrd = await this.documentService.Create<WgLvOrd>();
    docWgLvOrd.Code.Value = (string)await this.documentService.FieldToAnsi(nameof(WgLvOrd), nameof(WgLvOrd.Code), emplData.EmployeeNumber);
    await docWgLvOrd.SetEmployeeData();
    docWgLvOrd.DateR.NullableValue = request.OrderDate;
    docWgLvOrd.Number.Value = (string)await this.documentService.FieldToAnsi(nameof(WgLvOrd), nameof(WgLvOrd.Number), request.OrderNumber);
    docWgLvOrd.DateS.Value = request.FinalCalculationDate;
    docWgLvOrd.DateE.Value = request.FinalCalculationDate;
    docWgLvOrd.DateSC.Value = new DateTime(request.AverageYear, request.AverageMonth, 1);
    docWgLvOrd.CalcDate.Value = new DateTime(request.CalculationYear, request.CalculationMonth, 1);
    docWgLvOrd.LvType.Value = (string)await this.documentService.FieldToAnsi(nameof(WgLvOrd), nameof(WgLvOrd.LvType), request.LeaveType);
    docWgLvOrd.LvScheme.Value = (string)await this.documentService.FieldToAnsi(nameof(WgLvOrd), nameof(WgLvOrd.LvScheme), request.LeaveScheme);
    docWgLvOrd.TabType.Value = request.DaysCalculationType;
    docWgLvOrd.fCalc.Value = true;
    docWgLvOrd.fDni.Value = Math.Abs(emplData.FinalCalculationDays);
    docWgLvOrd.DedReCalc.Value = emplData.FinalCalculationDays < 0;
    docWgLvOrd.Coment.Value = (string)await this.documentService.FieldToAnsi(nameof(WgLvOrd), nameof(WgLvOrd.Coment), request.Comment);
    docWgLvOrd.bPlan.Value = "f";
    docWgLvOrd.Dni.Value = (short)Math.Abs(emplData.FinalCalculationDays);
    docWgLvOrd.MaxDni.Value = (short)Math.Abs(emplData.FinalCalculationDays);
    docWgLvOrd.SetPeriodAndYear();
    docWgLvOrd.bISN.Value = docWgLvOrd.ISN;
    docWgLvOrd.Property_LeaveGr = true;
    docWgLvOrd.Property_DontCheckPeriodCrossing = true;
    docWgLvOrd.BuildEmbeddedUIRequest(this.Progress);
    await docWgLvOrd.Store();
}
```

### FieldsToAnsi

```c#
public Task<Dictionary<string, object>> FieldsToAnsi(string docType, Dictionary<string, object> fields)
```

<!-- Վերադարձնում է փաստաթղթի դաշտերի արժեքները՝ ձևափոխված  համապատասխան լեզվի ANSI կոդավորման։ -->
Ձևափոխում է ցանցով փոխանցված արժեքների բազմությունը ANSI կոդավորման համարելով, որ դրանք պետք է լինեն փաստաթղթի դաշտերի արժեքներ։ 

Հաշվի է առնվում  
- դաշտը լրացվում է հայերեն, թե ռուսերեն,
- փոխանցող կլինետը օգտագործում է յունկոդ տվյալներ, թե ANSI տվյալներ։

Տե՛ս նաև [FieldToAnsi](#fieldtoansi)

**Պարամետրեր**

* `docType` - Փաստաթղթի ներքին անունը (տեսակը)։  
* `fields` - Փաստաթղթի դաշտերի ներքին անունների և արժեքների բազմություն։

<!-- ### GetCaption

```c#
public Task<(string caption, string englishCaption)> GetCaption(string docType)
```

Վերադարձնում է փաստաթղթի հայերեն և անգլերեն անվանումները։

**Պարամետրեր**

* `docType` - Փաստաթղթի տեսակ։ -->

### GetDocsInfo

```c#
public ArchiveInfo GetDocsInfo()
```

Վերադարձնում է փաստաթղթերի արխիվը պարունակող տվյալների պահոցի անունը և Sql միացումը դեպի այդ տվյալների պահոց։

### GetDocumentChildren

```c#
public Task<List<(int isn, string docType)>> GetDocumentChildren(
    int isn, 
    string docType = "", 
    DocumentChildrenOrder order = DocumentChildrenOrder.UnOrdered, 
    string docTypeLike = "")
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

### GetDocumentParents

```c#
public Task<List<(int isn, string docType)>> GetDocumentParents(
    int isn, 
    string docType = "", 
    DocumentChildrenOrder order = DocumentChildrenOrder.UnOrdered, 
    string docTypeLike = "")
```

Վերադարձնում է փաստաթղթի ծնող փաստաթղերի isn-ների ու ներքին անունների (տեսակների) ցուցակը:

Եթե փաստաթուղթը չի ունենում ծնողներ, ապա ֆունկցիան վերադարձնում է դատարկ ցուցակ։

**Պարամետրեր**

* `isn` - Զավակ փաստաթղթի ներքին նույնականացման համարը:
* `docType` - Սահմանում է ներառվող կամ չներառվող ծնող փաստաթղթերի տիպերը։  
  Եթե պարամետրը առկա չի, ապա վերադարձվում են բոլոր տիպի ծնող փաստաթղթերի isn-ները ու տեսակները։  
  Ներառվող տիպերի ցուցակը թվարկվում են `+` նշանով սկսելով՝ փաստաթղթի տեսակների անվանումները իրարից առանձնացնելով բացատներով։ 
  Օրինակ՝ `"+KasPr MemOrd SetPr"`։  
  Չներառվող տիպերի ցուցակը թվարկվում են `-` նշանով սկսելով՝ փաստաթղթի տեսակների անվանումները իրարից առանձնացնելով բացատներով։ 
  Օրինակ՝ `"-AccDoc AsTurn"`։
  Միայն նշված տիպի ծնող փաստաթղթերը վերադարձնելու համար անհրաժեշտ է ավելացնել փաստաթղթի տեսակը։ 
  Օրինակ՝ `"AccDoc"`:
* `order` - Ըստ ծնող փաստաթղթերի ստեղծման ամսաթվի դասավորման նշան։
DocumentChildrenOrder.UnOrdered - Չի դասավորվում։
DocumentChildrenOrder.CreationDateAscending - Դասավորվում է աճման կարգով։
DocumentChildrenOrder.CreationDateDescending - Դասավորվում է նվազման կարգով։
* `docTypeLike` - Սահմանում է ներառվող կամ չներառվող ծնող փաստաթղթերի տիպերի ֆիլտր։ 
  Եթե պարամետրը առկա չի, ապա վերադարձվում են բոլոր տիպի ծնող  փաստաթղթերի isn-ները ու տեսակները։  
  Ներառվող տիպերի ֆիլտրը `+` նշանով սկսելով։ 
  Օրինակ՝ `"+Acc%"`։  
  Չներառվող տիպերի ֆիլտրը `-` նշանով սկսելով։ 
  Օրինակ՝ `"-Acc%"`։

### GetDocumentState

```c#
public Task<int> GetDocumentState(int isn)
```

Վերադարձնում է փաստաթղթի վիճակը։
Եթե փաստաթուղթը առկա չի, կամ ոչ վերջնական ջնջված է, ապա ֆունկցիան վերադարձնում է `-1` արժեք։

**Պարամետրեր**

* `isn` - Փաստաթղթի ներքին նույնականացման համար։

### GetDocumentStatus

```c#
public Task<byte> GetDocumentStatus(string folderID, int isn)
```

Վերադարձնում է թղթապանակի տարրի վիճակը։

**Պարամետրեր**

* `folderID` - Թղթապանակի ներքին անուն:
* `isn` - Փաստաթղթի ներքին նույնականացման համար։

### GetDocumentType 

```c#
public Task<string> GetDocumentType(int isn)
```

Վերադարձնում է նշված ներքին նույնականացման համարով փաստաթղթի ներքին անունը (տեսակը)։

**Պարամետրեր**

* `isn` - Փաստաթղթի ներքին նույնականացման համար։

### GetDocumentTypeFromFolder

```c#
public Task<string> GetDocumentTypeFromFolder(string folder, string key)
```

Վերադարձնում է նշված թղթապանակից փաստաթղթի ներքին անունը (տեսակը):

**Պարամետրեր**

* `folder` - Թղթապանակի ներքին անուն։
* `key` - Թղթապանակի տարրի բանալի։

### GetGrandChildren

```c#
public Task<List<int>> GetGrandChildren(int isn, 
                                        string docType1 = "", 
                                        string docTypeLike1 = "", 
                                        string docType2 = "", 
                                        string docTypeLike2 = "")
```

Նշված փաստաթղթի համար վերադարձնում է «թոռնիկների» ցուցակը։

**Պարամետրեր**

* `isn` - Ծնող փաստաթղթի ներքին նույնականացման համար:
* `docType1` - Սահմանում է ներառվող կամ չներառվող զավակ փաստաթղթերի տիպերը։ 
  Եթե պարամետրը առկա չի, ապա դիտարկվում են բոլոր տիպի զավակ փաստաթղթերի զավակները։  
  Ներառվող տիպերի ցուցակը թվարկվում են `+` նշանով սկսելով։ 
  Օրինակ՝ `"+KasPr MemOrd SetPr"`։  
  Չներառվող տիպերի ցուցակը թվարկվում են `-` նշանով սկսելով։ 
  Օրինակ՝ `"-AccDoc AsTurn"`։
* `docTypeLike1` - Սահմանում է ներառվող կամ չներառվող զավակ փաստաթղթերի տիպերի ֆիլտր։ 
  Եթե պարամետրը առկա չի, ապա դիտարկվում են բոլոր տիպի զավակ փաստաթղթերի զավակները։  
  Ներառվող տիպերի ֆիլտրը `+` նշանով սկսելով։ 
  Օրինակ՝ `"+Acc%"`։  
  Չներառվող տիպերի ֆիլտրը `-` նշանով սկսելով։ 
  Օրինակ՝ `"-Acc%"`։
* `docType2` - Սահմանում է ներառվող կամ չներառվող թոռնիկ փաստաթղթերի տիպերը։ 
  Եթե պարամետրը առկա չի, ապա վերադարձվում են բոլոր տիպի թոռնիկների ISN-ները։  
  Ներառվող տիպերի ցուցակը թվարկվում են `+` նշանով սկսելով։ 
  Օրինակ՝ `"+KasPr MemOrd SetPr"`։  
  Չներառվող տիպերի ցուցակը թվարկվում են `-` նշանով սկսելով։ 
  Օրինակ՝ `"-AccDoc AsTurn"`։
* `docTypeLike2` - Սահմանում է ներառվող կամ չներառվող թոռնիկ փաստաթղթերի տիպերի ֆիլտր։ 
  Եթե պարամետրը առկա չի, ապա վերադարձվում են բոլոր տիպի թոռնիկների ISN-ները։  
  Ներառվող տիպերի ֆիլտրը `+` նշանով սկսելով։ 
  Օրինակ՝ `"+Acc%"`։  
  Չներառվող տիպերի ֆիլտրը `-` նշանով սկսելով։ 
  Օրինակ՝ `"-Acc%"`։


### GetParentIsn

```c#
public Task<int> GetParentIsn(int isn)
```

Վերադարձնում է փաստաթղթի միակ(առաջին) ծնող փաստաթղթի ներքին նույնականացման համարը։ 
Եթե ծնող փաստաթղթը չկա, ապա վերադառնում է `-1`։

**Պարամետրեր**

* `isn` - Փաստաթղթի ներքին նույնականացման համար:

### GetParentIsn

```c#
public Task<int> GetParentIsn(int isn, string docTypeLike)
```

Վերադարձնում է փաստաթղթի առաջին ծնող փաստաթղթի ներքին նույնականացման համարը, որը ունի նշված ներքին անունը (տեսակը)։
Եթե ծնող փաստաթղթը չկա, ապա վերադառնում է `-1`։

**Պարամետրեր**

* `isn` - Փաստաթղթի ներքին նույնականացման համար:
* `docTypeLike` - Սահմանում է ներառվող կամ չներառվող ծնող փաստաթղթերի տիպերի ֆիլտր։  
  Ներառվող տիպերի ֆիլտրը `+` նշանով սկսելով։ 
  Օրինակ՝ `"+Acc%"`։  
  Չներառվող տիպերի ֆիլտրը `-` նշանով սկսելով։ 
  Օրինակ՝ `"-Acc%"`։

### GetPassedState

```c#
public short GetPassedState(int isn, List<short> states, bool lastState = true, bool inStates = true)
```

Ստուգում է և վերադարձնում փաստաթղթի վերջին կամ առաջին նշանակված վիճակը տրված վիճակների ցուցակից։

Համապատասխանող վիճակ չգտնելու դեպքում վերադարձնում է `-1`։

**Պարամետրեր**

* `isn` - Փաստաթղթի ներքին նույնականացման համար։
* `states` - Փաստաթղթի վիճակների ցուցակ։
* `lastState` - `true` արժեքի դեպքում վերադարձնում է վերջին նշանակված վիճակը, հակառակ դեպքում՝ առաջինը։
* `inStates` - `true` արժեքի դեպքում փնտրվում է վիճակ, տրված վիճակների ցուցակից։ 
  Հակառակ դեպքում՝ ցուցակից դուրս։

### GetPassedState

```c#
public short GetPassedState(int isn, string statesSubQuery, bool lastState = true, bool inStates = true)
```

Ստուգում է և վերադարձնում փաստաթղթի վերջին կամ առաջին նշանակված վիճակը վիճակների ցուցակը սահմանող sql հարցում արդյունքից։

Համապատասխանող վիճակ չգտնելու դեպքում վերադարձնում է `-1`։


**Պարամետրեր**

* `isn` - Փաստաթղթի ներքին նույնականացման համար։
* `statesSubQuery` - Փաստաթղթի վիճակները սահմանող sql հարցում:
* `lastState` - `true` արժեքի դեպքում վերադարձնում է վերջին նշանակված վիճակը, հակառակ դեպքում՝ առաջինը։
* `inStates` - `true` արժեքի դեպքում փնտրվում է վիճակ, վիճակների ցուցակը սահմանող sql հարցում արդյունքից։ 
  Հակառակ դեպքում՝ արդյունքից դուրս։

**Օրինակ**
```c#
var lastConfirmationState = documentService.GetPassedState(doc.ISN, 
      $"Select fSTATE From DOCLOG WHERE fISN = {doc.ISN} and fSTATE Between 100 and 200");
```

### GetPassedState

```c#
public short GetPassedState(int isn, short state, bool lastState = true, bool inStates = true)
```

Ստուգում է տրված վիճակը հանդիանում է փաստաթղթի վերջին կամ առաջին նշանակված վիճակը, թե ոչ։
Պայմանին բավարարելու դեպքում վերադարձնում է նշված վիճակը։ 
Չբավարարելու դեպքում վերադարձնում է `-1`։

**Պարամետրեր**

* `isn` - Փաստաթղթի ներքին նույնականացման համար։
* `state` - Փաստաթղթի վիճակ։
* `lastState` - `true` արժեքի դեպքում վերադարձնում է վերջին վիճակը, հակառակ դեպքում՝ առաջինը։
* `inStates` - `true` արժեքի դեպքում փնտրվում է վիճակ, որը վիճակների ցուցակի միջից է։ 
  Հակառակ դեպքում՝ ցուցակի միջից չէ։


### GetPassedState

```c#
public short GetPassedState(int isn, bool lastState = true)
```

Վերադարձնում է փաստաթղթի վերջին կամ առաջին նշանակված վիճակը։

**Պարամետրեր**

* `isn` - Փաստաթղթի ներքին նույնականացման համար։
* `lastState` - `true` արժեքի դեպքում վերադարձնում է վերջին նշանակված վիճակը, հակառակ դեպքում՝ առաջինը։

### GetProcessingModes

```c#
public  Task<DocumentProcessingModes> GetProcessingModes(string docType)
```

Վերադարձնում է փաստաթղթի կատարման ռեժիմները ըստ փաստաթղթի ներքին անվան (տեսակի)։
 
**Պարամետրեր**

* `docType` - Փաստաթղթի ներքին անուն (տեսակ):

### GetSUIDAndDate

```c#
public Task<(bool exists, short suid, string dateTime)> GetSUIDAndDate(int isn, int state, bool sort = true)
```

Փնտրում է նշված վիճակին համապատասխան տողի առկայությունը փաստաթղթի պատմության մեջ ([DOCLOG](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/DocLog.html) աղյուսակում) և վերադարձնում ստեղծողին և ամսաթիվը։

Առկայության դեպքում վերադարձնում է  
`exists` -> **true**,  
`suid` -> այդ վիճակ տեղափոխած օգտագործողի համարը,  
`dateTime` -> այդ վիճակ տեղափոխած օրը/ժամը: Արժեքը գրվում է հետևյալ ձևաչափով `yyyy-MM-dd hh:mm:ss`։

Բացակայության դեպքում  
`exists` -> **false**:

**Պարամետրեր**

* `isn` - Փաստաթղթի ներքին նույնականացման համար:
* `state` - Փնտրվող վիճակ։
* `sort` - Փաստաթուղթը նշված վիճակին բերած առաջին (`true`) կամ վերջին (`false`) անգամ վիճակը հասնելը։ 

### HiDelete

```c#
public Task<(bool had01AccRow, bool hadHIRow)> HiDelete(Document doc, bool deleteDoc)
```

Ջնջում է փաստաթղթի նախկինում գրանցած հաշվառումները [HI](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/Hi.html) աղյուսակից։  
Եթե մեթոդը կանչում են [Action](../definitions/document.md#action) իրադարձության մշակիչից, ապա սահմանաչափերի ստուգումները կկատարվեն Action-ի ավարտից հետո։  
Իսկ եթե այլ տեղից է կանչած, ապա ստուգումները կկատարվեն անմիջապես։

Վերադարձնում է կորտեժ  
`hadHIRow` - ջնջվում են որևէ հաշվառման տողեր,  
`had01AccRow` - ջնջվում են `01` հաշվառման տողեր։

**Պարամետրեր**

* `doc` - [Փաստաթղթի օբյեկտ](../definitions/document.md)։
* `deleteDoc` - հարկավոր է փոխանցել `true`, երբ ֆունկցիան կանչվում է որևէ փաստաթղթի ջնջման ժամանակ։
  Պարամետրը փոխանցվում է OnLimitFault իրադարձության մշակիչին։

### HiDeleteAll

```c#
public Task HiDeleteAll(Document doc);
```

Ջնջում է փաստաթղթի նախկինում գրանցած հաշվառումները [HI](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/Hi.html), [HI2](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/Hi2.html) և այլ համարժեք աղյուսակներից։  
Եթե մեթոդը կանչում են [Action](../definitions/document.md#action) իրադարձության մշակիչից, ապա սահմանաչափերի ստուգումները կկատարվեն Action-ի ավարտից հետո։ 
Իսկ եթե այլ տեղից է կանչած, ապա ստուգումները կկատարվեն անմիջապես։

**Պարամետրեր**

* `doc` - [Փաստաթղթի օբյեկտ](../definitions/document.md)։

### HiParDelete

```c#
public Task HiParDelete(Document doc)
```

[HIPAR](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/HiPar.html) աղյուսակից ջնջում է այս փաստաթղթի նախկինում գրանցած պարամետրերի արժեքները։

**Պարամետրեր**

* `doc` - [Փաստաթղթի օբյեկտ](../definitions/document.md)։

### IsArchived

```c#
public Task<bool> IsArchived(int isn)
```

Ստուգում է փաստաթղթի արխիվացված լինելը։

**Պարամետրեր**

* `isn` - Փաստաթղթի ներքին նույնականացման համար:

### Load

```c#
public Task<Document> Load(int isn, GridLoadMode gridLoadMode = GridLoadMode.Full,
                           bool loadImagesAndMemos = true, bool lockTableRow = false,
                           bool throwExceptionIfDeleted = true, bool lookInArc = true,
                           Type instanceType = null, bool loadParents = false)
```

Բեռնում է տվյալների պահոցում գոյություն ունեցող փաստաթուղթը ըստ ներքին նույնականացման համարի։

Վերադարձնում է Փաստաթղթի օբյեկտը, եթե հայտնաբերվել է։  
Եթե չի հայտնաբերվել առաջացնում է սխալ կամ վերադարձնում է **null** կախված `throwExceptionIfDeleted` պարամետրից։

**Պարամետրեր**

* `isn` - Բեռնվող փաստաթղթի ներքին նույնականացման համարը։
* `gridLoadMode` - [Աղյուսակների բեռնման հայտանիշ](../types/GridLoadMode.md)։
* `loadImagesAndMemos` - Նկարների ու մեծ մուտքագրման դաշտերի բեռնման հայտանիշ։ 
* `lockTableRow` - Տվյալների պահոցում արգելափակման (lock) միացման հայտանիշ։ 
  true արժեքի դեպքում դրվում է թարմացման (update) արգելափակում։ 
* `throwExceptionIfDeleted` - Պահանջվող փաստաթղթի հեռացված լինելու դեպքում սխալի առջացման հայտանիշ։ 
* `lookInArc` - Արխիվացված փաստաթղթի բեռնման հայտանիշ։ 
  **true** արժեքի դեպքում փաստաթղթի բեռնումը փորձում է կատարել նաև արխիվային տվյալների պահոցից, եթե այնտեղ նույնպես փաստաթութը առկա չէ, առաջանում է սխալ։ 
* `instanceType` - Փաստաթղթի նկարագրված դաս 8X-ում։
  [Document](../definitions/document.md) դասից ժառանգ հանդիսացող դաս, որ տիպի փաստաթղթի օբյեկտ պետք է ստեղծվի:
* `loadParents` - Ծնող փաստաթղթերի ISN-ների ցուցակի բեռնման հայտանիշ։ 

### Load

```c#
public Task<T> Load<T>(int isn, GridLoadMode gridLoadMode = GridLoadMode.Full, 
                       bool loadImagesAndMemos = true, bool lockTableRow = false, 
                       bool throwExceptionIfDeleted = true, bool lookInArc = true, 
                       bool loadParents = false) where T : Document
```

Բեռնում է տվյալների պահոցում գոյություն ունեցող փաստաթուղթը ըստ ներքին նույնականացման համարի։

Վերադարձնում է Փաստաթղթի օբյեկտը, եթե հայտնաբերվել է։  
Եթե չի հայտնաբերվել առաջացնում է սխալ կամ վերադարձնում է **null** կախված `throwExceptionIfDeleted` պարամետրից։

**Պարամետրեր**

* `T` - Փաստաթղթի նկարագրված դաս 8X-ում, [Document](../definitions/document.md) դասի ժառանգ։
* `isn` - Բեռնվող փաստաթղթի ներքին նույնականացման համարը։
* `gridLoadMode` - [Աղյուսակների բեռնման հայտանիշ](../types/GridLoadMode.md)։
* `loadImagesAndMemos` - Նկարների ու մեծ մուտքագրման դաշտերի բեռնման հայտանիշ։ 
* `lockTableRow` - Տվյալների պահոցում արգելափակման (lock) միացման հայտանիշ։ 
  **true** արժեքի դեպքում դրվում է թարմացման (update) արգելափակում։ 
* `throwExceptionIfDeleted` - Պահանջվող փաստաթղթի հեռացված լինելու դեպքում սխալի առաջացման հայտանիշ։ 
* `lookInArc` - Արխիվացված փաստաթղթի բեռնման հայտանիշ։ 
  **true** արժեքի դեպքում փաստաթղթի բեռնումը փորձում է կատարել նաև արխիվային տվյալների պահոցից, եթե այնտեղ նույնպես փաստաթութը առկա չէ, առաջանում է սխալ։ 
* `loadParents` - Ծնող փաստաթղթերի ISN-ների ցուցակի բեռնման հայտանիշ։ 

### LoadFromFolder

```c#
public Task<Document> LoadFromFolder(string folder, string key, GridLoadMode gridLoadMode = GridLoadMode.Full,
                                     bool loadImagesAndMemos = true, Type instanceType = null, bool loadParents = false)
```

Բեռնում է փաստաթուղթը ըստ թղթապանակի և բանալու։

**Պարամետրեր**

* `folder` - Թղթապանակի ներքին անուն։
* `key` - Թղթապանակի տարրի բանալի։
* `gridLoadMode` - [Աղյուսակների բեռնման հայտանիշ](../types/GridLoadMode.md)։
* `loadImagesAndMemos` - Նկարների ու մեծ մուտքագրման դաշտերի բեռնման հայտանիշ։ 
* `instanceType` - Փաստաթղթի նկարագրված դաս 8X-ում, [Document](../definitions/document.md) դասի ժառանգ։։
* `loadParents` - Ծնող փաստաթղթերի ISN-ների ցուցակի բեռնման հայտանիշ։ 

### LoadFromFolder

```c#
public Task<T> LoadFromFolder<T>(string folder, string key, GridLoadMode gridLoadMode = GridLoadMode.Full,
                                 bool loadImagesAndMemos = true, bool loadParents = false) where T : Document
```

Բեռնում է փաստաթուղթը ըստ թղթապանակի և բանալու։

**Պարամետրեր**

* `T` - Փաստաթղթի նկարագրված դաս 8X-ում, [Document](../definitions/document.md) դասի ժառանգ։
* `folder` - Թղթապանակի ներքին անուն։
* `key` - Թղթապանակի տարրի բանալի։
* `gridLoadMode` - [Աղյուսակների բեռնման հայտանիշ](../types/GridLoadMode.md)։
* `loadImagesAndMemos` - Նկարների ու մեծ մուտքագրման դաշտերի բեռնման հայտանիշ։ 
* `loadParents` - Ծնող փաստաթղթերի ISN-ների ցուցակի բեռնման հայտանիշ։ 

### MakeParentLink

```c#
public Task MakeParentLink(Document document, int parentIsn, bool removeExistingLinks = true)
```

Ընթացիկ փաստաթղթի համար սահմանում է ծնողի հետ կապ։ 
Ընթացիկ փաստաթուղթը կարող է դեռ գրանցված չլինել տվյալների պահոցում։

Մեթոդը նախատեսված է [Action](../definitions/document.md#action) իրադարձության մշակիչում կանչելու համար։  
Եթե փաստաթուղթը տվյալների պահոցում դեռ գրանցված չէ, ապա այս մեթոդի կանչից հետո ծնող-զավակ կապերը անմիջապես չեն գրանցվում տվյալների պահոցում, դրանց գրանցումը կատարվում է [Action](../definitions/document.md#action) իրադարձության մշակիչի ավարտից հետո։

**Պարամետրեր**

* `document` - [Փաստաթղթի օբյեկտ](../definitions/document.md)։
* `parentIsn` - Ծնող փաստաթղթի ներքին նույնականացման համար։
* `removeExistingLinks` - `true` արժեքի դեպքում ստեղծվող կապը լինում է միակը և նախորդ եղած կապերը հեռացվում են։
  `false` արժեքի դեպքում ծնողների ցուցակում ավելանում է ևս մեկը։ 

### ReFolder

```c#
public Task ReFolder(Document document, StoreMode mode)
```

Իրականացնում է փաստաթղթի վերաինդեքսավորումը թղթապանակներում:
Այսինքն առաջացնում է [Folders](../definitions/document.md#folders) իրադարձությունը և համապատասխան մշակիչը։

**Պարամետրեր**

* `document` - [Փաստաթղթի օբյեկտ](../definitions/document.md)։
* `mode` - [Փաստաթղթի պահպանման ռեժիմը](../types/StoreMode.md)։
  Տե՛ս [Document](../definitions/document.md).[StoreMode](../definitions/document.md#storemode) հատկությունը։

### Store

```c#
public Task Store(Document document, 
                  DocumentCheckLevel checkLevel = DocumentCheckLevel.None, 
                  string logComment = "")
```

Անցկացնում է պարտադիր ստուգումներ և գրանցում փաստաթուղթը տվյալների պահոցում։

**Պարամետրեր**

* `document` - [Փաստաթղթի օբյեկտ](../definitions/document.md)։
* `checkLevel` - [Փաստաթղթի ստուգման մակարդակը](../types/DocumentCheckLevel.md)։
* `logComment` - Փաստաթղթի պատմության մեջ գրանցվող հաղորդագրությունը։

### StoreFact

```c#
public Task StoreFact(Document document, Fact fact)
```

Գրանցում է փաստաթղթի հաշվառումը տվյալների պահոցում:
Մեթոդը պետք է կանչել փաստաթղթի [Action](../definitions/document.md#action) իրադարձության մշակիչից։  
Այս մեթոդի կանչից հետո հաշվառումները անմիջապես չեն գրանցվում տվյալների պահոցում, դրանց գրանցումը կատարվում է միմիայն [Action](../definitions/document.md#action) իրադարձության մշակիչի ավարտից հետո։

**Պարամետրեր**

* `document` - [Փաստաթղթի օբյեկտ](../definitions/document.md)։
* `fact` - Գրանցման ենթակա հաշվառում։

### StoreInFolder

```c#
public void StoreInFolder(Document document, FolderElement folderElement)
```

Գրանցում է թղթապանակի տարրը տվյալների պահոցում:
Մեթոդը հարկավոր է կանչել միմիայն փաստաթղթի [Folders](../definitions/document.md#folders) իրադարձության մշակիչի մեջ։  
Թղթապանակի տարրերը անմիջապես չեն գրանցվում տվյալների պահոցում անմիջապես, գրանցումները կատարվում են [Folders](../definitions/document.md#folders) իրադարձության մշակիչի ավարտից հետո։

**Պարամետրեր**

* `document` - [Փաստաթղթի օբյեկտ](../definitions/document.md)։
* `folderElement` - [Թղթապանակի տարր](../types/FolderElement.md)։

### StoreInTree

```c#
public void StoreInTree(Document document, TreeElement treeElement)
```

Գրանցում է ծառի տարրը տվյալների պահոցում:
Մեթոդը հարկավոր է կանչել միմիայն փաստաթղթի [Folders](../definitions/document.md#folders) իրադարձության մշակիչի մեջ։  
Ծառի տարրերը անմիջապես չեն գրանցվում տվյալների պահոցում անմիջապես, գրանցումները կատարվում են [Folders](../definitions/document.md#folders) իրադարձության մշակիչի ավարտից հետո։

**Պարամետրեր**

* `document` - [Փաստաթղթի օբյեկտ](../definitions/document.md)։
* `treeElement` - [Ծառի տարր](../types/TreeElement.md):
