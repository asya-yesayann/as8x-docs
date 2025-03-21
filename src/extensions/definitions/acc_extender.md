---
layout: page
title: "Հաշվառման ընդլայնման նկարագրություն"
tags: [Accounting, ACCEXTENDER]
---

## Բովանդակություն

- [Բովանդակություն](#բովանդակություն)
- [Ներածություն](#ներածություն)
- [ACCEXTENDER նկարագրություն](#accextender-նկարագրություն)
- [Հատկություններ](#հատկություններ)
  - [NAME](#name)
  - [CAPTION](#caption)
  - [ECAPTION](#ecaption)
  - [CSSOURCE](#cssource)
- [AccountingExtender դաս](#accountingextender-դաս)
- [Մեթոդներ](#մեթոդներ)
  - [PreOnDelete](#preondelete)
  - [PostOnDelete](#postondelete)

## Ներածություն

Գոյություն ունեցող հաշվառումների մշակման գործընթացում սեփական տրամաբանություն ավելացնելու համար նկարագրվում է հաշվառման ընդլայնում։
Հաշվառման ընդլայնումը իրենից ներկայացնում է վիրտուալ մեթոդների բազմություն, որոնք կանչվում են հաշվառման հիմնական իրադարձություններից առաջ և հետո։

8X համակարգում փաստաթղթի ընդլայնում նկարագրելու համար հարկավոր է ունենալ`

* .as ընդլայնմամբ ֆայլ սկրիպտերում [ACCEXTENDER](#accextender-նկարագրություն) նկարագրությամբ, որը պարունակում է մետատվյալներ ընդլայնման մասին,
* .cs ընդլայնմամբ ֆայլ, որը պարունակում է սերվերում աշխատող տրամաբանությունը։

.as և .cs ընդլայնմամբ ֆայլերը լրացնելուց հետո անհրաժեշտ է .as ընդլայնմամբ ֆայլը ներմուծել համակարգ `SYSCON` գործիքի միջոցով, որի արդյունքում կներմուծվի նաև .cs ընդլայնմամբ ֆայլը։

## ACCEXTENDER նկարագրություն

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
Եթե ընդլայնումը [դինամիկ](../../architecture/extension.md#ընդլայնումների-ավելացում-syscon-գործիքով-ներմուծման-միջոցով) է, ապա անհրաժեշտ է ավելացնել նաև `CSSOURCE` դաշտը, որը պարունակում է սերվիսային տրամաբանության C# ֆայլի [հարաբերական ճանապարհը](https://phoenixnap.com/kb/absolute-path-vs-relative-path) .as ֆայլի նկատմամբ։

Տե՛ս նաև [Նկարագրության CSSOURCE դաշտում հարաբերական ճանապարհի լրացման օրինակներ](../../server_api/examples/relative_path_examples.md):

## AccountingExtender դաս

Հաշվառման ընդլայնման համար անհրաժեշտ է սահմանել դաս, որը ժառանգում է `AccountingExtender` դասը և ունի `AccountingExtender` ատրիբուտը։

**Օրինակ**

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
