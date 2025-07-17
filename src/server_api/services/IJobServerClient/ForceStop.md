---
title: IJobServerClient.ForceStop(Guid, string) մեթոդ
---

```c#
public Task<bool> ForceStop(Guid id, string message)
```

Փորձում է ընդհատել նախապես հերթի դրված [փաստաթղթի](../../definitions/document.md), [տվյալների աղբյուրի](../../definitions/ds.md) կամ [DPR](../../definitions/dpr.md)-ի կատարումը։

Վերադարձնում Է `bool` տիպի արժեք, որը ցույց է տալիս ընդհատումը հաջողվեց թե ոչ։

**Պարամետրեր**

* `id` - [Փաստաթղթի](../../definitions/document.md), [տվյալների աղբյուրի](../../definitions/ds.md) կամ [DPR](../../definitions/dpr.md)-ի կատարման առաջադրանքի id-ն։
* `message` - Այն սխալի հաղորդագրությունը, որը կվերադարձվի եթե ընդհատման ընթացքում առաջացել է սխալ։
