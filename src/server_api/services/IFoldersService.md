---
layout: page
title: "FolderService" 
tags: FolderService
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
  - [Store](#store)


## Ներածություն

FolderService դասը նախատեսված է թղթապանակի տարրերի հետ աշխատանքը ապահովելու համար։

## Մեթոդներ

### Exists

```c#
public Task<bool> Exists(string folderId);
```

Ստուգում է թղթապանակի առկայությունը տվյալների պահոցի [FOLDERS](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/Folders.html) աղյուսակում։

**Պարամետրեր**

* `folderId` - Թղթապանակի ներքին անունը։

### GetElement

```c#
public Task<FolderElement> GetElement(string folderId, int isn);
```

Վերադարձնում է թղթապանակի տարրը նկարագրող դասը՝ ըստ թղթապանակի ներքին անվան և թղթապանակում գրանցված փաստաթղթի ներքին նույնականացման համարի։

**Պարամետրեր**

* `folderId` - Թղթապանակի ներքին անունը։
* `isn` - Թղթապանակում գրանցված փաստաթղթի ներքին նույնականացման համարը։

### GetElement

```c#
public Task<FolderElement> GetElement(string folderId, string key, bool noLock = false);
```

Վերադարձնում է թղթապանակի տարրը նկարագրող դասը՝ ըստ թղթապանակի ներքին անվան և տարրի կոդի։

**Պարամետրեր**

* `folderId` - Թղթապանակի ներքին անունը։
* `key` - Թղթապանակի տարրի կոդը։
* `noLock` - Թղթապանակի տարրը վերադարձնող Sql հարցման [NOLOCK](https://dev.to/sardarmudassaralikhan/why-do-we-nolock-in-sql-server-with-an-example-447c#:~:text=In%20SQL%20Server%2C%20the%20NOLOCK,what's%20called%20%22dirty%20reads.%22) ռեժիմով կատարման հայտանիշ։

### GetElements

```c#
public Task<List<FolderElement>> GetElements(string folderID);
```

Վերադարձնում է թղթապանակի բոլոր տարրերը։

**Պարամետրեր**

* `folderID` - Թղթապանակի ներքին անունը։

### GetElements

```c#
public Task<List<FolderElement>> GetElements(string folderID, List<string> keys);
```

Վերադարձնում է թղթապանակի նշված կոդերով տարրերը նկարագրող դասերը։

**Պարամետրեր**

* `folderID` - Թղթապանակի ներքին անունը։
* `keys` - Թղթապանակի տարրերի կոդերի ցուցակ։

### GetISN

```c#
public Task<int> GetISN(string folderId, string key);
```

Վերադարձնում է թղթապանակում գրանցված փաստաթղթի ներքին նույնականացման համարը՝ ըստ թղթապանակի ներքին անվան և տարրի կոդի։

**Պարամետրեր**

* `folderId` - Թղթապանակի ներքին անունը։
* `key` - Թղթապանակի տարրի կոդը։

### Store

```c#
public Task Store(int isn, List<FolderElement> folderElements, string defaultComment, bool existsInDb);
```

Գրանցում է folderElements արգումենտում նշված թղթապանակների տարրերը տվյալների պահոցի [FOLDERS](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/Folders.html) աղյուսակից։


**Պարամետրեր**

* `isn` - 
* `folderElements` - Գրանցման ենթակա թղթապանակի տարրերի ցուցակը։
* `defaultComment` - Թղթապանակի տարրերում Comment դաշտի դատարկ արժեքի դեպքում թղթապանակի տարրերի հայերեն անվանում։
* `existsInDb` - isn արգումենտով նշված փաստաթղթի թղթապանակները տվյալների պահոցից հեռացման հայտանիշ։







