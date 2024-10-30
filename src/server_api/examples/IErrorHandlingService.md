---
layout: page
title: "Օրինակ IErrorHandlingService" 
sublinks:
- { title: "Օրինակ GetSqlExceptionText, ILogger", ref: օրինակ-1 }
- { title: "Օրինակ GetSqlRelatedException", ref: օրինակ-2 }
---

## Բովանդակություն
- [IErrorHandlingService, GetSqlExceptionText, ILogger օգտագործման օրինակ](#օրինակ-1)
- [IErrorHandlingService, GetSqlRelatedException օգտագործման օրինակ](#օրինակ-2)

## Օրինակ 1

IErrorHandlingService, GetSqlExceptionText, ILogger օգտագործման օրինակ։

Օրինակում տվյալների պահոցում փորձում է գրանցել պատվերները։ 
Եթե պատվերի գրանցման ընթացքում առաջանում է SQL-ական սխալ, ապա
- մշակում է սխալի հաղորդագրությունը [GetSqlExceptionText](#getsqlexceptiontext) մեթոդի միջոցով,
- գրանցում լոգում,
- գրանցում է սխալների հավաքաման տեղեկանքի մեջ։

Լոգի կարգավորումները անհրաժեշտ է նախապես սահմանել [appsettings.json](../../project/appsettings_json.md) կոնֆիգուրացիոն ֆայլի [Serilog](../../project/appsettings_json.md#serilog) բաժնում:

Տե՛ս նաև  
[Ilogger interface](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger)  
[Logging in .NET Core and ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/logging)

```c#
public class OrderProcessingService
{
    private readonly ILogger logger;
    private readonly IErrorHandlingService errorHandlingService;
    private readonly IStorageService storageService;

    // ինյեկցիա է արվում աշխատանքի համար անհրաժեշտ սերվիսները
    public OrderProcessingService(
        IErrorHandlingService errorHandlingService, 
        IStorageService storageService)
    {
        this.logger = Log.ForContext("Connected service", nameof(OrderProcessingService));

        this.errorHandlingService = errorHandlingService;
        this.storageService = storageService;
    }

    public async Task<StorageInfo> ProcessOrder(OrderDetails details)
    {
        using var report = new TextReport(storageService);
        report.ArmenianCaption = "Սխալներ".ToArmenianANSI();
        report.EnglishCaption = "Errors";
        report.AddFragment(120);

        foreach (var orderDetail in details)
        {
            try
            {
                // պատվերի գրանցում տվյալների պահոցում
                await StoreOrderInner(orderID, details);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex is SqlException sqlex)
                {
                    message = this.errorHandlingService.GetSqlExceptionText(sqlex);
                }
                // առաջացած սխալի գրանցում լոգում
                logger.ForContext("Title", "Task ProcessOrder").Information(message);

                // սխալները հավաքում ենք տեղեկանքի մեջ
                report.AddRow(message);
                report.AddRow("");
            }
        }

        // վերջում վերադարձնում ենք սխալների տեղեկանքը
        return await report.SaveToStorageAndClose();
    }

    //private Task StoreOrderInner( ...
}
```

## Օրինակ 2

Օրինակում ստեղծվում է [SqlCommand](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlcommand) դասի օբյեկտ՝ [IDBService](../services/IDBService.md) դասի [CreateCommand](../services/IDBService.md#createcommand) մեթոդի միջոցով` Sql հարցումներ կատարելու համար։

Հարցումով տվյալների պահոցում փորձում է գրանցել փաստաթուղթը, և եթե տվյալների պահոցում արդեն գոյություն ունի գրանցվող փաստաթղթի isn-ով տվյալ, ապա առաջացած [SqlException](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlexception) սխալի հաղորդագրությունը փոխարինում է վերջնական օգտագործողներին ավելի հասկանալի հաղորդագրության [GetSqlRelatedException](#getsqlrelatedexception) մեթոդի միջոցով։

```c#
private async Task CreateDocumentInner(Document document)
{
    try
    {
        using var cmd = this.DbService.CreateCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "asp_CreateDoc";
        cmd.Parameters.Add("@ISN", SqlDbType.Int).Value = document.ISN;
        cmd.Parameters.Add("@NAME", SqlDbType.Char, 8).Value = document.Description.DocType;
        cmd.Parameters.Add("@BODY", SqlDbType.VarChar).Value = body;
        await cmd.ExecuteNonQueryAsync();
    }
    catch (SqlException sqlEx)
    {
        throw this.ErrorHandlingService.GetSqlRelatedException(sqlEx, $"Համակարգի սիստեմային {document.ISN} համարի(ISN) կրկնություն");
    }
}
```
