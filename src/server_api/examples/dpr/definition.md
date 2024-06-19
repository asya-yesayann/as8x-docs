# Ինչպես նկարագրել DPR

Սերվիսային երկար տևող հարցումներ կատարելու ու կատարման ընթացքին հետևելու համար նկարագրվում է Dpr` Data Processing Request:

- Անհրաժեշտ է հայտատարել դաս, որը ժառանգում է DataProcessingRequest<R, P>  դասը, որտեղ որպես R անհրաժեշտ է փոխանցել Dpr-ի կատարման արդյունքում ստացվող տվյալները նկարագրող դասը, իսկ որպես P` Dpr-ի կատարման համար անհրաժեշտ պարամետրերը նկարագրող դաս։

```c#
   public class IndexDefragment : DataProcessingRequest<NoResult, IndexDefragmentRequest>
```

Եթե Dpr-ի կատարման արդյունքում տվյալներ չեն ստացվում, ապա որպես R անհրաժեշտ է փոխանցել `NoResult` դասը։

```c#
   public class IndexDefragment : DataProcessingRequest<NoResult, IndexDefragmentRequest>
```

Եթե Dpr-ի համար անհրաժեշտ պարամետրեր չկան, ապա որպես P անհրաժեշտ է փոխանցել `NoParam` դասը։
```c#
    public class IndexDefragment : DataProcessingRequest<NoResult, NoParam>
```

- Հետո անհրաժեշտ է ձևավորել կոնստրուկտորը, որտեղ inject անել աշխատանքի համար անհրաժեշտ service-ները։
```c#
        private IDBService DbService { get; }

        public IndexDefragment(IDBService dbService)
        {
            this.DbService = dbService;
        }
```

Dpr-ը կատարման համար անհրաժեշտ է գերբեռնել base դասի `Execute` մեթոդը
```c#
   Task<object> Execute(object param, CancellationToken stoppingToken);
```

որտեղ `object param`-ի փոխարեն անհրաժեշտ է փոխանցել Dpr-ի կատարման համար անհրաժեշտ պարամետրերը նկարագրող դասը, իսկ որպես վերադարձվող արժեք նշել՝ Dpr-ի կատարման արդյունքում ստացվող տվյալները նկարագրող դասը։

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
