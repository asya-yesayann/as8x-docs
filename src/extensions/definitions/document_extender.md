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
DSEXTENDER {
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

### PostAction

Action իրադարձությունը առաջանում է փաստաթղթի պահպանման ժամանակ ([Store](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Functions/ASDOC/Store.html)) տրանզակցիայի մեջ` [Action](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/Action.html) իրադարձությունից հետո։

### PreAction

Action իրադարձությունը առաջանում է փաստաթղթի պահպանման ժամանակ ([Store](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Functions/ASDOC/Store.html)) տրանզակցիայի մեջ` [Action](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/Action.html) իրադարձությունից առաջ։

### PreAfterCreate

PreAfterCreate իրադարձությունը առաջանում է փաստաթուղթը ստեղծելուց` [AfterCreate](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/AfterCreate.html) իրադարձությունից առաջ։

### PostAfterCreate

PostAfterCreate իրադարձությունը առաջանում է փաստաթուղթը ստեղծելուց` [AfterCreate](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/AfterCreate.html) իրադարձությունից հետո։

### PreAfterLoad

PreAfterLoad իրադարձությունը առաջանում է փաստաթղթի բեռնումից անմիջապես հետո` [AfterLoad](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/AfterLoad.html) իրադարձությունից առաջ։

### PostAfterLoad

PostAfterLoad իրադարձությունը առաջանում է փաստաթղթի բեռնումից անմիջապես հետո` [AfterLoad](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/AfterLoad.html) իրադարձությունից հետո։

### PreBeforeCommit

PreBeforeCommit իրադարձությունը առաջանում է փաստաթղթի տվյալների պահոցում գրանցումից անմիջապես հետո տրանզակցիայի մեջ՝ [BeforeCommit](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/BeforeCommit.html) իրադարձությունից առաջ։

### PostBeforeCommit

PostBeforeCommit իրադարձությունը առաջանում է փաստաթղթի տվյալների պահոցում գրանցումից անմիջապես հետո տրանզակցիայի մեջ՝ [BeforeCommit](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/BeforeCommit.html) իրադարձությունից հետո։

### PreBeforeCopy

PreBeforeCopy իրադարձությունը առաջանում է փաստաթուղթը պատճենման ժամանակ` [BeforeCopy](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/BeforeCopy.html) իրադարձությունից հետո։ 

### PostBeforeCopy

PostBeforeCopy իրադարձությունը առաջանում է փաստաթուղթը պատճենման ժամանակ` [BeforeCopy](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/BeforeCopy.html) իրադարձությունից հետո։ 

### PreDelete

PreDelete իրադարձությունը առաջանում է փաստաթուղթը ջնջելու ժամանակ տրանզակցիայի մեջ` [Delete](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/Delete.html) իրադարձությունից առաջ։ 

### PostDelete

PostDelete իրադարձությունը առաջանում է փաստաթուղթը ջնջելու ժամանակ տրանզակցիայի մեջ` [Delete](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/Delete.html) իրադարձությունից հետո։ 

### PreFolders

PreFolders իրադարձությունը առաջանում է փաստաթղթի պահպանման ժամանակ ([Store](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Functions/ASDOC/Store.html)) տրանզակցիայի մեջ` [Folders](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/Folders.html) իրադարձությունից առաջ։

### PostFolders

PostFolders իրադարձությունը առաջանում է փաստաթղթի պահպանման ժամանակ ([Store](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Functions/ASDOC/Store.html)) տրանզակցիայի մեջ` [Folders](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/Folders.html) իրադարձությունից հետո։

### PreValidate

PreValidate իրադարձությունը առաջանում է փաստաթղթի պահպանման ժամանակ ([Store](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Functions/ASDOC/Store.html)) տրանզակցիայի մեջ` [Validate](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/Validate.html) իրադարձությունից առաջ։

### PostValidate

PostValidate իրադարձությունը առաջանում է փաստաթղթի պահպանման ժամանակ ([Store](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Functions/ASDOC/Store.html)) տրանզակցիայի մեջ` [Validate](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/Validate.html) իրադարձությունից հետո։

### PostLoadGrids

PostLoadGrids իրադարձությունը առաջանում է փաստաթղթի աղյուսակների բեռնման ժամանակ՝ [LoadGrids](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/LoadGrid.html) իրադարձությունից հետո։

### PostStoreGrid

PostStoreGrid իրադարձությունը առաջանում է փաստաթղթի աղյուսակի պահպանման ժամանակ` [StoreGrids](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/StoreGrid.html) իրադարձությունից հետո։
