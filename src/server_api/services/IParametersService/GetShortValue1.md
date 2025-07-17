---
title: IParametersService.GetShortValue(string, short) մեթոդ
---

```c#
public Task<short> GetShortValue(string paramId, short suid)
```

Վերադարձնում է կարճ ամբողջ թիվ տիպի ([N](../../types/system_types.md#numericfieldtype), [NP](../../types/system_types.md#numericpositivefieldtype)) պարամետրի արժեքը՝ ըստ պարամետրի ներքին անվան և օգտագործողի համարի։  
Տիպի անհամապատասխանության դեպքում առաջանում է սխալ։  
Պարամետրի սահմանված չլինելու դեպքում առաջանում է սխալ։

**Պարամետրեր**

* `paramId` - Պարամետրի ներքին անուն (id):
* `suid` - Օգտագործողի ներքին համար (կոդ)։
