---
layout: page
title: "Վարկային հոսքագծի ենթահամակարգում օգտագործվող c# ֆունկցիաների ստեղում" 
---
## Բովանդակություն

* [Ներածություն](#ներածություն)
* [AppProcessContext դասի ֆունկցիաները](loan_app_functions.md)
* [Օրինակներ](#օրինակներ)
  
## Ներածություն

"Վարկային հոսքագիծ" ենթահամակարգում c# ֆունկցիաները օգտագործվում են ցուցանիշների հաշվարկման, ինչպես նաև յուրահատուկ անցման տեսակներ (C# Ֆունկցիա (Այո/Ոչ)) ստեղծելու համար։

Վարկային հայտերում օգտագործվող յուրաքանչյուր ցուցանիշի հաշվարկման կամ անցման փուլի նկարագրության ֆունկցիա իրագործվում է առանձին դասով։

Ցուցանիշների հաշվարկման համար նախատեսված դասերը իրագործում են ArmSoft.AS8X.Bank.Subsystems.IAppCustomScore ինտերֆեյսը, իսկ անցման փուլերի նկարագրության դասերը՝ ArmSoft.AS8X.Bank.Subsystems.IAppCustomCondition։

Մեկ ֆայլում կարող են պարունակվել մի քանի դասեր։ 
ՀԾ-Բանկ ներմուծելու համար յուրաքանչյուր c# ֆայլի համար անհրաժեշտ է ստեղծել մեկ սերվերային մոդուլի նկարագրության ֆայլ: 
Ֆայլերի պատրաստման և ՀԾ-Բանկ ներմուծման համար տես՝ [Սերվերային մոդուլի ձեռնարկը (SERVERSIDEMODULE)](definitions/server_side_module.md)։


**Ցուցանիշի հաշվարկման համար նախատեսված դասի ձևանմուշ**

```c#
using ArmSoft.AS8X.Bank.Subsystems;
using ArmSoft.AS8X.Bank.Subsystems.Models;
using System.Threading;
using System.Threading.Tasks;

namespace LoanApplication.CompanyName;

public class CalculateSomeIndex : IAppCustomScore
{

    public async Task<decimal> Evaluate(AppProcessContext context, CancellationToken cancellationToken)
    {
        return await Task.Run(() => 1m);
    }
}
```

**Յուրահատուկ անցման տեսակի ֆունկցիայի դասի ձևանմուշ**

```c#
using ArmSoft.AS8X.Bank.Subsystems;
using ArmSoft.AS8X.Bank.Subsystems.Models;
using System.Threading;
using System.Threading.Tasks;

namespace LoanApplication.CompanyName;

public class ProcessSomeVerifications : IAppCustomCondition
{
    public async Task<bool> Evaluate(AppProcessContext context, CancellationToken cancellationToken)
    {
        return await Task.Run(() => true);
    }
}
```

Դասերը ծրագրավորելուց հնարավոր է օգտագործել 8x տարբեր սերվիսներ։ Դրա համար անհրաժեշտ է կատարել պահանջվող սերվիսների ինյեկցիա։

```c#
using ArmSoft.AS8X.Bank.General.Currency;
using ArmSoft.AS8X.Bank.UserProxy;

public class CalculateSomeIndex : IAppCustomScore
{
     private ExchangeRateService exchangeRateService;
     private readonly UserProxyService proxyService;
     
     // Կատարվում է ExchangeRateService սերվիսի ինյեկցիա
     public CalculateSomeIndex(ExchangeRateService exchangeRateService)
     {
        this.exchangeRateService = exchangeRateService;
     }

        public async Task<decimal> Evaluate(AppProcessContext context, CancellationToken cancellationToken)
    {
        decimal appSum = context.AppForm().SUMMA;
        string currency = context.AppForm().CURRENCY;
        if (currency != "000")
        {
            var rate = await exchangeRateService.GetExchangeRate(currency, DateTime.Now);
            appSum *= rate.Rate;
        }

        return appSum < 500_000 ? 0.5m : 1m;
    }
}
```

## Օրինակներ

```c#
/*
Ֆունկցիան վերադարձնում է 1 արժեքը եթե հաճախորդի ռիսկի դասիչը ստանդարտ է և 0 մնացած դեպքերում։ Հաշվարկը իրականացվում է ԱՔՌԱ -ից ստացված պատասխանի հիման վրա։ 
*/

public class IsClientClassificationStandard : IAppCustomScore
{
    public async Task<decimal> Evaluate(AppProcessContext context, CancellationToken cancellationToken)
    {
        var acra = await context.AcraData("01");
        var loansClasses = acra.Data.SubGrids["RDLoans"].Rows;
        
        if (loansClasses.Count == 0)
        {
            return 1m;
        }
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
// Ստուգվում է արդյոք հաճախորդը կապված է բանկի հետ։ Նշված ֆունկցիա միջոցով հնարավոր է կարգավորել
// անցման փուլ, որի ընթացքում հայտը կարող է մերժվել այն դեպքում երբ հաճախորդը կապված է բանկի հետ։

public class IsConnectedToBank : IAppCustomCondition
{
    public async Task<bool> Evaluate(AppProcessContext context, CancellationToken cancellationToken)
    {
        Client client = await context.ClientDoc();

        return !client.RELBANK;
    }
}
```