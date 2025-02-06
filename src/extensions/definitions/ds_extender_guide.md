---
layout: page
title: "Տվյալների աղբյուրի ընդլայնման ձեռնարկ" 
sublinks:
- { title: ".as ֆայլի ստեղծում", ref: as-ֆայլի-ստեղծում }
- { title: ".cs ֆայլի ստեղծում", ref: cs-ֆայլի-ստեղծում }
- { title: "ProccessRow ֆունկցիա", ref: proccessrow-ֆունկցիա }
- { title: "BeforeProcess ֆունկցիա", ref: beforeprocess-ֆունկցիա }
- { title: "Ներմուծում և օգտագործում", ref: ներմուծում-և-օգտագործում }
---

## Բովանդակություն

- [Ներածություն](#ներածություն)
- [.as ֆայլի ստեղծում](#as-ֆայլի-ստեղծում)
- [.cs ֆայլի ստեղծում](#cs-ֆայլի-ստեղծում)
  - [ProccessRow ֆունկցիա](#proccessrow-ֆունկցիա)
  - [BeforeProcess ֆունկցիա](#beforeprocess-ֆունկցիա)
- [Ներմուծում և օգտագործում](#ներմուծում-և-օգտագործում)

## Ներածություն

Գոյություն ունեցող դիտելու ձևերում լրացուցիչ սյուներ, պարամետրեր ավելացնելու, տողերի պարունակությունը փոփոխելու համար նկարագրվում է տվյալների աղբյուրի ընդլայնում։

Ստորև ձեռնարկում նկարագրած է տվյալների աղբյուրում նոր սյուներ ավելացնելու քայլերը։  
Նոր պարամետրեր ավելացնելու համար [տե՛ս](ds_extender_param_guide.md)։  
Ընդլայնումը դիտելու ձևում օգտագործման համար [տե՛ս](view_guide.md):  

Տվյալների աղբյուրի ընդլայնման համար անհրաժեշտ է ստեղծել `DSEXTENDER` նկարագրությունը .as ֆայլում և C# դասը .cs ֆայլերը, որոնք հետագայում հարկավոր կլինի ներմուծել համակարգ SYSCON-ի միջոցով։

## .as ֆայլի ստեղծում

Յուրաքանչյուր ընդլայնման համար, պրոյեկտի ներքո անհրաժեշտ է ստեղծել .as ֆայլ։ 
Տվյալ ֆայլում պետք է նկարագրված լինի տվյալների աղբյուրին վերաբերվող տվյալները։

``` as4x
DSEXTENDER {
  NAME = AgrTotlC3Artonyal;
  CAPTION = "Պայմանագրերի ամփոփում";
  ECAPTION = "Summary of Agreements";
  DATASOURCE = "AGRSINFO";
  CSSOURCE = AgrTotlC3Artonyal.cs;
}; 
```

Որտեղ`
- NAME - Ընդլայնման ներքին ունիկալ անունը, պետք է համընկնի ընդլայնող դասի (class) անվան հետ,
- CAPTION - Ընդլայնման հայերեն անվանումը ANSI կոդավորմամբ,
- ECaption - Ընդլայնման անգլերեն անվանումը,
- DATASOURCE - Տվյալների աղբյուրի անուն,
- CSSOURCE - .cs ֆայլի անվանում։

## .cs ֆայլի ստեղծում

Տվյալների աղբյուրի տրամաբանությունը անհրաժեշտ է նկարագրել C#-ով համապատասխան .cs ֆայլում։  
.cs ֆայլում հարկավոր է ստեղծել դաս, որը ժառանգվում է `Extender<R, P>` դասից։  
Որպես `R` փոխանցել ընդլայնվող սյուները նկարագրող դասը, իսկ որպես `P`՝ ընդլայնվող պարամետրերը նկարագրող դասը։  
Եթե ընդլայնումը չի ավելացնում նոր պարամետրեր, ապա որպես `P` անհրաժեշտ է փոխանցել `NoParam` դասը։  
Իսկ եթե ընդլայնումը չի ավելացնում նոր սյուններ, ապա որպես `R` անհրաժեշտ է փոխանցել `NoColumns` դասը։  
Հարկավոր է նաև ավելացնել `[DataSourceExtender]` ատրիբուտը։ Օրինակ՝ 

``` cs
[DataSourceExtender]
public class AgrsInfoC3Artonyal : Extender<AgrsInfoC3Artonyal.DataRow, NoParam>
```

Ընդլայնվող սյունակները հարկավոր է սահմանել երկու տեղ
1. Նոր դաս, որը պարունակում է ընդլայնվող սյունակները որպես հատկություններ  (Օրինակում DataRow)

``` cs
public class DataRow
{
    public string NominalPercent { get; set; }
    public string EffectivePercent { get; set; }
    public string ActualPercent { get; set; }
}
```

2. Ընդլայնող դասի կոնստրուկտորի մեջ՝ [AddColumn](ds_extender.md#addcolumn) ֆունկցիայի միջոցով։

``` cs
public AgrsInfoC3Artonyal()
{
    AddColumn(nameof(DataRow.NominalPercent), "Անվանական տոկոսադրույք ըստ նշումի".ToArmenianANSI(), "Nominal interest rate as per note", FieldTypeProvider.GetNumericPositiveFieldType(9,4));
    AddColumn(nameof(DataRow.EffectivePercent), "Արդյունավետ տոկոսադրույք ըստ նշումի".ToArmenianANSI(), "Effective rate as per note", FieldTypeProvider.GetNumericPositiveFieldType(9,4));
    AddColumn(nameof(DataRow.ActualPercent), "Փաստացի տոկոսադրույք ըստ նշումի".ToArmenianANSI(), "Actual rate as per note", FieldTypeProvider.GetNumericPositiveFieldType(9, 4));
}
```

Ֆունկցիային հարկավոր է փոխանցել հետևյալ արժեքները՝
- Սյան ներքին անուն՝ կոդ (նույնանուն հատկության պետք է լինի ստեղծված DataRow դասը մեջ),
- Անվանումը հայրեն ANSI կոդավորմամբ (կարելի է գրել Unicode և օգտագործել ToArmenianANSI() ֆունկցիան),
- Անվանումը անգլերեն,
- Դաշտի տիպը։

### ProccessRow ֆունկցիա

Ընդլայնված սյունակների հաշվարկը հարկավոր է կատարել [ProccessRow](ds_extender.md#proccessrow) ֆունկցիայի մեջ, որը կանչվում է յուրաքանչյուր տողի համար։

Ստորև օրինակում
- ստանում է պայմանագրի ամփոփման տողը,
- ստեղծում է տողի ընդլայնման դասի օրինակ (`extendColumn`),
- պարզագույն ձևով հաշվում է `NominalPercent` ընդլայնված սյան արժեքը,
- ընթացիկ տողի ընդլայնող հատկությանը (`row.Extend`) վերագրում է ստեղծված օբյեկտը,
- վերջում ֆունկցիան վերադարձնում է `true` արժեքը, որպեսզի ընթացիկ տողը ընդգրկվի վերջնական ցուցակում։

``` cs
public override Task<bool> ProccessRow(IExtendableRow row, IDataSourceArgs args)
{
    var dsRow = (AGRSINFO.DataRow)row;
    var extendColumn = new DataRow();

    extendColumn.NominalPercent = $"{dsRow.fNOTE.Trim()} %";

    row.Extend = extendColumn;
    return Task.FromResult<bool>(true);
}
```

**Ուշադրություն**, Ընթացիկ տողի ստացման համար հարկավոր է իմանալ համապատասխան տվյալների աղբյուրի տողի տիպը (այստեղ `AGRSINFO.DataRow`)։ Այն հնարավոր է իմանալ միայն 8X սերվիսի պրոյեկտը ուսումնասիրելով։

### BeforeProcess ֆունկցիա

Եթե ինչ-որ տվյալներ հարկավոր է հաշվարկել և քեշավորել նախքան [ProccessRow](ds_extender.md#proccessrow)-ի աշխատանքը, ապա հարկավոր է մշակել [BeforeProcess](ds_extender.md#beforeprocess) ֆունկցիան։ 
Տվյալ ֆունկցիան օգտագործվում է նաև կամայական տողի ձևափոխման համար։

``` cs
public override Task BeforeProcess(IList<IExtendableRow> rows, IDataSourceArgs args)
```

Տվյալ օրինակում քեշավորվել են ծառի էլեմենտները և հետո օգտագործվել [ProccessRow](ds_extender.md#proccessrow) ֆունկցիայում։

``` cs
private Dictionary<string, TreeElement> noteElements;
public override async Task BeforeProcess(IList<IExtendableRow> rows, IDataSourceArgs args)
{
    noteElements = await treeElementService.GetTreeElements("C1NOTE");
}
public override Task<bool> ProccessRow(IExtendableRow row, IDataSourceArgs args)
{
    var dsRow = (AGRSINFO.DataRow)row;
    var extendColumn = new DataRow();

    extendColumn.NoteName = noteElements[dsRow.fNOTE.Trim()].Comment;

    row.Extend = extendColumn;
    return Task.FromResult<bool>(true);
}
```

## Ներմուծում և օգտագործում

.as և .cs ֆայլերը պատրաստ լինելուն պես անհրաժեշտ է **SYSCON**-ով համապատասխան .as ֆայլը ներմուծել համակարգ, ինչի արդյունքում .cs ֆայլը նույնպես կներմուծվի։ 

ֆայլերը ներմուծելուց հետո ընլայնումը օգտագործելու համար հարկավոր է այն [կարգավորել դիտելու ձևում](view_guide.md)։
