---
layout: page
title: "DataSourceService" 
---

# DataSourceService

DataSourceService դասը նախատեսված է տվյալների աղբյուրի հետ աշխատանքը ապահովելու համար։

# Մեթոդներ

## ExecuteDataSource

```c#
public async Task<List<T>> ExecuteDataSource<T>(string dsName, Dictionary<string, object> parameters, CancellationToken cancellationToken = default)
```

Կատարում է տվյալների աղբյուրը և վերադարձնում տողերի ցուցակ` ստանալով տվյալների աղբյուրի՝
- dsName - ներքին անվանումը,
- parameters - պարամետրերի ցանկը,
- cancellationToken - չեղարկման տոկենը։

## ExecuteDataSource

```c#
public Task<List<T>> ExecuteDataSource<T>(Type dsType, Dictionary<string, object> parameters, CancellationToken cancellationToken = default)
```

Կատարում է տվյալների աղբյուրը և վերադարձնում տողերի ցուցակ՝ 
ստանալով տվյալների աղբյուրի՝
- dsName - նկարագրող դասի տիպը,
- parameters - պարամետրերի ցանկը,
- cancellationToken - չեղարկման տոկենը։

## GetDataSource

```c#
public T GetDataSource<T>() where T : IDataSource
```

Վերադարձնում է տիպիզացված տվյալների աղբյուր։

## GetColumnsDefinition

```c#
public async Task<Dictionary<string, DataSourceColumnDefinition>> GetColumnsDefinition(string dsName)
```

Վերադարձնում է տվյալների աղբյուրի սյուների նկարագրությունների ցանկը՝ ստանալով տվյալների աղբյուրի ներքին անվանումը։


## GetDefinition

```c#
public async Task<DataSourceDefinition> GetDefinition(string dsName, bool isFull = false)
```

Վերադարձնում է տվյալների աղբյուրի նկարագրությունը` ստանալով տվյալների աղբյուրի ներքին անվանումը։

