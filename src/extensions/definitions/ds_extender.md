---
layout: page
title: "Տվյալների աղբյուրի ընդլայնում"
tags: [Extender, DSEXTENDER]
---

## Բովանդակություն
* [Նախաբան](#նախաբան)
* [Օրինակներ](#օրինակներ)
* [DSEXTENDER նկարագրություն](#dsextender-նկարագրություն)
* [Extender դաս](#extender-դաս)
  * [Հատկություններ](#հատկություններ)
    * [AlwaysCallBeforeProcess](#alwayscallbeforeprocess)
  * [Մեթոդներ](#մեթոդներ)
    * [AddColumn](#addcolumn)
    * [AddParam](#addparam)
    * [BeforeProcess](#beforeprocess)
    * [ProccessRow](#proccessrow)


## Նախաբան

Գոյություն ունեցող տվյալների աղբյուրում լրացուցիչ սյուներ, պարամետրեր ավելացնելու, տողերի պարունակությունը փոփոխելու համար նկարագրվում է տվյալների աղբյուրի ընդլայնում։

8X համակարգում տվյալների աղբյուրի ընդլայնում նկարագրելու համար հարկավոր է ունենալ
- .as ընդլայնմամբ ֆայլ սկրիպտերում DSEXTENDER նկարագրությամբ, որը պարունակում է մետատվյալներ ընդլայնման մասին,
- .cs ընդլայնմամբ ֆայլ, որը պարունակում է սերվերում աշխատող տրամաբանությունը։

## Օրինակներ

* [Տվյալների աղբյուրի ընդլայնում 8X-ում](ds_extender_guide.md)
* [Տվյալների աղբյուրի պարամետրերի ընդլայնում 8X-ում](ds_extender_param_guide.md)
* [Ընդլայնման միջոցով պարամետրի ավելացմեն ամբողջական օրինակ](/src/extensions/definitions/ds_extender_param_full_example.md)

## DSEXTENDER նկարագրություն

``` as4x
DSEXTENDER {
  NAME = ...;
  CAPTION = ...;
  ECAPTION = ...;
  DATASOURCE = ...;
  CSSOURCE = ...;
};
```

## Հատկություններ

### NAME
Ընդլայնման ներքին անվանումը (առավ. 50 նիշ)։

### CAPTION 
Ընդլայնման հայերեն անվանումը ANSI կոդավորմամբ։

### ECAPTION 
Ընդլայնման անգլերեն անվանումը։

### DATASOURCE 
Ընդլայնվող տվյալների աղբյուրի ներքին անվանումը։

### CSSOURCE 
Ընդլայնող C# ֆայլի [հարաբերական ճանապարհը](https://phoenixnap.com/kb/absolute-path-vs-relative-path) .as ֆայլի նկատմամբ։

Օրինակներ՝  
* Եթե extend.as և extend.cs ֆայլերը գտնվում են նույն թղթապանակում, ապա կգրվի `CSSOURCE = "extend.cs";`։  
* Եթե extend.as գտվում է "C:\WorkingDir\Scripts\App\extend.as" հասցեում, իսկ extend.cs-ը՝ "C:\WorkingDir\SubFolder1\SubFolder2\extend.as" հասցեում, ապա `CSSOURCE = "..\..\SubFolder1\SubFolder2\extend.cs";`։  
* Կամ կլինի գրել ամբողջական ճանապարհը, ինչը խրախուսելի չէ `CSSOURCE = "C:\WoringDir\SubFolder1\SubFolder2\extend.cs";`

## Extender դաս

```c#
public abstract class Extender<R, P> : IExtender
    where P : class, new()
    where R : class, new()
```

Տվյալների աղբյուրի ընդլայման համար անհրաժեշտ է սահմանել դաս, որը ժառանգում է Extender<R, P> դասը՝ որպես R փոխանցելով տվյալների աղբյուրի ընդլայման սյուները նկարագրող դասը, իսկ որպես P՝ պարամետրերը նկարագրող դասը։  
Եթե նոր պարամետր չի ավելացվում ընդլայնմամբ, ապա որպես `P` անհրաժեշտ է փոխանցել `NoParam` դասը։
Եթե նոր սյուն չի ավելացվում ընդլայնմամբ, ապա որպես `R` անհրաժեշտ է փոխանցել `NoColumns` դասը։

## Հատկություններ

### AlwaysCallBeforeProcess

```c#
public virtual bool AlwaysCallBeforeProcess => false; 
```

[BeforeProcess](#beforeprocess) մեթոդը կանչվում է միայն տողեր պարունակող տվյալների աղբյուրի համար։ Դատարկ տվյալների աղբյուրի համար մեթոդի կանչը ապահովելու համար անհրաժեշտ է override անել այս հատկությունը և վերադարձնել true արժեք։

## Մեթոդներ

### AddColumn

```c#
public void AddColumn(string name, string armenianCaption, string englishCaption, FieldType columnType,
                      string armenianDescription = null, string englishDescription = null,
                      FieldType showType = null, short width = 0, short headlines = 2,
                      SupportedEncoding supportedEncoding = SupportedEncoding.ArmenianAnsi)
```

Ընդլայնման միջոցով ավելացող նոր սյան հատկությունները սահմանելու համար անհրաժեշտ է կոնստրուկտորում կանչել այս մեթոդը։

**Պարամետրեր**

* `name` - Սյան ներքին անուՆը:
* `armenianCaption` - Սյան հայերեն անվանումը ANSI կոդավորմամբ։
* `englishCaption` - Սյան անգլերեն անվանումը։
* `columnType` - Սյան համակարգային տիպը։  
  Օրինակ՝  
  FieldTypeProvider.Boolean  
  FieldTypeProvider.Amount  
  FieldTypeProvider.GetStringFieldType(10)  
* `armenianDescription` - Սյան հայերեն նկարագրությունը ANSI կոդավորմամբ։
* `englishDescription` - Սյան անգլերեն նկարագրությունը։
* `showType` - Սահմանում է համակարգային տիպը ցուցադրման ժամանակ։  
  Եթե այս պարամետրը բացակայում է, ապա օգտագործվում է columnType հատկության արժեքը։
  Սովորոբար այս հատկությունը օգտագործում են, եթե տվյալների տիպը, որը համապատասխանում է սյունակի արժեքներին, հարմար չի ցուցադրման համար։
  Օրինակ եթե columnType = FieldTypeProvider.GetStringFieldType(150) է, բայց շատ դեպքերում բավական է տեսնել տողի սկիզբը, ապա կարելի է սահմանել showType = 
  FieldTypeProvider.GetStringFieldType(32),
* `width` - Սյան լայնությունը:
  Արժեք չփոխանցելու դեպքում որոշվում է կախված սյան armenianCaption, englishCaption, columnType, showType հատկություններից կախված։
* `headlines` - Սյան անվանման մեջ տողերի քանակ։ Լռությամբ արժեքը 2 է։
* `supportedEncoding` - Սյան կոդավորման տեսակը, որը կարող է ընդունել 3 արժեք՝ SupportedEncoding.ArmenianAnsi, SupportedEncoding.RussionAnsi և SupportedEncoding.Unicode։

### AddParam

```c#
public void AddParam(string name, string description, FieldType fieldType)
```

Ընդլայնման միջոցով ավելացող նոր պարամետրի հատկությունները սահմանելու համար անհրաժեշտ է կոնստրուկտորում կանչել այս մեթոդը։

**Պարամետրեր**

* `name` - Պարամետրի ներքին անվանումը։
* `description` - Պարամետրի հայերեն նկարագրությունը։ Անհրաժեշտ է փոխանցել ANSI կոդավորմամբ։
* `fieldType` - Պարամետրի համակարգային տիպը:

### BeforeProcess

```c#
public virtual Task BeforeProcess(IList<IExtendableRow> rows, IDataSourceArgs args)
```

Մեթոդը կանչվում է միջուկի կողմից տվյալների աղբյուրի հիմնական հաշվարկի ավարտից հետո։  
Հիմնականում օգտագործվում է [ProccessRow](#proccessRow)-ում կիրառվող տվյալների բեռնման և քեշավորման համար։  
Կարող է օգտագործվել հիմնական հաշվարկված բոլոր տողերի մշակման (փոփոխելու, ջնջելու, ավելացնելու) համար։

Մեթոդը չի կանչվում միջուկի կողմից, եթե հիմնական հաշվարկի մեջ տողեր չկան և [AlwaysCallBeforeProcess](#alwayscallbeforeprocess) հատկության արժեքը false է։

**Պարամետրեր**

* `rows` - Տվյալների աղբյուրի ընդլայնման տողերի ցուցակ։
* `args` - Տվյալների աղբյուրի հաշվարկին սկսելու պարամետրեր։ Պարունակում է տվյալների աղբյուրի և ընդլայնման պարամետրերը, սյուների անվանումների ցանկը և մետատվյալներ։

### ProccessRow

```c#
public virtual Task<bool> ProccessRow(IExtendableRow row, IDataSourceArgs args)
```

Մեթոդը կանչվում է միջուկի կողմից տվյալների աղբյուրի յուրաքանչյուր տողի համար։  
Տվյալների աղբյուրի սյուների արժեքների փոփոխման, ավելացված սյուների արժեքների լրացման, տողերի ֆիլտրման համար անհրաժեշտ է մշակել այս մեթոդը։  

**Պարամետրեր**

* `row` - Տվյալների աղբյուրի ընդլայնման ընթացիկ տողը։ Պարունակում է object տիպի Extend հատկություն, որի մեջ պահվում են ընդլայնման սյուները։
* `args` - Տվյալների աղբյուրի հաշվարկին սկսելու պարամետրեր։ Պարունակում է տվյալների աղբյուրի և ընդլայնման պարամետրերը, սյուների անվանումների ցանկը և մետատվյալներ։

**Վերադարձնում է**
bool տիպի արժեք, որը ցույց է տալիս, թե ընթացիկ տողը պետք է ընդգրկվի վերջնական ցուցակում, թե ոչ։ 
