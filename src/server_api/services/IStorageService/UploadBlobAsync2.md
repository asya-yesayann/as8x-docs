---
title: IStorageService.UploadBlobAsync(string, string, Stream, BlobProperties, CancellationToken) մեթոդ
---

```c#
public Task<bool> UploadBlobAsync(string containerOrBucketName, string blobName, Stream stream, BlobProperties properties = null, CancellationToken cancellationToken = default)
```

Պահպանում է `stream` պարամետրի պարունակությունը ժամանակավոր ֆայլերի պահոցում՝ նշված կոնտեյների նշված ֆայլում։ 

**Պարամետրեր**

* `containerOrBucketName` - Կոնտեյների անունը։ 
* `blobName` - Ֆայլի անունը` ներառյալ ֆայլի ընդլայնումը։
* `stream` - Ֆայլի պարունակությունը որպես [Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream):
* `properties` - Ֆայլի հատկությունները։ 
* `cancellationToken` - Ընդհատման օբյեկտ։
