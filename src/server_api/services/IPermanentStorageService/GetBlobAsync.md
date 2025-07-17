---
title: IPermanentStorageService.GetBlobAsync(string, string, CancellationToken) մեթոդ
---

```c#
public virtual Task<Stream> GetBlobAsync(string container, string blobName, CancellationToken cancellationToken = default)
```

Վերադարձնում է ֆայլի պարունակությունը մշտական ֆայլերից պահոցից՝ որպես [Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream):

**Պարամետրեր**

* `container` - Կոնտեյների անունը։ 
* `blobName` - Ֆայլի անունը` ներառյալ ֆայլի ընդլայնումը։
* `cancellationToken` - Ընդհատման օբյեկտ։

<!-- ### GetTempBlobUrlAsync

```c#
public Task<string> GetTempBlobUrlAsync(string fileExtension, out string blobName);
```

Վերադարձնում է [Container](#container) հատկությամբ սահմանված ենթաթղթապանակում գոյություն չունեցող, պատահականության սկզբունքով ընտրված ֆայլի անուն՝ նշված ընդլայնմամբ և ֆայլի ամբողջական ճանապարհը։

**Օրինակ** `C:\\Storage\\Files\\76dfc298-66c0-4b41-8981-434582400aeb\\lsrbuqgy.jay.txt`:

**Պարամետրեր**

* `fileExtension` - Ֆայլի ընդլայնումը։
* `blobName` - Վերադարձնում է ֆայլի անունը՝ նշված ընդլայնմամբ։ -->
