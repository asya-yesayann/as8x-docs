---
layout: page
title: "DataSource դաս" 
tags: DS
sublinks:
- { title: "Client", ref: client }
- { title: "Definition", ref: definition }
- { title: "ExtenderSchema", ref: extenderschema }
- { title: "FetchSize", ref: fetchsize }
- { title: "FirstFetchSize", ref: firstfetchsize }
- { title: "EncodeResultUnicode", ref: encoderesultunicode }
- { title: "ExecuteAsync", ref: executeasync }
- { title: "LoadDefinitionAsync", ref: loaddefinitionasync }
- { title: "LongExecuteAsync", ref: longexecuteasync }
---

## Բովանդակություն

- [Ներածություն](#ներածություն)
- [Հատկություններ](#հատկություններ)
  - [Client](#client)
  - [Definition](#definition)
  - [ExtenderSchema](#extenderschema)
  - [FetchSize](#fetchsize)
  - [FirstFetchSize](#firstfetchsize)
  <!-- - [ShowProgress](#showprogress) -->
  - [EncodeResultUnicode](#encoderesultunicode)
- [Մեթոդներ](#մեթոդներ)
  - [ExecuteAsync](#executeasync)
  - [LoadDefinitionAsync](#loaddefinitionasync)
  - [LongExecuteAsync](#longexecuteasync)

## Ներածություն

DataSource դասը նախատեսված է կլիենտական ծրագրից տվյալների աղբյուրը աշխատացնելու և արդյունքը վերադարձնելու ֆունկցիոնալությունը ապահովելու համար։

Տվյալների աղբյուրը աշխատում է հերթագրման միջոցով։
Տե՛ս [Ասինխրոն մշակում կիրառությունների սերվերի վրա](../../architecture/appserver_async.md):

Օգտագործման [օրինակներ](../examples/DataSource.md)։

## Հատկություններ

### Client

```c#
public ApiClient Client { get; set; }
```

Վերադարձնում կամ նշանակում է [ApiClient](../types/ApiClient.md) դասի օբյեկտ, որը նախատեսված է տվյալների աղբյուրի կատարման ընթացքում կլիենտից դեպի սերվեր անհրաժեշտ հարցումներ կատարելու համար։

Այս հատկությունը հարկավոր է լրացնել DataSource դասի օբյեկտը ստեղծելուց անմիջապես հետո։

### Definition

```c#
public DataSourceDefinition Definition { get; set; }
```

Վերադարձնում կամ նշանակում է տվյալների աղբյուրի նկարագրությունը, որը պարունակում է տվյալների աղբյուրի, սյուների և պարամետրերի հատկությունները։

Այս հատկությունը լրացվում է [LoadDefinitionAsync](#loaddefinitionasync) մեթոդի կանչով։

Այդ օբյեկտը կարելի է քեշավորել և բազմակի օգտագործել։
Տե՛ս [օրինակը](../examples/DataSource.md#օրինակ-4)։

### ExtenderSchema

```c#
public ExtenderSchemaEx ExtenderSchema { get; set; }
```

Վերադարձնում կամ նշանակում է [տվյալների աղբյուրի ընդլայնման](../../extensions/definitions/ds_extender.md) նկարագրությունը, որը պարունակում է ընդլայնման ներքին անունը, պարամետրերի ու սյուների հատկությունները։

Այս հատկությանը արժեք փոխանցելու դեպքում տվյալների աղբյուրը կատարելիս նաև հաշվարկվում է ընդլայնումը։

Այս հատկությունը լրացվում է [GetSchemaAsync](ExtenderRoutes.md#getschemaasync) մեթոդի կանչով՝ փոխանցելով ընդլայնման ներքին անունը։

```c#
ds.ExtenderSchema = await apiClient.Extender.GetSchemaAsync("CreatDocExtended");
```

Տե՛ս [օրինակը](../examples/DataSource.md#օրինակ-2)։

### FetchSize

```c#
public int FetchSize { get; set; }
```

Տվյալների աղբյուրի կատարման արդյունքում վերադարձվող տողերը սերվիսից կլիենտ բեռնվում են կտոր առ կտոր։

Այս հատկությունը վերադարձնում կամ նշանակում է բեռնման յուրաքանչյուր կտորի տողերի քանակը՝ բացառությամբ առաջինի կտորի։

### FirstFetchSize

```c#
public int FirstFetchSize { get; set; }
```

Տվյալների աղբյուրի կատարման արդյունքում վերադարձվող տողերը սերվիսից կլիենտ բեռնվում են կտոր առ կտոր։

Այս հատկությունը վերադարձնում կամ նշանակում է բեռնման առաջին կտորի տողերի քանակը։

<!-- ### ShowProgress

```c#
public bool ShowProgress { get; set; }
```

Վերադարձնում կամ նշանակում է տվյալների աղբյուրը կատարման և բեռնման գործընթացի պրոգրեսի պատուհանով ցուցադրման հայտանիշը։ -->

### EncodeResultUnicode

```c#
public bool EncodeResultUnicode { get; set; }
```

Վերադարձնում կամ նշանակում է տվյալների աբյուրի արդյունքների յունիկոդ կոդավորմամբ լինելը։ 
**false** արժեքի դեպքում վերադարձնում է ANSI կոդավորմամբ։

## Մեթոդներ

### ExecuteAsync

```c#
public Task<DataSourceResult<R>> ExecuteAsync(P param, HashSet<string> columns = default, 
    string isn = null, CancellationToken cancellationToken = default, TimeSpan? timeout = null)
```

Աշխատացնում է տվյալների աղբյուրը, վերադարձնում ստացված տողերի ցուցակը և կատարման ընթացքում առաջացած սխալների մանրամասն տեղեկությունը։

Այս մեթոդը կարող է օգտագործվել այն դեպքերում, երբ կատարման ժամանակը չի գերազանցում 180 վայրկյանը։

**Պարամետրեր**

* `param` - Տվյալների աղբյուրի պարամետրերը նկարագրող դասի օբյեկտ՝ `ParameterCollection` դասի ժառանգ։
* `columns` - Տվյալների աղբյուրի վերադարձվող սյուների անունների ցուցակ։ 
  Արժեք չփոխանցելու դեպքում կատարման արդյունքում վերադարձվելու են բոլոր սյուները։
* `isn` - Տվյալների աղբյուրի նշված նույնականացուցիչով ֆիլտրման արժեք։ 
  Տե՛ս [IsUpdatable](../../server_api/definitions/ds.md#isupdatable)։
* `cancellationToken` - Ընդհատման օբյեկտ:
* `timeout` - Տվյալների աղբյուրի աշխատանքի առավելագույն ժամանակը։ 
  Արժեք չփոխանցելու դեպքում առավելագույն ժամանակ համարվելու է 180 վայրկյան (3 րոպե)։

**Oրինակ**

- [Տվյալների աղբյուրի կլիենտից կանչի օրինակ ոչ տիպիզացված եղանակով](../examples/DataSource.md#օրինակ-1)
- [Տվյալների աղբյուրի կլիենտից կանչի օրինակ տիպիզացված եղանակով](../examples/DataSource.md#օրինակ-3)
- [Տվյալների աղբյուրի կլիենտից կանչի օրինակ՝ օգտագործելով քեշավորում](../examples/DataSource.md#օրինակ-4)

### LoadDefinitionAsync

```c#
public async Task LoadDefinitionAsync(string name, CancellationToken cancellationToken = default)
```

Բեռնում է տվյալների աղբյուրի նկարագրությունը և վերագրում [Definition](#definition) հատկությանը։

**Պարամետրեր**

* `name` - Տվյալների աղբյուրի ներքին անունը։
* `cancellationToken` - Ընդհատման օբյեկտ:

### LongExecuteAsync

```c#
public Task<DataSourceResult<R>> LongExecuteAsync(P param, HashSet<string> columns = default, 
    string isn = null, bool handleEvents = false, 
    CancellationToken cancellationToken = default, TimeSpan? timeout = null)
```

Աշխատացնում է տվյալների աղբյուրը, վերադարձնում ստացված տողերի ցուցակը և կատարման ընթացքում առաջացած սխալների մանրամասն տեղեկությունը։

Այս մեթոդը անհրաժեշտ է օգտագործել այն դեպքերում, երբ կատարման ժամանակը գերազանցում է 180 վայրկյանը կամ անհայտ է։

**Պարամետրեր**

* `R` - Տվյալների աղբյուրի տողը նկարագրող դասի օբյեկտ՝ `ExtendableRow` դասի ժառանգ։
* `param` - Տվյալների աղբյուրի պարամետրերը նկարագրող դասի օբյեկտ՝ `ParameterCollection` դասի ժառանգ։
* `columns` - Տվյալների աղբյուրի վերադարձվող սյուների անունների ցուցակ։ 
  Արժեք չփոխանցելու դեպքում կատարման արդյունքում վերադարձվելու են բոլոր սյուները։
* `isn` - Տվյալների աղբյուրի նշված նույնականացուցիչով ֆիլտրման արժեք։ 
  Տե՛ս [IsUpdatable](../../server_api/definitions/ds.md#isupdatable)։
* `cancellationToken` - Ընդհատման օբյեկտ:
* `timeout` - Տվյալների աղբյուրի աշխատանքի առավելագույն ժամանակը։ 
  Արժեք չփոխանցելու դեպքում առավելագույն ժամանակ համարվելու է 180 վայրկյան (3 րոպե)։

**Oրինակ**

- [Տվյալների աղբյուրի և ընդլայնման կլիենտից կանչի օրինակ ոչ տիպիզացված եղանակով](../examples/DataSource.md#օրինակ-2)
