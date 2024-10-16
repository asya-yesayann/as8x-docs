---
layout: page
title: "ISessionInfoService սերվիս" 
tags: session
---

## Բովանդակություն

- [Ներածություն](#ներածություն)
- [Հատկություններ](#հատկություններ)
  - [CurrentSessionGuid](#currentsessionguid)
- [Մեթոդներ](#մեթոդներ)
  - [Add](#add)
  - [Delete](#delete)
  - [DeleteExpirations](#deleteexpirations)
  - [GetInfo](#getinfo)
  - [GetInfo](#getinfo-1)
  - [GetInfos](#getinfos)
  - [Update](#update)

## Ներածություն

ISessionInfoService դասը նախատեսված է [սեսսիաների](../types/SessionInfo.md) հետ աշխատանքը ապահովելու համար։

## Հատկություններ

### CurrentSessionGuid

```c#
public string CurrentSessionGuid { get }
```

Վերադարձնում է ընթացիկ [սեսսիայի](../types/SessionInfo.md) ներքին նույնականացման համարը (Guid):

## Մեթոդներ

### Add

```c#
public Task Add(SessionInfo sessionInfo)
```

Ավելացնում է նոր [սեսսիա](../types/SessionInfo.md) տվյալների պահոցի `SESSIONINFO` աղյուսակում և քեշում։

Նոր սեսսիա ավտոմատ կերպով բացվում է ծրագիր մուտք գործելիս։

**Պարամետրեր**

* `sessionInfo` - Ավելացվող [սեսսիայի ինֆորմացիան](../types/SessionInfo.md)։

### Delete

```c#
public Task Delete()
```

Հեռացնում է ընթացիկ [սեսսիան](../types/SessionInfo.md) տվյալների պահոցի `SESSIONINFO` աղյուսակից և քեշից։

Ընթացիկ սեսսիան ավտոմատ կերպով հեռացվում է ծրագրից դուրս գալուց։

### DeleteExpirations

```c#
public Task<List<string>> DeleteExpirations()
```

Հեռացնում է բոլոր ժամկետանց սեսսիաները տվյալների պահոցի `SESSIONINFO` աղյուսակից և քեշից։

Վերադարձնում է հեռացված [սեսսիաների](../types/SessionInfo.md) ներքին նույնականացման համարների (Guid-ների) ցուցակը։

### GetInfo

```c#
public SessionInfo GetInfo()
```

Վերադարձնում է ընթացիկ [սեսսիայի մասին ինֆորմացիան](../types/SessionInfo.md)։

### GetInfo

```c#
public SessionInfo GetInfo(string sessionGuid)
```

Վերադարձնում է նշված ներքին նույնականացման համարով [սեսսիայի մասին ինֆորմացիան](../types/SessionInfo.md) քեշից։

Քեշում բացակայության դեպքում բեռնում է սեսսիայի մասին ինֆորմացիան տվյալների պահոցի `SESSIONINFO` աղյուսակից և ավելացնում քեշում։

**Պարամետրեր**

* `sessionGuid` - Սեսսիայի ներքին նույնականացման համարը (Guid)։

### GetInfos

```c#
public List<SessionInfo> GetInfos()
```

Վերադարձնում է տվյալների պահոցի `SESSIONINFO` աղյուսակում պահված բոլոր [սեսսիաների մասին ինֆորմացիան](../types/SessionInfo.md) և ավելացնում քեշում։

### Update

```c#
public Task Update(SessionInfoModel sessionInfo)
```

Թարմացնում է ընթացիկ սեսսիայի ինֆորմացիան։

**Պարամետրեր**

* `sessionInfo` - Թարմացումը պարունակող ինֆորմացիան։


