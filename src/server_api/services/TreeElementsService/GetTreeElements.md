---
title: TreeElementsService.GetTreeElements(int, Dictionary<string, TreeElement>, bool, bool) մեթոդ
---

```c#
public Task<Dictionary<string, TreeElement>> GetTreeElements(string treeId, 
                                                             string nodeType = null, 
                                                             string key = null, 
                                                             CacheUsage cacheUsage = CacheUsage.Use);
```

Վերադարձնում է ծառի տարրերը տվյալների պահոցից կամ քեշից, եթե ծառը քեշավորվող է։  
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
