---
layout: page
title: "Ինյեկցիա (Dependency Injection)" 
tags: [DI, Dependency]
---

## Բովանդակություն
- [Բովանդակություն](#բովանդակություն)
- [Ի՞նչ է Dependency injection-ը](#ինչ-է-dependency-injection-ը)
- [Պրոյեկտում կիրառման օրինակներ](#պրոյեկտում-կիրառման-օրինակներ)
  - [Սերվիսում օգտագործման օրինակ](#սերվիսում-օգտագործման-օրինակ)
  - [Տվյալների աղբյուրում օգտագործման օրինակ](#տվյալների-աղբյուրում-օգտագործման-օրինակ)

## Ի՞նչ է Dependency injection-ը

Dependency injection-ը ծրագրավորման մեխանիզմ է, որը դասը դարձնում է անկախ այլ դասերից, որոնց ֆունկցիոնալությունը օգտագործում է։ Դա կատարվում է օբյեկտի օգտագործումը և ստեղծումը իրարից անջատելով։ Այսինքն դասերը չեն ստեղծում այն դասերի օրինակներ, որոնց ֆունկցիոնալությունից օգտվելու են։

Ավելի մանրամասն նկարագրության համար տե՛ս

- [.NET dependency injection](https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection)
- [Dependency injection: definition, principles and uses](https://www.growin.com/what-is-dependency-injection)
- [Dependency injection in simple words](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/)


## Պրոյեկտում կիրառման օրինակներ

### Սերվիսում օգտագործման օրինակ

[TreeElementService](/src/server_api/services/TreeElementsService.md) դասը իր կախվածությունները (IDBService, TimeStampService, TreeService և IErrorHandlingService) ստանում է կոնստրուկտորով ինյեկցիայի միջոցով: Այս սերվիսները վերագրվում են դասի ներսում նախապես հայտարարված լոկալ փոփոխականներին և օգտագործվում են դասի ներսում: Դասի օրինակները ստեղծվում են Dependency Injection-ի մեխանիզմի [Container](https://dev.to/shutoosawa/learning-dependency-injection-ioc-container-in-c-kn9)-ի միջոցով ծրագրի աշխատանքի ընթացքում:

Դասի ամբողջական նկարագրության համար կարող եք ծանոթանալ [այստեղ](/src/server_api/services/TreeElementsService.md):

```c#
public class TreeElementService
{
    private readonly IDBService dbService;
    private readonly TimeStampService timeStampService;
    private readonly TreeService treeService;
    private readonly IErrorHandlingService errorHandlingService

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

TreeNode դասը իր կախվածությունը՝ IDBService, ստանում է կոնստրուկտորով ինյեկցիայի միջոցով, ինչպես նաև IServiceProvider, որը փոխանցում է բազային DataSource դասին: 
Այս դասը վերագրվում է դասի ներսում նախապես հայտարարված լոկալ փոփոխականին (dBService) և օգտագործվում է դասի ներսում: 
Դասի օրինակը ստեղծվում է Dependency Injection մեխանիզմի [Container](https://dev.to/shutoosawa/learning-dependency-injection-ioc-container-in-c-kn9)-ի միջոցով ծրագրի աշխատանքի ընթացքում:

Օրինակում օգտագործված տվյալների աղբյուրի նկարագրման ձեռնարկին ծանոթանալու համար [տե՛ս](/src/server_api/definitions/ds_guide.md):

Օրինակում օգտագործված տվյալների աղբյուրի կոդին ծանոթանալու համար [տե՛ս](/src/server_api/examples/ds/sql_based_code.cs):

```c#
[DataSource(nameof(TreeNode))]
public class TreeNode : DataSource<TreeNode.DataRow, TreeNode.Param>
{
    private readonly IDBService dBService;

    public TreeNode(IDBService dbService, IServiceProvider serviceProvider) : base(serviceProvider)
    {
        this.dBService = dbService;
        ...
    }
}
```
