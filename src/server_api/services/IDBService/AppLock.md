---
title: IDBService.AppLock(string, string, string, string, int, string) մեթոդ
---

```c#
public Task AppLock(string resource, 
                    string errorMsg = "", 
                    string mode = "Exclusive", 
                    string owner = "Transaction", 
                    int timeout = 0, 
                    string dbPrincipal = "public");
```

Ստեղծում է SQL արգելափակում (lock) տրված անունով ռեսուրսի վրա։
Եթե արգելափակումը չի ստացվում ստեղծել, ապա առաջանում է սխալ։

Նախատեսված է զուգահեռ նույն ռեսուրսի հետ աշխատանքը սահմանափակելու համար։

Արգելափակման համար օգտագործվում է [sp_getapplock](https://learn.microsoft.com/en-us/sql/relational-databases/system-stored-procedures/sp-getapplock-transact-sql) պրոցեդուրան։

**Պարամետրեր**
* `resource` - [Ռեսուրսի ներքին անունը (@Resource)](https://learn.microsoft.com/en-us/sql/relational-databases/system-stored-procedures/sp-getapplock-transact-sql#----nresource)։
* `errorMsg` - Արգելափակման տեղադրման չստացվելու դեպքում առաջացող սխալի հաղորդագրությունը։ 
  Եթե պարամետրի արժեքը դատարկ տող է, ապա առաջանում է ստանդարտ տեքստով սխալ։
* `mode` - [Արգելափակման տեղադրման եղանակը (@LockMode)](https://learn.microsoft.com/en-us/sql/relational-databases/system-stored-procedures/sp-getapplock-transact-sql#----lockmode): 
* `owner` - [Արգելափակման տեղադրման սեփականատերը (@LockOwner)](https://learn.microsoft.com/en-us/sql/relational-databases/system-stored-procedures/sp-getapplock-transact-sql#----lockowner)։ 
* `timeout` - [Արգելափակման տեղադրման առավելագույն ժամանակը միլիվայրկյաններով (@LockTimeout)](https://learn.microsoft.com/en-us/sql/relational-databases/system-stored-procedures/sp-getapplock-transact-sql#----locktimeout)։ 
* `dbPrincipal` - [Տվյալների պահոցում իրավասություն ունեցող կողմ (@DbPrincipal)](https://learn.microsoft.com/en-us/sql/relational-databases/system-stored-procedures/sp-getapplock-transact-sql#----ndbprincipal):