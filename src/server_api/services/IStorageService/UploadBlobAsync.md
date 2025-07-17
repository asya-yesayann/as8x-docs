---
title: IStorageService.UploadBlobAsync(string, string, byte[], CancellationToken) մեթոդ
---

```c#
public Task<bool> UploadBlobAsync(string container, string blobName, byte[] value, CancellationToken cancellationToken = default)
```

Պահպանում է `value` պարամետրի պարունակությունը ժամանակավոր ֆայլերի պահոցում` ըստ կոնտեյների և ֆայլի անվան։ 

**Պարամետրեր**

* `container` - Կոնտեյների անունը, որտեղ պետք է պահպանվի ֆայլը։
* `blobName` - Ֆայլի անունը` ներառյալ ֆայլի ընդլայնումը։
* `value` - Ֆայլի պարունակությունը` որպես byte-երի զանգված։
* `cancellationToken` - Ընդհատման օբյեկտ։
