---
title: IJobServerClient.Enqueue(DPR.Descriptor, object, bool, IServiceProvider, Dictionary<int, UIRequestResultBase>, string, bool) մեթոդ
---

```c#
public Task<JobEnqueueResponse> Enqueue(DPR.Descriptor dpr, object param, bool enableUIRequest,
                                        IServiceProvider serviceProvider,
                                        Dictionary<int, UIRequestResultBase> uiResponse, string sessionGuid,
                                        bool isUnicode = false)
```

Հերթի է դնում [DPR](../../definitions/dpr.md)-ի կատարումը և վերադարձնում է Id՝ [DPR](../../definitions/dpr.md)-ի կատարման ընթացքին հետևելու համար։

**Պարամետրեր**

* `dpr` - [DPR-ի մետատվյալները նկարագրող դասի օբյեկտ](../../types/DPR_Descriptor.md)։
* `param` - [DPR](../../definitions/dpr.md)-ի կատարման համար անհրաժեշտ պարամետրերը նկարագրող դասի օբյեկտ։
* `enableUIRequest` - Սերվիսից կլիենտ հաղորդագրություն ուղարկելու, հաղորդագրության պատասխանը ստանալու և այն սերվիսում մշակելու համար հնարավորության միացման հայտանիշ։
* `serviceProvider` - [IServiceProvider](https://learn.microsoft.com/en-us/dotnet/api/system.iserviceprovider) դասի օբյեկտ, որը օգտագործվում է մեթոդի աշխատանքի համար անհրաժեշտ սերվիսները [ինյեկցիա](../../../project/injection.md) անելու համար։
* `uiResponse` - 
* `sessionGuid` - Այն [սեսսիայի](../../types/SessionInfo.md) id-ն, որում հերթի է դրվում DPR-ը։ Սովորաբար այս պարամետրին տրվում է ընթացիկ սեսսիայի id-ն, որը կարելի է ստանալ [ISessionInfoService](../ISessionInfoService.md).[CurrentSessionGuid](../ISessionInfoService/CurrentSessionGuid.md) հատկության միջոցով։
* `isUnicode` - Ցույց է տալիս, թե DPR-ի կատարման պրոգրեսում տվյալները պետք է ցուցադրվեն `Unicode` կոդավորմամբ թե ոչ։ `false` արժեքի դեպքում տվյալները ցուցադրվում են `ANSI` կոդավորմամբ։
