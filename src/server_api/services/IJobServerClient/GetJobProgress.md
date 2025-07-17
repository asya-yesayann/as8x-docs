---
title: IJobServerClient.GetJobProgress(Guid) մեթոդ
---

```c#
public Task<object> GetJobProgress(Guid id)
```

Վերադարձնում է նախապես հերթի դրված [փաստաթղթի](../../definitions/document.md), [տվյալների աղբյուրի](../../definitions/ds.md), [DPR](../../definitions/dpr.md)-ի կատարման պրոգրեսը։

Եթե նշված id-ով կատարման առաջադրանք գոյություն չունի, ապա առաջացնում է սխալ։

**Պարամետրեր**

* `id` - [Փաստաթղթի](../../definitions/document.md), [տվյալների աղբյուրի](../../definitions/ds.md) կամ [DPR](../../definitions/dpr.md)-ի կատարման առաջադրանքի id-ն։
