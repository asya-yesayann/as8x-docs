---
layout: page
title: "IOlapDBService սերվիս" 
tags: [DBService, Olap]
---

## Բովանդակություն

- [Ներածություն](#ներածություն)
- [Մեթոդներ](#մեթոդներ)
  - [BeginTrans](#begintrans)
  - [BeginTransAsync](#begintransasync)
  - [CommitTrans](#committrans)
  - [CommitTransAsync](#committransasync)
  - [CreateAdditionalConnection](#createadditionalconnection)
  - [GetApproximateServerDate](#getapproximateserverdate)
  - [GetServerDate](#getserverdate)
  - [RollBackTrans](#rollbacktrans)
  - [RollBackTransAsync](#rollbacktransasync)
- [Հատկություններ](#հատկություններ)
  - [Connection](#connection)

## Ներածություն

IOlapDBService դասը նախատեսված է **OLAP** տվյալների պահոցի հետ աշխատանքը ապահովելու համար։
Այն ապահովում է SQL սերվերին միացում և տրանզակցիաների բացում/փակում:

**OLAP** տվյալների պահոցը կարող է լինել նույն սերվերում, որտեղ գտնվում է հիմնական տվյալների պահոցը, կամ այն կարող է տեղակայված լինել այլ սերվերում:

**OLAP** տվյալների պահոցի ուրիշ սերվերում տեղակայված լինելը որոշվում է `OLPDB` պարամետրի միջոցով։ Պարամետրի դատարկ արժեքի դեպքում **OLAP** տվյալների պահոցը գտնվում է նույն սերվերում, ինչ հիմնական տվյալների պահոցը, հակառակ դեպքում ուրիշ սերվերում։

**OLAP** տվյալների պահոցի անունը հիմնական տվյալների պահոցից միշտ տարբերվում է միայն `_OLAP` վերջավորությամբ։

**OLAP** միացման կարգավորումները անհրաժեշտ է տալ [appsettings.json](../../project/appsettings_json.md) կոնֆիգուրացիոն ֆայլի [db](../../project/appsettings_json.md#db) բաժնում` որպես տվյալների պահոցի անուն նշելով **OLAP** տվյալների պահոցին համապատասխան հիմնական պահոցի անունը։

Օրինակ եթե **OLAP** տվյալների պահոցի անունը `test_bank_Olap` է, ապա [appsettings.json](../../project/appsettings_json.md) կոնֆիգուրացիոն ֆայլի [db](../../project/appsettings_json.md#db) բաժնի `database` բաժնում անհրաժեշտ է նշել `test_bank`։

## Մեթոդներ

### BeginTrans

```c#
public void BeginTrans();
```

[Սկսում է](https://learn.microsoft.com/en-us/sql/t-sql/language-elements/begin-transaction-transact-sql) SQL տրանզակցիա **OLAP** տվյալների պահոցում։

### BeginTransAsync

```c#
public Task BeginTransAsync();
```

[Սկսում է](https://learn.microsoft.com/en-us/sql/t-sql/language-elements/begin-transaction-transact-sql) SQL տրանզակցիա **OLAP** տվյալների պահոցում։

### CommitTrans

```c#
public void CommitTrans();
```

[Ավարտում է](https://learn.microsoft.com/en-us/sql/t-sql/language-elements/commit-transaction-transact-sql) SQL տրանզակցիան **OLAP** տվյալների պահոցում։

### CommitTransAsync

```c#
public Task CommitTransAsync();
```

[Ավարտում է](https://learn.microsoft.com/en-us/sql/t-sql/language-elements/commit-transaction-transact-sql) SQL տրանզակցիան **OLAP** տվյալների պահոցում։

### CreateAdditionalConnection

```c#
public SqlConnection CreateAdditionalConnection(bool pooling = true, 
                                                string connectionName = "", 
                                                bool isReadonly = false);
```

Բացում և վերադարձնում է նոր [SQL միացում](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlconnection) դեպի **OLAP** տվյալների պահոց։

**Պարամետրեր**
* `pooling` - Օգտագործել միացումների քեշ, թե ոչ։
  Փոխանցում է [SqlConnectionStringBuilder](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlconnectionstringbuilder).[Pooling](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlconnectionstringbuilder.pooling) հատկությանը։
* `connectionName` - Ծրագրի անունը SQL միացում բացելուց։ 
  Փոխանցում է [SqlConnectionStringBuilder](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlconnectionstringbuilder).[ApplicationName](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlconnectionstringbuilder.applicationname) հատկությանը։
* `isReadonly` - Այո արժեքի դեպքում SQL միացումը բացվում է միայն կարդալու հնարավորությամբ։
  Փոխանցում է [ReadOnly](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.applicationintent) արժեքը [SqlConnectionStringBuilder](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlconnectionstringbuilder).[ApplicationIntent](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlconnectionstringbuilder.applicationname) հատկությանը։

### GetApproximateServerDate

```c#
public Task<DateTime> GetApproximateServerDate();
```

Վերադարձնում է SQL սերվերի ընթացիկ ամսաթիվը/ժամը որոշակի շեղման հավանականությամբ։

Ավելի արագ է աշխատում քան [GetServerDate](#getserverdate), քանզի աշխատում է ամեն անգամ SQL չկատարելու սկզբունքով։

### GetServerDate

```c#
public Task<DateTime> GetServerDate();
```

Վերադարձնում է SQL սերվերի ընթացիկ ամսաթիվը/ժամը կանչելով SQL-ի [GetDate](https://learn.microsoft.com/en-us/sql/t-sql/functions/getdate-transact-sql) ֆունկցիան։

### RollBackTrans

```c#
public void RollBackTrans();
```

[Հետարկում է](https://learn.microsoft.com/en-us/sql/t-sql/language-elements/rollback-transaction-transact-sql) SQL տրանզակցիան **OLAP** տվյալների պահոցում։

### RollBackTransAsync

```c#
public Task RollBackTransAsync();
```

[Հետարկում է](https://learn.microsoft.com/en-us/sql/t-sql/language-elements/rollback-transaction-transact-sql) SQL տրանզակցիան **OLAP** տվյալների պահոցում։

## Հատկություններ

### Connection

```c#
public SqlConnection Connection { get; }
```

Վերադարձնում է բաց [SQL միացումը](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlconnection) դեպի **OLAP** տվյալների պահոց։
