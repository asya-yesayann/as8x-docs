---
layout: page
title: "Տվյալների աղբյուրի նկարագրություն" 
tags: [DS, DataSource]
sublinks:
- { title: "Օրինակներ", ref: օրինակներ }
- { title: "DATA նկարագրություն", ref: data-նկարագրություն }
- { title: "Հատկություններ", ref: հատկություններ }
- { title: "NAME", ref: name }
- { title: "CAPTION", ref: caption }
- { title: "ECAPTION", ref: ecaption }
- { title: "PROCESSINGMODE", ref: processingmode }
- { title: "DataSource դաս", ref: datasource-դաս }
- { title: "Ոչ վիրտուալ հատկություններ", ref: ոչ-վիրտուալ-հատկություններ }
- { title: "ArmenianCaption", ref: armeniancaption }
- { title: "EnglishCaption", ref: englishcaption }
- { title: "Name", ref: name-1 }
- { title: "Progress", ref: progress }
- { title: "QueryTimeOut", ref: querytimeout }
- { title: "Rows", ref: rows }
- { title: "Schema", ref: schema }
- { title: "Վիտուալ հատկություններ", ref: վիտուալ-հատկություններ }
- { title: "AfterDataReaderCloseMode", ref: afterdatareaderclosemode }
- { title: "CommandBehaviorFlag", ref: commandbehaviorflag }
- { title: "IsSQLBased", ref: issqlbased }
- { title: "IsUpdatable", ref: isupdatable }
- { title: "SupportPrepareExecutionPhase", ref: supportprepareexecutionphase }
- { title: "SupportsSnapshotIsolation", ref: supportssnapshotisolation }
- { title: "Ոչ վիրտուալ մեթոդներ", ref: ոչ-վիրտուալ-մեթոդներ }
- { title: "Execute", ref: execute }
- { title: "Վիրտուալ մեթոդներ", ref: վիրտուալ-մեթոդներ }
- { title: "AfterExecuteSQLCommand", ref: afterexecutesqlcommand }
- { title: "AfterDataReaderClose", ref: afterdatareaderclose }
- { title: "AfterDataReaderClose", ref: afterdatareaderclose-1 }
- { title: "BeforeExecuteSQLCommand", ref: beforeexecutesqlcommand }
- { title: "FillData", ref: filldata }
- { title: "MakeSQLCommand", ref: makesqlcommand }
- { title: "ProcessRow", ref: processrow }
---

## Բովանդակություն

