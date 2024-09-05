---
layout: page
title: "FolderService սերվիս" 
sublinks:
- { title: "ClearCache", ref: clearcache }
- { title: "Exists", ref: exists }
- { title: "GetElement", ref: getelement }
- { title: "GetElement", ref: getelement-1 }
- { title: "GetElements", ref: getelements }
- { title: "GetElements", ref: getelements-1 }
- { title: "GetISN", ref: getisn }
---

## Բովանդակություն
- [Ներածություն](#ներածություն)
- [Մեթոդներ](#մեթոդներ)
  - [Exists](#exists)
  - [GetElement](#getelement)
  - [GetElement](#getelement-1)
  - [GetElements](#getelements)
  - [GetElements](#getelements-1)
  - [GetISN](#getisn)
  <!-- - [Store](#store) -->


## Ներածություն

FolderService դասը նախատեսված է [FOLDERS](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/Folders.html) աղյուսակից թղթապանակի տարրերի հետ աշխատանքը ապահովելու համար։

## Մեթոդներ

### Exists

```c#
public Task<bool> Exists(string folderId);
```

Ստուգում է որևէ տարրի առկայությունը տվյալների պահոցի [FOLDERS](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/Folders.html) աղյուսակում։

**Պարամետրեր**

* `folderId` - Թղթապանակի ներքին անունը։

### GetElement

```c#
public Task<FolderElement> GetElement(string folderId, int isn);
```

Վերադարձնում է [թղթապանակի տարրը](FolderElement.md)՝ ըստ թղթապանակի ներքին անվան և փաստաթղթի ներքին նույնականացման համարի։

Տարրի առկա չլինելու դեպքում վերադարձնում է **null**։

**Պարամետրեր**

* `folderId` - Թղթապանակի ներքին անունը։
* `isn` - Թղթապանակում գրանցված փաստաթղթի ներքին նույնականացման համարը։

### GetElement

```c#
public Task<FolderElement> GetElement(string folderId, string key, bool noLock = false);
```

Վերադարձնում է [թղթապանակի տարրը](FolderElement.md)՝ ըստ թղթապանակի ներքին անվան և բանալու։

Տարրի առկա չլինելու դեպքում վերադարձնում է **null**։

**Պարամետրեր**

* `folderId` - Թղթապանակի ներքին անունը։
* `key` - Տարրի բանալին թղթապանակում։
* `noLock` - Թղթապանակի տարրը վերադարձնող Sql հարցման [NOLOCK](https://learn.microsoft.com/en-us/sql/t-sql/queries/hints-transact-sql-table?view=sql-server-ver16#readuncommitted) (READUNCOMMITTED) ռեժիմով կատարման հայտանիշ։

### GetElements

```c#
public Task<List<FolderElement>> GetElements(string folderID);
```

Վերադարձնում է թղթապանակի բոլոր [տարրերը](FolderElement.md):

**Պարամետրեր**

* `folderID` - Թղթապանակի ներքին անունը։

### GetElements

```c#
public Task<List<FolderElement>> GetElements(string folderID, List<string> keys);
```

Վերադարձնում է թղթապանակի նշված բանալիներով [տարրերը](FolderElement.md):

**Պարամետրեր**

* `folderID` - Թղթապանակի ներքին անունը։
* `keys` - Թղթապանակի տարրերի բանալիների ցուցակ։

### GetISN

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
