---
layout: page
title: "Տվյալների աղբյուրի նկարագրություն" 
tags: [DS, DataSource]
---

## Բովանդակություն

- [Ներածություն](#ներածություն)
- [Օրինակներ](#օրինակներ)
- [Ոչ վիրտուալ հատկություններ](#ոչ-վիրտուալ-հատկություններ)
  - [ArmenianCaption](#armeniancaption)
  - [EnglishCaption](#englishcaption)
  - [Name](#name)
  - [IsParametersSupported](#isparameterssupported)
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
  - [AddRow](#addrow)
  - [Execute](#execute)
  - [Execute](#execute-1)
  - [GetExecutionPhases](#getexecutionphases)
- [Վիրտուալ մեթոդներ](#վիրտուալ-մեթոդներ)
  - [AfterDataReaderClose](#afterdatareaderclose)
  - [AfterDataReaderClose](#afterdatareaderclose-1)
  - [BeforeExecuteSQLCommand](#beforeexecutesqlcommand)
  - [MakeSQLCommand](#makesqlcommand)
  - [ProcessRow](#processrow)

## Ներածություն

Տվյալների պահոցից աղյուսակային տեսքով տվյալներ կարդալու և ցույց տալու համար նկարագրվում է տվյալների աղբյուր։

```c#
    public abstract class DataSource<R, P> : IDataSource
         where P : class, new()
         where R : class, new()
```

DataSource աբստրակտ դասը հիմք է հանդիսանում է տվյալների աղբյուրների սահմանման համար։ 
Բոլոր տվյալների աղբյուրները ունեն `DataSource` ատրիբուտը և ժառանգ են հանդիսանում այս դասից, որը տրամադրում է վիրտուալ մեթոդներ սեփական սերվերային տրամաբանության սահմանման համար և հատկություններ տվյալների աղբյուրի մետատվյալների ստացման համար։

**Օրինակ**
```c#
[DataSource("TreeNode")]
public class TreeNode : DataSource<TreeNode.DataRow, TreeNode.Param>
```

## Օրինակներ

* [Տվյալների աղբյուրի նկարագրման ձեռնարկ](/src/server_api/definitions/ds_guide.md)
* [DataSourceService դաս](/src/server_api/services/DataSourceService.md)
* [Տվյալների աղբյուրի ընդլայնման բազային դաս](/src/extensions/definitions/ds_extender.md)
* [Տվյալների աղբյուրի ընդլայնման նկարագրման ձեռնարկ](/src/extensions/definitions/ds_extender_guide.md)
  
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

### IsParametersSupported

```c#
public bool IsParametersSupported { get; }
```

Ցույց է տալիս, արդյոք տվյալների աղբյուրը պարամետրեր ունի, թե ոչ:

### Progress

```c#
public DataSourceExecutionProgress Progress { get; }
```

Վերադարձնում է տվյալների աղբյուրի կատարման պրոգրեսը:

### QueryTimeOut

```c#
public int QueryTimeOut { get; set; }
```

Վերադարձնում կամ արժեքավորում է տվյալների աղբյուրի հարցման կատարման առավելագույն ժամանակը (վայրկյաններով):

### Rows

```c#
protected List<R> Rows { get; set; }
```

Վերադարձնում կամ արժեքավորում է տվյալների աղբյուրի տողերը՝ որպես R վերադարձնելով տվյալների աղբյուրի սյուները նկարագրող դասը։

### Schema

```c#
public Schema Schema { get; protected set; }
```

Վերադարձնում է տվյալների աղբյուրի [սխեման](schema.md), որը պարունակում է ինֆորմացիա տվյալների աղբյուրի սյուների ու պարամետրերի հատկությունների մասին։

## Վիտուալ հատկություններ

### AfterDataReaderCloseMode

```c#
public virtual CallMode AfterDataReaderCloseMode
{
    get { return CallMode.None; }
}
```

Sql-based տվյալների աղբյուրի հարցման կատարումից հետո տողերի հավելյալ մշակման, ֆիլտրացիայի համար անհրաժեշտ է override անել այս հատկությունը՝ որպես արժեք նշելով հավելյալ մշակում պետք է անել՝ CallMode.EachRowCall - ստացված տողերից յուրաքանչյուրի համար, SingleCall մի ամբողջական մշակում անել բոլոր տողերի համար։ Մշակումը իրականացնելու համար էլ անհրաժեշտ է override անել [AfterDataReaderClose](#afterDataReaderClose) մեթոդը։

### CommandBehaviorFlag

```c#
protected virtual CommandBehavior CommandBehaviorFlag
{
   get { return CommandBehavior.Default; }
}
```

Վերադարձնում է sql-based տվյալների աղբյուրի հարցման կատարման հատկությունները և արդյունքների վերադարձման եղանակը։ Ավելի մանրամասն տեղեկատվության համար [տե՛ս](https://learn.microsoft.com/en-us/dotnet/api/system.data.commandbehavior?view=net-8.0):


### IsSQLBased

```c#
public virtual bool IsSQLBased
{
    get { return true; }
}
```

Ցույց է տալիս թե տվյալների աղբյուրի տվյալները ստացվում են sql հարցման միջոցով թե ոչ։

### IsUpdatable

```c#
public virtual bool IsUpdatable
{
    get { return false; }
}
```

Sql-based տվյալների աղբյուրում նոր տող ավելացնելու, ջնջելու կամ թարմացնելու հնարավորությունը ապահովելու համար անհրաժեշտ է override անել այս հատկությունը՝ վերադարձնելով true արժեք և [MakeSQLCommand](#makeSQLCommand) մեթոդի DataSourceArgs<P> տիպի args պարամետրի IsUpdate bool տիպի հատկության true արժեքի դեպքում ավելացնել ֆիլտրում ըստ տվյալների աղբյուրի տողի նույննականացուցիչի։ Սովորաբար տողի նույննականացուցիչ հանդիսանում է փաստաթղթի ISN է, բայց կարող է նաև լինել այլ տիպի արժեք։

### SupportPrepareExecutionPhase

```c#
public virtual bool SupportPrepareExecutionPhase
{
   get { return false; }
}
```

Ցույց է տալիս տվյալների աղբյուրի պրոգրեսով կատարումը սատարում է "Նախապատրաստում" փուլը թե ոչ:

### SupportsSnapshotIsolation

```c#
public virtual bool SupportsSnapshotIsolation
{
   get { return false; }
}
```

Վերադարձնում է  տվյալների աղբյուրի հարցման կատարման իզոլյացիայի մակարդակը [snapshot](https://learn.microsoft.com/en-us/dotnet/framework/data/adonet/sql/snapshot-isolation-in-sql-server) է թե ոչ:


## Ոչ վիրտուալ մեթոդներ

### AddRow

```c#
protected void AddRow(R row)
```

Ավելացնում է տող տվյալների աղբյուրի տողերի ցուցակում` որպես մուտքային R պարամետր ստանալով տվյալների աղբյուրի սյուները նկարագրող դասը։

### Execute

```c#
public Task<DataSourceResult<R>> Execute(DataSourceArgs<P> args, CancellationToken stoppingToken, IExtender extender = null)
```

Կատարում է տվյալների աղբյուրը` որպես մուտքային պարամետրեր ստանալով տվյալների աղբյուրի՝
* args - DataSourceArgs<P> դասի օբյեկտ՝ որպես P փոխանցելով պարամետրերը նկարագրող դասը, որը պարունակում է տվյալների աղղբյուրի պարամետրերը, վերադարձվող սյուների անվանումների ցուցակը և մետատվյալներ,
* stoppingToken - չեղարկման տոկենը,
* extender - տվյալների աղբյուրի ընդլայնումը,

### Execute

```c#
public Task<DataSourceResult<R>> Execute(P param, HashSet<string> columns = null, IExtender extender = null, CancellationToken stoppingToken = default)
```

Կատարում է տվյալների աղբյուրը` որպես մուտքային պարամետրեր ստանալով տվյալների աղբյուրի՝
* param - պարամետրերը նկարագրող դասը,
* columns - վերադարձվող սյուների անվանումների ցուցակը,
* extender - տվյալների աղբյուրի ընդլայնումը,
* stoppingToken - չեղարկման տոկենը։

Օգտագործման օրինակին ծանոթանալու համար [տե՛ս](../examples/ds.md#2-Տիպիզացված-կատարում)։

### GetExecutionPhases

```c#
public virtual IEnumerable<DataSourceExecutionPhase> GetExecutionPhases()
```

Վերադարձնում է տվյալների աղբյուրի կատարման փուլերը։

## Վիրտուալ մեթոդներ

### AfterDataReaderClose

```c#
protected virtual Task AfterDataReaderClose(DataSourceArgs<P> args, CancellationToken stoppingToken)
```

Sql-based տվյալների աղբյուրի sql հարցման կատարումից հետո տողերի հավելյալ մշակման, ֆիլտրման և հաշվարկային սյուների արժեքների հաշվման համար անհրաժեշտ է override անել այս մեթոդը՝ նախապես override անելով [AfterDataReaderCloseMode](#afterDataReaderCloseMode) հատկությունը՝ որպես վերադարձվող արժեք նշելով CallMode.EachRowCall արժեքը, որի արդյունքում AfterDataReaderClose մեթոդը կկանչվի մեկ անգամ՝ տողերի ընդհանուր մշակում իրականացնելու նպատակով։

### AfterDataReaderClose

```c#
protected virtual Task<bool> AfterDataReaderClose(DataSourceArgs<P> args, R row)
```

Sql-based տվյալների աղբյուրի sql հարցման կատարումից հետո տողերի հավելյալ մշակման, ֆիլտրման և հաշվարկային սյուների արժեքների հաշվման համար անհրաժեշտ է override անել այս մեթոդը՝ նախապես override անելով [AfterDataReaderCloseMode](#afterDataReaderCloseMode) հատկությունը՝ որպես վերադարձվող արժեք նշելով CallMode.EachRowCall արժեքը, որի արդյունքում AfterDataReaderClose մեթոդը կկանչվի յուրաքանչյուր տողի համար։

Օգտագործման օրինակներին ծանոթանալու համար [տե՛ս](sql_based_ds_rows_additional_processing.md#afterdatareaderclosemode-ի-օգտագործման-օրինակներ)։

### BeforeExecuteSQLCommand

```c#
protected virtual Task BeforeExecuteSQLCommand(DataSourceArgs<P> args, CancellationToken stoppingToken)
```

Նախատեսված է տվյալների աղբյուրի կատարումից առաջ նախապատրաստական աշխատանքներ կատարելու համար:

### MakeSQLCommand

```c#
protected virtual Task<SqlCommand> MakeSQLCommand(DataSourceArgs<P> args, CancellationToken stoppingToken)
```

Ձևավորում է sql-based տվյալների աղբյուրի sql հարցման հրամանը։

### ProcessRow

```c#
protected virtual bool ProcessRow(DataSourceArgs<P> args, R row, SqlDataReader reader)
```

Հանդիսանում է [AfterDataReaderClose](#afterDataReaderClose) մեթոդի համարժեքը, եթե տողերի հավելյալ մշակման համար անհրաժեշտ չէ կատարել լրացուցիչ sql հարցումներ՝ հավելյալ ինֆորմացիա ստանալու համար։

Օգտագործման օրինակներին ծանոթանալու համար [տե՛ս](sql_based_ds_rows_additional_processing.md#processRow-ի-օգտագործման-օրինակներ)։
