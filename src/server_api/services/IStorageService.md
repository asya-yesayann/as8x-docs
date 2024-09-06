---
layout: page
title: "IStorageService սերվիս" 
tags: [Storage, Blob]
sublinks:
- { title: "Container", ref: container }
- { title: "DeleteBlobAsync", ref: deleteblobasync }
- { title: "DeleteBlobAsync", ref: deleteblobasync-1 }
- { title: "GetBlobAsync", ref: getblobasync }
- { title: "UploadBlobAsync", ref: uploadblobasync }
- { title: "UploadTempBlobAsync", ref: uploadtempblobasync }
---

## Բովանդակություն

- [Ներածություն](#ներածություն)
- [Հատկություններ](#հատկություններ)
  - [Container](#container)
- [Մեթոդներ](#մեթոդներ)
  - [DeleteBlobAsync](#deleteblobasync)
  - [DeleteBlobAsync](#deleteblobasync-1)
  - [GetBlobAsync](#getblobasync)
  <!-- - [GetTempBlobUrlAsync](#gettempbloburlasync) -->
  - [UploadBlobAsync](#uploadblobasync)
  - [UploadTempBlobAsync](#uploadtempblobasync)

## Ներածություն

IStorageService դասը նախատեսված է ծրագրի աշխատանքի ընթացքում ձևավորվող ֆայլերի պահպանման և բեռնման համար։
Համակարգը կարող է կարգավորվել այնպես, որ ֆայլերի պահպանում կատարվի կա՛մ ֆայլային համակարգում, կա՛մ ամպային պահոցում։

Կարգավորվում է [appsettings.json](../../project/appsettings_json.md) կոնֆիգուրացիոն ֆայլի [Storage](../../project/appsettings_json.md#storage) բաժնում։

## Հատկություններ

### Container

```c#
public string Container { get; }
```

Վերադարձնում է այն կոնտեյների/թղթապանակի անունը, որտեղ պահվում են ընթացիկ սեսիայի ժամանակավոր ստեղծվող ֆայլերը։

Եթե ֆայլերը պահվում են ֆայլային համակարգում, ապա սեսիայի ժամանակավոր կոնտեյներըը հիմնական թղթապանակի ենթապանակ է չկրկնվող անունով ավտոմատ ձևավորված սեսիայի բացման ժամանակ, և ջնջվում է սեսիայի փակվելուց հետո։

<!-- (Text reports, տպելու ձևանմուշներից առաջացած ֆայլեր, կամ այլ ֆայլեր) -->

## Մեթոդներ

### DeleteBlobAsync

```c#
public virtual Task<bool> DeleteBlobAsync(string container, string blobName, CancellationToken cancellationToken = default)
```

Հեռացնում է ֆայլը պահոցից ըստ անվան և կոնտեյների։ 

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
public virtual Task<Stream> GetBlobAsync(string container, string blobName, CancellationToken cancellationToken = default);
```

Վերադարձնում է ֆայլի պարունակությունը որպես [Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream):

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
public Task<bool> UploadBlobAsync(string container, string blobName, byte[] value, CancellationToken cancellationToken = default);
```

Պահպանում է `value` պարամետրի պարունակությունը նշված կոնտեյների նշված ֆայլում։ 

**Պարամետրեր**

* `container` - Կոնտեյների անունը։ 
* `blobName` - Ֆայլի անունը` ներառյալ ֆայլի ընդլայնումը։
* `value` - Ֆայլի պարունակությունը որպես byte-երի զանգված։
* `cancellationToken` - Ընդհատման օբյեկտ։

### UploadTempBlobAsync

```c#
public Task<bool> UploadTempBlobAsync(string fileExtension, out string blobName, Stream stream, BlobProperties properties = null, CancellationToken cancellationToken = default);
```

Պահպանում է `stream` պարամետրի պարունակությունը [ընթացիկ սեսիայի կոնտեյների](#container) նշված ընդլայնմամբ ֆայլում, որի անունը ձևավորվում է ավտոմատ։ 

**Պարամետրեր**

* `fileExtension` - Ֆայլի ընդլայնումը։
* `blobName` - Վերադարձնում է ստեղծված ֆայլի անունը` ներառյալ ֆայլի ընդլայնումը։
* `stream` - Ֆայլի պարունակությունը որպես [Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream):
* `properties` - Ֆայլի հատկությունները։ 
* `cancellationToken` - Ընդհատման օբյեկտ։
