---
layout: page
title: "Տպելու ձևերի ընդլայնում"
tags:
- TemplateSubstitutionExtender
- ITemplateSubstitutionExtender
- TemplateSubstitution
---

## Բովանդակություն

- [Ներածություն](#ներածություն)
- [.as ֆայլի նկարագրություն](#as-ֆայլի-նկարագրություն)
- [C# ֆայլի նկարագրություն](#c-ֆայլի-նկարագրություն)
- [ITemplateSubstitutionExtender ինտերֆեյս](#itemplatesubstitutionextender-ինտերֆեյս)
- [Մեթոդներ](#մեթոդներ)
  - [Calculate](#calculate)

## Ներածություն

Գոյություն ունեցող տպելու ձևանմուշների պարամետրերի հաշվարկի տրամաբանությունը փոփոխելու համար նկարագրվում է տպելու ձևանմուշի ընդլայնում։

8X համակարգում տվյալների աղբյուրի ընդլայնում նկարագրելու համար հարկավոր է ունենալ

* .as ընդլայնմամբ ֆայլ սկրիպտերում [SERVERSIDEMODULE](server_side_module_guide.md) նկարագրությամբ, որը պարունակում է մետատվյալներ ընդլայնման մասին,
* .cs ընդլայնմամբ ֆայլ, որը պարունակում է սերվերում աշխատող տրամաբանությունը։

.as և .cs ընդլայնմամբ ֆայլերը լրացնելուց հետո անհրաժեշտ է .as ընդլայնմամբ ֆայլը ներմուծել համակարգ `SYSCON` գործիքի միջոցով, որի արդյունքում կներմուծվի նաև .cs ընդլայնմամբ ֆայլը։

## .as ֆայլի նկարագրություն

Տե՛ս 

* [SERVERSIDEMODULE նկարագրության հատկություններ](server_side_module.md#serversidemodule-նկարագրություն)
* [SERVERSIDEMODULE նկարագրման ձեռնարկ](server_side_module_guide.md)

**Օրինակ**

```as4x
SERVERSIDEMODULE {Name = MTSIncAEG;
Caption = "Պահեստի մուտքի օրդեր";
ECaption = "Storage input order";
Cssource = MTSIncAEG.cs;
};
```

## C# ֆայլի նկարագրություն

Տպելու ձևանմուշի ընդլայնման համար անհրաժեշտ է սահմանել դաս, որը իրականացնում է `ITemplateSubstitutionExtender` ինտերֆեյսը և ունի `TemplateSubstitutionExtender` ատրիբուտը։

**Օրինակ**

```c#
[TemplateSubstitutionExtender]
public class BusTripExtended : ITemplateSubstitutionExtender 
```

## ITemplateSubstitutionExtender ինտերֆեյս

Այս ինտերֆեյսը նախատեսված է տպելու ձևանմուշների ընդլայնման դասերի սահմանման համար։

## Մեթոդներ

### Calculate

```c#
public Task Calculate(TemplateSubstitutionExtenderArgs templateSubstitutionExtenderArgs);
```

Իրականացնում է տպելու ձևանմուշի ընդլայնման պարամետրերի հաշվարկը։

**Պարամետրեր**
* `templateSubstitutionExtenderArgs` - Տպելու ձևանմուշի պարամետրերը նկարագրող դասը։
