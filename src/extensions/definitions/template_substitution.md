---
layout: page
title: "Տպելու ձևերի ընդլայնում"
tags:
- TemplateSubstitutionExtender
- ITemplateSubstitutionExtender
- TemplateSubstitution
---

## Բովանդակություն

- [Ներածություն](#ներածություն)
- [.as ֆայլի նկարագրություն](#as-ֆայլի-նկարագրություն)
- [Հատկություններ](#հատկություններ)
  - [NAME](#name)
  - [CAPTION](#caption)
  - [ECAPTION](#ecaption)
  - [CSSOURCE](#cssource)
- [C# ֆայլի նկարագրություն](#c-ֆայլի-նկարագրություն)
- [ITemplateSubstitutionExtender ինտերֆեյս](#itemplatesubstitutionextender-ինտերֆեյս)
- [Մեթոդներ](#մեթոդներ)
  - [Calculate](#calculate)

## Ներածություն

Գոյություն ունեցող տպելու ձևանմուշների պարամետրերի հաշվարկի տրամաբանությունը փոփոխելու համար նկարագրվում է տպելու ձևանմուշի ընդլայնում։

8X համակարգում տվյալների աղբյուրի ընդլայնում նկարագրելու համար հարկավոր է ունենալ

* .as ընդլայնմամբ ֆայլ սկրիպտերում SERVERSIDEMODULE նկարագրությամբ, որը պարունակում է մետատվյալներ ընդլայնման մասին,
* .cs ընդլայնմամբ ֆայլ, որը պարունակում է սերվերում աշխատող տրամաբանությունը։

## .as ֆայլի նկարագրություն

```as4x
SERVERSIDEMODULE {
  NAME = ...;
  CAPTION = ...;
  ECAPTION = ...;
  CSSOURCE = ...;
};
```

## Հատկություններ

### NAME
Ընդլայնման ներքին անունը։

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

## C# ֆայլի նկարագրություն

Տպելու ձևանմուշի ընդլայնման համար անհրաժեշտ է սահմանել դաս, որը իրականացնում է `ITemplateSubstitutionExtender` ինտերֆեյսը և ունի `TemplateSubstitutionExtender` ատրիբուտը։

**Օրինակ**

```c#
[TemplateSubstitutionExtender]
public class BusTripExtended : ITemplateSubstitutionExtender 
```

## ITemplateSubstitutionExtender ինտերֆեյս

Այս ինտերֆեյսը նախատեսված է տպելու ձևանմուշների ընդլայնման դասերի սահմանման համար։

## Մեթոդներ

### Calculate

```c#
public Task Calculate(TemplateSubstitutionExtenderArgs templateSubstitutionExtenderArgs);
```

Իրականացնում է տպելու ձևանմուշի ընդլայնման պարամետրերի հաշվարկը։

**Պարամետրեր**
* `templateSubstitutionExtenderArgs` - Տպելու ձևանմուշի պարամետրերը նկարագրող դասը։
