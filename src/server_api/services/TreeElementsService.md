---
title: "TreeElementsService սերվիս"
---

## Ներածություն

TreeElementService դասը նախատեսված է ծառի հանգույցների հետ աշխատանքը ապահովելու համար։

Ծառի հանգույցները ծրագրային ստեղծվում են երկու ձևով, 
- փաստաթղթերի հետ կապված [IDocumentService](IDocumentService.md).[StoreInTree](IDocumentService/StoreInTree.md) ֆունկցիայով,
- անկախ հանգույցներ [AddNode](TreeElementsService/AddNode.md) ֆունկցիայով։

Ծառի հանգույցները պահվում են [TREES](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/Trees.html) աղյուսակում։

## Մեթոդներ

| Անվանում | Նկարագրություն |
|----------|----------------|
| [AddNode](TreeElementsService/AddNode.md) | Ավելացնում է ծառի նոր հանգույց տվյալների պահոցում։ |
| [DeleteNode](TreeElementsService/DeleteNode.md) | Հեռացնում է ծառի հանգույցը տվյալների պահոցից։ |
| [EditNode](TreeElementsService/EditNode.md) | Խմբագրում է ծառի հանգույցը և գրանցում տվյալների պահոցում։ |
| [ExistsInDB](TreeElementsService/ExistsInDB.md) | Ստուգում է ծառի հանգույցի առկայությունը տվյալների պահոցում։ |
| [Get](TreeElementsService/Get.md) | Բեռնում է [ծառի տարրը](../types/TreeElement.md) տվյալների պահոցից կամ քեշից, եթե ծառը քեշավոևվող է։ |
| [GetTreeElements](TreeElementsService/GetTreeElements.md) | Վերադարձնում է ծառի տարրերը տվյալների պահոցից կամ քեշից, եթե ծառը քեշավորվող է։ |

<!-- ### CheckAndLoadIfNeeded

```c#
public Task<(bool, byte[], Dictionary<string, TreeElement>)> CheckAndLoadIfNeeded(string treeId, byte[] ts)
```

Եթե ՝ts՝ պարամետրը չի համընկնում ծառի հանգույցների բեռնման և քեշում գրանցման վերջին ժամանակի հետ, ապա բեռնում է տրված ծառի բոլոր հանգույցները և գրանցում քեշում։

Վերադարձնում է՝ արդյոք բեռնվել են ծառի հանգույցները, վերջին բեռնման ժամանակը՝ որպես byte-երի զանգված, և հանգույցները նկարագրող dictionary-ն։ Եթե բեռնումը տեղի չի ունեցել, վերադարձնում է null-եր։

**Պարամետրեր**

* `treeID` - Ծառի ներքին անունը։
* `ts` -  

### ClearOldsFromCache

```c#
public static void ClearOldsFromCache(SqlConnection connection, string treeId = null)
```

Մաքրում է ծառի նկարագրությունը և հանգույցները քեշից։

**Պարամետրեր**

* `connection` - [SqlConnection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlconnection?view=sqlclient-dotnet-standard-5.2) դեպի ծառը պարունակող տվյալների պահոց։
* `treeID` - Ծառի ներքին անունը։ 

-->

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
