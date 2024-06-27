---
layout: page
title: "DPR-ի նկարագրման ձեռնարկ"
---

## Բովանդակություն
  * [Նախաբան](#նախաբան)
  * [.as ընդլայնմամբ ֆայլի սահմանում](#as-ընդլայնմամբ-ֆայլի-սահմանում)
  * [.cs ընդլայնմամբ ֆայլի սահմանում](#cs-ընդլայնմամբ-ֆայլի-սահմանում)
    * [Օժանդակ դասերի սահմանում](#օժանդակ-դասերի-սահմանում)
    * [Կոնստրուկտորի ձևավորում](#կոնստրուկտորի-ձևավորում)
    * [Execute](#execute)

## Նախաբան
Սերվիսային երկար տևող հարցումներ կատարելու ու կատարման ընթացքին հետևելու համար նկարագրվում է Dpr` Data Processing Request:

8X-ում DPR նկարագրության համար հարկավոր է ունենալ`
* .as ընդլայնմամբ ֆայլ սկրիպտերում, որը պարունակում է մետատվյալներ DPR-ի մասին,
* .cs ընդլայնմամբ ֆայլ, որը պարունակում է սերվերում աշխատող տրամաբանությունը։

## .as ընդլայնմամբ ֆայլի սահմանում
- Ստեղծել .as ընդլայնմամբ ֆայլ՝ ավելացնելով DATA տիպի նկարագրություն, որը պարունակում է DPR-ի՝
  - NAME - ներքին անվանումը,
  - CAPTION - հայերեն անվանումը՝ `ANSI` կոդավորմամբ,
  - ECAPTION - անգլերեն անվանումը,
  - TYPE - տեսակը,
  - VERSION - տարբերակը,
  - CSSOURCE - սերվիսային նկարագրությունը պարունակող .cs ընդլայնմամբ ֆայլի ճանապարհը:
  
- Ստեղծված ֆայլը ներմուծել տվյալների բազա `Syscon` գործիքով։

```c#
NAME = IndexDefragment;
CAPTION = "Ինդեքսների դեֆրագմենտացիա";
ECAPTION = "Index defragmentation";
CSSOURCE = IndexDefragment.cs;
TYPE = 29;
VERSION = 2;
}
```
## .cs ընդլայնմամբ ֆայլի սահմանում

### Օժանդակ դասերի սահմանում
- Ստեղծել DPR-ի կատարման համար անհրաժեշտ պարամետրերը նկարագրող դաս։

```c#
public class IndexDefragmentRequest
{
   public bool UpdateUsage { get; set; }
}
```

- Ստեղծել DPR-ի կատարման արդյունքում ստացվող տվյալները նկարագրող դասը։
```c#

```

- Հայտատարել դաս, որը ունի DPR ատրիբուտը և ժառանգում է DataProcessingRequest<R, P> դասը՝ որպես R փոխանցելով Dpr-ի կատարման արդյունքում ստացվող տվյալները նկարագրող դասը, իսկ որպես P՝ պարամետրերը նկարագրող դասը։ Պարամետրերի բացակայության դեպքում որպես P անհրաժեշտ է փոխանցել `NoParam` դասը, արդյունքի բացակայության դեպքում որպես R փոխանցել `NoResult` դասը։

```c#
[DPR("", DPRType = DPRType.Other, ArmenianCaption = "Ինդեքսների դեֆրագմենտացիա",
                                      EnglishCaption = "Index defragmentation")]
public class IndexDefragment : DataProcessingRequest<NoResult, IndexDefragmentRequest>
```

### Կոնստրուկտորի ձևավորում
- Ձևավորել կոնստրուկտորը, որտեղ անհրաժեշտ է [ինյեկցիա](https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection) անել աշխատանքի համար անհրաժեշտ service-ները։

```c#
private IDBService DbService { get; }

public IndexDefragment(IDBService dbService)
{
this.DbService = dbService;
}
```

### Execute 

Dpr-ի կատարման համար անհրաժեշտ է գերբեռնել base դասի `Execute` մեթոդը՝ փոխանցելով պարամետրերը նկարագրող դասը և վերադարձնելով կատարման արդյունքում ստացվող տվյալները նկարագրող դասը։
```c#
public override async Task<NoResult> Execute(IndexDefragmentRequest request, CancellationToken stoppingToken)
{
      using var cmd = this.DbService.Connection.CreateCommand();
      cmd.CommandType = CommandType.StoredProcedure;
      cmd.CommandTimeout = timeout;
      cmd.CommandText = "asp_IndexDefrag";
      cmd.Parameters.Add("@withupdateusage", SqlDbType.Bit).Value = request.UpdateUsage;
      await cmd.ExecuteNonQueryAsync(stoppingToken);
      return new NoResult();
}
```
