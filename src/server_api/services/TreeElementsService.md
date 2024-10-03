---
layout: page
title: "TreeElementService սերվիս" 
sublinks:
- { title: "AddNode", ref: addnode }
- { title: "DeleteNode", ref: deletenode }
- { title: "EditNode", ref: editnode }
- { title: "ExistsInDB", ref: existsindb }
- { title: "Get", ref: get }
- { title: "GetTreeElements", ref: gettreeelements }
---

## Բովանդակություն
- [Ներածություն](#ներածություն)
- [Մեթոդներ](#մեթոդներ)
  - [AddNode](#addnode)
  <!-- - [CheckAndLoadIfNeeded](#checkandloadifneeded) -->
  <!-- - [ClearOldsFromCache](#clearoldsfromcache) -->
  - [DeleteNode](#deletenode)
  - [EditNode](#editnode)
  - [ExistsInDB](#existsindb)
  - [Get](#get)
  - [GetTreeElements](#gettreeelements)
  <!-- - [Store](#store) -->


## Ներածություն

TreeElementService դասը նախատեսված է ծառի հանգույցների հետ աշխատանքը ապահովելու համար։

Ծառւ էլեմենտները ծրագրային ստեղծվում են երկու ձևով, 
- փաստաթղթերի հետ կապված [IDocumentService](IDocumentService.md).[StoreInTree](IDocumentService.md#storeintree) ֆունկցիայով,
- անկախ հանգույցներ [AddNode](#addnode) ֆունկցիայով։

Ծառի հանգույցները պահվում են [TREES](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/Trees.html) աղյուսակում։

## Մեթոդներ

### AddNode

```c#
public Task<List<TreeNode>> AddNode(TreeElement treeElement, bool overwrite = false)
```

Ավելացնում է ծառի նոր հանգույց տվյալների պահոցում։

**Պարամետրեր**

* `treeElement` - [Ծառի տարր](../types/TreeElement.md)։
* `overwrite` - Տվյալների պահոցում ծառի հանգույցի առկայության դեպքում հանգույցի վերագրանցման հայտանիշ։ 
  Այս հնարավորությունը հասանելի է միայն փաստաթղթի հետ չկապակցված ծառի հանգույցների համար։ 

<!-- ### CheckAndLoadIfNeeded

```c#
public Task<(bool, byte[], Dictionary<string, TreeElement>)> CheckAndLoadIfNeeded(string treeId, byte[] ts)
```

Եթե ՝ts՝ պարամետրը չի համընկնում ծառի հանգույցների բեռնման և քեշում գրանցման վերջին ժամանակի հետ, ապա բեռնում է տրված ծառի բոլոր հանգույցները և գրանցում քեշում։

Վերադարձնում է՝ արդյոք բեռնվել են ծառի հանգույցները, վերջին բեռնման ժամանակը՝ որպես byte-երի զանգված, և հանգույցները նկարագրող dictionary-ն։ Եթե բեռնումը տեղի չի ունեցել, վերադարձնում է null-եր։

**Պարամետրեր**

* `treeID` - Ծառի ներքին անունը։
* `ts` -  -->

<!-- ### ClearOldsFromCache

```c#
public static void ClearOldsFromCache(SqlConnection connection, string treeId = null)
```

Մաքրում է ծառի նկարագրությունը և հանգույցները քեշից։

**Պարամետրեր**

* `connection` - [SqlConnection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlconnection?view=sqlclient-dotnet-standard-5.2) դեպի ծառը պարունակող տվյալների պահոց։
* `treeID` - Ծառի ներքին անունը։ -->

### DeleteNode

```c#
public Task<TreeNode> DeleteNode(string treeID, string key)
```

Հեռացնում է ծառի հանգույցը տվյալների պահոցից։

**Պարամետրեր**

* `treeID` - Ծառի ներքին անունը։
* `key` - Ծառի հանգույցի կոդը։

### EditNode

```c#
public Task<List<TreeNode>> EditNode(TreeElement treeElement)
```

Խմբագրում է ծառի հանգույցը և գրանցում տվյալների պահոցում։

**Պարամետրեր**

* `treeElement` - [Ծառի տարրը](../types/TreeElement.md)։

### ExistsInDB

```c#
public Task<bool> ExistsInDB(string treeId, string key)
```

Ստուգում է ծառի հանգույցի առկայությունը տվյալների պահոցում։

**Պարամետրեր**

* `treeId` - Ծառի ներքին անունը։
* `key` - Ծառի հանգույցի կոդը։

### Get

```c#
public Task<TreeElement> Get(string treeId, string key, bool useCache = true)
```

Բեռնում է [ծառի տարրը](../types/TreeElement.md) տվյալների պահոցից կամ քեշից, եթե ծառը քեշավոևվող է։

**Պարամետրեր**

* `treeId` - Ծառի ներքին անունը։
* `key` - Ծառի հանգույցի կոդը։
* `useCache` - Քեշում առկայության դեպքում քեշից բեռնման հայտանիշ։

### GetTreeElements

```c#
public Task<Dictionary<string, TreeElement>> GetTreeElements(string treeId, 
                                                             string nodeType = null, 
                                                             string key = null, 
                                                             CacheUsage cacheUsage = CacheUsage.Use);
```

Վերադարձնում է ծառի տարրերը տվյալների պահոցից կամ քեշից, եթե ծառը քեշավոևվող է։  
Վերադարձվող Dictionary-ում որպես բանալի հանդես է գալիս ծառի հանգույցի կոդը։

**Պարամետրեր**

* `treeId` - Ծառի ներքին անունը։
* `nodeType` - Ծառի հանգույցի տեսակը՝  
    `"0"` - Բեռնել միայն տերևները։  
    `"1"` - Բեռնել միայն ոչ տերևները։  
* `key` - Ծառի հանգույցի կոդը։
* `cacheUsage` - Քեշում հանգույցի նկարագրության առկայության դեպքում քեշից բեռնման հայտանիշ։ 

<!-- ### Store

```c#
public Task<List<TreeNode>> Store(int isn, Dictionary<string, TreeElement> cols, bool existsInDB, bool returnModifiedTreeNodes)
```

Գրանցում է `cols` պարամետրում տրված ծառի հանգույցները տվյալների պահոցի [TREES](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/Trees.html) աղյուսակում և վերադարձնում 

**Պարամետրեր**

* `isn` - Գրանցման ենթակա ծառի հանգույցներին տարրերին կապակցված փաստաթղթի ներքին նույնակականացման համարը։
* `cols` - Գրանցման ենթակա ծառի հանգույցների ցուցակը։
* `existsInDB` - 
* `returnModifiedTreeNodes` -  -->
