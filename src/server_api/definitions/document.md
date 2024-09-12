---
layout: page
title: "Փաստաթղթի նկարագրություն" 
tags: [Doc, Document, AsDoc]
---

## Բովանդակություն

- [Ներածություն](#ներածություն)
- [Օրինակներ](#օրինակներ)
- [DOCUMENT նկարագրություն](#document-նկարագրություն)
- [Document դաս](#document-դաս)
- [Հատկություններ](#հատկություններ)
  - [Archived](#archived)
  - [CancellationToken](#cancellationtoken)
  - [CopiedFrom](#copiedfrom)
  - [CreatorSUID](#creatorsuid)
  - [CreationDate](#creationdate)
  - [Description](#description)
  - [DocumentChangeRequest](#documentchangerequest)
  - [DocumentLog](#documentlog)
  - [Deleting](#deleting)
  - [ExistsInDB](#existsindb)
  - [Grids](#grids)
  - [GridsInitialized](#gridsinitialized)
  - [GridsLoaded](#gridsloaded)
  - [GridsLoading](#gridsloading)
  - [IsCancellationSupported](#iscancellationsupported)
  - [IsLogged](#islogged)
  - [InitialSnapshot](#initialsnapshot)
  - [ISN](#isn)
  - [IsNew](#isnew)
  - [IsUIOrigin](#isuiorigin)
  - [LastFixedState](#lastfixedstate)
  - [LogTransactions](#logtransactions)
  - [NestedTransactionReport](#nestedtransactionreport)
  - [Origin](#origin)
  - [Progress](#progress)
  - [Properties](#properties)
  - [ShowProgress](#showprogress)
  - [Snapshots](#snapshots)
  - [State](#state)
  - [StoreMode](#storemode)
  - [StoredFacts](#storedfacts)
  - [StoreSnapshot](#storesnapshot)
  - [TemplateSubstitutionIsExtended](#templatesubstitutionisextended)
  - [TimeStamp](#timestamp)
- [Մեթոդներ](#մեթոդներ)
  - [Action](#action)
  - [AddParent](#addparent)
  - [AfterCommit](#aftercommit)
  - [AfterCreate](#aftercreate)
  - [AfterLoad](#afterload)
  - [ApplySnapshot](#applysnapshot)
  - [BeforeCommit](#beforecommit)
  - [BeforeCopy](#beforecopy)
  - [BeforeImportProcessing](#beforeimportprocessing)
  - [Body](#body)
  - [BuildEmbeddedUIRequest](#buildembeddeduirequest)
  - [DefaultComment](#defaultcomment)
  - [Delete](#delete)
  - [DeserializeComplexObjects](#deserializecomplexobjects)
  - [ExistsGrid](#existsgrid)
  - [ExistsRekvizit](#existsrekvizit)
  - [Folders](#folders)
  - [GetCheckValue](#getcheckvalue)
  - [GetFieldType](#getfieldtype)
  - [GetImage](#getimage)
  - [GetMemo](#getmemo)
  - [GetNextTrans](#getnexttrans)
  - [GetParents](#getparents)
  - [Grid](#grid)
  - [InitGrids](#initgrids)
  - [DoLoadGrids](#doloadgrids)
  - [LoadGrids](#loadgrids)
  - [LoadImagesAndMemos](#loadimagesandmemos)
  - [LoadParents](#loadparents)
  - [OnConfirmDocumentChangeRequest](#onconfirmdocumentchangerequest)
  - [OnRefuse](#onrefuse)
  - [OnRejectDocumentChangeRequest](#onrejectdocumentchangerequest)
  - [PostMessage](#postmessage)
  - [RefreshTimeStamp](#refreshtimestamp)
  - [SendMessage](#sendmessage)
  - [SerializeComplexObjects](#serializecomplexobjects)
  - [SetCheckValue](#setcheckvalue)
  - [SetDefaultValuesForFields](#setdefaultvaluesforfields)
  - [SetDefaultValuesForFields](#setdefaultvaluesforfields-1)
  - [SetImage](#setimage)
  - [SetMemo](#setmemo)
  - [Store](#store)
  - [StoreGrids](#storegrids)
  - [StoreValuesHistory](#storevalueshistory)
  - [TakeSnapshot](#takesnapshot)
  - [TemplateSubstitution](#templatesubstitution)
  - [TemplateSubstitutionEx](#templatesubstitutionex)
  - [Validate](#validate)
  - [WriteLog](#writelog)

## Ներածություն

```c#
public class Document : DocumentBase
```

Document դասը հիմք է հանդիսանում է փաստաթղթերի սահմանման համար։ 
Բոլոր փաստաթղթերը ունեն `Document` ատրիբուտը և ժառանգ են հանդիսանում այս դասից, որը տրամադրում է վիրտուալ մեթոդներ սեփական սերվերային տրամաբանության սահմանման համար և հատկություններ փաստաթղթի մետատվյալների ստացման համար։

8X համակարգում փաստաթուղթ նկարագրելու համար հարկավոր է ունենալ
* .as ընդլայնմամբ ֆայլ սկրիպտերում [DOCUMENT](#document-նկարագրություն) նկարագրությամբ։ 
  Այն անհրաժեշտ է ներմուծել տվյալների բազա `Syscon` գործիքի միջոցով։
* .cs ընդլայնմամբ ֆայլ, որը պարունակում է սերվերում աշխատող տրամաբանությունը։

[.as և c# ֆայլերի նկարագրման ամբողջական օրինակ](../examples/document_definition.md)

## Օրինակներ

* [Փաստաթղթի նկարագրման ձեռնարկ](document_guide.md)
* [IDocumentService դաս](../services/IDocumentService.md)
* [Փաստաթղթի օգտագործման օրինակներ](../examples/document.md)
* [Փաստաթղթի ընդլայնման բազային դաս](../../extensions/definitions/document_extender.md)
* [Փաստաթղթի ընդլայնման նկարագրման ձեռնարկ](../../extensions/definitions/document_extender_guide.md)

## DOCUMENT նկարագրություն

.as ընդլայնմամբ ֆայլ անհրաժեշտ է ավելացնել [DOCUMENT](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Defs/doc.html) նկարագրություն, որը պարունակում է փաստաթղթի մետատվյալները և դաշտերի, աղյուսակների, մեմոների նկարագրությունները և 8X-ին յուրահատուկ են հատկությունները, ինչպիսին են` 

* `ALLOWSTOREINSERVICE`-ը, որը թույլատրում է փաստաթղթի գրանցումը 8X սերվիսում,
* `PROCESSINGMODE`-ը, որը սահմանում է փաստաթղթի հիմնական գործողություններից (Store, Delete, Load, Create) որոնք են կատարվում 8X սերվիսում։

DOCUMENT նկարագրությանը ծանոթանալու համար [տե՛ս](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Defs/doc.html):

## Document դաս

Փաստաթղթի համար անհրաժեշտ է սահմանել դաս, որը ժառանգում է `Document` դասը և ունի փաստաթղթի ներքին անունը պարունակող `Document` ատրիբուտը։

**Օրինակ**

```c#
[Document("TemplGrp")]
public class TemplateGroups : Document
```

## Հատկություններ

### Archived 

```c#
public bool Archived { get; internal set; }
```

Ցույց է տալիս փաստաթղթի արխիվացված լինելը։

### CancellationToken

```c#
public CancellationToken CancellationToken { get; internal set; }
```

Փաստաթղթի գրանցման ժամանակ դադարեցման տոկեն։ 
Փաստաթղթի գրանցման ժամանակ կանչվող մեթոդներում ([Validate](#validate), [Action](#action)...) տալիս է հնարավորություն ստուգելու արդյոք UI-ում փաստաթղթի գրանցումը դադարեցնել կոճակի միջոցով ընդատված է, թե ոչ։

### CopiedFrom

```c#
public int CopiedFrom { get; internal set; } = -1;
```

Վերադարձնում է այն փաստաթղթի isn-ը, որից պատճենվել է տվյալ փաստաթուղթը։

### CreatorSUID

```c#
public short CreatorSUID { get; internal set; }
```

Վերադարձնում է փաստաթուղթը ստեղծողի ներքին համարը (user id):

### CreationDate 

```c#
public DateTime CreationDate { get; internal set; }
```

Վերադարձնում է փաստաթղթի ստեղծման ամսաթիվը/ժամանակը։

### Description 

```c#
public DocumentDescription Description { get; internal set; }
```

Վերադարձնում է փաստաթղթի նկարագրությունը։

### DocumentChangeRequest

```c#
public DocumentChangeRequest DocumentChangeRequest { get; internal set; }
```

Վերադարձնում է փաստաթղթի փոփոխման հայտը գրանցման իրադարձություններում (Validate, Action), երբ փոփոխման հայտը հաստատվում է։ 

### DocumentLog

```c#
public DocumentLog DocumentLog { get; internal set; } = new DocumentLog();
```

Նախատեսված է փաստաթղթի լոգերի ժամանակավոր պահպանման համար, որոնք գրանցվում են [փաստաթղթի պատմությունում](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/DocLog.html) փաստաթղթի գրանցման ժամանակ։

### Deleting

```c#
public bool Deleting { get; internal set; }
```

Ցույց է տալիս, որ փաստաթուղթը հեռացման ընթացքում է [IDocumentService](../services/IDocumentService.md) դասի [Delete](../services/IDocumentService.md#delete), [DeleteAll](../services/IDocumentService.md#delete) մեթոդների միջոցով։

### ExistsInDB

```c#
public bool ExistsInDB { get; internal set; }
```

Ցույց է տալիս փաստաթղթի գրանցված լինելը տվյալների պահոցում։

### Grids

```c#
public IReadOnlyDictionary<string, IGrid> Grids { get; private set; }
```

Վերադարձնում է փաստաթղթի աղյուսակների բազմությունը՝ որտեղ բանալին աղյուսակի ներքին անունն է, իսկ արժեքը՝ աղյուսակը IGrid ինտերֆեյսով։

### GridsInitialized

```c#
public bool GridsInitialized { get; protected internal set; }
```

Ցույց է տալիս փաստաթղթի աղյուսակների ձևավորված լինելը։ 

### GridsLoaded

```c#
public bool GridsLoaded { get; protected internal set; }
```

Ցույց է տալիս փաստաթղթի աղյուսակների բեռնված լինելը։ 
Փաստաթղթի բեռնման ժամանակ հնարավոր է բեռնել միայն դաշտերը։
Տե՛ս [IDocumentService](../services/IDocumentService.md).[Load](../services/IDocumentService.md#load)։

### GridsLoading 

```c#
public bool GridsLoading { get; internal set; } = false;
```

Ցույց է տալիս փաստաթղթի աղյուսակները գտնվում են բեռնման պրոցեսում թե ոչ։
Այս հատկանիշը էական է աղյուսակների բեռնման սեփական մշակման դեպքում։ 
Տե՛ս [DoLoadGrids](#doloadgrids)։

### IsCancellationSupported

```c#
public virtual bool IsCancellationSupported { get { return true; } }
```

Այս մշակվող հատկության միջոցով հնարավոր է թույլատրել կամ արգելել UI-ից փաստաթղթի գրանցման դադարեցման (cancellation) հնարավորությունը։

### IsLogged

```c#
public bool IsLogged { get; set; }
```

Ցույց է տալիս, թե փաստաթղթի լոգերը գրանցվել են [փաստաթղթի պատմությունում](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/DocLog.html) [WriteLog](#writelog) մեթոդի միջոցով։

### InitialSnapshot

```c#
public DocumentSnapshot InitialSnapshot { get; private set; }
```

[Snapshots](#snapshots)-ից վերադարձնում է `"InitialSnapshot"` բանալիով փաստաթղթի քեշավորված պատկերը։

### ISN

```c#
public int ISN { get; internal set; }
```

Վերադարձնում է փաստաթղթի ներքին նույնականացման համարը (isn-ը):

### IsNew 

```c#
public bool IsNew { get; internal set; }
```

Վերադարձնում է փաստաթղթի նոր կամ սևագիր լինելու հայտանիշը։

### IsUIOrigin

```c#
public bool IsUIOrigin
```

Ցույց է տալիս փաստաթղթի ֆորման երևում է UI-ում, թե ոչ։

### LastFixedState

```c#
public short LastFixedState { get; internal set; } = 0;
```

Վերադարձնում է փասթաթղթի տվյալների պահոցում գրանցված վերջին վիճակը։

Ի տարբերություն **LastFixedState** հատկության, [State](#state)  հատկությունը վերադարձնում է փաստաթղթի ընթացիկ վիճակը, որը կարող է նաև տվյալների պահոցում գրանցված չլինել։

### LogTransactions

```c#
public bool LogTransactions { get; set; }
``` 

Վերադարձնում կամ նշանակում է փաստաթղթի պատմության մեջ հաշվառումների գրանցման վերաբերյալ ավտոմատ լոգավորում կատարելու հայտանիշը։

### NestedTransactionReport 

```c#
public StorageInfo NestedTransactionReport { get; internal set; }
```

??

### Origin

```c#
public DocumentOrigin Origin { get; internal set; }
```

Վերադարձնում է փաստաթուղթը գրանցող [աղբյուրը](../services/DocumentOrigin.md):

### Progress 

```c#
public DocumentExecutionProgress Progress { get; private set; }
```

Վերադարձնում է փաստաթղթի կատարման պրոգրեսը։

Այս օբյեկտի միջոցով հնարավոր է կառավարել գրանցման փուլերը, UI-ում ցույց տալ այդ փուլերը և UI-ում ցույց տալ հաղորդագրության պատուհան (MessageBox):
Տե՛ս [օրինակ](../../extensions/examples/document_extender_country.md)։

### Properties

```c#
public Dictionary<string, object> Properties { get; set; }
```

Վերադարձնում է կամ արժեքավորում է փաստաթղթի հատկությունները։

### ShowProgress

```c#
public virtual bool ShowProgress { get { return false; } }
```

Ցույց է տալիս փաստաթղթի գրանցումը/հեռացումը UI-ում անհրաժեշտ է կատարել պրոգրեսի պատուհանով թե ոչ։
        
### Snapshots

```c#
public Dictionary<string, DocumentSnapshot> Snapshots { get; internal set; } = new(StringComparer.InvariantCultureIgnoreCase);
```

Վերադարձնում է փաստաթղթի `DocumentSnapshot` տիպի քեշավորված պատկերների բազմությունը։

### State

```c#
public short State { get; set; }
```

Վերադարձնում կամ նշանակում է փաստաթղթի վիճակը:

### StoreMode

```c#
public StoreMode StoreMode { get; internal set; }
```

Վերադարձնում է տվյալների պահոցում [փաստաթղթի գրանցման ռեժիմը](../services/StoreMode.md) գրանցման մեթոդների ընթացքում։

### StoredFacts

```c#
public List<Fact> StoredFacts { get; internal set; }
```

Վերադարձնում է փաստաթղթի ժամանակավոր պահված հաշվառումների գրառումների ցուցակը, որոնք ավելանում են [DocumentService](../services/IDocumentService.md).[StoreFact](../services/IDocumentService.md#storefact) մեթոդով։

[IDBService](../services/IDBService.md).[TransDeferred](../services/IDBService.md#transdeferred) հատկության `true` արժեքի դեպքում հաշվառումները պահվում են ժամանակավոր այս հատկությունում և գրանցվում տվյալների պահոցում [IDocumentService](../services/IDocumentService.md).[Store](../services/IDocumentService.md#store) մեթոդով փաստաթուղթը գրանցելիս, հակառակ դեպքում գրանցվում են տվյալների պահոցում անմիջապես։

### StoreSnapshot

```c#
public DocumentSnapshot StoreSnapshot { get; private set; }
```

[Snapshots](#snapshots)-ից վերադարձնում է `"StoreSnapshot"` բանալիով փաստաթղթի քեշավորված պատկերը։

### TemplateSubstitutionIsExtended

```c#
public virtual bool TemplateSubstitutionIsExtended { get; }
```

??

### TimeStamp

```c#
public byte[] TimeStamp { get; internal set; }
```

Վերադարձնում է փաստաթղթի վերջին փոփոխման ամսաթիվը և ժամանակը` որպես byte տիպի զանգված:

## Մեթոդներ

### Action

```c#
public virtual Task Action(ActionEventArgs args);
```

Մեթոդը կանչվում է միջուկի կողմից [IDocumentService](../services/IDocumentService.md).[Store](../services/IDocumentService.md#store) ֆունկցիայով փաստաթուղթը տվյալների պահոցում գրանցելուց առաջ։

Հաշվառումների ստեղծումը և տվյալների պահոցում գրանցումը հարկավոր է կատարել այս մեթոդում [IDocumentService](../services/IDocumentService.md).[StoreFact](../services/IDocumentService.md#storefact) մեթոդով։

Հանդիսանում է 4x համակարգում նկարագրված [Action](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/Action.html)  իրադարձության համարժեքը:

### AddParent

```c#
public Task AddParent(int isn);
```

Ավելացնում է տրված isn-ով փաստաթուղթը փաստաթղթի ծնող փաստաթղթերի ցուցակում։

Ծնող փաստաթղթերի ցուցակը գրանցում է տվյալների պահոցի [DOCP](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/DocP.html) աղյուսակում 
[IDocumentService](../services/IDocumentService.md).[Store](../services/IDocumentService.md#store) ֆունկցիայով փաստաթուղթը տվյալների պահոցում գրանցելուց:

**Պարամետրեր**

* `isn` - Ծնող փաստաթղթի ներքին նույնականացման համարը։

### AfterCommit

```c#
public virtual Task AfterCommit(AfterCommitEventArgs args);
```

Մեթոդը կանչվում է միջուկի կողմից [IDocumentService](../services/IDocumentService.md).[Load](../services/IDocumentService.md#load) ֆունկցիայով փաստաթուղթը տվյալների պահոցից բեռնելուց անմիջապես հետո։

Հանդիսանում է 4x համակարգում նկարագրված `AfterCommit` իրադարձության համարժեքը:

### AfterCreate

```c#
public virtual Task AfterCreate(AfterCreateEventArgs args);
```

Մեթոդը կանչվում է միջուկի կողմից [IDocumentService](../services/IDocumentService.md).[Create](../services/IDocumentService.md#create) ֆունկցիայով փաստաթղթի օբյեկտը ստեղծելուց հետո։

Փաստաթղթի ներմուծման ժամանակ մեթոդը չի կանչվում։

Հանդիսանում է 4x համակարգում նկարագրված [AfterCreate](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/AfterCreate.html)  իրադարձության համարժեքը:

### AfterLoad

```c#
public virtual Task AfterLoad(AfterLoadEventArgs args);
```

Մեթոդը կանչվում է միջուկի կողմից [IDocumentService](../services/IDocumentService.md).[Load](../services/IDocumentService.md#load) ֆունկցիայով փաստաթուղթը տվյալների պահոցից բեռնելուց անմիջապես հետո։

Մեթոդում սովորաբար փաստաթղթի դաշտերին տրվում են ժամանակավոր արժեքներ։

Հանդիսանում է 4x համակարգում նկարագրված [AfterLoad](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/AfterLoad.html)  իրադարձության համարժեքը:

### ApplySnapshot

```c#
public void ApplySnapshot(DocumentSnapshot snapshot);
```

`snapshot` պարամետրում եղած փաստաթղթի քեշավորված պատկերի արժեքները վերագրում է փաստաթղթի դաշտերին և աղյուսակներին։

### BeforeCommit

```c#
public virtual Task BeforeCommit(BeforeCommitEventArgs args);
```

Մեթոդը կանչվում է միջուկի կողմից [IDocumentService](../services/IDocumentService.md).[Store](../services/IDocumentService.md#store) ֆունկցիայով փաստաթուղթը տվյալների պահոցում գրանցելուց տրանզակցիան փակելուց առաջ։

Մեթոդում իմաստ չունի փոխել փաստաթղթի հատկությունները, գեներացնել հաշվառումները և այլն։

Հանդիսանում է 4x համակարգում նկարագրված [BeforeCommit](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/BeforeCommit.html)  իրադարձության համարժեքը:

### BeforeCopy

```c#
public virtual Task BeforeCopy(BeforeCopyEventArgs args);
```

Մեթոդը կանչվում է միջուկի կողմից [IDocumentService](../services/IDocumentService.md).[Copy](../services/IDocumentService.md#copy) ֆունկցիայով փաստաթղթի պատճեն օբյեկտը ստեղծելուց հետո։

Հանդիսանում է 4x համակարգում նկարագրված [BeforeCopy](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/BeforeCopy.html)  իրադարձության համարժեքը:

### BeforeImportProcessing

```c#
public virtual Task BeforeImportProcessing(BeforeImportProcessingEventArgs args);
```

Մեթոդը կանչվում է միջուկի կողմից փաստաթղթերի ներմուծման ժամանակ փաստաթղթի օբյեկտի ստեղծելուց հետո։

Հանդիսանում է 4x համակարգում նկարագրված [BeforeImport](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/BeforeImport.html)  իրադարձության համարժեքը:

### Body

```c#
public string Body();
```

Վերադարձնում է փաստաթղթի սերիալիզացված դաշտերի բազմությունը որպես տեքստ, ինչպես գրվում է ներմուծման .as ընդլայնմամբ ֆայլում կամ [DOCS](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/Docs.html) աղյուսակի `fBODY` սյունում։

Ներառված չեն փաստաթղթի աղյուսակները, նկարները և մեծ տեքստային դաշտերը (մեմո)։

### BuildEmbeddedUIRequest

```c#
public void BuildEmbeddedUIRequest<T>(T uiRequestExecutionProgress) where T : IUIRequestExecutionProgress;
```

Փաստաթղթի UI-ում progress-ով մշակման ժամանակ հաղորդագրության պատուհան (messagebox) ցուցադրելու համար անհրաժոշտ է կանչել այս մեթոդը։

### DefaultComment

```c#
public virtual Task DefaultComment(DefaultCommentEventArgs args);
```

Մեթոդը կանչվում է միջուկի կողմից փաստաթղթի [թղթապանակի տարր](../services/FolderElement.md) ստեղծելուց մեկնաբանություն լրացնելու համար։

Հանդիսանում է 4x համակարգում նկարագրված [DefaultComment](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/DefaultComment.html) իրադարձության համարժեքը:

### Delete

```c#
public virtual Task Delete(DeleteEventArgs args);
```

Մեթոդը կանչվում է միջուկի կողմից [IDocumentService](../services/IDocumentService.md).[Delete](../services/IDocumentService.md#delete) ֆունկցիայով փաստաթղթի ջնջելուց առաջ։

Նախատեսված է ջնջելուց առաջ ստուգումներ կատարելու և կապակցված տվյալներ ջնջելու համար։

Հանդիսանում է 4x համակարգում նկարագրված [Delete](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/Delete.html)  իրադարձության համարժեքը:

### DeserializeComplexObjects

```c#
public virtual Task DeserializeComplexObjects(DeserializeComplexObjectsEventArgs args);
```

Մեթոդը անհրաժեշտ է մշակել այն դեպքում, երբ 4X-ական փաստաթղթի `Properties` հատկությունով եկած բարդ օբյեկտները անհրաժեշտ է բերել համապատասխան c#-ական տիպերի 8X-ում։

**Օրինակ**
```c#
public override async Task DeserializeComplexObjects(DeserializeComplexObjectsEventArgs args)
{
  foreach (var key in args.ComplexObjectsJson.Keys)
  {
    if (key.StartsWith("StmKey"))
    {
      this.Properties.Add(key, await this.DocumentService.DeserializeRequestBody(args.Deserialize<DocumentModel>(key)));
    }
  }
}
```

### ExistsGrid

```c#
public bool ExistsGrid(string grid);
```

Ստուգում է տրված ներքին անունով աղյուսակի առկայությունը փաստաթղթի նկարագրության մեջ։

**Պարամետրեր**

* `grid` - Աղյուսակի ներքին անունը։

### ExistsRekvizit

```c#
public bool ExistsRekvizit(string rekv);
```

Ստուգում է տրված ներքին անունով դաշտի առկայությունը փաստաթղթի նկարագրության մեջ։

**Պարամետրեր**

* `rekv` - Դաշտի ներքին անունը։

### Folders

```c#
public virtual Task Folders(FoldersEventArgs args);
```

Մեթոդը կանչվում է միջուկի կողմից [IDocumentService](../services/IDocumentService.md).[Store](../services/IDocumentService.md#store) ֆունկցիայով փաստաթուղթը տվյալների պահոցում գրանցելուց առաջ։
Կանչվում է նաև փաստաթղթերի ինդեքսավորման ժամանակ։

Թղթապանակների, ծառերի տարրերի ստեղծումը և տվյալների պահոցումը գրանցումը հարկավոր է կատարել այս մեթոդում՝ կանչելով [IDocumentService](../services/IDocumentService.md).[StoreInFolder](../services/IDocumentService.md#storeinfolder) և [IDocumentService](../services/IDocumentService.md).[StoreInTree](../services/IDocumentService.md#storeintree) մեթոդների միջոցով։

Հանդիսանում է 4x համակարգում նկարագրված [Folders](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/Folders.html)  իրադարձության համարժեքը:

### GetCheckValue

```c#
public bool GetCheckValue(string fieldName);
```

Վերադարձնում է փաստաթղթի նշված ներքին անունով դաշտի ստուգման հայտանիշը: 
`false` արժեքի դեպքում դաշտի լրացման կամ ցուցադրման ժամանակ չի ստուգվում արժեքի առկայությունը ծառում կամ թղթապանակում։ 
`true` արժեքի դեպքում դաշտի արժեքը պետք է գոյություն ունենա դաշտի համակարգային տիպում նկարագրված ծառում կամ թղթապանակում։

**Պարամետրեր**

* `fieldName` - Դաշտի ներքին անունը։

### GetFieldType

```c#
public FieldType GetFieldType(string fieldName);
```

Վերադարձնում է փաստաթղթի տրված ներքին անունով դաշտի [համակարգային տիպը](../../system_types.md)։

**Պարամետրեր**

* `fieldName` - Դաշտի ներքին անունը։

### GetImage

```c#
public byte[] GetImage(string name);
```

Վերադարձնում է փաստաթղթի տրված ներքին անունով նկար դաշտը՝ որպես byte տիպի զանգված։

**Պարամետրեր**

* `fieldName` - Նկարի ներքին անունը։

### GetMemo

```c#
public string GetMemo(string name);
```

Վերադարձնում է փաստաթղթի տրված ներքին անունով մեծ տեքստային դաշտի (մեմոյի) արժեքը։

**Պարամետրեր**

* `fieldName` - Մեմոյի ներքին անունը։

### GetNextTrans

```c#
public int GetNextTrans();
```

Վերադարձնում է փաստաթղթի տրանզակցիայի հերթական նոր համարը։

Մի քանի գրանցվող հաշվառում խմբավորելու համար օգտագործվում է Trans հատկությունը, որին տրվում է մեկ տրանզակցիայի համար։ 
Նոր համար ստացվում է GetNextTrans ֆունկցիայի միջոցով։ 

### GetParents

```c#
public Task<List<int>> GetParents();
```

Վերադարձնում է փաստաթղթի ծնող փաստաթղթերի isn-ների ցուցակը։ 

### Grid

```c#
public IGrid Grid(string name);
```

Վերադարձնում է փաստաթղթի տրված ներքին անունով աղյուսակը։
IGrid-ի տակից կարող է լինել չտիպիզացված աղյուսակ, կամ տիպիզացված աղյուսակ, եթե [CodeGen](../CodeGen/CodeGen.md) գործիքով ձևավորվել են տիպիզացված աղյուսակներ։

**Պարամետրեր**

* `fieldName` - Աղյուսակի ներքին անունը։

### InitGrids

```c#
protected void InitGrids();
```

Ձևավորում է փաստաթղթի աղյուսակները՝ առանց տվյալների բեռնելու։ 

### DoLoadGrids

```c#
protected virtual Task DoLoadGrids(LoadGridsEventArgs args);
```

Մեթոդը կանչվում է միջուկի կողմից [IDocumentService](../services/IDocumentService.md).[Load](../services/IDocumentService.md#load) մեթոդի միջոցով փաստաթուղթը բեռնելիս։

Նախատեսված է [DOCSG](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/DocsG.html) աղյուսակում չպահվող փաստաթղթի աղյուսակների բեռնման տրամաբանության սահմանման համար։

Մեթոդը չմշակելու դեպքում բեռնվելու են [DOCSG](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/DocsG.html) աղյուսակում պահվող փաստաթղթի աղյուսակները։

**Պարամետրեր**

* `args` - LoadGridsEventArgs տիպի օբյեկտ, որը պարունակում է [GridLoadMode](../services/GridLoadMode.md) տիպի օբյեկտ, որը սահմանում է փաստաթղթի աղյուսակների բեռնման ռեժիմը։

### LoadGrids

```c#
public Task LoadGrids(LoadGridsEventArgs args);
```

Բեռնում է փաստաթղթի աղյուսակները, եթե մինչ այդ բեռնված չէին [IDocumentService](../services/IDocumentService.md).[Load](../services/IDocumentService.md#load):

**Պարամետրեր**

* `args` - LoadGridsEventArgs տիպի օբյեկտ, որը պարունակում է [GridLoadMode](../services/GridLoadMode.md) տիպի օբյեկտ, որը սահմանում է փաստաթղթի աղյուսակների բեռնման ռեժիմը։

### LoadImagesAndMemos

```c#
public Task LoadImagesAndMemos(ArchiveInfo archiveInfo = null);
```

Բեռնում է փաստաթղթի նկարները և մեծ տեքստային դաշտերը (մեմոներ) տվյալների պահոցից։

**Պարամետրեր**

* `archiveInfo` - ArchiveInfo դասի օբյեկտ, որը պարունակում է արխիվացված փաստաթուղթը պարունակող տվյալների պահոցի անունը և [IDBService](../services/IDBService.md) դասի օբյեկտ՝ այդ պահոցի հետ Sql միացում ապահովելու համար։

### LoadParents

```c#
public Task LoadParents();
```

Բեռնում է փաստաթղթի ծնող փաստաթղթերի isn-ների ցուցակը տվյալների պահոցից, անկախ այն բանից մինչև այդ բեռնված էին թե ոչ։

### OnConfirmDocumentChangeRequest

```c#
public virtual Task OnConfirmDocumentChangeRequest(ConfirmDocumentChangeRequestEventArgs args);
```

Մեթոդը կանչվում է միջուկի կողմից փաստաթղթի փոփոխման հայտը `IDocumentChangeRequestService.Reject` մեթոդով հաստատելիս։

Հանդիսանում է 4x համակարգում նկարագրված `ONCONFIRMDCR` իրադարձության համարժեքը:

### OnRefuse

```c#
public virtual Task OnRefuse(RefuseEventArgs args);
```

Մեթոդը կանչվում է միջուկի կողմից [IDocumentService](../services/IDocumentService.md).[Delete](../services/IDocumentService.md#delete) մեթոդի միջոցով փաստաթղթի ջնջելուց առաջ, եթե մեթոդի `callDelete` պարամետրի արժեքը `false` է։ 

Այս մեթոդի մշակման դեպքում իմաստ չունի մշակել [Delete](#delete) մեթոդը, քանի որ մեթոդը չի կանչվելու միջուկի կողմից։

Հանդիսանում է 4x համակարգում նկարագրված `OnRefuseDoc` իրադարձության համարժեքը:

### OnRejectDocumentChangeRequest

```c#
public virtual Task OnRejectDocumentChangeRequest(RejectDocumentChangeRequestEventArgs args);
```

Մեթոդը կանչվում է միջուկի կողմից փաստաթղթի փոփոխման հայտը `IDocumentChangeRequestService.Reject` մեթոդով մերժելիս։

Հանդիսանում է 4x համակարգում նկարագրված `ONCONFIRMDCR` իրադարձության համարժեքը:

### PostMessage

```c#
public virtual Task PostMessage(PostMessageEventArgs args);
```

Մեթոդը կանչվում է միջուկի կողմից երբ կից փաստաթղթից այս փաստաթղթին ուղարկվում է ծրագրային հաղորդագրություն [SendMessage](#sendmessage) ֆունկցիայի միջոցով, դրանից հետո այս փաստաթուղթը գրանցվում տվյալների պահոցում։

Հանդիսանում է 4x համակարգում նկարագրված [PostMessage](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/PostMessage.html)  իրադարձության համարժեքը:

### RefreshTimeStamp

```c#
public Task RefreshTimeStamp();
```

Հիշողության մեջ թարմացնում է փաստաթղթի վերջին փոփոխման ամսաթիվը և ժամանակը՝ [TimeStamp](#timestamp)` բեռնելով այն տվյալների պահոցից։

### SendMessage

```c#
public Task SendMessage(string message,
                        int isn = -1,
                        string messageForDocLog = "",
                        bool raiseErrorIfDocNotExists = true,
                        bool raiseErrorIfParentNotExists = true);
```

Ուղարկում է հաղորդագրություն այլ փաստաթղթի (կամ ծնող փաստաթղթերին) աշխատացնելով [PostMessage](#postmessage) ֆունկցիան:  
Հաղորդագրություն ստանալուց հետո ստացող փաստաթղթի [պատմության](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/DocLog.html)  մեջ [գրանցվում է](#writelog) հաղորդագրության տեքստը և ստացող փաստաթուղթը գրանցվում է տվյալների պահոցում [StoreMode](#storemode) հատկությանը տալով `ContinueProcessing` արժեքը։

**Պարամետրեր**
- `message` - Ուղարկվող հաղորդագրության տեքստը։
- `isn` - Հաղորդագրությունը ստացող փաստաթղթի ներքին նույնականացման համարը։ 
  Եթե պարամետրը փոխանցված չէ, ապա հաղորդագրությունը կուղարկվի ընթացիկ փաստաթղթի ծնող փաստաթղթերին, եթե այն առկա են։
- `messageForDocLog` - Ստացող փաստաթղթի պատմության մեջ գրանցվող տեքստը։ 
  Եթե պարամետրը փոխանցված չէ, ապա պատմության մեջ կգրանցվի `message` պարամետրի արժեքը։
- `raiseErrorIfDocNotExists` - Ստացող փաստաթղթի բացակայության դեպքում սխալի գեներացում։ 
  Լռությամբ արժեքը **true** է։
- `raiseErrorIfParentNotExists` - Ստացող ծնող փաստաթղթերի բացակայության դեպքում սխալի գեներացում։ 
  Լռությամբ արժեքը **true** է։

### SerializeComplexObjects

```c#
public virtual Task SerializeComplexObjects(SerializeComplexObjectsEventArgs args);
```

Մեթոդը անհրաժեշտ է մշակել այն դեպքում, երբ 8X-ական փաստաթղթի `Properties` հատկությունում եկած բարդ օբյեկտները անհրաժեշտ է բերել 4x-ական տիպերի՝ 4X-ում օգտագործելու համար։

### SetCheckValue

```c#
public void SetCheckValue(string fieldName, bool value);
```

Նշանակում է փաստաթղթի նշված ներքին անունով դաշտի ստուգման հայտանիշը:

**Պարամետրեր**

- `fieldName` - Դաշտի ներքին անունը։
- `value` - Սահմանում է դաշտի համակարգային տիպում նշված ծառում կամ թղթապանակում դաշտի արժեքի առկայությունը։

### SetDefaultValuesForFields

```c#
public void SetDefaultValuesForFields(IList<string> fields);
```

Վերագրում է լռությամբ արժեքներ փաստաթղթի տրված դաշտերին։

**Պարամետրեր**

- `fields` - Փաստաթղթի դաշտերի ներքին անունների ցուցակ։

### SetDefaultValuesForFields

```c#
public void SetDefaultValuesForFields(params string[] fields);
```

Վերագրում է լռությամբ արժեքներ փաստաթղթի տրված դաշտերին։

**Պարամետրեր**

- `fields` - Փաստաթղթի դաշտերի ներքին անունների ցուցակ։

### SetImage

```c#
public void SetImage(string name, byte[] value);
```

Արժեքավորում է փաստաթղթի տրված ներքին անունով նկար դաշտը։

**Պարամետրեր**

* `name` - Նկարի ներքին անունը։
* `value` - Վերագրվող արժեքը։

### SetMemo

```c#
public void SetMemo(string name, string value);
```

Արժեքավորում է փաստաթղթի տրված ներքին անունով մեծ տեքստային դաշտը (մեմո)։

**Պարամետրեր**

* `name` - Մեմոյի ներքին անունը։
* `value` - Վերագրվող արժեքը։

### Store

```c#
public Task Store(DocumentCheckLevel checkLevel = DocumentCheckLevel.None, string logComment = "");
```

Կատարում է պարտադիր ստուգումներ և գրանցում փաստաթուղթը տվյալների պահոցում։

**Պարամետրեր**

* `checkLevel` - [Փաստաթղթի գրանցման եղանակ](../services/DocumentCheckLevel.md), որը որոշում է թե ինչ ստանդարտ ստուգումներ և մշակիչներ ([Action](#action), [Validate](#validate)) կարող են անջատվել կամ միացվել փաստաթղթի գրանցման ընթացքում, ինչպես նաև, թե ինչ լրացուցիչ մշակիչներ պետք է գործարկվեն։
* `logComment` - Փաստաթղթի պատմության մեջ գրվող տեքստը։

### StoreGrids

```c#
public virtual Task StoreGrids(StoreGridsEventArgs args);
```

Մեթոդը կանչվում է միջուկի կողմից փաստաթուղթը [IDocumentService](../services/IDocumentService.md).[Store](../services/IDocumentService.md#store) մեթոդի միջոցով տվյալների պահոցում գրանցելուց։

Մեթոդի գերբեռնումը նախատեսված է փաստաթղթի ցանկալի աղյուսակները DOCSG աղյուսակի մեջ չպահպանելու և այլ տեղերում պահպանելու համար։
Այլ տեղում պահպանված աղյուսակները հարկավոր է ավելացնել `args.IgnoreGrids` ցուցակում։

```c#
args.IgnoreGrids.AddRange([Grid("CLIENTS"), Grid("STMDATES")]);
```

Մշակման դեպքում ծրագրավորողը պետք է ապահովի աղյուսակի ճիշտ բեռնումը մշակելով [DoLoadGrids](#doloadgrids) մեթոդը։

Հանդիսանում է 4x համակարգում նկարագրված [StoreGrid](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/StoreGrid.html)  իրադարձության համարժեքը:

### StoreValuesHistory

```c#
public Task StoreValuesHistory();
```

Փաստաթղթի դաշտերի արժեքները գրանցում է տվյալների պահոցի `LASTVALUESGROUP` աղյուսակում։
Օգտագործվում է UI-ում փաստաթղթի պատուհանում նախկին օգտագործված արժեքները առաջարկելու համար։

### TakeSnapshot

```c#
public Task TakeSnapshot(SnapshotContent content, string name, bool overwrite = true);
```

Քեշավորում և պահպանում է փաստաթղթի պատկերը [Snapshots](#snapshots)-ում։

**Պարամետրեր**

* `content` - Սահմանում է փաստաթղթի քեշավորվող կտորները, որը կարող է ընդունել հետևյալ արժեքները՝
	* SnapshotContent.None - ոչինչ չի քեշավորվում,
	* SnapshotContent.Requisites - քեշավորվում են միայն դաշտերը,
	* SnapshotContent.Grids - քեշավորվում են միայն աղյուսակները,
	* SnapshotContent.All - քեշավորվում են դաշտերը և աղյուսակները։
* `name` - Ստեղծվող քեշավորման օբյեկտի ներքին անուն, որը հանդիսանալու է բանալի [Snapshots](#snapshots)-ում։
* `overwrite` - Բանալիի կրկնության դեպքում վերարտագրման հայտանիշ։

### TemplateSubstitution

```c#
public virtual Task<TemplateSubstitution> TemplateSubstitution(Dictionary<string, bool> mode, Dictionary<string, object> parameters = null);
```

Մեթոդը կանչվում է միջուկի կողմից, երբ փաստաթղթի համար ձևավորվում է տպման ձև և անջատված է [TemplateSubstitutionIsExtended](#templatesubstitutionisextended) հատկությունը։ 

Հանդիսանում է 4x համակարգում նկարագրված [TemplateSubstitution](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/TemplateSubstitution.html) իրադարձության համարժեքը:

### TemplateSubstitutionEx

```c#
public virtual Task<TemplateSubstitutionEx> TemplateSubstitutionEx(Dictionary<string, bool> mode, Dictionary<string, object> parameters = null);
```

Մեթոդը կանչվում է միջուկի կողմից, երբ փաստաթղթի համար ձևավորվում է տպման ձև և միացված է [TemplateSubstitutionIsExtended](#templatesubstitutionisextended) հատկությունը։ 

Հանդիսանում է 4x համակարգում նկարագրված  [TemplateSubstitution](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/TemplateSubstitution.html) իրադարձության համարժեքը:

### Validate

```c#
public virtual Task Validate(ValidateEventArgs args);
```

Մեթոդը կանչվում է միջուկի կողմից [IDocumentService](../services/IDocumentService.md).[Store](../services/IDocumentService.md#store) ֆունկցիայով փաստաթուղթը տվյալների պահոցում գրանցելուց առաջ։

Օգտագործվում է փաստաթղթի դաշտերի արժեքների ստուգման համար։

Հանդիսանում է 4x համակարգում նկարագրված [Validate](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/Validate.html)  իրադարձության համարժեքը:

### WriteLog

```c#
public Task WriteLog(string message, int dcrId = -1, bool dcrIdIsISN = false);
```

Ավելացնում է նոր գրառում փաստաթղթի պատմության մեջ։

Փաստաթղթի կյանքի ընթացքում մի շարք գործողություններ գրանցվում են պատմության մեջ ավտոմատ կերպով, ինչպիսին են փաստաթղթի ստեղծումը կամ խմբագրումը։ 
Այս մեթոդի միջոցով հնարավոր է ավելացնել լրացուցիչ տողեր։ 
`dcrIdIsISN` պարամետրի `false` արժեքի դեպքում [DOCLOG](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/DocLog.html) աղյուսակում ավելանում է գրառում `"M"` կոդով, հակառակ դեպքում `"L"` կոդով։

Եթե այս մեթոդը կանչում ենք [Action](#action) մեթոդի մեջ, ապա գրանցումները տվյալների պահոցում կատարվում են մեթոդի ավարտից հետո, հակառակ դեպքում գրանցումը կատարվում է անմիջապես։

**Պարամետրեր**

* `message` - Փաստաթղթի պատմությունում ավելացվող հաղորդագրություն։
* `dcrId` - Փոփոխման հայտի համարը (DocChangeRequest) կամ հիմքային փաստաթղթի ներքին նույնականացման համարը։
* `dcrIdIsISN` - `false` արժեքը ցույց է տալիս, որ `dcrId`-ը փոփոխման հայտի համար է, `true` արժեքը՝ հիմքային փաստաթղթի ներքին նույնականացման համար։
