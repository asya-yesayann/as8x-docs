---
title: IParametersService.GetDecimalValue(string, short) մեթոդ
---

```c#
public Task<decimal> GetDecimalValue(string paramId, short suid)
```

Վերադարձնում է կոտորակային թիվ տիպի ([N](../../types/system_types.md#numericfieldtype), [NP](../../types/system_types.md#numericpositivefieldtype), [SUMMA](../../types/system_types.md#amountfieldtype), [SUMMAP](../../types/system_types.md#amountpositivefieldtype)) պարամետրի արժեքը՝ ըստ պարամետրի ներքին անվան և օգտագործողի համարի։  
Տիպի անհամապատասխանության դեպքում առաջանում է սխալ։  
Պարամետրի սահմանված չլինելու դեպքում առաջանում է սխալ։

**Պարամետրեր**

* `paramId` - Պարամետրի ներքին անուն (id):
* `suid` - Օգտագործողի ներքին համար (կոդ)։
