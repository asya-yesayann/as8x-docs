---
title: IParametersService.GetStringValue(string, short) մեթոդ
---

```c#
public Task<string> GetStringValue(string paramId, short suid)
```

Վերադարձնում է տող տիպի ([C](../../types/system_types.md#stringfieldtype), [CH](../../types/system_types.md#chfieldtype), [FOLDER](../../types/system_types.md#folderfieldtype), [AMACC](../../types/system_types.md#amaccfieldtype), [TREE](../../types/system_types.md#treefieldtype), [FULLTREE](../../types/system_types.md#treefieldtype), [PATH](../../types/system_types.md#pathfieldtype), [FILE](../../types/system_types.md#filefieldtype)) պարամետրի արժեքը՝ ըստ պարամետրի ներքին անվան և օգտագործողի համարի։  
Տիպի անհամապատասխանության դեպքում առաջանում է սխալ։  
Պարամետրի սահմանված չլինելու դեպքում առաջանում է սխալ։

**Պարամետրեր**

* `paramId` - Պարամետրի ներքին անուն (id):
* `suid` - Օգտագործողի ներքին համար (կոդ)։
