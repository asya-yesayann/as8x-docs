---
layout: page
title: "LiteDocument դաս" 
tags: [cache, Document, AsDoc]
---

## Բովանդակություն

- [Ներածություն](#ներածություն)
- [Հատկություններ](#հատկություններ)
  - [Archived](#archived)
  - [CreationDate](#creationdate)
  - [CreatorSUID](#creatorsuid)
  - [Description](#description)
  - [DocumentType](#documenttype)
  - [Fields](#fields)
  - [Grids](#grids)
  - [GridsInitialized](#gridsinitialized)
  - [GridsLoaded](#gridsloaded)
  - [GridsLoading](#gridsloading)
  - [indexer](#indexer)
  - [ISN](#isn)
  - [LastLookup](#lastlookup)
  - [LastTSCheck](#lasttscheck)
  - [TimeStamp](#timestamp)
  - [State](#state)
- [Մեթոդներ](#մեթոդներ)
  - [ExistsRekvizit](#existsrekvizit)
  - [InitGrids](#initgrids)
  - [LoadGrids](#loadgrids)
  - [RefreshLastLookup](#refreshlastlookup)
  - [RefreshLastTSCheck](#refreshlasttscheck)

## Ներածություն

LiteDocument դասը նախատեսված է փաստաթուղթը քեշավորելու համար։

LiteDocument տեսակի փաստաթուղթը տվյալների պահոցից բեռնելու, քեշում պահելու և քեշից կարդալու համար տե՛ս [LiteDocumentService](../services/LiteDocumentService.md):

## Հատկություններ

### Archived 

```c#
public bool Archived { get; internal set; }
```

Ցույց է տալիս փաստաթղթի արխիվացված լինելը։

### CreationDate 

```c#
public DateTime CreationDate { get; internal set; }
```

Վերադարձնում է փաստաթղթի ստեղծման ամսաթիվը/ժամանակը։

### CreatorSUID

```c#
public short CreatorSUID { get; internal set; }
```

Վերադարձնում է փաստաթուղթը ստեղծողի ներքին համարը (user id):

### Description 

```c#
public DocumentDescription Description { get; internal set; }
```

Վերադարձնում է փաստաթղթի նկարագրությունը։

### DocumentType

```c#
public string DocumentType
```

Վերադարձնում է փաստաթղթի տեսակը։

### Fields

```c#
public Dictionary<string, object> Fields { get; private set; }
```

Վերադարձնում է փաստաթղթի դաշտերը որպես dictionary, որտեղ բանալին՝ դաշտի ներքին անունն է, իսկ արժեքը՝ դաշտի արժեքը:

### Grids

```c#
public IReadOnlyDictionary<string, IGrid> Grids { get; private set; }
```

Վերադարձնում է փաստաթղթի աղյուսակների բազմությունը՝ որտեղ բանալին աղյուսակի ներքին անունն է, իսկ արժեքը՝ աղյուսակը IGrid ինտերֆեյսով։

### GridsInitialized

```c#
public bool GridsInitialized { get; protected internal set; }
```

Ցույց է տալիս փաստաթղթի աղյուսակների ձևավորված լինելը։ 

### GridsLoaded

```c#
public bool GridsLoaded { get; protected internal set; }
```

Ցույց է տալիս փաստաթղթի աղյուսակների բեռնված լինելը։ 
Տե՛ս [Load](../services/LiteDocumentService.md#load), [LoadGrids](../services/LiteDocumentService.md#loadgrids)։

### GridsLoading 

```c#
public bool GridsLoading { get; internal set; } = false;
```

Ցույց է տալիս փաստաթղթի աղյուսակները գտնվում են բեռնման պրոցեսում թե ոչ։

### indexer

```c#
public object this[string name] { get; set; }
```

Վերադարձնում կամ նշանակում է փաստաթղթի տրված ներքին անունով դաշտի արժեքը։

**Պարամետրեր**

* `name` - Դաշտի ներքին անունը։

### ISN

```c#
public int ISN { get; internal set; }
```

Վերադարձնում է փաստաթղթի ներքին նույնականացման համարը (isn-ը):

### LastLookup

```c#
public DateTime LastLookup { get; private set; }
```

Վերադարձնում է փաստաթղթի քեշում փնտրման և քեշից բեռնման վերջին ամսաթիվը/ժամանակը:

Փաստաթուղթը քեշից բեռնելու համար անհրաժեշտ է կանչել [LiteDocumentService](../services/LiteDocumentService.md).[LookUpInCache](../services/LiteDocumentService.md#lookupincache) մեթոդը։

### LastTSCheck

```c#
public DateTime LastTSCheck { get; private set; }
```

Վերադարձնում է փաստաթղթի [TimeStamp](#timestamp)-ի տվյալների պահոցից վերջին ստուգման ամսաթիվը/ժամանակը:

### TimeStamp

```c#
byte[] IDocumentCache.TimeStamp { get; set; }
```

Նշանակում է կամ վերադարձնում փաստաթղթի վերջին փոփոխման ամսաթիվը և ժամանակը` որպես byte տիպի զանգված:

### State

```c#
public short State { get; set; }
```

Վերադարձնում կամ նշանակում է փաստաթղթի վիճակը:

## Մեթոդներ

### ExistsRekvizit

```c#
public bool ExistsRekvizit(string rekv);
```

Ստուգում է տրված ներքին անունով դաշտի առկայությունը փաստաթղթի նկարագրության մեջ։

**Պարամետրեր**

* `rekv` - Դաշտի ներքին անունը։

### InitGrids

```c#
protected void InitGrids();
```

Ձևավորում է փաստաթղթի աղյուսակները՝ առանց տվյալների բեռնելու։ 

### LoadGrids

```c#
public Task LoadGrids(IDBService dBService, ArchiveInfo archiveInfo = null)
```

Բեռնում է փաստաթղթի աղյուսակները տվյալների պահոցից և ավելացնում փաստաթղթում։

**Պարամետրեր**

* `dBService` - [IDBService](../services/IDBService.md) դասի օբյեկտ տվյալների պահոցի հետ կապը հաստատելու համար։
* `archiveInfo` - ArchiveInfo դասի օբյեկտ, որը պարունակում է արխիվացված փաստաթուղթը պարունակող տվյալների պահոցի անունը և [IDBService](../services/IDBService.md) դասի օբյեկտ՝ այդ պահոցի հետ Sql միացում ապահովելու համար։

### RefreshLastLookup

```c#
public void RefreshLastLookup();
```

Թարմացնում է [LastLookup](#lastlookup) հատկության արժեքը՝ նշանակելով ընթացիկ ամսաթիվը/ժամանակը։

### RefreshLastTSCheck

```c#
public void RefreshLastTSCheck();
```

Թարմացնում է [LastTSCheck](#lasttscheck) հատկության արժեքը՝ նշանակելով ընթացիկ ամսաթիվը/ժամանակը։
