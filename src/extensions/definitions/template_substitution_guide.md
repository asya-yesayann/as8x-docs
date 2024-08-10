---
layout: page
title: "Տպելու ձևերի ընդլայնման ձեռնարկ"
tags:
- TemplateSubstitutionExtender
- ITemplateSubstitutionExtender
- TemplateSubstitution
---

## Բովանդակություն

* [Ներածություն](#ներածություն)  
* [C# ֆայլի նկարագրություն](#c-ֆայլի-նկարագրություն)  
* [Ընդլայնման կապակցում տպելու ձևանմուշին](#ընդլայնման-կապակցում-տպելու-ձևանմուշին)  
* [Օրինակներ](#օրինակներ)
* [Հատուկ դեպքեր](#հատուկ-դեպքեր)

## 	Ներածություն

Տպելու ձևանմուշների ընդլայնումը իրականացվում է ծրագրավորման միջոցով օգտագորելով C# լեզուն: Օգտագործվում է [սերվերային մոդուլ](/src/extensions/definitions/server_side_module_guide.md) ընդլայնումը համակարգ ներմուծելու համար։ Անհրաժեշտ է ստեղծել երկու ֆայլ՝
1.	պարամետրերի հաշվարկի ծրագրերը պարունակող C# ֆայլը,
2.	`.as` ընդլայնումով [սերվերային մոդուլի](/src/extensions/definitions/server_side_module_guide.md) նկարագրող ֆայլը, որը օգտագործվում է C# ֆայլը ներմուծելիս։

Ստեղծված ֆայլերը պետք է [ներմուծել](/src/extensions/definitions/server_side_module_guide.md#ընդլայնման-ներմուծում) համակարգ, որից հետո [կապակցել](#ընդլայնման-կապակցում-տպելու-ձևանմուշին) տպվող ձևի ձևանմուշին։
Ընդլայնվող տպելու ձևանմուշում բոլոր լրացուցիչ պարամետրերը պետք է ծրագրավորված լինեն մեկ C# դասի միջոցով։

Չնայած որ, մեկ ֆայլը կարող է պարունակել բազնաթիվ դասեր, տպելու ձևանմուշին հնարավոր է կապակցել միայն մեկ դաս։

Տպելու ձևանմուշին ընդլայնման բոլոր հատկությունները տրված են [տեխնիկական նկարագրության էջում](template_substitution.md)։

## C# ֆայլի նկարագրություն

Տպելու ձևանմուշի ընդլայնման դասը պետք է ունենա `[TemplateSubstitutionExtender]` ատրիբուտը և իրագործի `ITemplateSubstitutionExtender` ինտերֆեյսը։

```c#
[TemplateSubstitutionExtender]
public class AccStateAdr_Extander : ITemplateSubstitutionExtender 
```

Նոր դասում կարելի է կատարել [ինյեկցիա](/src/project/injection.md) սերվերային API-ներին հասանելություն ստանալու համար։

```c#
[TemplateSubstitutionExtender]
public class AccStateAdr_Extander : ITemplateSubstitutionExtender 
{
    private readonly UserProxyService proxyService;
     
    public AccStateAdr_Extander(UserProxyService proxyService)
    {
        this.proxyService = proxyService;
    }

    ...
}
```

Ավելացվող տպելու պարամետրերի հաշվարկը իրականացվում է `Calculate` ֆունկցիայում։  
Այն որպես պարամետր ստանում է `TemplateSubstitutionExtenderArgs` տիպի օբյեկտ, որի միջոցով հնարավոր է հասանելիություն ստանալ տպվող փաստաթղթին և հաշվարկված տպվող կոդերի բազմությանը։

Ավելացվող նոր պարամետրերի արժեքները պետք է լինեն ANSI կոդավորմամբ։ Տե՛ս [հատուկ դեպքերը](#հատուկ-դեպքեր)։

```c#
public Task Calculate(TemplateSubstitutionExtenderArgs args)
{
    //Վերադարձնում է ատոմար տպելու պարամետրերի ցուցակը
    var atomics = args.Substitution.AtomicSubstitutions;

    //Վերադարձնում է այն փաստաթուղթը, որի վրայից ձևավորվում է տպվող ձևը
    var agrDoc = args.Document;

    if (agrDoc["CURRENCY"].ToString() == "001" || agrDoc["CURRENCY"].ToString() == "049")
    {
        atomics.Add("CurType", "Ազատ փոխարկելի արտարժույթ".ToArmenianANSI());
    }
    else
    {
        atomics.Add("CurType", "");
    }
    return Task.CompletedTask;
}
```

Պարամետրի հաշվարկը և ավելացումը հնարավոր է կատարել նաև [UserProxyService](/src/extensions/user_proxy_service.md)-ի [TryAddAtomic](/src/extensions/user_proxy_service.md#tryaddatomic) կամ [TryAddAtomicAsync](/src/extensions/user_proxy_service.md#tryaddatomicasync) մեթոդովներով։
Այս դեպքում մեկ պարամետրի հաշվարկի ընթացքում առաջացած սխալի դեպքում ծրագրի աշխատանքը չի ընդհատվի շարունակելով մնացած բոլոր պարամետրերի հաշվակը։

```c#
[TemplateSubstitutionExtender]
public class AccStatements : ITemplateSubstitutionExtender
{
    private readonly UserProxyService proxyService;
    public AccStatements(UserProxyService proxyService)
    {
        this.proxyService = proxyService;
    }
    public async Task Calculate(TemplateSubstitutionExtenderArgs args)
    {
        var accountDoc = (Account)args.Document;
        await proxyService.TryAddAtomicAsync("pass", async () =>
        {
            var clientDoc = await this.proxyService.LoadClientDescByCode(accountDoc.CLICOD);
            return clientDoc.PasCode;
        }, args);
    }
}
```

## Ընդլայնման կապակցում տպելու ձևանմուշին

Ընդլայնման ֆայլերը ներմուծելուց հետո կատարվում է կապակցում տպելու ձևանմուշի հետ։ Այդ նպատակով անհրաժեշտ է լրացնել համապատասխան դաշտերը "Տպելու ձևանմուշի օգտ.նկարագրված պարամետրեր" փաստաթղթի "Տպվող ձևանմուշի ընդլայնումը սերվիսում" էջում։

| Դաշտի անվանում | Նկարագրություն |
|-|-|
| Ընդլայնման նկարագրության անվանում | Համապատասխանում է `.as` ֆայլում սերվերային մոդուլի `Name` հատկության արժեքին: |
| Դասի անուն նկարգրությունում | C# Ֆայլում պարունակվող դասի անվանումը, որտեղ իրագործված է լրացուցիչ պարամետրերի հաշվարկը: |

Երկու դաշտերը հնարավոր է լրացնել ընտրելով համապատասխան արժեքը ցուցակից սեղմելով դաշտի կողքի հապապատասխան կոճակը։ 

![Ընդլայնման կապակցում ձևանմուշին](template_substitution_guide_connect_template.png)

## Օրինակներ

Տե՛ս [հաշվի քաղվածքի ընդլայնման օրինակ](/src/extensions/examples/template_substitution_AccState.md)։

## Հատուկ դեպքեր

ՀԾ-Բանկում հաշվի և քարտի քաղվածքում նոր պարամետրեր ավելացնելուց արժեքը պետք է լինի Unicode կոդավորմամբ, երբ ձևանմուշը պետք է արտահանվի Unicode, այսինքն գրեթե միշտ։
