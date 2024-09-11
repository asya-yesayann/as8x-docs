---
layout: page
title: "IDocumentService" 
tags: [IDocumentService, DocumentService]
---

## Բովանդակություն

- [Ներածություն](#ներածություն)
- [Մեթոդներ](#մեթոդներ)
  - [Approve](#approve)
  - [CheckAndStore](#checkandstore)
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
  - [DecodeDocLogState](#decodedoclogstate)
  - [Delete](#delete)
  - [Delete](#delete-1)
  - [DeleteAll](#deleteall)
  - [DeserializeRequestBody](#deserializerequestbody)
  - [ExistInDb](#existindb)
  - [FieldToAnsi](#fieldtoansi)
  - [FieldsToAnsi](#fieldstoansi)
  - [GetCaption](#getcaption)
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
  - [GetParentIsn](#getparentisn-2)
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

IDocumentService դասը նախատեսված է փաստաթղթի հետ աշխատանքը ապահովելու համար։

## Մեթոդներ

### Approve

```c#
public Task Approve(Document document, DocumentCheckLevel checkLevel = DocumentCheckLevel.None, string logComment = "");
```

Հաստատում է փաստաթուղթը և գրանցում տվյալների պահոցում։

**Պարամետրեր**

* `document` - Փաստաթուղթը նկարագրող դասը։
* `checkLevel` - [Փաստաթղթի ստուգման մակարդակը](DocumentCheckLevel.md)։
* `logComment` - Փաստաթղթի պատմության մեջ գրանցվող հաղորդագրություն։

### CheckAndStore

```c#
public Task CheckAndStore(Document document,
                          StoreMode mode,
                          DocumentCheckLevel checkLevel = DocumentCheckLevel.None,
                          int stateBeforeCallPostMessage = 0,
                          string logComment = "");
```

Անցկացնում է պարտադիր ստուգումներ և սահմանված ռեժիմով գրանցում փաստաթուղթը տվյալների պահոցում։

**Պարամետրեր**

* `document` - Փաստաթուղթը նկարագրող դասը։
* `mode` - Փաստաթղթի պահպանման ռեժիմը։
* `checkLevel` - [Փաստաթղթի ստուգման մակարդակը](DocumentCheckLevel.md)։
* `stateBeforeCallPostMessage` - Փաստաթղթի վիճակը PostMessage մեթոդի կանչից առաջ։
* `logComment` - Փաստաթղթի պատմության մեջ գրանցվող հաղորդագրություն։

### CheckProcessingMode

```c#
public Task CheckProcessingMode(string docType);
```

Ստուգում է տրված տեսակի փաստաթղթերի գրանցման/հեռացման հնարավորությունը սերվիսում(փաստաթղթի կատարման ռեժիմը = է 0-ի թե ոչ)։ 

**Պարամետրեր**

* `docType` - Փաստաթղթի տեսակ։

### CleanDeleted

```c#
public Task CleanDeleted(DateTime startDate, DateTime endDate, string docType = "");
```

Մաքրում է բոլոր մասնակի հեռացված փաստաթղթերը՝ նշված ժամանակահատվածով։

**Պարամետրեր**

* `startDate` - ժամանակահատվածի սկզբի ամսաթիվ։
* `endDate` - ժամանակահատվածի վերջին ամսաթիվ։
* `docType` - Սահմանում է փաստաթղթերի տիպերի ֆիլտր։ Մաքրվում են այն հեռացված փաստաթղերը, որոնք սկսվում են docType արժեքով։
              Չլրացնելու դեպքում մաքրվում են նշված ժամանակահատվածում հեռացված բոլոր փաստաթղթերը։

### Copy

```c#
public Task<Document> Copy(int isn, object beforeCopyParam = null, int copyDocMode = 0);
```

Ստեղծում է արդեն գոյություն ունեցող փաստաթղթի պատճեն օբյեկտը։
Տրված ISN-ով փաստաթուղթը բեռնում է տվյալների պահոցից, որի հիման վրա ստեղծում պատճեն օբյեկտը։

**Պարամետրեր**

* `isn` - Պատճենման ենթակա փաստաթղթի ներքին նույնականացման համար:
* `beforeCopyParam` - Տվյալ պարամետրի արժեքը փոխանցվում է փաստաթղթի [BeforeCopy](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/BeforeCopy.html) իրադարձությանը։ 
* `copyDocMode` - Փաստաթղթի պատճենման ռեժիմը։ Լռությամբ արժեքը 0 է:

  `0` - Պատճենվում են բոլոր դաշտերի արժեքները։  
  `1` - Պատճենման ռեժիմը կախված է փաստաթղթի նկարագրության [CopyAsRepeatable](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Defs/doc.md) 
   հատկության արժեքից։  
  `2` - Պատճենվում են միայն այն դաշտերը, որոնք պարունակում են `N` հայտանիշը։  

### Create

```c#
public Task<T> Create<T>(List<int> parentsISN = null, DocumentOrigin origin = DocumentOrigin.AsService, params object[] parameters) where T : Document;
```

Ստեղծում է նշված տիպի փաստաթղթի նոր օբյեկտ։

**Պարամետրեր**

* `parentsISN` - Փաստաթղթի ծնող փաստաթղթերի ISN-ների ցուցակը:
* `origin` - Սահմանում է [փաստաթղթի ստեղծման աղբյուրը](DocumentOrigin.md):
* `parameters` - Արգումենտների զանգված, որոնք փոխանցվում են փաստաթղթի կոնսրուկտորին և պիտի թվով, հերթականությամբ, տիպերով համընկնեն կանչվող կոնստրուկտորի շարահյուսությանը։
Չփոխանցելու դեպքում փաստաթղթի նոր օբյեկտը ստեղծվելու է պարամետրեր չպարունակող կոնստրուկտորի միջոցով։

### Create

```c#
public Task<T> Create<T>(int parentISN, DocumentOrigin origin = DocumentOrigin.AsService, params object[] parameters) where T : Document;
```

Ստեղծում է նշված տիպի փաստաթղթի նոր օբյեկտ։

**Պարամետրեր**

* `parentsISN` - Փաստաթղթի ծնող փաստաթղթի ISN-ը:
* `origin` - Սահմանում է [փաստաթղթի ստեղծման աղբյուրը](DocumentOrigin.md): 
* `parameters` - Արգումենտների զանգված, որոնք փոխանցվում են փաստաթղթի կոնսրուկտորին և պիտի թվով, հերթականությամբ, տիպերով համընկնեն կանչվող կոնստրուկտորի շարահյուսությանը։
Չփոխանցելու դեպքում փաստաթղթի նոր օբյեկտը ստեղծվելու է պարամետրեր չպարունակող կոնստրուկտորի միջոցով։

### Create

```c#
public  Task<Document> Create(string typeName, List<int> parentISN = null, Type instanceType = null, DocumentOrigin origin = DocumentOrigin.AsService, params object[] parameters);
```

Ստեղծում է նշված տեսակի փաստաթղթի նոր օբյեկտ։

**Պարամետրեր**

* `typeName` - Փաստաթղթի տեսակ։
* `parentsISN` - Փաստաթղթի ծնող փաստաթղթերի ISN-ների ցուցակը:
* `instanceType` - ??
* `origin` - Սահմանում է [փաստաթղթի ստեղծման աղբյուրը](DocumentOrigin.md):
* `parameters` - Արգումենտների զանգված, որոնք փոխանցվում են փաստաթղթի կոնսրուկտորին և պիտի թվով, հերթականությամբ, տիպերով համընկնեն կանչվող կոնստրուկտորի շարահյուսությանը։
Չփոխանցելու դեպքում փաստաթղթի նոր օբյեկտը ստեղծվելու է պարամետրեր չպարունակող կոնստրուկտորի միջոցով։

### CreateFactsUsingStateMoverFrom

```c#
public Task CreateFactsUsingStateMoverFrom(Document document, int state);
```

### CreateParentLinkDB

```c#
public Task CreateParentLinkDB(int isn, int parentIsn = -1);
```

Փաստաթղթերի միջև ստեղծում է ծնող-զավակ կապ։ 
Ֆունկցիան ստեղծում է կապը անմիջապես տվյալների պահոցում։ 
Զավակ փաստաթուղթը պետք է գրանցված լինի տվյալների պահոցում։

Ի տարբերություն  [MakeParentLink](#makeparentlink)-ի այս ֆունկցիան կարելի է կանչել ամենուրեք։

**Պարամետրեր**

* `isn` - Զավակ փաստաթղթի ներքին նույնականացման համար:
* `parentIsn` - Ծնող փաստաթղթի ներքին նույնականացման համար։

### CreateParentLinksDB

```c#
public  Task CreateParentLinksDB(int isn, List<int> parentsIsn);
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
public Task<(DateTime CreationDate, short SUID)> CreationDate(int isn, bool isNotRiseErrWhenNoRow = false);
```

Վերադարձնում է փաստաթղթի ստեղծման ամսաթիվը և ստեղծողի ներքին համարը։

**Պարամետրեր**

* `isn` - Փաստաթղթի ներքին նույնականացման համար:
* `isNotRiseErrWhenNoRow` - Պահանջվող փաստաթղթի չգտնվելու դեպքում սխալի գեներացման հայտանիշ։
Լռությամբ արժեքը `false` է։
Տվյալների պահոցում ստեղծման ամսաթվի և ստեղծողի ներքին համարի բացակայության դեպքում,  isNotRiseErrWhenNoRow  պարամետրի `true` արժեքի դեպքում որպես **CreationDate** վերադարձնում է 01/01/1900 ամսաթիվը, իսկ որպես **SUID** -1 արժեքը, իսկ `false` արժեքի դեպքում առաջացնում է սխալ հետևյալ հաղորդագրությամբ՝ "Document with specified isn does not exist in DB. No current row.":

### CutChildLink

```c#
public Task CutChildLink(int isn, int childIsn = -1);
```

Ջնջում է փաստաթղթի և իրա զավակների միջև կապերը, կամ մեկ նշված փաստաթղթի հետ կապը։

**Պարամետրեր**

* `isn` - Այն փաստաթղթի ներքին նույնականացման համարը, որի համար խզվում է զավակների հետ կապը։
* `childIsn` - Մեկ զավակի ներքին նույնականացման համար, այդ զավակի կապը կզելու համար։
Եթե պարամետրը փոխանցված չէ, ապա կապը խզվում է բոլոր առկա զավակների հետ։

### CutParentLink

```c#
public Task CutParentLink(int isn, int parentIsn = -1);
```

Ջնջում է փաստաթղթի և իրա ծնողների միջև կապերը, կամ մեկ նշված փաստաթղթի հետ կապը։

**Պարամետրեր**

* `isn` - Այն փաստաթղթի ներքին նույնականացման համարը, որի համար խզվում է կապը ծնողի հետ։
* `parentIsn` - Մեկ ծնողի ներքին նույնականացման համար, այդ ծնողի կապը կզելու համար։
Եթե պարամետրը փոխանցված չէ, ապա կապը խզվում է բոլոր առկա ծնողների հետ։

### DecodeDocLogState

```c#
public string DecodeDocLogState(string operationCode, string comment);
```

### Delete

```c#
public Task<DeletedDoc> Delete(int isn,
                               bool fullDelete,
                               string comment,
                               bool callDelete = true,
                               bool inheritedDelete = false);
```

Ջնջում է փաստաթուղթը համակարգից։  
Ջնջվող փաստաթղթերի համար առաջանում է [Delete](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/ScriptProcs/Delete.md)  իրադարձությունը, ապա փաստաթղթի վիճակը դառնում է 999, որից հետո այդ փաստաթուղթը հայտնվում է ջնջված փաստաթղթերի թղթապանակում։ 
Ջնջման ժամանակ հեռացվում են նաև այդ փաստաթղթի բոլոր թղթապանակները, ծառի տարրերը և իր համար գրանցված հաշվառումները։

Եթե փաստաթուղթը ունի ենթափաստաթղթեր, ապա ջնջումը թույլատրելի չի լինի։

Ջնջումը տեղի է ունենում տրանզակցիայի մեջ։

**Պարամետրեր**

* `isn` - Ջնջվող փաստաթղթի ներքին նույնականացման համարը:
* `fullDelete` - Փաստաթղթի վերջնական ջնջման հայտանիշ։
Վերջնական ջնջման ժամանակ փաստաթուղթը ջնջվում է բոլոր միջուկային աղյուսակներից աղյուսակներից՝ [DOCP](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/DocP.html), [FOLDERS](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Folders.html), [TREES](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Trees.html), [HIPAR](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/HiPar.html), [HIREST](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Hirest.html), [HIREST2](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Hirest2.html), [ACCESS](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Access.html), [HI](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Hi.html) և [HI2](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Hi2.html)։
Ոչ վերջնական ջնջման ժամանակ փաստաթուղթը մնում է [DOCS](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Docs.html), [DOCLOG](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/DocLog.html), [DOCSG](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/DocsG.html), [DOCSIM](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Docsim.html) աղյուսակների մեջ և վիճակը լինում է 999:
Լռությամբ արժեքը `false` է։
* `comment` - Փաստաթղթի պատմության մեջ գրանցվող ջնջման մեկնաբանություն։
* `callDelete` - Փաստաթղթի [Delete](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/ScriptProcs/Delete.md) իրադարձությունը կանչելու հայտանիշ։ Լռությամբ արժեքը `true` է։
* `inheritedDelete` - `true` արժեքի դեպքում փաստաթղթի պատմության մեջ գրվում է, որ փաստաթուղթը ջնջվել է այլ փաստաթղթի ջնջման ընթացքում։ Տվյալների պահոցում ջնջման կոդը լինում է `H`, հակառակ դեպքում `D`։

### Delete

```c#
public Task<DeletedDoc> Delete(Document document,
                               bool fullDelete,
                               string comment,
                               bool callDelete = true,
                               bool inheritedDelete = false);
```

Ջնջում է փաստաթուղթը համակարգից։  
Ջնջվող փաստաթղթերի համար առաջանում է  [Delete](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/ScriptProcs/Delete.md)  իրադարձությունը, ապա փաստաթղթի վիճակը դառնում է 999, որից հետո այդ փաստաթուղթը հայտնվում է ջնջված փաստաթղթերի թղթապանակում։ 
Ջնջման ժամանակ հեռացվում են նաև այդ փաստաթղթի բոլոր թղթապանակները, ծառի տարրերը և իր համար գրանցված հաշվառումները։

Եթե փաստաթուղթը ունի ենթափաստաթղթեր, ապա ջնջումը թույլատրելի չի լինի։

Ջնջումը տեղի է ունենում տրանզակցիայի մեջ։

**Պարամետրեր**

* `document` - Ջնջվող փաստաթուղթը նկարագրող դասը։
* `fullDelete` - Փաստաթղթի վերջնական ջնջման հայտանիշ։ Վերջնական ջնջման ժամանակ փաստաթուղթը ջնջվում է բոլոր միջուկային աղյուսակներից աղյուսակներից՝ [DOCP](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/DocP.html), [FOLDERS](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Folders.html), [TREES](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Trees.html), [HIPAR](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/HiPar.html), [HIREST](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Hirest.html), [HIREST2](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Hirest2.html), [ACCESS](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Access.html), [HI](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Hi.html) և [HI2](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Hi2.html)։
Ոչ վերջնական ջնջման ժամանակ փաստաթուղթը մնում է [DOCS](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Docs.html), [DOCLOG](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/DocLog.html), [DOCSG](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/DocsG.html), [DOCSIM](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Docsim.html) աղյուսակների մեջ և վիճակը լինում է 999:
Լռությամբ արժեքը `false` է։
* `comment` - Փաստաթղթի պատմության մեջ գրանցվող ջնջման մեկնաբանություն։
* `callDelete` - Փաստաթղթի [Delete](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/ScriptProcs/Delete.md) իրադարձությունը կանչելու հայտանիշ։ Լռությամբ արժեքը `true` է։
* `inheritedDelete` - `true` արժեքի դեպքում փաստաթղթի պատմության մեջ գրվում է, որ փաստաթուղթը ջնջվել է այլ փաստաթղթի ջնջման ընթացքում։
Տվյալների պահոցում ջնջման կոդը լինում է `H`, հակառակ դեպքում `D`։

### DeleteAll

```c#
public Task DeleteAll(List<int> isnList, bool fullDelete, string comment, bool callDelete = true, bool inheritedDelete = false);
```

Ջնջում է տրված փաստաթղթերը համակարգից։  
Ջնջվող փաստաթղթերի համար առաջանում է  [Delete](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/ScriptProcs/Delete.md)  իրադարձությունը, ապա փաստաթղթերի վիճակը դառնում է 999, որից հետո այդ փաստաթուղթը հայտնվում է ջնջված փաստաթղթերի թղթապանակում։ Ջնջման ժամանակ հեռացվում են նաև այդ փաստաթղթերի բոլոր թղթապանակները, ծառի տարրերը և իր համար գրանցված հաշվառումները։

Եթե փաստաթուղթերը ունեն ենթափաստաթղթեր, ապա ջնջումը թույլատրելի չի լինի։

Ջնջումը տեղի է ունենում տրանզակցիայի մեջ։

**Պարամետրեր**

* `document` - Ջնջվող փաստաթղթերի ներքին նույնականացման համարների ցուցակ։
* `fullDelete` - Փաստաթղթերի վերջնական ջնջման հայտանիշ։ Վերջնական ջնջման ժամանակ փաստաթղթերը ջնջվում է բոլոր միջուկային աղյուսակներից աղյուսակներից՝ [DOCP](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/DocP.html), [FOLDERS](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Folders.html), [TREES](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Trees.html), [HIPAR](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/HiPar.html), [HIREST](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Hirest.html), [HIREST2](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Hirest2.html), [ACCESS](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Access.html), [HI](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Hi.html) և [HI2](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Hi2.html)։
Ոչ վերջնական ջնջման ժամանակ փաստաթղթերը մնում են [DOCS](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Docs.html), [DOCLOG](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/DocLog.html), [DOCSG](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/DocsG.html), [DOCSIM](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Docsim.html) աղյուսակներում և վիճակը լինում է 999:
Լռությամբ արժեքը `false`։
* `comment` - Փաստաթղթերի պատմության մեջ գրանցվող ջնջման մեկնաբանություն:
* `callDelete` - Փաստաթղթերի [Delete](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/ScriptProcs/Delete.md) իրադարձությունը կանչելու հայտանիշ։ Լռությամբ արժեքը `true`։
* `inheritedDelete` - `true` արժեքի դեպքում փաստաթղթերի պատմության մեջ գրվում է, որ փաստաթղթերը ջնջվել են այլ փաստաթղթի ջնջման ընթացքում։ Տվյալների պահոցում ջնջման կոդը լինում է `H`, հակառակ դեպքում `D`։

### DeserializeRequestBody

```c#
public Task<Document> DeserializeRequestBody(DocumentModel request, bool isExtended = false);
```

### ExistInDb

```c#
public Task<bool> ExistInDb(int isn);
```

Ստուգում է փաստաթղթի առկայությունը տվյալների պահոցում։

**Պարամետրեր**

* `isn` - Փաստաթղթի ներքին նույնականացման համար:

### FieldToAnsi

```c#
public  Task<object> FieldToAnsi(string docType, string name, object value);
```

Վերադարձնում է փաստաթղթի դաշտի արժեքը՝ ձևափոխված  համապատասխան լեզվի ANSI կոդավորման։

**Պարամետրեր**

* `docType` - Փաստաթղթի տեսակ:
* `name` - Դաշտի ներքին անուն։
* `value` - Դաշտի արժեք։

### FieldsToAnsi

```c#
public Task<Dictionary<string, object>> FieldsToAnsi(string docType, Dictionary<string, object> fields);
```

Վերադարձնում է փաստաթղթի դաշտերի արժեքները՝ ձևափոխված  համապատասխան լեզվի ANSI կոդավորման։

**Պարամետրեր**

* `docType` - Փաստաթղթի տեսակ:
* `fields` - Դաշտի ներքին անունների և արժեքների ցանկ։

### GetCaption

```c#
public Task<(string caption, string englishCaption)> GetCaption(string docType);
```

Վերադարձնում է փաստաթղթի հայերեն և անգլերեն անվանումները։

**Պարամետրեր**

* `docType` - Փաստաթղթի տեսակ։

### GetDocsInfo

```c#
public ArchiveInfo GetDocsInfo();
```

Վերադարձնում է փաստաթղթի արխիվը պարունակող տվյալների բազայի անունը և SqlConnection դեպի այդ բազան։

### GetDocumentChildren

```c#
public Task<List<(int isn, string docType)>> GetDocumentChildren(int isn, string docType = "", DocumentChildrenOrder order = DocumentChildrenOrder.UnOrdered, string docTypeLike = "");
```

Վերադարձնում է փաստաթղթի զավակ փաստաթղերի isn-ների ու տեսակների ցուցակը:

**Պարամետրեր**

* `isn` - Ծնող փաստաթղթի ներքին նույնականացման համարը:
* `docType` - Սահմանում է ներառվող կամ չներառվող զավակ փաստաթղթերի տիպերը։ Եթե պարամետրը առկա չի, ապա վերադարձվում են բոլոր տիպի զավակ փաստաթղթերի isn-ները ու տեսակները։  
Ներառվող տիպերի ցուցակը թվարկվում են `+` նշանով սկսելով՝ փաստաթղթի տեսակների անվանումները իրարից առանձնացնելով բացատներով։ Օրինակ՝ `"+KasPr MemOrd SetPr"`։  
Չներառվող տիպերի ցուցակը թվարկվում են `-` նշանով սկսելով՝ փաստաթղթի տեսակների անվանումները իրարից առանձնացնելով բացատներով։ Օրինակ՝ `"-AccDoc AsTurn"`։
Միայն նշված տիպի զավակ փաստաթղթերը վերադարձնելու համար անհրաժեշտ է ավելացնել փաստաթղթի տեսակը։ Օրինակ՝ `"AccDoc"`:
* `order` -  Ըստ զավակ փաստաթղթերի ստեղծման ամսաթվի դասավորման նշան։
DocumentChildrenOrder.UnOrdered - Չի դասավորվում։
DocumentChildrenOrder.CreationDateAscending - Դասավորվում է աճման կարգով։
DocumentChildrenOrder.CreationDateDescending - Դասավորվում է նվազման կարգով։
* `docTypeLike` - Սահմանում է ներառվող կամ չներառվող զավակ փաստաթղթերի տիպերի ֆիլտր։ Եթե պարամետրը առկա չի, ապա վերադարձվում են բոլոր տիպի զավակների isn-ները ու տեսակները։
Ներառվող տիպերի ֆիլտրը `+` նշանով սկսելով։ Օրինակ՝ `"+Acc%"`։  
Չներառվող տիպերի ֆիլտրը `-` նշանով սկսելով։ Օրինակ՝ `"-Acc%"`։

### GetDocumentParents

```c#
public Task<List<(int isn, string docType)>> GetDocumentParents(int isn, string docType = "", DocumentChildrenOrder order = DocumentChildrenOrder.UnOrdered, string docTypeLike = "");
```

Վերադարձնում է փաստաթղթի ծնող փաստաթղերի isn-ների ու տեսակների ցուցակը:

**Պարամետրեր**

* `isn` - Զավակ փաստաթղթի ներքին նույնականացման համարը:
* `docType` - Սահմանում է ներառվող կամ չներառվող ծնող փաստաթղթերի տիպերը։ Եթե պարամետրը առկա չի, ապա վերադարձվում են բոլոր տիպի ծնող փաստաթղթերի isn-ները ու տեսակները։ 
Ներառվող տիպերի ցուցակը թվարկվում են `+` նշանով սկսելով՝ փաստաթղթի տեսակների անվանումները իրարից առանձնացնելով բացատներով։ Օրինակ՝ `"+KasPr MemOrd SetPr"`։  
Չներառվող տիպերի ցուցակը թվարկվում են `-` նշանով սկսելով՝ փաստաթղթի տեսակների անվանումները իրարից առանձնացնելով բացատներով։ Օրինակ՝ `"-AccDoc AsTurn"`։
Միայն նշված տիպի ծնող փաստաթղթերը վերադարձնելու համար անհրաժեշտ է ավելացնել փաստաթղթի տեսակը։ Օրինակ՝ `"AccDoc"`:
* `order` -  Ըստ ծնող փաստաթղթերի ստեղծման ամսաթվի դասավորման նշան։
DocumentChildrenOrder.UnOrdered - Չի դասավորվում։
DocumentChildrenOrder.CreationDateAscending - Դասավորվում է աճման կարգով։
DocumentChildrenOrder.CreationDateDescending - Դասավորվում է նվազման կարգով։
* `docTypeLike` -  Սահմանում է ներառվող կամ չներառվող ծնող փաստաթղթերի տիպերի ֆիլտր։ Եթե պարամետրը առկա չի, ապա վերադարձվում են բոլոր տիպի ծնող  փաստաթղթերի isn-ները ու տեսակները։    
Ներառվող տիպերի ֆիլտրը `+` նշանով սկսելով։ Օրինակ՝ `"+Acc%"`։  
Չներառվող տիպերի ֆիլտրը `-` նշանով սկսելով։ Օրինակ՝ `"-Acc%"`։

### GetDocumentState

```c#
public Task<int> GetDocumentState(int isn);
```

Վերադարձնում է փաստաթղթի վիճակը։
Եթե փաստաթուղթը առկա չի, կամ ոչ վերջնական ջնջված է, ապա ֆունկցիան վերադարձնում է -1 արժեք։

**Պարամետրեր**

* `isn` - Փաստաթղթի ներքին նույնականացման համար։

### GetDocumentStatus

```c#
public Task<byte> GetDocumentStatus(string folderID, int isn);
```

Վերադարձնում է թղթապանակի տարրի վիճակը։

**Պարամետրեր**

* `folderID` - Թղթապանակի ներքին անուն:
* `isn` - Փաստաթղթի ներքին նույնականացման համար։

### GetDocumentType 

```c#
public Task<string> GetDocumentType(int isn);
```

Վերադարձնում է նշված ներքին նույնականացման համարով փաստաթղթի տեսակը։

**Պարամետրեր**

* `isn` - Փաստաթղթի ներքին նույնականացման համար։

### GetDocumentTypeFromFolder

```c#
public Task<string> GetDocumentTypeFromFolder(string folder, string key);
```

Վերադարձնում է փաստաթղթի տեսակը:

**Պարամետրեր**

* `folder` - Թղթապանակի ներքին անուն։
* `key` - Թղթապանակի տարրի բանալի։

### GetGrandChildren

```c#
public Task<List<int>> GetGrandChildren(int isn, string docType1 = "", string docTypeLike1 = "", string docType2 = "", string docTypeLike2 = "");
```

Նշված փաստաթղթի համար վերադարձնում է թոռնիկների հավաքածուն։

**Պարամետրեր**

* `isn` - Ծնող փաստաթղթի ներքին նույնականացման համար:
* `docType1` - Սահմանում է ներառվող կամ չներառվող զավակ փաստաթղթերի տիպերը։ Եթե պարամետրը առկա չի, ապա դիտարկվում են բոլոր տիպի զավակ փաստաթղթերի զավակները։  
Ներառվող տիպերի ցուցակը թվարկվում են `+` նշանով սկսելով։ Օրինակ՝ `"+KasPr MemOrd SetPr"`։  
Չներառվող տիպերի ցուցակը թվարկվում են `-` նշանով սկսելով։ Օրինակ՝ `"-AccDoc AsTurn"`։
* `docTypeLike1` - Սահմանում է ներառվող կամ չներառվող զավակ փաստաթղթերի տիպերի ֆիլտր։ Եթե պարամետրը առկա չի, ապա դիտարկվում են բոլոր տիպի զավակ փաստաթղթերի զավակները։  
Ներառվող տիպերի ֆիլտրը `+` նշանով սկսելով։ Օրինակ՝ `"+Acc%"`։  
Չներառվող տիպերի ֆիլտրը `-` նշանով սկսելով։ Օրինակ՝ `"-Acc%"`։
* `docType2` - Սահմանում է ներառվող կամ չներառվող թոռնիկ փաստաթղթերի տիպերը։ Եթե պարամետրը առկա չի, ապա վերադարձվում են բոլոր տիպի թոռնիկների ISN-ները։  
Ներառվող տիպերի ցուցակը թվարկվում են `+` նշանով սկսելով։ Օրինակ՝ `"+KasPr MemOrd SetPr"`։  
Չներառվող տիպերի ցուցակը թվարկվում են `-` նշանով սկսելով։ Օրինակ՝ `"-AccDoc AsTurn"`։
* `docTypeLike2` - Սահմանում է ներառվող կամ չներառվող թոռնիկ փաստաթղթերի տիպերի ֆիլտր։ Եթե պարամետրը առկա չի, ապա վերադարձվում են բոլոր տիպի թոռնիկների ISN-ները։  
Ներառվող տիպերի ֆիլտրը `+` նշանով սկսելով։ Օրինակ՝ `"+Acc%"`։  
Չներառվող տիպերի ֆիլտրը `-` նշանով սկսելով։ Օրինակ՝ `"-Acc%"`։


### GetParentIsn

```c#
public Task<int> GetParentIsn(int isn);
```

Վերադարձնում է փաստաթղթի առաջին ծնող փաստաթղթի ներքին նույնականացման համարը։ Եթե ծնող փաստաթղթը չկա, ապա վերադառնում է -1։

### GetParentIsn

```c#
public Task<int> GetParentIsn(int isn, string docTypeLike);
```

Վերադարձնում է փաստաթղթի առաջին ծնող փաստաթղթի ներքին նույնականացման համարը։ Եթե ծնող փաստաթղթը չկա, ապա վերադառնում է -1։

**Պարամետրեր**

* `isn` - Փաստաթղթի ներքին նույնականացման համար:
* `docTypeLike` - Սահմանում է ներառվող կամ չներառվող ծնող փաստաթղթերի տիպերի ֆիլտր։
Ներառվող տիպերի ֆիլտրը `+` նշանով սկսելով։ Օրինակ՝ `"+Acc%"`։  
Չներառվող տիպերի ֆիլտրը `-` նշանով սկսելով։ Օրինակ՝ `"-Acc%"`։

### GetPassedState

```c#
public short GetPassedState(int isn, List<short> states, bool lastState = true, bool inStates = true);
```

Ստուգում է և վերադարձնում է փաստաթղթի վերջին կամ առաջին նշանակված վիճակը տրված վիճակների ցուցակից։

**Պարամետրեր**

* `isn` - Փաստաթղթի ներքին նույնականացման համար։
* `states` - Փաստաթղթի վիճակների ցուցակ։
* `lastState` - `true` արժեքի դեպքում վերադառնում է վերջին նշանակված վիճակը, հակառակ դեպքում՝ առաջինը։
* `inStates` - true` արժեքի դեպքում փնտրվում է վիճակ, տրված վիճակների ցուցակից։ Հակառակ դեպքում՝ ցուցակից դուրս։

### GetPassedState

```c#
public short GetPassedState(int isn, string statesSubQuery, bool lastState = true, bool inStates = true);
```

Ստուգում է և վերադարձնում է փաստաթղթի վերջին կամ առաջին նշանակված վիճակը վիճակների ցուցակը սահմանող sql հարցում արդյունքից։

**Պարամետրեր**

* `isn` - Փաստաթղթի ներքին նույնականացման համար։
* `statesSubQuery` - Փաստաթղթի վիճակները սահմանող sql հարցում:
* `lastState` - `true` արժեքի դեպքում վերադառնում է վերջին նշանակված վիճակը, հակառակ դեպքում՝ առաջինը։
* `inStates` - true` արժեքի դեպքում փնտրվում է վիճակ, վիճակների ցուցակը սահմանող sql հարցում արդյունքից։ Հակառակ դեպքում՝ արդյունքից դուրս։

### GetPassedState

```c#
public short GetPassedState(int isn, short state, bool lastState = true, bool inStates = true);
```

Ստուգում է տրված վիճակը հանդիանում է փաստաթղթի վերջին կամ առաջին նշանակված վիճակը թե ոչ։

**Պարամետրեր**

* `isn` - Փաստաթղթի ներքին նույնականացման համար։
* `state` - Փաստաթղթի վիճակ։
* `lastState` - `true` արժեքի դեպքում վերադառնում է վերջին վիճակը, հակառակ դեպքում՝ առաջինը։
* `inStates` - `true` արժեքի դեպքում փնտրվում է վիճակ, որը վիճակների ցուցակի միջից է։ Հակառակ դեպքում՝ ցուցակի միջից չէ։


### GetPassedState

```c#
public short GetPassedState(int isn, short state, bool lastState = true, bool inStates = true);
```

Վերադարձնում է փաստաթղթի վերջին կամ առաջին նշանակված վիճակը։

**Պարամետրեր**

* `isn` - Փաստաթղթի ներքին նույնականացման համար։
* `lastState` - `true` արժեքի դեպքում վերադառնում է վերջին վիճակը, հակառակ դեպքում՝ առաջինը։

### GetParentIsn

```c#
public Task<int> GetParentIsn(int isn, string docType);
```

Վերադարձնում է առաջին 2 ծնող փաստաթղթերի ներքին նույնականացման համարները։Ծնող փաստաթղթերի բացակայության դեպքում վերադառնում է -1։

**Պարամետրեր**

* `isn` - Փաստաթղթի ներքին նույնականացման համար:
* `docType` - Սահմանում է ներառվող կամ չներառվող փաստաթղթերի տիպերը։   
Ներառվող տիպերի ցուցակը թվարկվում են `+` նշանով սկսելով՝ փաստաթղթի տեսակների անվանումները իրարից առանձնացնելով բացատներով։ Օրինակ՝ `"+KasPr MemOrd SetPr"`։  
Չներառվող տիպերի ցուցակը թվարկվում են `-` նշանով սկսելով՝ փաստաթղթի տեսակների անվանումները իրարից առանձնացնելով բացատներով։ Օրինակ՝ `"-AccDoc AsTurn"`։
Միայն նշված տիպի ծնող փաստաթղթերը վերադարձնելու համար անհրաժեշտ է ավելացնել փաստաթղթի տեսակը։ Օրինակ՝ `"AccDoc"`:

### GetProcessingModes

```c#
public  Task<DocumentProcessingModes> GetProcessingModes(string docType);
```

Վերադարձնում է փաստաթղթի կատարման ռեժիմները ըստ փաստաթղթի տեսակի։
 
**Պարամետրեր**

* `docType` - Փաստաթղթի տեսակ:

### GetSUIDAndDate

```c#
public Task<(bool exists, short suid, string dateTime)> GetSUIDAndDate(int isn, int state, bool sort = true);
```

Ստուգում է նշված վիճակին համապատասխան տողի առկայությունը փաստաթղթի պատմության մեջ ([DOCLOG](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/DocLog.html) աղյուսակում)։

**Պարամետրեր**

* `isn` - Փաստաթղթի ներքին նույնականացման համար:
* `state` - Փնտրվող վիճակ։
* `sort` - Փաստաթուղթը նշված վիճակին բերած առաջին (`true`) կամ վերջին (`false`) անգամ վիճակը հասնելը։ Լռությամբ արժեքը true է։

### HiDelete

```c#
public Task<(bool had01AccRow, bool hadHIRow)> HiDelete(Document doc, bool deleteDoc);
```

Ջնջում է փաստաթղթի նախկինում գրանցած հաշվառումները [HI](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/Hi.html) աղյուսակից։  
Եթե մեթոդը կանչում են  [Action](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/Action.html)  իրադարձության մշակիչից, ապա սահմանաչափերի ստուգումները կկատարվեն Action-ի ավարտից հետո։ Իսկ եթե այլ տեղից է կանչած, ապա ստուգումները կկատարվեն անմիջապես։

**Պարամետրեր**

* `doc` - Փաստաթուղթը նկարագրող դասը։
* `deleteDoc` - ???

### HiDeleteAll

```c#
public Task HiDeleteAll(Document doc)
```

Ջնջում է փաստաթղթի նախկինում գրանցած հաշվառումները [HI](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/Hi.html), [HI2](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/Hi2.html) աղյուսակներից։  
Եթե մեթոդը կանչում են  [Action](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/Action.html)  իրադարձության մշակիչից, ապա սահմանաչափերի ստուգումները կկատարվեն Action-ի ավարտից հետո։ Իսկ եթե այլ տեղից է կանչած, ապա ստուգումները կկատարվեն անմիջապես։

**Պարամետրեր**

* `doc` - Փաստաթուղթը նկարագրող դասը։

### HiParDelete

```c#
public Task HiParDelete(Document doc);
```

[HIPAR](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/HiPar.html) աղյուսակից ջնջում է այս փաստաթղթի նախկինում գրանցած պարամետրերի արժեքները։

**Պարամետրեր**

* `doc` - Փաստաթուղթը նկարագրող դասը։

### IsArchived

```c#
public Task<bool> IsArchived(int isn);
```

Ստուգում է փաստաթղթի արխիվացված լինելը։

**Պարամետրեր**

* `isn` - Փաստաթղթի ներքին նույնականացման համար:

### Load

```c#
public Task<Document> Load(int isn, GridLoadMode gridLoadMode = GridLoadMode.Full,
                           bool loadImagesAndMemos = true, bool lockTableRow = false,
                           bool throwExceptionIfDeleted = true, bool lookInArc = true,
                           Type instanceType = null, bool loadParents = false);
```

Բեռնում է տվյալների պահոցում գոյություն ունեցող փաստաթուղթը ըստ ներքին նույնականացման համարի։

**Պարամետրեր**

* `isn` - Բեռնվող փաստաթղթի ներքին նույնականացման համարը։
* `gridLoadMode` - [Գրիդերի բեռնման ռեժիմը](GridLoadMode.md)։
* `loadImagesAndMemos` - Նկարների ու մեծ մուտքագրման դաշտերի բեռնման հայտանիշ։ Լռությամբ արժեքը  true է։
* `lockTableRow` -  Տվյալների պահոցում արգելափակման (lock) միացման հայտանիշ։ true արժեքի դեպքում դրվում է թարմացման (update) արգելափակում։ Լռությամբ արժեքը false է:
* `throwExceptionIfDeleted` - Պահանջվող փաստաթղթի հեռացված լինելու դեպքում սխալի գեներացման հայտանիշ։ Լռությամբ արժեքը true է:
* `lookInArc` - Արխիվացված փաստաթղթի բեռնման հայտանիշ։ `true` արժեքի դեպքում փաստաթղթի բեռնումը փորձում է կատարել նաև արխիվային տվյալների պահոցից, եթե այնտեղ նույնպես փաստաթութը առկա չէ, առաջանում է սխալ։ Լռությամբ արժեքը  true է։
* `instanceType` - ??
* `loadParents` - Ծնող փաստաթղթերի ISN-ների ցուցակի բեռնման հայտանիշ։ Լռությամբ արժեքը false է։

### Load

```c#
public Task<T> Load<T>(int isn, GridLoadMode gridLoadMode = GridLoadMode.Full, bool loadImagesAndMemos = true,
                       bool lockTableRow = false, bool throwExceptionIfDeleted = true, bool lookInArc = true, 
                       bool loadParents = false) where T : Document;
```

Բեռնում է տվյալների պահոցում գոյություն ունեցող փաստաթուղթը ըստ ներքին նույնականացման համարի։

**Պարամետրեր**

* `isn` - Բեռնվող փաստաթղթի ներքին նույնականացման համարը։
* `gridLoadMode` - [Գրիդերի բեռնման ռեժիմը](GridLoadMode.md)։
* `loadImagesAndMemos` - Նկարների ու մեծ մուտքագրման դաշտերի բեռնման հայտանիշ։ Լռությամբ արժեքը  true է։
* `lockTableRow` -  Տվյալների պահոցում արգելափակման (lock) միացման հայտանիշ։ true արժեքի դեպքում դրվում է թարմացման (update) արգելափակում։ Լռությամբ արժեքը false է:
* `throwExceptionIfDeleted` - Պահանջվող փաստաթղթի հեռացված լինելու դեպքում սխալի գեներացման հայտանիշ։ Լռությամբ արժեքը true է:
* `lookInArc` - Արխիվացված փաստաթղթի բեռնման հայտանիշ։ `true` արժեքի դեպքում փաստաթղթի բեռնումը փորձում է կատարել նաև արխիվային տվյալների պահոցից, եթե այնտեղ նույնպես փաստաթութը առկա չէ, առաջանում է սխալ։ Լռությամբ արժեքը  true է։
* `loadParents` - Ծնող փաստաթղթերի ISN-ների ցուցակի բեռնման հայտանիշ։ Լռությամբ արժեքը false է։

### LoadFromFolder

```c#
public Task<Document> LoadFromFolder(string folder, string key, GridLoadMode gridLoadMode = GridLoadMode.Full,
                                     bool loadImagesAndMemos = true, Type instanceType = null, bool loadParents = false);
```

Բեռնում է փաստաթուղթը ըստ թղթապանակի և բանալու։

**Պարամետրեր**

* `folder` - Թղթապանակի ներքին անուն։
* `key` - Թղթապանակի տարրի բանալի։
* `gridLoadMode` - [Գրիդերի բեռնման ռեժիմը](GridLoadMode.md)։
* `loadImagesAndMemos` - Նկարների ու մեծ մուտքագրման դաշտերի բեռնման հայտանիշ։ Լռությամբ արժեքը true է։
* `instanceType` - ??
* `loadParents` - Ծնող փաստաթղթերի ISN-ների ցուցակի բեռնման հայտանիշ։ Լռությամբ արժեքը false է։

### LoadFromFolder

```c#
public Task<T> LoadFromFolder<T>(string folder, string key, GridLoadMode gridLoadMode = GridLoadMode.Full,
                                 bool loadImagesAndMemos = true, bool loadParents = false) where T : Document;
```

Բեռնում է փաստաթուղթը ըստ թղթապանակի և բանալու։

**Պարամետրեր**

* `folder` - Թղթապանակի ներքին անուն։
* `key` - Թղթապանակի տարրի բանալի։
* `gridLoadMode` - [Գրիդերի բեռնման ռեժիմը](GridLoadMode.md)։
* `loadImagesAndMemos` - Նկարների ու մեծ մուտքագրման դաշտերի բեռնման հայտանիշ։ Լռությամբ արժեքը true է։
* `loadParents` - Ծնող փաստաթղթերի ISN-ների ցուցակի բեռնման հայտանիշ։ Լռությամբ արժեքը false է։

### MakeParentLink

```c#
public Task MakeParentLink(Document document, int parentIsn, bool removeExistingLinks = true);
```

Ընթացիկ փաստաթղի համար սահմանում է ծնողի հետ կապ։ Ընթացիկ փաստաթուղթը կարող է դեռ գրանցված չլինել տվյալների պահոցում։

Մեթոդը նախատեսված է [Action](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/Action.html) իրադարձության մշակիչում կանչելու համար։  
Եթե փաստաթուղթը տվյալների պահոցում դեռ գրանցված չէ, ապա այս մեթոդի կանչից հետո ծնող-զավակ կապերը անմիջապես չեն գրանցվում տվյալների պահոցում, դրանց գրանցումը կատարվում է [Action](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/ScriptProcs/Action.md)  իրադարձության մշակիչի ավարտից հետո։

**Պարամետրեր**

* `document` - Փաստաթուղթը նկարագրող դասը։
* `parentIsn` - Ծնող փաստաթղթի ներքին նույնականացման համար։
* `removeExistingLinks` - `true` արժեքի դեպքում ստեղծվող կապը լինում է միակը և նախորդ եղած կապերը հեռացվում են։ `false` արժեքի դեպքում ծնողների ցուցակում ավելանում է ևս մեկը։ Լռությամբ արժեքը true է։

### ReFolder

```c#
public Task ReFolder(Document document, StoreMode mode);
```

Իրականացնում է փաստաթղթի վերաինդեքսավորումը թղթապանակներում:

**Պարամետրեր**

* `document` - Փաստաթուղթը նկարագրող դասը։
* `mode` - Փաստաթղթի պահպանման ռեժիմը։

### Store

```c#
public Task Store(Document document, DocumentCheckLevel checkLevel = DocumentCheckLevel.None, string logComment = "");
```

Անցկացնում է պարտադիր ստուգումներ և գրանցում փաստաթուղթը տվյալների պահոցում։

**Պարամետրեր**

* `document` - Փաստաթուղթը նկարագրող դասը։
* `checkLevel` - [Փաստաթղթի ստուգման մակարդակը](DocumentCheckLevel.md)։
* `logComment` - Փաստաթղթի պատմության մեջ գրանցվող հաղորդագրություն։

### StoreFact

```c#
public Task StoreFact(Document document, Fact fact);
```

Գրանցում է փաստաթղթի հաշվառումը։

**Պարամետրեր**

* `document` - Փաստաթուղթը նկարագրող դասը։
* `fact` - Գրանցման ենթակա հաշվառումը նկարագրող դասը։

### StoreInFolder

```c#
public void StoreInFolder(Document document, FolderElement folderElement);
```

Գրանցում է թղթապանակի տարրը։

**Պարամետրեր**

* `document` - Փաստաթուղթը նկարագրող դասը։
* `folderElement` - Թղթապանակի տարրը նկարագրող դասը։

### StoreInTree

```c#
public void StoreInTree(Document document, TreeElement treeElement);
```

Գրանցում է ծառի տարրը։

**Պարամետրեր**

* `document` - Փաստաթուղթը նկարագրող դասը։
* `folderElement` - Ծառի տարրը նկարագրող դասը։
