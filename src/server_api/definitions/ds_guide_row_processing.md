---
layout: page
title: "Sql-based տվյալների աղբյուրի տողերի հավելյալ մշակում"
tags: [DataSource, DS]
---

## Բովանդակություն
* [Նախաբան](#նախաբան)
* [ProcessRow](#processRow)
  * [Օգտագործման օրինակներ](#processRow-ի-օգտագործման-օրինակներ)
 * [AfterDataReaderCloseMode](#afterDataReaderCloseMode)
   *  [Օգտագործման օրինակներ](#afterDataReaderCloseMode-ի-օգտագործման-օրինակներ)

## Նախաբան

`Sql-based` տվյալների աղբյուրի տողերի հավելյալ մշակման, ֆիլտրման և հաշվարկային սյուների արժեքների հաշվման համար կարող են օգտագործվել երկու մեթոդներ՝ **ProcessRow** և **AfterDataReaderClose**: 
Երկու մեթոդներն էլ կանչվում են **յուրաքանչյուր** տողի համար և հանդիսանում են 4x համակարգում նկարագրված [OnEachRow](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/OnEachRow.html) + [Valid](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/Valid_Data.html) իրադարձությունների միավորումը:
Երկու մեթոդներն էլ վերադարձնում են bool տիպի արժեք, որը ցույց է տալիս թե ընթացիկ տողը ընդգրկվի տվյալների աղբյուրի տողերի վերջնական ցուցակում թե ոչ։

## ProcessRow 

*  Կանչվում է SQL հարցման կատարման ընթացքում, երբ հարցման սյուները կարդացող [SqlDataReader]((https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqldatareader?view=sqlclient-dotnet-standard-5.2))-ը դեռ բաց է:
*  Որպես մուտքային պարամետրեր ստանում է ընթացիկ տողը, SqlDataReader տիպի օբյեկտ և DataSourceArgs տիպի օբյեկտ, որը պարունակում է տվյալների աղբյուրի պարամետրերը, սյուների անվանումների ցուցակը և մետատվյալներ:
* Մեթոդում հնարավոր չէ կատարել այլ sql հարցումներ կամ դիմել sql միացում պահանջող սերվիսային մեթոդների։

## ProcessRow-ի օգտագործման օրինակներ

### Օրինակ 1

Այս օրինակում fSTATENAME string տիպի **հաշվարկային** սյան արժեքը որոշվում fSTATE short տիպի ոչ հաշվարկային սյան արժեքներից ելնելով:

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

Ներկայացված է տվյալների աղբյուրի տողերի **ֆիլտրացիայի** օրինակ՝ վերջնական տողերի ցուցակում ընդգրկվում են այն տողերը, որոնց short տիպի Age դաշտի արժեքը մեծ է short տիպի AgeStart պարամետրի արժեքից։

```c#
protected override bool ProcessRow(DataSourceArgs<Param> args, DataRow row, SqlDataReader reader)
{
    if (row.Age < args.Parameters.AgeStart)
    {
        return false;
    }
    else
    {
        return true;
    }
}
```

### Օրինակ 3

Ներկայացված է տվյալների աղբյուրի տողերի **ֆիլտրացիայի** և հաշվարկային սյուների հաշվման օրինակ՝ վերջնական տողերի ցուցակում ընդգրկվում են այն տողերը, որոնց int տիպի WorkersCount հաշվարկային սյան արժեքը հավասար չէ 0-ի։

```c#
protected override bool ProcessRow(DataSourceArgs<Param> args, DataRow row, SqlDataReader reader)
{
	row.WorkersCount = row.FirstCompanyWorkersCount + row.SecondCompanyWorkersCount;
	return WorkersCount != 0;
}
```

## AfterDataReaderCloseMode

*  Կանչվում է SQL հարցման կատարման ավարտից հետո, երբ հարցման սյուները կարդացող [SqlDataReader]((https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqldatareader?view=sqlclient-dotnet-standard-5.2))-ը արդեն փակ է:
*  Որպես մուտքային պարամետրեր ստանում է ընթացիկ տողը և DataSourceArgs տիպի օբյեկտ, որը պարունակում է տվյալների աղբյուրի պարամետրերը, սյուների անվանումների ցուցակը և մետատվյալներ։
* Մեթոդում թույլատրվում է կատարել այլ sql հարցումներ և դիմել sql միացում պահանջող սերվիսային մեթոդների։
* Մեթոդի ակտիվացման համար անհրաժեշտ է նախապես override անել [AfterDataReaderCloseMode](ds.md#afterDataReaderCloseMode) հատկությունը՝ վերադարձնելով CallMode.EachRowCall արժեքը։

## AfterDataReaderCloseMode-ի օգտագործման օրինակներ

### Օրինակ 1

Այս օրինակում յուրաքանչյուր տողի համար բեռնվում է տողի fISN դաշտի արժեքով փաստաթուղթը  և  DOCARMCAPTION, DOCENGCAPTION string տիպի հաշվարկային սյուներին վերագրում բեռնված փաստաթղթի հայերեն և անգլերեն անվանումները։

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

Այս օրինակում յուրաքանչյուր տողի համար բեռնվում է ծառի նկարագրությունը՝ օգտագործելով տողի fNAME դաշտի արժեքը: 
Եթե դիտումը(AllowView) կամ խմբագրումը(AllowEdit) թույլատրված է, ապա fCAPTION, fECAPTION string տիպի հաշվարկային սյուներին վերագրվում է բեռնված ծառի հայերեն և անգլերեն անվանումները և վերադարձնում true, որի շնորհիվ տողը ներառվում է տվյալների աղբյուրի տողերի վերջնական ցուցակում։ 
Հակառակ դեպքում տողը չի ավելացվում ցուցակում:

```c#
public override CallMode AfterDataReaderCloseMode => CallMode.EachRowCall;

protected override Task<bool> AfterDataReaderClose(DataSourceArgs<NoParam> args, DataRow row)
{
    TreeDefinition tree = this.treeService.GetFreshDecsriptor(row.fNAME);
    
    if (tree.AllowEdit || tree.AllowView)
    {
        row.fCAPTION = tree.ArmenianCaption; 
        row.fECAPTION = tree.EnglishCaption;
        return Task.FromResult(true);
    }    
    return Task.FromResult(false);
}
```
