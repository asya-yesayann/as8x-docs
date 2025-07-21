---
title: IStorageService.UploadTempBlobAsync(string, string, Stream, BlobProperties, CancellationToken) մեթոդ
---

```c#
public Task<bool> UploadTempBlobAsync(string fileExtension, out string blobName, Stream stream, BlobProperties properties = null, CancellationToken cancellationToken = default)
```

Պահպանում է `stream` պարամետրի պարունակությունը [ընթացիկ սեսիայի կոնտեյների](Container.md) նշված ընդլայնմամբ ֆայլում, որի անունը ձևավորվում է ավտոմատ։ 

**Պարամետրեր**

* `fileExtension` - Ֆայլի ընդլայնումը։
* `blobName` - Վերադարձնում է ստեղծված ֆայլի անունը` ներառյալ ֆայլի ընդլայնումը։
* `stream` - Ֆայլի պարունակությունը որպես [Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream):
* `properties` - Ֆայլի հատկությունները։ 
* `cancellationToken` - Ընդհատման օբյեկտ։
