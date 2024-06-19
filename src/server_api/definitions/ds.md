---
layout: page
title: "Տվյալների աղբյուրի նկարագրություն" 
---

# Տվյալների աղբյուրի նկարագրություն

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

Վերադարձնում է տվյալների աղբյուրի [սխեման]():

```c#
      protected List<R> Rows { get; set; }
```

## CommandBehaviorFlag

Վերադարձնում է sql-based տվյալների աղբյուրի հարցման կատարման ժամանակ տվյալների ստացման հատկությունները։ Ավելին մանրամասն տեղեկատվության համար տես:

```c#
      protected virtual CommandBehavior CommandBehaviorFlag
      {
        get { return CommandBehavior.Default; }
      }
```

## AfterDataReaderCloseMode

Տվյալների աղբյուրի հարցման կատարումից հետո երբեմն անհրաժեշտ է լինում հավելյալ մշակել ստացված տվյալները։ Այդ դեպքում անհրաժեշտ է գերբեռնել այս հատկությունը՝ որպես արժեք նշելով հավելյալ մշակում պետք է անել՝ CallMode.EachRowCall - ստացված տողերից յուրաքանչյուրի համար, SingleCall մի ամբողջական մշակում անել բոլոր տողերի համար։ Մշակումը իրականացնելու համար էլ անհրաժեշտ է գերբեռնել AfterDataReaderClose մեթոդը։

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

## AddRow(R)

Ավելացնում է տող տվյալների աղբյուրի տողերի ցուցակում:

```c#
protected void AddRow(R row)
```

## Execute(DataSourceArgs<P>, CancellationToken, IExtender)

Կատարում է տվյալների աղբյուրը:

```c#
public async Task<DataSourceResult<R>> Execute(DataSourceArgs<P> args, CancellationToken stoppingToken, IExtender extender = null)
```

## Execute(P, HashSet<string>, IExtender, CancellationToken )

Կատարում է տվյալների աղբյուրը:

```c#
public async Task<DataSourceResult<R>> Execute(P param, HashSet<string> columns = null, IExtender extender = null, CancellationToken stoppingToken = default)
```

---
## MakeSQLCommand(DataSourceArgs<P>, CancellationToken)

Այս մեթոդը անհրաժեշտ է գերբեռնել այն դեպքում, երբ որ ունենք sql-based տվյալների աղբյուր։ Այս մեթոդը ձևավորում ենք տվյալների աղբյուրի տվյալների լրացման համար անհրաժեշտ sql հարցումը ու այն վերադարձնել։

```c#
protected virtual Task<SqlCommand> MakeSQLCommand(DataSourceArgs<P> args, CancellationToken stoppingToken)
```

## BeforeExecuteSQLCommand(DataSourceArgs<P>, CancellationToken)

Նախատեսված է տվյալների աղբյուրի կատարումից առաջ նախապատրաստական աշխատանքներ կատարելու համար()

```c#
protected virtual Task BeforeExecuteSQLCommand(DataSourceArgs<P> args, CancellationToken stoppingToken)
```

## AfterExecuteSQLCommand(DataSourceArgs<P>, SqlDataReader)

Այս մեթոդը անհրաժեշտ է գերբեռնել եթե sql-based տվյալների աղբյուրի sql հարցման կատարումից հետո անհրաժեշտ է ստանալ հարցման սյուների պարունակությունը:

```c#
protected virtual void AfterExecuteSQLCommand(DataSourceArgs<P> args, SqlDataReader reader)
```

## ProcessRow(DataSourceArgs<P>, R, SqlDataReader)

Հանդիսանում է AfterDataReaderClose համարժեքը, եթե տվյալների տողերի հավելյալ մշակման համար անհրաժեշտ չէ կատարել լրացուցիչ sql հարցումներ հավելյալ ինֆորմացիա ստանալու համար։

```c#
protected virtual bool ProcessRow(DataSourceArgs<P> args, R row, SqlDataReader reader)
```


## AfterDataReaderClose(DataSourceArgs<P>, CancellationToken)

Տվյալների աղբյուրի հարցման կատարումից հետո երբեմն անհրաժեշտ է լինում հավելյալ մշակել ստացված տվյալները։ Այդ դեպքում անհրաժեշտ է գերբեռնել այս մեթոդը՝ նախապես գերբեռնելով AfterDataReaderCloseMode՝ը որպես վերադարձվող արժեք նշելով CallMode.EachRowCall արժեքը, որով ասում ենք որ AfterDataReaderClose մեթոդը կանչվելու է յուրաքանչյուր տողի համար։

```c#
protected virtual Task AfterDataReaderClose(DataSourceArgs<P> args, CancellationToken stoppingToken)
```

## AfterDataReaderClose(DataSourceArgs<P>, R)

Տվյալների աղբյուրի հարցման կատարումից հետո երբեմն անհրաժեշտ է լինում հավելյալ մշակել ստացված տվյալները։ Այդ դեպքում անհրաժեշտ է գերբեռնել այս մեթոդը՝ նախապես գերբեռնելով AfterDataReaderCloseMode՝ը որպես վերադարձվող արժեք նշելով CallMode.EachRowCall արժեքը, որով ասում ենք որ AfterDataReaderClose մեթոդը կանչվելու է յուրաքանչյուր տողի համար։

```c#
protected virtual Task<bool> AfterDataReaderClose(DataSourceArgs<P> args, R row)
```

## GetExecutionPhases()

Վերադարձնում է տվյալների աղբյուրի կատարման փուլերը։

```c#
public virtual IEnumerable<DataSourceExecutionPhase> GetExecutionPhases()
```
