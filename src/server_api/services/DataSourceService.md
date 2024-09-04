---
layout: page
title: "DataSourceService" 
tags: [DataSourceService, DS, DataSource]
---

## Բովանդակություն
- [Ներածություն](#ներածություն)
- [Մեթոդներ](#մեթոդներ)
  - [ExecuteDataSource](#executedatasource)
  - [ExecuteDataSource](#executedatasource-1)
  - [GetColumnsDefinition](#getcolumnsdefinition)
  - [GetDataSource](#getdatasource)
  - [GetDefinition](#getdefinition)

## Ներածություն

DataSourceService դասը նախատեսված է տվյալների աղբյուրի հետ աշխատանքը ապահովելու համար։

## Մեթոդներ

### ExecuteDataSource

```c#
public Task<List<T>> ExecuteDataSource<T>(string dsName, Dictionary<string, object> parameters, CancellationToken cancellationToken = default)
```

Կատարում է տվյալների աղբյուրը և վերադարձնում տողերի ցուցակ։

**Պարամետրեր**

* `dsName` - Տվյալների աղբյուրի ներքին անունը:
* `parameters` - Տվյալների աղբյուրի պարամետրերի ցանկը:
* `cancellationToken` - Չեղարկման տոկենը:
* `T` - Տվյալների աղբյուրի սյուները նկարագրող դասը։

Օգտագործման օրինակին ծանոթանալու համար [տե՛ս](../examples/ds.md#1-չտիպիզացված-կատարում):

### ExecuteDataSource

```c#
public Task<List<T>> ExecuteDataSource<T>(Type dsType, Dictionary<string, object> parameters, CancellationToken cancellationToken = default)
```

Կատարում է տվյալների աղբյուրը և վերադարձնում տողերի ցուցակ։

**Պարամետրեր**

* `dsType` - Տվյալների աղբյուրը նկարագրող դասի տիպը։
* `parameters` - Տվյալների աղբյուրի պարամետրերի ցանկը:
* `cancellationToken` - Չեղարկման տոկենը:
* `T` - Տվյալների աղբյուրի սյուները նկարագրող դասը:

Օգտագործման օրինակին ծանոթանալու համար [տե՛ս](../examples/ds.md#1-չտիպիզացված-կատարում):

### GetColumnsDefinition

```c#
public Task<Dictionary<string, DataSourceColumnDefinition>> GetColumnsDefinition(string dsName)
```

Վերադարձնում է տվյալների աղբյուրի սյուների նկարագրությունների ցանկը։

**Պարամետրեր**
* `dsName` - Տվյալների աղբյուրի ներքին անունը:

### GetDataSource

```c#
public T GetDataSource<T>() where T : IDataSource
```

Ստեղծվում է տրված T տիպի տվյալների աղբյուրի դասի օբյեկտ։

**Պարամետրեր**

* `T` - Տվյալների աղբյուրը նկարագրող դասը:

Օգտագործման օրինակին ծանոթանալու համար [տե՛ս](../examples/ds.md#2-տիպիզացված-կատարում):

### GetDefinition

```c#
public Task<DataSourceDefinition> GetDefinition(string dsName, bool isFull = false)
```

Վերադարձնում է տվյալների աղբյուրի նկարագրությունը, որը պարունակում է տվյալների աղբյուրի մետատվյալները և հատկությունները(ներքին անուն, հայերեն, անգլերեն անվանումներ, SqlBased է թե ոչ, ...):

**Պարամետրեր**
* `dsName` - Տվյալների աղբյուրի ներքին անունը:
