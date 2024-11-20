---
layout: page
title: "BlobRoutes"
---

## Բովանդակություն

- [Ներածություն](#ներածություն)
- [Մեթոդներ](#մեթոդներ)
  - [Append](#append)
  - [AppendAsync](#appendasync)
  - [DeleteBlob](#deleteblob)
  - [DeleteBlobAsync](#deleteblobasync)
  - [Download](#download)
  - [DownloadAsync](#downloadasync)
  - [DownloadToFile](#downloadtofile)
  - [DownloadToFileAsync](#downloadtofileasync)
  - [Upload](#upload)
  - [UploadAsync](#uploadasync)

## Ներածություն

## Մեթոդներ

### Append

```c#
public bool Append(string container, string blobName, byte[] value, int size)
```

Ավելացնում է `value` պարամետրի պարունակությունը `file` պարամետրում նշված ֆայլի վերջում։

**Պարամետրեր**

* `container` - Կոնտեյների անունը։ 
* `blobName` - Ֆայլի անունը` ներառյալ ֆայլի ընդլայնումը, որին կավելանա երկրորդ ֆայլը։
* `value` - Ավելացվող ֆայլի պարունակությունը որպես byte-երի զանգված։
* `size` - Ավելացվող ֆայլի երկարությունը։

### AppendAsync

```c#
public Task<bool> AppendAsync(string container, string blobName, byte[] value, int size, CancellationToken cancellationToken = default)
```

Ավելացնում է `value` պարամետրի պարունակությունը `file` պարամետրում նշված ֆայլի վերջում։

**Պարամետրեր**

* `container` - Կոնտեյների անունը։ 
* `blobName` - Ֆայլի անունը` ներառյալ ֆայլի ընդլայնումը, որին կավելանա երկրորդ ֆայլը։
* `value` - Ավելացվող ֆայլի պարունակությունը որպես byte-երի զանգված։
* `size` - Ավելացվող ֆայլի երկարությունը։
* `cancellationToken` - Ընդհատման օբյեկտ:

### DeleteBlob

```c#
public bool DeleteBlob(string container, string blobName)
```

Հեռացնում է ֆայլը պահոցից ըստ անվան և կոնտեյների։ 

**Պարամետրեր**

* `container` - Կոնտեյների անունը։ 
* `blobName` - Ֆայլի անունը` ներառյալ ֆայլի ընդլայնումը։

### DeleteBlobAsync

```c#
public Task<bool> DeleteBlobAsync(string container, string blobName, CancellationToken cancellationToken = default)
```

Հեռացնում է ֆայլը պահոցից ըստ անվան և կոնտեյների։ 

**Պարամետրեր**

* `container` - Կոնտեյների անունը։ 
* `blobName` - Ֆայլի անունը` ներառյալ ֆայլի ընդլայնումը։
* `cancellationToken` - Ընդհատման օբյեկտ:

### Download

```c#
public Stream Download(string container, string blobName)
```

Բեռնում է նշված կոնտեյների նշված ֆայլը և վերադարձնում ֆայլի պարունակությունը որպես [Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream): 

**Պարամետրեր**

* `container` - Կոնտեյների անունը։ 
* `blobName` - Ֆայլի անունը` ներառյալ ֆայլի ընդլայնումը։
* `cancellationToken` - Ընդհատման օբյեկտ:

### DownloadAsync

```c#
public Task<Stream> DownloadAsync(string container, string blobName, CancellationToken cancellationToken = default)
```

Բեռնում է նշված կոնտեյների նշված ֆայլը և վերադարձնում ֆայլի պարունակությունը որպես [Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream): 

**Պարամետրեր**

* `container` - Կոնտեյների անունը։ 
* `blobName` - Ֆայլի անունը` ներառյալ ֆայլի ընդլայնումը։
* `cancellationToken` - Ընդհատման օբյեկտ:

### DownloadToFile

```c#
public void DownloadToFile(string container, string blobName,
                           string file, bool deleteBlob = true)
```

Բեռնում է նշված կոնտեյների նշված ֆայլը և ավելացնում `file` պարամետրում նշված ֆայլում։

`file` պարամետրում նշված ճանապարհով ֆայլի գոյություն չունենալու դեպքում, ստեղծվում է այն և ավելացնում բեռնված ֆայը։

**Պարամետրեր**

* `container` - Կոնտեյների անունը։ 
* `blobName` - Ֆայլի անունը` ներառյալ ֆայլի ընդլայնումը։
* `file` - Ֆայլի ճանապարհը, որտեղ պահելու է բեռնված ֆայլը։
* `deleteBlob` - Ցույց է տալիս, արդյոք `blobName` պարամետրում նշված ֆայլը բեռնումից հետո պետք է հեռացվի, թե ոչ։

### DownloadToFileAsync

```c#
public Task DownloadToFileAsync(string container, string blobName,
                                string file, bool deleteBlob = true,
                                CancellationToken cancellationToken = default)
```

Բեռնում է նշված կոնտեյների նշված ֆայլը և ավելացնում `file` պարամետրում նշված ֆայլում։

`file` պարամետրում նշված ճանապարհով ֆայլի գոյություն չունենալու դեպքում, ստեղծվում է այն և ավելացնում բեռնված ֆայը։

**Պարամետրեր**

* `container` - Կոնտեյների անունը։ 
* `blobName` - Ֆայլի անունը` ներառյալ ֆայլի ընդլայնումը։
* `file` - Ֆայլի ճանապարհը, որտեղ պահելու է բեռնված ֆայլը։
* `deleteBlob` - Ցույց է տալիս, արդյոք `blobName` պարամետրում նշված ֆայլը բեռնումից հետո պետք է հեռացվի, թե ոչ։
* `cancellationToken` - Ընդհատման օբյեկտ:

### Upload

```c#
public bool Upload(string container, string blobName, byte[] value)
```

Պահպանում է `value` պարամետրի պարունակությունը նշված կոնտեյների նշված ֆայլում։ 

**Պարամետրեր**

* `container` - Կոնտեյների անունը։ 
* `blobName` - Ֆայլի անունը` ներառյալ ֆայլի ընդլայնումը։
* `value` - Ֆայլի պարունակությունը որպես byte-երի զանգված։

### UploadAsync

```c#
public Task<bool> UploadAsync(string container, string blobName, byte[] value, CancellationToken cancellationToken = default)
```

Պահպանում է `value` պարամետրի պարունակությունը նշված կոնտեյների նշված ֆայլում։ 

**Պարամետրեր**

* `container` - Կոնտեյների անունը։ 
* `blobName` - Ֆայլի անունը` ներառյալ ֆայլի ընդլայնումը։
* `value` - Ֆայլի պարունակությունը որպես byte-երի զանգված։
* `cancellationToken` - Ընդհատման օբյեկտ:



