---
layout: page
title: "StorageService սերվիս" 
tags: [Storage, Blob]
---

## Բովանդակություն

- [Ներածություն](#ներածություն)
- [Հատկություններ](#հատկություններ)
  - [Container](#container)
- [Մեթոդներ](#մեթոդներ)
  - [DeleteBlobAsync](#deleteblobasync)
  - [DeleteBlobAsync](#deleteblobasync-1)
  - [GetBlobAsync](#getblobasync)
  - [GetTempBlobUrlAsync](#gettempbloburlasync)
  - [UploadBlobAsync](#uploadblobasync)
  - [UploadTempBlobAsync](#uploadtempblobasync)

## Ներածություն

StorageService դասը նախատեսված է ծրագրի աշխատանքի ընթացքում առաջացող ֆայլերի հետ աշխատանքը ապահովելու համար։

## Հատկություններ

### Container

```c#
public string Container { get; }
```

Վերադարձնում է այն թղթապանակի անունը, որտեղ պահվում են լոգինի արդյունքում բացված սեսսիայի ընթացքում ստեղծվող ֆայլերը (Text reports, տպելու ձևանմուշներից առաջացած ֆայլեր, կամ այլ ֆայլեր)։

Թղթապանակը գտնվում է [appsettings.json](../../project/appsettings_json.md) կոնֆիգուրացիոն ֆայլի [Storage](../../project/appsettings_json.md#storage) բաժնի `Directory` պարամետրում նշված բազային թղթապանակում։

## Մեթոդներ

### DeleteBlobAsync

```c#
public virtual Task<bool> DeleteBlobAsync(string container, string blobName, CancellationToken cancellationToken = default)
```

Հեռացնում է նշված ֆայլը նշված թղթապանակից։ 

**Պարամետրեր**

* `container` - Թղթապանակի անունը։ Թղթապանակը պարունակող բազային թղթապանակի ճանապարհը անհրաժեշտ է նախապես սահմանել [appsettings.json](../../project/appsettings_json.md) կոնֆիգուրացիոն ֆայլի [Storage](../../project/appsettings_json.md#storage) բաժնի `Directory` պարամետրում։
* `blobName` - Ֆայլի անունը` ներառյալ ֆայլի ընդլայնումը։
* `cancellationToken` - Մեթոդի կանչի դադարեցման տոկեն։ Լռությամբ արժեքը **default** է։

### DeleteBlobAsync

```c#
public virtual Task<bool> DeleteBlobAsync(string blobName, CancellationToken cancellationToken = default)
```

Հեռացնում է նշված ֆայլը [Container](#container) հատկությամբ սահմանված թղթապանակից։

**Պարամետրեր**

* `blobName` - Ֆայլի անունը` ներառյալ ֆայլի ընդլայնումը։
* `cancellationToken` - Մեթոդի կանչի դադարեցման տոկեն։ Լռությամբ արժեքը **default** է։

### GetBlobAsync

```c#
public virtual Task<Stream> GetBlobAsync(string container, string blobName, CancellationToken cancellationToken = default);
```

Վերադարձնում է նշված թղթապանակում պարունակվող նշված ֆայլը՝ որպես [Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream):

**Պարամետրեր**

* `container` - Ֆայլը պարունակող թղթապանակի անունը։ Թղթապանակը պարունակող բազային թղթապանակի ճանապարհը անհրաժեշտ է նախապես սահմանել [appsettings.json](../../project/appsettings_json.md) կոնֆիգուրացիոն ֆայլի [Storage](../../project/appsettings_json.md#storage) բաժնի `Directory` պարամետրում։
* `blobName` - Ֆայլի անունը` ներառյալ ֆայլի ընդլայնումը։
* `cancellationToken` - Մեթոդի կանչի դադարեցման տոկեն։ Լռությամբ արժեքը **default** է։

### GetTempBlobUrlAsync

```c#
public Task<string> GetTempBlobUrlAsync(string fileExtension, out string blobName);
```

Վերադարձնում է [Container](#container) հատկությամբ սահմանված ենթաթղթապանակում գոյություն չունեցող, պատահականության սկզբունքով ընտրված ֆայլի անուն՝ նշված ընդլայնմամբ և ֆայլի ամբողջական ճանապարհը։

**Օրինակ** `C:\\Storage\\Files\\76dfc298-66c0-4b41-8981-434582400aeb\\lsrbuqgy.jay.txt`:

**Պարամետրեր**

* `fileExtension` - Ֆայլի ընդլայնումը։
* `blobName` - Վերադարձնում է ֆայլի անունը՝ նշված ընդլայնմամբ։

### UploadBlobAsync

```c#
public Task<bool> UploadBlobAsync(string container, string blobName, byte[] value, CancellationToken cancellationToken = default);
```

Վերբեռնում է `value` պարամետրի պարունակությունը նշված թղթապանակի նշված ֆայլ։ 

**Պարամետրեր**

* `container` - Թղթապանակի անունը։ Թղթապանակը պարունակող բազային թղթապանակի ճանապարհը անհրաժեշտ է նախապես սահմանել [appsettings.json](../../project/appsettings_json.md) կոնֆիգուրացիոն ֆայլի [Storage](../../project/appsettings_json.md#storage) բաժնի `Directory` պարամետրում։
* `blobName` - Ֆայլի անունը` ներառյալ ֆայլի ընդլայնումը։
* `value` - Ֆայլի պարունակությունը որպես byte-երի զանգված։
* `cancellationToken` - Մեթոդի կանչի դադարեցման տոկեն։ Լռությամբ արժեքը **default** է։

### UploadTempBlobAsync

```c#
public Task<bool> UploadTempBlobAsync(string fileExtension, out string blobName, Stream stream, BlobProperties properties = null, CancellationToken cancellationToken = default);
```

Ստեղծում է [Container](#container) հատկությամբ սահմանված թղթապանակում գոյություն չունեցող անունով ֆայլ և վերբեռնում է `stream` պարամետրի պարունակությունը այդ ֆայլ։

**Պարամետրեր**

* `fileExtension` - Ֆայլի ընդլայնումը։
* `blobName` - Վերադարձնում է ստեղծված ֆայլի անունը` ներառյալ ֆայլի ընդլայնումը։
* `stream` - Ֆայլի պարունակությունը որպես [Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream):
* `properties` - Ֆայլի հատկությունները։ Լռությամբ արժեքը **null** է։
* `cancellationToken` - Մեթոդի կանչի դադարեցման տոկեն։ Լռությամբ արժեքը **default** է։

