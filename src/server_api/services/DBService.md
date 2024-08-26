---
layout: page
title: "DBService" 
tags: DBService
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
  - [CreateConnectionString](#createconnectionstring)
  - [CreateReadOnlyConnection](#createreadonlyconnection)
  - [GetApplicationName](#getapplicationname)
  - [GetApproximateServerDate](#getapproximateserverdate)
  - [GetContext](#getcontext)
  - [SetContext](#setcontext)
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
  - [Server](#server)
  - [TransDeferred](#transdeferred)
  - [ReadOnly](#readonly)

## Ներածություն

DBService դասը նախատեսված է տվյալների պահոցի հետ աշխատանքը ապահովելու համար։

## Մեթոդներ

### ActiveTrans

```c#
public bool ActiveTrans();
```

Ստուգում է ակտիվ տրանզակցիայի առկայությունը։

### AppLock

```c#
public Task AppLock(string resource, string errorMsg = "", string mode = "Exclusive", string owner = "Transaction", int timeout = 0, string dbPrincipal = "public");
```

Ստեղծում է SQL արգելափակում (lock) տրված անունով ռեսուրսի վրա։
Եթե արգելափակումը չի ստացվում ստեղծել, ապա առաջանում է սխալ։

Նախատեսված է զուգահեռ նույն ռեսուրսի հետ աշխատանքը սահմանափակելու համար։

Արգելափակման համար օգտագործվում է [sp_getapplock](https://learn.microsoft.com/en-us/sql/relational-databases/system-stored-procedures/sp-getapplock-transact-sql?view=sql-server-ver16) պրոցեդուրան։

**Պարամետրեր**
* `resource` - [Ռեսուրսի ներքին անունը](https://learn.microsoft.com/en-us/sql/relational-databases/system-stored-procedures/sp-getapplock-transact-sql?view=sql-server-ver16#----nresource)։
* `errorMsg` - Արգելափակման տեղադրման չստացվելու դեպքում առաջացող սխալի հաղորդագրությունը։
* `mode` - [Արգելափակման տեղադրման եղանակը](https://learn.microsoft.com/en-us/sql/relational-databases/system-stored-procedures/sp-getapplock-transact-sql?view=sql-server-ver16#----lockmode):
* `owner` - [Արգելափակման տեղադրման սեփականատերը](https://learn.microsoft.com/en-us/sql/relational-databases/system-stored-procedures/sp-getapplock-transact-sql?view=sql-server-ver16#----lockowner)։
* `timeout` - [Արգելափակման տեղադրման առավելագույն ժամանակը միլիվայրկյաններով](https://learn.microsoft.com/en-us/sql/relational-databases/system-stored-procedures/sp-getapplock-transact-sql?view=sql-server-ver16#----locktimeout)։
* `dbPrincipal` - [Տվյալների պահոցում իրավասություն ունեցող կողմ](https://learn.microsoft.com/en-us/sql/relational-databases/system-stored-procedures/sp-getapplock-transact-sql?view=sql-server-ver16#----ndbprincipal)

### BeginSqlServerDistributedTransaction

```c#
public void BeginSqlServerDistributedTransaction();
```

Բացում է [Distributed](https://hazelcast.com/glossary/distributed-transaction/) տեսակի [Sql տրանզակցիա](https://www.tutorialspoint.com/sql/sql-transactions.htm)։

### BeginSqlServerDistributedTransactionAsync

```c#
public Task BeginSqlServerDistributedTransactionAsync();
```

Բացում է [Distributed](https://hazelcast.com/glossary/distributed-transaction/) տեսակի [Sql տրանզակցիա](https://www.tutorialspoint.com/sql/sql-transactions.htm) ասինխրոն եղանակով։

### BeginTrans

```c#
public void BeginTrans();
```

Բացում է [Sql տրանզակցիա](https://www.tutorialspoint.com/sql/sql-transactions.htm)։

### BeginTransAsync

```c#
public Task BeginTransAsync();
```

Բացում է [Sql տրանզակցիա](https://www.tutorialspoint.com/sql/sql-transactions.htm) ասինխրոն եղանակով։

### CommitTrans

```c#
public void CommitTrans();
```

Հաստատում է [Sql տրանզակցիայի](https://www.tutorialspoint.com/sql/sql-transactions.htm) ընթացքում կատարված փոփոխությունները և փակում տրանզակցիան։

### CommitTransAsync

```c#
public Task CommitTransAsync();
```

Հաստատում է [Sql տրանզակցիայի](https://www.tutorialspoint.com/sql/sql-transactions.htm) ընթացքում կատարված փոփոխությունները և փակում տրանզակցիան ասինխրոն եղանակով։

### CreateAdditionalConnection

```c#
public SqlConnection CreateAdditionalConnection(bool pooling = true, string connectionName = "", bool isReadonly = false);
```

Ստեղծում է լրացուցիչ Sql միացում դեպի 8X սերվիսի կողմից օգտագործվող տվյալների բազա։

**Պարամետրեր**
* `pooling` - [Pooling](https://www.linkedin.com/pulse/how-sql-connection-pool-works-prashant-pathak/)-ի միացման հայտանիշ։ Լռությամբ արժեքը true է։
* `connectionName` - Այն ծրագրի անունը, որը միանալու է Sql-ին։
* `isReadonly` - Ցույց է տալիս, արդյոք ընթացիկ տվյալների բազային միացումը միայն կարդալու իրավասությամբ է (Read-only), թե ոչ։

### CreateCommand

```c#
public SqlCommand CreateCommand(TimeoutType timeoutType = TimeoutType.QueryTimeout);
```

Ստեղծում է [SqlCommand](https://learn.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlcommand?view=netframework-4.8.1&viewFallbackFrom=netstandard-2.1) դասի նոր օբյեկտ, որը նախատեսված է Sql հարցումների կատարման համար։

**Պարամետրեր**

- `timeoutType` - [Sql հարցման կատարման առավելագույն ժամանակը](TimeoutType.md)։

### CreateConnectionString

```c#
public string CreateConnectionString(string sqlServer, string dbName, string login, string password, bool encrypt,
                                     bool pooling = true, string connectionName = Constants.DBConnections.Main,
                                     int? maxPoolSize = null, bool withoutDecrypting = false);
```

Ստեղծում է Sql միացում դեպի նշված սերվերի տվյալների բազա և վերադարձնում [Connection string](https://code-maze.com/aspnetcore-how-to-properly-set-connection-strings/)` Sql-ի հետ կապի հաստատման համար։

**Պարամետրեր**
* `sqlServer` - Սերվերի անունը։
* `dbName` - Սերվերում գտնվող տվյալների բազայի անուն։
* `login` - Տվյալների բազայի սերվերին մուտք գործելու համար օգտագործվող մուտքանունը։
* `password` - Տվյալների բազայի սերվերին մուտք գործելու համար օգտագործվող գաղտնաբառը։
* `encrypt` - Նշում է, թե արդյոք տվյալների բազային միացումը ծածկագրվի, թե ոչ։
* `pooling` - [Pooling](https://www.linkedin.com/pulse/how-sql-connection-pool-works-prashant-pathak/)-ի միացման հայտանիշ։ Լռությամբ արժեքը true է։
* `connectionName` - Այն ծրագրի անունը, որը միանալու է Sql-ին։
* `maxPoolSize` - Տվյալների բազայի [միացումների Pool](https://www.linkedin.com/pulse/how-sql-connection-pool-works-prashant-pathak/)-ում միացումների առավելագույն քանակը։
* `withoutDecrypting` - Նշում է, արդյոք գաղտնաբառը օգտագործվի առանց ապակոդավորելու։ Լռությամբ արժեքը false է։

### CreateReadOnlyConnection

```c#
public SqlConnection CreateReadOnlyConnection(bool pooling = true);
```

Ստեղծում է միայն կարդալու իրավասությամբ (Read-only) լրացուցիչ Sql միացում դեպի 8X սերվիսի կողմից օգտագործվող տվյալների բազա։

**Պարամետրեր**
* `pooling` - [Pooling](https://www.linkedin.com/pulse/how-sql-connection-pool-works-prashant-pathak/)-ի միացման հայտանիշ։ Լռությամբ արժեքը true է։

### GetApplicationName

```c#
public string GetApplicationName(bool withPostfix = true);
```

Վերադարձնում է այն ծրագրի անունը, որին միացված է 8X սերվիսը: Օրինակ՝ ArmSoft.Enterpise.Service, ArmSoft.Bank.Service, ...։

### GetApproximateServerDate

```c#
public Task<DateTime> GetApproximateServerDate();
```

Վերադարձնում է 8X սերվիսի կողմից օգտագործվող Sql սերվերի մոտավոր ամսաթիվը և ժամանակը։

Sql սերվերի անունը անհրաժեշտ է նախապես սահմանել [appsettings.json](../../project/appsettings_json.md) կոնֆիգուրացիոն ֆայլի [db](../../project/appsettings_json.md#db) բաժնի `database` պարամետրում։

### GetContext

```c#
public byte[] GetContext(string defaultValue = null);
```

8X սերվիս լոգին լինելուց բացվում է սեսսիա, որի մեջ պահվում է մուտք գործողի մասին ինֆորմացիան։
Մեթոդը վերադարձնում է սեսսիայի մասին կոնտեքստային ինֆորմացիան(մուտք գործած օգտատիրոջ, բացված սեսսիայի id-ները, օգտատիրոջ աշխատանքային տեղի անունը և `defaultValue` պարամետրը) որպես byte-երի զանգված։ 

**Պարամետրեր**
* `defaultValue` - Սովորաբար նշվում է այն դասի անունը, որը կանչում է այս մեթոդը։

### SetContext

```c#
public void SetContext(string value);
```

8X սերվիս լոգին լինելուց բացվում է սեսսիա, որի մեջ պահվում է մուտք գործողի մասին ինֆորմացիան։

Մեթոդը գրանցում է սեսսիայի մասին կոնտեքստային ինֆորմացիան(մուտք գործած օգտատիրոջ, բացված սեսսիայի id-ները, օգտատիրոջ աշխատանքային տեղի անունը և `defaultValue` պարամետրը) որպես byte-երի զանգված տվյալների բազայի [sys.dm_exec_requests](https://learn.microsoft.com/en-us/sql/relational-databases/system-dynamic-management-views/sys-dm-exec-requests-transact-sql?view=sql-server-ver16), [sys.dm_exec_sessions](https://learn.microsoft.com/en-us/sql/relational-databases/system-dynamic-management-views/sys-dm-exec-sessions-transact-sql?view=sql-server-ver16), [sys.sysprocesses](https://learn.microsoft.com/en-us/sql/relational-databases/system-compatibility-views/sys-sysprocesses-transact-sql?view=sql-server-ver16) համակարգային աղյուսակներում [CONTEXT_INFO](https://learn.microsoft.com/en-us/sql/t-sql/statements/set-context-info-transact-sql?view=sql-server-ver16) ֆունկցիայի միջոցով։

**Պարամետրեր**
* `value` - Սովորաբար նշվում է այն դասի անունը, որը կանչում է այս մեթոդը։

### GetServerDate

```c#
public Task<DateTime> GetServerDate();
```

Վերադարձնում է 8X սերվիսի կողմից օգտագործվող Sql սերվերի ընթացիկ ամսաթիվը և ժամանակը։

Sql սերվերի անունը անհրաժեշտ է նախապես սահմանել [appsettings.json](../../project/appsettings_json.md) կոնֆիգուրացիոն ֆայլի [db](../../project/appsettings_json.md#db) բաժնի `database` պարամետրում։

### RollBackTrans

```c#
public void RollBackTrans();
```

Չեղարկում է [Sql տրանզակցիայի](https://www.tutorialspoint.com/sql/sql-transactions.htm) ընթացքում կատարված փոփոխությունները և փակում տրանզակցիան։

### RollBackTransAsync

```c#
public Task RollBackTransAsync();
```

Չեղարկում է [Sql տրանզակցիայի](https://www.tutorialspoint.com/sql/sql-transactions.htm) ընթացքում կատարված փոփոխությունները և փակում տրանզակցիան ասինխրոն եղանակով։

### SetIsolationLevel

```c#
public void SetIsolationLevel(IsolationLevel level);
```

Սահմանում է բացվող [տրանզակցիաների](https://www.tutorialspoint.com/sql/sql-transactions.htm) իզոլյացիայի [մակարդակը](https://www.geeksforgeeks.org/transaction-isolation-levels-dbms/)։ 
Տրանզակցիաների լռությամբ իզոլյացիայի մակարդակը [Read committed](https://sqlperformance.com/2014/04/t-sql-queries/the-read-committed-isolation-level)-ն է։

**Պարամետրեր**

* `level` - [Տրանզակցիայի իզոլյացիայի մակարդակը](https://learn.microsoft.com/en-us/dotnet/api/system.data.isolationlevel?view=net-8.0)։

### SetIsolationLevelAsync

```c#
public Task SetIsolationLevelAsync(IsolationLevel level);
```

Սահմանում է բացվող [տրանզակցիաների](https://www.tutorialspoint.com/sql/sql-transactions.htm) իզոլյացիայի [մակարդակը](https://www.geeksforgeeks.org/transaction-isolation-levels-dbms/)  ասինխրոն եղանակով։
Տրանզակցիաների լռությամբ իզոլյացիայի մակարդակը [Read committed](https://sqlperformance.com/2014/04/t-sql-queries/the-read-committed-isolation-level)-ն է։

**Պարամետրեր**

* `level` - [Տրանզակցիայի իզոլյացիայի մակարդակը](https://learn.microsoft.com/en-us/dotnet/api/system.data.isolationlevel?view=net-8.0)։

### TryAppLock

```c#
public Task TryAppLock(string resource, string errorMsg = "", string mode = "Exclusive", string owner = "Transaction", string dbPrincipal = "public");
```

Ստեղծում է SQL արգելափակում (lock) տրված անունով ռեսուրսի վրա և վերադարձնում է արժեք, որը ցույց է տալիս արդյոք արգելափակման տեղադրումը հաջողվել է, թե ոչ։

Նախատեսված է զուգահեռ նույն ռեսուրսի հետ աշխատանքը սահմանափակելու համար։

Արգելափակման համար օգտագործվում է [sp_getapplock](https://learn.microsoft.com/en-us/sql/relational-databases/system-stored-procedures/sp-getapplock-transact-sql?view=sql-server-ver16) պրոցեդուրան։

**Պարամետրեր**
* `resource` - [Ռեսուրսի ներքին անունը](https://learn.microsoft.com/en-us/sql/relational-databases/system-stored-procedures/sp-getapplock-transact-sql?view=sql-server-ver16#----nresource)։
* `errorMsg` - Արգելափակման տեղադրման չստացվելու դեպքում առաջացող սխալի հաղորդագրությունը։
* `mode` - [Արգելափակման տեղադրման եղանակը](https://learn.microsoft.com/en-us/sql/relational-databases/system-stored-procedures/sp-getapplock-transact-sql?view=sql-server-ver16#----lockmode):
* `owner` - [Արգելափակման տեղադրման սեփականատերը](https://learn.microsoft.com/en-us/sql/relational-databases/system-stored-procedures/sp-getapplock-transact-sql?view=sql-server-ver16#----lockowner)։
* `dbPrincipal` - [Տվյալների պահոցում իրավասություն ունեցող կողմ](https://learn.microsoft.com/en-us/sql/relational-databases/system-stored-procedures/sp-getapplock-transact-sql?view=sql-server-ver16#----ndbprincipal)

## Հատկություններ

### AllowSnapshotIsolation

```c#
public bool AllowSnapshotIsolation { get; }
```

Տվյալների աղբյուրի հարցումների կատարման միացման վրա [Snapshot](https://www.dremio.com/wiki/snapshot-isolation/#:~:text=Snapshot%20Isolation%20is%20a%20database,being%20affected%20by%20concurrent%20transactions.) իզոլյացիայի մակարդակի միացման հայտանիշ։

### Connection

```c#
public SqlConnection Connection { get; }
```

Վերադարձնում է [Sql միացում](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlconnection?view=sqlclient-dotnet-standard-5.2) դեպի 8X սերվիսի կողմից օգտագործվող ընթացիկ տվյալների բազա։

### CurrentIsolationLevel

```c#
public IsolationLevel CurrentIsolationLevel { get; }
```

Վերադարձնում է տրանզակցիաների կատարման ընթացիկ [իզոլյացիայի մակարդակը](https://learn.microsoft.com/en-us/dotnet/api/system.data.isolationlevel?view=net-8.0)։

### Database

```c#
string Database { get; }
```

Վերադարձնում է այն տվյալների բազայի անունը, որին միացված է 8X սերվիսը: 

Այն անհրաժեշտ է նախապես սահմանել [appsettings.json](../../project/appsettings_json.md) կոնֆիգուրացիոն ֆայլի [db](../../project/appsettings_json.md#db) բաժնի `database` պարամետրում։

### Server

```c#
public string Server { get; }
```

Վերադարձնում է Sql սերվերի անունը, որը նախատեսված է 8X սերվիսի կողմից Sql միացման համար: 

Այն անհրաժեշտ է նախապես սահմանել [appsettings.json](../../project/appsettings_json.md) կոնֆիգուրացիոն ֆայլի [db](../../project/appsettings_json.md#db) բաժնի `server` պարամետրում:

### TransDeferred

```c#
public bool TransDeferred { get; set; }
```

### ReadOnly

```c#
public bool ReadOnly { get; }
```

Ցույց է տալիս, արդյոք ընթացիկ տվյալների բազային միացումը միայն կարդալու իրավասությամբ է (Read-only), թե ոչ։ 

Այն անհրաժեշտ է նախապես սահմանել [appsettings.json](../../project/appsettings_json.md) կոնֆիգուրացիոն ֆայլի [db](../../project/appsettings_json.md#db) բաժնի `readOnly` պարամետրում։
