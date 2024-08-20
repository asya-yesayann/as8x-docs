---
layout: page
title: "Ինյեկցիա (Dependency Injection)" 
tags: [DI, Dependency]
---

## Բովանդակություն
- [Ի՞նչ է Dependency injection-ը](#ինչ-է-dependency-injection-ը)
- [Պրոյեկտում կիրառման օրինակներ](#պրոյեկտում-կիրառման-օրինակներ)
  - [Սերվիսում օգտագործման օրինակ](#սերվիսում-օգտագործման-օրինակ)
  - [Տվյալների աղբյուրում օգտագործման օրինակ](#տվյալների-աղբյուրում-օգտագործման-օրինակ)

## Ի՞նչ է Dependency injection-ը

Dependency injection-ը ծրագրավորման մեխանիզմ է, որը թույլ է տալիս սահմանել բարդ ֆունկցիոնալություն տվող դասեր (սերվիսներ), որոնք ունեն բարդ ստեղծման մեխանիզմ և օգտագործել դրանք այլ դասերում առանց դրանց ստեղծման մասին մտածելու։ 

Օրինակ.  
Համակարգում սահմանված է [TreeElementService](/src/server_api/services/TreeElementsService.md), որը իր կոնստրուկտորում պետք է ստանա 4 պարամետր։ 
Ինյեկցիա կիրառելով այն հնարավոր է ստանալ այլ դասում առանց կոնստրուկտորը կանչելու։

```c#
public class MyExtention
{
  private readonly TreeElementService treeElementService;
  public MyExtention(TreeElementService treeElementService)
  {
    this.treeElementService = treeElementService;
  }
  //...
}
```

Բարդ ֆունկցիոնալություն տվող դասերը (սերվիսները) սահմանվում են 8X համակարգի մեջ, և կարող են օգտագործվել
- Այլ սերվիսներ ստեղծելուց,
- asp.net Controller-ներում API-ներ սահմանող մեթոդներ սահմանելուց,
- 8X համակարգի նկարագրություններ ստեղծելուց (Փաստաթուղթ, Տվյալների աղբյուր...),
- 8X համակարգի ընդլայնող դասերում (Տվյալների աղբյուրի ընդլայնում, Տպվող ձևի ընդլայնում...),
- այլ տեղերում, որտեղ հասանելի է [IServiceProvider](https://learn.microsoft.com/en-us/dotnet/api/system.iserviceprovider) ինտերֆեյսի օբյեկտը։

[IServiceProvider](https://learn.microsoft.com/en-us/dotnet/api/system.iserviceprovider) ինտերֆեյսի օբյեկտը դա հատուկ «հավաքածու» է, որը կարողանում է ստեղծել 8X համակարգի միացման ժամանակ ծրագրային սահմանված սերվիս դասերը իր [GetService](https://learn.microsoft.com/en-us/dotnet/api/system.iserviceprovider.getservice) մեթոդով։

```c#
// հիմնական GetService մեթոդ
var treeElementService1 = (TreeElementService)serviceProvider.GetService(typeof(TreeElementService));

// ընդլայնված GetService մեթոդ
var treeElementService2 = serviceProvider.GetService<TreeElementService>();
```

Ինյեկցիայով ստեղծվող սերվիսի օբյեկտը միակն է ընթացող աշխատանքի կոնտեքստում։ 
Այսինքն մի քանի անգամ ինյեկցիա անելուց կամ [GetService](https://learn.microsoft.com/en-us/dotnet/api/system.iserviceprovider.getservice) մեթոդով ստանալուց օբյեկտը լինում է նույնը։

Ավելի մանրամասն նկարագրության համար տե՛ս
- [Dependency injection in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection)
- [.NET dependency injection](https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection)
- [Dependency injection: definition, principles and uses](https://www.growin.com/what-is-dependency-injection)


## Պրոյեկտում կիրառման օրինակներ

### Սերվիսում օգտագործման օրինակ

[TreeElementService](/src/server_api/services/TreeElementsService.md) դասը իր կախվածությունները ([IDBService](/src/server_api/services/DBService.md), TimeStampService, TreeService և IErrorHandlingService) ստանում է կոնստրուկտորով ինյեկցիայի միջոցով: 
Այս սերվիսները վերագրվում են դասի ներսում նախապես հայտարարված լոկալ փոփոխականներին և օգտագործվում են դասի ներսում: 

```c#
public class TreeElementService
{
    private readonly IDBService dbService;
    private readonly TimeStampService timeStampService;
    private readonly TreeService treeService;
    private readonly IErrorHandlingService errorHandlingService;

    public TreeElementService(IDBService dbService,
                              TimeStampService timeStampService,
                              TreeService treeService,
                              IErrorHandlingService errorHandlingService)
    {
        this.dbService = dbService;
        this.timeStampService = timeStampService;
        this.treeService = treeService;
        this.errorHandlingService = errorHandlingService;
    }
    ...
}
```

### Տվյալների աղբյուրում օգտագործման օրինակ

`TreeNode` դասը իր կախվածությունը՝ [IDBService](/src/server_api/services/DBService.md), ստանում է կոնստրուկտորով ինյեկցիայի միջոցով, ինչպես նաև `IServiceProvider`, որը փոխանցում է բազային [DataSource](/src/server_api/definitions/ds.md) դասին: 
Այս դասը վերագրվում է դասի ներսում նախապես հայտարարված լոկալ փոփոխականին (`dbService`) և օգտագործվում է դասի ներսում: 

Օրինակում օգտագործված տվյալների աղբյուրի նկարագրման ձեռնարկին ծանոթանալու համար [տե՛ս](/src/server_api/definitions/ds_guide.md):  
Օրինակում օգտագործված տվյալների աղբյուրի կոդին ծանոթանալու համար [տե՛ս](/src/server_api/examples/ds/sql_based_code.cs):

```c#
[DataSource("TreeNode")]
public class TreeNode : DataSource<TreeNode.DataRow, TreeNode.Param>
{
    private readonly IDBService dbService;

    public TreeNode(IDBService dbService, IServiceProvider serviceProvider) : base(serviceProvider)
    {
        this.dbService = dbService;
        ...
    }
}
```
