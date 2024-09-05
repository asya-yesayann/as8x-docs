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
Գրանցման իրադարձություններում (Validate, Action) տալիս է հնարավորություն ստուգելու արդյոք UI-ում փաստաթղթի գրանցումը դադարեցնել կոճակի միջոցով ընդատված է, թե ոչ։

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

Վերադարձնում է փաստաթղթի ստեղծման ամսաթիվը/ժամը։

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

??

### Deleting

```c#
public bool Deleting { get; internal set; }
```

Ցույց է տալիս, որ փաստաթուղթը հեռացման ընթացքում է Delete, OnRefuse իրադարձություններում։

### ExistsInDB

```c#
public bool ExistsInDB { get; internal set; }
```

Ցույց է տալիս փաստաթղթի գրանցված լինելը տվյալների պահոցում։

### Grids

```c#
public IReadOnlyDictionary<string, IGrid> Grids { get; private set; }
```

Վերադարձնում է փաստաթղթի աղյուսակների բազմությունը՝ որտեղ բանալին աղյուսակի ներքին անունն է, իսկ արժեքն է աղյուսակը IGrid ինտերֆեյսով։

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
Տե՛ս [Load](../services/IDocumentService.md#load)։

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

Այս մշակվող հատկության միջոցով հնարավոր է թույլատրել կամ արգելել UI-ից փաստաթղթի գրանցման դադարեցման (cancellation) հնարվորությունը։

### IsLogged

```c#
public bool IsLogged { get; set; }
```

??

### InitialSnapshot

```c#
public DocumentSnapshot InitialSnapshot { get; private set; }
```

[Snapshots](#snapshots)-ից վերադարձնում է `"InitialSnapshot"` բանակիով փաստաթղթի քեշավորված պատկերը։

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

Ի տարբերություն **LastFixedState** հատկության,  [State](#state)  հատկությունը վերադարձնում է փաստաթղթի ընթացիկ վիճակը, որը կարող է նաև տվյալների պահոցում գրանցված չլինել։

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

Վերադարձնում է փաստաթուղթի գրանցվելու [աղբյուրը](../services/DocumentOrigin.md):


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

??

### Snapshots

```c#
public Dictionary<string, DocumentSnapshot> Snapshots { get; internal set; } = new(StringComparer.InvariantCultureIgnoreCase);
```

Վերադարձնում է փաստաթղթի DocumentSnapshot տիպի քեշավորված պատկերների բազմությունը։

### State

```c#
public int ISN { get; internal set; }
```

Վերադարձնում է փաստաթղթի վիճակը:

### StoreMode

```c#
public StoreMode StoreMode { get; internal set; }
```

Վերադարձնում է տվյալների պահոցում փաստաթղթի գրանցման ռեժիմը գրանցման իրադարձությունների ընթացքում։

StoreMode-ի արժեքների բազմություն
- StoreMode.Draft - Փաստաթուղթը պահվում է 0 վիճակով։
- StoreMode.StartProcessing - Փաստաթուղթը պահվում է և սկսվում է անցումը 0-ից 1:
- StoreMode.ContinueProcessing - Փաստաթուղթը պահվում է և շարունակվում գործընթացը։
- StoreMode.SecondInput - Փաստաթղթի կրկնակի մուտքագրում։
- StoreMode.NotConfirmed - Փաստաթուղթը մերժվել է։
- StoreMode.Confirmed - Փաստաթուղթը վավերացվում է։
- StoreMode.Import - Փաստաթղթի ներմուծում։

### StoredFacts

```c#
public List<Fact> StoredFacts { get; internal set; }
```

Վերադարձնում է փաստաթղթի ժամանակավոր պահված հաշվառումների գրառումների բազմությունը [DocumentService](../services/IDocumentService.md).[StoreFact](../services/IDocumentService.md#storefact) ֆունկցիյով ավելացնելուց հետո։

Այստեղ ժամանակավոր պահվում են, եթե [IDBService](../services/IDBService.md).[TransDeferred](../services/IDBService.md#transdeferred) հատկությունը `true` է։

### StoreSnapshot

```c#
public DocumentSnapshot StoreSnapshot { get; private set; }
```

[Snapshots](#snapshots)-ից վերադարձնում է `"StoreSnapshot"` բանակիով փաստաթղթի քեշավորված պատկերը։

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
public virtual Task Action(ActionEventArgs args)
```

Մեթոդը կանչվում է միջուկի կողմից UI-ից կամ [IDocumentService](../services/IDocumentService.md).[Store](../services/IDocumentService.md#store) ֆունկցիայով փաստաթուղթը տվյալների պահոցում գրանցելուց առաջ։

Փաստաթղթի գրանցման ժամանակ հավելյալ ստուգումներ կատարելու, լոգում, տվյալների բազայի աղյուսակներում փոխկապակցված գրանցումներ կատարելու, ինչ-որ պայմաններից կախված փաստաթղթի էլեմենտների (ռեկվիզիտ, մեմո, աղյուսակ) և հատկությունների արժեքները փոփոխելու համար անհրաժեշտ է override անել այս մեթոդը, որը հանդիսանում է 4x համակարգում նկարագրված  [Action](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/Action.html)  իրադարձության համարժեքը:

### AddParent

```c#
public Task AddParent(int isn)
```

Ավելացնում է տրված isn-ով փաստաթուղթը փաստաթղթի ծնող փաստաթղթերի ցուցակում։

### AfterCommit

```c#
public virtual Task AfterCommit(AfterCommitEventArgs args)
```

??

### AfterCreate

```c#
public virtual Task AfterCreate(AfterCreateEventArgs args)
```

Մեթոդը կանչվում է միջուկի կողմից [IDocumentService](../services/IDocumentService.md).[Create](../services/IDocumentService.md#create) ֆունկցիայով փաստաթղթի օբյեկտը ստեղծելուց հետո։

Հանդիսանում է 4x համակարգում նկարագրված  [AfterCreate](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/AfterCreate.html)  իրադարձության համարժեքը:

### AfterLoad

```c#
public virtual Task AfterLoad(AfterLoadEventArgs args)
```

Մեթոդը կանչվում է միջուկի կողմից [IDocumentService](../services/IDocumentService.md).[Load](../services/IDocumentService.md#load) ֆունկցիայով փաստաթուղթը տվյալների պահոցից բեռնելուց անմիջապես հետո։

Հանդիսանում է 4x համակարգում նկարագրված  [AfterLoad](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/AfterLoad.html)  իրադարձության համարժեքը:

### ApplySnapshot

```c#
public void ApplySnapshot(DocumentSnapshot snapshot)
```

???

### BeforeCommit

```c#
public virtual Task BeforeCommit(BeforeCommitEventArgs args)
```

Մեթոդը կանչվում է միջուկի կողմից UI-ից կամ [IDocumentService](../services/IDocumentService.md).[Store](../services/IDocumentService.md#store) ֆունկցիայով փաստաթուղթը տվյալների պահոցում գրանցելուց տրանզակցիան փակելուց առաջ։

Հանդիսանում է 4x համակարգում նկարագրված  [BeforeCommit](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/BeforeCommit.html)  իրադարձության համարժեքը:

### BeforeCopy

```c#
public virtual Task BeforeCopy(BeforeCopyEventArgs args)
```

Մեթոդը կանչվում է միջուկի կողմից UI-ից կամ [IDocumentService](../services/IDocumentService.md).[Copy](../services/IDocumentService.md#copy) ֆունկցիայով փաստաթղթի պատճեն օբյեկտը ստեղծելուց հետո։

Հանդիսանում է 4x համակարգում նկարագրված  [BeforeCopy](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/BeforeCopy.html)  իրադարձության համարժեքը:

### BeforeImportProcessing

```c#
public virtual Task BeforeImportProcessing(BeforeImportProcessingEventArgs args)
```

Մեթոդը կանչվում է միջուկի կողմից փաստաթղթերի ներմուծման ժամանակ փաստաթղթի օբյեկտի ստեղծելուց հետո։

Հանդիսանում է 4x համակարգում նկարագրված  [BeforeImport](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/BeforeImport.html)  իրադարձության համարժեքը:

### Body

```c#
public string Body()
```

Վերադարձնում է փաստաթղթի սերիալիզացված դաշտերի բազմությունը, ինչպես գրվում է ներմուծման ֆայլում կամ DOCS աղյուսակում։ 
Ներառված չեն փաստաթղթի աղյուսակները։

### BuildEmbeddedUIRequest

```c#
public void BuildEmbeddedUIRequest<T>(T uiRequestExecutionProgress) where T : IUIRequestExecutionProgress
```

???

### DefaultComment

```c#
public virtual Task DefaultComment(DefaultCommentEventArgs args)
```

Մեթոդը կանչվում է միջուկի կողմից փաստաթղթի թղթապանակի տարր ստեղծելուց մեկնաբանություն լրացնելու համար։

Հանդիսանում է 4x համակարգում նկարագրված  [DefaultComment](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/DefaultComment.html)  իրադարձության համարժեքը:

### Delete

```c#
public virtual Task Delete(DeleteEventArgs args)
```

Մեթոդը կանչվում է միջուկի կողմից UI-ից կամ [IDocumentService](../services/IDocumentService.md).[Delete](../services/IDocumentService.md#delete) ֆունկցիայով փաստաթղթի ջնջելուց առաջ։

Հանդիսանում է 4x համակարգում նկարագրված  [Delete](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/Delete.html)  իրադարձության համարժեքը:

### DeserializeComplexObjects

```c#
public virtual Task DeserializeComplexObjects(DeserializeComplexObjectsEventArgs args)
```

???

### ExistsGrid

```c#
public bool ExistsGrid(string grid)
```

Ստուգում է տրված ներքին անունով աղյուսակի առկայությունը փաստաթղթի նկարագրության մեջ։

### ExistsRekvizit

```c#
public bool ExistsRekvizit(string rekv)
```

Ստուգում է տրված ներքին անունով դաշտի առկայությունը փաստաթղթի նկարագրության մեջ։

### Folders

```c#
public virtual Task Folders(FoldersEventArgs args)
```

Մեթոդը կանչվում է միջուկի կողմից UI-ից կամ [IDocumentService](../services/IDocumentService.md).[Store](../services/IDocumentService.md#store) ֆունկցիայով փաստաթուղթը տվյալների պահոցում գրանցելուց առաջ։
Կանչվում է նաև փաստաթղթերի ինդեքսավորման ժամանակ։

Հանդիսանում է 4x համակարգում նկարագրված  [Folders](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/Folders.html)  իրադարձության համարժեքը:

### GetCheckValue

```c#
public bool GetCheckValue(string fieldName)
```

Վերադարձնում է փաստաթղթի նշված ներքին անունով դաշտի ստուգման հայտանիշը: 
false արժեքի դեպքում դաշտի լրացման կամ ցուցադրման ժամանակ չի ստուգվում արժեքի առկայությունը ծառում կամ թղթապանակում։ 
true արժեքի դեպքում դաշտի արժեքը պետք է գոյություն ունենա դաշտի համակարգային տիպում նկարագրված ծառում կամ թղթապանակում։

### GetFieldType

```c#
public FieldType GetFieldType(string fieldName)
```

Վերադարձնում է փաստաթղթի տրված ներքին անունով ռեկվիզիտի [համակարգային տիպը](../../system_types.md)։

### GetImage

```c#
public byte[] GetImage(string name)
```

Վերադարձնում է փաստաթղթի տրված ներքին անունով նկար դաշտը՝ որպես byte զանգված։

### GetMemo

```c#
public string GetMemo(string name)
```

Վերադարձնում է փաստաթղթի տրված ներքին անունով մեծ տեքստային դաշտի (մեմոյի) արժեքը։

### GetNextTrans

```c#
public int GetNextTrans()
```

Վերադարձնում է փաստաթղթի տրանզակցիայի հերթական նոր համարը։

Մի քանի գրանցվող հաշվառում խմբավորելու համար օգտագործվում է Trans հատկությունը, որին տրվում է մեկ տրանզակցիայի համար։ 
Նոր համար ստացվում է GetNextTrans ֆունկցիայի միջոցով։ 

### GetParents

```c#
public Task<List<int>> GetParents()
```

Վերադարձնում է փաստաթղթի ծնող փաստաթղթերի isn-ների ցուցակը։ 

### Grid

```c#
public IGrid Grid(string name)
```

Վերադարձնում է փաստաթղթի տրված ներքին անունով աղյուսակը։
IGrid-ի տակից կարող է լինել չտիպիզացված աղյուսակ, կամ տիպիզացված աղյուսակ, եթե [CodeGen](../CodeGen/CodeGen.md) գործիքով ձևավորվել են տիպիզացված աղյուսակներ։

### InitGrids

```c#
protected void InitGrids()
```

Ձևավորում է փաստաթղթի աղյուսակները առանց տվյալների բեռնելու։ 

### DoLoadGrids

```c#
protected virtual Task DoLoadGrids(LoadGridsEventArgs args)
```

???

### LoadGrids

```c#
public Task LoadGrids(LoadGridsEventArgs args)
```

Բեռնում է փաստաթղթի աղյուսակները, եթե մինչ այդ բեռնված չէին [](../services/IDocumentService.md).[](../services/IDocumentService.md#load):

**Պարամետրեր**

* args -  LoadGridsEventArgs տիպի օբյեկտ, որը պարունակում է GridLoadMode enum տիպի օբյեկտ, որը կարող է ընդունել հետևյալ արժեքները՝
	* GridLoadMode.None - Ոչ մի աղյուսակ չի բեռնվում։
	* GridLoadMode.Full - Բեռնվում են բոլոր աղյուսակները։

### LoadImagesAndMemos

```c#
public Task LoadImagesAndMemos(ArchiveInfo archiveInfo = null)
```

???

### LoadParents

```c#
public Task LoadParents()
```

Բեռնում է փաստաթղթի ծնող փաստաթղթերի isn-ների ցուցակը տվյալների պահոցից, անկախ այն բանից մինչև այդ բեռնված էին թե ոչ։

### OnConfirmDocumentChangeRequest

```c#
public virtual Task OnConfirmDocumentChangeRequest(ConfirmDocumentChangeRequestEventArgs args)
```

???

### OnRefuse

```c#
public virtual Task OnRefuse(RefuseEventArgs args)
```

??

### OnRejectDocumentChangeRequest

```c#
public virtual Task OnRejectDocumentChangeRequest(RejectDocumentChangeRequestEventArgs args)
```

???

### PostMessage

```c#
public virtual Task PostMessage(PostMessageEventArgs args)
```

Մեթոդը կանչվում է միջուկի կողմից երբ կից փաստաթղթից այս փաստաթղթին ուղարկվում է ծրագրային հաղորդագրություն [SendMessage](#sendmessage) ֆունկցիայի միջոցով, դրանից հետո այս փաստաթուղթը գրանցվում տվյալների պահոցում։

Հանդիսանում է 4x համակարգում նկարագրված  [PostMessage](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/PostMessage.html)  իրադարձության համարժեքը:

### RefreshTimeStamp

```c#
public Task RefreshTimeStamp()
```

Հիշողության մեջ թարմացնում է փաստաթղթի վերջին գրանցման համարը՝ [TimeStamp](#timestamp), տվյալների պահոցից։

### SendMessage

```c#
public Task SendMessage(string message,
                        int isn = -1,
                        string messageForDocLog = "",
                        bool raiseErrorIfDocNotExists = true,
                        bool raiseErrorIfParentNotExists = true)
```

Ուղարկում է հաղորդագրություն այլ փաստաթղթի (կամ ծնող փաստաթղթին) աշխատացնելով [PostMessage](#postmessage)  ֆունկցիան:  
Հաղորդագրություն ստանալուց հետո ստացող փաստաթղթի  [պատմության](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/DocLog.html)  մեջ  [գրանցվում է](#writelog)  հաղորդագրության տեքստը և ստացող փաստաթուղթը գրանցվում է տվյալների պահոցում [StoreMode](#storemode) հատկությանը տալով `ContinueProcessing` արժեքը։

**Պարամետրեր**
- message - Ուղարկվող հաղորդագրության տեքստը։
- isn - Հաղորդագրությունը ստացող փաստաթղթի ներքին նույնականացման համարը։ 
  Եթե պարամետրը փոխանցված չէ, ապա հաղորդագրությունը կուղարկվի ընթացիկ փաստաթղթի ծնողին, եթե այն առկա է։
- messageForDocLog - Ստացող փաստաթղթի պատմության մեջ գրանցվող տեքստը։ 
  Եթե պարամետրը փոխանցված չէ, ապա պատմության մեջ կգրանցվի `message` պարամետրի արժեքը։
- raiseErrorIfDocNotExists - Ստացող փաստաթղթի բացակայության դեպքում սխալի գեներացում։ 
  Լռությամբ արժեքը true է։
- raiseErrorIfParentNotExists - Ստացող ծնող փաստաթղթի բացակայության դեպքում սխալի գեներացում։ 
  Լռությամբ արժեքը true է։

### SerializeComplexObjects

```c#
public virtual Task SerializeComplexObjects(SerializeComplexObjectsEventArgs args)
```

???

### SetCheckValue

```c#
public void SetCheckValue(string fieldName, bool value)
```

Նշանակում է փաստաթղթի նշված ներքին անունով դաշտի ստուգման հայտանիշը:

**Պարամետրեր**

- fieldName - Ռեկվիզիտի ներքին անուն։
- value - Սահմանում է դաշտի համակարգային տիպում նկարագրված ծառում կամ թղթապանակում դաշտի արժեքի առկայությունը։

### SetDefaultValuesForFields

```c#
public void SetDefaultValuesForFields(IList<string> fields)
```

Վերագրում է լռությամբ արժեքներ փաստաթղթի տրված դաշտերին։

### SetDefaultValuesForFields

```c#
public void SetDefaultValuesForFields(params string[] fields)
```

Վերագրում է լռությամբ արժեքներ փաստաթղթի տրված դաշտերին։

### SetImage

```c#
public void SetImage(string name, byte[] value)
```

Արժեքավորում է փաստաթղթի տրված ներքին անունով նկար դաշտը։

**Պարամետրեր**

* name - նկարի ներքին անունը,
* value - արժեքը։

### SetMemo

```c#
public void SetMemo(string name, string value)
```

Արժեքավորում է փաստաթղթի տրված ներքին անունով մեծ տեքստային դաշտը (մեմո)։

**Պարամետրեր**

* name - մեմոյի ներքին անունը,
* value - արժեքը։

### Store

```c#
public Task Store(DocumentCheckLevel checkLevel = DocumentCheckLevel.None, string logComment = "")
```

Կատարում է պարտադիր ստուգումներ և գրանցում փաստաթուղթը տվյալների պահոցում։

**Պարամետրեր**

* checkLevel - Փաստաթղթի գրանցման եղանակ՝ որոշում են թե ինչ ստանդարտ ստուգումներ կարող են չաշխատել, ինչ ստանդարտ մշակիչներ (VALIDATE, ACTION...) չաշխատեն, և ինչ լրացուցիչ մշակիչներ աշխատեն։
* logComment - Փաստաթղթի պատմության մեջ գրվող տեքստը։

### StoreGrids

```c#
public virtual Task StoreGrids(StoreGridsEventArgs args)
```

Մեթոդը կանչվում է միջուկի կողմից փաստաթուղթը տվյալների պահոցում գրանցելուց։

Մեթոդի գերբեռնումը նախատեսված է փաստաթղթի ցանկալի աղյուսակները DOCSG աղյուսակի մեջ չպահպանելու և աղյուսակներ այլ տեղերում պահպանելու համար։
Այլ տեղում պահպանված աղյուսակները հարկավոր է ավելացնել `args.IgnoreGrids` ցուցակում։

```c#
args.IgnoreGrids.AddRange([Grid("CLIENTS"), Grid("STMDATES")]);
```

Մշակման դեպքում ծրագրավորողը պետք է ապահովի աղյուսակի ճիշտ բեռնումը մշակելով [LoadGrid](#doloadgrids) մեթոդը։

Հանդիսանում է 4x համակարգում նկարագրված  [StoreGrid](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/StoreGrid.html)  իրադարձության համարժեքը:

### StoreValuesHistory

```c#
public Task StoreValuesHistory()
```

Փաստաթղթի ռեկվիզիտների արժեքները գրանցում է տվյալների պահոցի LASTVALUESGROUP աղյուսակում։
Հետագայում UI-ում նախկին օգտագործված արժեքներ առաջարկելու համար։

### TakeSnapshot

```c#
public Task TakeSnapshot(SnapshotContent content, string name, bool overwrite = true)
```

Քեշավորում և պահպանում է փաստաթղթի պատկերը [Snapshots](#snapshots)-ում։

**Պարամետրեր**

* content - սահմանում է փաստաթղթի քեշավորվող կտորները, որը կարող է ընդունել հետևյալ արժեքները՝
	* SnapshotContent.None - ոչինչ չի քեշավորվում,
	* SnapshotContent.Requisites - քեշավորվում են միայն ռեկվիզիտները,
	* SnapshotContent.Grids - քեշավորվում են միայն աղյուսակները,
	* SnapshotContent.All - քեշավորվում են ռեկվիզիտները և աղյուսակները,
* name - ստեղծվող քեշավորման օբյեկտի ներքին անուն, որը հանդիսանալու է բանալի [Snapshots](#snapshots)-ում,
* overwrite - բանալիի կրկնության դեպքում վերարտագրման հայտանիշ։

### TemplateSubstitution

```c#
public virtual Task<TemplateSubstitution> TemplateSubstitution(Dictionary<string, bool> mode, Dictionary<string, object> parameters = null)
```

Մեթոդը կանչվում է միջուկի կողմից, երբ փաստաթղթի համար ձևավորվում է տպման ձև, երբ անջատված է [TemplateSubstitutionIsExtended](#templatesubstitutionisextended) հատկությունը։ 

Հանդիսանում է 4x համակարգում նկարագրված  [TemplateSubstitution](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/TemplateSubstitution.html)  իրադարձության համարժեքը:

### TemplateSubstitutionEx

```c#
public virtual Task<TemplateSubstitutionEx> TemplateSubstitutionEx(Dictionary<string, bool> mode, Dictionary<string, object> parameters = null)
```

Մեթոդը կանչվում է միջուկի կողմից, երբ փաստաթղթի համար ձևավորվում է տպման ձև, երբ միացված է [TemplateSubstitutionIsExtended](#templatesubstitutionisextended) հատկությունը։ 

Հանդիսանում է 4x համակարգում նկարագրված  [TemplateSubstitution](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/TemplateSubstitution.html)  իրադարձության համարժեքը:

### Validate

```c#
public virtual Task Validate(ValidateEventArgs args)
```

Մեթոդը կանչվում է միջուկի կողմից UI-ից կամ [IDocumentService](../services/IDocumentService.md).[Store](../services/IDocumentService.md#store) ֆունկցիայով փաստաթուղթը տվյալների պահոցում գրանցելուց առաջ։

Օգտագործվում է փաստաթղթի դաշտերի արժեքների ստուգման համար։

Հանդիսանում է 4x համակարգում նկարագրված  [Validate](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/Validate.html)  իրադարձության համարժեքը:

### WriteLog

```c#
public Task WriteLog(string message, int dcrId = -1, bool dcrIdIsISN = false)
```

Ավելացնում է նոր գրառում փաստաթղթի պատմության մեջ։

Փաստաթղթի կյանքի ընթացքում մի շարք գործողություններ գրանցվում են պատմության մեջ ավտոմատ կերպով, ինչպիսին է փաստաթղթի ստեղծումը կամ խմբագրումը։ 
Այս մեթոդի միջոցով հնարավոր է ավելացնել լրացուցիչ տողեր։ 
Այս ֆունկցիայով տող ավելացնելուց DOCLOG աղյուսակում ավելանում է գրառում `"M"` կոդով։

Եթե այս մեթոդը կանչում ենք [Action](#action) մեթոդի մեջ, ապա գրանցումները տվյալների պահոցում կատարվում են մեթոդի ավարտից հետո, իսկ այլ դեպքերում գրանցումը կատարվում է անմիջապես։

**Պարամետրեր**

* sMsg - Փաստաթղթի պատմությունում ավելացվող հաղորդագրություն։
* dcrId - Փոփոխման հայտի համարը (DocChangeRequest) կամ հիմքային փաստաթղթի ներքին նույնականացման համար։
* dcrIdIsISN - `false` արժեքը ցույց է տալիս, որ `dcrId`-ը փոփոխման հայտի համար է, `true` արժեքը՝ հիմքային փաստաթղթի ներքին նույնականացման համար։
