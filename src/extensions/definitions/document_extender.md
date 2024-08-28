---
layout: page
title: "Փաստաթղթի իրադարձությունների ընդլայնման նկարագրություն"
tags: [DocExtender, DOCUMENTEXTENDER]
sublinks: 
- { title: "DOCUMENTEXTENDER նկարագրություն", ref: documentextender-նկարագրություն }
- { title: "Հատկություններ", ref: հատկություններ }
- { title: "NAME", ref: name }
- { title: "CAPTION", ref: caption }
- { title: "ECAPTION", ref: ecaption }
- { title: "CSSOURCE", ref: cssource }
- { title: "DocumentExtender դաս", ref: documentextender-դաս }
- { title: "Մեթոդներ", ref: մեթոդներ }
- { title: "BeforeCommitDelete", ref: beforecommitdelete }
- { title: "PreAction", ref: preaction }
- { title: "PostAction", ref: postaction }
- { title: "PreAfterCommit", ref: preaftercommit }
- { title: "PostAfterCommit", ref: postaftercommit }
- { title: "PreAfterCreate", ref: preaftercreate }
- { title: "PostAfterCreate", ref: postaftercreate }
- { title: "PreAfterLoad", ref: preafterload }
- { title: "PostAfterLoad", ref: postafterload }
- { title: "PreBeforeCommit", ref: prebeforecommit }
- { title: "PostBeforeCommit", ref: postbeforecommit }
- { title: "PreBeforeCopy", ref: prebeforecopy }
- { title: "PostBeforeCopy", ref: postbeforecopy }
- { title: "PreDelete", ref: predelete }
- { title: "PostDelete", ref: postdelete }
- { title: "PreFolders", ref: prefolders }
- { title: "PostFolders", ref: postfolders }
- { title: "PostLoadGrids", ref: postloadgrids }
- { title: "PreOnConfirmDocumentChangeRequest", ref: preonconfirmdocumentchangerequest }
- { title: "PostOnConfirmDocumentChangeRequest", ref: postonconfirmdocumentchangerequest }
- { title: "PostStoreGrid", ref: poststoregrid }
- { title: "PreValidate", ref: prevalidate }
- { title: "PostValidate", ref: postvalidate }
---

## Բովանդակություն

