---
layout: page
title: "Սերվերային մոդուլ (SERVERSIDEMODULE)" 
---

## Բովանդակություն

- [Ներածություն](#ներածություն)
- [SERVERSIDEMODULE նկարագրություն](#serversidemodule-նկարագրություն)
- [Հատկություններ](#հատկություններ)
  - [NAME](#name)
  - [CAPTION](#caption)
  - [ECAPTION](#ecaption)
  - [CSSOURCE](#cssource)

## Ներածություն

8X համակարգում տարատեսակ ընդլայնումների և կազմակերպությանը յուրահատուկ սերվերային տրամաբանություն մշակելու համար նկարագրվում է սերվերային մոդուլ։
Հիմնականում օգտագործվում է [տպելու ձևերի ընդլայնման](template_substitution.md) նկարագրման համար։

Տե՛ս նաև
* [Տպելու ձևերի ընդլայնման նկարագրություն](template_substitution.md)
* [Տպելու ձևերի ընդլայնման ձեռնարկ](template_substitution_guide.md)

8X համակարգում սերվերային մոդուլ նկարագրելու համար հարկավոր է ունենալ

* .as ընդլայնմամբ ֆայլ սկրիպտերում SERVERSIDEMODULE նկարագրությամբ, որը պարունակում է մետատվյալներ ընդլայնման մասին,
* .cs ընդլայնմամբ ֆայլ, որը պարունակում է սերվերում աշխատող տրամաբանությունը։

.as և .cs ընդլայնմամբ ֆայլերը լրացնելուց հետո անհրաժեշտ է .as ընդլայնմամբ ֆայլը ներմուծել համակարգ `SYSCON` գործիքի միջոցով, որի արդյունքում կներմուծվի նաև .cs ընդլայնմամբ ֆայլը։

## SERVERSIDEMODULE նկարագրություն

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
