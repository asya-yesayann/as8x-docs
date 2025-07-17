---
title: IJobServerClient.Delete(Guid) մեթոդ
---

```c#
public Task Delete(Guid id)
```

Հեռացնում է [փաստաթղթի](../../definitions/document.md), [տվյալների աղբյուրի](../../definitions/ds.md) կամ [DPR](../../definitions/dpr.md)-ի կատարման առաջադրանքը։

Եթե նշված id-ով կատարման առաջադրանք գոյություն չունի կամ առաջադրանքը դեռ ավարտված չէ, ապա առաջացնում է սխալ։

**Պարամետրեր**

* `id` - [Փաստաթղթի](../../definitions/document.md), [տվյալների աղբյուրի](../../definitions/ds.md) կամ [DPR](../../definitions/dpr.md)-ի կատարման առաջադրանքի id-ն։
