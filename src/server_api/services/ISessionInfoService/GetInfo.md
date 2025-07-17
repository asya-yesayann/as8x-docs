---
title: ISessionInfoService.GetInfo() մեթոդ
---

```c#
public SessionInfo GetInfo()
```

Վերադարձնում է ընթացիկ [սեսսիայի մասին ինֆորմացիան](../../types/SessionInfo.md)։

Օգտագործման օրինակին ծանոթանալու համար [տե՛ս](../../types/SessionInfo.md#օգտագործման-օրինակ):

<!-- ### GetInfo

```c#
public SessionInfo GetInfo(string sessionGuid)
```

Վերադարձնում է նշված ներքին նույնականացման համարով [սեսսիայի մասին ինֆորմացիան](../../types/SessionInfo.md) քեշից։

Քեշում բացակայության դեպքում բեռնում է սեսսիայի մասին ինֆորմացիան տվյալների պահոցի `SESSIONINFO` աղյուսակից և ավելացնում քեշում։

**Պարամետրեր**

* `sessionGuid` - Սեսսիայի ներքին նույնականացման համարը (Guid)։
