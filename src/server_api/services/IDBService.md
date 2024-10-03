---
layout: page
title: "IDBService սերվիս" 
tags: DBService
sublinks:
- { title: "ActiveTrans", ref: activetrans }
- { title: "AppLock", ref: applock }
- { title: "BeginSqlServerDistributedTransaction", ref: beginsqlserverdistributedtransaction }
- { title: "BeginSqlServerDistributedTransactionAsync", ref: beginsqlserverdistributedtransactionasync }
- { title: "BeginTrans", ref: begintrans }
- { title: "BeginTransAsync", ref: begintransasync }
- { title: "CommitTrans", ref: committrans }
- { title: "CommitTransAsync", ref: committransasync }
- { title: "CreateAdditionalConnection", ref: createadditionalconnection }
- { title: "CreateCommand", ref: createcommand }
- { title: "CreateReadOnlyConnection", ref: createreadonlyconnection }
- { title: "GetApproximateServerDate", ref: getapproximateserverdate }
- { title: "GetServerDate", ref: getserverdate }
- { title: "RollBackTrans", ref: rollbacktrans }
- { title: "RollBackTransAsync", ref: rollbacktransasync }
- { title: "SetIsolationLevel", ref: setisolationlevel }
- { title: "SetIsolationLevelAsync", ref: setisolationlevelasync }
- { title: "TryAppLock", ref: tryapplock }
- { title: "AllowSnapshotIsolation", ref: allowsnapshotisolation }
- { title: "Connection", ref: connection }
- { title: "CurrentIsolationLevel", ref: currentisolationlevel }
- { title: "Database", ref: database }
- { title: "ReadOnly", ref: readonly }
- { title: "Server", ref: server }
- { title: "TransDeferred", ref: transdeferred }

---

## Բովանդակություն

- [Ներածություն](#ներածություն)
- [Մեթոդներ](#մեթոդներ)
  - [ActiveTrans](#activetrans)
  - [AppLock](#applock)
  - [BeginSqlServerDistributedTransaction](#beginsqlserverdistributedtransaction)
  - [BeginSqlServerDistributedTransactionAsync](#beginsqlserverdistributedtransactionasync)
  - [BeginTrans](#begintrans)
  - [BeginTransAsync](#begintransasync)
  - [CommitTrans](#committrans)
  - [CommitTransAsync](#committransasync)
  - [CreateAdditionalConnection](#createadditionalconnection)
  - [CreateCommand](#createcommand)
  <!-- - [CreateConnectionString](#createconnectionstring) -->
  - [CreateReadOnlyConnection](#createreadonlyconnection)
  <!-- - [GetApplicationName](#getapplicationname) -->
  - [GetApproximateServerDate](#getapproximateserverdate)
  <!-- - [GetContext](#getcontext) -->
  <!-- - [SetContext](#setcontext) -->
  - [GetServerDate](#getserverdate)
  - [RollBackTrans](#rollbacktrans)
  - [RollBackTransAsync](#rollbacktransasync)
  - [SetIsolationLevel](#setisolationlevel)
  - [SetIsolationLevelAsync](#setisolationlevelasync)
  - [TryAppLock](#tryapplock)
- [Հատկություններ](#հատկություններ)
  - [AllowSnapshotIsolation](#allowsnapshotisolation)
  - [Connection](#connection)
  - [CurrentIsolationLevel](#currentisolationlevel)
  - [Database](#database)
  - [ReadOnly](#readonly)
  - [Server](#server)
  - [TransDeferred](#transdeferred)

## Ներածություն

IDBService դասը նախատեսված է տվյալների պահոցի հետ աշխատանքը ապահովելու համար։
Տալիս է SQL սերվերին միացում, բացում/փակում է տրանզակցիաներ։

## Մեթոդներ

### ActiveTrans

```c#
public bool ActiveTrans();
```

Ստուգում է ակտիվ տրանզակցիայի առկայությունը։

### AppLock

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

### BeginSqlServerDistributedTransaction

```c#
public void BeginSqlServerDistributedTransaction();
```

Բացում է [բաշխված տրանզակցիա](https://learn.microsoft.com/en-us/sql/t-sql/language-elements/begin-distributed-transaction-transact-sql)։

### BeginSqlServerDistributedTransactionAsync

```c#
public Task BeginSqlServerDistributedTransactionAsync();
```

Բացում է [բաշխված տրանզակցիա](https://learn.microsoft.com/en-us/sql/t-sql/language-elements/begin-distributed-transaction-transact-sql)։

### BeginTrans

```c#
public void BeginTrans();
```

[Սկսում է](https://learn.microsoft.com/en-us/sql/t-sql/language-elements/begin-transaction-transact-sql) SQL տրանզակցիա։

### BeginTransAsync

```c#
public Task BeginTransAsync();
```

[Սկսում է](https://learn.microsoft.com/en-us/sql/t-sql/language-elements/begin-transaction-transact-sql) SQL տրանզակցիա։

### CommitTrans

```c#
public void CommitTrans();
```

[Ավարտում է](https://learn.microsoft.com/en-us/sql/t-sql/language-elements/commit-transaction-transact-sql) SQL տրանզակցիան։

### CommitTransAsync

```c#
public Task CommitTransAsync();
```

[Ավարտում է](https://learn.microsoft.com/en-us/sql/t-sql/language-elements/commit-transaction-transact-sql) SQL տրանզակցիան։

### CreateAdditionalConnection

```c#
public SqlConnection CreateAdditionalConnection(bool pooling = true, 
                                                string connectionName = "", 
                                                bool isReadonly = false);
```

Բացում և վերադարձնում է նոր [SQL միացում](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlconnection) դեպի տվյալների պահոց։

**Պարամետրեր**
* `pooling` - Օգտագործել միացումների քեշ, թե ոչ։
  Փոխանցում է [SqlConnectionStringBuilder](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlconnectionstringbuilder).[Pooling](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlconnectionstringbuilder.pooling) հատկությանը։
* `connectionName` - Ծրագրի անունը SQL միացում բացելուց։ 
  Փոխանցում է [SqlConnectionStringBuilder](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlconnectionstringbuilder).[ApplicationName](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlconnectionstringbuilder.applicationname) հատկությանը։
* `isReadonly` - Այո արժեքի դեպքում SQL միացումը բացվում է միայն կարդալու հնարավորությամբ։
  Փոխանցում է [ReadOnly](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.applicationintent) արժեքը [SqlConnectionStringBuilder](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlconnectionstringbuilder).[ApplicationIntent](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlconnectionstringbuilder.applicationname) հատկությանը։

### CreateCommand

```c#
public SqlCommand CreateCommand(TimeoutType timeoutType = TimeoutType.QueryTimeout);
```

Ստեղծում է [SqlCommand](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlcommand), և անմիջապես լրացնում է [CommandTimeout](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlcommand.commandtimeout) ըստ օգտագործողի դրույթներում սահմանված հացման առավելագույն ժամանակի։

**Պարամետրեր**

- `timeoutType` - [SQL հարցման կատարման առավելագույն ժամանակի տիպը](../types/TimeoutType.md)՝ սովորական հարցումների կամ հաշվետվությունների հարցման համար։ 

<!-- ### CreateConnectionString

```c#
public string CreateConnectionString(string sqlServer, string dbName, string login, string password, bool encrypt,
                                     bool pooling = true, string connectionName = Constants.DBConnections.Main,
                                     int? maxPoolSize = null, bool withoutDecrypting = false);
```

Ստեղծում է SQL միացման տողը ([Connection string](https://code-maze.com/aspnetcore-how-to-properly-set-connection-strings/))։
Օգտագործում է [SqlConnectionStringBuilder](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlconnectionstringbuilder) և փոխանցում է ֆունկցիայի պարամետրերը համապատասխան հատկություններին։

**Պարամետրեր**
* `sqlServer` - Սերվերի անունը։
* `dbName` - Սերվերում տվյալների պահոցի անուն։
* `login` - Օգտագործողի մուտքանունը։
* `password` - Օգտագործողի գաղտնաբառը։
* `encrypt` - Նշում է, թե արդյոք տվյալների պահոցին միացումը ծածկագրվի, թե ոչ։
* `pooling` - Օգտագործել միացումների քեշ, թե ոչ։
* `connectionName` - Ծրագրի անունը։ 
* `maxPoolSize` - Միացումների քեշի առավելագույն քանակ։
* `withoutDecrypting` - Նշվում է որ պետք չէ գաղտնաբառը ապակոդավորվի։ -->

### CreateReadOnlyConnection

```c#
public SqlConnection CreateReadOnlyConnection(bool pooling = true);
```

Ստեղծում է միայն կարդալու իրավասությամբ լրացուցիչ SQL միացում դեպի հիմնական տվյալների պահոց։

**Պարամետրեր**
* `pooling` -  Օգտագործել միացումների քեշ, թե ոչ։

<!-- ### GetApplicationName

```c#
public string GetApplicationName(bool withPostfix = true);
```

Վերադարձնում է այն ծրագրի անունը, որին միացված է 8X սերվիսը: Օրինակ՝ ArmSoft.Enterpise.Service, ArmSoft.Bank.Service, ...։ -->

### GetApproximateServerDate

```c#
public Task<DateTime> GetApproximateServerDate();
```

Վերադարձնում է SQL սերվիսի ընթացիկ ամսաթիվը/ժամը որոշակի շեղման հավանականությամբ։

Ավելի արագ է աշխատում քանի [GetServerDate](#getserverdate), քանզի աշխատում է ամեն անգամ SQL չկատարելու սկզբունքով։

<!-- ### GetContext

```c#
public byte[] GetContext(string defaultValue = null);
```

8X սերվիս լոգին լինելուց բացվում է սեսսիա, որի մեջ պահվում է մուտք գործողի մասին ինֆորմացիան։

Մեթոդը վերադարձնում է սեսսիայի մասին կոնտեքստային ինֆորմացիան (մուտք գործած օգտատիրոջ, բացված սեսսիայի id-ները, օգտատիրոջ աշխատանքային տեղի անունը և `defaultValue` պարամետրը) որպես byte-երի զանգված։ 

**Պարամետրեր**
* `defaultValue` - Սովորաբար նշվում է այն դասի անունը, որը կանչում է այս մեթոդը։ Լռությամբ արժեքը **null** է։ -->

<!-- ### SetContext

```c#
public void SetContext(string value);
```

8X սերվիս լոգին լինելուց բացվում է սեսսիա, որի մեջ պահվում է մուտք գործողի մասին ինֆորմացիան։

Մեթոդը գրանցում է սեսսիայի մասին կոնտեքստային ինֆորմացիան (մուտք գործած օգտատիրոջ, բացված սեսսիայի id-ները, օգտատիրոջ աշխատանքային տեղի անունը և `defaultValue` պարամետրը) որպես byte-երի զանգված տվյալների պահոցի [sys.dm_exec_requests](https://learn.microsoft.com/en-us/sql/relational-databases/system-dynamic-management-views/sys-dm-exec-requests-transact-sql?view=sql-server-ver16), [sys.dm_exec_sessions](https://learn.microsoft.com/en-us/sql/relational-databases/system-dynamic-management-views/sys-dm-exec-sessions-transact-sql?view=sql-server-ver16), [sys.sysprocesses](https://learn.microsoft.com/en-us/sql/relational-databases/system-compatibility-views/sys-sysprocesses-transact-sql?view=sql-server-ver16) համակարգային աղյուսակներում [CONTEXT_INFO](https://learn.microsoft.com/en-us/sql/t-sql/statements/set-context-info-transact-sql?view=sql-server-ver16) ֆունկցիայի միջոցով։

**Պարամետրեր**
* `value` - Սովորաբար նշվում է այն դասի անունը, որը կանչում է այս մեթոդը։ -->

### GetServerDate

```c#
public Task<DateTime> GetServerDate();
```

Վերադարձնում է SQL սերվիսի ընթացիկ ամսաթիվը/ժամը կանչելով SQL-ի [GetDate](https://learn.microsoft.com/en-us/sql/t-sql/functions/getdate-transact-sql) ֆունկցիան։


### RollBackTrans

```c#
public void RollBackTrans();
```

[Հետարկում է](https://learn.microsoft.com/en-us/sql/t-sql/language-elements/rollback-transaction-transact-sql) SQL տրանզակցիան։

### RollBackTransAsync

```c#
public Task RollBackTransAsync();
```

[Հետարկում է](https://learn.microsoft.com/en-us/sql/t-sql/language-elements/rollback-transaction-transact-sql) SQL տրանզակցիան։

### SetIsolationLevel

```c#
public void SetIsolationLevel(IsolationLevel level);
```

[Փոխում է բաց տրազակցիայի մեկուսացման մակարդակը](https://learn.microsoft.com/en-us/sql/t-sql/statements/set-transaction-isolation-level-transact-sql)։ 

Տրանզակցիաների բացվում են Read Committed մակարդակով։

**Պարամետրեր**

* `level` - [Տրանզակցիայի իզոլյացիայի մակարդակը](https://learn.microsoft.com/en-us/dotnet/api/system.data.isolationlevel)։

### SetIsolationLevelAsync

```c#
public Task SetIsolationLevelAsync(IsolationLevel level);
```

[Փոխում է բաց տրազակցիայի մեկուսացման մակարդակը](https://learn.microsoft.com/en-us/sql/t-sql/statements/set-transaction-isolation-level-transact-sql)։ 

Տրանզակցիաների բացվում են Read Committed մակարդակով։

**Պարամետրեր**

* `level` - [Տրանզակցիայի իզոլյացիայի մակարդակը](https://learn.microsoft.com/en-us/dotnet/api/system.data.isolationlevel)։

### TryAppLock

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


## Հատկություններ

### AllowSnapshotIsolation

```c#
public bool AllowSnapshotIsolation { get; }
```

Ցույց է տալիս, արդյոք թույլատված է հիմնական տվյալների պահոցում Snapshot [մեկուսացման մակարդակը](https://learn.microsoft.com/en-us/sql/t-sql/statements/set-transaction-isolation-level-transact-sql), տվյալների աղբյուրի հարցումների [կատարուման համար](../definitions/ds.md#supportssnapshotisolation)։

### Connection

```c#
public SqlConnection Connection { get; }
```

Վերադարձնում է բաց [SQL միացումը](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlconnection) դեպի տվյալների պահոց։

### CurrentIsolationLevel

```c#
public IsolationLevel CurrentIsolationLevel { get; }
```

Վերադարձնում է տրանզակցիաների կատարման ընթացիկ [մեկուսացման մակարդակը](https://learn.microsoft.com/en-us/dotnet/api/system.data.isolationlevel)։

### Database

```c#
string Database { get; }
```

Վերադարձնում է ընթացիկ տվյալների պահոցի անունը: 

### ReadOnly

```c#
public bool ReadOnly { get; }
```

Ցույց է տալիս, արդյոք բաց SQL միացումը միայն կարդալու իրավասությամբ է, թե ոչ։ 

### Server

```c#
public string Server { get; }
```

Վերադարձնում է SQL սերվերի անունը: 

### TransDeferred

```c#
public bool TransDeferred { get; set; }
```

Վերադարձնում կամ նշանակում է Fact տիպի օբյեկտների տվյալների պահոցում հետաձգված գրանցման հայտանիշը։
Նախնական արժեքը **true** է։

**true** արժեքի դեպքում [DocumentService](IDocumentService.md).[StoreFact](IDocumentService.md#storefact) մեթոդի կանչի արդյունքում հաշվառումները պահվում են փաստաթղթի [StoredFacts](../definitions/document.md#storedfacts) ցուցակում և գրանցվում տվյալների պահոցում փաստաթղթի գրանցման հետ միասին։ 
**false** արժեքրի դեպքում՝ գրանցվում են անմիջապես։
