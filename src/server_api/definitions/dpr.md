---
layout: page
title: "Տվյալների մշակման հարցման նկարագրություն (DPR)"
tags: [DPR]
sublinks:
- { title: "DataProcessingRequest դաս", ref: dataprocessingrequest-դաս }
- { title: "ArmenianCaption", ref: armeniancaption }
- { title: "EnglishCaption", ref: englishcaption }
- { title: "Name", ref: name }
- { title: "Progress", ref: progress }
- { title: "DPRType", ref: dprtype }
- { title: "IsCancellationSupported", ref: iscancellationsupported }
- { title: "AfterDeserializeParameter", ref: afterdeserializeparameter }
- { title: "Execute", ref: execute }
---

## Բովանդակություն

- [Ներածություն](#ներածություն)
- [DataProcessingRequest դաս](#dataprocessingrequest-դաս)
- [Հատկություններ](#հատկություններ)
  - [ArmenianCaption](#armeniancaption)
  - [EnglishCaption](#englishcaption)
  - [Name](#name)
  - [Progress](#progress)
  - [DPRType](#dprtype)
  - [IsCancellationSupported](#iscancellationsupported)
- [Մեթոդներ](#մեթոդներ)
  - [AfterDeserializeParameter](#afterdeserializeparameter)
  - [Execute](#execute)

## Ներածություն

Սերվիսային երկար տևող հարցումներ կատարելու և կատարման ընթացքին հետևելու համար նկարագրվում է Տվյալների մշակման հարցում (DPR - Data Processing Request): 

Տե՛ս [Ասինխրոն մշակում կիրառությունների սերվերի վրա](../../architecture/appserver_async.md)։

Տվյալների մշակման հարցման (`DPR`-ի) նկարագրության համար հարկավոր է նկարագրել սերվերում աշխատող տրամաբանությունը C# դասում (`.cs` ֆայլում)։  
Հարկավոր է սահմանել մուտքային և ելքային պարամետրերի դասեր (կարելի է օգտագործել գոյություն ունեցողները)։

Տվյալների մշակման հարցման (`DPR`-ի) ստեղծման ձեռնարկը տե՛ս [այստեղ](dpr_guide.md)։  

Կազմակերպության սեփական Տվյալների մշակման հարցումների (`DPR`-ի) ստեղծման համար [տե՛ս](../../extensions/definitions/dpr_new_guide.md):

## DataProcessingRequest դաս

Տվյալների մշակման հարցման (`DPR`-ի) համար անհրաժեշտ է`
* սահմանել դաս, որը ժառանգում է `DataProcessingRequest<R, P>` դասը՝ որպես `R` փոխանցելով հարցման կատարման արդյունքում ստացվող տվյալները նկարագրող դասը, իսկ որպես `P`՝ պարամետրերը նկարագրող դասը
* Այդ դասին վրա դնել [DPR ատրիբուտը](../types/DPRAttribute.md)՝ նշելով DPR-ի տեսակը, հայերեն, անգլերեն անվանումները և թույլատրված է ընդհատումը UI-ից թե ոչ (չնշելու դեպքում լռությամբ թույլատրվում է ընդհատումը UI-ից)

**Օրինակ**

```c#
[DPR(DPRType = DPRType.Other, ArmenianCaption = "Փաստաթղթի դաշտերի խմբագրում", EnglishCaption = "Document's fields' edition", 
    IsCancellationSupported = FeatureAvailability.Disabled)]
public class EditDocumentsFields : DataProcessingRequest<EditFieldsResponse, EditFieldsRequest>
{
  //...
}
```

## Հատկություններ

### ArmenianCaption

```c#
public string ArmenianCaption { get; }
```

Վերադարձնում է հայերեն անվանումը ANSI կոդավորմամբ:

### EnglishCaption

```c#
public string EnglishCaption { get; }
```

Վերադարձնում է անգլերեն անվանումը:

<!-- ### IsParametersSupported

```c#
public bool IsParametersSupported { get; }
```

Ցույց է տալիս DPR-ի ունի պարամետրեր թե ոչ: -->

### Name

```c#
public string Name { get; }
```

Վերադարձնում է ներքին անունը: 

Եթե [DPR ատրիբուտում](../types/DPRAttribute.md) `Name` դաշտը լրացված է և դատարկ չէ, ապա վերադարձնում է այդ արժեքը, հակառակ դեպքում վերադարձնում է DPR-ը նկարագրող դասի անունը։ 

### Progress

```c#
public DPRExecutionProgress Progress { get; }
```

Վերադարձնում է Տվյալների մշակման հարցման կատարման պրոգրեսը:

Այս օբյեկտի միջոցով հնարավոր է կառավարել աշխատանքի փուլերը, UI-ում ցույց տալ այդ փուլերը և UI-ում ցույց տալ հաղորդագրության պատուհան ([MessageBox](../types/UIRequestExecutionProgress.md#messagebox-1)):

Տե՛ս օգտագործման [օրինակը](../examples/dpr/code.md)։

### DPRType

```c#
public DPRType DPRType { get; }
```

Վերադարձնում է տեսակը, որը լրացված է նկարագրվող դասի վրա [DPR ատրիբուտի](../types/DPRAttribute.md) մեջ։

* **DPRType.Report** - Հաշվետվությունների տվյալների մշակման հարցում
* **DPRType.OLAP** - Օլապ տվյալների մշակման հարցում
* **DPRType.JobElement** - Առաջադրանքների տվյալների մշակման հարցում
* **DPRType.Other** - Այլ տվյալների մշակման հարցում

### IsCancellationSupported

```c#
public virtual bool IsCancellationSupported { get { return true; } }
```

Այս մշակվող հատկության միջոցով հնարավոր է թույլատրել կամ արգելել UI-ից պրոցեսի դադարեցման (cancellation) հնարավորությունը։

## Մեթոդներ

### AfterDeserializeParameter

```c#
protected virtual Task AfterDeserializeParameter(P parameter, JsonElement jsonElement)
```

Մեթոդը կանչվում է միջուկի կողմից DPR-ը հերթագրման դնելուց առաջ։
Այն հարկավոր է մշակել, եթե հարկավոր է փոխանցված պարամետրերի ստուգումներ կատարել, կամ մուտքային պարամետրերը ձևափոխել։
Մեթոդի կանչից առաջ `parameter`-ը արդեն իսկ ձևավորված է ըստ ցանցով փոխանցված JSON-ի։

**Պարամետրեր**

- `parameter` - Մուտքային պարամետրերի նկարագրված դասի օբյեկտ։ 
- `jsonElement` - Փոխանցված JSON օբյեկտի մեջ։

### Execute

```c#
public abstract Task<R> Execute(P p, CancellationToken stoppingToken)
```

Մեթոդը կանչվում է միջուկի կողմից, այստեղ հարկավոր է մշակել սերվերում աշխատող տրամաբանությունը։

**Պարամետրեր**

- `R` - Կատարման արդյունքում վերադարձվող տվյալները նկարագրող դաս:
- `p` - Մուտքային պարամետրերի նկարագրված դասի օբյեկտ։
- `stoppingToken` - Դադարեցման տոկենը։

Տե՛ս օգտագործման [օրինակը](dpr_guide.md#execute)։