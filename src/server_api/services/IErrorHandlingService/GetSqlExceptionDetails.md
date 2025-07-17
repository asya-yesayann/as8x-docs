---
title: IErrorHandlingService.GetSqlExceptionDetails(SqlException) մեթոդ
---

```c#        
public List<ErrorDetail> GetSqlExceptionDetails(SqlException sqlException)
```

Վերադարձնում է `sqlException` պարամետրում պարունակվող SQL-ական ենթասխալների [մանրամասների](../../types/ErrorDetail.md) ցուցակը։

**Պարամետրեր**

* `sqlException` - [SqlException](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlexception) տիպի սխալ:
