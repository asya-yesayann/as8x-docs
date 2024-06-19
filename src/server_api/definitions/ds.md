---
layout: page
title: "Տվյալների աղբյուրի նկարագրություն" 
---

# Տվյալների աղբյուրի նկարագրություն

# Մեթոդներ

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
