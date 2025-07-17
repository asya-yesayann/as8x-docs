---
title: "IJobServerClient սերվիս"
---

## Ներածություն

IJobServerClient դասը նախատեսված է [փաստաթղթի](../definitions/document.md), [տվյալների աղբյուրի](../definitions/ds.md), [DPR](../definitions/dpr.md)-ի կատարումը հերթի դնելու, կատարման պրոգրեսը, արդյունքը ստանալու, կատարումը ընդհատելու ֆունկցիոնալությունը ապահովելու համար։

## Մեթոդներ

| Անվանում | Նկարագրություն |
|----------|----------------|
| [Enqueue](IJobServerClient/Enqueue.md) | Հերթի է դնում [DPR](../definitions/dpr.md)-ի կատարումը և վերադարձնում է Id՝ [DPR](../definitions/dpr.md)-ի կատարման ընթացքին հետևելու համար։ |
| [GetJobProgress](IJobServerClient/GetJobProgress.md) | Վերադարձնում է նախապես հերթի դրված [փաստաթղթի](../definitions/document.md), [տվյալների աղբյուրի](../definitions/ds.md), [DPR](../definitions/dpr.md)-ի կատարման պրոգրեսը։ |
| [GetJobResult](IJobServerClient/GetJobResult.md) | Վերադարձնում է նախապես հերթի դրված [փաստաթղթի](../definitions/document.md), [տվյալների աղբյուրի](../definitions/ds.md) կամ [DPR](../definitions/dpr.md)-ի կատարման արդյունքը։ |
| [Stop](IJobServerClient/Stop.md) | Ընդհատում է նախապես հերթի դրված [փաստաթղթի](../definitions/document.md), [տվյալների աղբյուրի](../definitions/ds.md) կամ [DPR](../definitions/dpr.md)-ի կատարումը։ |
| [ForceStop](IJobServerClient/ForceStop.md) | Փորձում է ընդհատել նախապես հերթի դրված [փաստաթղթի](../definitions/document.md), [տվյալների աղբյուրի](../definitions/ds.md) կամ [DPR](../definitions/dpr.md)-ի կատարումը։ |
| [Delete](IJobServerClient/Delete.md) | Հեռացնում է [փաստաթղթի](../definitions/document.md), [տվյալների աղբյուրի](../definitions/ds.md) կամ [DPR](../definitions/dpr.md)-ի կատարման առաջադրանքը։ |
| [GetJob](IJobServerClient/GetJob.md) | Վերադարձնում է նախապես հերթի դրված [փաստաթղթի](../definitions/document.md), [տվյալների աղբյուրի](../definitions/ds.md) կամ [DPR](../definitions/dpr.md)-ի կատարման առաջադրանքի օբյեկտը։ |
| [GetJobsInfo](IJobServerClient/GetJobsInfo.md) | Վերադարձնում է նշված id-ով [սեսսիայի](../types/SessionInfo.md) բոլոր [փաստաթղթի](../definitions/document.md), [տվյալների աղբյուրի](../definitions/ds.md), [DPR](../definitions/dpr.md)-ի կատարման առաջադրանքների ինֆորմացիաների ցուցակը։ |
