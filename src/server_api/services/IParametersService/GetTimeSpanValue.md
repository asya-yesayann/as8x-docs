---
title: IParametersService.GetTimeSpanValue(string) մեթոդ
---

```c#
public Task<TimeSpan> GetTimeSpanValue(string paramId)
```

Վերադարձնում է ժամ տիպի ([TIME](../../types/system_types.md#timefieldtype), [TIMELONG](../../types/system_types.md#timefieldtype)) պարամետրի արժեքը՝ ըստ պարամետրի ներքին անվան։  
Տիպի անհամապատասխանության դեպքում առաջանում է սխալ։  
Պարամետրի սահմանված չլինելու դեպքում առաջանում է սխալ։

**Պարամետրեր**

* `paramId` - Պարամետրի ներքին անուն (id):
