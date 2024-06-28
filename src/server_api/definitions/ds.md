---
layout: page
title: "Տվյալների աղբյուրի նկարագրություն" 
---

# Տվյալների աղբյուրի նկարագրություն
- [Հատկություններ](https://github.com/armsoft/as8x-docs/blob/main/src/server_api/definitions/ds.md#%D5%B0%D5%A1%D5%BF%D5%AF%D5%B8%D6%82%D5%A9%D5%B5%D5%B8%D6%82%D5%B6%D5%B6%D5%A5%D6%80)
- [Մեթոդներ](https://github.com/armsoft/as8x-docs/blob/main/src/server_api/definitions/ds.md#%D5%B4%D5%A5%D5%A9%D5%B8%D5%A4%D5%B6%D5%A5%D6%80)
# Հատկություններ

## Name

Վերադարձնում է տվյալների աղբյուրի ներքին անվանումը:

```c#
public string Name { get; }
```
## ArmenianCaption

Վերադարձնում է տվյալների աղբյուրի հայերեն անվանումը:
```c#
public string ArmenianCaption { get; }
```

## EnglishCaption

Վերադարձնում է տվյալների աղբյուրի անգլերեն անվանումը:
```c#
public string EnglishCaption { get; }
```

## IsParametersSupported

Ցույց է տալիս տվյալների աղբյուրը ունի պարամետրեր թե ոչ:

```c#
public bool IsParametersSupported { get; }
```

## Progress

Վերադարձնում է տվյալների աղբյուրի կատարման պրոգրեսը:

```c#
public DataSourceExecutionProgress Progress { get; }
```
---

## QueryTimeOut

Վերադարձնում կամ արժեքավորում է տվյալների աղբյուրի հարցման կատարման մաքսիմալ ժամանակը(վայրկյաններով):

```c#
public int QueryTimeOut { get; set; }
```

---

## Rows

Վերադարձնում կամ արժեքավորում է տվյալների աղբյուրի տողերը:

```c#
protected List<R> Rows { get; set; }
```

--- 

## Schema

Վերադարձնում է տվյալների աղբյուրի [սխեման](schema.md):

```c#
protected List<R> Rows { get; set; }
```

## CommandBehaviorFlag

Վերադարձնում է sql-based տվյալների աղբյուրի հարցման կատարման ժամանակ տվյալների ստացման հատկությունները։ Ավելի մանրամասն տեղեկատվության համար [տես](https://learn.microsoft.com/en-us/dotnet/api/system.data.commandbehavior?view=net-8.0):

```c#
protected virtual CommandBehavior CommandBehaviorFlag
{
   get { return CommandBehavior.Default; }
}
```

## AfterDataReaderCloseMode

Տվյալների աղբյուրի հարցման կատարումից հետո երբեմն անհրաժեշտ է լինում հավելյալ մշակել ստացված տվյալները։ Այդ դեպքում անհրաժեշտ է overload անել այս հատկությունը՝ որպես արժեք նշելով հավելյալ մշակում պետք է անել՝ CallMode.EachRowCall - ստացված տողերից յուրաքանչյուրի համար, SingleCall մի ամբողջական մշակում անել բոլոր տողերի համար։ Մշակումը իրականացնելու համար էլ անհրաժեշտ է overload անել AfterDataReaderClose մեթոդը։

```c#
public virtual CallMode AfterDataReaderCloseMode
{
    get { return CallMode.None; }
}
```
## IsSQLBased

Ցույց է տալիս թե տվյալների աղբյուրի տվյալները ստացվում են sql հարցման միջոցով թե ոչ։

```c#
public virtual bool IsSQLBased
{
    get { return true; }
}
```

## IsUpdatable

??

```c#
public virtual bool IsUpdatable
{
    get { return false; }
}
```

## SupportPrepareExecutionPhase

Ցույց է տալիս տվյալների աղբյուրի պրոգրեսով կատարումը սատարում է "Նախապատրաստում" փուլը թե ոչ:

```c#
public virtual bool SupportPrepareExecutionPhase
{
   get { return false; }
}
```

## SupportsSnapshotIsolation

Ցույց է տալիս տվյալների աղբյուրի հարցման կատարման իզոլյացիայի մակարդակը snapshot է թե ոչ:

```c#
public virtual bool SupportsSnapshotIsolation
{
   get { return false; }
}
```
---

# Մեթոդներ

## AddRow

Ավելացնում է տող տվյալների աղբյուրի տողերի ցուցակում:

```c#
protected void AddRow(R row)
```

## Execute

Կատարում է տվյալների աղբյուրը:

```c#
public async Task<DataSourceResult<R>> Execute(DataSourceArgs<P> args, CancellationToken stoppingToken, IExtender extender = null)
```

## Execute

Կատարում է տվյալների աղբյուրը:

```c#
public async Task<DataSourceResult<R>> Execute(P param, HashSet<string> columns = null, IExtender extender = null, CancellationToken stoppingToken = default)
```

---
## MakeSQLCommand

Այս մեթոդը անհրաժեշտ է overload անել այն դեպքում, երբ որ ունենք sql-based տվյալների աղբյուր։ Այս մեթոդը ձևավորում ենք տվյալների աղբյուրի տվյալների լրացման համար անհրաժեշտ sql հարցումը ու այն վերադարձնել։

```c#
protected virtual Task<SqlCommand> MakeSQLCommand(DataSourceArgs<P> args, CancellationToken stoppingToken)
```

## BeforeExecuteSQLCommand

Նախատեսված է տվյալների աղբյուրի կատարումից առաջ նախապատրաստական աշխատանքներ կատարելու համար()

```c#
protected virtual Task BeforeExecuteSQLCommand(DataSourceArgs<P> args, CancellationToken stoppingToken)
```

## AfterExecuteSQLCommand

Այս մեթոդը անհրաժեշտ է overload անել եթե sql-based տվյալների աղբյուրի sql հարցման կատարումից հետո անհրաժեշտ է ստանալ հարցման սյուների պարունակությունը:

```c#
protected virtual void AfterExecuteSQLCommand(DataSourceArgs<P> args, SqlDataReader reader)
```

## ProcessRow

Հանդիսանում է AfterDataReaderClose համարժեքը, եթե տվյալների տողերի հավելյալ մշակման համար անհրաժեշտ չէ կատարել լրացուցիչ sql հարցումներ հավելյալ ինֆորմացիա ստանալու համար։

```c#
protected virtual bool ProcessRow(DataSourceArgs<P> args, R row, SqlDataReader reader)
```


## AfterDataReaderClose

Տվյալների աղբյուրի հարցման կատարումից հետո երբեմն անհրաժեշտ է լինում հավելյալ մշակել ստացված տվյալները։ Այդ դեպքում անհրաժեշտ է overload անել այս մեթոդը՝ նախապես overload անելով AfterDataReaderCloseMode՝ը որպես վերադարձվող արժեք նշելով CallMode.EachRowCall արժեքը, որով ասում ենք որ AfterDataReaderClose մեթոդը կանչվելու է յուրաքանչյուր տողի համար։

```c#
protected virtual Task AfterDataReaderClose(DataSourceArgs<P> args, CancellationToken stoppingToken)
```

## AfterDataReaderClose

Տվյալների աղբյուրի հարցման կատարումից հետո երբեմն անհրաժեշտ է լինում հավելյալ մշակել ստացված տվյալները։ Այդ դեպքում անհրաժեշտ է overload անել այս մեթոդը՝ նախապես overload անելով AfterDataReaderCloseMode՝ը որպես վերադարձվող արժեք նշելով CallMode.EachRowCall արժեքը, որով ասում ենք որ AfterDataReaderClose մեթոդը կանչվելու է յուրաքանչյուր տողի համար։

```c#
protected virtual Task<bool> AfterDataReaderClose(DataSourceArgs<P> args, R row)
```

## GetExecutionPhases

Վերադարձնում է տվյալների աղբյուրի կատարման փուլերը։

```c#
public virtual IEnumerable<DataSourceExecutionPhase> GetExecutionPhases()
```
