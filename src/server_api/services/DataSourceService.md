---
layout: page
title: "DataSourceService սերվիս" 
tags: [DataSourceService, DS, DataSource]
sublinks:
- { title: "ExecuteDataSource", ref: executedatasource }
- { title: "ExecuteDataSource", ref: executedatasource-1 }
- { title: "GetColumnsDefinition", ref: getcolumnsdefinition }
- { title: "GetDataSource", ref: getdatasource }
- { title: "GetDefinition", ref: getdefinition }
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
* `cancellationToken` - Ընդհատման օբյեկտ:
* `T` - Տվյալների աղբյուրի տողը նկարագրող դասը։

Օգտագործման օրինակին ծանոթանալու համար [տե՛ս](../examples/ds.md#չտիպիզացված-կատարում):

### ExecuteDataSource

```c#
public Task<List<T>> ExecuteDataSource<T>(Type dsType, Dictionary<string, object> parameters, CancellationToken cancellationToken = default)
```

Կատարում է տվյալների աղբյուրը և վերադարձնում տողերի ցուցակ։

**Պարամետրեր**

* `dsType` - Տվյալների աղբյուրի տիպը։
* `parameters` - Տվյալների աղբյուրի պարամետրերի ցանկը:
* `cancellationToken` - Ընդհատման օբյեկտ:
* `T` - Տվյալների աղբյուրի տողը նկարագրող դասը:

Օգտագործման օրինակին ծանոթանալու համար [տե՛ս](../examples/ds.md#չտիպիզացված-կատարում):

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

* `T` - Տվյալների աղբյուրի տիպը:

Օգտագործման օրինակին ծանոթանալու համար [տե՛ս](../examples/ds.md#տիպիզացված-կատարում):

### GetDefinition

```c#
public Task<DataSourceDefinition> GetDefinition(string dsName, bool isFull = false)
```

Վերադարձնում է տվյալների աղբյուրի նկարագրությունը, որը պարունակում է տվյալների աղբյուրի մետատվյալները և հատկությունները(ներքին անուն, հայերեն, անգլերեն անվանումներ, SqlBased է թե ոչ...):

**Պարամետրեր**
* `dsName` - Տվյալների աղբյուրի ներքին անունը:
