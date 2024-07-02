---
layout: page
title: "Տվյալների աղբյուր ընդլայնման ձեռնարկ" 
---

# Տվյալների աղբյուրի ընդլայնում 8X-ում

Տվյալների աղբյուրի ընդլայնման համար անհրաժեշտ է ստեղծել համապատասխան .as և .cs ֆայլերը, որոնք հետագայում հարկավոր կլինի ներմուծել համակարգ SYSCON-ի միջոցով։

## .as ֆայլերի ստեղծում

Յուրաքանչյուր ընդլայնման համար, պրոյեկտի ներքո անհրաժեշտ է ստեղծել .as ֆայլ։ Տվյալ ֆայլում պետք է նկարագրված լինի տվյալների աղբյուրին վերաբերվող տվյալները։

``` cs
COMMENT {
};
DSEXTENDER {
    NAME = AgrTotlC3Artonyal;
    CAPTION = "Պայմանագրերի ամփոփում";
    ECAPTION = "Summary of Agreements";
    DATASOURCE = "AGRSINFO";
    CSSOURCE = AgrTotlC3Artonyal.cs;
}; 
```
Որտեղ՝
- NAME - Դիտելու ձևի class-ի անուն;
- CAPTION - Ընդլահնման անվանում - հարկավոր է լրացնել ANSI ստանդարտով;
- ECaption - Ընդլահնման անվանում - անգլերենով;
- DATASOURCE - Տվյալների աղբյուրի անուն;
- CSSOURCE - .cs ֆայլի անվանում;

## .cs ֆայլերի ստեղծում

Տվյալների աղբյուրի տրամաբանությունը անհրաժեշտ է նկարագրել C#-ով համապատասխան .cs ֆայլում։
.cs ֆայլում հարկավոր է ստեղծել ```class```, որը ժառանգում է ```Extender<R, P>``` դասը՝ որպես R փոխանցելով տվյալների աղբյուրի սյուները նկարագրող դասը, իսկ որպես P՝ պարամետրերը նկարագրող դասը։ Եթե տվյալների աղբյուրը չի պարունակում պարամետրեր, ապա որպես P անհրաժեշտ է փոխանցել NoParam դասը։ Հարկավոր է նաև ավելացնել ```[DataSourceExtender]``` ատրիբուտը։ Օրինակ՝ 

```cs
[DataSourceExtender]
public class AgrsInfoC3Artonyal : Extender<AgrsInfoC3Artonyal.DataRow, NoParam>
```
Ընդլայնվող սյունակները հարկավոր է սահմանել երկու տեղ
1. Նոր class, որը պարունակում է ընդլայնվող սյունակները որպես հատկություններ  (Օրինակում DataRow)

``` cs
public class DataRow
{
    public string NominalPercent { get; set; }
    public string EffectivePercent { get; set; }
    public string ActualPercent { get; set; }
}
```
2. Ընդլայնող դասի կոնստրուկտորի մեջ՝ ```AddColumn``` ֆունկցիայի միջոցով։
``` cs
public AgrsInfoC3Artonyal()
{
    AddColumn(nameof(DataRow.NominalPercent), "Անվանական տոկոսադրույք ըստ նշումի".ToArmenianANSI(), "Nominal interest rate as per note", FieldTypeProvider.GetNumericPositiveFieldType(9,4));
    AddColumn(nameof(DataRow.EffectivePercent), "Արդյունավետ տոկոսադրույք ըստ նշումի".ToArmenianANSI(), "Effective rate as per note", FieldTypeProvider.GetNumericPositiveFieldType(9,4));
    AddColumn(nameof(DataRow.ActualPercent), "Փաստացի տոկոսադրույք ըստ նշումի".ToArmenianANSI(), "Actual rate as per note", FieldTypeProvider.GetNumericPositiveFieldType(9, 4));
}
```
AddColumn ֆունկցիային հարկավոր է փոխանցել հետևյալ արժեքները՝
- Սյան ներքին անուն (կոդ)
- Անվանումը հայրեն ANSI ստանդարտով (կարելի է գրել Unicode և օգտագործել ToArmenianANSI() ֆունկցիան)
- Անվանումը անգլերեն
- Դաշտի տեսակը

Տվյալների աղբյուրի պարամետրերը նկարագրող դասը սահմանվում է ընդլայնվող սյունյակների նման։ Նախ հայտարարում ենք նոր ```class``` և ավելացնում ընդլայնող դասի կոնստրուկտորի մեջ` ```AddColumn``` ֆունկցիայի միջոցով։
```cs
public class Param
{
    public string CliCode { get; set; }
}
```
### ProcessRow ֆունկցիա
Ընդլայնված սյունյակների հաշվարկը հարկավոր է կատարել ```ProccessRow``` ֆունկցիայի մեջ, որը կանչվում է յուրաքանչյուր տողի համար։
Տվյալ օրինակում ստանալով պայմանագրի սյուները տվյալների աղբյուրից, վերագրում ենք նշում դաշտը ```fNOTE``` նոր ընդլայնված սյանը ```extendColumn.NominalPercent```։

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
Հարկավոր է վերջում ընդլայնված սյունը վերագրել տվյալների աղբյուրին` ```row.Extend = extendColumn```։

**Ուշադրություն**, որպեսզի ընթացիկ տողը ցուցադրվի ընդլայնման վերջնական տեսքի մեջ, հարկավոր է ```return Task.FromResult<bool>(true);``` տողում տալ ```true``` արժեքը, հակառակ դեպքում, եթե արժեքը դնենք ```false``` տվյալ տողերը չեն ցուցադրվի։

### BeforeProcess ֆունկցիա
Եթե ինչ որ տվյալներ հարկավոր է հաշվարկել և քեշավորել նախքան ```ProccessRow```, հարկավոր է մշակել ```BeforeProcess``` ֆունկցիան։ Տվյալ ֆունկցիան օգտագործվում է նաև կամայական տողի ձևափոխման համար։
``` cs
public override Task BeforeProcess(IList<IExtendableRow> rows, IDataSourceArgs args)
```

Տվյալ օրինակում քեշավորվել են ծառի էլեմենտները և հետո օգտագործվել ```override ProccessRow``` ֆունկցիայում

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


.as և .cs ֆայլերը պատրաստ լինելուն պես անհրաժեշտ է **SYSCON**-ով համապատասխան .as ֆայլը ներմուծել համակարգ, ինչի արդյունքում .cs ֆայլը նույնպես կներմուծվի։ 

[Տվյալների աղբյուր նկարագրություն](ds_extender.md)


