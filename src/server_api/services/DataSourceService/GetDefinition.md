---
title: DataSourceService.GetDefinition(string, bool) մեթոդ
---

```c#
public Task<DataSourceDefinition> GetDefinition(string dsName, bool isFull = false)
```

Վերադարձնում է տվյալների աղբյուրի նկարագրությունը, որը պարունակում է տվյալների աղբյուրի մետատվյալները և հատկությունները(ներքին անուն, հայերեն, անգլերեն անվանումներ, SqlBased է թե ոչ...):

**Պարամետրեր**

* `dsName` - Տվյալների աղբյուրի ներքին անունը:
