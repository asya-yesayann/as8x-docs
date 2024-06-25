# DPR-ի նկարագրման ձեռնարկ

Սերվիսային երկար տևող հարցումներ կատարելու ու կատարման ընթացքին հետևելու համար նկարագրվում է Dpr` Data Processing Request:

# .as ընդլայնմամբ ֆայլի սահմանում
- Ստեղծել .as ընդլայնմամբ ֆայլ՝ ավելացնելով DATA տիպի նկարագրություն, որը պարունակում է DPR-ի՝
  - NAME - ներքին անվանումը,
  - CAPTION - հայերեն անվանումը՝ `ANSI` կոդավորմամբ,
  - ECAPTION - անգլերեն անվանումը,
  - CSSOURCE
  - TYPE
  - VERSION
- Ստեղծված ֆայլը ներմուծել տվյալների բազա `Syscon` գործիքով։

```c#
NAME = IndexDefragment;
CAPTION = "Ինդեքսների դեֆրագմենտացիա";
ECAPTION = "Index defragmentation";
CSSOURCE = ImportSHRlzOrd.cs;
TYPE = 29;
VERSION = 2;
}
```
# .cs ընդլայնմամբ ֆայլի սահմանում

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

- Հետո անհրաժեշտ է ձևավորել կոնստրուկտորը, որտեղ inject անել աշխատանքի համար անհրաժեշտ service-ները։
```c#
private IDBService DbService { get; }

public IndexDefragment(IDBService dbService)
{
this.DbService = dbService;
}
```

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
