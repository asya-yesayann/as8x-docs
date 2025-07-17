---
title: IJobServerClient.GetJobsInfo(string) մեթոդ
---

```c#
public Task<List<JobInfoModel>> GetJobsInfo(string sessionGuid)
```

Վերադարձնում է նշված id-ով [սեսսիայի](../../types/SessionInfo.md) բոլոր [փաստաթղթի](../../definitions/document.md), [տվյալների աղբյուրի](../../definitions/ds.md), [DPR](../../definitions/dpr.md)-ի կատարման առաջադրանքների ինֆորմացիաների ցուցակը։

**Պարամետրեր**

* `sessionGuid` - Այն [սեսսիայի](../../types/SessionInfo.md) id-ն, որի կատարման առաջադրանքները պետք է վերադարձվեն։ Սովորաբար այս պարամետրին տրվում է ընթացիկ սեսսիայի id-ն, որը կարելի է ստանալ [ISessionInfoService](../ISessionInfoService.md).[CurrentSessionGuid](../ISessionInfoService/CurrentSessionGuid.md) հատկության միջոցով։