- [Ներածություն](#ներածություն)
- [Օրինակներ](#օրինակներ)
- [DATA նկարագրություն](#data-նկարագրություն)
- [Հատկություններ](#հատկություններ)
  - [NAME](#name)
  - [CAPTION](#caption)
  - [ECAPTION](#ecaption)
  - [PROCESSINGMODE](#processingmode)
- [DataSource դաս](#datasource-դաս)
- [Ոչ վիրտուալ հատկություններ](#ոչ-վիրտուալ-հատկություններ)
  - [ArmenianCaption](#armeniancaption)
  - [EnglishCaption](#englishcaption)
  - [Name](#name-1)
  <!-- - [IsParametersSupported](#isparameterssupported) -->
  - [Progress](#progress)
  - [QueryTimeOut](#querytimeout)
  - [Rows](#rows)
  - [Schema](#schema)
- [Վիտուալ հատկություններ](#վիտուալ-հատկություններ)
  - [AfterDataReaderCloseMode](#afterdatareaderclosemode)
  - [CommandBehaviorFlag](#commandbehaviorflag)
  - [IsSQLBased](#issqlbased)
  - [IsUpdatable](#isupdatable)
  - [SupportPrepareExecutionPhase](#supportprepareexecutionphase)
  - [SupportsSnapshotIsolation](#supportssnapshotisolation)
- [Ոչ վիրտուալ մեթոդներ](#ոչ-վիրտուալ-մեթոդներ)
  <!-- - [AddRow](#addrow) -->
  - [Execute](#execute)
  <!-- - [Execute](#execute-1) -->
  <!-- - [GetExecutionPhases](#getexecutionphases) -->
- [Վիրտուալ մեթոդներ](#վիրտուալ-մեթոդներ)
  - [AfterExecuteSQLCommand](#afterexecutesqlcommand)
  - [AfterDataReaderClose](#afterdatareaderclose)
  - [AfterDataReaderClose](#afterdatareaderclose-1)
  - [BeforeExecuteSQLCommand](#beforeexecutesqlcommand)
  - [FillData](#filldata)
  - [MakeSQLCommand](#makesqlcommand)
  - [ProcessRow](#processrow)

## Ներածություն

Տվյալների պահոցից աղյուսակային տեսքով տվյալներ կարդալու և ցույց տալու համար նկարագրվում է տվյալների աղբյուր։

8X համակարգում տվյալների աղբյուր նկարագրելու համար հարկավոր է ունենալ
* .as ընդլայնմամբ ֆայլ սկրիպտերում [DATA](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Defs/Data.html) նկարագրությամբ։ 
  Այն անհրաժեշտ է ներմուծել տվյալների բազա `Syscon` գործիքի միջոցով։
* .cs ընդլայնմամբ ֆայլ, որը պարունակում է սերվերում աշխատող տրամաբանությունը։

## Օրինակներ

* [Տվյալների աղբյուրի նկարագրման ձեռնարկ](ds_guide.md)
* [DataSourceService դաս](../services/DataSourceService.md)
* [Տվյալների աղբյուրի ընդլայնման բազային դաս](../../extensions/definitions/ds_extender.md)
* [Տվյալների աղբյուրի ընդլայնման նկարագրման ձեռնարկ](../../extensions/definitions/ds_extender_guide.md)

## DATA նկարագրություն

```as4x
DATA {
  NAME = ...;
  CAPTION = ...;
  ECAPTION = ...;
  PROCESSINGMODE = ...;
};
```

## Հատկություններ

### NAME
Տվյալների աղբյուրի ներքին անունը։
Առավելագույնը 8 Նիշ։

### CAPTION 
Տվյալների աղբյուրի հայերեն անվանումը ANSI կոդավորմամբ։

### ECAPTION 
Տվյալների աղբյուրի անգլերեն անվանումը։

### PROCESSINGMODE 
Տվյալների աղբյուրի կատարման ռեժիմը։
Հարկավոր է տալ 1 արժեք տվյալների աղբյուրը 8X սերվիս ռեժիմով աշխատացնելու համար։

## DataSource դաս

Տվյալների աղբյուրի համար անհրաժեշտ է սահմանել դաս, որը ունի տվյալների աղբյուրի ներքին անունը պարունակող `DataSource` ատրիբուտը և ժառանգում է `DataSource<R, P>` դասը՝ որպես `R` փոխանցելով տվյալների աղբյուրի տող նկարագրող դասը, իսկ որպես `P`՝ պարամետրերը նկարագրող դասը։ 
Եթե տվյալների աղբյուրը չի պարունակում պարամետրեր, ապա որպես `P` անհրաժեշտ է փոխանցել `NoParam` դասը։

**Օրինակ**

```c#
[DataSource("DocSets")]
public class DocumentSettings : DataSource<DocumentSettings.DataRow, DocumentSettings.Param>
```
  
## Ոչ վիրտուալ հատկություններ

### ArmenianCaption

```c#
public string ArmenianCaption { get; }
```

Վերադարձնում է տվյալների աղբյուրի հայերեն անվանումը:

### EnglishCaption

```c#
public string EnglishCaption { get; }
```

Վերադարձնում է տվյալների աղբյուրի անգլերեն անվանումը:

### Name

```c#
public string Name { get; }
```

Վերադարձնում է տվյալների աղբյուրի ներքին անունը:

<!-- ### IsParametersSupported

```c#
public bool IsParametersSupported { get; }
```

Ցույց է տալիս, արդյոք տվյալների աղբյուրը պարամետրեր ունի, թե ոչ: -->

### Progress

```c#
public DataSourceExecutionProgress Progress { get; }
```

Վերադարձնում է տվյալների աղբյուրի կատարման պրոգրեսը:

Այս օբյեկտի միջոցով հնարավոր է կառավարել UI-ում ցույց տրվող փուլերը:

### QueryTimeOut

```c#
public int QueryTimeOut { get; set; }
```

Վերադարձնում կամ արժեքավորում է տվյալների աղբյուրի [MakeSqlCommand](#makesqlcommand)-ում ձևավորված հարցման կատարման առավելագույն ժամանակը (վայրկյաններով):
Համապատասխանում է [DATA](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Defs/Data.html) նկարագրություն `QueryTimeout` հատկությանը։

### Rows

```c#
protected List<R> Rows { get; set; }
```

Հաշվարկվող տվյալների աղբյուրի տողերի ցուցակը։

Տե՛ս տողերի ավելացման [օրինակը](ds_guide_row_processing.md#օրինակ-2-1)։

### Schema

```c#
public Schema Schema { get; protected set; }
```

Տվյալների աղբյուրի [սխեման](../types/schema.md), որը պարունակում է ինֆորմացիա տվյալների աղբյուրի սյուների ու պարամետրերի հատկությունների մասին։

Այն ձևավորվում է կոնստրուկտորում։
Տ՛ես [օրինակը](ds_guide.md#կոնստրուկտորի-ձևավորում)։

## Վիտուալ հատկություններ

### AfterDataReaderCloseMode

```c#
public virtual CallMode AfterDataReaderCloseMode
{
    get { return CallMode.None; }
}
```

[AfterDataReaderClose](#afterdatareaderclose)-ի աշխատանքի երկու տարբերակ կա կախված այս հատկության արժեքից՝
- Ամեն տողի համար առանձին կանչ,
- Մեկ կանչ բոլոր տողերի մշակման համար։

Տե՛ս [օրինակը](ds_guide_row_processing.md#օրինակ-2-1)։

### CommandBehaviorFlag

```c#
protected virtual CommandBehavior CommandBehaviorFlag
{
   get { return CommandBehavior.Default; }
}
```

Այս հատկության միջոցով ձևավորվում է [MakeSqlCommand](#makesqlcommand)-ում ձևավորված հարցման [ExecuteReaderAsync](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlcommand.executereaderasync#microsoft-data-sqlclient-sqlcommand-executereaderasync(system-data-commandbehavior-system-threading-cancellationtoken))-ի մեթոդով կատարման ժամանակ `behavior` պարամետրի արժեքը։

### IsSQLBased

```c#
public virtual bool IsSQLBased
{
    get { return true; }
}
```

Տվյալների աղբյուրը ըստ տվյալների բեռնման աղբյուրի լինում է 2 տեսակի՝
- sql-based (տվյալները ստացվում են տվյալների բազայից՝ sql հարցման միջոցով),
- array-based (տվյալները ստացվում են այլ աղբյուրներից և ավելացվում տվյալների աղբյուրի [տողերի](#rows) զանգվածին):
  
Տեսակը որոշվում է այս հատկության միջոցով, որի լռությամբ արժեքը **true** է։

### IsUpdatable

```c#
public virtual bool IsUpdatable
{
    get { return false; }
}
```

Sql-based տվյալների աղբյուրում նոր տող ավելացնելու, ջնջելու կամ թարմացնելու հնարավորությունը ապահովելու համար անհրաժեշտ է գերբեռնել այս հատկությունը՝ վերադարձնելով **true** արժեք և [MakeSQLCommand](#makesqlcommand) մեթոդի `args` պարամետրի `IsUpdate` հատկության **true** արժեքի դեպքում ձևավորվող sql հարցման տեքստում ավելացնել ֆիլտրում ըստ տվյալների աղբյուրի տողի նույննականացուցիչի՝ `args.ISN`։ 
Սովորաբար տողի նույննականացուցիչ հանդիսանում է փաստաթղթի ISN, բայց կարող է նաև լինել այլ արժեք։

### SupportPrepareExecutionPhase

```c#
public virtual bool SupportPrepareExecutionPhase
{
   get { return false; }
}
```

Ցույց է տալիս տվյալների աղբյուրի պրոգրեսով կատարումը սատարում է «Նախապատրաստում» փուլը, թե ոչ:

### SupportsSnapshotIsolation

```c#
public virtual bool SupportsSnapshotIsolation
{
   get { return false; }
}
```

Վերադարձնում է տվյալների աղբյուրի հարցման կատարման իզոլյացիայի մակարդակը [snapshot](https://learn.microsoft.com/en-us/dotnet/framework/data/adonet/sql/snapshot-isolation-in-sql-server) է, թե [ReadCommitted](https://learn.microsoft.com/en-us/dotnet/api/system.data.isolationlevel#fields):


## Ոչ վիրտուալ մեթոդներ

<!-- ### AddRow

```c#
protected void AddRow(R row)
```

Ավելացնում է տող տվյալների աղբյուրի տողերի ցուցակում` որպես մուտքային R պարամետր ստանալով տվյալների աղբյուրի սյուները նկարագրող դասը։ -->

<!-- ### Execute

```c#
public Task<DataSourceResult<R>> Execute(DataSourceArgs<P> args, CancellationToken stoppingToken, IExtender extender = null)
```

Կատարում է տվյալների աղբյուրը` որպես մուտքային պարամետրեր ստանալով տվյալների աղբյուրի՝
* args - DataSourceArgs<P> դասի օբյեկտ՝ որպես P փոխանցելով պարամետրերը նկարագրող դասը, որը պարունակում է տվյալների աղղբյուրի պարամետրերը, վերադարձվող սյուների անվանումների ցուցակը և մետատվյալներ,
* stoppingToken - չեղարկման տոկենը,
* extender - տվյալների աղբյուրի ընդլայնումը,

Տե՛ս [օրինակը](../examples/ds.md#2-տիպիզացված-կատարում)։ -->

### Execute

```c#
public Task<DataSourceResult<R>> Execute(P param, HashSet<string> columns = null, IExtender extender = null, CancellationToken stoppingToken = default)
```

Կատարում է տվյալների աղբյուրը` որպես մուտքային պարամետրեր ստանալով տվյալների աղբյուրի՝
* `param` - պարամետրերը նկարագրող դասի օբյեկտ,
* `columns` - վերադարձվող սյուների անվանումների ցուցակը,
* `extender` - տվյալների աղբյուրի ընդլայնումը,
* `stoppingToken` - ընդհատման օբյեկտը։

Տե՛ս [օրինակը](../examples/ds.md#2-տիպիզացված-կատարում)։

<!-- ### GetExecutionPhases

```c#
public virtual IEnumerable<DataSourceExecutionPhase> GetExecutionPhases()
```

Վերադարձնում է տվյալների աղբյուրի կատարման փուլերը։ -->

## Վիրտուալ մեթոդներ

### AfterDataReaderClose

```c#
protected virtual Task AfterDataReaderClose(DataSourceArgs<P> args, CancellationToken stoppingToken)
```

Մեթոդը կանչվում է միջուկի կողմից SQL հարցման կատարման ավարտից հետո, երբ [SqlDataReader](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqldatareader)-ը արդեն փակ է: 

Տե՛ս [AfterDataReaderCloseMode](ds.md#afterdatareaderclosemode)։

Տե՛ս [օրինակը](ds_guide_row_processing.md#օրինակ-1-1)։

### AfterDataReaderClose

```c#
protected virtual Task<bool> AfterDataReaderClose(DataSourceArgs<P> args, R row)
```

Մեթոդը կանչվում է միջուկի կողմից SQL հարցման կատարման ավարտից հետո ամեն մի հաշվարկված տողի համար, երբ [SqlDataReader](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqldatareader)-ը արդեն փակ է: 

Մեթոդը է վերադարձնում են bool տիպի արժեք, որը ցույց է տալիս թե ընթացիկ տողը պետք է ընդգրկվի տվյալների աղբյուրի տողերի վերջնական ցուցակում, թե ոչ։

Տե՛ս [AfterDataReaderCloseMode](ds.md#afterdatareaderclosemode)։

Տե՛ս [օրինակը](ds_guide_row_processing.md#օրինակ-2-1)։

### AfterExecuteSQLCommand

```c#
protected virtual void AfterExecuteSQLCommand(DataSourceArgs<P> args, SqlDataReader reader)
```

Մեթոդը կանչվում է միջուկի կողմից SQL հարցման սկսելուց հետո, երբ [SqlDataReader](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqldatareader)-ը արդեն բաց է: 
Նախատեսված է `reader`-ից սյունակների դիրքերի ստացման համար [SqlDataReader](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqldatareader).[GetOrdinal](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqldatareader.getordinal) մեթոդով։

Տե՛ս [օրինակը](ds_guide_row_processing.md#օրինակ-2)։

### BeforeExecuteSQLCommand

```c#
protected virtual Task BeforeExecuteSQLCommand(DataSourceArgs<P> args, CancellationToken stoppingToken)
```

Մեթոդը կանչվում է միջուկի կողմից [MakeSqlCommand](#makesqlcommand) մեթոդի ավարտից հետո, Նախատեսված է տվյալների աղբյուրի կատարումից առաջ նախապատրաստական աշխատանքներ կատարելու համար:

### FillData

```c#
protected virtual Task FillData(DataSourceArgs<P> args, CancellationToken stoppingToken)
```

Մեթոդը կանչվում է միջուկի կողմից array-based տվյալների աղբյուրի դեպքում։
նախատեսված է վերջնական [տողերի](#rows) ցուցակի ձևավորման համար։

Տե՛ս [ձեռնարկում](ds_guide.md) [array-based տվյալների աղբյուրի նկարագրություն](ds_guide.md#array-based-տվյալների-աղբյուրի-նկարագրման-ձեռնարկ)։


### MakeSQLCommand

```c#
protected virtual Task<SqlCommand> MakeSQLCommand(DataSourceArgs<P> args, CancellationToken stoppingToken)
```

Մեթոդը կանչվում է միջուկի կողմից, այն հարկավոր է մշակել և վերադարձնել sql-based տվյալների աղբյուրի sql հարցման կատարող [SqlCommand](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlcommand)-ը։

Տե՛ս [ձեռնարկում](ds_guide.md) [Sql հարցման ձևավորում](ds_guide.md#sql-հարցման-ձևավորում)։

### ProcessRow

```c#
protected virtual bool ProcessRow(DataSourceArgs<P> args, R row, SqlDataReader reader)
```

Մեթոդը կանչվում է միջուկի կողմից [MakeSqlCommand](ds.md#makesqlcommand) մեթոդում ձևավորված SQL հարցման կատարման ընթացքում, երբ հարցման տվյալները կարդացող [SqlDataReader](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqldatareader)-ը դեռ բաց է:

Մեթոդը է վերադարձնում են bool տիպի արժեք, որը ցույց է տալիս թե ընթացիկ տողը պետք է ընդգրկվի տվյալների աղբյուրի տողերի վերջնական ցուցակում, թե ոչ։

Տե՛ս [օրինակը](ds_guide_row_processing.md#processrow)։
