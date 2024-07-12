---
layout: page
title: "Փաստաթղթի նկարագրություն" 
tags: [Doc, Document]
---

## Բովանդակություն

- [Հատկություններ](#հատկություններ)
	- [ISN](#isn)
	- [State](#state)
	- [TimeStamp](#timestamp)
	- [CreatorSUID](#creatorsuid)
	- [Archived](#archived )
	- [CreationDate](#creationdate )
	- [Description](#description )
	- [Grids](#grids)
	- [GridsLoading ](#gridsloading)
	- [GridsInitialized](#gridsinitialized)
	- [GridsLoaded](#gridsloaded)
	- [IsNew](#isnew)
	- [ExistsInDB](#existsindb)
	- [Snapshots](#snapshots)
	- [StoreMode](#storemode)
	- [Deleting](#deleting)
	- [LogTransactions](#logtransactions)
	- [CopiedFrom](#copiedfrom)
	- [IsLogged](#islogged)
	- [LastFixedState](#lastfixedstate)
	- [DocumentChangeRequest](#documentchangerequest)
	- [Properties](#properties)
	- [StoredFacts](#storedfacts)
	- [DocumentLog](#documentlog)
	- [NestedTransactionReport](#nestedtransactionreport)
	- [Progress](#progress )
	- [CancellationToken](#cancellationtoken)
	- [IsUIOrigin](#isuiorigin)
	- [ShowProgress](#showprogress)
	- [IsCancellationSupported](#iscancellationsupported)
	- [TemplateSubstitutionIsExtended](#templatesubstitutionisextended)
	- [Origin](#origin)
	- [InitialSnapshot](#initialsnapshot)
	- [StoreSnapshot](#storesnapshot)
- [Մեթոդներ](#մեթոդներ)
	- [InitGrids](#initgrids)
	- [ExistsRekvizit](#existsrekvizit)
	- [GetFieldType](#getfieldtype)
	- [TemplateSubstitution](#templatesubstitution)
	- [TemplateSubstitutionEx](#templatesubstitutionex)
	- [ApplySnapshot](#applysnapshot)
	- [TakeSnapshot](#takesnapshot)
	- [DoLoadGrids](#doloadgrids)
	- [LoadGrids](#loadgrids)
	- [LoadImagesAndMemos](#loadimagesandmemos)
	- [GetMemo](#getmemo)
	- [SetMemo](#setmemo)
	- [GetImage](#getimage)
	- [SetImage](#setimage)
	- [ExistsGrid](#existsgrid)
	- [Grid](#grid)
	- [StoreValuesHistory](#storevalueshistory)
	- [LoadParents](#loadparents)
	- [AddParent](#addparent)
	- [GetParents](#getparents)
	- [GetNextTrans](#getnexttrans)
	- [Body](#body)
	- [WriteLog](#writelog)
	- [SendMessage](#sendmessage)
	- [Store](#store)
	- [BuildEmbeddedUIRequest](#buildembeddeduirequest)
	- [RefreshTimeStamp](#refreshtimestamp)
	- [GetCheckValue](#getcheckvalue)
	- [SetCheckValue](#setcheckvalue)
	- [SetDefaultValuesForFields](#setdefaultvaluesforfields)
	- [OnConfirmDocumentChangeRequest](#onconfirmdocumentchangerequest)
	- [OnRejectDocumentChangeRequest](#onrejectdocumentchangerequest)
	- [StoreGrids](#storegrids)
	- [DefaultComment](#defaultcomment)
	- [Folders](#folders)
	- [Validate](#validate)
	- [Action](#action)
	- [BeforeCommit](#beforecommit)
	- [AfterCommit](#aftercommit)
	- [PostMessage](#postmessage)
	- [AfterLoad](#afterload)
	- [AfterCreate](#aftercreate)
	- [Delete](#delete)
	- [OnRefuse](#onrefuse)
	- [SerializeComplexObjects](#serializecomplexobjects)
	- [DeserializeComplexObjects](#deserializecomplexobjects)
	- [BeforeCopy](#beforecopy)
	- [BeforeImportProcessing](#beforeimportprocessing)

## Հատկություններ

### ISN

```c#
public int ISN { get; internal set; }
```

Վերադարձնում է փաստաթղթի isn-ը:

### State

```c#
public int ISN { get; internal set; }
```

Վերադարձնում է փաստաթղթի վիճակը:

### TimeStamp

```c#
public byte[] TimeStamp { get; internal set; }
```

Վերադարձնում է փաստաթղթի վերջին փոփոխման ամսաթիվը և ժամանակը` որպես byte տիպի զանգված:

### CreatorSUID

```c#
public short CreatorSUID { get; internal set; }
```

Վերադարձնում է փաստաթուղթը ստեղծողի user id-ն:

### Archived 

```c#
public bool Archived { get; internal set; }
```

Ցույց է տալիս փաստաթուղթը արխիվացված է թե ոչ։

### CreationDate 

```c#
public DateTime CreationDate { get; internal set; }
```

Վերադարձնում է փաստաթղթի ստեղծման ամսաթիվը։

### Description 

```c#
public DocumentDescription Description { get; internal set; }
```

Վերադարձնում է փաստաթղթի նկարագրությունը։

### Grids

```c#
public IReadOnlyDictionary<string, IGrid> Grids { get; private set; }
```

Վերադարձնում է փաստաթղթի գրիդերի ցուցակը dictionary-ով՝ որտեղ key-ն գրիդի ներքին անունն է, իսկ value-ն IGrid տիպի class, որը պարունակում է գրիդի ամբողջ ինֆորմացիան։

### GridsLoading 

```c#
public bool GridsLoading { get; internal set; } = false;
```

Ցույց է տալիս փաստաթղթի գրիդները գտնվում են բեռնման պրոցեսում թե ոչ։

### GridsInitialized

```c#
public bool GridsInitialized { get; protected internal set; }
```

Ցույց է տալիս փաստաթղթի գրիդները բեռնվել և արժեքավորվել են թե ոչ։

### GridsLoaded

```c#
public bool GridsLoaded { get; protected internal set; }
```

Ցույց է տալիս փաստաթղթի գրիդները բեռնվել են թե ոչ։

### IsNew 

```c#
public bool IsNew { get; internal set; }
```

Ցույց է տալիս թե փաստաթուղթը նոր է թե ոչ։

### ExistsInDB

```c#
public bool ExistsInDB { get; internal set; }
```

Ստուգում է փաստաթղթի առկայությունը տվյալների բազայում։

### Snapshots

```c#
public Dictionary<string, DocumentSnapshot> Snapshots { get; internal set; } = new(StringComparer.InvariantCultureIgnoreCase);
```

??

### StoreMode

```c#
public StoreMode StoreMode { get; internal set; }
```

Վերադարձնում է տվյալների պահոցում փաստաթղթի գրանցման ռեժիմը։

### Deleting

```c#
public bool Deleting { get; internal set; }
```

Ցույց է տալիս փաստաթղթի գրիդները գտնվում են հեռացման պրոցեսում թե ոչ։

### LogTransactions

```c#
public bool LogTransactions { get; set; }
``` 

??

### CopiedFrom

```c#
public int CopiedFrom { get; internal set; } = -1;
```

Վերադարձնում է այն փաստաթղթի isn-ը, որից պատճենվել է տվյալ փաստաթուղթը։

### IsLogged

```c#
public bool IsLogged { get; set; }
```

??

### LastFixedState

```c#
public short LastFixedState { get; internal set; }
```

??

### DocumentChangeRequest

```c#
public DocumentChangeRequest DocumentChangeRequest { get; internal set; }
```

Վերադարձնում է փաստաթղթի փոփոխման հայտը։

### Properties

```c#
public Dictionary<string, object> Properties { get; set; }
```

Վերադարձնում կամ արժեքավորում է ??

### StoredFacts

```c#
public List<Fact> StoredFacts { get; internal set; }
```

Վերադարձնում է փաստաթղթի հաշվառումների ցուցակը։

### DocumentLog

```c#
public DocumentLog DocumentLog { get; internal set; } = new DocumentLog();
```

??

### NestedTransactionReport 

```c#
public StorageInfo NestedTransactionReport { get; internal set; }
```

??

### Progress 

```c#
public DocumentExecutionProgress Progress { get; private set; }
```

Վերադարձնում է փաստաթղթի կատարման պրոգրեսը։

### CancellationToken

```c#
public CancellationToken CancellationToken { get; internal set; }
```

Վերադարձնում է փաստաթղթի չեղարկման տոկենը։

### IsUIOrigin

```c#
public bool IsUIOrigin
```

Ցույց է տալիս փաստաթղթի կանչի տեսակը՝ UI-ից է, թե ոչ։

### ShowProgress

```c#
public virtual bool ShowProgress { get { return false; } }
```

??

### IsCancellationSupported

```c#
public virtual bool IsCancellationSupported { get { return true; } }
```

Ցույց է տալիս թե փաստաթղթի կատարումը սատարում է չեղարկումը(cancellation) թե ոչ։

### TemplateSubstitutionIsExtended

```c#
public virtual bool TemplateSubstitutionIsExtended { get; }
```

??

### Origin

```c#
public DocumentOrigin Origin
```

Վերադարձնում է թե որտեղից (Ինտերֆեյսից՝ 4X, 8X, կոդից` 4X, 8X) են փորձում հիշել փաստաթուղթը:

### InitialSnapshot

```c#
public DocumentSnapshot InitialSnapshot { get; private set; }
```

Snapshots dictionary-ից վերադարձնում է InitialSnapshot key-ին համապատասխան փաստաթղթի քեշավորված նկարագրությունը։

### StoreSnapshot

```c#
public DocumentSnapshot StoreSnapshot { get; private set; }
```

Snapshots dictionary-ից վերադարձնում է StoreSnapshot key-ին համապատասխան փաստաթղթի քեշավորված նկարագրությունը։

## Մեթոդներ

### InitGrids

```c#
protected void InitGrids()
```

Արժեքավորում է փաստաթղթի բոլոր գրիդերը։

### ExistsRekvizit

```c#
public bool ExistsRekvizit(string rekv)
```

Ստուգում է փաստաթղթում տրված ներքին անունով ռեկվիզիտի առկայությունը։

### GetFieldType

```c#
public FieldType GetFieldType(string fieldName)
```

Վերադարձնում է փաստաթղթի տրված ներքին անունով ռեկվիզիտի համակարգային տիպը։

### TemplateSubstitution

```c#
public virtual Task<TemplateSubstitution> TemplateSubstitution(Dictionary<string, bool> mode, Dictionary<string, object> parameters = null)
```

???

### TemplateSubstitutionEx

```c#
public virtual Task<TemplateSubstitutionEx> TemplateSubstitutionEx(Dictionary<string, bool> mode, Dictionary<string, object> parameters = null)
```

???

### ApplySnapshot

```c#
public void ApplySnapshot(DocumentSnapshot snapshot)
```

???

### TakeSnapshot

```c#
public Task TakeSnapshot(SnapshotContent content, string name, bool overwrite = true)
```

Քեշավորում է փաստաթղթի նկարագրությունը և ավելացնում [Snapshots](#snapshots) dictionary-ում։

**Պարամետրեր**

* content - սահմանում է փաստաթղթի քեշավորվող կտորները, որը կարող է ընդունել հետևյալ արժեքները՝
	* SnapshotContent.None - ոչինչ չի քեշավորվում,
	* SnapshotContent.Requisites - քեշավորվում են միայն ռեկվիզիտները,
	* SnapshotContent.Grids - քեշավորվում են միայն գրիդերը,
	* SnapshotContent.All - քեշավորվում են ռեկվիզիտները և գրիդերը,
* name - ստեղծվող քեշավորման օբյեկտի ներքին անուն, որը հանդիսանալու է key Snapshots dictionary-ում,
* overwrite - հնարավոր է հետագայում վերագրանցել քեշավորված նկարագրությունը թե ոչ։

### DoLoadGrids

```c#
protected virtual async Task DoLoadGrids(LoadGridsEventArgs args)
```

???

### LoadGrids

```c#
public async Task LoadGrids(LoadGridsEventArgs args)
```

Բեռնում է փաստաթղթի գրիդները:

**Պարամետրեր**

* args -  LoadGridsEventArgs տիպի օբյեկտ, որը պարունակում է GridLoadMode enum տիպի օբյեկտ, որը կարող է ընդունել հետևյալ արժեքները՝
	* GridLoadMode.None - ոչ մի գրիդ չի բեռնվում,
	* GridLoadMode.Full - բեռնվում են բոլոր գրիդները,

### LoadImagesAndMemos

```c#
public async Task LoadImagesAndMemos(ArchiveInfo archiveInfo = null)
```

???

### GetMemo

```c#
public string GetMemo(string name)
```

Վերադարձնում է փաստաթղթի տրված ներքին անունով մեմոյի արժեքը։

### SetMemo

```c#
public void SetMemo(string name, string value)
```

Արժեքավորում է փաստաթղթի մեմոն։

**Պարամետրեր**

* name - մեմոյի ներքին անունը,
* value - արժեքը։

### GetImage

```c#
public byte[] GetImage(string name)
```

Վերադարձնում է փաստաթղթի տրված ներքին անունով նկարը՝ որպես byte տիպի զանգված։

### SetImage

```c#
public void SetImage(string name, byte[] value)
```

Արժեքավորում է փաստաթղթի նկարը։

**Պարամետրեր**

* name - նկարի ներքին անունը,
* value - արժեքը։

### ExistsGrid

```c#
public bool ExistsGrid(string grid)
```

Ստուգում է փաստաթղթում տրված ներքին անունով գրիդի առկայությունը։

### Grid

```c#
public IGrid Grid(string name)
```

Վերադարձնում է փաստաթղթի տրված ներքին անունով գրիդը։

### StoreValuesHistory

```c#
public async Task StoreValuesHistory()
```

???

### LoadParents

```c#
public async Task LoadParents()
```

Բեռնում է փաստաթղթի ծնող փաստաթղթերի isn-ների ցուցակը։

### AddParent

```c#
public async Task AddParent(int isn)
```

Ավելացնում է տրված isn-ով փաստաթուղթը փաստաթղթի ծնող փաստաթղթերի ցուցակում։

### GetParents

```c#
public async Task<List<int>> GetParents()
```

Վերադարձնում է փաստաթղթի ծնող փաստաթղթերի isn-ների ցուցակը։ 

### GetNextTrans

```c#
public int GetNextTrans()
```

???

### Body

```c#
public string Body()
```

???

### WriteLog

```c#
public async Task WriteLog(string message, int dcrId = -1, bool dcrIdIsISN = false)
```

???

### SendMessage

```c#
public async Task SendMessage(string message,
                              int isn = -1,
                              string messageForDocLog = "",
                              bool raiseErrorIfDocNotExists = true,
                              bool raiseErrorIfParentNotExists = true)
```

???

### Store

```c#
public Task Store(DocumentCheckLevel checkLevel = DocumentCheckLevel.None, string logComment = "")
```

Գրանցում է փաստաթուղթը տվյալների պահոցում։

**Պարամետրեր**

* checkLevel  - փաստաթղթի ստուգման մակարդակը,
* logComment - լոգավորման համար անհրաժեշտ մեկնաբանությունը։

### BuildEmbeddedUIRequest

```c#
public void BuildEmbeddedUIRequest<T>(T uiRequestExecutionProgress) where T : IUIRequestExecutionProgress
```

???

### RefreshTimeStamp

```c#
public async Task RefreshTimeStamp()
```

???

### GetCheckValue

```c#
public bool GetCheckValue(string fieldName)
```

???

### SetCheckValue

```c#
public void SetCheckValue(string fieldName, bool value)
```

???

### SetDefaultValuesForFields

```c#
public void SetDefaultValuesForFields(IList<string> fields)
```

Վերագրում է default արժեքներ փաստաթղթի տրված դաշտերին։

### SetDefaultValuesForFields

```c#
public void SetDefaultValuesForFields(params string[] fields)
```

Վերագրում է default արժեքներ փաստաթղթի տրված դաշտերին։

### OnConfirmDocumentChangeRequest

```c#
public virtual Task OnConfirmDocumentChangeRequest(ConfirmDocumentChangeRequestEventArgs args)
```

???

### OnRejectDocumentChangeRequest

```c#
public virtual Task OnRejectDocumentChangeRequest(RejectDocumentChangeRequestEventArgs args)
```

???

### StoreGrids

```c#
public virtual Task StoreGrids(StoreGridsEventArgs args)
```

Հանդիսանում է 4x համակարգում նկարագրված  [StoreGrid](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/StoreGrid.html)  իրադարձության համարժեքը:

### DefaultComment

```c#
public virtual Task DefaultComment(DefaultCommentEventArgs args)
```

Հանդիսանում է 4x համակարգում նկարագրված  [DefaultComment](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/DefaultComment.html)  իրադարձության համարժեքը:

### Folders

```c#
public virtual Task Folders(FoldersEventArgs args)
```

Հանդիսանում է 4x համակարգում նկարագրված  [Folders](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/Folders.html)  իրադարձության համարժեքը:

### Validate

```c#
public virtual Task Validate(ValidateEventArgs args)
```

Հանդիսանում է 4x համակարգում նկարագրված  [Validate](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/Validate.html)  իրադարձության համարժեքը:

### Action

```c#
public virtual Task Action(ActionEventArgs args)
```

Փաստաթղթի գրանցման ժամանակ հավելյալ ստուգումներ կատարելու, լոգում, տվյալների բազայի աղյուսակներում փոխկապակցված գրանցումներ կատարելու, ինչ-որ պայմաններից կախված փաստաթղթի էլեմենտների(ռեկվիզիտ, մեմո, աղյուսակ) և հատկությունների արժեքները փոփոխելու համար անհրաժեշտ է override անել այս մեթոդը, որը հանդիսանում է 4x համակարգում նկարագրված  [Action](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/Action.html)  իրադարձության համարժեքը:

### BeforeCommit

```c#
public virtual Task BeforeCommit(BeforeCommitEventArgs args)
```

Հանդիսանում է 4x համակարգում նկարագրված  [BeforeCommit](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/BeforeCommit.html)  իրադարձության համարժեքը:

### AfterCommit

```c#
public virtual Task AfterCommit(AfterCommitEventArgs args)
```

??

### PostMessage

```c#
public virtual Task PostMessage(PostMessageEventArgs args)
```

Հանդիսանում է 4x համակարգում նկարագրված  [PostMessage](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/PostMessage.html)  իրադարձության համարժեքը:

### AfterLoad

```c#
public virtual Task AfterLoad(AfterLoadEventArgs args)
```

Հանդիսանում է 4x համակարգում նկարագրված  [AfterLoad](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/AfterLoad.html)  իրադարձության համարժեքը:

### AfterCreate

```c#
public virtual Task AfterCreate(AfterCreateEventArgs args)
```

Հանդիսանում է 4x համակարգում նկարագրված  [AfterCreate](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/AfterCreate.html)  իրադարձության համարժեքը:

### Delete

```c#
public virtual Task Delete(DeleteEventArgs args)
```

Հանդիսանում է 4x համակարգում նկարագրված  [Delete](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/Delete.html)  իրադարձության համարժեքը:

### OnRefuse

```c#
public virtual Task OnRefuse(RefuseEventArgs args)
```

??

### SerializeComplexObjects

```c#
public virtual Task SerializeComplexObjects(SerializeComplexObjectsEventArgs args)
```

???

### DeserializeComplexObjects

```c#
public virtual Task DeserializeComplexObjects(DeserializeComplexObjectsEventArgs args)
```

???

### BeforeCopy

```c#
public virtual Task BeforeCopy(BeforeCopyEventArgs args)
```

Հանդիսանում է 4x համակարգում նկարագրված  [BeforeCopy](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/BeforeCopy.html)  իրադարձության համարժեքը:

### BeforeImportProcessing

```c#
public virtual Task BeforeImportProcessing(BeforeImportProcessingEventArgs args)
```

Հանդիսանում է 4x համակարգում նկարագրված  [BeforeImport](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/BeforeImport.html)  իրադարձության համարժեքը:
