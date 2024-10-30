---
layout: page
title: "IErrorHandlingService սերվիս" 
sublinks:
- { title: "GetSqlExceptionDetails", ref: getsqlexceptiondetails }
- { title: "GetSqlExceptionText", ref: getsqlexceptiontext }
- { title: "GetSqlRelatedException", ref: getsqlrelatedexception }
---

## Բովանդակություն

- [Ներածություն](#ներածություն)
- [Մեթոդներ](#մեթոդներ)
  - [GetSqlExceptionDetails](#getsqlexceptiondetails)
  - [GetSqlExceptionText](#getsqlexceptiontext)
  - [GetSqlRelatedException](#getsqlrelatedexception)

## Ներածություն

IErrorHandlingService դասը նախատեսված է ծրագրի աշխատանքի ընթացքում առաջացած sql սխալների մշակման համար։
Մեթոդները ճանաչում են [SqlException](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlexception)-ները և դրանք ձևափոխում են։

## Մեթոդներ

### GetSqlExceptionDetails

```c#        
public List<ErrorDetail> GetSqlExceptionDetails(SqlException sqlException)
```

Վերադարձնում է `sqlException` պարամետրում պարունակվող SQL-ական ենթասխալների [մանրամասների](../types/ErrorDetail.md) ցուցակը։

**Պարամետրեր**

* `sqlException` - [SqlException](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlexception) տիպի սխալ:

### GetSqlExceptionText

```c#           
public string GetSqlExceptionText(SqlException exception, string duplicateErrorMessage = "")
```

Փորձում է ճանաչել SQL-ական սխալը և վերադարձնել վերջնական օգտագործողներին ավելի հասկանալի հաղորդագրություն։
Օրինակ. գետևյալ հաղորդագրության փոխարեն վերադարձնում է 
  - `The connection is broken and recovery is not possible. The client driver attempted to recover the connection one or more times and all attempts failed. Increase the value of ConnectRetryCount to increase the number of recovery attempts.`
  - `Ցանցային կապի խզում: Կապվեք ցանցի ադմինիստրատորի հետ`

**Պարամետրեր**

* `exception` - [SqlException](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlexception) տիպի սխալ, որի հաղորդագրությունը պետք է վերադարձնել:
* `duplicateErrorMessage` - Այն հաղորդագրությունը, որը կվերադարձնի տվյալների պահոցում տվյալի կրկնության դեպքում։
  Սա միայն հատուկ թույլատրված աղյուսակների՝ դրանցում կրկնությունների, դեպքում է։

**Օրինակ**

Տե՛ս օգտագործման [օրինակը](../examples/IErrorHandlingService.md#օրինակ-1)։

### GetSqlRelatedException

```c#           
public Exception GetSqlRelatedException(SqlException exception, 
                                        string duplicateErrorMessage = "", 
                                        bool duplicateIsRestException = false)
```

Ձևափոխում է SQL-ական սխալը փոխելով հաղորդագրությունը տեքստը ըստ [GetSqlExceptionText](#getsqlexceptiontext)-ի։

**Պարամետրեր**

* `exception` - [SqlException](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlexception) տիպի սխալ:
* `duplicateErrorMessage` - Այն հաղորդագրությունը, որը կվերադարձնի տվյալների պահոցում տվյալի կրկնության դեպքում։
  Սա միայն հատուկ թույլատրված աղյուսակների՝ դրանցում կրկնությունների, դեպքում է։
* `duplicateIsRestException` - Վերադարձնել `RESTException`, եթե տվյալի կրկնության կրկնության սխալ է։

**Օրինակ**

Տե՛ս օգտագործման [օրինակը](../examples/IErrorHandlingService.md#օրինակ-2)։