- [Ներածություն](#ներածություն)
- [DOCUMENTEXTENDER նկարագրություն](#documentextender-նկարագրություն)
- [Հատկություններ](#հատկություններ)
  - [NAME](#name)
  - [CAPTION](#caption)
  - [ECAPTION](#ecaption)
  - [CSSOURCE](#cssource)
- [DocumentExtender դաս](#documentextender-դաս)
  - [Մեթոդներ](#մեթոդներ)
    - [BeforeCommitDelete](#beforecommitdelete)
    - [PreAction](#preaction)
    - [PostAction](#postaction)
    - [PreAfterCommit](#preaftercommit)
    - [PostAfterCommit](#postaftercommit)
    - [PreAfterCreate](#preaftercreate)
    - [PostAfterCreate](#postaftercreate)
    - [PreAfterLoad](#preafterload)
    - [PostAfterLoad](#postafterload)
    - [PreBeforeCommit](#prebeforecommit)
    - [PostBeforeCommit](#postbeforecommit)
    - [PreBeforeCopy](#prebeforecopy)
    - [PostBeforeCopy](#postbeforecopy)
    - [PreDelete](#predelete)
    - [PostDelete](#postdelete)
    - [PreFolders](#prefolders)
    - [PostFolders](#postfolders)
    - [PostLoadGrids](#postloadgrids)
    - [PreOnConfirmDocumentChangeRequest](#preonconfirmdocumentchangerequest)
    - [PostOnConfirmDocumentChangeRequest](#postonconfirmdocumentchangerequest)
    - [PostStoreGrid](#poststoregrid)
    - [PreValidate](#prevalidate)
    - [PostValidate](#postvalidate)

## Ներածություն

Գոյություն ունեցող փաստաթղթերի մշակման գործընթացում լրացուցիչ ստուգումներ իրականացնելու, դաշտերի ավտոմատ լրացման և այլ սեփական տրամաբանություն ավելացնելու համար նկարագրվում է փաստաթղթի ընդլայնում։
Փաստաթղթի ընդլայնումը իրանից ներկայացնում է վիրտուալ մեթոդների բազմություն, որոնք կանչվում են [փաստաթղթի հիմնական իրադարձություններից](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/DocEvents.html) առաջ և հետո։ 

8X համակարգում փաստաթղթի ընդլայնում նկարագրելու համար հարկավոր է ունենալ
- .as ընդլայնմամբ ֆայլ սկրիպտերում [DOCUMENTEXTENDER](#documentextender-նկարագրություն) նկարագրությամբ, որը պարունակում է մետատվյալներ ընդլայնման մասին,
- .cs ընդլայնմամբ ֆայլ, որը պարունակում է սերվերում աշխատող տրամաբանությունը։

.as և .cs ընդլայնմամբ ֆայլերը լրացնելուց հետո անհրաժեշտ է .as ընդլայնմամբ ֆայլը ներմուծել համակարգ `SYSCON` գործիքի միջոցով, որի արդյունքում կներմուծվի նաև .cs ընդլայնմամբ ֆայլը։

## DOCUMENTEXTENDER նկարագրություն

``` as4x
DOCUMENTEXTENDER {
  NAME = ...;
  CAPTION = ...;
  ECAPTION = ...;
  CSSOURCE = ...;
};
```

## Հատկություններ

### NAME
Ընդլայնվող փաստաթղթի ներքին անունը։

### CAPTION 
Ընդլայնման հայերեն անվանումը ANSI կոդավորմամբ։

### ECAPTION 
Ընդլայնման անգլերեն անվանումը։

### CSSOURCE 
Ընդլայնող C# ֆայլի [հարաբերական ճանապարհը](https://phoenixnap.com/kb/absolute-path-vs-relative-path) .as ֆայլի նկատմամբ։

Օրինակներ՝  
* Եթե extend.as և extend.cs ֆայլերը գտնվում են նույն թղթապանակում, ապա կգրվի `CSSOURCE = "extend.cs";`։  
* Եթե extend.as գտվում է "C:\WorkingDir\Scripts\App\extend.as" հասցեում, իսկ extend.cs-ը՝ "C:\WorkingDir\SubFolder1\SubFolder2\extend.as" հասցեում, ապա `CSSOURCE = "..\..\SubFolder1\SubFolder2\extend.cs";`։  
* Կամ կլինի գրել ամբողջական ճանապարհը, ինչը խրախուսելի չէ `CSSOURCE = "C:\WoringDir\SubFolder1\SubFolder2\extend.cs";`

## DocumentExtender դաս

Փաստաթղթի ընդլայնման համար անհրաժեշտ է սահմանել դաս, որը ժառանգում է `DocumentExtender` դասը և ունի `DocumentExtender` ատրիբուտը։

**Օրինակ**

```c#
[DocumentExtender]
public class DocExtenders : DocumentExtender
```

### Մեթոդներ

#### BeforeCommitDelete

```c#
public virtual Task BeforeCommitDelete(Document sender, BeforeCommitDeleteEventArgs args);
```

BeforeCommitDelete իրադարձությունը առաջանում է տվյալների պահոցից փաստաթղթի հեռացումից անմիջապես հետո տրանզակցիայի մեջ։ 

#### PreAction

```c#
public virtual Task PreAction(Document sender, ActionEventArgs args);
```

PreAction իրադարձությունը առաջանում է փաստաթղթի պահպանման ժամանակ ([Store](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Functions/ASDOC/Store.html)) տրանզակցիայի մեջ` [Action](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/Action.html) իրադարձությունից առաջ։

#### PostAction

```c#
public virtual Task PostAction(Document sender, ActionEventArgs args);
```

PostAction իրադարձությունը առաջանում է փաստաթղթի պահպանման ժամանակ ([Store](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Functions/ASDOC/Store.html)) տրանզակցիայի մեջ` [Action](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/Action.html) իրադարձությունից հետո։

#### PreAfterCommit

```c#
public virtual Task PreAfterCommit(Document sender, AfterCommitEventArgs args);
```

PreAfterCommit իրադարձությունը առաջանում է փաստաթղթի տվյալների պահոցում գրանցումից հետո մեծ տրանզակցիայի մեջ՝ [BeforeCommit](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/BeforeCommit.html) իրադարձությունից հետո և AfterCommit իրադարձությունից առաջ։

#### PostAfterCommit

```c#
public virtual Task PostAfterCommit(Document sender, AfterCommitEventArgs args);
```

PostAfterCommit իրադարձությունը առաջանում է փաստաթղթի տվյալների պահոցում գրանցումից հետո մեծ տրանզակցիայի մեջ՝ [BeforeCommit](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/BeforeCommit.html), AfterCommit իրադարձություններից հետո։

#### PreAfterCreate

```c#
public virtual Task PreAfterCreate(Document sender, AfterCreateEventArgs args);
```

PreAfterCreate իրադարձությունը առաջանում է փաստաթուղթը ստեղծելուց` [AfterCreate](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/AfterCreate.html) իրադարձությունից առաջ։


#### PostAfterCreate

```c#
public virtual Task PostAfterCreate(Document sender, AfterCreateEventArgs args);
```

PostAfterCreate իրադարձությունը առաջանում է փաստաթուղթը ստեղծելուց` [AfterCreate](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/AfterCreate.html) իրադարձությունից հետո։

#### PreAfterLoad

```c#
public virtual Task PreAfterLoad(Document sender, AfterLoadEventArgs args);
```

PreAfterLoad իրադարձությունը առաջանում է փաստաթղթի բեռնումից անմիջապես հետո` [AfterLoad](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/AfterLoad.html) իրադարձությունից առաջ։

#### PostAfterLoad

```c#
public virtual Task PostAfterLoad(Document sender, AfterLoadEventArgs args);
```

PostAfterLoad իրադարձությունը առաջանում է փաստաթղթի բեռնումից անմիջապես հետո` [AfterLoad](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/AfterLoad.html) իրադարձությունից հետո։

#### PreBeforeCommit

```c#
public virtual Task PreBeforeCommit(Document sender, BeforeCommitEventArgs args);
```

PreBeforeCommit իրադարձությունը առաջանում է փաստաթղթի տվյալների պահոցում գրանցումից անմիջապես հետո տրանզակցիայի մեջ՝ [BeforeCommit](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/BeforeCommit.html) իրադարձությունից առաջ։

#### PostBeforeCommit

```c#
public virtual Task PostBeforeCommit(Document sender, BeforeCommitEventArgs args);
```

PostBeforeCommit իրադարձությունը առաջանում է փաստաթղթի տվյալների պահոցում գրանցումից անմիջապես հետո տրանզակցիայի մեջ՝ [BeforeCommit](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/BeforeCommit.html) իրադարձությունից հետո։

#### PreBeforeCopy

```c#
public virtual Task PreBeforeCopy(Document sender, BeforeCopyEventArgs args);
```

PreBeforeCopy իրադարձությունը առաջանում է փաստաթուղթը պատճենման ժամանակ` [BeforeCopy](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/BeforeCopy.html) իրադարձությունից հետո։ 

#### PostBeforeCopy

```c#
public virtual Task PostBeforeCopy(Document sender, BeforeCopyEventArgs args);
```

PostBeforeCopy իրադարձությունը առաջանում է փաստաթուղթը պատճենման ժամանակ` [BeforeCopy](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/BeforeCopy.html) իրադարձությունից հետո։ 

#### PreDelete

```c#
public virtual Task PreDelete(Document sender, DeleteEventArgs args);
```

PreDelete իրադարձությունը առաջանում է փաստաթուղթը ջնջելու ժամանակ տրանզակցիայի մեջ` [Delete](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/Delete.html) իրադարձությունից առաջ։ 

#### PostDelete

```c#
public virtual Task PostDelete(Document sender, DeleteEventArgs args);
```

PostDelete իրադարձությունը առաջանում է փաստաթուղթը ջնջելու ժամանակ տրանզակցիայի մեջ` [Delete](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/Delete.html) իրադարձությունից հետո։ 

#### PreFolders

```c#
public virtual Task PreFolders(Document sender, FoldersEventArgs args);
```

PreFolders իրադարձությունը առաջանում է փաստաթղթի պահպանման ժամանակ ([Store](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Functions/ASDOC/Store.html)) տրանզակցիայի մեջ` [Folders](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/Folders.html) իրադարձությունից առաջ։

#### PostFolders

```c#
public virtual Task PostFolders(Document sender, FoldersEventArgs args);
```

PostFolders իրադարձությունը առաջանում է փաստաթղթի պահպանման ժամանակ ([Store](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Functions/ASDOC/Store.html)) տրանզակցիայի մեջ` [Folders](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/Folders.html) իրադարձությունից հետո։

#### PostLoadGrids

```c#
public virtual Task PostLoadGrids(Document sender, LoadGridsEventArgs args);
```

PostLoadGrids իրադարձությունը առաջանում է փաստաթղթի աղյուսակների բեռնման ժամանակ՝ [LoadGrids](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/LoadGrid.html) իրադարձությունից հետո։

#### PreOnConfirmDocumentChangeRequest

```c#
public virtual Task PreOnConfirmDocumentChangeRequest(Document sender, ConfirmDocumentChangeRequestEventArgs args);
```

PreOnConfirmDocumentChangeRequest իրադարձությունը առաջանում է փաստաթղթի պահպանման ժամանակ ([Store](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Functions/ASDOC/Store.html)) փաստաթղթի փոփոխման հայտի բացման ընթացքում տրանզակցիայի մեջ` [Validate](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/Validate.html) իրադարձությունից հետո և OnConfirmDocumentChangeRequest իրադարձությունից առաջ։

#### PostOnConfirmDocumentChangeRequest

```c#
public virtual Task PostOnConfirmDocumentChangeRequest(Document sender, ConfirmDocumentChangeRequestEventArgs args);
```

PreOnConfirmDocumentChangeRequest իրադարձությունը առաջանում է փաստաթղթի պահպանման ժամանակ ([Store](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Functions/ASDOC/Store.html)) փաստաթղթի փոփոխման հայտի բացման ընթացքում տրանզակցիայի մեջ` [Validate](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/Validate.html), OnConfirmDocumentChangeRequest իրադարձություններից հետո։

#### PostStoreGrid

```c#
public virtual Task PostStoreGrid(Document sender, StoreGridsEventArgs args);
```

PostStoreGrid իրադարձությունը առաջանում է փաստաթղթի աղյուսակի պահպանման ժամանակ` [StoreGrids](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/StoreGrid.html) իրադարձությունից հետո։

#### PreValidate

```c#
public virtual Task PreValidate(Document sender, ValidateEventArgs args);
```

PreValidate իրադարձությունը առաջանում է փաստաթղթի պահպանման ժամանակ ([Store](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Functions/ASDOC/Store.html)) տրանզակցիայի մեջ` [Validate](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/Validate.html) իրադարձությունից առաջ։

#### PostValidate

```c#
public virtual Task PostValidate(Document sender, ValidateEventArgs args);
```

PostValidate իրադարձությունը առաջանում է փաստաթղթի պահպանման ժամանակ ([Store](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Functions/ASDOC/Store.html)) տրանզակցիայի մեջ` [Validate](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/Validate.html) իրադարձությունից հետո։
