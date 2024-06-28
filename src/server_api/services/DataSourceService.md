---
layout: page
title: "DataSourceService" 
---

DataSourceService դասը նախատեսված է տվյալների աղբյուրի հետ աշխատանքը ապահովելու համար։

## Բովանդակություն
* [Մեթոդներ](#մեթոդներ)
  * [ExecuteDataSource](#executeDataSource)
  * [GetDataSource](#getDataSource)
  * [GetColumnsDefinition](#getColumnsDefinition)
  * [GetDefinition](#GetDefinition)


## Մեթոդներ

### ExecuteDataSource

```c#
public async Task<List<T>> ExecuteDataSource<T>(string dsName, Dictionary<string, object> parameters, CancellationToken cancellationToken = default)
```

Կատարում է տվյալների աղբյուրը և վերադարձնում տողերի ցուցակ` որպես մուտքային պարամետրեր ստանալով տվյալների աղբյուրի՝
- dsName - ներքին անվանումը,
- parameters - պարամետրերի ցանկը,
- cancellationToken - չեղարկման տոկենը,
- T - սյուները նկարագրող դասը։

Օգտագործման օրինակին ծանոթանալու համար [տե՛ս](../examples/ds.md#1-չտիպիզացված-կատարում):

### ExecuteDataSource

```c#
public Task<List<T>> ExecuteDataSource<T>(Type dsType, Dictionary<string, object> parameters, CancellationToken cancellationToken = default)
```

Կատարում է տվյալների աղբյուրը և վերադարձնում տողերի ցուցակ՝ որպես մուտքային պարամետրեր ստանալով տվյալների աղբյուրի՝
- dsType - նկարագրող դասի տիպը,
- parameters - պարամետրերի ցանկը,
- cancellationToken - չեղարկման տոկենը,
- T - սյուները նկարագրող դասը:

Օգտագործման օրինակին ծանոթանալու համար [տե՛ս](../examples/ds.md#1-չտիպիզացված-կատարում):

### GetDataSource

```c#
public T GetDataSource<T>() where T : IDataSource
```

Ստեղծվում է տրված T տիպի տվյալների աղբյուրի դասի օբյեկտ։

Օգտագործման օրինակին ծանոթանալու համար [տե՛ս](../examples/ds.md#2-տիպիզացված--կատարում):

### GetColumnsDefinition

```c#
public async Task<Dictionary<string, DataSourceColumnDefinition>> GetColumnsDefinition(string dsName)
```

Վերադարձնում է տվյալների աղբյուրի սյուների նկարագրությունների ցանկը՝ որպես մուտքային պարամետր ստանալով տվյալների աղբյուրի ներքին անվանումը։

### GetDefinition

```c#
public async Task<DataSourceDefinition> GetDefinition(string dsName, bool isFull = false)
```

Վերադարձնում է տվյալների աղբյուրի նկարագրությունը` որպես մուտքային պարամետր ստանալով տվյալների աղբյուրի ներքին անվանումը։
