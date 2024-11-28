---
layout: page
title: "Վարկային հոսքագծի ենթահամակարգում օգտագործվող c# ֆունկցիաների ստեղում" 
---
## Բովանդակություն

* [Ներածություն](#ներածություն)
* [Օրինակներ](#օրինակներ)
* [AppProcessContext դասի ֆունկցիաները](#appprocesscontext-դասի-ֆունկցիաները)
    * [AppForm](#apform)


## Ներածություն

"Վարկային հոսքագիծ" ենթահամակարգում c# ֆունկցիաները օգտագործվում են ցուցանիշների հաշվարկման, ինչպես նաև յուրահատուկ անցման տեսակներ (C# Ֆունկցիա (Այո/Ոչ)) ստեղծելու համար։

Վարկային հայտերում օգտագործվող յուրաքանչյուր ցուցանիշի հաշվարկման կամ անցման փուլի նկարագրության յուրաքանչյուր ֆունկցիա իրագործվում է առանձին դասով։

Ցուցանիշների հաշվարկման համար նախատեսված դասերը իրագործում են ArmSoft.AS8X.Bank.Subsystems.IAppCustomScore ինտերֆեյսը, իսկ անցման փուլերի նկարագրության դասերը՝ ArmSoft.AS8X.Bank.Subsystems.IAppCustomCondition։

Մեկ ֆայլում կարող են պարունակվել մի քանի դասեր։ 
ՀԾ-Բանկ ներմուծելու համար յուրաքանչյուր c# ֆայլի համար անհրաժեշտ է ստեղծել մեկ սերվերային մոդուլի նկարագրության ֆայլ: 
Ֆայլերի պատրաստման և ՀԾ-Բանկ ներմուծման համար տես՝ [Սերվերային մոդուլի ձեռնարկը (SERVERSIDEMODULE)](definitions/server_side_module.md)։


## AppProcessContext դասի ֆունկցիաները

### ApForm
---
```c#
public ApForm AppForm()
```
Վերադարձնում է հայտի փաստաթուղթը։

**Օրինակ**
```c#
 /* Ստանում ենք 812735354 isn ով փաստաթղթի 7 վիճակում գրանցված լինելու իրադարձության
 առկայությունը (exist), նշված վիճակով վերջին իրադարձությունը գրանցած օգտագործղողի կոդը (suid) և 
 իրադարձության ժամանակը (dateTime)
 */
 (bool exist, int suid, string dateTime) = await proxyService.GetSUIDAndDate(812735354, 7, false);
```


public async Task<Client> ClientDoc()
async Task<AcraReport> AcraData(string reportType)
public async Task<List<PEKTaxInfo>> EkengPEKData()
public Task<decimal> EkengPEKTotalNetInc()
public Task<decimal> EkengPEKAvgNetInc()
public async Task<int> AllLoansCount()
public async Task<int> CurrentLoansCount()
public async Task<decimal> CurrentLoansAmount()
public async Task<int> RejectedAppsCount()





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





