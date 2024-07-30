---
layout: page
title: "Փաստաթղթի ընդլայնում"
tags: [DocExtender, DOCUMENTEXTENDER]
---

## Բովանդակություն
* [Նախաբան](#նախաբան)
* [Օրինակներ](#օրինակներ)
* [DOCUMENTEXTENDER նկարագրություն](#documentextender-նկարագրություն)
* [DocumentExtender դաս](#documentextender-դաս)
  * [Մեթոդներ](#մեթոդներ)
	* [Custom](#custom) 
	* [BeforeCommitDelete](#beforecommitdelete) 
	* [PostAction](#postaction) 
    * [PostAfterCommit](#postaftercommit) 
    * [PostAfterCreate](#postaftercreate) 
    * [PostAfterLoad](#postafterload) 
    * [PostBeforeCommit](#postbeforecommit) 
    * [PostBeforeCopy](#postbeforecopy) 
    * [PostDelete](#postdelete) 
    * [PostDeserializeComplexObjectsProperties](#postdeserializecomplexobjectsproperties)
    * [PostFolders](#postfolders) 
    * [PostOnConfirmDocumentChangeRequest](#postonconfirmdocumentchangerequest)
    * [PostSerializeComplexObjects](#postserializecomplexobjects)
    * [PostStoreGrid](#poststoregrid) 
    * [PostValidate](#postvalidate) 
    * [PreAction](#preaction) 
    * [PreAfterCommit](#preaftercommit) 
    * [PreAfterCreate](#preaftercreate) 
    * [PreAfterLoad](#preafterload) 
    * [PreBeforeCommit](#prebeforecommit) 
    * [PreBeforeCopy](#preaftercommit) 
    * [PreDelete](#predelete) 
    * [PreDeserializeComplexObjectsProperties](#predeserializecomplexobjectsproperties) 
    * [PreFolders](#prefolders) 
    * [PostLoadGrids](#postloadgrids) 
    * [PreOnConfirmDocumentChangeRequest](#preonconfirmdocumentchangerequest) 
    * [PreSerializeComplexObjects](#preserializecomplexobjects) 
    * [PreValidate](#prevalidate) 
   
## Նախաբան

8X համակարգում փաստաթղթի ընդլայնում նկարագրելու համար հարկավոր է ունենալ
- .as ընդլայնմամբ ֆայլ սկրիպտերում DOCUMENTEXTENDER նկարագրությամբ, որը պարունակում է մետատվյալներ ընդլայնման մասին,
- .cs ընդլայնմամբ ֆայլ, որը պարունակում է սերվերում աշխատող տրամաբանությունը։

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

```
[DocumentExtender]
public class DocExtenders : DocumentExtender
```

### Մեթոդներ

### BeforeCommitDelete

BeforeCommitDelete իրադարձությունը առաջանում է տվյալների պահոցից փաստաթղթի հեռացումից անմիջապես հետո տրանզակցիայի մեջ։ 

```c#
public virtual Task BeforeCommitDelete(Document sender, BeforeCommitDeleteEventArgs args)
```

### PreAction

Action իրադարձությունը առաջանում է փաստաթղթի պահպանման ժամանակ ([Store](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Functions/ASDOC/Store.html)) տրանզակցիայի մեջ` [Action](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/Action.html) իրադարձությունից առաջ։

```c#
public virtual Task PreAction(Document sender, ActionEventArgs args)
```

### PostAction

Action իրադարձությունը առաջանում է փաստաթղթի պահպանման ժամանակ ([Store](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Functions/ASDOC/Store.html)) տրանզակցիայի մեջ` [Action](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/Action.html) իրադարձությունից հետո։

```c#
public virtual Task PostAction(Document sender, ActionEventArgs args)
```

### PreAfterCreate

PreAfterCreate իրադարձությունը առաջանում է փաստաթուղթը ստեղծելուց` [AfterCreate](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/AfterCreate.html) իրադարձությունից առաջ։

```c#
public virtual Task PreAfterCreate(Document sender, AfterCreateEventArgs args)
```

### PostAfterCreate

PostAfterCreate իրադարձությունը առաջանում է փաստաթուղթը ստեղծելուց` [AfterCreate](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/AfterCreate.html) իրադարձությունից հետո։

```c#
public virtual Task PostAfterCreate(Document sender, AfterCreateEventArgs args)
```

### PreAfterLoad

PreAfterLoad իրադարձությունը առաջանում է փաստաթղթի բեռնումից անմիջապես հետո` [AfterLoad](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/AfterLoad.html) իրադարձությունից առաջ։

```c#
public virtual Task PreAfterLoad(Document sender, AfterLoadEventArgs args)
```

### PostAfterLoad

PostAfterLoad իրադարձությունը առաջանում է փաստաթղթի բեռնումից անմիջապես հետո` [AfterLoad](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/AfterLoad.html) իրադարձությունից հետո։

```c#
public virtual Task PostAfterLoad(Document sender, AfterLoadEventArgs args)
```

### PreBeforeCommit

PreBeforeCommit իրադարձությունը առաջանում է փաստաթղթի տվյալների պահոցում գրանցումից անմիջապես հետո տրանզակցիայի մեջ՝ [BeforeCommit](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/BeforeCommit.html) իրադարձությունից առաջ։

```c#
public virtual Task PreBeforeCommit(Document sender, BeforeCommitEventArgs args)
```

### PostBeforeCommit

PostBeforeCommit իրադարձությունը առաջանում է փաստաթղթի տվյալների պահոցում գրանցումից անմիջապես հետո տրանզակցիայի մեջ՝ [BeforeCommit](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/BeforeCommit.html) իրադարձությունից հետո։

```c#
public virtual Task PostBeforeCommit(Document sender, BeforeCommitEventArgs args)
```

### PreBeforeCopy

PreBeforeCopy իրադարձությունը առաջանում է փաստաթուղթը պատճենման ժամանակ` [BeforeCopy](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/BeforeCopy.html) իրադարձությունից հետո։ 

```c#
public virtual Task PreBeforeCopy(Document sender, BeforeCopyEventArgs args)
```

### PostBeforeCopy

PostBeforeCopy իրադարձությունը առաջանում է փաստաթուղթը պատճենման ժամանակ` [BeforeCopy](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/BeforeCopy.html) իրադարձությունից հետո։ 

```c#
public virtual Task PostBeforeCopy(Document sender, BeforeCopyEventArgs args)
```

### PreDelete

PreDelete իրադարձությունը առաջանում է փաստաթուղթը ջնջելու ժամանակ տրանզակցիայի մեջ` [Delete](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/Delete.html) իրադարձությունից առաջ։ 

```c#
public virtual Task PreDelete(Document sender, DeleteEventArgs args)
```

### PostDelete

PostDelete իրադարձությունը առաջանում է փաստաթուղթը ջնջելու ժամանակ տրանզակցիայի մեջ` [Delete](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/Delete.html) իրադարձությունից հետո։ 

```c#
public virtual Task PostDelete(Document sender, DeleteEventArgs args)
```

### PreFolders

PreFolders իրադարձությունը առաջանում է փաստաթղթի պահպանման ժամանակ ([Store](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Functions/ASDOC/Store.html)) տրանզակցիայի մեջ` [Folders](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/Folders.html) իրադարձությունից առաջ։

```c#
public virtual Task PreFolders(Document sender, FoldersEventArgs args)
```

### PostFolders

PostFolders իրադարձությունը առաջանում է փաստաթղթի պահպանման ժամանակ ([Store](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Functions/ASDOC/Store.html)) տրանզակցիայի մեջ` [Folders](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/Folders.html) իրադարձությունից հետո։

```c#
public virtual Task PostFolders(Document sender, FoldersEventArgs args)
```

### PreValidate

PreValidate իրադարձությունը առաջանում է փաստաթղթի պահպանման ժամանակ ([Store](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Functions/ASDOC/Store.html)) տրանզակցիայի մեջ` [Validate](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/Validate.html) իրադարձությունից առաջ։

```c#
public virtual Task PreValidate(Document sender, ValidateEventArgs args)
```

### PostValidate

PostValidate իրադարձությունը առաջանում է փաստաթղթի պահպանման ժամանակ ([Store](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Functions/ASDOC/Store.html)) տրանզակցիայի մեջ` [Validate](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/Validate.html) իրադարձությունից հետո։

```c#
public virtual Task PostValidate(Document sender, ValidateEventArgs args)
```

### PostLoadGrids

PostLoadGrids իրադարձությունը առաջանում է փաստաթղթի աղյուսակների բեռնման ժամանակ՝ [LoadGrids](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/LoadGrid.html) իրադարձությունից հետո։

```c#
public virtual Task PostLoadGrids(Document sender, LoadGridsEventArgs args)
```

### PostStoreGrid

PostStoreGrid իրադարձությունը առաջանում է փաստաթղթի աղյուսակի պահպանման ժամանակ` [StoreGrids](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/StoreGrid.html) իրադարձությունից հետո։

```c#
public virtual Task PostStoreGrid(Document sender, StoreGridsEventArgs args)
```
