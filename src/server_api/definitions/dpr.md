---
layout: page
title: "DPR Երկար աշխատող պրոցեսի նկարագրություն" 
---

## Բովանդակություն
- [Բովանդակություն](#բովանդակություն)
- [Հատկություններ](#հատկություններ)
  - [ArmenianCaption](#armeniancaption)
  - [EnglishCaption](#englishcaption)
  - [IsParametersSupported](#isparameterssupported)
  - [Name](#name)
  - [Progress](#progress)
  - [DPRType](#dprtype)
  - [IsCancellationSupported](#iscancellationsupported)
  - [PhasesCount](#phasescount)
- [Մեթոդներ](#մեթոդներ)
  - [Execute](#execute)

## Հատկություններ

### ArmenianCaption

```c#
public string ArmenianCaption { get; }
```

Վերադարձնում է DPR-ի հայերեն անվանումը:

### EnglishCaption

```c#
public string EnglishCaption { get; }
```

Վերադարձնում է DPR-ի անգլերեն անվանումը:

### IsParametersSupported

```c#
public bool IsParametersSupported { get; }
```

Ցույց է տալիս DPR-ի ունի պարամետրեր թե ոչ:

### Name

```c#
public string Name { get; }
```

Վերադարձնում է DPR-ի ներքին անունը:

### Progress

Վերադարձնում է DPR-ի կատարման պրոգրեսը:

```c#
public DataSourceExecutionProgress Progress { get; }
```
---

### DPRType

```c#
public DPRType DPRType { get; private set; }
```

Վերադարձնում է DPR-ի տեսակը։

### IsCancellationSupported

```c#
public virtual bool IsCancellationSupported { get { return true; } }
```

Ցույց է տալիս թե DPR-ի կատարումը սատարում է չեղարկումը(cancellation) թե ոչ։

### PhasesCount

```c#
public virtual short PhasesCount { get { return 1; } }
```

Ցույց է տալիս է DPR-ի կատարման փուլերի քանակը:

## Մեթոդներ

### Execute

```c#
public abstract Task<R> Execute(P p, CancellationToken stoppingToken);
```

Կատարում է DPR-ը։

**Պարամետրեր**

- `R` - Կատարման արդյունքում վերադարձվող տվյալները նկարագրող դասը:
- `p` - Կատարման համար անհրաժեշտ պարամետրերը նկարագրող դասը։
- `stoppingToken` - Չեղարկման տոկենը։