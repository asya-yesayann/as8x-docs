---
title: IPermanentStorageService.UploadBlobAsync(string, string, byte[], CancellationToken) մեթոդ
---

```c#
public Task<bool> UploadBlobAsync(string container, string blobName, byte[] value, CancellationToken cancellationToken = default)
```

Պահպանում է `value` պարամետրի պարունակությունը մշտական ֆայլերի պահոցում՝ նշված կոնտեյների նշված ֆայլում։ 

**Պարամետրեր**

* `container` - Կոնտեյների անունը։ 
* `blobName` - Ֆայլի անունը` ներառյալ ֆայլի ընդլայնումը։
* `value` - Ֆայլի պարունակությունը որպես byte-երի զանգված։
* `cancellationToken` - Ընդհատման օբյեկտ։
