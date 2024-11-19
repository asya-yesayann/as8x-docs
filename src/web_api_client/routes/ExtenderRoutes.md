---
layout: page
title: "ExtenderRoutes"
---

## Բովանդակություն

- [Ներածություն](#ներածություն)
- [Մեթոդներ](#մեթոդներ)
  - [GetColumns](#getcolumns)
  - [GetColumnsAsync](#getcolumnsasync)
  - [GetSchema](#getschema)
  - [GetSchemaAsync](#getschemaasync)

## Ներածություն

ExtenderRoutes դասը նախատեսված է ընդլայնումների հետ աշխատանքը ապահովելու համար։

## Մեթոդներ

### GetColumns

```c#
public List<string> GetColumns(string name)
```

Վերադարձնում է տվյալների աղբյուրի ընդլայնման սյուների ներքին անունների ցուցակը։

**Պարամետրեր**

* `name` - Տվյալների աղբյուրի ընդլայնման ներքին անունը։

### GetColumnsAsync

```c#
public Task<List<string>> GetColumnsAsync(string name, CancellationToken cancellationToken = default)
```

Վերադարձնում է տվյալների աղբյուրի ընդլայնման սյուների ներքին անունների ցուցակը։

**Պարամետրեր**

* `name` - Տվյալների աղբյուրի ընդլայնման ներքին անունը։
* `cancellationToken` - Ընդհատման օբյեկտ:

### GetSchema

```c#
public ExtenderSchema GetSchema(string extenderName)
```

Վերադարձնում է տվյալների աղբյուրի ընդլայնման նկարագրությունը, որը պարունակում է ընդլայնման ներքին անունը, պարամետրերի ու սյուների հատկությունները։

**Պարամետրեր**

* `extenderName` - Տվյալների աղբյուրի ընդլայնման ներքին անունը։

Մեթոդի վերադարձված արժեքը անհրաժեշտ է վերագրել [տվյալների աղբյուր](DataSource.md)-ի [ExtenderSchema](DataSource.md#extenderschema) հատկությանը, որի արդյունքում տվյալների աղբյուրը կատարելիս կհաշվարկվի նաև ընդլայնումը։

**Օրինակ**

Տե՛ս օգտագործման [օրինակը](../examples/DataSource.md#օրինակ-2)։

### GetSchemaAsync

```c#
public Task<ExtenderSchema> GetSchemaAsync(string extenderName, CancellationToken cancellationToken = default)
```

Վերադարձնում է տվյալների աղբյուրի ընդլայնման նկարագրությունը, որը պարունակում է ընդլայնման ներքին անունը, պարամետրերի ու սյուների հատկությունները։

**Պարամետրեր**

* `extenderName` - Տվյալների աղբյուրի ընդլայնման ներքին անունը։
* `cancellationToken` - Ընդհատման օբյեկտ:

Մեթոդի վերադարձված արժեքը անհրաժեշտ է վերագրել [տվյալների աղբյուր](DataSource.md)-ի [ExtenderSchema](DataSource.md#extenderschema) հատկությանը, որի արդյունքում տվյալների աղբյուրը կատարելիս կհաշվարկվի նաև ընդլայնումը։

**Օրինակ**

Տե՛ս օգտագործման [օրինակը](../examples/DataSource.md#օրինակ-2)։


