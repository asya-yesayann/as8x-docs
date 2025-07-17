---
title: IUserService.GetList() մեթոդ
---

```c#
public Task<List<UserDescription>> GetList()
```

Վերադարձնում է համակարգի բոլոր [օգտագործողների նկարագրությունները](../../types/UserDescription.md)։

<!-- ### ChangeName

```c#
public Task ChangeName(short suid, string newName, string oldName)
```

Փոխում է համակարգի օգտագործողի ներքին անունը։

Անվան դատարկ լինելու կամ նշված ներքին անունով օգտագործողի գոյության դեպքում առաջացնում է սխալ։

**Պարամետրեր**

* `suid` - Օգտագործողի ներքին համար (կոդ)։ 
* `newName` -Օգտագործողի նոր ներքին անունը։
* `oldName` - Օգտագործողի նախկին ներքին անունը։
