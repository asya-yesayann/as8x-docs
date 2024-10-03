---
layout: page
title: "Նոր DPR Երկար աշխատող պրոցեսի ավելացնելու ձեռնարկ"
---

## ԲոՎանդակություն

- [Ներածություն](#ներածություն)
- [DPR նկարագրություն](#dpr-նկարագրություն)
- [DSEXTENDER նկարագրություն](#dsextender-նկարագրություն)
- [Հատկություններ](#հատկություններ)
  - [NAME](#name)
  - [CAPTION](#caption)
  - [ECAPTION](#ecaption)
  - [TYPE](#type)
  - [VERSION](#version)
  - [CSSOURCE](#cssource)

## Ներածություն

Հնարավորություն է տրվում ընդլայնել 8X-ի սերվիսը, ստեղծելով կազմակերպության սեփական DPR:  
Ստորև նկաարգրված են այն քայլերը, որոնք յուրահատուկ են կազմակերպության սեփական DPR ստեղծելու համար։  
DPR-ի ստեղծման հիմնական քայլերը տե՛ս [ձեռնարկում](../../server_api/definitions/dpr_guide.md)։

DPR-ի նկարագրման համար հարկավոր է ունենալ՝

* .as ընդլայնմամբ ֆայլ `DPR` նկարագրությամբ, որը պարունակում Է DPR-ի մետատվյլաները,
* .cs ընդլայնմամբ ֆայլ, որը պարունակում է սերվերում աշխատող տրամաբանությունը։

Ստեղծված .as և .cs ֆայլերը հարկավոր է ներմուծել տվյալների բազա `SysCon` գործիքով։

## DPR նկարագրություն

## DSEXTENDER նկարագրություն

``` as4x
DSEXTENDER {
  NAME = ...;
  CAPTION = ...;
  ECAPTION = ...;
  TYPE = ...;
  VERSION = ...;
  CSSOURCE = ...;
};
```

## Հատկություններ

### NAME

DPR-ի ներքին անունը։

### CAPTION 

DPR-ի հայերեն անվանումը ANSI կոդավորմամբ։

### ECAPTION

DPR-ի անգլերեն անվանումը։

### TYPE 

DPR-ի տեսակը։

### VERSION 

DPR-ի տարբերակը։

### CSSOURCE 
Ընդլայնող C# ֆայլի [հարաբերական ճանապարհը](https://phoenixnap.com/kb/absolute-path-vs-relative-path) .as ֆայլի նկատմամբ։

Օրինակներ՝  
* Եթե extend.as և extend.cs ֆայլերը գտնվում են նույն թղթապանակում, ապա կգրվի `CSSOURCE = "extend.cs";`։  
* Եթե extend.as գտվում է "C:\WorkingDir\Scripts\App\extend.as" հասցեում, իսկ extend.cs-ը՝ "C:\WorkingDir\SubFolder1\SubFolder2\extend.as" հասցեում, ապա `CSSOURCE = "..\..\SubFolder1\SubFolder2\extend.cs";`։  
* Կամ կլինի գրել ամբողջական ճանապարհը, ինչը խրախուսելի չէ `CSSOURCE = "C:\WoringDir\SubFolder1\SubFolder2\extend.cs";`



