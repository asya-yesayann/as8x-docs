---
title: IErrorHandlingService.GetSqlRelatedException(SqlException, string, bool) մեթոդ
---

```c#           
public Exception GetSqlRelatedException(SqlException exception, 
                                        string duplicateErrorMessage = "", 
                                        bool duplicateIsRestException = false)
```

Ձևափոխում է SQL-ական սխալը փոխելով հաղորդագրությունը տեքստը ըստ [GetSqlExceptionText](GetSqlExceptionText.md)-ի։

**Պարամետրեր**

* `exception` - [SqlException](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlexception) տիպի սխալ:
* `duplicateErrorMessage` - Այն հաղորդագրությունը, որը կվերադարձնի տվյալների պահոցում տվյալի կրկնության դեպքում։
  Սա միայն հատուկ թույլատրված աղյուսակների՝ դրանցում կրկնությունների, դեպքում է։
* `duplicateIsRestException` - Վերադարձնել `RESTException`, եթե տվյալի կրկնության կրկնության սխալ է։

**Օրինակ**

Տե՛ս օգտագործման [օրինակը](../../examples/IErrorHandlingService.md#օրինակ-2)։
