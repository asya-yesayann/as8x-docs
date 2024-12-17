---
layout: page
title: "Web API կլիենտական գրադարանի dll-ներ" 
---

8X սերվիսի Web API-ի հետ աշխատանքի համար նախատեսված է կլիենտական գրադարան։  
Կլիենտական գրադարանը առկա է .NET 8, .NET 6 և .NET Framework 4.7.2 տարբերակների համար։

Կլիենտական գրադարանը պարունակում է հիմնական dll-ներ բոլոր .NET-ի տարբերակների համար և օժանդակ dll-ները, որ տարբերվում են .NET-ի տարբերակից կախված։

### Հիմնական dll-ներ

* ArmSoft.AS8X.Public.Client.dll
* ArmSoft.AS8X.Public.Models.dll
* ArmSoft.AS8X.Common.dll
* ArmSoft.AS8X.Cryptography.dll
* Ardalis.SmartEnum.dll
* Ardalis.SmartEnum.SystemTextJson.dll

### ՀԾ-Բանկի յուրահատուկ dll-ներ

* ArmSoft.AS8X.Public.BankClient.dll
* ArmSoft.AS8X.Public.BankModels.dll

### Կլիենտական գրադարանի օգտագործող csproj-ի օրինակ

``` xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <Reference Include="Ardalis.SmartEnum">
      <HintPath>..\AS8X.Public.BankClient\net8․0\Ardalis.SmartEnum.dll</HintPath>
    </Reference>
    <Reference Include="Ardalis.SmartEnum.SystemTextJson">
      <HintPath>..\AS8X.Public.BankClient\net8․0\Ardalis.SmartEnum.SystemTextJson.dll</HintPath>
    </Reference>
    <Reference Include="ArmSoft.AS8X.Common">
      <HintPath>..\AS8X.Public.BankClient\net8․0\ArmSoft.AS8X.Common.dll</HintPath>
    </Reference>
    <Reference Include="ArmSoft.AS8X.Cryptography">
      <HintPath>..\AS8X.Public.BankClient\net8․0\ArmSoft.AS8X.Cryptography.dll</HintPath>
    </Reference>
    <Reference Include="ArmSoft.AS8X.Public.BankClient">
      <HintPath>..\AS8X.Public.BankClient\net8․0\ArmSoft.AS8X.Public.BankClient.dll</HintPath>
    </Reference>
    <Reference Include="ArmSoft.AS8X.Public.BankModels">
      <HintPath>..\AS8X.Public.BankClient\net8․0\ArmSoft.AS8X.Public.BankModels.dll</HintPath>
    </Reference>
    <Reference Include="ArmSoft.AS8X.Public.Client">
      <HintPath>..\AS8X.Public.BankClient\net8․0\ArmSoft.AS8X.Public.Client.dll</HintPath>
    </Reference>
    <Reference Include="ArmSoft.AS8X.Public.Models">
      <HintPath>..\AS8X.Public.BankClient\net8․0\ArmSoft.AS8X.Public.Models.dll</HintPath>
    </Reference>
    <Reference Include="Microsoft.Extensions.DependencyInjection.Abstractions">
      <HintPath>..\AS8X.Public.BankClient\net8․0\Microsoft.Extensions.DependencyInjection.Abstractions.dll</HintPath>
    </Reference>
    <Reference Include="Microsoft.Extensions.Logging.Abstractions">
      <HintPath>..\AS8X.Public.BankClient\net8․0\Microsoft.Extensions.Logging.Abstractions.dll</HintPath>
    </Reference>
    <Reference Include="Microsoft.IdentityModel.Abstractions">
      <HintPath>..\AS8X.Public.BankClient\net8․0\Microsoft.IdentityModel.Abstractions.dll</HintPath>
    </Reference>
    <Reference Include="Microsoft.IdentityModel.JsonWebTokens">
      <HintPath>..\AS8X.Public.BankClient\net8․0\Microsoft.IdentityModel.JsonWebTokens.dll</HintPath>
    </Reference>
    <Reference Include="Microsoft.IdentityModel.Logging">
      <HintPath>..\AS8X.Public.BankClient\net8․0\Microsoft.IdentityModel.Logging.dll</HintPath>
    </Reference>
    <Reference Include="Microsoft.IdentityModel.Tokens">
      <HintPath>..\AS8X.Public.BankClient\net8․0\Microsoft.IdentityModel.Tokens.dll</HintPath>
    </Reference>
    <Reference Include="System.IdentityModel.Tokens.Jwt">
      <HintPath>..\AS8X.Public.BankClient\net8․0\System.IdentityModel.Tokens.Jwt.dll</HintPath>
    </Reference>
    <Reference Include="System.Text.Json">
      <HintPath>..\AS8X.Public.BankClient\net8․0\System.Text.Json.dll</HintPath>
    </Reference>
  </ItemGroup>

</Project>
```
