---
layout: page
title: "DocParser դաս: Փաստաթղթերի 8X տեղափոխման մասնակի ավտոմատացում"
tags: [CodeGen, DocParser]
---

Բովանդակություն
* [DocParser](#docparser)
* [Մեթոդներ](#մեթոդներ)
  * [Parse](#parse)
  * [ParseClient](#parseclient)
  * [ParseAll](#parseall)
  * [ParseClientAll](#parseclientall)
* [DocGeneratorOptions](#docgeneratoroptions)
  * [Օրինակներ](#օրինակներ)

## DocParser

```c#
public static class DocParser
```

DocParser դասը նախատեսված է 4X-ում նկարագրված փաստաթղթերի նկարագրությունների նկարագրման հատվածը (Definition) 8X տեղափոխելու համար։
Օգտագործվում է Text Template գործիքի մեջ։  
Օգտագործման համար տե՛ս [CodeGen : 4X նկարագրությունների տեղափոխման մասնակի ավտոմատացում](/src/server_api/CodeGen/CodeGen.md)։


## Մեթոդներ

### Parse

```c#
public static string Parse(
    string configFilePath, 
    string filename, 
    string docType, 
    string namespaceName, 
    string className = "",
    string conditionalCompilationList = "", 
    DocGeneratorOptions options = null, 
    string parentClass = "",
    bool generateFieldAccessor = false, 
    bool uppercaseAll = false)
```

Մեթոդը գեներացնում է փաստաթղթի 4X-ական նկարագրությանը համարժեք 8X-ական դասը, որը պարունակում է փաստաթղթի սերվերային նկարագրությունը։

Պարամետրեր

- `configFilePath`  
  CodeGen.xml-ի ամբողջական ճանապարհը։  
  Սովորաբար կանչը փոխանցվում է հետևյալ ձևով՝ `this.Host.ResolvePath(@"..\..\CodeGen.xml")`, որտեղ ResolvePath ֆունկցիային տրված է CodeGen.xml-ի հարաբերական ճանապարհը ընթացիկ `.tt` ֆայլի նկատմամբ։

- `filename`  
  Փաստաթուղթը պարունակող `.as` ընդլայնմամբ ֆայլի հարաբերական ճանապարհը CodeGen.xml-ում նշված սկրիպտերի թղթապանակի նկատմամբ            

- `docType`  
  Փաստաթղթի ներքին անունը։    

- `namespaceName`  
  Գեներացվող դասի namespace-ի վերջին հատվածը (namespace-ի սկիզբը միշտ `ArmSoft.AS8X.` է)։

- `className`  
  Գեներացվող դասի անունը։ Չլրացնելու դեպքում համընկնելու է փաստաթղթի տեսակի  անվանման հետ՝ `docType`:

- `conditionalCompilationList`  
  փաստաթղթեր ընդհանուր են մի քանի համակարգերի համար և տարբերվում են միայն գտնվելու տեղով՝ namespace-ով։ 
  Նույն դասը 2 տեղ չգրելու համար անհրաժեշտ է այն տեղադրել Tfs-ում ընդհանուր հասանելիության թղթապանակում և լինկով միացնել անհրաժեշտ պրոյեկտներում, իսկ `conditionalCompilationList`-ում գրել այն պրոյեկտների անվանումները, որոնց լինկով միացվելու է դասը։ 
  Պրոյեկտների անունները  անհրաժեշտ է իրարից անջատել ստորակետերով։

- `options`  
  Այս հատկությունը հնարավորություն է տալիս վերանվանել փաստաթղթի ռեկվիզիտների ու գրիդի սյուների անունները։

- `parentClass`  
  Գեներացվող փաստաթղթի ծնող դասը, որը պետք է ժառանգ լինի Document դասից։ 
  Չլրացնելու դեպքում ծնող դաս է հանդիսանալու Document դասը։

- `generateFieldAccessor`  
  Ցույց է տալիս թե գեներացվող փաստաթղթի դաշտերը լինեն C#-ի ներդրված տիպերի թե `DocumentFieldAccessor<T>` տիպի, որտեղ որպես T անհրաժեշտ է լրացնել դաշտի համակարգային տիպին համապատասխան C#-ի ներդրված տիպը։

- `uppercaseAll`  
  Ցույց է տալիս թե գեներացվող դասի բոլոր էլեմենտների(ռեկվիզիտ, մեմո, աղյուսակի սյուն, …) անունները լինեն գեներացվեն ամբողջությամբ մեծատառ թե ոչ։ 
  Չլրացնելու դեպքում էլեմենտների անունները համընկնում են 4x-ի էլեմենտների անունների հետ։


### ParseClient

```c#
public static string ParseClient(
    string configFilePath, 
    string filename, 
    string docType, 
    string namespaceName, 
    string className = "",
    string conditionalCompilationList = "", 
    DocGeneratorOptions options = null, 
    string parentClass = "")
```

Մեթոդը գեներացնում է փաստաթղթի 4X-ական նկարագրությանը համարժեք 8X-ական դասը, որը պարունակում է փաստաթղթի կլիենտական նկարագրությունը։

Պարամետրեր

- `configFilePath`  
  CodeGen.xml-ի ամբողջական ճանապարհը։  
  Սովորաբար կանչը փոխանցվում է հետևյալ ձևով՝ `this.Host.ResolvePath(@"..\..\CodeGen.xml")`, որտեղ ResolvePath ֆունկցիային տրված է CodeGen.xml-ի հարաբերական ճանապարհը ընթացիկ `.tt` ֆայլի նկատմամբ։

- `filename`  
  Փաստաթուղթը պարունակող `.as` ընդլայնմամբ ֆայլի հարաբերական ճանապարհը CodeGen.xml-ում նշված սկրիպտերի թղթապանակի նկատմամբ։

- `docType`  
  Փաստաթղթի ներքին անունը։

- `namespaceName`  
  Գեներացվող դասի namespace-ի վերջին հատվածը (namespace-ի սկիզբը միշտ `ArmSoft.AS8X.` է)։

- `className`  
  Գեներացվող դասի անունը։ 
  Չլրացնելու դեպքում համընկնելու է փաստաթղթի տեսակի անվանման հետ՝ `docType`։

- `conditionalCompilationList`  
  Որոշ փաստաթղթեր ընդհանուր են մի քանի համակարգերի համար և տարբերվում են միայն գտնվելու տեղով՝ namespace-ով։ 
  Նույն դասը 2 տեղ չգրելու համար անհրաժեշտ է այն տեղադրել Tfs-ում ընդհանուր հասանելիության թղթապանակում և լինկով միացնել անհրաժեշտ պրոյեկտներում, իսկ `conditionalCompilationList`-ում գրել այն պրոյեկտների անվանումները, որոնց լինկով միացվելու է դասը։ 
  Պրոյեկտների անունները  անհրաժեշտ է իրարից անջատել ստորակետերով։

- `options`  
  Այս հատկությունը հնարավորություն է տալիս վերանվանել փաստաթղթի ռեկվիզիտների ու գրիդի սյուների անունները։

- `parentClass`  
  Գեներացվող փաստաթուղթի ծնող դասը, որը պետք է ժառանգ լինի Document դասից։ 
  Չլրացնելու դեպքում ծնող դաս է հանդիսանալու Document դասը։


### ParseAll

```c#
public static string ParseAll(
    string configFilePath, 
    string filename, 
    string namespaceName,
    string conditionalCompilationList = "", 
    Dictionary<string, DocGeneratorOptions> options = null,
    bool generateFieldAccessor = false, 
    bool uppercaseAll = false)
```

Մեթոդը գեներացնում է `.as` ֆայլում գտնվող բոլոր փաստաթղթերի 4X-ական նկարագրություններին համարժեք 8X-ական դասերը, որոնք պարունակում են փաստաթղթերի սերվերային նկարագրությունները։

Պարամետրեր

- `configFilePath`  
  CodeGen.xml-ի ամբողջական ճանապարհը։  
  Սովորաբար կանչը փոխանցվում է հետևյալ ձևով՝ `this.Host.ResolvePath(@"..\..\CodeGen.xml")`, որտեղ ResolvePath ֆունկցիային տրված է CodeGen.xml-ի հարաբերական ճանապարհը ընթացիկ `.tt` ֆայլի նկատմամբ։

- `filename`  
  Փաստաթղթերը պարունակող `.as` ընդլայնմամբ ֆայլի հարաբերական ճանապարհը CodeGen.xml-ում նշված սկրիպտերի թղթապանակի նկատմամբ։

- `namespaceName`  
  Գեներացվող դասերի namespace-ի վերջին հատվածը (namespace-ի սկիզբը միշտ `ArmSoft.AS8X.` է)։

- `conditionalCompilationList`  
  փաստաթղթեր ընդհանուր են մի քանի համակարգերի համար և տարբերվում են միայն գտնվելու տեղով՝ namespace-ով։ 
  Նույն դասը 2 տեղ չգրելու համար անհրաժեշտ է այն տեղադրել Tfs-ում ընդհանուր հասանելիության թղթապանակում և լինկով միացնել անհրաժեշտ պրոյեկտներում, իսկ `conditionalCompilationList`-ում գրել այն պրոյեկտների անվանումները, որոնց լինկով միացվելու է դասը։ 
  Պրոյեկտների անունները  անհրաժեշտ է իրարից անջատել ստորակետերով։

- `options`  
  Այս հատկությունը հնարավորություն է տալիս վերանվանել փաստաթղթի ռեկվիզիտների ու գրիդի սյուների անունները։

- `generateFieldAccessor`  
  Ցույց է տալիս թե գեներացվող փաստաթղթերի դաշտերը լինեն C#-ի ներդրված տիպերի թե DocumentFieldAccessor<T> տիպի, որտեղ որպես T դրվում է դաշտի համակարգային տիպին համապատասխան C#-ի ներդրված տիպը։

- `uppercaseAll`  
  Ցույց է տալիս թե գեներացվող դասերի բոլոր էլեմենտների(ռեկվիզիտ, մեմո, աղյուսակի սյուն, …) անունները լինեն գեներացվեն ամբողջությամբ մեծատառ թե ոչ։ 
  Չլրացնելու դեպքում էլեմենտների անունները համընկնում են 4X-ի էլեմենտների անունների հետ։


### ParseClientAll

```c#
public static string ParseClientAll(
    string configFilePath, 
    string filename, 
    string namespaceName,
    string conditionalCompilationList = "", 
    Dictionary<string, DocGeneratorOptions> options = null)
```

Մեթոդը գեներացնում է `.as` ֆայլում գտնվող բոլոր փաստաթղթերի 4X-ական նկարագրություններին համարժեք 8X-ական դասերը, որոնք պարունակում են փաստաթղթերի կլիենտական նկարագրությունները։

Պարամետրեր

- `configFilePath`  
  CodeGen.xml-ի ամբողջական ճանապարհը։  
  Սովորաբար կանչը փոխանցվում է հետևյալ ձևով՝ `this.Host.ResolvePath(@"..\..\CodeGen.xml")`, որտեղ ResolvePath ֆունկցիային տրված է CodeGen.xml-ի հարաբերական ճանապարհը ընթացիկ `.tt` ֆայլի նկատմամբ։

- `filename`  
  Փաստաթղթերը պարունակող `.as` ընդլայնմամբ ֆայլի հարաբերական ճանապարհը CodeGen.xml-ում նշված սկրիպտերի թղթապանակի նկատմամբ։

- `namespaceName`  
  Գեներացվող դասերի namespace-ի վերջին հատվածը (namespace-ի սկիզբը միշտ `ArmSoft.AS8X.` է)։

- `conditionalCompilationList`  
  Որոշ փաստաթղթեր ընդհանուր են մի քանի համակարգերի համար և տարբերվում են միայն գտնվելու տեղով՝ namespace-ով։ 
  Նույն դասը 2 տեղ չգրելու համար անհրաժեշտ է այն տեղադրել Tfs-ում ընդհանուր հասանելիության թղթապանակում և լինկով միացնել անհրաժեշտ պրոյեկտներում, իսկ `conditionalCompilationList`-ում գրել այն պրոյեկտների անվանումները, որոնց լինկով միացվելու է դասը։ 
  Պրոյեկտների անունները  անհրաժեշտ է իրարից անջատել ստորակետերով։

- `options`  
  Այս հատկությունը հնարավորություն է տալիս վերանվանել փաստաթղթի ռեկվիզիտների ու գրիդի սյուների անունները։

## DocGeneratorOptions

```c#
public class DocGeneratorOptions
{
    public string[] OverridableProperties { get; set; }

    public DocFieldGeneratorOptions[] Fields { get; set; } = new DocFieldGeneratorOptions[] { };
    public DocGridGeneratorOptions[] Grids { get; set; } = new DocGridGeneratorOptions[] { };
}

public class DocFieldGeneratorOptions
{
    public string Name { get; set; } = "";
    public string PropertyName { get; set; } = "";
}

public class DocGridGeneratorOptions
{
    public Dictionary<string, string> ColumnsPropertiesNames { get; set; }
    public bool IsUntypedGrid { get; set; } = false;

    public string Name { get; set; } = "";
    public bool ParameterizedConstructor { get; set; } = false;
}
```

### Օրինակներ

1. Ձևավոևվող փաստաթղթի C# դասում Payer դաշտին տրվում է նոր անուն՝ Receiver։
   ```tt
   var options = new DocGeneratorOptions()
   {
     Fields = new DocFieldGeneratorOptions[]
     {
       new DocFieldGeneratorOptions { Name = "Payer", PropertyName = "Receiver" }
     }
   };
   string code = DocParser.Parse(configFilePath: this.Host.ResolvePath(@"..\..\..\CodeGen.xml"),
                                 filename: @"\SOURCE\AutoPark\Directories\AutoFuel.as",
                                 docType: "AutoFuel",
                                 namespaceName: "Enterprise.Doc.AutoPark.Directories",
                                 options: options);
   ```
   արդյունքում ստացվում է
   ```c#
   [DocumentField("Payer")]
   /// <summary> Ստացող </summary>
   public string Receiver
   {
       get { return (string)this[nameof(this.Receiver)]; }
       set { this[nameof(this.Receiver)] = value; }
   }
   ```

2. Ձևավոևվող փաստաթղթի C# դասում MtList աղյուսակի Dogovor սյան տրվում է նոր անուն՝ Contract։
   ```tt
   var options = new DocGeneratorOptions()
   {
     Grids = new DocGridGeneratorOptions[]
     {
       new DocGridGeneratorOptions 
       { 
         Name = "MtList", 
         ColumnsPropertiesNames = new()
         {
           {"Dogovor", "Contract"}
         }
       }
     }
   };
   string code = DocParser.Parse(configFilePath:this.Host.ResolvePath(@"..\..\CodeGen.xml"),
                                 filename:@"\SOURCE\OnDeposit\DPExp.as",
                                 docType:"DPExp",
                                 namespaceName:"Enterprise.Doc.OnDeposit",
                                 options: options);
   ```

3. Ձևավոևվող փաստաթղթի C# դասին որպես ծնող դաս է տրվում ApTrBase, ապա երկու դաշտերի համար, որ սահմանված են ծնողում, նշվում է, որ դրանք override արված են
   ```tt
   var options = new DocGeneratorOptions()
   {
       OverridableProperties = new[]{ "TRANS", "CODE" }
   };
   string code = DocParser.Parse(
                               configFilePath: this.Host.ResolvePath(@"..\..\..\..\CodeGen.xml"), 
                               filename: @"\SubSystems\Docs\Applications\AppTransitions\ApTrClVl.as", 
                               docType: "ApTrClVl", 
                               namespaceName: "Bank.Subsystems.Docs.Applications",
                               className։ "ApTrClVl", 
                               options։ options, 
                               parentClass։ "ApTrBase");
   ```
   արդյունքում ստացվում է
   ```c#
   [Document("ApTrClVl")]
   public partial class ApTrClVl : ApTrBase
   {
     /// <summary> Անցման տեսակ </summary>
     public override string TRANS
     {
         get { return (string)this[nameof(this.TRANS)]; }
         set { this[nameof(this.TRANS)] = value; }
     }
     ...
   }
   ```