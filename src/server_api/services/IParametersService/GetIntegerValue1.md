---
title: IParametersService.GetIntegerValue(string, short) մեթոդ
---

```c#
public Task<int> GetIntegerValue(string paramId, short suid)
```

Վերադարձնում է ամբողջ թիվ տիպի ([N](../../types/system_types.md#numericfieldtype), [NP](../../types/system_types.md#numericpositivefieldtype)) պարամետրի արժեքը՝ ըստ պարամետրի ներքին անվան և օգտագործողի համարի։  
Տիպի անհամապատասխանության դեպքում առաջանում է սխալ։  
Պարամետրի սահմանված չլինելու դեպքում առաջանում է սխալ։

**Պարամետրեր**

* `paramId` - Պարամետրի ներքին անուն (id):
* `suid` - Օգտագործողի ներքին համար (կոդ)։
