---
layout: page
title: "Հաշվառման ընդլայնման ձեռնարկ" 
tags: [AccountingExtender, AccExtender]
---

## Բովանդակություն

- [Ներածություն](#ներածություն)
- [.as ֆայլի ստեղծում](#as-ֆայլի-ստեղծում)
- [.cs ֆայլի ստեղծում](#cs-ֆայլի-ստեղծում)
- [Ֆայլերի ներմուծում](#ֆայլերի-ներմուծում)

## Ներածություն

Գոյություն ունեցող [հաշվառումների](../../server_api/definitions/accounting.md) մշակման գործընթացում լրացուցիչ ստուգումներ իրականացնելու և այլ սեփական տրամաբանություն ավելացնելու համար նկարագրվում է [հաշվառման ընդլայնում](acc_extender.md)։

[Հաշվառման ընդլայնումը](acc_extender.md) իրանից ներկայացնում է վիրտուալ մեթոդների բազմություն, որոնք կանչվում են [հաշվառման հիմնական իրադարձություններից](../../server_api/definitions/accounting.md) առաջ և հետո։ 

8X համակարգում հաշվառման ընդլայնում նկարագրելու համար հարկավոր է ունենալ

* .as ընդլայնմամբ ֆայլ սկրիպտերում [ACCEXTENDER](acc_extender.md#accextender-նկարագրություն) նկարագրությամբ, որը պարունակում է մետատվյալներ ընդլայնման մասին,
* .cs ընդլայնմամբ ֆայլ, որը պարունակում է սերվերում աշխատող տրամաբանությունը։

## .as ֆայլի ստեղծում

``` as4x
ACCEXTENDER {
  NAME = 01;
  CAPTION = "Սինթետիկ հաշիվների հաշվառման ընդլայնում";
  ECAPTION = "Synthetic accounts' accounting's extender";
  CSSOURCE = SyntAccountingExtender.cs;
}
```

Ստեղծել .as ընդլայնմամբ ֆայլ `ACCEXTENDER` նկարագրությամբ, որը պարունակում է 

- `NAME` - Ընդլայնվող հաշվառման ներքին անունը (կոդը)։
- `CAPTION` - Ընդլայնման հայերեն անվանումը ANSI կոդավորմամբ։
- `ECAPTION` - Ընդլայնման անգլերեն անվանումը։
- `CSSOURCE` - Ընդլայնող C# ֆայլի [հարաբերական ճանապարհը](https://phoenixnap.com/kb/absolute-path-vs-relative-path) .as ֆայլի նկատմամբ։

Օրինակներ՝  
* Եթե extend.as և extend.cs ֆայլերը գտնվում են նույն թղթապանակում, ապա կգրվի `CSSOURCE = "extend.cs";`։  
* Եթե extend.as գտվում է "C:\WorkingDir\Scripts\App\extend.as" հասցեում, իսկ extend.cs-ը՝ "C:\WorkingDir\SubFolder1\SubFolder2\extend.as" հասցեում, ապա `CSSOURCE = "..\..\SubFolder1\SubFolder2\extend.cs";`։  
* Կամ կլինի գրել ամբողջական ճանապարհը, ինչը խրախուսելի չէ `CSSOURCE = "C:\WoringDir\SubFolder1\SubFolder2\extend.cs";`

## .cs ֆայլի ստեղծում

- Ստեղծել դաս, որը ունի `AccountingExtender` ատրիբուտը և  ժառանգում է [AccountingExtender](acc_extender.md#accountingextender-դաս) դասը:

```c#
[AccountingExtender]
public class SyntAccountingExtender : AccountingExtender
```

- Ձևավորել ընդլայնող դասի կոնստրուկտորը՝ [ինյեկցիա](../../project/injection.md) անելով աշխատանքի համար անհրաժեշտ սերվիսները։

```c#
private readonly EnterpriseParametersService parametersService;
private readonly IDBService dbService;

public SyntAccountingExtender(EnterpriseParametersService parametersService, IDBService dbService)
{
    this.parametersService = parametersService;
    this.dbService = dbService;
}
```

- [OnDelete](../../server_api/definitions/accounting.md#ondelete) մեթոդով [հաշվառումը](../../server_api/definitions/accounting.md) հեռացնելուց առաջ լրացուցիչ տրամաբանություն ավելացնելու համար անհրաժեշտ է override անել [PreOnDelete](acc_extender.md#preondelete) մեթոդը։

Մեթոդը կանչվում է միջուկի կողմից։

Օրինակում ստուգվում է արդյոք թույլատրված է հաշվառման հեռացումը՝ կախված պարամետրից։ Թույլատրված չլինելու դեպքում առաջացնում է սխալ։ 

```c#
public override async Task PreOnDelete(Core.Accounting.Accounting sender, OnDeleteEventArgs onDeleteEventArgs)
{
    if (!await this.parametersService.GetBooleanValue("CanDeleteAccTrans"))
    {
        throw new RESTException("Հաշվապահական ձևակերպումը հեռացնելու իրավասություն չունեք".ToArmenianANSI());
    }
}
```

- [OnDelete](../../server_api/definitions/accounting.md#ondelete) մեթոդով [հաշվառումը](../../server_api/definitions/accounting.md) հեռացնելուց հետո լրացուցիչ տրամաբանություն ավելացնելու համար անհրաժեշտ է override անել [PostOnDelete](acc_extender.md#postondelete) մեթոդը։

Մեթոդը կանչվում է միջուկի կողմից։

Օրինակում հեռացվում են հաշվառման հաշվի մնացորդները [HIREST2](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/Hirest2.html) աղյուսակից։

```c#
public override async Task PostOnDelete(Core.Accounting.Accounting sender, OnDeleteEventArgs onDeleteEventArgs)
{
    using var cmd = this.dbService.CreateCommand();
    cmd.CommandText = "DELETE FROM HIREST2 WHERE fOBJECT = ?ObjectISN";
    cmd.Parameters.Add("@ObjectISN", SqlDbType.Int).Value = onDeleteEventArgs.Fact.ObjectISN;

    await cmd.ExecuteNonQueryAsync();
}
```

## Ֆայլերի ներմուծում

.as և .cs ընդլայնմամբ ֆայլերը պատրաստ լինելուն պես անհրաժեշտ է **SYSCON**-ով համապատասխան .as ֆայլը ներմուծել համակարգ, ինչի արդյունքում .cs ֆայլը նույնպես կներմուծվի։ 
