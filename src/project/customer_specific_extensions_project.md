---
layout: page
title: "Կազմակերպության սեփական ընդլայնումները պարունակող պրոյեկտի ստեղծում"
---

Ընդլայնումներ մշակելը հեշտացնելու համար C#-ի ֆայլերը կարելի է հավաքել մեկ պրոյեկտի մեջ։  
Պրոյեկտի կառուցվածքը տարբերվում է, երբ
* [Հասանելի են 8X սերվիսի պրոյեկտի dll-ները](#հասանելի-են-8x-սերվիսի-պրոյեկտի-dll-ները)
* [Հասանելի են 8X սերվիսի պրոյեկտի կոդերը](#հասանելի-են-8x-սերվիսի-պրոյեկտի-կոդերը)

## Հասանելի են 8X սերվիսի պրոյեկտի dll-ները

Պրոյեկտը ստեղծել հետևյալ քայլերով
* Ստեղծել Class Library տիպի պրոյեկտ։ Ստեղծման եղանակին ծանոթանալու համար [տե'ս](https://learn.microsoft.com/en-us/dotnet/core/tutorials/library-with-visual-studio?create-a-class-library-project):
* Framework-ը պետք է լինի .NET 8  
  (.csproj ֆայլում  `<TargetFramework>net8.0</TargetFramework>`)
* Պրոյեկտում հարկավոր է անջատել հետևյալ հատկությունները
  * Implicit global usings
    (.csproj ֆայլում  `<ImplicitUsings>disable</ImplicitUsings>`)
  * Nullable
    (.csproj ֆայլում  `<Nullable>disable</Nullable>`)
* Պրոյեկտին ավելացնել աշխատանքի համար անհրաժեշտ dll-ները։

### Պարտադիր dll-ներ

* ArmSoft.AS8X.Common.dll
* ArmSoft.AS8X.Core.dll

### Ոչ պարտադիր dll-ներ

Ստորև dll-ները պարդիր չեն, բայց հիմնականում օգտագործվում են ընդլայնում գրելուց
* Armsoft.PrintTemplates2.dll
* Ardalis.SmartEnum.dll
* Microsoft.Data.SqlClient.dll

Այս dll-ները յուրահատուկ են ըստ պրոյեկտի
* ՀԾ-Բանկ -> ArmSoft.AS8X.Bank.dll
* ՀԾ-Ձեռնարկություն -> ArmSoft.AS8X.Enterprise.dll
* ՀԾ-Աշխատավարձ -> ArmSoft.AS8X.Wages.dll

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

## Հասանելի են 8X սերվիսի պրոյեկտի կոդերը

Պրոյեկտի կոդերի բեռնումը [տե՛ս այստեղ](get_project.md)։

Պրոյեկտը ստեղծել հետևյալ քայլերով
* Պատճենել ՀԾ-Բանկի հիմնական լուծման ֆայլը (ArmSoft.AS8X.Bank.sln)։ 
* Ավելացնել նոր Class Library տիպի պրոյեկտ։ Ստեղծման եղանակին ծանոթանալու համար [տե'ս](https://learn.microsoft.com/en-us/dotnet/core/tutorials/library-with-visual-studio?create-a-class-library-project):
* Framework-ը պետք է լինի .NET 8  
  (.csproj ֆայլում  `<TargetFramework>net8.0</TargetFramework>`)
* Պրոյեկտում հարկավոր է անջատել հետևյալ հատկությունները
  * Implicit global usings
    (.csproj ֆայլում  `<ImplicitUsings>disable</ImplicitUsings>`)
  * Nullable
    (.csproj ֆայլում  `<Nullable>disable</Nullable>`)
* Պրոյեկտին բանկային հիմնական պրոյեկտի հղում  
  (.csproj ֆայլում `<ProjectReference Include="..\ProjectLocation\Bank\AS-8X\ArmSoft.AS8X.Bank\ArmSoft.AS8X.Bank.csproj" />`)

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
