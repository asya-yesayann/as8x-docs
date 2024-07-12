---
layout: page
title: "Փաստաթղթի նկարագրություն" 
tags: [Doc, Document]
---

```c#
public class Document
```

## Բովանդակություն

-   [Հատկություններ](#հատկություններ)
    -   [Archived](#archived)
    -   [CancellationToken](#cancellationtoken)
    -   [CopiedFrom](#copiedfrom)
    -   [CreatorSUID](#creatorsuid)
    -   [CreationDate](#creationdate)
    -   [Description](#description)
    -   [DocumentChangeRequest](#documentchangerequest)
    -   [DocumentLog](#documentlog)
    -   [Deleting](#deleting)
    -   [ExistsInDB](#existsindb)
    -   [Grids](#grids)
    -   [GridsInitialized](#gridsinitialized)
    -   [GridsLoaded](#gridsloaded)
    -   [GridsLoading](#gridsloading)
    -   [InitialSnapshot](#initialsnapshot)
    -   [ISN](#isn)
    -   [IsCancellationSupported](#iscancellationsupported)
    -   [IsLogged](#islogged)
    -   [IsNew](#isnew)
    -   [IsUIOrigin](#isuiorigin)
    -   [LastFixedState](#lastfixedstate)
    -   [LogTransactions](#logtransactions)
    -   [NestedTransactionReport](#nestedtransactionreport)
    -   [Origin](#origin)
    -   [Progress](#progress)
    -   [Properties](#properties)
    -   [ShowProgress](#showprogress)
    -   [Snapshots](#snapshots)
    -   [State](#state)
    -   [StoreMode](#storemode)
    -   [StoreSnapshot](#storesnapshot)
    -   [StoredFacts](#storedfacts)
    -   [TemplateSubstitutionIsExtended](#templatesubstitutionisextended)
    -   [TimeStamp](#timestamp)
-   [Մեթոդներ](#մեթոդներ)
    -   [Action](#action)
    -   [AddParent](#addparent)
    -   [AfterCommit](#aftercommit)
    -   [AfterCreate](#aftercreate)
    -   [AfterLoad](#afterload)
    -   [ApplySnapshot](#applysnapshot)
    -   [BeforeCommit](#beforecommit)
    -   [BeforeCopy](#beforecopy)
    -   [BeforeImportProcessing](#beforeimportprocessing)
    -   [Body](#body)
    -   [BuildEmbeddedUIRequest](#buildembeddeduirequest)
    -   [DefaultComment](#defaultcomment)
    -   [Delete](#delete)
    -   [DeserializeComplexObjects](#deserializecomplexobjects)
    -   [DoLoadGrids](#doloadgrids)
    -   [ExistsGrid](#existsgrid)
    -   [ExistsRekvizit](#existsrekvizit)
    -   [Folders](#folders)
    -   [GetCheckValue](#getcheckvalue)
    -   [GetFieldType](#getfieldtype)
    -   [GetImage](#getimage)
    -   [GetMemo](#getmemo)
    -   [GetNextTrans](#getnexttrans)
    -   [GetParents](#getparents)
    -   [Grid](#grid)
    -   [InitGrids](#initgrids)
    -   [LoadGrids](#loadgrids)
    -   [LoadImagesAndMemos](#loadimagesandmemos)
    -   [LoadParents](#loadparents)
    -   [OnConfirmDocumentChangeRequest](#onconfirmdocumentchangerequest)
    -   [OnRefuse](#onrefuse)
    -   [OnRejectDocumentChangeRequest](#onrejectdocumentchangerequest)
    -   [PostMessage](#postmessage)
    -   [RefreshTimeStamp](#refreshtimestamp)
    -   [SendMessage](#sendmessage)
    -   [SerializeComplexObjects](#serializecomplexobjects)
    -   [SetCheckValue](#setcheckvalue)
    -   [SetDefaultValuesForFields](#setdefaultvaluesforfields)
    -   [SetImage](#setimage)
    -   [SetMemo](#setmemo)
    -   [Store](#store)
    -   [StoreGrids](#storegrids)
    -   [StoreValuesHistory](#storevalueshistory)
    -   [TakeSnapshot](#takesnapshot)
    -   [TemplateSubstitution](#templatesubstitution)
    -   [TemplateSubstitutionEx](#templatesubstitutionex)
    -   [Validate](#validate)
    -   [WriteLog](#writelog)

## Հատկություններ

### Archived 

```c#
public bool Archived { get; internal set; }
```

Ստուգում է փաստաթղթի արխիվացված լինելը։

### CancellationToken

```c#
public CancellationToken CancellationToken { get; internal set; }
```

Վերադարձնում է փաստաթղթի չեղարկման տոկենը։

### CopiedFrom

```c#
public int CopiedFrom { get; internal set; } = -1;
```

Վերադարձնում է այն փաստաթղթի isn-ը, որից պատճենվել է տվյալ փաստաթուղթը։

### CreatorSUID

```c#
public short CreatorSUID { get; internal set; }
```

Վերադարձնում է փաստաթուղթը ստեղծողի ներքին համարը(user id):

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

### DocumentChangeRequest

```c#
public DocumentChangeRequest DocumentChangeRequest { get; internal set; }
```

Վերադարձնում է փաստաթղթի փոփոխման հայտը։

### DocumentLog

```c#
public DocumentLog DocumentLog { get; internal set; } = new DocumentLog();
```

??

### Deleting

```c#
public bool Deleting { get; internal set; }
```

Ցույց է տալիս փաստաթուղթը հեռացման ընթացքում է թե ոչ։

### ExistsInDB

```c#
public bool ExistsInDB { get; internal set; }
```

Ստուգում է փաստաթղթի առկայությունը տվյալների պահոցում։

### Grids

```c#
public IReadOnlyDictionary<string, IGrid> Grids { get; private set; }
```

Վերադարձնում է փաստաթղթի գրիդերի ցուցակը dictionary-ով՝ որտեղ key-ն գրիդի ներքին անունն է, իսկ value-ն IGrid տիպի class, որը պարունակում է գրիդի ամբողջ ինֆորմացիան։

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

### GridsLoading 

```c#
public bool GridsLoading { get; internal set; } = false;
```

Ցույց է տալիս փաստաթղթի գրիդները գտնվում են բեռնման պրոցեսում թե ոչ։

### InitialSnapshot

```c#
public DocumentSnapshot InitialSnapshot { get; private set; }
```

Snapshots dictionary-ից վերադարձնում է InitialSnapshot key-ին համապատասխան փաստաթղթի քեշավորված նկարագրությունը։

### ISN

```c#
public int ISN { get; internal set; }
```

Վերադարձնում է փաստաթղթի ներքին նույնականացման համարը(isn-ը):

### IsCancellationSupported

```c#
public virtual bool IsCancellationSupported { get { return true; } }
```

Ցույց է տալիս թե փաստաթղթի կատարումը սատարում է չեղարկումը(cancellation) թե ոչ։

### IsLogged

```c#
public bool IsLogged { get; set; }
```

??

### IsNew 

```c#
public bool IsNew { get; internal set; }
```

Վերադարձնում է փաստաթղթի նոր կամ սևագիր լինելու հայտանիշը։

### IsUIOrigin

```c#
public bool IsUIOrigin
```

Ցույց է տալիս փաստաթղթի կանչի տեսակը՝ UI-ից է, թե ոչ։

### LastFixedState

```c#
public short LastFixedState { get; internal set; }
```

Վերադարձնում է փասթաթղթի տվյալների պահոցում վերջին գրանցված վիճակը։

Ի տարբերություն  **LastFixedState**  հատկության ,  [State](#state)  հատկությունը վերադարձնում է փաստաթղթի ընթացիկ վիճակը, որը կարող է նաև տվյալների պահոցում գրանցված չլինել։

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
public DocumentOrigin Origin
```

Վերադարձնում է թե որտեղից (Ինտերֆեյսից՝ 4X, 8X, կոդից` 4X, 8X) են փորձում հիշել փաստաթուղթը:

### Progress 

```c#
public DocumentExecutionProgress Progress { get; private set; }
```

Վերադարձնում է փաստաթղթի կատարման պրոգրեսը։

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

Վերադարձնում է փաստաթղթի DocumentSnapshot տիպի քեշավորված նկարագրությունները։

### State

```c#
public int ISN { get; internal set; }
```

Վերադարձնում է փաստաթղթի վիճակը:

### StoreMode

```c#
public StoreMode StoreMode { get; internal set; }
```

Վերադարձնում է տվյալների պահոցում փաստաթղթի գրանցման ռեժիմը։

StoreMode-ի արժեքների բազմություն
- StoreMode.Draft - Փաստաթուղթը պահվում է 0 վիճակով։
- StoreMode.StartProcessing - Փաստաթուղթը պահվում է և սկսվում է անցումը 0-ից 1:
- StoreMode.ContinueProcessing - Փաստաթուղթը պահվում է և շարունակվում գործընթացը։
- StoreMode.SecondInput - Փաստաթղթի կրկնակի մուտքագրում։
- StoreMode.NotConfirmed - Փաստաթուղթը չի վավերացվում։
- StoreMode.Confirmed - Փաստաթուղթը վավերացվում է։
- StoreMode.Import - Փաստաթղթի ներմուծում։

### StoreSnapshot

```c#
public DocumentSnapshot StoreSnapshot { get; private set; }
```

Snapshots dictionary-ից վերադարձնում է StoreSnapshot key-ին համապատասխան փաստաթղթի քեշավորված նկարագրությունը։

### StoredFacts

```c#
public List<Fact> StoredFacts { get; internal set; }
```

Վերադարձնում է փաստաթղթի գրանցված հաշվառումների ցուցակը։

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

Փաստաթղթի գրանցման ժամանակ հավելյալ ստուգումներ կատարելու, լոգում, տվյալների բազայի աղյուսակներում փոխկապակցված գրանցումներ կատարելու, ինչ-որ պայմաններից կախված փաստաթղթի էլեմենտների(ռեկվիզիտ, մեմո, աղյուսակ) և հատկությունների արժեքները փոփոխելու համար անհրաժեշտ է override անել այս մեթոդը, որը հանդիսանում է 4x համակարգում նկարագրված  [Action](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/Action.html)  իրադարձության համարժեքը:

### AddParent

```c#
public async Task AddParent(int isn)
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

Հանդիսանում է 4x համակարգում նկարագրված  [AfterCreate](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/AfterCreate.html)  իրադարձության համարժեքը:

### AfterLoad

```c#
public virtual Task AfterLoad(AfterLoadEventArgs args)
```

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

Հանդիսանում է 4x համակարգում նկարագրված  [BeforeCommit](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/BeforeCommit.html)  իրադարձության համարժեքը:

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

### Body

```c#
public string Body()
```

Վերադարձնում է փաստաթղթի սերիալիզացված դաշտերի բազմությունը, ինչպես գրվում է ներմուծման ֆայլում կամ DOCS աղյուսակում։ Ներառված չեն փաստաթղթի աղյուսակները։

### BuildEmbeddedUIRequest

```c#
public void BuildEmbeddedUIRequest<T>(T uiRequestExecutionProgress) where T : IUIRequestExecutionProgress
```

???

### DefaultComment

```c#
public virtual Task DefaultComment(DefaultCommentEventArgs args)
```

Հանդիսանում է 4x համակարգում նկարագրված  [DefaultComment](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/DefaultComment.html)  իրադարձության համարժեքը:

### Delete

```c#
public virtual Task Delete(DeleteEventArgs args)
```

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

Ստուգում է տրված ներքին անունով գրիդի առկայությունը փաստաթղթի նկարագրության մեջ։

### ExistsRekvizit

```c#
public bool ExistsRekvizit(string rekv)
```

Ստուգում է փաստաթղթում տրված ներքին անունով ռեկվիզիտի առկայությունը։

### Folders

```c#
public virtual Task Folders(FoldersEventArgs args)
```

Հանդիսանում է 4x համակարգում նկարագրված  [Folders](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/Folders.html)  իրադարձության համարժեքը:

### GetCheckValue

```c#
public bool GetCheckValue(string fieldName)
```
Վերադարձնում է փաստաթղթի նշված ներքին անունով դաշտի ստուգման հայտանիշը: false արժեքի դեպքում դաշտի լրացման կամ ցուցադրման ժամանակ չի ստուգվում արժեքի առկայությունը ծառում կամ թղթապանակում։ true արժեքի դեպքում դաշտի արժեքը պետք է գոյություն ունենա դաշտի համակարգային տիպում նկարագրված ծառում կամ թղթապանակում։

### GetFieldType

```c#
public FieldType GetFieldType(string fieldName)
```

Վերադարձնում է փաստաթղթի տրված ներքին անունով ռեկվիզիտի համակարգային տիպը։

### GetImage

```c#
public byte[] GetImage(string name)
```

Վերադարձնում է փաստաթղթի տրված ներքին անունով նկար դաշտը՝ որպես byte տիպի զանգված։

### GetMemo

```c#
public string GetMemo(string name)
```

Վերադարձնում է փաստաթղթի տրված ներքին անունով մեծ տեքստային դաշտի(մեմոյի) արժեքը։

### GetNextTrans

```c#
public int GetNextTrans()
```

Վերադարձնում է փաստաթղթի տրանզակցիայի հերթական նոր համարը։

### GetParents

```c#
public async Task<List<int>> GetParents()
```

Վերադարձնում է փաստաթղթի ծնող փաստաթղթերի isn-ների ցուցակը։ 

### Grid

```c#
public IGrid Grid(string name)
```

Վերադարձնում է փաստաթղթի տրված ներքին անունով գրիդը։

### InitGrids

```c#
protected void InitGrids()
```

Արժեքավորում է փաստաթղթի բոլոր գրիդերը։

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
	* GridLoadMode.None - Ոչ մի գրիդ չի բեռնվում։
	* GridLoadMode.Full - Բեռնվում են բոլոր գրիդները։

### LoadImagesAndMemos

```c#
public async Task LoadImagesAndMemos(ArchiveInfo archiveInfo = null)
```

???

### LoadParents

```c#
public async Task LoadParents()
```

Բեռնում է փաստաթղթի ծնող փաստաթղթերի isn-ների ցուցակը։

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

Հանդիսանում է 4x համակարգում նկարագրված  [PostMessage](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/PostMessage.html)  իրադարձության համարժեքը:

### RefreshTimeStamp

```c#
public async Task RefreshTimeStamp()
```

Հիշողության մեջ թարմացնում է փաստաթղթի վերջին գրանցման համարը տվյալների պահոցից։

### SendMessage

```c#
public async Task SendMessage(string message,
                              int isn = -1,
                              string messageForDocLog = "",
                              bool raiseErrorIfDocNotExists = true,
                              bool raiseErrorIfParentNotExists = true)
```

Ուղարկում է հաղորդագրություն այլ փաստաթղթի (կամ ծնող փաստաթղթին) առաջացնելով  [PostMessage](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/PostMessage.html)  իրադարձություն:  
Հաղորդագրություն ստանալուց հետո ստացող փաստաթղթի  [պատմության](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/DocLog.html)  մեջ  [գրանցվում է](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Functions/ASDOC/WriteLog.html)  հաղորդագրության տեքստը և ստացող փաստաթղթի համար աշխատում է  [CheckAndStore](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Functions/ASDOC/CheckAndStore.html)  `2`  պարամետրով։

**Պարամետրեր**
- message - Ուղարկվող հաղորդագրության տեքստը։
- isn - Հաղորդագրությունը ստացող փաստաթղթի ներքին նույնականացման համարը։ Եթե պարամետրը փոխանցված չէ, ապա հաղորդագրությունը կուղարկվի ընթացիկ փաստաթղթի ծնողին, եթե այն առկա է։
- messageForDocLog - Ստացող փաստաթղթի պատմության մեջ գրանցվող տեքստը։ Եթե պարամետրը փոխանցված չէ, ապա պատմության մեջ կգրանցվի `message` պարամետրի արժեքը։
- raiseErrorIfDocNotExists - Ստացող փաստաթղթի բացակայության դեպքում սխալի գեներացում։ Լռությամբ արժեքը true է։
- raiseErrorIfParentNotExists - Ստացող ծնող փաստաթղթի բացակայության դեպքում սխալի գեներացում։ Լռությամբ արժեքը true է։

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

Վերագրում է default արժեքներ փաստաթղթի տրված դաշտերին։

### SetDefaultValuesForFields

```c#
public void SetDefaultValuesForFields(params string[] fields)
```

Վերագրում է default արժեքներ փաստաթղթի տրված դաշտերին։

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

Արժեքավորում է փաստաթղթի տրված ներքին անունով մեծ տեքստային դաշտը(մեմո)։

**Պարամետրեր**

* name - մեմոյի ներքին անունը,
* value - արժեքը։

### Store

```c#
public Task Store(DocumentCheckLevel checkLevel = DocumentCheckLevel.None, string logComment = "")
```

Կատարում է պարտադիր ստուգումներ և գրանցում փաստաթուղթը տվյալների պահոցում։

**Պարամետրեր**

* checkLevel  - Փաստաթղթի ստուգման մակարդակը։
* logComment - Լոգավորման համար անհրաժեշտ մեկնաբանությունը։

### StoreGrids

```c#
public virtual Task StoreGrids(StoreGridsEventArgs args)
```

Հանդիսանում է 4x համակարգում նկարագրված  [StoreGrid](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/StoreGrid.html)  իրադարձության համարժեքը:

### StoreValuesHistory

```c#
public async Task StoreValuesHistory()
```

Փաստաթղթի ռեկվիզիտների արժեքները գրանցում է տվյալների պահոցի LASTVALUESGROUP աղյուսակում։

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

### TemplateSubstitution

```c#
public virtual Task<TemplateSubstitution> TemplateSubstitution(Dictionary<string, bool> mode, Dictionary<string, object> parameters = null)
```

Հանդիսանում է 4x համակարգում նկարագրված  [TemplateSubstitution](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/TemplateSubstitution.html)  իրադարձության

### TemplateSubstitutionEx

```c#
public virtual Task<TemplateSubstitutionEx> TemplateSubstitutionEx(Dictionary<string, bool> mode, Dictionary<string, object> parameters = null)
```

???

### Validate

```c#
public virtual Task Validate(ValidateEventArgs args)
```

Հանդիսանում է 4x համակարգում նկարագրված  [Validate](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/Validate.html)  իրադարձության համարժեքը:

### WriteLog

```c#
public async Task WriteLog(string message, int dcrId = -1, bool dcrIdIsISN = false)
```

Ավելացնում է նոր գրառում փաստաթղթի պատմության մեջ։
