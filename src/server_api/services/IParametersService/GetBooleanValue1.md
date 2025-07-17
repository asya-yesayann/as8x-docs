---
title: IParametersService.GetBooleanValue(string, short) մեթոդ
---

```c#
public Task<bool> GetBooleanValue(string paramId, short suid)
```

Վերադարձնում է [տրամաբանական տիպի](../../types/system_types.md#booleanfieldtype) պարամետրի արժեքը՝ ըստ պարամետրի ներքին անվան և օգտագործողի համարի։  
Տիպի անհամապատասխանության դեպքում առաջանում է սխալ։  
Պարամետրի սահմանված չլինելու դեպքում առաջանում է սխալ։

**Պարամետրեր**

* `paramId` - Պարամետրի ներքին անուն (id)։
* `suid` - Օգտագործողի ներքին համար (կոդ)։
