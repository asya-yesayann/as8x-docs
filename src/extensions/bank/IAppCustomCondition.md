---
layout: page
title: "IAppCustomCondition, C# Ֆունկցիա (Այո/Ոչ)" 
---

## C# Ֆունկցիա (Այո/Ոչ)

«Վարկային հոսքագիծ» ենթահամակարգում յուրահատուկ անցման փուլի համար նախատեսված ինտերֆեյս։

``` c#
namespace ArmSoft.AS8X.Bank.Subsystems;

public interface IAppCustomCondition
{
    Task<bool> Evaluate(AppProcessContext context, CancellationToken cancellationToken);
}
```

Անցման փուլի հաշվարկման համար հարկավոր է իրականացնել այս ինտերֆեյսը և ստացված C# ֆայլը ներմուծել որպես [սերվերային մոդուլ](../definitions/server_side_module_guide.md)։

Տե՛ս [ձեռնարկը](loan_app.md)