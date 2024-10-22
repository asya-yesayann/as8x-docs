---
layout: page
title: "IErrorHandlingService սերվիս" 
---

## Բովանդակություն

- [Բովանդակություն](#բովանդակություն)
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

Մշակում է `exception` պարամետրում նշված SQL-ական սխալի հաղորդագրությունը և վերադարձնում։

**Պարամետրեր**

* `exception` - [SqlException](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlexception) տիպի սխալ, որի հաղորդագրությունը պետք է վերադարձնել:
* `duplicateErrorMessage` - Այն հաղորդագրությունը, որը կավելացվի `exception` պարամետրում նշված սխալի հաղորդագրությանը, եթե սխալը առաջացել է տվյալների պահոցում գոյություն ունեցող տվյալ գրանցել փորձելիս։

**Օրինակ**

Օրինակում տվյալների պահոցում փորձում է գրանցել պատվերը և եթե պատվերի գրանցման ընթացքում առաջանում է SQL-ական սխալ, մշակում է սխալի հաղորդագրությունը [GetSqlExceptionText](#getsqlexceptiontext) մեթոդի միջոցով գրանցում լոգում։ 

Լոգի կարգավորումները անհրաժեշտ է նախապես սահմանել [appsettings.json](../../project/appsettings_json.md) կոնֆիգուրացիոն ֆայլի [Serilog](../../project/appsettings_json.md#serilog) բաժնում:

Տե՛ս նաև

[Ilogger interface](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger)
[Logging in .NET Core and ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/logging)

```c#
using System;
using System.Threading.Tasks;
using ArmSoft.AS8X.Core.ErrorHandling;
using Microsoft.Data.SqlClient;
using Serilog;

namespace ArmSoft.AS8X.Bank.Subsystems;

public class OrderProcessingService
{
    private readonly ILogger logger;
    private readonly IErrorHandlingService errorHandlingService;

    // ինյեկցիա է արվում աշխատանքի համար անհրաժեշտ սերվիսները
    public OrderProcessingService(ILogger logger, IErrorHandlingService errorHandlingService)
    {
        this.errorHandlingService = errorHandlingService;
        this.logger = logger;
 
        this.logger = Log.ForContext("Connected service", nameof(OrderProcessingService));
    }

    public async Task ProcessOrder(int orderID, OrderDetails details)
    {
        try
        {
          // պատվերի գրանցում տվյալների պահոցում
            await StoreOrderInner(orderID, details);
        }
        catch (Exception ex)
        {
            string message = ex.Message;
            if (ex is SqlException)
            {
                message = this.errorHandlingService.GetSqlExceptionText(ex as SqlException);
            }
            // առաջացած սխալի գրանցում լոգում` որպես լոգի գլխագիր ավելացնելով "Task ProcessOrder"-ը և առաջացած սխալի 
            // հաղորդագրությունը գրանցելով Error մակարդակով
            logger.ForContext("Title", "Task ProcessOrder").Information(message);
        }
    }
}
```

### GetSqlRelatedException

```c#           
public Exception GetSqlRelatedException(SqlException exception, string duplicateErrorMessage = "", bool duplicateIsRestException = false)
```

Վերադարձնում է `exception` պարամետրում նշված SQL-ական սխալը բերված բազային [Exception](https://learn.microsoft.com/en-us/dotnet/api/system.exception) տիպի։

**Պարամետրեր**

* `exception` - [SqlException](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlexception) տիպի սխալ:
* `duplicateErrorMessage` - Այն հաղորդագրությունը, որը կավելացվի `exception` պարամետրում նշված սխալի հաղորդագրությանը, եթե սխալը առաջացել է տվյալների պահոցում գոյություն ունեցող տվյալ գրանցել փորձելիս։
* `duplicateIsRestException` - Ցույց է տալիս սխալը RESTException տիպի է թե ոչ։

**Օրինակ**

Օրինակում ստեղծվում է [SqlCommand](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlcommand) դասի օբյեկտ՝ [IDBService](../services/IDBService.md) դասի [CreateCommand](../services/IDBService.md#createcommand) մեթոդի միջոցով` Sql հարցումներ կատարելու համար։

Հարցումով տվյալների պահոցում փորձում է գրանցել փաստաթուղթը և եթե տվյալների պահոցում արդեն գոյություն ունի գրանցվող փաստաթղթի isn-ով տվյալ, առաջացած [SqlException](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlexception) սխալի հաղորդագրությունը լրացուցիր մշակվում է, բերվում բազային [Exception](https://learn.microsoft.com/en-us/dotnet/api/system.exception) տիպի [GetSqlRelatedException](#getsqlrelatedexception) մեթոդի միջոցով և կրկին առաջացնում սխալ։

```c#
private async Task CreateDocumentInner(Document document)
{
  try
  {
    if (!document.ExistsInDB)
    {
      using var cmd = this.DbService.CreateCommand();
      cmd.CommandType = CommandType.StoredProcedure;
      cmd.CommandText = "asp_CreateDoc";
      cmd.Parameters.Add("@ISN", SqlDbType.Int).Value = document.ISN;
      cmd.Parameters.Add("@NAME", SqlDbType.Char, 8).Value = document.Description.DocType;
      cmd.Parameters.Add("@BODY", SqlDbType.VarChar).Value = body;
      await cmd.ExecuteNonQueryAsync();
    }
  }
  catch (SqlException sqlEx)
  {
      throw this.ErrorHandlingService.GetSqlRelatedException(sqlEx, string.Format("Նշված isn-ով փաստաթուղթ արդեն գոյություն ունի", document.ISN));
  }
}
```