---
layout: page
title: "DSParser դաս: Տվյալների աղբյուրների 8X տեղափոխման մասնակի ավտոմատացում"
tags: [CodeGen, DSParser]
sublinks:
- { title: "DSParser", ref: dsparser }
- { title: "Մեթոդներ", ref: մեթոդներ }
- { title: "Parse", ref: parse }
---

Բովանդակություն

- [DSParser](#dsparser)
- [Մեթոդներ](#մեթոդներ)
  - [Parse](#parse)

# DSParser

```c#
public static class DSParser
```

DSParser դասը նախատեսված է 4X-ում նկարագրված տվյալների աղբյուրների նկարագրման հատվածը (Definition) 8X տեղափոխելու համար։  
Օգտագործվում է Text Template գործիքի մեջ։  
Օգտագործման համար տե՛ս [CodeGen : 4X նկարագրությունների տեղափոխման մասնակի ավտոմատացում](DSParser.md):

# Մեթոդներ

## Parse

```c#
public static string Parse(
    string configFilePath,
    string filename,
    string dsName,
    string namespaceName,
    string className = "",
    bool generatePublicConstructor = false,
    string conditionalCompilationList = "")
```

Մեթոդը գեներացնում է տվյալների աղբյուրի 4X-ական նկարագրությանը համարժեք 8X-ական դասերը:

Պարամետրեր

- `configFilePath`  
  CodeGen.xml-ի ամբողջական ճանապարհը։  
  Սովորաբար կանչը փոխանցվում է հետևյալ ձևով՝ `this.Host.ResolvePath(@"..\..\CodeGen.xml")`, որտեղ ResolvePath ֆունկցիային տրված է CodeGen.xml-ի հարաբերական ճանապարհը ընթացիկ `.tt` ֆայլի նկատմամբ։

- `filename`  
  Տվյալների աղբյուրը պարունակող `.as` ընդլայնմամբ ֆայլի ճանապարհը:

- `dsName`  
  Տվյալների աղբյուրի ներքին անունը:

- `namespaceName`  
  Գեներացվող դասի namespace-ի վերջին հատվածը (namespace-ի սկիզբը միշտ `ArmSoft.AS8X.` է)։

- `className`  
  Գեներացվող դասի անունը։ 
  Չլրացնելու դեպքում համընկնելու է տվյալների աղբյուրի ներքին անվան հետ՝ `dsName`։

- `generatePublicConstructor`  
  Գեներացվող դասի կոնստրուկտորը լինի public, թե private հասանելիությամբ։ 
  Չլրացնելու դեպքում գեներացվում է private հասանելիությամբ կոնստրուկտոր:

- `conditionalCompilationList`  
  Որոշ տվյալների աղբյուրներ ընդհանուր են մի քանի համակարգերի համար և տարբերվում են միայն գտնվելու տեղով՝ namespace-ով։ 
  Նույն դասը 2 տեղ չգրելու համար անհրաժեշտ է այն տեղադրել Tfs-ում ընդհանուր հասանելիության թղթապանակում և լինկով միացնել անհրաժեշտ պրոյեկտներում, իսկ `conditionalCompilationList`-ում գրել այն պրոյեկտների անունները, որոնց լինկով միացվելու է դասը։ 
  Պրոյեկտների անունները անհրաժեշտ է իրարից անջատել ստորակետերով։
