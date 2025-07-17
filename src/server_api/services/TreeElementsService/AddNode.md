---
title: TreeElementsService.AddNode(TreeElement, bool) մեթոդ
---

```c#
public Task<List<TreeNode>> AddNode(TreeElement treeElement, bool overwrite = false)
```

Ավելացնում է ծառի նոր հանգույց տվյալների պահոցում։

**Պարամետրեր**

* `treeElement` - [Ծառի տարր](../../types/TreeElement.md)։
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
