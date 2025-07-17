---
title: "ISessionInfoService սերվիս"
---

## Ներածություն

ISessionInfoService դասը նախատեսված է [սեսսիաների](../types/SessionInfo.md) հետ աշխատանքը ապահովելու համար։
Հնարավոր է ստանալ ընթացիկ օգտագործողի տվյալներ, ինչպես նաև ընթացիկ պարամետրերի արժեքներ։

<!-- ## Հատկություններ

### CurrentSessionGuid

```c#
public string CurrentSessionGuid { get }
```

Վերադարձնում է ընթացիկ [սեսսիայի](../types/SessionInfo.md) ներքին նույնականացման համարը (Guid): -->

## Մեթոդներ

| Անվանում | Նկարագրություն |
|----------|----------------|
| [CurrentSessionGuid](ISessionInfoService/CurrentSessionGuid.md) | Ավելացնում է նոր [սեսսիա](../types/SessionInfo.md) տվյալների պահոցի `SESSIONINFO` աղյուսակում և քեշում։ |
| [Delete](ISessionInfoService/Delete.md) | Հեռացնում է ընթացիկ [սեսսիան](../types/SessionInfo.md) տվյալների պահոցի `SESSIONINFO` աղյուսակից և քեշից։ |
| [DeleteExpirations](ISessionInfoService/DeleteExpirations.md) | Հեռացնում է բոլոր ժամկետանց սեսսիաները տվյալների պահոցի `SESSIONINFO` աղյուսակից և քեշից։ |
| [GetInfo](ISessionInfoService/GetInfo.md) | Վերադարձնում է ընթացիկ [սեսսիայի մասին ինֆորմացիան](../types/SessionInfo.md)։ |
| [GetInfos](ISessionInfoService/GetInfos.md) | Վերադարձնում է տվյալների պահոցի `SESSIONINFO` աղյուսակում պահված բոլոր [սեսսիաների մասին ինֆորմացիան](../types/SessionInfo.md) և ավելացնում քեշում։ |
| [Update](ISessionInfoService/Update.md) | Թարմացնում է ընթացիկ սեսսիայի ինֆորմացիան։ |
