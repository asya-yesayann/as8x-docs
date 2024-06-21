
# Codegen : 4x-ական նկարագրությունների տեղափոխման մասնակի ավտոմատացում

`Codegen` գործիքը նախատեսված է 4x-ում նկարագրված տվյալների աղբյուրների և փաստաթղթերի նկարագրությունների 8x համակարգ տեղափոխումը մասնակի ավտոմատացնելու համար։ Այն հնարավորություն է տալիս 8x տեղափոխել համակարգային նկարագրությունների միայն նկարագրման հատվածը (Definition), սկրիպտային բաժնի տեղափոխումը ավտոմատացված չէ։

## Նախապատրաստական քայլեր

 - Տեղադրել VS-ը։
 - Աշխատացնել  …\AS-8X\bin թղթապանակի ArmSoft.AS8X.CodeGen.bat Ֆայլը `Run as administrator` հրամանով, որը ռեգիստրացնում է CodeGen գործիքի աշխատանքի համար անհրաժեշտ dll-ները։
 - Այն պրոյեկտում, որտեղ կիրառվելու է Codegen-ը, անհրաժեշտ է ավելացնել CodeGen.xml անունով ֆայլ՝ գրելով տեղափոխվող սկրիպտերի թղթապանակի հարաբերական ճանապարհը CodeGen.xml-ը պարունակող պրոյեկտի ճանապարհի նկատմամբ։

Օրինակ՝

```xml
<?xml version="1.0" encoding="utf-8" ?>
<Configuration>
  <ScriptsPath>..\..\Scripts</ScriptsPath>
</Configuration>
```

> [!IMPORTANT]
> Codegen-ը աշխատում է .tt ընդլայնմամբ ֆայլերի միջոցով և աշխատանքի արդյունքում գեներացնում է .cs ընդլայնմամբ ֆայլ։

