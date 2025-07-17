---
title: IFoldersService.GetElement(string, string, bool) մեթոդ
---

```c#
public Task<FolderElement> GetElement(string folderId, string key, bool noLock = false);
```

Վերադարձնում է [թղթապանակի տարրը](../../types/FolderElement.md)՝ ըստ թղթապանակի ներքին անվան և բանալու։

Տարրի առկա չլինելու դեպքում վերադարձնում է **null**։

**Պարամետրեր**

* `folderId` - Թղթապանակի ներքին անունը։
* `key` - Տարրի բանալին թղթապանակում։
* `noLock` - Թղթապանակի տարրը վերադարձնող Sql հարցման [NOLOCK](https://learn.microsoft.com/en-us/sql/t-sql/queries/hints-transact-sql-table?view=sql-server-ver16#readuncommitted) (READUNCOMMITTED) ռեժիմով կատարման հայտանիշ։
