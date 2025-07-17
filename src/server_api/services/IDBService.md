---
title: "IDBService սերվիս"
---

## Ներածություն

IDBService դասը նախատեսված է տվյալների պահոցի հետ աշխատանքը ապահովելու համար։
Տալիս է SQL սերվերին միացում, բացում/փակում է տրանզակցիաներ։

## Մեթոդներ

| Անվանում | Նկարագրություն |
|----------|----------------|
| [ActiveTrans](IDBService/ActiveTrans.md) | Ստուգում է ակտիվ տրանզակցիայի առկայությունը։ |
| [AppLock](IDBService/AppLock.md) | Ստեղծում է SQL արգելափակում (lock) տրված անունով ռեսուրսի վրա։ |
| [BeginSqlServerDistributedTransaction](IDBService/BeginSqlServerDistributedTransaction.md) | Բացում է [բաշխված տրանզակցիա](https://learn.microsoft.com/en-us/sql/t-sql/language-elements/begin-distributed-transaction-transact-sql)։ |
| [BeginSqlServerDistributedTransactionAsync](IDBService/BeginSqlServerDistributedTransactionAsync.md) | Բացում է [բաշխված տրանզակցիա](https://learn.microsoft.com/en-us/sql/t-sql/language-elements/begin-distributed-transaction-transact-sql)։ |
| [BeginTrans](IDBService/BeginTrans.md) | [Սկսում է](https://learn.microsoft.com/en-us/sql/t-sql/language-elements/begin-transaction-transact-sql) SQL տրանզակցիա։ |
| [BeginTransAsync](IDBService/BeginTransAsync.md) | [Սկսում է](https://learn.microsoft.com/en-us/sql/t-sql/language-elements/begin-transaction-transact-sql) SQL տրանզակցիա։ |
| [CommitTrans](IDBService/CommitTrans.md) | [Ավարտում է](https://learn.microsoft.com/en-us/sql/t-sql/language-elements/commit-transaction-transact-sql) SQL տրանզակցիան։ |
| [CommitTransAsync](IDBService/CommitTransAsync.md) | [Ավարտում է](https://learn.microsoft.com/en-us/sql/t-sql/language-elements/commit-transaction-transact-sql) SQL տրանզակցիան։ |
| [CreateAdditionalConnection](IDBService/CreateAdditionalConnection.md) | Բացում և վերադարձնում է նոր [SQL միացում](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlconnection) դեպի տվյալների պահոց։ |
| [CreateCommand](IDBService/CreateCommand.md) | Ստեղծում է [SqlCommand](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlcommand), և անմիջապես լրացնում է [CommandTimeout](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlcommand.commandtimeout) ըստ օգտագործողի դրույթներում սահմանված հացման առավելագույն ժամանակի։ |
| [CreateReadOnlyConnection](IDBService/CreateReadOnlyConnection.md) | Ստեղծում է միայն կարդալու իրավասությամբ լրացուցիչ SQL միացում դեպի հիմնական տվյալների պահոց։ |
| [GetApproximateServerDate](IDBService/GetApproximateServerDate.md) | Վերադարձնում է SQL սերվիսի ընթացիկ ամսաթիվը/ժամը որոշակի շեղման հավանականությամբ։ |
| [GetServerDate](IDBService/GetServerDate.md) | Վերադարձնում է SQL սերվիսի ընթացիկ ամսաթիվը/ժամը կանչելով SQL-ի [GetDate](https://learn.microsoft.com/en-us/sql/t-sql/functions/getdate-transact-sql) ֆունկցիան։ |
| [RollBackTrans](IDBService/RollBackTrans.md) | [Հետարկում է](https://learn.microsoft.com/en-us/sql/t-sql/language-elements/rollback-transaction-transact-sql) SQL տրանզակցիան։ |
| [RollBackTransAsync](IDBService/RollBackTransAsync.md) | [Հետարկում է](https://learn.microsoft.com/en-us/sql/t-sql/language-elements/rollback-transaction-transact-sql) SQL տրանզակցիան։ |
| [SetIsolationLevel](IDBService/SetIsolationLevel.md) | [Փոխում է բաց տրազակցիայի մեկուսացման մակարդակը](https://learn.microsoft.com/en-us/sql/t-sql/statements/set-transaction-isolation-level-transact-sql)։ |
| [SetIsolationLevelAsync](IDBService/SetIsolationLevelAsync.md) | [Փոխում է բաց տրազակցիայի մեկուսացման մակարդակը](https://learn.microsoft.com/en-us/sql/t-sql/statements/set-transaction-isolation-level-transact-sql)։ |
| [TryAppLock](IDBService/TryAppLock.md) | Ստեղծում է SQL արգելափակում (lock) տրված անունով ռեսուրսի վրա և վերադարձնում է արժեք, որը ցույց է տալիս արդյոք արգելափակման տեղադրումը հաջողվել է, թե ոչ։ |

## Հատկություններ

| Անվանում | Նկարագրություն |
|----------|----------------|
| [AllowSnapshotIsolation](IDBService/AllowSnapshotIsolation.md) | Ցույց է տալիս, արդյոք թույլատված է հիմնական տվյալների պահոցում Snapshot [մեկուսացման մակարդակը](https://learn.microsoft.com/en-us/sql/t-sql/statements/set-transaction-isolation-level-transact-sql), տվյալների աղբյուրի հարցումների [կատարման համար](../definitions/ds.md#supportssnapshotisolation)։ |
| [Connection](IDBService/Connection.md) | Վերադարձնում է բաց [SQL միացումը](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlconnection) դեպի տվյալների պահոց։ |
| [CurrentIsolationLevel](IDBService/CurrentIsolationLevel.md) | Վերադարձնում է տրանզակցիաների կատարման ընթացիկ [մեկուսացման մակարդակը](https://learn.microsoft.com/en-us/dotnet/api/system.data.isolationlevel)։ |
| [Database](IDBService/Database.md) | Վերադարձնում է ընթացիկ տվյալների պահոցի անունը: |
| [ReadOnly](IDBService/ReadOnly.md) | Ցույց է տալիս, արդյոք բաց SQL միացումը միայն կարդալու իրավասությամբ է, թե ոչ։ |
| [Server](IDBService/Server.md) | Վերադարձնում է SQL սերվերի անունը: |
| [TransDeferred](IDBService/TransDeferred.md) | Վերադարձնում կամ նշանակում է Fact տիպի օբյեկտների տվյալների պահոցում հետաձգված գրանցման հայտանիշը։ |