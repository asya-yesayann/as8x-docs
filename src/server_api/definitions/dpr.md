---
layout: page
title: "DPR Երկար աշխատող պրոցեսի նկարագրություն" 
---

# DPR Երկար աշխատող պրոցեսի նկարագրություն

# Հատկություններ

## Name

Վերադարձնում է DPR-ի ներքին անվանումը:

```c#
public string Name { get; }
```
## ArmenianCaption

Վերադարձնում է DPR-ի հայերեն անվանումը:
```c#
public string ArmenianCaption { get; }
```

## EnglishCaption

Վերադարձնում է DPR-ի անգլերեն անվանումը:
```c#
public string EnglishCaption { get; }
```

## IsParametersSupported

Ցույց է տալիս DPR-ի ունի պարամետրեր թե ոչ:

```c#
public bool IsParametersSupported { get; }
```

## Progress

Վերադարձնում է DPR-ի կատարման պրոգրեսը:

```c#
public DataSourceExecutionProgress Progress { get; }
```
---

## DPRType

Վերադարձնում է DPR-ի տեսակը։

```c#
public DPRType DPRType { get; private set; }
```
---

## IsCancellationSupported

Ցույց է տալիս թե DPR-ի կատարումը սատարում է չեղարկումը(cancellation) թե ոչ

```c#
public virtual bool IsCancellationSupported { get { return true; } }
```

## PhasesCount

Ցույց է տալիս է DPR-ի կատարման փուլերի քանակը:

```c#
public virtual short PhasesCount { get { return 1; } }
```


# Մեթոդներ

## Execute

Կատարում է DPR-ը` ստանալով՝
- կատարման համար անհրաժեշտ պարամետրերը նկարագրող դասը,
- չեղարկման տոկենը։
  
```c#
public abstract Task<R> Execute(P p, CancellationToken stoppingToken);
```

