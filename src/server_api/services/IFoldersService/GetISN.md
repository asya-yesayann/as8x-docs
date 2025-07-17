---
title: IFoldersService.GetISN(string, string) մեթոդ
---

```c#
public Task<int> GetISN(string folderId, string key);
```

Վերադարձնում է թղթապանակում գրանցված փաստաթղթի ներքին նույնականացման համարը՝ ըստ թղթապանակի ներքին անվան և բանալու։

Տարրի առկա չլինելու դեպքում վերադարձնում է **-1**։

**Պարամետրեր**

* `folderId` - Թղթապանակի ներքին անունը։
* `key` - Տարրի բանալին թղթապանակում։

<!-- ### Store

```c#
public Task Store(int isn, List<FolderElement> folderElements, string defaultComment, bool existsInDb);
```

Գրանցում է ՝folderElements՝ արգումենտում նշված [թղթապանակների տարրերը](FolderElement.md) տվյալների պահոցի [FOLDERS](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/Folders.html) աղյուսակում։

**Պարամետրեր**

* `isn` - Գրանցման ենթակա թղթապանակի տարրերին կապակցված փաստաթղթի ներքին նույնակականացման համարը։
* `folderElements` - Գրանցման ենթակա թղթապանակի տարրերի ցուցակը։
* `defaultComment` - Թղթապանակի տարրերում Comment դաշտի դատարկ արժեքի դեպքում թղթապանակի տարրերին տրվող հայերեն անվանում։
* `existsInDb` - `isn` ներքին նույնականացման համարով փաստաթղթին կապակցված թղթապանակի տարրերի տվյալների պահոցից հեռացման հայտանիշ։ -->
