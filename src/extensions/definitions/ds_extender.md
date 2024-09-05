---
layout: page
title: "Տվյալների աղբյուրի ընդլայնման նկարագրություն"
tags: [Extender, DSEXTENDER]
sublinks:
- { title: "Օրինակներ", ref: օրինակներ }
- { title: "DSEXTENDER նկարագրություն", ref: dsextender-նկարագրություն }
- { title: "Հատկություններ", ref: հատկություններ }
- { title: "NAME", ref: name }
- { title: "CAPTION", ref: caption }
- { title: "ECAPTION", ref: ecaption }
- { title: "DATASOURCE", ref: datasource }
- { title: "CSSOURCE", ref: cssource }
- { title: "Extender դաս", ref: extender-դաս }
- { title: "Հատկություններ", ref: հատկություններ-1 }
- { title: "AlwaysCallBeforeProcess", ref: alwayscallbeforeprocess }
- { title: "Մեթոդներ", ref: մեթոդներ }
- { title: "AddColumn", ref: addcolumn }
- { title: "AddParam", ref: addparam }
- { title: "BeforeProcess", ref: beforeprocess }
- { title: "ProccessRow", ref: proccessrow }
---

## Բովանդակություն

- [Ներածություն](#ներածություն)
- [Օրինակներ](#օրինակներ)
- [DSEXTENDER նկարագրություն](#dsextender-նկարագրություն)
- [Հատկություններ](#հատկություններ)
  - [NAME](#name)
  - [CAPTION](#caption)
  - [ECAPTION](#ecaption)
  - [DATASOURCE](#datasource)
  - [CSSOURCE](#cssource)
- [Extender դաս](#extender-դաս)
- [Հատկություններ](#հատկություններ-1)
  - [AlwaysCallBeforeProcess](#alwayscallbeforeprocess)
- [Մեթոդներ](#մեթոդներ)
  - [AddColumn](#addcolumn)
  - [AddParam](#addparam)
  - [BeforeProcess](#beforeprocess)
  - [ProccessRow](#proccessrow)

## Ներածություն

Գոյություն ունեցող տվյալների աղբյուրում լրացուցիչ սյուներ, պարամետրեր ավելացնելու, տողերի պարունակությունը փոփոխելու համար նկարագրվում է տվյալների աղբյուրի ընդլայնում։

8X համակարգում տվյալների աղբյուրի ընդլայնում նկարագրելու համար հարկավոր է ունենալ
- .as ընդլայնմամբ ֆայլ սկրիպտերում [DSEXTENDER](#dsextender-նկարագրություն) նկարագրությամբ, որը պարունակում է մետատվյալներ ընդլայնման մասին,
- .cs ընդլայնմամբ ֆայլ, որը պարունակում է սերվերում աշխատող տրամաբանությունը։

.as և .cs ընդլայնմամբ ֆայլերը լրացնելուց հետո անհրաժեշտ է .as ընդլայնմամբ ֆայլը ներմուծել համակարգ `SYSCON` գործիքի միջոցով, որի արդյունքում կներմուծվի նաև .cs ընդլայնմամբ ֆայլը։

## Օրինակներ

* [Տվյալների աղբյուրի ընդլայնում 8X-ում](ds_extender_guide.md)
* [Տվյալների աղբյուրի պարամետրերի ընդլայնում 8X-ում](ds_extender_param_guide.md)
* [Ընդլայնման միջոցով պարամետրի ավելացման ամբողջական օրինակ](../examples/ds_extender_addparam.md)

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
Ընդլայնման ներքին անունը (առավ. 50 նիշ)։

### CAPTION 
Ընդլայնման հայերեն անվանումը ANSI կոդավորմամբ։

### ECAPTION 
Ընդլայնման անգլերեն անվանումը։

### DATASOURCE 
Ընդլայնվող տվյալների աղբյուրի ներքին անունը։

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

Տվյալների աղբյուրի ընդլայման համար անհրաժեշտ է սահմանել դաս, որը ժառանգում է `Extender<R, P>` դասը՝ որպես `R` փոխանցելով տվյալների աղբյուրի ընդլայման սյուները նկարագրող դասը, իսկ որպես `P`՝ պարամետրերը նկարագրող դասը։  
Եթե նոր պարամետր չի ավելացվում ընդլայնմամբ, ապա որպես `P` անհրաժեշտ է փոխանցել `NoParam` դասը։
Եթե նոր սյուն չի ավելացվում ընդլայնմամբ, ապա որպես `R` անհրաժեշտ է փոխանցել `NoColumns` դասը։

Դասը պարտադիր պետք է ունենա `DataSourceExtender` ատրիբուտը։ 
* Եթե դասի անունը համընկնում է .as ֆայլում նկարագրված [ներքին անվան](#name) հետ, ապա ատրիբուտին արժեք փոխանցելու կարիք չկա:

  **Օրինակ**
  ```as4x
  DSEXTENDER {
    NAME = AllOperExtended;
    ...
  };
  ```
  
  ```c#
  [DataSourceExtender]
  public class AllOperExtended : Extender<NoColumns, AllOperExtended.Params>
  ```

* Եթե դասի անունը չի համընկնում .as ֆայլում նկարագրված [ներքին անվան](#name) հետ, ապա ատրիբուտին պետք է փոխանցել ընդլայնման [ներքին անունը](#name)։

  **Օրինակ**
  ```as4x
  DSEXTENDER {
    NAME = AllOperExt;
    ...
  };
  ```
  
  ```c#
  [DataSourceExtender("AllOperExt")]
  public class AllOperExtended : Extender<NoColumns, AllOperExtended.Params>
  ```

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

* `name` - Պարամետրի ներքին անունը։
* `description` - Պարամետրի հայերեն նկարագրությունը։ Անհրաժեշտ է փոխանցել ANSI կոդավորմամբ։
* `fieldType` - Պարամետրի համակարգային տիպը:

### BeforeProcess

```c#
public virtual Task BeforeProcess(IList<IExtendableRow> rows, IDataSourceArgs args)
```

Մեթոդը կանչվում է միջուկի կողմից տվյալների աղբյուրի հիմնական հաշվարկի ավարտից հետո։  
Հիմնականում օգտագործվում է [ProccessRow](#proccessrow)-ում կիրառվող տվյալների բեռնման և քեշավորման համար։  
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
