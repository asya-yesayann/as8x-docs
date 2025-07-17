---
title: IPermanentStorageService.UploadBlobAsync(string, Stream, BlobProperties, CancellationToken) մեթոդ
---

```c#
public Task<bool> UploadBlobAsync(string blobName, Stream stream, BlobProperties properties = null, CancellationToken cancellationToken = default)
```

Պահպանում է `value` պարամետրի պարունակությունը մշտական ֆայլերի պահոցի [Container](#container) հատկությամբ նշված թղթապանակում՝ `blobName` պարամետրում նշված ֆայլում։

**Պարամետրեր**

* `blobName` - Ֆայլի անունը` ներառյալ ֆայլի ընդլայնումը։
* `stream` - Ֆայլի պարունակությունը որպես [Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream):
* `properties` - Ֆայլի հատկությունները։ 
* `cancellationToken` - Ընդհատման օբյեկտ։
