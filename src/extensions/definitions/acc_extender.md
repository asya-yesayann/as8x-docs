---
layout: page
title: "Հաշվառման ընդլայնում"
tags: [Accounting, ACCEXTENDER]
---

## Բովանդակություն

- [Ներածություն](#ներածություն)
- [ACCEXTENDER](#accextender)
- [Հատկություններ](#հատկություններ)
  - [NAME](#name)
  - [CAPTION](#caption)
  - [ECAPTION](#ecaption)
  - [CSSOURCE](#cssource)
- [DocumentExtender դաս](#documentextender-դաս)
- [Մեթոդներ](#մեթոդներ)
  - [PreOnDelete](#preondelete)
  - [PostOnDelete](#postondelete)


## Ներածություն

Գոյություն ունեցող հաշվառումների մշակման գործընթացում սեփական տրամաբանություն ավելացնելու համար նկարագրվում է հաշվառման ընդլայնում։
Հաշվառման ընդլայնումը իրենից ներկայացնում է վիրտուալ մեթոդների բազմություն, որոնք կանչվում են հաշվառման հիմնական իրադարձություններից առաջ և հետո։

8X համակարգում փաստաթղթի ընդլայնում նկարագրելու համար հարկավոր է ունենալ

* .as ընդլայնմամբ ֆայլ սկրիպտերում ACCEXTENDER նկարագրությամբ, որը պարունակում է մետատվյալներ ընդլայնման մասին,
* .cs ընդլայնմամբ ֆայլ, որը պարունակում է սերվերում աշխատող տրամաբանությունը։

## ACCEXTENDER

``` as4x
ACCEXTENDER {
  NAME = ...;
  CAPTION = ...;
  ECAPTION = ...;
  CSSOURCE = ...;
};
```

## Հատկություններ

### NAME
Ընդլայնվող հաշվառման ներքին անունը։

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

Հաշվառման ընդլայնման համար անհրաժեշտ է սահմանել դաս, որը ժառանգում է `AccountingExtender` դասը և ունի `AccountingExtender` ատրիբուտը։

```c#
[AccountingExtender]
public class SyntAccountingExtender : AccountingExtender
```

## Մեթոդներ

### PreOnDelete

```c#
public virtual Task PreOnDelete(Accounting sender, OnDeleteEventArgs onDeleteEventArgs);
```

PreOnDelete իրադարձությունը առաջանում է հաշվառումը ջնջելու ժամանակ` հաշվառման OnDelete իրադարձությունից առաջ։ 

**Պարամետրեր**
* `sender` - Հաշվառումը նկարագրող դասը։
* `onDeleteEventArgs` - Հաշվառման գործառնությունները նկարագրող դասը։

### PostOnDelete

```c#
public virtual Task PostOnDelete(Accounting sender, OnDeleteEventArgs onDeleteEventArgs);
```

PreOnDelete իրադարձությունը առաջանում է հաշվառումը ջնջելու ժամանակ` հաշվառման OnDelete իրադարձությունից հետո։ 

**Պարամետրեր**
* `sender` - Հաշվառումը նկարագրող դասը։
* `onDeleteEventArgs` - Հաշվառման գործառնությունները նկարագրող դասը։
