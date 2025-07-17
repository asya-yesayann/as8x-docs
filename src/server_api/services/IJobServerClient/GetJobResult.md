---
title: IJobServerClient.GetJobResult(Guid) մեթոդ
---

```c#
public Task<object> GetJobResult(Guid id)
```

Վերադարձնում է նախապես հերթի դրված [փաստաթղթի](../../definitions/document.md), [տվյալների աղբյուրի](../../definitions/ds.md) կամ [DPR](../../definitions/dpr.md)-ի կատարման արդյունքը։

Եթե կատարումը դեռ չի ավարտվել կամ նշված id-ով կատարման առաջադրանք գոյություն չունի, ապա առաջացնում է սխալ։

**Պարամետրեր**

* `id` - [Փաստաթղթի](../../definitions/document.md), [տվյալների աղբյուրի](../../definitions/ds.md) կամ [DPR](../../definitions/dpr.md)-ի կատարման առաջադրանքի id-ն։
