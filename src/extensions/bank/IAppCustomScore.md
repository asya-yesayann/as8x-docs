---
layout: page
title: "IAppCustomScore, C# Ֆունկցիա (ցուցանիշ)" 
---

## C# Ֆունկցիա (ցուցանիշ)

«Վարկային հոսքագիծ» ենթահամակարգում յուրահատուկ ցուցանիշի համար նախատեսված ինտերֆեյս։

``` c#
namespace ArmSoft.AS8X.Bank.Subsystems;

public interface IAppCustomScore
{
    Task<decimal> Evaluate(AppProcessContext context, CancellationToken cancellationToken);
}
```

Ցուցանիշի հաշվարկման համար հարկավոր է իրականացնել այս ինտերֆեյսը և ստացված C# ֆայլը ներմուծել որպես [սերվերային մոդուլ](../definitions/server_side_module_guide.md)։

Տե՛ս [ձեռնարկը](loan_app.md)