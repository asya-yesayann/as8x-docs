---
title: IStorageService.GetBlobAsync(string, string, CancellationToken) մեթոդ
---

```c#
public virtual Task<Stream> GetBlobAsync(string container, string blobName, CancellationToken cancellationToken = default)
```

Վերադարձնում է ֆայլի պարունակությունը ժամանակավոր ֆայլերի պահոցից` որպես [Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream):

**Պարամետրեր**

* `container` - Կոնտեյների անունը։ 
* `blobName` - Ֆայլի անունը` ներառյալ ֆայլի ընդլայնումը։
* `cancellationToken` - Ընդհատման օբյեկտ։
