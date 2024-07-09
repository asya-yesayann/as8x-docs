---
layout: page
title: "(DataSource) Տվյալների աղբյուրի ընդլայնում"
tags: [Extender, DSEXTENDER]
---


## Բովանդակություն
* [Նախաբան](#նախաբան)
* [DSEXTENDER նկարագրություն](#dsextender-նկարագրություն)
* [Extender դաս](#extender-դաս)
  * [Հատկություններ](#հատկություններ)
  * [Մեթոդներ](#մեթոդներ)

## Նախաբան

Գոյություն ունեցող տվյալների աղբյուրում լրացուցիչ սյուներ, պարամետրեր ավելացնելու, տողերի պարունակությունը փոփոխելու համար նկարագրվում է տվյալների աղբյուրի ընդլայնում։

8X համակարգում տվյալների աղբյուրի ընդլայնում նկարագրելու համար հարկավոր է ունենալ
- .as ընդլայնմամբ ֆայլ սկրիպտերում, որը պարունակում է մետատվյալներ ընդլայնման մասին,
- .cs ընդլայնմամբ ֆայլ, որը պարունակում է սերվերում աշխատող տրամաբանությունը։

## DSEXTENDER նկարագրություն

Տվյալների աղբյուրի ընդլայման համար անհրաժեշտ է ստեղծել .as ընդլայնմամբ ֆայլ՝ ավելացնելով DSEXTENDER տիպի նկարագրություն հետևյալ հատկություններով
### NAME
ներքին անվանումը (առավ. 50 նիշ)։
### CAPTION 
հայերեն անվանումը ANSI կոդավորմամբ։
### ECAPTION 
անգլերեն անվանումը։
### DATASOURCE 
ընդլայնվող տվյալների աղբյուրի ներքին անվանումը։
### CSSOURCE 
Ընդլայնող C# ֆայլի հարաբերական ճանապարհը .as ֆայլի նկատմամբ։

Օրինակներ՝  
Եթե extend.as և extend.cs ֆայլերը գտնվում են նույն թղթապանակում, ապա կգրվի `CSSOURCE = "extend.cs";`։  
Եթե extend.as գտվում է "C:\WorkingDir\Scripts\App\extend.as" հասցեում իսկ extend.cs-ը "C:\WorkingDir\SubFolder1\SubFolder2\extend.as" հասցեում, ապա `CSSOURCE = "..\..\SubFolder1\SubFolder2\extend.cs";`։  
Կամ կլինի գրել ամբողջական ճանապարհը, ինչը խրախուսելի չէ `CSSOURCE = "C:\WoringDir\SubFolder1\SubFolder2\extend.cs";`

## Extender դաս

```c#
public abstract class Extender<R, P> : IExtender
    where P : class, new()
    where R : class, new()
```

Տվյալների աղբյուրի ընդլայման համար անհրաժեշտ է սահմանել դաս, որը ժառանգում է Extender<R, P> դասը՝ -   որպես R փոխանցելով տվյալների աղբյուրի ընդլայման սյուները նկարագրող դասը, իսկ որպես P՝ պարամետրերը նկարագրող դասը։ Եթե տվյալների աղբյուրը ընդլայնումը չի պարունակում պարամետրեր, ապա որպես P անհրաժեշտ է փոխանցել  `NoParam`  դասը։

Նկարագրման օրինակին ծանոթանալու համար [տե՛ս](../examples/ds.md)։

## Հատկություններ

### AlwaysCallBeforeProcess

```c#
public virtual bool AlwaysCallBeforeProcess => false; 
```

[BeforeProcess](#beforeprocess) մեթոդը կանչվում է միայն այն դեպքում, երբ տվյալների աղբյուրը պարունակում է տողեր։ Տողեր չպարունակելու դեպքում մեթոդի կանչը ապահովելու համար անհրաժեշտ է override անել այս հատկությունը՝ վերադարձնելով true արժեք։

## Մեթոդներ

### BeforeProcess

```c#
public virtual Task BeforeProcess(IList<IExtendableRow> rows, IDataSourceArgs args)
```

Մեթոդը կանչվում է միջուկի կողմից տվյալների աղբյուրի հիմնական հաշվարկի ավարտից հետո։  
Հիմնականում օգտագործվում է [ProccessRow](#proccessRow)-ում կիրառվող տվյալների բեռնման և քեշավորման համար։  
Կարող է օգտագործվել հիմնական հաշվարկված բոլոր տողերի մշակման (փոփոխելու, ջնջելու, ավելացնելու) համար։

### ProccessRow

```c#
public virtual Task<bool> ProccessRow(IExtendableRow row, IDataSourceArgs args)
```

Մեթոդը կանչվում է միջուկի կողմից տվյալների աղբյուրի յուրաքանչյուր տողի համար։  
Տվյալների աղբյուրի սյուների արժեքների փոփոխման, ավելացված սյուների արժեքների լրացման, տողերի ֆիլտրման համար անհրաժեշտ է մշակել անել այս մեթոդը։  
Վերադարձնում է bool տիպի արժեք, որը ցույց է տալիս, թե ընթացիկ տողը պետք է ընդգրկվի վերջնական ցուցակում, թե ոչ։ 

### AddColumn

```c#
public void AddColumn(string name, string armenianCaption, string englishCaption, FieldType columnType,
                      string armenianDescription = null, string englishDescription = null,
                      FieldType showType = null, short width = 0, short headlines = 2,
                      SupportedEncoding supportedEncoding = SupportedEncoding.ArmenianAnsi)
```

Ավելացված սյան հատկությունները սահմանելու համար անհրաժեշտ է կոնստրուկտորում կանչել այս մեթոդը։

**Պարամետրեր**

* name - սյան ներքին անումը,
* armenianCaption - Սյան հայերեն անվանումը՝ անհրաժեշտ է փոխանցել ANSI կոդավորմամբ,
* englishCaption - սյան անգլերեն անվանումը,
* columnType - սյան համակարգային տիպը։  
  Օրինակ՝  
  FieldTypeProvider.Boolean  
  FieldTypeProvider.Amount  
  FieldTypeProvider.GetStringFieldType(10)  
* armenianDescription - սյան հայերեն նկարագրությունը՝ անհրաժեշտ է փոխանցել ANSI կոդավորմամբ,
* englishDescription  - սյան անգլերեն նկարագրությունը,
* showType - Սահմանում է համակարգային տիպը ցուցադրման ժամանակ։  
  Եթե այս պարամետրը բացակայում է, ապա օգտագործվում է columnType հատկության արժեքը։ Սովորոբար այս հատկությունը օգտագործում են, եթե տվյալների տիպը, որը համապատասխանում է սյունակի արժեքներին, հարմար չի ցուցադրման համար։
  Օրինակ եթե columnType = new StringFieldType(150) է, բայց շատ դեպքերում բավական է տեսնել տողի սկիզբը, ապա կարելի է սահմանել showType = new StringFieldType(32),
* width - սյան լայնությունը: Արժեք չփոխանցելու դեպքում որոշվում է կախված սյան armenianCaption, englishCaption, columnType, showType հատկություններից կախված,
* headlines - սյան անվանման մեջ տողերի քանակ։ Լռությամբ արժեքը 2 է,
* supportedEncoding - սյան կոդավորման տեսակը, որը կարող է ընդունել 3  արժեք՝ ArmenianAnsi, RussionAnsi և Unicode։

### AddParam

Ավելացված պարամետրի կառուցվածքը սահմանելու համար անհրաժեշտ է կոնստրուկտորում կանչել այս մեթոդը։

```c#
public void AddParam(string name, string description, FieldType fieldType)
```

**Մեթոդի պարամետրերի ցանկ**

* name - պարամետրի ներքին անվանումը,
* description - պարամետրի հայերեն նկարագրությունը՝ անհրաժեշտ է փոխանցել ANSI կոդավորմամբ
* fieldType - պարամետրի համակարգային տիպը:
