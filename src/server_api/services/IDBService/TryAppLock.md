---
title: IDBService.TryAppLock(string, string, string, string) մեթոդ
---

```c#
public Task<bool> TryAppLock(string resource, 
                             string mode = "Exclusive", 
                             string owner = "Transaction", 
                             string dbPrincipal = "public");
```

Ստեղծում է SQL արգելափակում (lock) տրված անունով ռեսուրսի վրա և վերադարձնում է արժեք, որը ցույց է տալիս արդյոք արգելափակման տեղադրումը հաջողվել է, թե ոչ։

Նախատեսված է զուգահեռ նույն ռեսուրսի հետ աշխատանքը սահմանափակելու համար։

Արգելափակման համար օգտագործվում է [sp_getapplock](https://learn.microsoft.com/en-us/sql/relational-databases/system-stored-procedures/sp-getapplock-transact-sql) պրոցեդուրան։

**Պարամետրեր**
* `resource` - [Ռեսուրսի ներքին անունը (@Resource)](https://learn.microsoft.com/en-us/sql/relational-databases/system-stored-procedures/sp-getapplock-transact-sql#----nresource)։
* `mode` - [Արգելափակման տեղադրման եղանակը (@LockMode)](https://learn.microsoft.com/en-us/sql/relational-databases/system-stored-procedures/sp-getapplock-transact-sql#----lockmode): 
* `owner` - [Արգելափակման տեղադրման սեփականատերը (@LockOwner)](https://learn.microsoft.com/en-us/sql/relational-databases/system-stored-procedures/sp-getapplock-transact-sql#----lockowner)։ 
* `dbPrincipal` - [Տվյալների պահոցում իրավասություն ունեցող կողմ (@DbPrincipal)](https://learn.microsoft.com/en-us/sql/relational-databases/system-stored-procedures/sp-getapplock-transact-sql#----ndbprincipal): 
