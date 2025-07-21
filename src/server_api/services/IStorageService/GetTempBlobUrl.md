---
title: IStorageService.GetTempBlobUrl(string, string) մեթոդ
---

```c#
public Task<string> GetTempBlobUrl(string fileExtension, out string blobName)
```

Վերադարձնում է [ընթացիկ սեսիայի կոնտեյներում](Container.md) գոյություն չունեցող, պատահականության սկզբունքով ընտրված ֆայլի անուն՝ ներառյալ ընդլայնումը և ֆայլի ամբողջական ճանապարհը։

**Օրինակ** `C:\\Storage\\Files\\76dfc298-66c0-4b41-8981-434582400aeb\\lsrbuqgy.jay.txt`:

**Պարամետրեր**

* `fileExtension` - Ֆայլի ընդլայնումը։
* `blobName` - Վերադարձնում է ֆայլի անունը՝ նշված ընդլայնմամբ։

<!-- ### GetTempBlobUrlAsync

```c#
public Task<string> GetTempBlobUrlAsync(string fileExtension, out string blobName)
```

Վերադարձնում է [Container](#container) հատկությամբ սահմանված ենթաթղթապանակում գոյություն չունեցող, պատահականության սկզբունքով ընտրված ֆայլի անունը՝ ներառյալ ընդլայնումը և ֆայլի ամբողջական ճանապարհը։

**Օրինակ** `C:\\Storage\\Files\\76dfc298-66c0-4b41-8981-434582400aeb\\lsrbuqgy.jay.txt`:

**Պարամետրեր**

* `fileExtension` - Ֆայլի ընդլայնումը։
* `blobName` - Վերադարձնում է ֆայլի անունը՝ նշված ընդլայնմամբ։ -->
