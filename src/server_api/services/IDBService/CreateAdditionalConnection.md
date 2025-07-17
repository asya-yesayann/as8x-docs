---
title: IDBService.CreateAdditionalConnection(bool, string, bool) մեթոդ
---

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
