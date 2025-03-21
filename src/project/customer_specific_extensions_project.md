---
layout: page
title: "Կազմակերպության սեփական նկարագրությունները և ընդլայնումները պարունակող պրոյեկտի ստեղծում"
---

Ընդլայնումների և նկարագրությունների մշակումը հեշտացնելու համար C#-ի ֆայլերը կարելի է հավաքել մեկ պրոյեկտի մեջ։  
Պրոյեկտի կառուցվածքը տարբերվում է, երբ
- [Հասանելի են 8X սերվիսի պրոյեկտի կոդերը](#հասանելի-են-8x-սերվիսի-պրոյեկտի-կոդերը)
  - [ՀԾ-Բանկի ընդլայնման csproj-ի օրինակ](#հծ-բանկի-ընդլայնման-csproj-ի-օրինակ)
- [Հասանելի են 8X սերվիսի պրոյեկտի dll-ները](#հասանելի-են-8x-սերվիսի-պրոյեկտի-dll-ները)
  - [Պարտադիր dll-ներ](#պարտադիր-dll-ներ)
  - [Ոչ պարտադիր dll-ներ](#ոչ-պարտադիր-dll-ներ)
  - [ՀԾ-Բանկի ընդլայնման csproj-ի օրինակ](#հծ-բանկի-ընդլայնման-csproj-ի-օրինակ-1)

## Հասանելի են 8X սերվիսի պրոյեկտի կոդերը

Պրոյեկտի կոդերի բեռնումը [տե՛ս այստեղ](get_project.md)։

Պրոյեկտը անհրաժեշտ է ստեղծել հետևյալ քայլերով՝
* Պատճենել ՀԾ-Բանկի հիմնական լուծման ֆայլը (**ArmSoft.AS8X.Bank.sln**)։ 
* Լուծման մեջ ավելացնել նոր Class Library տիպի պրոյեկտ։ Ստեղծման եղանակին ծանոթանալու համար [տե'ս](https://learn.microsoft.com/en-us/dotnet/core/tutorials/library-with-visual-studio?create-a-class-library-project):
* TargetFramework-ի տարբերակը պետք է համընկնի կազմակերպությունում տեղադրված 8X սերվիսի տարբերակի TargetFramework-ի հետ:
  (օր․՝ .csproj ֆայլում  `<TargetFramework>net8.0</TargetFramework>`)
* Պրոյեկտում հարկավոր է անջատել հետևյալ հատկությունները`
  * Implicit global usings
    (.csproj ֆայլում  `<ImplicitUsings>disable</ImplicitUsings>`)
  * Nullable
    (.csproj ֆայլում  `<Nullable>disable</Nullable>`)
* Պրոյեկտին ավելացնել բանկային հիմնական պրոյեկտի հղումը  
  (.csproj ֆայլում `<ProjectReference Include="..\ProjectLocation\Bank\AS-8X\ArmSoft.AS8X.Bank\ArmSoft.AS8X.Bank.csproj" />`)

**Խորհուրդ է տրվում օգտագործել այս տարբերակը, քանի որ այն տալիս է հնարավորություն debug անել 8X սերվիսի կոդը։**

### ՀԾ-Բանկի ընդլայնման csproj-ի օրինակ

``` xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>disable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <ProjectReference Include="..\ProjectLocation\Bank\AS-8X\ArmSoft.AS8X.Bank\ArmSoft.AS8X.Bank.csproj" />
  </ItemGroup>
</Project>
```

8X սերվիսի միացման ժամանակ կազմակերպության սեփական նկարագրությունները պարունակող պրոյեկտը հաշվի առնելու համար անհրաժեշտ է`
* պրոյեկտը build անել, որի արդյունքում ձևավորվում է .dll ընդլայնմամբ ֆայլ,
* [appsettings.json](appsettings_json.md) կոնֆիգուրացիոն ֆայլի [Extensions](appsettings_json.md#extensions) բաժնում լրացնել առաջացած ընդլայնող dll-ի մասին ինֆորմացիան (անուն, գտնվելու ճանապարհ...)։

## Հասանելի են 8X սերվիսի պրոյեկտի dll-ները

Պրոյեկտը անհրաժեշտ է ստեղծել հետևյալ քայլերով՝
* Ստեղծել Class Library տիպի պրոյեկտ։ Ստեղծման եղանակին ծանոթանալու համար [տե'ս](https://learn.microsoft.com/en-us/dotnet/core/tutorials/library-with-visual-studio?create-a-class-library-project):
* TargetFramework-ի տարբերակը պետք է համընկնի կազմակերպությունում տեղադրված 8X սերվիսի տարբերակի TargetFramework-ի հետ:
  (օր․՝ .csproj ֆայլում  `<TargetFramework>net8.0</TargetFramework>`)
* Պրոյեկտում հարկավոր է անջատել հետևյալ հատկությունները`
  * Implicit global usings
    (.csproj ֆայլում  `<ImplicitUsings>disable</ImplicitUsings>`)
  * Nullable
    (.csproj ֆայլում  `<Nullable>disable</Nullable>`)
* Պրոյեկտին ավելացնել աշխատանքի համար անհրաժեշտ dll-ները։

### Պարտադիր dll-ներ

* ArmSoft.AS8X.Common.dll
* ArmSoft.AS8X.Core.dll

### Ոչ պարտադիր dll-ներ

Ստորև dll-ները պարտադիր չեն, բայց հիմնականում օգտագործվում են ընդլայնում գրելուց՝
* Armsoft.PrintTemplates2.dll
* Ardalis.SmartEnum.dll
* Microsoft.Data.SqlClient.dll

Այս dll-ները յուրահատուկ են ըստ պրոյեկտի՝
* ՀԾ-Բանկ -> ArmSoft.AS8X.Bank.dll
* ՀԾ-Ձեռնարկություն -> ArmSoft.AS8X.Enterprise.dll
* ՀԾ-ՄՌԿ -> ArmSoft.AS8X.Wages.dll

8X սերվիսի ընդլայնման համար կարող են օգտագործվել նաև այլ dll-ներ, որ առկա են և օգտագործվում են սերվիսի dll-ների ցանկում։

### ՀԾ-Բանկի ընդլայնման csproj-ի օրինակ

``` xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>disable</ImplicitUsings>
    <Nullable>disable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <Reference Include="ArmSoft.AS8X.Bank">
      <HintPath>..\ServiceLocation\ArmSoft.AS8X.Bank.dll</HintPath>
    </Reference>
    <Reference Include="ArmSoft.AS8X.Common">
      <HintPath>..\ServiceLocation\ArmSoft.AS8X.Common.dll</HintPath>
    </Reference>
    <Reference Include="ArmSoft.AS8X.Core">
      <HintPath>..\ServiceLocation\ArmSoft.AS8X.Core.dll</HintPath>
    </Reference>
    <Reference Include="Armsoft.PrintTemplates2">
      <HintPath>..\ServiceLocation\Armsoft.PrintTemplates2.dll</HintPath>
    </Reference>
    <Reference Include="System.Data.SqlClient">
      <HintPath>..\ServiceLocation\Microsoft.Data.SqlClient.dll</HintPath>
    </Reference>
    <Reference Include="System.Data.SqlClient">
      <HintPath>..\ServiceLocation\Ardalis.SmartEnum.dll</HintPath>
    </Reference>
  </ItemGroup>
</Project>
```

8X սերվիսի միացման ժամանակ կազմակերպության սեփական նկարագրությունները պարունակող պրոյեկտը հաշվի առնելու համար անհրաժեշտ է`
* պրոյեկտը build անել, որի արդյունքում ձևավորվում է .dll ընդլայնմամբ ֆայլ,
* [appsettings.json](appsettings_json.md) կոնֆիգուրացիոն ֆայլի [Extensions](appsettings_json.md#extensions) բաժնում լրացնել առաջացած ընդլայնող dll-ի մասին ինֆորմացիան (անուն, գտնվելու ճանապարհ...)։
