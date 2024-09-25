---
layout: page
title: "DPR Երկար աշխատող պրոցեսի նկարագրություն" 
---

## Բովանդակություն

- [Ներածություն](#ներածություն)
- [DataProcessingRequest դաս](#dataprocessingrequest-դաս)
- [Հատկություններ](#հատկություններ)
  - [ArmenianCaption](#armeniancaption)
  - [EnglishCaption](#englishcaption)
  - [IsParametersSupported](#isparameterssupported)
  - [Name](#name)
  - [Progress](#progress)
  - [DPRType](#dprtype)
  - [IsCancellationSupported](#iscancellationsupported)
  - [PhasesCount](#phasescount)
- [Մեթոդներ](#մեթոդներ)
  - [Execute](#execute)

## Ներածություն

Սերվիսային երկար տևող հարցումներ կատարելու ու կատարման ընթացքին հետևելու համար նկարագրվում է DPR (Data Processing Request):

8X համակարգում DPR նկարագրելու համար հարկավոր է ունենալ .cs ընդլայնմամբ ֆայլ, որը պարունակում է սերվերում աշխատող տրամաբանությունը։

Կազմակերպության սեփական DPR-ների ստեղծման համար [տե՛ս](../../extensions/definitions/dpr_new_guide.md):

## DataProcessingRequest դաս

DPR-ի համար անհրաժեշտ է սահմանել դաս, որը ժառանգում է `DataProcessingRequest<R, P>` դասը՝ որպես R փոխանցելով DPR-ի կատարման արդյունքում ստացվող տվյալները նկարագրող դասը, իսկ որպես P՝ պարամետրերը նկարագրող դասը և ունի DPR-ի տեսակը, հայերեն, անգլերեն անվանումները պարունակող `DPR` ատրիբուտը։

**Օրինակ**

```c#
[DPR(DPRType = Common.DPRType.Other, ArmenianCaption = "Փաստաթղթի դաշտերի խմբագրում", EnglishCaption = "Document's fields' edition")]
public class EditDocumentsFields : DataProcessingRequest<EditFieldsResponse, EditFieldsRequest>
```

## Հատկություններ

### ArmenianCaption

```c#
public string ArmenianCaption { get; }
```

Վերադարձնում է DPR-ի հայերեն անվանումը:

### EnglishCaption

```c#
public string EnglishCaption { get; }
```

Վերադարձնում է DPR-ի անգլերեն անվանումը:

### IsParametersSupported

```c#
public bool IsParametersSupported { get; }
```

Ցույց է տալիս DPR-ի ունի պարամետրեր թե ոչ:

### Name

```c#
public string Name { get; }
```

Վերադարձնում է DPR-ի ներքին անունը:

### Progress

Վերադարձնում է DPR-ի կատարման պրոգրեսը:

```c#
public DataSourceExecutionProgress Progress { get; }
```
---

### DPRType

```c#
public DPRType DPRType { get; private set; }
```

Վերադարձնում է DPR-ի տեսակը։

### IsCancellationSupported

```c#
public virtual bool IsCancellationSupported { get { return true; } }
```

Ցույց է տալիս թե DPR-ի կատարումը սատարում է չեղարկումը(cancellation) թե ոչ։

### PhasesCount

```c#
public virtual short PhasesCount { get { return 1; } }
```

Ցույց է տալիս է DPR-ի կատարման փուլերի քանակը:

## Մեթոդներ

### Execute

```c#
public abstract Task<R> Execute(P p, CancellationToken stoppingToken)
```

Կատարում է DPR-ը։

**Պարամետրեր**

- `R` - Կատարման արդյունքում վերադարձվող տվյալները նկարագրող դաս:
- `p` - Կատարման համար անհրաժեշտ պարամետրերը նկարագրող դաս։
- `stoppingToken` - Չեղարկման տոկենը։