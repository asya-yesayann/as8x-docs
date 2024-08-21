---
layout: page
title: "Sql-based տվյալների աղբյուրի տողերի հավելյալ մշակում"
tags: [DataSource, DS]
---

## Բովանդակություն
* [Ներածություն](#ներածություն)
* [ProcessRow](#processrow)
* [AfterDataReaderClose](#afterdatareaderclose)

## Ներածություն

Sql-based տվյալների աղբյուրի տողերի հավելյալ մշակման, ֆիլտրման և հաշվարկային սյուների արժեքների հաշվարկման համար կարող են օգտագործվել երկու մեթոդներ՝ [ProcessRow](ds#processrow) և [AfterDataReaderClose](ds#afterdatareaderclose): 

Երկու մեթոդները փոխարինում են 4X համակարգում նկարագրված [OnEachRow](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/OnEachRow.html) և [Valid](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/Valid_Data.html) իրադարձություններին:

## ProcessRow 

Մեթոդը կանչվում է [MakeSqlCommand](ds#makesqlcommand) մեթոդում փևավորված SQL հարցման կատարման ընթացքում, երբ հարցման տվյալները կարդացող [SqlDataReader](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqldatareader)-ը դեռ բաց է:

Մեթոդը է վերադարձնում են bool տիպի արժեք, որը ցույց է տալիս թե ընթացիկ տողը պետք է ընդգրկվի տվյալների աղբյուրի տողերի վերջնական ցուցակում, թե ոչ։

Մեթոդում նախատեսված չէ կատարել sql հարցումներ կամ կանչել ասինխրոն ֆունկցիաներ։ 
Այլ հարկավոր է կա՛մ աշխատել ընթացիկ տողի հետ, կա՛մ reader-ի ընթացիկ տողի հետ։

### Օրինակ 1

Այս օրինակում fSTATENAME string տիպի *հաշվարկային* սյան արժեքը որոշվում fSTATE short տիպի ոչ հաշվարկային սյան արժեքներից ելնելով:

```c#
protected override bool ProcessRow(DataSourceArgs<Param> args, DataRow row, SqlDataReader reader)
{
  switch (row.fSTATE)
  {
    case 998:
        row.fSTATENAME = "Մերժված";
        break;
    case 999:
        row.fSTATENAME = "Հեռացված";
        break;
    default:
        row.fSTATENAME = "Անհայտ";
        break;
  }
  return true;
}
```

### Օրինակ 2

Ներկայացված է տվյալների աղբյուրի տողերի ֆիլտրացիայի օրինակ՝ վերջնական տողերի ցուցակում ընդգրկվում են այն տողերը, որտեղ ստուգվում է տարիքը։

reader-ից տողերը կարդալը առավել արագացնելու համար կարելի է [AfterExecuteSQLCommand](ds#afterexecutesqlcommand) մեթոդում ստանալ reader-ի մեջ հարկավոր դիրքերը։

```c#
private int ageOrdinal;

protected override void AfterExecuteSQLCommand(DataSourceArgs<Param> args, SqlDataReader reader)
{
    this.ageOrdinal = reader.GetOrdinal("fAGE");
}

protected override bool ProcessRow(DataSourceArgs<Param> args, DataRow row, SqlDataReader reader)
{
    if (args.Parameters.CheckAge && reader.GetInt32(this.ageOrdinal) < 18)
    {
        return false;
    }
    else
    {
        return true;
    }
}
```

## AfterDataReaderClose

AfterDataReaderClose-ը կանչվում է SQL հարցման կատարման ավարտից հետո, երբ [SqlDataReader](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqldatareader)-ը արդեն փակ է: 
Մեթոդում թույլատրվում է կատարել այլ sql հարցումներ և կանչել ասինխրոն ֆունկցիաներ։

AfterDataReaderClose-ի աշխատանքի երկու տարբերակ կա կախված գերբեռնվող [AfterDataReaderCloseMode](ds.md#afterdatareaderclosemode) հատկության արժեքից՝
- Ամեն տողի համար առանձին կանչ,
- Մեկ կանչ բոլոր տողերի մշակման համար։

### Օրինակ 1

Այս օրինակում յուրաքանչյուր տողի համար բեռնվում է տողի fISN դաշտի արժեքով փաստաթուղթը և  DOCARMCAPTION, DOCENGCAPTION string տիպի հաշվարկային սյուներին վերագրում բեռնված փաստաթղթի հայերեն և անգլերեն անվանումները։

```c#
public override CallMode AfterDataReaderCloseMode => CallMode.EachRowCall;
							
protected override async Task<bool> AfterDataReaderClose(DataSourceArgs<Param> args, DataRow row)
{
	Document doc = await this.documentService.Load(row.fISN);
	row.DOCARMCAPTION = doc.Description.ArmenianCaption;
	row.DOCENGCAPTION = doc.Description.EnglishCaption; 
	return true;
}
```

### Օրինակ 2

Այս օրինակում տողերի մի մասը ստացվում է այլ աղբյուրից, և դրանք ավելացվում են վերջնական տողերի ցուցակին։

```c#
public override CallMode AfterDataReaderCloseMode => CallMode.SingleCall;

protected override async Task AfterDataReaderClose(DataSourceArgs<Param> args, CancellationToken stoppingToken)
{
    var otherRows = await GetRowsFromOtherSource(args, stoppingToken);
    this.Rows.AddRange(otherRows);
}

private async Task<List<DataRow>> GetRowsFromOtherSource(DataSourceArgs<Param> args, CancellationToken stoppingToken)
{
    //...
}
```
