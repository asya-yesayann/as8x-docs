---
layout: page
title: "IJobServerClient սերվիս" 
---

## Բովանդակություն

- [Ներածություն](#ներածություն)
- [Մեթոդներ](#մեթոդներ)
  - [Enqueue](#enqueue)
  - [GetJobProgress](#getjobprogress)
  - [GetJobResult](#getjobresult)
  - [Stop](#stop)
  - [ForceStop](#forcestop)
  - [Delete](#delete)
  - [GetJob](#getjob)
  - [GetJobsInfo](#getjobsinfo)

## Ներածություն

IJobServerClient դասը նախատեսված է [փաստաթղթի](../definitions/document.md), [տվյալների աղբյուրի](../definitions/ds.md), [DPR](../definitions/dpr.md)-ի կատարումը հերթի դնելու, կատարման պրոգրեսը, արդյունքը ստանալու, կատարումը ընդհատելու ֆունկցիոնալությունը ապահովելու համար։

## Մեթոդներ

### Enqueue

```c#
public Task<JobEnqueueResponse> Enqueue(DPR.Descriptor dpr, object param, bool enableUIRequest,
                                        IServiceProvider serviceProvider,
                                        Dictionary<int, UIRequestResultBase> uiResponse, string sessionGuid,
                                        bool isUnicode = false)
```

Հերթի է դնում [DPR](../definitions/dpr.md)-ի կատարումը և վերադարձնում է Id՝ [DPR](../definitions/dpr.md)-ի կատարման ընթացքին հետևելու համար։

**Պարամետրեր**

* `dpr` - [DPR-ի մետատվյալները նկարագրող դասի օբյեկտ](../types/DPR_Descriptor.md)։
* `param` - [DPR](../definitions/dpr.md)-ի կատարման համար անհրաժեշտ պարամետրերը նկարագրող դասի օբյեկտ։
* `enableUIRequest` - Սերվիսից կլիենտ հաղորդագրություն ուղարկելու, հաղորդագրության պատասխանը ստանալու և այն սերվիսում մշակելու համար հնարավորության միացման հայտանիշ։
* `serviceProvider` - [IServiceProvider](https://learn.microsoft.com/en-us/dotnet/api/system.iserviceprovider) դասի օբյեկտ, որը օգտագործվում է մեթոդի աշխատանքի համար անհրաժեշտ սերվիսները [ինյեկցիա](../../project/injection.md) անելու համար։
* `uiResponse` - 
* `sessionGuid` - Այն [սեսսիայի](../types/SessionInfo.md) id-ն, որում հերթի է դրվում DPR-ը։ Սովորաբար այս պարամետրին տրվում է ընթացիկ սեսսիայի id-ն, որը կարելի է ստանալ [ISessionInfoService](ISessionInfoService.md).[CurrentSessionGuid](ISessionInfoService.md#currentsessionguid) հատկության միջոցով։
* `isUnicode` - Ցույց է տալիս, թե DPR-ի կատարման պրոգրեսում տվյալները պետք է ցուցադրվեն `Unicode` կոդավորմամբ թե ոչ։ `false` արժեքի դեպքում տվյալները ցուցադրվում են `ANSI` կոդավորմամբ։

### GetJobProgress

```c#
public Task<object> GetJobProgress(Guid id)
```

Վերադարձնում է նախապես հերթի դրված [փաստաթղթի](../definitions/document.md), [տվյալների աղբյուրի](../definitions/ds.md), [DPR](../definitions/dpr.md)-ի կատարման պրոգրեսը։

Եթե նշված id-ով կատարման առաջադրանք գոյություն չունի, ապա առաջացնում է սխալ։

**Պարամետրեր**

* `id` - [Փաստաթղթի](../definitions/document.md), [տվյալների աղբյուրի](../definitions/ds.md) կամ [DPR](../definitions/dpr.md)-ի կատարման առաջադրանքի id-ն։

### GetJobResult

```c#
public Task<object> GetJobResult(Guid id)
```

Վերադարձնում է նախապես հերթի դրված [փաստաթղթի](../definitions/document.md), [տվյալների աղբյուրի](../definitions/ds.md) կամ [DPR](../definitions/dpr.md)-ի կատարման արդյունքը։

Եթե կատարումը դեռ չի ավարտվել կամ նշված id-ով կատարման առաջադրանք գոյություն չունի, ապա առաջացնում է սխալ։

**Պարամետրեր**

* `id` - [Փաստաթղթի](../definitions/document.md), [տվյալների աղբյուրի](../definitions/ds.md) կամ [DPR](../definitions/dpr.md)-ի կատարման առաջադրանքի id-ն։

### Stop

```c#
public Task Stop(Guid id, object param)
```

Ընդհատում է նախապես հերթի դրված [փաստաթղթի](../definitions/document.md), [տվյալների աղբյուրի](../definitions/ds.md) կամ [DPR](../definitions/dpr.md)-ի կատարումը։

Եթե կատարումը արդեն ավարտվել է, ապա [հեռացնում է](#delete) կատարման առաջադրանքը։

Եթե նշված id-ով կատարման առաջադրանք գոյություն չունի, ապա առաջացնում է սխալ։

**Պարամետրեր**

* `id` - [Փաստաթղթի](../definitions/document.md), [տվյալների աղբյուրի](../definitions/ds.md) կամ [DPR](../definitions/dpr.md)-ի կատարման առաջադրանքի id-ն։
* `param` - Օգտագործվում է ընդհատման համար լրացուցիչ պարամետրերի փոխանցման համար։ Այս պահին միայն [տվյալների աղբյուրի](../definitions/ds.md) կատարման առաջադրանքին հնարավոր է փոխանցել `bool` տիպի պարամետր, որով որոշվում է կատարման առաջադրանքից ընդհատումից հետո տվյալների աղբյուրի տողերը պետք է հավելյալ մշակվեն [AfterDataReaderClose](../definitions/ds.md#afterdatareaderclose-1) մեթոդի միջոցով թե ոչ։ `true` արժեքի դեպքում տողերը հավելյալ չեն մշակվում։

### ForceStop

```c#
public Task<bool> ForceStop(Guid id, string message)
```

Փորձում է ընդհատել նախապես հերթի դրված [փաստաթղթի](../definitions/document.md), [տվյալների աղբյուրի](../definitions/ds.md) կամ [DPR](../definitions/dpr.md)-ի կատարումը։

Վերադարձնում Է `bool` տիպի արժեք, որը ցույց է տալիս ընդհատումը հաջողվեց թե ոչ։

**Պարամետրեր**

* `id` - [Փաստաթղթի](../definitions/document.md), [տվյալների աղբյուրի](../definitions/ds.md) կամ [DPR](../definitions/dpr.md)-ի կատարման առաջադրանքի id-ն։
* `message` - Այն սխալի հաղորդագրությունը, որը կվերադարձվի եթե ընդհատման ընթացքում առաջացել է սխալ։

### Delete

```c#
public Task Delete(Guid id)
```

Հեռացնում է [փաստաթղթի](../definitions/document.md), [տվյալների աղբյուրի](../definitions/ds.md) կամ [DPR](../definitions/dpr.md)-ի կատարման առաջադրանքը։

Եթե նշված id-ով կատարման առաջադրանք գոյություն չունի կամ առաջադրանքը դեռ ավարտված չէ, ապա առաջացնում է սխալ։

**Պարամետրեր**

* `id` - [Փաստաթղթի](../definitions/document.md), [տվյալների աղբյուրի](../definitions/ds.md) կամ [DPR](../definitions/dpr.md)-ի կատարման առաջադրանքի id-ն։

### GetJob

```c#
public Job GetJob(Guid id)
```

Վերադարձնում է նախապես հերթի դրված [փաստաթղթի](../definitions/document.md), [տվյալների աղբյուրի](../definitions/ds.md) կամ [DPR](../definitions/dpr.md)-ի կատարման առաջադրանքի օբյեկտը։

**Պարամետրեր**

* `id` - [Փաստաթղթի](../definitions/document.md), [տվյալների աղբյուրի](../definitions/ds.md) կամ [DPR](../definitions/dpr.md)-ի կատարման առաջադրանքի id-ն։

### GetJobsInfo

```c#
public Task<List<JobInfoModel>> GetJobsInfo(string sessionGuid)
```

Վերադարձնում է նշված id-ով [սեսսիայի](../types/SessionInfo.md) բոլոր [փաստաթղթի](../definitions/document.md), [տվյալների աղբյուրի](../definitions/ds.md), [DPR](../definitions/dpr.md)-ի կատարման առաջադրանքների ինֆորմացիաների ցուցակը։

**Պարամետրեր**

* `sessionGuid` - Այն [սեսսիայի](../types/SessionInfo.md) id-ն, որի կատարման առաջադրանքները պետք է վերադարձվեն։ Սովորաբար այս պարամետրին տրվում է ընթացիկ սեսսիայի id-ն, որը կարելի է ստանալ [ISessionInfoService](ISessionInfoService.md).[CurrentSessionGuid](ISessionInfoService.md#currentsessionguid) հատկության միջոցով։




