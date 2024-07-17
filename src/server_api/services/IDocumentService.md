---
layout: page
title: "IDocumentService" 
tags: [IDocumentService, DocumentService]
---

IDocumentService դասը նախատեսված է փաստաթղթի հետ աշխատանքը ապահովելու համար։

## Բովանդակություն
* [Մեթոդներ](#մեթոդներ)
	* [CheckProcessingMode](#checkprocessingmode)
	* [CleanDeleted](#cleandeleted)
	* [Copy](#copy) 
	* [Create&lgtT&gt](#create&lgtT&gt)
	* [CreationDate](#creationdate) 
	* [CutChildLink](#cutchildlink) 
	* [CutParentLink](#cutparentlink) 
	* [ExistInDb](#existindb) 
	* [GetCaption](#getcaption) 
	* [GetDocsInfo](#getdocsinfo) 
	* [GetDocumentChildren](#getdocumentchildren) 
	* [GetDocumentParents](#getdocumentparents) 
	* [GetDocumentState](#getdocumentstate) 
	* [GetDocumentStatus](#getdocumentstatus) 
	* [GetDocumentType](#getdocumenttype) 
	* [GetParentIsn](#getparentisn)
	* [GetParentIsn](#getparentisn)
 	* [GetProcessingModes](#getprocessingmodes)
	* [IsArchived](#isarchived) 
	* [Load](#load)
	* [LoadFromFolder](#loadfromfolder)
 	* [ReFolder](#refolder)
	* [Store](#store) 
	* [StoreFact](#storefact)
	* [StoreInFolder](#storeinfolder) 
	* [StoreInTree](#storeintree)  

## Մեթոդներ

### CheckProcessingMode

```c#
public async Task CheckProcessingMode(string docType)
```

Ստուգում է տրված տեսակի փաստաթղթերի գրանցման/հեռացման հնարավորությունը սերվիսում։

**Պարամետրեր**
* docType - Փաստաթղթի տեսակ։

### CleanDeleted

```c#
public Task CleanDeleted(DateTime startDate, DateTime endDate, string docType = "")
```

Մաքրում է բոլոր հեռացված փաստաթղթերը՝ նշված ժամանակահատվածով։

**Պարամետրեր**
* startDate - ժամանակահատվածի սկզբի ամսաթիվ։
* endDate - ժամանակահատվածի վերջին ամսաթիվ։
* docType - Սահմանում է փաստաթղթերի տիպերի ֆիլտր։ Մաքրվում են այն փաստաթղերը, որոնք սկսվում են docType արժեքով։ Չլրացնելու դեպքում մաքրվում են նշված ժամանակահատվածում հեռացված բոլոր փաստաթղթերը։

### Copy

```c#
public Task<Document> Copy(int isn, object beforeCopyParam = null, int copyDocMode = 0)
```

Ստեղծում է արդեն գոյություն ունեցող փաստաթղթի պատճեն օբյեկտը։
Տրված ISN-ով փաստաթուղթը բեռնում է տվյալների պահոցից, որի հիման վրա ստեղծում պատճեն օբյեկտը։

**Պարամետրեր**
*  isn - Պատճենման ենթակա փաստաթղթի ներքին նույնականացման համար:
* beforeCopyParam - Տվյալ պարամետրի արժեքը փոխանցվում է փաստաթղթի [BeforeCopy](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/ScriptProcs/BeforeCopy.html) իրադարձությանը։ 
* copyDocMode  - Սահմանում է փաստաթղթի պատճենման ռեժիմը։
`0` - Պատճենվում են բոլոր դաշտերի արժեքները։  
`1` - Պատճենման ռեժիմը կախված է փաստաթղթի նկարագրության [CopyAsRepeatable](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Defs/doc.md) հատկության արժեքից։  
`2` - Պատճենվում են միայն այն դաշտերը, որոնք պարունակում են `N` հայտանիշը։  
Լռությամբ արժեքը 0 է:

### Create&lgtT&gt

```c#
public Task<T> Create<T>(List<int> parentsISN = null, DocumentOrigin origin = DocumentOrigin.AsService, params object[] parameters) where T : Document
```

Ստեղծում է նշված տիպի փաստաթղթի նոր օբյեկտ։

**Պարամետրեր**
* parentsISN - Փաստաթղթի ծնող փաստաթղթերի ISN-ների ցուցակը:
* origin - Սահմանում է փաստաթղթի ստեղծման աղբյուրը:
DocumentOrigin.Unknown - Անհայտ:

DocumentOrigin.As4xUI - Փաստաթուղթը ստեղծվել է 4xUI-ում:

DocumentOrigin.As4xScript - Փաստաթուղթը ստեղծվել է 4x սկրիպտում:

DocumentOrigin.AsService - Փաստաթուղթը ստեղծվել է սերվիսում:

DocumentOrigin.As8xUI - Փաստաթուղթը ստեղծվել է 8xUI-ում:

DocumentOrigin.As8xUICode - Փաստաթուղթը ստեղծվել է 8xUI-ի կոդում:
  
* parameters - ??

### CreationDate

```c#
public Task<(DateTime CreationDate, short SUID)> CreationDate(int isn, bool isNotRiseErrWhenNoRow = false);
```

Վերադարձնում է փաստաթղթի ստեղծման ամսաթիվը և ստեղծողի 
ներքին համարը։

**Պարամետրեր**
* isn - Փաստաթղթի ներքին նույնականացման համար:
* isNotRiseErrWhenNoRow - Պահանջվող փաստաթղթի չգտնվելու դեպքում սխալի գեներացման հայտանիշ։ Լռությամբ արժեքը `False` է։ Տվյալների պահոցում ստեղծման ամսաթվի և ստեղծողի ներքին համարի բացակայության դեպքում,  isNotRiseErrWhenNoRow  պարամետրի `true` արժեքի դեպքում որպես **CreationDate** վերադարձնում է 01/01/1900 ամսաթիվը, իսկ որպես **SUID** -1 արժեքը, իսկ `false` արժեքի դեպքում առաջացնում է սխալ հետևյալ հաղորդագրությամբ՝ "Document with specified isn does not exist in DB. No current row.":

### CutChildLink

```c#
public Task CutChildLink(int isn, int childIsn = -1);
```

Ջնջում է փաստաթղթի և իրա զավակների միջև կապերը, կամ մեկ նշված փաստաթղթի հետ կապը։

**Պարամետրեր**
* isn - Այն փաստաթղթի ներքին նույնականացման համարը, որի համար խզվում է զավակների հետ կապը։
* childIsn - Մեկ զավակի ներքին նույնականացման համար, այդ զավակի կապը կզելու համար։ Եթե պարամետրը փոխանցված չէ, ապա կապը խզվում է բոլոր առկա զավակների հետ։

### CutParentLink

```c#
public Task CutParentLink(int isn, int parentIsn = -1);
```

Ջնջում է փաստաթղթի և իրա ծնողների միջև կապերը, կամ մեկ նշված փաստաթղթի հետ կապը։

**Պարամետրեր**
* isn - Այն փաստաթղթի ներքին նույնականացման համարը, որի համար խզվում է կապը ծնողի հետ։
* parentIsn - Մեկ ծնողի ներքին նույնականացման համար, այդ ծնողի կապը կզելու համար։ Եթե պարամետրը փոխանցված չէ, ապա կապը խզվում է բոլոր առկա ծնողների հետ։

### ExistInDb

```c#
public Task<bool> ExistInDb(int isn);
```

Ստուգում է փաստաթղթի առկայությունը տվյալների պահոցում։

**Պարամետրեր**
* isn - Փաստաթղթի ներքին նույնականացման համար:

### GetCaption

```c#
public Task<(string caption, string englishCaption)> GetCaption(string docType)
```

Վերադարձնում է փաստաթղթի հայերեն և անգլերեն անվանումները։

**Պարամետրեր**
* docType - Փաստաթղթի տեսակ։

### GetDocsInfo

Վերադարձնում է փաստաթղթի արխիվը պարունակող տվյալների բազայի անունը և SqlConnection դեպի այդ բազան։

```c#
public ArchiveInfo GetDocsInfo()
```

### GetDocumentChildren

```c#
public Task<List<(int isn, string docType)>> GetDocumentChildren(int isn, string docType = "", DocumentChildrenOrder order = DocumentChildrenOrder.UnOrdered, string docTypeLike = "");
```

Վերադարձնում է նշված փաստաթղթի զավակ փաստաթղերի isn-ների ու տեսակների ցուցակը:

**Պարամետրեր**
*  isn - Ծնող փաստաթղթի ներքին նույնականացման համարը:
* docType - Սահմանում է ներառվող կամ չներառվող զավակ փաստաթղթերի տիպերը։ Եթե պարամետրը առկա չի, ապա վերադարձվում են բոլոր տիպի փաստաթղթերի ISN-ները։  
Ներառվող տիպերի ցուցակը թվարկվում են `+` նշանով սկսելով՝ փաստաթղթի տեսակների անվանումները իրարից առանձնացնելով բացատներով։ Օրինակ՝ `"+KasPr MemOrd SetPr"`։  
Չներառվող տիպերի ցուցակը թվարկվում են `-` նշանով սկսելով՝ փաստաթղթի տեսակների անվանումները իրարից առանձնացնելով բացատներով։ Օրինակ՝ `"-AccDoc AsTurn"`։
Միայն նշված տիպի զավակ փաստաթղթերը վերադարձնելու համար անհրաժեշտ է ավելացնել փաստաթղթի տեսակը։ Օրինակ՝ `"AccDoc"`:
* order -  Ըստ զավակ փաստաթղթերի ստեղծման ամսաթվի դասավորման նշան։
DocumentChildrenOrder.UnOrdered - Չի դասավորվում։
DocumentChildrenOrder.CreationDateAscending - Դասավորվում է աճման կարգով։
DocumentChildrenOrder.CreationDateDescending - Դասավորվում է նվազման կարգով։
* docTypeLike - Սահմանում է ներառվող կամ չներառվող զավակ փաստաթղթերի տիպերի ֆիլտր։ Եթե պարամետրը առկա չի, ապա վերադարձվում են բոլոր տիպի զավակների ISN-ները։  
Ներառվող տիպերի ֆիլտրը `+` նշանով սկսելով։ Օրինակ՝ `"+Acc%"`։  
Չներառվող տիպերի ֆիլտրը `-` նշանով սկսելով։ Օրինակ՝ `"-Acc%"`։

### GetDocumentParents

```c#
public Task<List<(int isn, string docType)>> GetDocumentParents(int isn, string docType = "", DocumentChildrenOrder order = DocumentChildrenOrder.UnOrdered, string docTypeLike = "");
```

Վերադարձնում է նշված փաստաթղթի ծնող փաստաթղերի isn-ների ու տեսակների ցուցակը:

**Պարամետրեր**
*  isn - Զավակ փաստաթղթի ներքին նույնականացման համարը:
* docType - Սահմանում է ներառվող կամ չներառվող ծնող փաստաթղթերի տիպերը։ Եթե պարամետրը առկա չի, ապա վերադարձվում են բոլոր տիպի փաստաթղթերի ISN-ները։  
Ներառվող տիպերի ցուցակը թվարկվում են `+` նշանով սկսելով՝ փաստաթղթի տեսակների անվանումները իրարից առանձնացնելով բացատներով։ Օրինակ՝ `"+KasPr MemOrd SetPr"`։  
Չներառվող տիպերի ցուցակը թվարկվում են `-` նշանով սկսելով՝ փաստաթղթի տեսակների անվանումները իրարից առանձնացնելով բացատներով։ Օրինակ՝ `"-AccDoc AsTurn"`։
Միայն նշված տիպի ծնող փաստաթղթերը վերադարձնելու համար անհրաժեշտ է ավելացնել փաստաթղթի տեսակը։ Օրինակ՝ `"AccDoc"`:
* order -  Ըստ ծնող փաստաթղթերի ստեղծման ամսաթվի դասավորման նշան։
DocumentChildrenOrder.UnOrdered - Չի դասավորվում։
DocumentChildrenOrder.CreationDateAscending - Դասավորվում է աճման կարգով։
DocumentChildrenOrder.CreationDateDescending - Դասավորվում է նվազման կարգով։
* docTypeLike -  Սահմանում է ներառվող կամ չներառվող ծնող փաստաթղթերի տիպերի ֆիլտր։ Եթե պարամետրը առկա չի, ապա վերադարձվում են բոլոր տիպի զավակների ISN-ները։  
Ներառվող տիպերի ֆիլտրը `+` նշանով սկսելով։ Օրինակ՝ `"+Acc%"`։  
Չներառվող տիպերի ֆիլտրը `-` նշանով սկսելով։ Օրինակ՝ `"-Acc%"`։

### GetDocumentState

```c#
public Task<int> GetDocumentState(int isn);
```

Վերադարձնում է փաստաթղթի վիճակը։
Եթե փաստաթուղթը առկա չի, կամ ոչ վերջնական ջնջված է, ապա ֆունկցիան վերադարձնում է -1 արժեք։

**Պարամետրեր**
* isn - Փաստաթղթի ներքին նույնականացման համար։

### GetDocumentStatus

```c#
public Task<byte> GetDocumentStatus(string folderID, int isn)
```

Վերադարձնում է թղթապանակի տարրի վիճակը։

**Պարամետրեր**
* folderID - Թղթապանակի ներքին անուն:
* isn - Փաստաթղթի ներքին նույնականացման համար։

### GetDocumentType 

```c#
public Task<string> GetDocumentType(int isn);
```

Վերադարձնում է նշված ներքին նույնականացման համարով փաստաթղթի տեսակը։

**Պարամետրեր**
* isn - Փաստաթղթի ներքին նույնականացման համար։

### GetParentIsn

```c#
public Task<int> GetParentIsn(int isn)
```

Վերադարձնում է նշված ներքին նույնականացման համարով փաստաթղթի առաջին ծնող փաստաթղթի ներքին նույնականացման համարը։ Եթե ծնող փաստաթղթը չկա, ապա վերադառնում է -1։

### GetProcessingModes

```c#
public async Task<DocumentProcessingModes> GetProcessingModes(string docType)
```

Վերադարձնում է փաստաթղթի կատարման ռեժիմները ըստ փաստաթղթի տեսակի։
 
**Պարամետրեր**
* docType - Փաստաթղթի տեսակ:

### GetParentIsn

```c#
public Task<int> GetParentIsn(int isn, string docType)
```

Վերադարձնում է առաջին ծնող փաստաթղթի ներքին նույնականացման համարը։ Եթե ծնող փաստաթղթը չկա, ապա վերադառնում է -1։

**Պարամետրեր**
* isn - Փաստաթղթի ներքին նույնականացման համար:
* docType - 

### IsArchived

```c#
public Task<bool> IsArchived(int isn);
```

Ստուգում է փաստաթղթի արխիվացված լինելը։

**Պարամետրեր**
* isn - Փաստաթղթի ներքին նույնականացման համար:

### Load

```c#
public Task<Document> Load(int isn, GridLoadMode gridLoadMode = GridLoadMode.Full,
                                 bool loadImagesAndMemos = true, bool lockTableRow = false,
                                 bool throwExceptionIfDeleted = true, bool lookInArc = true,
                                 Type instanceType = null, bool loadParents = false)
```

Բեռնում է տվյալների պահոցում գոյություն ունեցող փաստաթուղթը ըստ ներքին նույնականացման համարի։

**Պարամետրեր**
* isn - Բեռնվող փաստաթղթի ներքին նույնականացման համարը։
* gridLoadMode - Գրիդերի բեռնման ռեժիմը։
* loadImagesAndMemos - Նկարների ու մեծ մուտքագրման դաշտերի բեռնման հայտանիշ։ Լռությամբ արժեքը  true է։
* lockTableRow -  Տվյալների պահոցում արգելափակման (lock) միացման հայտանիշ։ true արժեքի դեպքում դրվում է թարմացման (update) արգելափակում։ Լռությամբ արժեքը false է:
* throwExceptionIfDeleted - Պահանջվող փաստաթղթի հեռացված լինելու դեպքում սխալի գեներացման հայտանիշ։ 
* lookInArc - Արխիվացված փաստաթղթի բեռնման հայտանիշ։ `True` արժեքի դեպքում փաստաթղթի բեռնումը փորձում է կատարել նաև արխիվային տվյալների պահոցից, եթե այնտեղ նույնպես փաստաթութը առկա չէ, առաջանում է սխալ։ Լռությամբ արժեքը  true է։
* instanceType - ??
* loadParents -  Ծնող փաստաթղթերի ISN-ների ցուցակի բեռնման հայտանիշ։ Լռությամբ արժեքը false է։

### LoadFromFolder

```c#
public Task<Document> LoadFromFolder(string folder, string key, GridLoadMode gridLoadMode = GridLoadMode.Full,
                              bool loadImagesAndMemos = true, Type instanceType = null, bool loadParents = false);
```

Բեռնում է փաստաթուղթը ըստ թղթապանակի և բանալու։

**Պարամետրեր**
* folder - Թղթապանակի ներքին անուն։
* key - Թղթապանակի տարրի բանալի։
* gridLoadMode - Գրիդերի բեռնման ռեժիմը։
* loadImagesAndMemos - Նկարների ու մեծ մուտքագրման դաշտերի բեռնման հայտանիշ։ Լռությամբ արժեքը  true է։
* instanceType - ??
* loadParents -  Ծնող փաստաթղթերի ISN-երի ցուցակի բեռնման հայտանիշ։

### ReFolder

```c#
public Task ReFolder(Document document, StoreMode mode)
```

Իրականացնում է փաստաթղթի վերաինդեկսավորումը թղթապանակներում:

**Պարամետրեր**
* document - Փաստաթուղթը նկարագրող դասը։
* mode - Փաստաթղթի պահպանման ռեժիմը։

### Store

```c#
public Task Store(Document document, DocumentCheckLevel checkLevel = DocumentCheckLevel.None, string logComment = "");
```

Անցկացնում է պարտադիր ստուգումներ և գրանցում փաստաթուղթը տվյալների պահոցում։

**Պարամետրեր**
* document - Փաստաթուղթը նկարագրող դասը։
* checkLevel  - [Փաստաթղթի ստուգման մակարդակը](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Functions/ASDOC/DocCheckLevel.html)։
* logComment - Հաղորդագրությունը գրանցում է փաստաթղթի պատմության մեջ։

### StoreFact

```c#
public Task StoreFact(Document document, Fact fact);
```

Գրանցում է փաստաթղթի հաշվառումը։

**Պարամետրեր**
* document - Փաստաթուղթը նկարագրող դասը։
* fact - Գրանցման ենթակա հաշվառումը նկարագրող դասը։

### StoreInFolder

```c#
public void StoreInFolder(Document document, FolderElement folderElement);
```

Գրանցում է թղթապանակի տարրը։

**Պարամետրեր**
* document - Փաստաթուղթը նկարագրող դասը։
* folderElement - Թղթապանակի տարրը նկարագրող դասը։

### StoreInTree

```c#
public void StoreInTree(Document document, TreeElement treeElement);
```

Գրանցում է ծառի տարրը։

**Պարամետրեր**
* document - Փաստաթուղթը նկարագրող դասը։
* folderElement - Ծառի տարրը նկարագրող դասը։
