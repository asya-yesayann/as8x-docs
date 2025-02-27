---
layout: page
title: "IPermanentStorageService սերվիս" 
tags: [Storage, Blob]
sublinks:
- { title: "Container", ref: container }
- { title: "DeleteBlobAsync", ref: deleteblobasync }
- { title: "DeleteBlobAsync", ref: deleteblobasync-1 }
- { title: "GetBlobAsync", ref: getblobasync }
- { title: "GetTempBlobUrl", ref: gettempbloburl }
- { title: "UploadBlobAsync", ref: uploadblobasync }
- { title: "UploadBlobAsync", ref: uploadblobasync-1 }
- { title: "UploadBlobAsync", ref: uploadblobasync-2 }
- { title: "UploadTempBlobAsync", ref: uploadtempblobasync }
---

## Ներածություն

IPermanentStorageService դասը նախատեսված է ծրագրի աշխատանքի ընթացքում ձևավորվող մշտական ֆայլերի պահպանման և բեռնման համար։
Համակարգը կարող է կարգավորվել այնպես, որ ֆայլերի պահպանում կատարվի կա՛մ ֆայլային համակարգում, կա՛մ ամպային պահոցում։

Կարգավորվում է [appsettings.json](../../project/appsettings_json.md) կոնֆիգուրացիոն ֆայլի [Storage](../../project/appsettings_json.md#storage) բաժնի `Permanent` ենթաբաժնում։

## Հատկություններ

### Container

```c#
public string Container { get; set; }
```

Վերադարձնում կամ նշանակում է մշտական ֆայլերի պահպանման ընթացիկ թղթապանակը, որը հանդիսանում է մշտական ֆայլերի պահոցի ենթաթղթապանակ։

## Մեթոդներ

### DeleteBlobAsync

```c#
public virtual Task<bool> DeleteBlobAsync(string container, string blobName, CancellationToken cancellationToken = default)
```

Հեռացնում է ֆայլը մշտական ֆայլերի պահոցից՝ ըստ անվան և կոնտեյների։ 

**Պարամետրեր**

* `container` - Կոնտեյների անունը։ 
* `blobName` - Ֆայլի անունը` ներառյալ ֆայլի ընդլայնումը։
* `cancellationToken` - Ընդհատման օբյեկտ։ 

### DeleteBlobAsync

```c#
public virtual Task<bool> DeleteBlobAsync(string blobName, CancellationToken cancellationToken = default)
```

Հեռացնում է ֆայլը մշտական ֆայլերի պահոցի [Container](#container) հատկությամբ նշված թղթապանակից։

**Պարամետրեր**

* `blobName` - Ֆայլի անունը` ներառյալ ֆայլի ընդլայնումը։
* `cancellationToken` - Ընդհատման օբյեկտ։

### GetBlobAsync

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

### UploadBlobAsync

```c#
public Task<bool> UploadBlobAsync(string container, string blobName, byte[] value, CancellationToken cancellationToken = default)
```

Պահպանում է `value` պարամետրի պարունակությունը մշտական ֆայլերի պահոցում՝ նշված կոնտեյների նշված ֆայլում։ 

**Պարամետրեր**

* `container` - Կոնտեյների անունը։ 
* `blobName` - Ֆայլի անունը` ներառյալ ֆայլի ընդլայնումը։
* `value` - Ֆայլի պարունակությունը որպես byte-երի զանգված։
* `cancellationToken` - Ընդհատման օբյեկտ։

### UploadBlobAsync

```c#
public Task<bool> UploadBlobAsync(string blobName, Stream stream, BlobProperties properties = null, CancellationToken cancellationToken = default)
```

Պահպանում է `value` պարամետրի պարունակությունը մշտական ֆայլերի պահոցի [Container](#container) հատկությամբ նշված թղթապանակում՝ `blobName` պարամետրում նշված ֆայլում։

**Պարամետրեր**

* `blobName` - Ֆայլի անունը` ներառյալ ֆայլի ընդլայնումը։
* `stream` - Ֆայլի պարունակությունը որպես [Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream):
* `properties` - Ֆայլի հատկությունները։ 
* `cancellationToken` - Ընդհատման օբյեկտ։

### UploadBlobAsync

```c#
public Task<bool> UploadBlobAsync(string containerOrBucketName, string blobName, Stream stream, BlobProperties properties = null, CancellationToken cancellationToken = default)
```

Պահպանում է `stream` պարամետրի պարունակությունը մշտական ֆայլերի պահոցում՝ նշված կոնտեյների նշված ֆայլում։ 

**Պարամետրեր**

* `containerOrBucketName` - Կոնտեյների անունը։ 
* `blobName` - Ֆայլի անունը` ներառյալ ֆայլի ընդլայնումը։
* `stream` - Ֆայլի պարունակությունը որպես [Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream):
* `properties` - Ֆայլի հատկությունները։ 
* `cancellationToken` - Ընդհատման օբյեկտ։

### UploadTempBlobAsync

```c#
public Task<bool> UploadTempBlobAsync(string fileExtension, out string blobName, Stream stream, BlobProperties properties = null, CancellationToken cancellationToken = default)
```

Պահպանում է `stream` պարամետրի պարունակությունը մշտական ֆայլերի պահոցի [Container](#container) հատկությամբ նշված թղթապանակում` տրված ընդլայնմամբ ֆայլում, որի անունը ձևավորվում է ավտոմատ։ 

**Պարամետրեր**

* `fileExtension` - Ֆայլի ընդլայնումը։
* `blobName` - Վերադարձնում է ստեղծված ֆայլի անունը` ներառյալ ֆայլի ընդլայնումը։
* `stream` - Ֆայլի պարունակությունը որպես [Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream):
* `properties` - Ֆայլի հատկությունները։ 
* `cancellationToken` - Ընդհատման օբյեկտ։