## Նկարագրությունը տեղափոխելու համար անհրաժեշտ ընդհանուր քայլեր

 - Ստեղծել .tt ընդլայնմամբ ֆայլ հետևյալ ձևով՝ Add -> New Item -> Text Template։ Նախընտրելի  է ֆայլի անունը դնել հետևյալ ֆորմատի՝ GeneratedDSClassName.Codegen.tt՝ նկարագրության սկրիպտային բաժինը և նկարագրման բաժինը նկարագրող դասերի [ներդրվածությունը](https://learn.microsoft.com/en-us/visualstudio/ide/file-nesting-solution-explorer?view=vs-2022) ապահովելու համար։
 - Ստեղծված ֆայլի հատկությունների Custom tool դաշտի արժեքը դնել TextTemplatingFileGenerator հետևյալ ձևով՝ Right-click the file → Properties → Custom Tool: TextTemplatingFileGenerator:
 -  Ֆայլում ավելացնել հետևյալ տեքստը՝
  
```txt
<#@ template debug="false" hostspecific="true" language="C#" #>
<#@ assembly name="ArmSoft.AS8X.CodeGen" #>
<#@ import namespace="ArmSoft.AS8X.CodeGen" #>
<#@ output extension=".cs" #>
```

## Տվյալների աղբյուրի նկարագրությունը տեղափոխելու համար անհրաժեշտ քայլեր

Վերևում նշված [նախապատրաստական](https://github.com/armsoft/as8x-docs/blob/main/src/server_api/codegen.md#%D5%B6%D5%A1%D5%AD%D5%A1%D5%BA%D5%A1%D5%BF%D6%80%D5%A1%D5%BD%D5%BF%D5%A1%D5%AF%D5%A1%D5%B6-%D6%84%D5%A1%D5%B5%D5%AC%D5%A5%D6%80) և [ընդհանուր](https://github.com/armsoft/as8x-docs/blob/main/src/server_api/codegen.md#%D5%B6%D5%AF%D5%A1%D6%80%D5%A1%D5%A3%D6%80%D5%B8%D6%82%D5%A9%D5%B5%D5%B8%D6%82%D5%B6%D5%A8-%D5%BF%D5%A5%D5%B2%D5%A1%D6%83%D5%B8%D5%AD%D5%A5%D5%AC%D5%B8%D6%82-%D5%B0%D5%A1%D5%B4%D5%A1%D6%80-%D5%A1%D5%B6%D5%B0%D6%80%D5%A1%D5%AA%D5%A5%D5%B7%D5%BF-%D5%A8%D5%B6%D5%A4%D5%B0%D5%A1%D5%B6%D5%B8%D6%82%D6%80-%D6%84%D5%A1%D5%B5%D5%AC%D5%A5%D6%80) քայլերի կատարումից հետո .tt ընդլայնմամբ ֆայլում անհրաժեշտ է ավելացնել [DSParser](https://github.com/armsoft/as8x-docs/blob/main/src/server_api/DSParser.md#dsparser) static դասի [Parse](https://github.com/armsoft/as8x-docs/blob/main/src/server_api/DSParser.md#parse) մեթոդի կանչը, որը գեներացնում է տվյալների աղբյուրի 4x-ական նկարագրությանը համարժեք 8x-ական դասը։ 

Օրինակ՝ 
```c#
<#
string code = DSParser.Parse(configFilePath: this.Host.ResolvePath(@"..\..\CodeGen.xml"),
                             filename: @"\PAYMENT\DOC\PaySys.as",
			     dsName: "OBACSOPT",
			     namespaceName: "Bank.BankSettings.DS",
			     className: "AllowableForbiddenAccessTypes");
#>
<#= code #>
```
                                                                                       
## Փաստաթղթի նկարագրությունը տեղափոխելու համար անհրաժեշտ քայլեր

4x համակարգում գոյություն ունի փաստաթուղթը նկարագրող մեկ դաս, որը ծառայում է և՛ կլիենտական և՛ սերվերային նպատակներով:
8x համակարգում սերվերային և կլիենտական ֆունկցիոնալությունները առանձնացված են և յուրաքանչյուրի համար սահմանված է առանձին դաս։

- ## Փաստաթղթի սերվերային նկարագրության տեղափոխում

Վերևում նշված [նախապատրաստական](https://github.com/armsoft/as8x-docs/blob/main/src/server_api/codegen.md#%D5%B6%D5%A1%D5%AD%D5%A1%D5%BA%D5%A1%D5%BF%D6%80%D5%A1%D5%BD%D5%BF%D5%A1%D5%AF%D5%A1%D5%B6-%D6%84%D5%A1%D5%B5%D5%AC%D5%A5%D6%80) և [ընդհանուր](https://github.com/armsoft/as8x-docs/blob/main/src/server_api/codegen.md#%D5%B6%D5%AF%D5%A1%D6%80%D5%A1%D5%A3%D6%80%D5%B8%D6%82%D5%A9%D5%B5%D5%B8%D6%82%D5%B6%D5%A8-%D5%BF%D5%A5%D5%B2%D5%A1%D6%83%D5%B8%D5%AD%D5%A5%D5%AC%D5%B8%D6%82-%D5%B0%D5%A1%D5%B4%D5%A1%D6%80-%D5%A1%D5%B6%D5%B0%D6%80%D5%A1%D5%AA%D5%A5%D5%B7%D5%BF-%D5%A8%D5%B6%D5%A4%D5%B0%D5%A1%D5%B6%D5%B8%D6%82%D6%80-%D6%84%D5%A1%D5%B5%D5%AC%D5%A5%D6%80) քայլերի կատարումից հետո .tt ընդլայնմամբ ֆայլում անհրաժեշտ է ավելացնել [DocParser](https://github.com/armsoft/as8x-docs/blob/main/src/server_api/DocParser.md#docparser) static դասի [Parse](https://github.com/armsoft/as8x-docs/blob/main/src/server_api/DocParser.md#parse) մեթոդի կանչը, որը գեներացնում է փաստաթղթի 4x-ական նկարագրությանը համարժեք 8x-ական դասը։ 

Օրինակ՝ 
``` c#
<#
string code = DocParser.Parse(configFilePath: this.Host.ResolvePath(@"..\..\CodeGen.xml"),
			      filename: @"\SOURCE\Agreement\Contracts.as",
			      docType: "CnCont",
			      namespaceName: "Enterprise.Doc.Agreement",
			      className: "Contract",
                              generateFieldAccessor: true,
			      parentClass: "EnterpriseWagesDocument");
#>
<#= code #>
```

- ##  .as ընդլայմամբ ֆայլի մեջ գտնվող բոլոր փաստաթղթերի սերվերային նկարագրությունների տեղափոխում

Վերևում նշված [նախապատրաստական](https://github.com/armsoft/as8x-docs/blob/main/src/server_api/codegen.md#%D5%B6%D5%A1%D5%AD%D5%A1%D5%BA%D5%A1%D5%BF%D6%80%D5%A1%D5%BD%D5%BF%D5%A1%D5%AF%D5%A1%D5%B6-%D6%84%D5%A1%D5%B5%D5%AC%D5%A5%D6%80) և [ընդհանուր](https://github.com/armsoft/as8x-docs/blob/main/src/server_api/codegen.md#%D5%B6%D5%AF%D5%A1%D6%80%D5%A1%D5%A3%D6%80%D5%B8%D6%82%D5%A9%D5%B5%D5%B8%D6%82%D5%B6%D5%A8-%D5%BF%D5%A5%D5%B2%D5%A1%D6%83%D5%B8%D5%AD%D5%A5%D5%AC%D5%B8%D6%82-%D5%B0%D5%A1%D5%B4%D5%A1%D6%80-%D5%A1%D5%B6%D5%B0%D6%80%D5%A1%D5%AA%D5%A5%D5%B7%D5%BF-%D5%A8%D5%B6%D5%A4%D5%B0%D5%A1%D5%B6%D5%B8%D6%82%D6%80-%D6%84%D5%A1%D5%B5%D5%AC%D5%A5%D6%80) քայլերի կատարումից հետո .tt ընդլայնմամբ ֆայլում անհրաժեշտ է ավելացնել [DocParser](https://github.com/armsoft/as8x-docs/blob/main/src/server_api/DocParser.md#docparser) static դասի [ParseAll](https://github.com/armsoft/as8x-docs/blob/main/src/server_api/DocParser.md#parseall) մեթոդի կանչը, որը գեներացնում է .as ֆայլում գտնվող բոլոր փաստաթղթերի 4x-ական նկարագրություններին համարժեք 8x-ական դասերը։ 

Օրինակ՝ 
``` c#
<#
string code = DocParser.ParseAll(configFilePath: this.Host.ResolvePath(@"..\..\CodeGen.xml"),
				filename: @"\SOURCE\Agreement\Contracts.as",
				namespaceName: "Enterprise.Doc.Agreement");
#>
<#= code #>
```

Ի տարբերություն DocParser դասի Parse մեթոդի, այս մեթոդում չենք կարող նշել գեներացվող դասերի անունները, գեներացվող դասերը ունենալու են 4x-ական փաստաթղթերի անունները: Նաև չենք կարող նշել այն դասը, որից ժառանգելու են գեներացվող դասերը, բոլորը ժառանգվելու են Document դասից։

## Փաստաթղթի կլիենտական նկարագրության տեղափոխում

Վերևում նշված [նախապատրաստական](https://github.com/armsoft/as8x-docs/blob/main/src/server_api/codegen.md#%D5%B6%D5%A1%D5%AD%D5%A1%D5%BA%D5%A1%D5%BF%D6%80%D5%A1%D5%BD%D5%BF%D5%A1%D5%AF%D5%A1%D5%B6-%D6%84%D5%A1%D5%B5%D5%AC%D5%A5%D6%80) և [ընդհանուր](https://github.com/armsoft/as8x-docs/blob/main/src/server_api/codegen.md#%D5%B6%D5%AF%D5%A1%D6%80%D5%A1%D5%A3%D6%80%D5%B8%D6%82%D5%A9%D5%B5%D5%B8%D6%82%D5%B6%D5%A8-%D5%BF%D5%A5%D5%B2%D5%A1%D6%83%D5%B8%D5%AD%D5%A5%D5%AC%D5%B8%D6%82-%D5%B0%D5%A1%D5%B4%D5%A1%D6%80-%D5%A1%D5%B6%D5%B0%D6%80%D5%A1%D5%AA%D5%A5%D5%B7%D5%BF-%D5%A8%D5%B6%D5%A4%D5%B0%D5%A1%D5%B6%D5%B8%D6%82%D6%80-%D6%84%D5%A1%D5%B5%D5%AC%D5%A5%D6%80) քայլերի կատարումից հետո .tt ընդլայնմամբ ֆայլում անհրաժեշտ է ավելացնել [DocParser](https://github.com/armsoft/as8x-docs/blob/main/src/server_api/DocParser.md#docparser) static դասի [ParseClient](https://github.com/armsoft/as8x-docs/blob/main/src/server_api/DocParser.md#parseclient) մեթոդի կանչը, որը գեներացնում է փաստաթղթի 4x-ական նկարագրությանը համարժեք 8x-ական դասը։ 

Օրինակ՝ 
```c#
<#    
string code = DocParser.ParseClient(configFilePath: this.Host.ResolvePath(@"..\..\CodeGen.xml"),
                              	   filename: @"\SOURCE\Agreement\Contracts.as",
                                   docType: "CnCont",
                                   namespaceName: "Enterprise.Client.Doc.Agreement",
			           className: "Contract");   
#>
<#= code #>
```

## .as ընդլայմամբ ֆայլի մեջ գտնվող բոլոր փաստաթղթերի կլիենտական նկարագրությունների տեղափոխում

Վերևում նշված [նախապատրաստական](https://github.com/armsoft/as8x-docs/blob/main/src/server_api/codegen.md#%D5%B6%D5%A1%D5%AD%D5%A1%D5%BA%D5%A1%D5%BF%D6%80%D5%A1%D5%BD%D5%BF%D5%A1%D5%AF%D5%A1%D5%B6-%D6%84%D5%A1%D5%B5%D5%AC%D5%A5%D6%80) և [ընդհանուր](https://github.com/armsoft/as8x-docs/blob/main/src/server_api/codegen.md#%D5%B6%D5%AF%D5%A1%D6%80%D5%A1%D5%A3%D6%80%D5%B8%D6%82%D5%A9%D5%B5%D5%B8%D6%82%D5%B6%D5%A8-%D5%BF%D5%A5%D5%B2%D5%A1%D6%83%D5%B8%D5%AD%D5%A5%D5%AC%D5%B8%D6%82-%D5%B0%D5%A1%D5%B4%D5%A1%D6%80-%D5%A1%D5%B6%D5%B0%D6%80%D5%A1%D5%AA%D5%A5%D5%B7%D5%BF-%D5%A8%D5%B6%D5%A4%D5%B0%D5%A1%D5%B6%D5%B8%D6%82%D6%80-%D6%84%D5%A1%D5%B5%D5%AC%D5%A5%D6%80) քայլերի կատարումից հետո .tt ընդլայնմամբ ֆայլում անհրաժեշտ է ավելացնել [DocParser](https://github.com/armsoft/as8x-docs/blob/main/src/server_api/DocParser.md#docparser) static դասի [ParseClientAll](https://github.com/armsoft/as8x-docs/blob/main/src/server_api/DocParser.md#parseclientall) մեթոդի կանչը, որը գեներացնում է .as ֆայլում գտնվող բոլոր փաստաթղթերի 4x-ական նկարագրություններին համարժեք 8x-ական դասերը։ 

Օրինակ՝ 
```c#
<#
string code = DocParser.ParseClientAll(configFilePath: this.Host.ResolvePath(@"..\..\CodeGen.xml"),
				       filename: @"\SOURCE\Agreement\Contracts.as",
                                       namespaceName: "Enterprise.Client.Doc.Agreement");    
#>
<#= code #>
```
