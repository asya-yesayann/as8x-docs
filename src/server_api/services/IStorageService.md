---
layout: page
title: "IStorageService սերվիս" 
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

## Բովանդակություն

- [Բովանդակություն](#բովանդակություն)
- [Ներածություն](#ներածություն)
- [Հատկություններ](#հատկություններ)
  - [Container](#container)
- [Մեթոդներ](#մեթոդներ)
  - [DeleteBlobAsync](#deleteblobasync)
  - [DeleteBlobAsync](#deleteblobasync-1)
  - [GetBlobAsync](#getblobasync)
  - [GetTempBlobUrl](#gettempbloburl)
  - [UploadBlobAsync](#uploadblobasync)
  - [UploadBlobAsync](#uploadblobasync-1)
  - [UploadBlobAsync](#uploadblobasync-2)
  - [UploadTempBlobAsync](#uploadtempblobasync)

## Ներածություն

IStorageService դասը նախատեսված է ծրագրի աշխատանքի ընթացքում ձևավորվող ժամանակավոր ֆայլերի պահպանման և բեռնման համար։
Համակարգը կարող է կարգավորվել այնպես, որ ֆայլերի պահպանում կատարվի կա՛մ ֆայլային համակարգում, կա՛մ ամպային պահոցում։

Կարգավորվում է [appsettings.json](../../project/appsettings_json.md) կոնֆիգուրացիոն ֆայլի [Storage](../../project/appsettings_json.md#storage) բաժնում։

## Հատկություններ

### Container

```c#
public string Container { get; }
```

Վերադարձնում է այն կոնտեյների/թղթապանակի անունը, որտեղ պահվում են ընթացիկ սեսիայի ժամանակավոր ստեղծվող ֆայլերը։

Եթե ֆայլերը պահվում են ֆայլային համակարգում, ապա սեսիայի ժամանակավոր կոնտեյները հիմնական թղթապանակի ենթապանակ է չկրկնվող անունով, որը ձևավորվում է ավտոմատ՝ սեսիայի բացման ժամանակ, և ջնջվում է սեսիայի փակվելուց հետո։

<!-- (Text reports, տպելու ձևանմուշներից առաջացած ֆայլեր, կամ այլ ֆայլեր) -->

## Մեթոդներ

### DeleteBlobAsync

```c#
public virtual Task<bool> DeleteBlobAsync(string container, string blobName, CancellationToken cancellationToken = default)
```

Հեռացնում է ֆայլը ժամանակավոր ֆայլերի պահոցից` ըստ անվան և կոնտեյների։ 

**Պարամետրեր**

* `container` - Կոնտեյների անունը։ 
* `blobName` - Ֆայլի անունը` ներառյալ ֆայլի ընդլայնումը։
* `cancellationToken` - Ընդհատման օբյեկտ։ 

### DeleteBlobAsync

```c#
public virtual Task<bool> DeleteBlobAsync(string blobName, CancellationToken cancellationToken = default)
```

Հեռացնում է ֆայլը [ընթացիկ սեսիայի կոնտեյներից](#container)։

**Պարամետրեր**

* `blobName` - Ֆայլի անունը` ներառյալ ֆայլի ընդլայնումը։
* `cancellationToken` - Ընդհատման օբյեկտ։

### GetBlobAsync

```c#
public virtual Task<Stream> GetBlobAsync(string container, string blobName, CancellationToken cancellationToken = default)
```

Վերադարձնում է ֆայլի պարունակությունը ժամանակավոր ֆայլերի պահոցից` որպես [Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream):

**Պարամետրեր**

* `container` - Կոնտեյների անունը։ 
* `blobName` - Ֆայլի անունը` ներառյալ ֆայլի ընդլայնումը։
* `cancellationToken` - Ընդհատման օբյեկտ։

### GetTempBlobUrl

```c#
public Task<string> GetTempBlobUrl(string fileExtension, out string blobName)
```

Վերադարձնում է [ընթացիկ սեսիայի կոնտեյներում](#container) գոյություն չունեցող, պատահականության սկզբունքով ընտրված ֆայլի անուն՝ ներառյալ ընդլայնումը և ֆայլի ամբողջական ճանապարհը։

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

### UploadBlobAsync

```c#
public Task<bool> UploadBlobAsync(string container, string blobName, byte[] value, CancellationToken cancellationToken = default)
```

Պահպանում է `value` պարամետրի պարունակությունը ժամանակավոր ֆայլերի պահոցում` ըստ կոնտեյների և ֆայլի անվան։ 

**Պարամետրեր**

* `container` - Կոնտեյների անունը, որտեղ պետք է պահպանվի ֆայլը։
* `blobName` - Ֆայլի անունը` ներառյալ ֆայլի ընդլայնումը։
* `value` - Ֆայլի պարունակությունը` որպես byte-երի զանգված։
* `cancellationToken` - Ընդհատման օբյեկտ։

### UploadBlobAsync

```c#
public Task<bool> UploadBlobAsync(string blobName, Stream stream, BlobProperties properties = null, CancellationToken cancellationToken = default)
```

Պահպանում է `stream` պարամետրի պարունակությունը [ընթացիկ սեսիայի կոնտեյների](#container) նշված ֆայլում։ 

**Պարամետրեր**

* `blobName` - Ֆայլի անունը` ներառյալ ֆայլի ընդլայնումը։
* `stream` - Ֆայլի պարունակությունը որպես [Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream):
* `properties` - Ֆայլի հատկությունները։ 
* `cancellationToken` - Ընդհատման օբյեկտ։

### UploadBlobAsync

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

### UploadTempBlobAsync

```c#
public Task<bool> UploadTempBlobAsync(string fileExtension, out string blobName, Stream stream, BlobProperties properties = null, CancellationToken cancellationToken = default)
```

Պահպանում է `stream` պարամետրի պարունակությունը [ընթացիկ սեսիայի կոնտեյների](#container) նշված ընդլայնմամբ ֆայլում, որի անունը ձևավորվում է ավտոմատ։ 

**Պարամետրեր**

* `fileExtension` - Ֆայլի ընդլայնումը։
* `blobName` - Վերադարձնում է ստեղծված ֆայլի անունը` ներառյալ ֆայլի ընդլայնումը։
* `stream` - Ֆայլի պարունակությունը որպես [Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream):
* `properties` - Ֆայլի հատկությունները։ 
* `cancellationToken` - Ընդհատման օբյեկտ։
