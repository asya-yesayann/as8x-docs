---
layout: page
title: "IErrorHandlingService սերվիս" 
---

## Բովանդակություն

- [Ներածություն](#ներածություն)
- [Մեթոդներ](#մեթոդներ)
  - [GetSqlExceptionDetails](#getsqlexceptiondetails)
  - [GetSqlExceptionText](#getsqlexceptiontext)
  - [GetSqlRelatedException](#getsqlrelatedexception)

## Ներածություն

IErrorHandlingService դասը նախատեսված է ծրագրի աշխատանքի ընթացքում առաջացած սխալների մշակման համար։

## Մեթոդներ

### GetSqlExceptionDetails

```c#        
public List<ErrorDetail> GetSqlExceptionDetails(SqlException sqlException)
```

Վերադարձնում է `exception` պարամետրում նշված SQL-ական սխալում պարունակվող ենթասխալների [նկարագրությունների](../types/ErrorDetail.md) ցուցակը։

**Պարամետրեր**

* `sqlException` - [SqlException](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlexception) տիպի սխալ:

### GetSqlExceptionText

```c#           
public string GetSqlExceptionText(SqlException exception, string duplicateErrorMessage = "")
```

Վերադարձնում է `exception` պարամետրում նշված SQL-ական սխալի հաղորդագրությունը։

**Պարամետրեր**

* `exception` - [SqlException](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlexception) տիպի սխալ, որի հաղորդագրությունը պետք է վերադարձնել:
* `duplicateErrorMessage` - Այն հաղորդագրությունը, որը կավելացվի `exception` պարամետրում նշված սխալի հաղորդագրությանը, եթե սխալը առաջացել է տվյալների պահոցում գոյություն ունեցող տվյալ գրանցել փորձելիս։

### GetSqlRelatedException

```c#           
public Exception GetSqlRelatedException(SqlException exception, string duplicateErrorMessage = "", bool duplicateIsRestException = false)
```

Վերադարձնում է `exception` պարամետրում նշված SQL-ական սխալը բերված բազային [Exception](https://learn.microsoft.com/en-us/dotnet/api/system.exception) տիպի։

**Պարամետրեր**

* `exception` - [SqlException](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlexception) տիպի սխալ:
* `duplicateErrorMessage` - Այն հաղորդագրությունը, որը կավելացվի `exception` պարամետրում նշված սխալի հաղորդագրությանը, եթե սխալը առաջացել է տվյալների պահոցում գոյություն ունեցող տվյալ գրանցել փորձելիս։
* `duplicateIsRestException` - Ցույց է տալիս սխալը RESTException տիպի է թե ոչ։