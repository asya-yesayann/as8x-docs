---
layout: page
title: "Վարկային հոսքագծի ենթահամակարգում օգտագործվող C# ֆունկցիաների ստեղծման ձեռնարկ" 
sublinks:
- { title: "Ցուցանիշի հաշվարկման նվազագույն օրինակ", ref: ցուցանիշի-հաշվարկման-նվազագույն-օրինակ }
- { title: "Յուրահատուկ անցման տեսակի նվազագույն օրինակ", ref: յուրահատուկ-անցման-տեսակի-նվազագույն-օրինակ }
- { title: "Ինյեկցիաայի օրինակ", ref: ինյեկցիաայի-օրինակ }
- { title: "Օրինակներ", ref: օրինակներ }
---

## Բովանդակություն

- [Ներածություն](#ներածություն)
- [Ցուցանիշի հաշվարկման նվազագույն օրինակ](#ցուցանիշի-հաշվարկման-նվազագույն-օրինակ)
- [Յուրահատուկ անցման տեսակի նվազագույն օրինակ](#յուրահատուկ-անցման-տեսակի-նվազագույն-օրինակ)
- [Ինյեկցիաայի օրինակ](#ինյեկցիաայի-օրինակ)
- [Օրինակներ](#օրինակներ)
  
## Ներածություն

«Վարկային հոսքագիծ» ենթահամակարգում C# ֆունկցիաները օգտագործվում են ցուցանիշների հաշվարկման և յուրահատուկ անցման տեսակներ (C# Ֆունկցիա (Այո/Ոչ)) ստեղծելու համար։

Վարկային հայտերում օգտագործվող յուրաքանչյուր ցուցանիշի հաշվարկման կամ անցման փուլի նկարագրության ֆունկցիա իրականացվում է առանձին C# դասով։  

Ցուցանիշների հաշվարկման համար նախատեսված դասերը իրականացման համար նախատեսված է [IAppCustomScore](IAppCustomScore.md) ինտերֆեյսը, իսկ անցման փուլերի նկարագրության դասերը՝ [IAppCustomCondition](IAppCustomCondition.md)։  
Հաշվարկման համար հարկավոր է մշակել ինտերֆեյսում առկա միակ Evaluate մեթոդը։

Մեկ ֆայլում կարող են պարունակվել մի քանի դասեր։  
ՀԾ-Բանկ ներմուծելու համար յուրաքանչյուր C# ֆայլի համար անհրաժեշտ է ստեղծել մեկ [սերվերային մոդուլ](../definitions/server_side_module_guide.md)։ 

## Ցուցանիշի հաշվարկման նվազագույն օրինակ

```c#
using System.Threading;
using System.Threading.Tasks;
using ArmSoft.AS8X.Bank.Subsystems;
using ArmSoft.AS8X.Bank.Subsystems.Models;

namespace LoanApplication.CompanyName;

public class SimpleScore : IAppCustomScore
{
    public Task<decimal> Evaluate(AppProcessContext context, CancellationToken cancellationToken)
    {
        return Task.FromResult<decimal>(0);
    }
}
```

## Յուրահատուկ անցման տեսակի նվազագույն օրինակ

```c#
using System.Threading;
using System.Threading.Tasks;
using ArmSoft.AS8X.Bank.Subsystems;
using ArmSoft.AS8X.Bank.Subsystems.Models;

namespace LoanApplication.CompanyName;

public class SimpleCondition : IAppCustomCondition
{
    public Task<bool> Evaluate(AppProcessContext context, CancellationToken cancellationToken)
    {
        return Task.FromResult(false);
    }
}
``` 

## Ինյեկցիաայի օրինակ

Դասերում կարելի է կատարել [ինյեկցիա](../../project/injection.md) սերվերային API-ներին հասանելություն ստանալու համար։

```c#
public class SimpleScore : IAppCustomScore
{
    private readonly ExchangeRateService exchangeRateService;

    // Կատարվում է ExchangeRateService սերվիսի ինյեկցիա
    public SimpleScore(ExchangeRateService exchangeRateService)
    {
        this.exchangeRateService = exchangeRateService;
    }

    public async Task<decimal> Evaluate(AppProcessContext context, CancellationToken cancellationToken)
    {
        decimal appSum = context.AppForm().SUMMA;
        string currency = context.AppForm().CURRENCY;
        if (currency != "000")
        {
            var rate = await exchangeRateService.GetExchangeRate(currency, DateTime.Today);
            appSum *= rate.Rate;
        }

        return appSum < 500_000 ? 0.5m : 1m;
    }
}
```

## Օրինակներ

```c#
/*
Ցուցանիշը վերադարձնում է 1 արժեքը, եթե հաճախորդի ռիսկի դասիչը ստանդարտ է և 0 մնացած դեպքերում։ 
Հաշվարկը իրականացվում է ԱՔՌԱ-ից ստացված պատասխանի հիման վրա։ 
*/*
public class IsClientClassificationStandard : IAppCustomScore
{
    public async Task<decimal> Evaluate(AppProcessContext context, CancellationToken cancellationToken)
    {
        var acra = await context.AcraData("01");
        var loansClasses = acra.Data.SubGrids["RDLoans"].Rows;
        
        foreach (var row in loansClasses)
        {
            decimal amDue =  Convert.ToDecimal(row.Columns["AmountDue"].Value);
            string loanClass = (string)row.Columns["TheLoanClass"].Value ?? "";

            if (amDue > 0m && loanClass != "Ստանդարտ".ToArmenianANSI())
            {
                return 0m;
            }
        }
        return 1m;
    }
}
```

```c#
/*
Ստուգվում է արդյոք հաճախորդը կապված է բանկի հետ։ 
Նշված ֆունկցիայի միջոցով հնարավոր է կարգավորել անցման փուլ, որի ընթացքում հայտը կարող է մերժվել այն դեպքում երբ հաճախորդը կապված է բանկի հետ։
*/
public class IsConnectedToBank : IAppCustomCondition
{
    public async Task<bool> Evaluate(AppProcessContext context, CancellationToken cancellationToken)
    {
        Client client = await context.ClientDoc();
        return !client.RELBANK;
    }
}
```