---
layout: page
title: "DPR-ի նկարագրման ձեռնարկ"
---

## Բովանդակություն
- [Բովանդակություն](#բովանդակություն)
- [Նախաբան](#նախաբան)
- [.cs ընդլայնմամբ ֆայլի սահմանում](#cs-ընդլայնմամբ-ֆայլի-սահմանում)
  - [Օժանդակ դասերի սահմանում](#օժանդակ-դասերի-սահմանում)
  - [Կոնստրուկտորի ձևավորում](#կոնստրուկտորի-ձևավորում)
  - [Execute](#execute)

## Նախաբան
Սերվիսային երկար տևող հարցումներ կատարելու և կատարման ընթացքին հետևելու համար նկարագրվում է Dpr (Data Processing Request):

8X-ում DPR նկարագրության համար հարկավոր է ունենալ .cs ընդլայնմամբ ֆայլ, որը պարունակում է սերվերում աշխատող տրամաբանությունը։

## .cs ընդլայնմամբ ֆայլի սահմանում

Ամբողջական կոդը դիտելու համար [տե՛ս](../examples/dpr/code.cs):

### Օժանդակ դասերի սահմանում

- Ստեղծել DPR-ի կատարման համար անհրաժեշտ պարամետրերը նկարագրող դաս։

```c#
public class IndexDefragmentRequest
{
   public bool UpdateUsage { get; set; }
}
```

- Ստեղծել DPR-ի կատարման արդյունքում ստացվող տվյալները նկարագրող դասը։ Այս օրինակը արդյունքում ոչինչ չի վերադարձնում, հետևաբար դասի նկարագրման կարիք չկա։ 

- Հայտատարել դաս, որը ունի DPR ատրիբուտը և ժառանգում է DataProcessingRequest<R, P> դասը՝ որպես R փոխանցելով Dpr-ի կատարման արդյունքում ստացվող տվյալները նկարագրող դասը, իսկ որպես P՝ պարամետրերը նկարագրող դասը։ Պարամետրերի բացակայության դեպքում անհրաժեշտ է փոխանցել `NoParam` դասը,իսկ արդյունքի բացակայության դեպքում՝ `NoResult` դասը։

```c#
[DPR(nameof(IndexDefragment), DPRType = DPRType.Other, ArmenianCaption = "Ինդեքսների դեֆրագմենտացիա",
                                      EnglishCaption = "Index defragmentation")]
public class IndexDefragment : DataProcessingRequest<NoResult, IndexDefragmentRequest>
```

### Կոնստրուկտորի ձևավորում
- Ձևավորել կոնստրուկտորը, որտեղ անհրաժեշտ է [ինյեկցիա](../../project/injection.md) անել աշխատանքի համար անհրաժեշտ service-ները։

```c#
private readonly IDBService dbService;

public IndexDefragment(IDBService dbService)
{
  this.DbService = dbService;
}
```

### Execute 

Dpr-ի կատարման համար անհրաժեշտ է override անել բազային դասի `Execute` մեթոդը՝ փոխանցելով պարամետրերը նկարագրող դասը և վերադարձնելով կատարման արդյունքում ստացվող տվյալները նկարագրող դասը։

```c#
public override async Task<NoResult> Execute(IndexDefragmentRequest request, CancellationToken stoppingToken)
{
      using var cmd = this.dbService.Connection.CreateCommand();
      cmd.CommandType = CommandType.StoredProcedure;
      cmd.CommandText = "asp_IndexDefrag";
      cmd.Parameters.Add("@withupdateusage", SqlDbType.Bit).Value = request.UpdateUsage;
      await cmd.ExecuteNonQueryAsync(stoppingToken);
      return new NoResult();
}
```
Execute մեթոդում անհրաժեշտ է ստեղծել [SqlCommand](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlcommand?view=sqlclient-dotnet-standard-5.2) դասի օբյեկտ՝ IDBService դասի [Connection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlconnection?view=sqlclient-dotnet-standard-5.2) հատկության [CreateCommand](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlconnection.createcommand?view=sqlclient-dotnet-standard-5.2#microsoft-data-sqlclient-sqlconnection-createcommand) մեթոդի միջոցով, որը ընթացիկ sql միացման համար ստեղծում է [SqlCommand](https://learn.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlcommand?view=netframework-4.8.1)` sql հարցումը ձևավորվելու համար։

Ստեղծված [SqlCommand](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlcommand?view=sqlclient-dotnet-standard-5.2) դասի օբյեկտի [CommandText](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlcommand.commandtext?view=sqlclient-dotnet-standard-5.2) հատկությանը հարկավոր է փոխանցել հարցման տեքստը։ Օրինակում փոխանցված է [stored procedure](https://learn.microsoft.com/en-us/sql/relational-databases/stored-procedures/stored-procedures-database-engine?view=sql-server-ver16)-ի անվանումը և պարամետրին էլ փոխանցված է անհրաժեշտ արժեքը։ Կատարվել է հարցումը Ստեղծված [SqlCommand](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlcommand?view=sqlclient-dotnet-standard-5.2) դասի օբյեկտի [ExecuteNonQueryAsync](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlcommand.executenonqueryasync?view=sqlclient-dotnet-standard-5.2) մեթոդի միջոցով՝ փոխանցելով չեղարկման տոկենը( CancellationToken stoppingToken ):
Մեթոդի վերջում վերադարձվել է NoResult դասը, քանի որ կատարման արդյունքում տվյալներ չեն ստացվում:
