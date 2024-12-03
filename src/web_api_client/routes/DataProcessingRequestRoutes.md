---
layout: page
title: "DataProcessingRequestRoutes"
---

## Բովանդակություն

- [Ներածություն](#ներածություն)
- [Մեթոդներ](#մեթոդներ)
  - [GetList](#getlist)
  - [GetListAsync](#getlistasync)
  - [GetList](#getlist-1)
  - [GetListAsync](#getlistasync-1)
  - [GetObject](#getobject)
  - [GetObjectAsync](#getobjectasync)
  - [Enqueue](#enqueue)
  - [EnqueueAsync](#enqueueasync)
  - [GetProgress](#getprogress)
  - [GetProgressAsync](#getprogressasync)
  - [GetResult](#getresult)
  - [GetResultAsync](#getresultasync)
  - [Stop](#stop)
  - [StopAsync](#stopasync)

## Ներածություն

## Մեթոդներ

### GetList

```c#
public IEnumerable<DPRInfo> GetList()
```

Վերադարձնում է համակարգում առկա բոլոր DPR-ների մետատվյալները (ներքին անուն, հայերեն/անգլերեն անվանումներ, սատարում է չեղարկումը թե ոչ...)։

### GetListAsync

```c#
public Task<IEnumerable<DPRInfo>> GetListAsync(CancellationToken cancellationToken = default)
```

Վերադարձնում է համակարգում առկա բոլոր DPR-ների մետատվյալները (ներքին անուն, հայերեն/անգլերեն անվանումներ, տեսակ)։

**Պարամետրեր**

* `cancellationToken` - Ընդհատման օբյեկտ:

### GetList

```c#
public IEnumerable<DPRInfo> GetList(DPRType type)
```

Վերադարձնում է համակարգում առկա նշված `type` տիպի բոլոր DPR-ների մետատվյալները (ներքին անուն, հայերեն/անգլերեն անվանումներ, տեսակ)։

**Պարամետրեր**

* `type` - DPR-ի տեսակը, որը նշվում է DPR ատրիբուտում։
  * **DPRType.Report** - Հաշվետվությունների տվյալների մշակման հարցում
  * **DPRType.OLAP** - Օլապ տվյալների մշակման հարցում
  * **DPRType.JobElement** - Առաջադրանքների տվյալների մշակման հարցում
  * **DPRType.Other** - Այլ տվյալների մշակման հարցում

### GetListAsync

```c#
public Task<IEnumerable<DPRInfo>> GetListAsync(DPRType type, CancellationToken cancellationToken = default)
```

Վերադարձնում է համակարգում առկա նշված `type` տիպի բոլոր DPR-ների մետատվյալները (ներքին անուն, հայերեն/անգլերեն անվանումներ, տեսակ)։

**Պարամետրեր**

* `type` - DPR-ի տեսակը, որը նշվում է DPR ատրիբուտում։
  * **DPRType.Report** - Հաշվետվությունների տվյալների մշակման հարցում
  * **DPRType.OLAP** - Օլապ տվյալների մշակման հարցում
  * **DPRType.JobElement** - Առաջադրանքների տվյալների մշակման հարցում
  * **DPRType.Other** - Այլ տվյալների մշակման հարցում
* `cancellationToken` - Ընդհատման օբյեկտ:

### GetObject

```c#
public DPRInfoExtended GetObject(DPRType type, string name)
```

Վերադարձնում է DPR-ի մետատվյալները (ներքին անուն, հայերեն/անգլերեն անվանումներ, տեսակ, սատարում է չեղարկումը թե ոչ)՝ ըստ տեսակի և ներքին անվան։

**Պարամետրեր**

* `type` - DPR-ի տեսակը, որը նշվում է DPR ատրիբուտում։
  * **DPRType.Report** - Հաշվետվությունների տվյալների մշակման հարցում
  * **DPRType.OLAP** - Օլապ տվյալների մշակման հարցում
  * **DPRType.JobElement** - Առաջադրանքների տվյալների մշակման հարցում
  * **DPRType.Other** - Այլ տվյալների մշակման հարցում
* `name` - DPR-ի ներքին անունը։

### GetObjectAsync

```c#
public Task<DPRInfoExtended> GetObjectAsync(DPRType type, string name, CancellationToken cancellationToken = default)
```

Վերադարձնում է DPR-ի մետատվյալները (ներքին անուն, հայերեն/անգլերեն անվանումներ, տեսակ, սատարում է չեղարկումը թե ոչ)՝ ըստ տեսակի և ներքին անվան։

**Պարամետրեր**

* `type` - DPR-ի տեսակը, որը նշվում է DPR ատրիբուտում։
  * **DPRType.Report** - Հաշվետվությունների տվյալների մշակման հարցում
  * **DPRType.OLAP** - Օլապ տվյալների մշակման հարցում
  * **DPRType.JobElement** - Առաջադրանքների տվյալների մշակման հարցում
  * **DPRType.Other** - Այլ տվյալների մշակման հարցում
* `name` - DPR-ի ներքին անունը։
* `cancellationToken` - Ընդհատման օբյեկտ:

### Enqueue

```c#
public DPRJobEnqueueResponse Enqueue(DPRType type, string name, bool enableUIRequest, JobDPRRequest request)
```

Հերթի է դնում [DPR](../../server_api/definitions/dpr.md)-ի կատարումը և վերադարձնում է `DPRJobEnqueueResponse` դասի օբյեկտ, որը պարունակում է հերթի դրված [DPR](../../server_api/definitions/dpr.md)-ի տվյալները (ներքին անուն, սատարում է չեղարկումը թե ոչ...) և Id՝ [DPR](../../server_api/definitions/dpr.md)-ի կատարման ընթացքին հետևելու համար։

**Պարամետրեր**

* `type` - DPR-ի տեսակը, որը նշվում է DPR ատրիբուտում։
  * **DPRType.Report** - Հաշվետվությունների տվյալների մշակման հարցում
  * **DPRType.OLAP** - Օլապ տվյալների մշակման հարցում
  * **DPRType.JobElement** - Առաջադրանքների տվյալների մշակման հարցում
  * **DPRType.Other** - Այլ տվյալների մշակման հարցում
* `name` - DPR-ի ներքին անունը։
* `enableUIRequest` - DPR-ի կատարման ընթացքում սերվիսից կլիենտ հաղորդագրություն ուղարկելու, հաղորդագրության պատասխանը ստանալու և այն սերվիսում մշակելու համար հնարավորության միացման հայտանիշ։
* `request` - DPR-ի կատարման համար անհրաժեշտ պարամետրերը։

### EnqueueAsync

```c#
public Task<DPRJobEnqueueResponse> EnqueueAsync(DPRType type, string name, 
                                                bool enableUIRequest, JobDPRRequest request, 
                                                CancellationToken cancellationToken = default)
```

Հերթի է դնում [DPR](../../server_api/definitions/dpr.md)-ի կատարումը և վերադարձնում է `DPRJobEnqueueResponse` դասի օբյեկտ, որը պարունակում է հերթի դրված [DPR](../../server_api/definitions/dpr.md)-ի տվյալները (ներքին անուն, սատարում է չեղարկումը թե ոչ...) և Id՝ [DPR](../../server_api/definitions/dpr.md)-ի կատարման ընթացքին հետևելու համար։

**Պարամետրեր**

* `type` - DPR-ի տեսակը, որը նշվում է DPR ատրիբուտում։
  * **DPRType.Report** - Հաշվետվությունների տվյալների մշակման հարցում
  * **DPRType.OLAP** - Օլապ տվյալների մշակման հարցում
  * **DPRType.JobElement** - Առաջադրանքների տվյալների մշակման հարցում
  * **DPRType.Other** - Այլ տվյալների մշակման հարցում
* `name` - DPR-ի ներքին անունը։
* `enableUIRequest` - DPR-ի կատարման ընթացքում սերվիսից կլիենտ հաղորդագրություն ուղարկելու, հաղորդագրության պատասխանը ստանալու և այն սերվիսում մշակելու համար հնարավորության միացման հայտանիշ։
* `request` - DPR-ի կատարման համար անհրաժեշտ պարամետրերը։
* `cancellationToken` - Ընդհատման օբյեկտ:

### GetProgress

```c#
public DPRProgress GetProgress(Guid id)
```

Վերադարձնում է [Enqueue](#enqueue) մեթոդի միջոցով նախապես հերթի դրված [DPR](../../server_api/definitions/dpr.md)-ի կատարման պրոգրեսը։

Եթե նշված id-ով կատարման առաջադրանք գոյություն չունի, ապա առաջացնում է սխալ։

**Պարամետրեր**

* `id` - [DPR](../../server_api/definitions/dpr.md)-ի կատարման առաջադրանքի id-ն, որը ստացվում է [Enqueue](#enqueue) մեթոդի կանչի արդյունքում։

### GetProgressAsync

```c#
public Task<DPRProgress> GetProgressAsync(Guid id, CancellationToken cancellationToken = default)
```

Վերադարձնում է [EnqueueAsync](#enqueueasync) մեթոդի միջոցով նախապես հերթի դրված [DPR](../../server_api/definitions/dpr.md)-ի կատարման պրոգրեսը։

Եթե նշված id-ով DPR-ի կատարման առաջադրանք գոյություն չունի, ապա առաջացնում է սխալ։

**Պարամետրեր**

* `id` - [DPR](../../server_api/definitions/dpr.md)-ի կատարման առաջադրանքի id-ն, որը ստացվում է [EnqueueAsync](#enqueueasync) մեթոդի կանչի արդյունքում։
* `cancellationToken` - Ընդհատման օբյեկտ:

### GetResult

```c#
public T GetResult<T>(Guid id, bool delete)
```

Վերադարձնում է [Enqueue](#enqueue) մեթոդի միջոցով նախապես հերթի դրված [DPR](../../server_api/definitions/dpr.md)-ի կատարման արդյունքը։

Եթե կատարումը դեռ չի ավարտվել կամ նշված id-ով կատարման առաջադրանք գոյություն չունի, ապա առաջացնում է սխալ։

**Պարամետրեր**

* `id` - [DPR](../../server_api/definitions/dpr.md)-ի կատարման առաջադրանքի id-ն, որը ստացվում է [Enqueue](#enqueue) մեթոդի կանչի արդյունքում։
* `delete` - DPR-ի կատարման առաջադրանքի քեշից մաքրման հայտանիշ։

### GetResultAsync

```c#
public Task<T> GetResultAsync<T>(Guid id, bool delete, CancellationToken cancellationToken = default)
```

Վերադարձնում է [EnqueueAsync](#enqueueasync) մեթոդի միջոցով նախապես հերթի դրված [DPR](../../server_api/definitions/dpr.md)-ի կատարման արդյունքը։

Եթե կատարումը դեռ չի ավարտվել կամ նշված id-ով կատարման առաջադրանք գոյություն չունի, ապա առաջացնում է սխալ։

**Պարամետրեր**

* `id` - [DPR](../../server_api/definitions/dpr.md)-ի կատարման առաջադրանքի id-ն, որը ստացվում է [EnqueueAsync](#enqueueasync) մեթոդի կանչի արդյունքում։
* `delete` - DPR-ի կատարման առաջադրանքի քեշից մաքրման հայտանիշ։
* `cancellationToken` - Ընդհատման օբյեկտ:

### Stop

```c#
public void Stop(Guid id)
```

Ընդհատում է նախապես հերթի դրված [DPR](../../server_api/definitions/dpr.md)-ի կատարումը։

Եթե նշված id-ով կատարման առաջադրանք գոյություն չունի, ապա առաջացնում է սխալ։

**Պարամետրեր**

* `id` - [DPR](../../server_api/definitions/dpr.md)-ի կատարման առաջադրանքի id-ն, որը ստացվում է [Enqueue](#enqueue) մեթոդի կանչի արդյունքում։

### StopAsync

```c#
public Task StopAsync(Guid id, CancellationToken cancellationToken = default)
```

Ընդհատում է նախապես հերթի դրված [DPR](../../server_api/definitions/dpr.md)-ի կատարումը։

Եթե նշված id-ով կատարման առաջադրանք գոյություն չունի, ապա առաջացնում է սխալ։

**Պարամետրեր**

* `id` - [DPR](../../server_api/definitions/dpr.md)-ի կատարման առաջադրանքի id-ն, որը ստացվում է [EnqueueAsync](#enqueueasync) մեթոդի կանչի արդյունքում։
* `cancellationToken` - Ընդհատման օբյեկտ:
