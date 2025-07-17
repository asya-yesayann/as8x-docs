---
title: DataSourceService.ExecuteDataSource(Type, Dictionary<string, object>, CancellationToken) մեթոդ
---

```c#
public Task<List<T>> ExecuteDataSource<T>(Type dsType, Dictionary<string, object> parameters, CancellationToken cancellationToken = default)
```

Կատարում է տվյալների աղբյուրը և վերադարձնում տողերի ցուցակ։

**Պարամետրեր**

* `dsType` - Տվյալների աղբյուրի տիպը։
* `parameters` - Տվյալների աղբյուրի պարամետրերի ցանկը:
* `cancellationToken` - Ընդհատման օբյեկտ:
* `T` - Տվյալների աղբյուրի տողը նկարագրող դասը:

Օգտագործման օրինակին ծանոթանալու համար [տե՛ս](../../examples/ds.md#չտիպիզացված-կատարում):
