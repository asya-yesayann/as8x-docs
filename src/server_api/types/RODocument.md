---
layout: page
title: "RODocument դաս" 
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
  - [indexer](#indexer)
  - [ISN](#isn)
  - [LastLookup](#lastlookup)
  - [LastTSCheck](#lasttscheck)
  - [TimeStamp](#timestamp)
  - [State](#state)
- [Մեթոդներ](#մեթոդներ)
  - [CheckGrid](#checkgrid)
  - [CheckImage](#checkimage)
  - [CheckMemo](#checkmemo)
  - [RefreshLastLookup](#refreshlastlookup)
  - [RefreshLastTSCheck](#refreshlasttscheck)

## Ներածություն

RODocument դասը նախատեսված է փաստաթուղթը քեշավորելու համար։

RODocument տիպի քեշավորվող փաստաթղթերը ժառանգում են `RODocument` դասից և ունեն փաստաթղթի ներքին անունը պարունակող `RODocument` ատրիբուտը։

```c#
[RODocument("Cli")]
public class Client : RODocument
```

Փաստաթղթին համապատասխան քեշավորվող փաստաթուղթը գեներացվում է ավտոմատ [Codegen](../CodeGen/CodeGen.md) գործիքի միջոցով։

RODocument տեսակի փաստաթուղթը տվյալների պահոցից բեռնելու, քեշում պահելու և քեշից կարդալու համար տե՛ս [RODocumentService](../services/RODocumentService.md):

## Հատկություններ

### Archived 

```c#
public bool Archived { get; private set; }
```

Ցույց է տալիս փաստաթղթի արխիվացված լինելը։

### CreationDate 

```c#
public DateTime CreationDate { get; private set; }
```

Վերադարձնում է փաստաթղթի ստեղծման ամսաթիվը/ժամանակը։

### CreatorSUID

```c#
public short CreatorSUID { get; private set; }
```

Վերադարձնում է փաստաթուղթը ստեղծողի ներքին համարը (user id):

### Description 

```c#
public DocumentDescription Description { get; private set; }
```

Վերադարձնում է փաստաթղթի նկարագրությունը։

### DocumentType

```c#
public string DocumentType { get; }
```

Վերադարձնում է փաստաթղթի տեսակը։

### Fields

```c#
public Dictionary<string, object> Fields { get; private set; }
```

Վերադարձնում է փաստաթղթի դաշտերը որպես dictionary, որտեղ բանալին՝ դաշտի ներքին անունն է, իսկ արժեքը՝ դաշտի արժեքը:

### indexer

```c#
public object this[string name] { get; }
```

Վերադարձնում է փաստաթղթի տրված ներքին անունով դաշտի արժեքը։

**Պարամետրեր**

* `name` - Դաշտի ներքին անունը։

### ISN

```c#
public int ISN { get; private set; }
```

Վերադարձնում է փաստաթղթի ներքին նույնականացման համարը (isn-ը):

### LastLookup

```c#
public DateTime LastLookup { get; private set; }
```

Վերադարձնում է փաստաթղթի քեշում փնտրման և քեշից բեռնման վերջին ամսաթիվը/ժամանակը:

Փաստաթուղթը քեշից բեռնելու համար անհրաժեշտ է կանչել [RODocumentService](../services/RODocumentService.md).[LookUpInCache](../services/RODocumentService.md#lookupincache) մեթոդը։

### LastTSCheck

```c#
public DateTime LastTSCheck { get; private set; }
```

Վերադարձնում է փաստաթղթի [TimeStamp](#timestamp)-ի տվյալների պահոցից վերջին ստուգման ամսաթիվը/ժամանակը:

### TimeStamp

```c#
public byte[] TimeStamp { get; set; }
```

Նշանակում է կամ վերադարձնում փաստաթղթի վերջին փոփոխման ամսաթիվը և ժամանակը` որպես byte տիպի զանգված:

### State

```c#
public short State { get; set; }
```

Վերադարձնում կամ նշանակում է փաստաթղթի վիճակը:

## Մեթոդներ

### CheckGrid

```c#
protected void CheckGrid()
```

Ստուգում է փաստաթղթի աղյուսակների բեռնված լինելը։

Բեռնված չլինելու դեպքում առաջացնում է սխալ։

### CheckImage

```c#
protected void CheckImage()
```

Ստուգում է փաստաթղթի նկարների բեռնված լինելը։

Բեռնված չլինելու դեպքում առաջացնում է սխալ։

### CheckMemo

```c#
protected void CheckMemo()
```

Ստուգում է փաստաթղթի մեծ տեքստային դաշտերի (մեմո) բեռնված լինելը։

Բեռնված չլինելու դեպքում առաջացնում է սխալ։

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
