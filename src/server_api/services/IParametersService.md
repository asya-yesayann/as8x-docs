---
layout: page
title: "IParametersService սերվիս"
tags: [Param, BankParametersService, EnterpriseParametersService, WagesParametersService]
sublinks:
- { title: "Exists", ref: exists }
- { title: "ExistsHiPar", ref: existshipar }
- { title: "GetBooleanValue", ref: getbooleanvalue }
- { title: "GetBooleanValue", ref: getbooleanvalue-1 }
- { title: "GetDateTimeValue", ref: getdatetimevalue }
- { title: "GetDateTimeValue", ref: getdatetimevalue-1 }
- { title: "GetDecimalValue", ref: getdecimalvalue }
- { title: "GetDecimalValue", ref: getdecimalvalue-1 }
- { title: "GetDetailedDescription", ref: getdetaileddescription }
- { title: "GetHiPar", ref: gethipar }
- { title: "GetIntegerValue", ref: getintegervalue }
- { title: "GetIntegerValue", ref: getintegervalue-1 }
- { title: "GetShortValue", ref: getshortvalue }
- { title: "GetShortValue", ref: getshortvalue-1 }
- { title: "GetStringValue", ref: getstringvalue }
- { title: "GetStringValue", ref: getstringvalue1 }
- { title: "GetTimeSpanValue", ref: gettimespanvalue }
- { title: "GetTimeSpanValue", ref: gettimespanvalue-1 }
- { title: "SetHiPar", ref: sethipar }
- { title: "SetValue", ref: setvalue }
- { title: "SetValueWithAdditionalConnection", ref: setvaluewithadditionalconnection }
---

## Բովանդակություն

- [Բովանդակություն](#բովանդակություն)
- [Ներածություն](#ներածություն)
- [Մեթոդներ](#մեթոդներ)
  - [DefaultBranch](#defaultbranch)
  - [DefaultBranch](#defaultbranch-1)
  - [Exists](#exists)
  - [ExistsHiPar](#existshipar)
  - [GetBooleanValue](#getbooleanvalue)
  - [GetBooleanValue](#getbooleanvalue-1)
  - [GetDateTimeValue](#getdatetimevalue)
  - [GetDateTimeValue](#getdatetimevalue-1)
  - [GetDecimalValue](#getdecimalvalue)
  - [GetDecimalValue](#getdecimalvalue-1)
  - [GetDescriptor](#getdescriptor)
  - [GetDetailedDescription](#getdetaileddescription)
  - [GetHiPar](#gethipar)
  - [GetIntegerValue](#getintegervalue)
  - [GetIntegerValue](#getintegervalue-1)
  - [GetShortValue](#getshortvalue)
  - [GetShortValue](#getshortvalue-1)
  - [GetStringValue](#getstringvalue)
  - [GetStringValue](#getstringvalue-1)
  - [GetTimeSpanValue](#gettimespanvalue)
  - [GetTimeSpanValue](#gettimespanvalue-1)
  - [OperEnd](#operend)
  - [OperEnd](#operend-1)
  - [OPERHOLIDAYS](#operholidays)
  - [OperStart](#operstart)
  - [OperStart](#operstart-1)
  - [REPEND](#repend)
  - [REPEND](#repend-1)
  - [REPSTART](#repstart)
  - [REPSTART](#repstart-1)
  - [SetHiPar](#sethipar)
  - [SetValue](#setvalue)
  - [SetValueWithAdditionalConnection](#setvaluewithadditionalconnection)

## Ներածություն

Համակարգում նկարագրվում են պարամետրեր, որոնց միջոցով հնարավոր է սահմանել օգտագործողների որոշ իրավասություններ, ծրագրի կարգավորումներ։
Պարամետրերի արժեքները կարող են լինել [համակարգային տիպի](../types/system_types.md)։  
Պարամետրի արժեքը կարող է պահվել մեկը, կամ ըստ օգտագործողի կտրվածքի՝ այս դեպքում ամեն օգտագործող կարող է ունենալ պարամետրի սեփական արժեքը։  
Համակարգային պարամետրերը պահվում են տվյալների պահոցի [PARAMS](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/Params.html) աղյուսակում։ Ըստ օգտագործողի արժեքները պահվում են [USERPARAMS](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/User%20Params.html) աղյուսակում:  
Համակարգային պարամետրերը ստեղծվում են տեքստային ֆայլով [ներմուծման միջոցով](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Import_Files/Parameter_Import.html)։

Բացի համակարգային պարամետրերից առկա են նաև ժամանակագրական պարամետրեր։ Արժեքներ պահվում են ըստ ամսաթվի, և մեկ օրվա ընթացքում կարող է գրանցվել մի քանի արժեք։  
Պարամետրերի արժեքները կարող են լինել միայն տողային։
Ժամանակագրական պարամետրերը պահվում են տվյալների պահոցի [HIPAR](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/HiPar.html) աղյուսակում։

ՀԾ-Բանկի, ՀԾ-Ձեռնարկության և ՀԾ-Աշխատավարձի պրոյեկտներում առկա են բազային IParametersService-ի ժառանգ դասեր (BankParametersService, EnterpriseParametersService, WagesParametersService), որոնցում առկա են խիստ տիպիզացված մեթոդներ պարամետրերի արժեքները ստանալու համար։

## Մեթոդներ

### DefaultBranch

```c#
public Task<string> DefaultBranch()
```

Վերադարձնում է **DEFBRANCH** ներքին անունով [տող տիպի](../types/system_types.md#stringfieldtype) պարամետրի արժեքը, որը ցույց է տալիս ընթացիկ օգտագործողի համար առաջարկվող գրասենյակի կոդը։

### DefaultBranch

```c#
public Task<string> DefaultBranch(short suid)
```

Վերադարձնում է **DEFBRANCH** ներքին անունով [տող տիպի](../types/system_types.md#stringfieldtype) պարամետրի արժեքը, որը ցույց է տալիս `suid` ներքին համարով օգտագործողի համար առաջարկվող գրասենյակի կոդը։

**Պարամետրեր**

* `suid` - Օգտագործողի ներքին համար (կոդ)։

### Exists

```c#
public bool Exists(string paramId)
```

Ստուգում է համակարգային պարամետրի գոյությունը՝ ըստ պարամետրի ներքին անվան։

**Պարամետրեր**

* `paramId` - Պարամետրի ներքին անուն (id)։

### ExistsHiPar

```c#
public Task<bool> ExistsHiPar(string paramID, 
                              DateTime date, 
                              bool softGet, 
                              string searchValue = null)
```

Ստուգում է ժամանակագրական պարամետրի նշանակված արժեքի առկայությունը:

**Պարամետրեր**

* `paramID` - Պարամետրի ներքին անուն (id)։
* `date` - Պարամետրի որոնման ամսաթիվ։
* `softGet` - **true** արժեքի դեպքում մեթոդը ստուգում է `date` ամսաթվի դրությամբ պարամետրի որևէ արժեքի նշանակված լինելը, հակառակ դեպքում՝ միմիայն `date` ամսաթվին նշանակված արժեքի գոյությունը։
* `searchValue` - Փոխանցված լինելու դեպքում որոնում է այդ արժեքը։

### GetBooleanValue

```c#
public Task<bool> GetBooleanValue(string paramId)
```

Վերադարձնում է [տրամաբանական տիպի](../types/system_types.md#booleanfieldtype) պարամետրի արժեքը՝ ըստ պարամետրի ներքին անվան։  
Տիպի անհամապատասխանության դեպքում առաջանում է սխալ։  
Պարամետրի սահմանված չլինելու դեպքում առաջանում է սխալ։

**Պարամետրեր**

* `paramId` - Պարամետրի ներքին անուն (id):

### GetBooleanValue

```c#
public Task<bool> GetBooleanValue(string paramId, short suid)
```

Վերադարձնում է [տրամաբանական տիպի](../types/system_types.md#booleanfieldtype) պարամետրի արժեքը՝ ըստ պարամետրի ներքին անվան և օգտագործողի համարի։  
Տիպի անհամապատասխանության դեպքում առաջանում է սխալ։  
Պարամետրի սահմանված չլինելու դեպքում առաջանում է սխալ։

**Պարամետրեր**

* `paramId` - Պարամետրի ներքին անուն (id)։
* `suid` - Օգտագործողի ներքին համար (կոդ)։

### GetDateTimeValue

```c#
public Task<DateTime?> GetDateTimeValue(string paramId)
```

Վերադարձնում է ամսաթիվ տիպի ([DATE](../types/system_types.md#datefieldtype), [DATELONG](../types/system_types.md#datefieldtype)) պարամետրի արժեքը՝ ըստ պարամետրի ներքին անվան։  
Տիպի անհամապատասխանության դեպքում առաջանում է սխալ։  
Պարամետրի սահմանված չլինելու դեպքում առաջանում է սխալ։

**Պարամետրեր**

* `paramId` - Պարամետրի ներքին անուն (id)։

### GetDateTimeValue

```c#
public Task<DateTime?> GetDateTimeValue(string paramId, short suid)
```

Վերադարձնում է ամսաթիվ տիպի ([DATE](../types/system_types.md#datefieldtype), [DATELONG](../types/system_types.md#datefieldtype)) պարամետրի արժեքը՝ ըստ պարամետրի ներքին անվան և օգտագործողի համարի։  
Տիպի անհամապատասխանության դեպքում առաջանում է սխալ։  
Պարամետրի սահմանված չլինելու դեպքում առաջանում է սխալ։

**Պարամետրեր**

* `paramId` - Պարամետրի ներքին անուն (id)։
* `suid` - Օգտագործողի ներքին համար (կոդ)։

### GetDecimalValue

```c#
public Task<decimal> GetDecimalValue(string paramId)
```

Վերադարձնում է կոտորակային թիվ տիպի ([N](../types/system_types.md#numericfieldtype), [NP](../types/system_types.md#numericpositivefieldtype), [SUMMA](../types/system_types.md#amountfieldtype), [SUMMAP](../types/system_types.md#amountpositivefieldtype)) պարամետրի արժեքը՝ ըստ պարամետրի ներքին անվան։  
Տիպի անհամապատասխանության դեպքում առաջանում է սխալ։  
Պարամետրի սահմանված չլինելու դեպքում առաջանում է սխալ։

**Պարամետրեր**

* `paramId` - Պարամետրի ներքին անուն (id)։

### GetDecimalValue

```c#
public Task<decimal> GetDecimalValue(string paramId, short suid)
```

Վերադարձնում է կոտորակային թիվ տիպի ([N](../types/system_types.md#numericfieldtype), [NP](../types/system_types.md#numericpositivefieldtype), [SUMMA](../types/system_types.md#amountfieldtype), [SUMMAP](../types/system_types.md#amountpositivefieldtype)) պարամետրի արժեքը՝ ըստ պարամետրի ներքին անվան և օգտագործողի համարի։  
Տիպի անհամապատասխանության դեպքում առաջանում է սխալ։  
Պարամետրի սահմանված չլինելու դեպքում առաջանում է սխալ։

**Պարամետրեր**

* `paramId` - Պարամետրի ներքին անուն (id):
* `suid` - Օգտագործողի ներքին համար (կոդ)։

### GetDescriptor

```c#
public Descriptor GetDescriptor(string paramId)
```

Վերադարձնում է համակարգային [պարամետրի նկարագրությունը](../types/Descriptor.md):

Պարամետրի սահմանված չլինելու դեպքում առաջանում է սխալ։

**Պարամետրեր**

* `paramId` - Պարամետրի ներքին անուն (id)։

### GetDetailedDescription

```c#
public Task<string> GetDetailedDescription(string paramId)
```

Վերադարձնում է պարամետրի մանրամասն նկարագրությունը։

Պարամետրի սահմանված չլինելու դեպքում առաջանում է սխալ։

**Պարամետրեր**

* `paramId` - Պարամետրի ներքին անուն (id)։

### GetHiPar

```c#
public Task<(string Value, DateTime? SoftDate)> GetHiPar(
    string paramID, DateTime date, bool softGet, string exceptionMessage = "", 
    bool notThrowExeption = false, DateTime? maxCreationDate = null)
```

Վերադարձնում է ժամանակագրական պարամետրի արժեքը և նշանակման ամսաթիվը։

**Պարամետրեր**

* `paramID` - Պարամետրի ներքին անուն (id)։
* `date` - Պարամետրի որոնման ամսաթիվ։
* `softGet` - **true** արժեքի դեպքում մեթոդը ստուգում է `date` ամսաթվի դրությամբ պարամետրի որևէ արժեքի նշանակված լինելը, հակառակ դեպքում՝ միմիայն `date` ամսաթվին նշանակված արժեքի գոյությունը։
* `exceptionMessage` - Արժեքի չգտնելու դեպքում ցույց տրվող սխալի հաղորդագրությունը: 
  Եթե արժեք տրված չէ, ապա կառաջանա ստանդարտ սխալի հաղորդագրություն։ 
* `notThrowExeption` - `true` արժեքի դեպքում տվյալների պահոցում պարամետրի արժեքի բացակայության դեպքում վերադարձնում է դատարկ տող, հակառակ դեպքում առաջացնում է սխալ։
* `maxCreationDate` -	Փոխանցված լինելու դեպքում մեթոդը փնտրում է արժեք, որի նշանակման ամսաթիվը չի գերազանցում փոխանցված ամսաթիվը:

### GetIntegerValue

```c#
public Task<int> GetIntegerValue(string paramId)
```

Վերադարձնում է ամբողջ թիվ տիպի ([N](../types/system_types.md#numericfieldtype), [NP](../types/system_types.md#numericpositivefieldtype)) պարամետրի արժեքը՝ ըստ պարամետրի ներքին անվան։  
Տիպի անհամապատասխանության դեպքում առաջանում է սխալ։  
Պարամետրի սահմանված չլինելու դեպքում առաջանում է սխալ։

**Պարամետրեր**

* `paramId` - Պարամետրի ներքին անուն (id):

### GetIntegerValue

```c#
public Task<int> GetIntegerValue(string paramId, short suid)
```

Վերադարձնում է ամբողջ թիվ տիպի ([N](../types/system_types.md#numericfieldtype), [NP](../types/system_types.md#numericpositivefieldtype)) պարամետրի արժեքը՝ ըստ պարամետրի ներքին անվան և օգտագործողի համարի։  
Տիպի անհամապատասխանության դեպքում առաջանում է սխալ։  
Պարամետրի սահմանված չլինելու դեպքում առաջանում է սխալ։

**Պարամետրեր**

* `paramId` - Պարամետրի ներքին անուն (id):
* `suid` - Օգտագործողի ներքին համար (կոդ)։

### GetShortValue

```c#
public Task<short> GetShortValue(string paramId)
```

Վերադարձնում է կարճ ամբողջ թիվ տիպի ([N](../types/system_types.md#numericfieldtype), [NP](../types/system_types.md#numericpositivefieldtype)) պարամետրի արժեքը՝ ըստ պարամետրի ներքին անվան։  
Տիպի անհամապատասխանության դեպքում առաջանում է սխալ։  
Պարամետրի սահմանված չլինելու դեպքում առաջանում է սխալ։

**Պարամետրեր**

* `paramId` - Պարամետրի ներքին անուն (id):

### GetShortValue

```c#
public Task<short> GetShortValue(string paramId, short suid)
```

Վերադարձնում է կարճ ամբողջ թիվ տիպի ([N](../types/system_types.md#numericfieldtype), [NP](../types/system_types.md#numericpositivefieldtype)) պարամետրի արժեքը՝ ըստ պարամետրի ներքին անվան և օգտագործողի համարի։  
Տիպի անհամապատասխանության դեպքում առաջանում է սխալ։  
Պարամետրի սահմանված չլինելու դեպքում առաջանում է սխալ։

**Պարամետրեր**

* `paramId` - Պարամետրի ներքին անուն (id):
* `suid` - Օգտագործողի ներքին համար (կոդ)։

### GetStringValue

```c#
public Task<string> GetStringValue(string paramId)
```

Վերադարձնում է տող տիպի ([C](../types/system_types.md#stringfieldtype), [CH](../types/system_types.md#chfieldtype), [FOLDER](../types/system_types.md#folderfieldtype), [AMACC](../types/system_types.md#amaccfieldtype), [TREE](../types/system_types.md#treefieldtype), [FULLTREE](../types/system_types.md#treefieldtype), [PATH](../types/system_types.md#pathfieldtype), [FILE](../types/system_types.md#filefieldtype)) պարամետրի արժեքը՝ ըստ պարամետրի ներքին անվան։  
Տիպի անհամապատասխանության դեպքում առաջանում է սխալ։  
Պարամետրի սահմանված չլինելու դեպքում առաջանում է սխալ։

**Պարամետրեր**

* `paramId` - Պարամետրի ներքին անուն (id):

### GetStringValue

```c#
public Task<string> GetStringValue(string paramId, short suid)
```

Վերադարձնում է տող տիպի ([C](../types/system_types.md#stringfieldtype), [CH](../types/system_types.md#chfieldtype), [FOLDER](../types/system_types.md#folderfieldtype), [AMACC](../types/system_types.md#amaccfieldtype), [TREE](../types/system_types.md#treefieldtype), [FULLTREE](../types/system_types.md#treefieldtype), [PATH](../types/system_types.md#pathfieldtype), [FILE](../types/system_types.md#filefieldtype)) պարամետրի արժեքը՝ ըստ պարամետրի ներքին անվան և օգտագործողի համարի։  
Տիպի անհամապատասխանության դեպքում առաջանում է սխալ։  
Պարամետրի սահմանված չլինելու դեպքում առաջանում է սխալ։

**Պարամետրեր**

* `paramId` - Պարամետրի ներքին անուն (id):
* `suid` - Օգտագործողի ներքին համար (կոդ)։

### GetTimeSpanValue

```c#
public Task<TimeSpan> GetTimeSpanValue(string paramId)
```

Վերադարձնում է ժամ տիպի ([TIME](../types/system_types.md#timefieldtype), [TIMELONG](../types/system_types.md#timefieldtype)) պարամետրի արժեքը՝ ըստ պարամետրի ներքին անվան։  
Տիպի անհամապատասխանության դեպքում առաջանում է սխալ։  
Պարամետրի սահմանված չլինելու դեպքում առաջանում է սխալ։

**Պարամետրեր**

* `paramId` - Պարամետրի ներքին անուն (id):

### GetTimeSpanValue

```c#
public Task<TimeSpan> GetTimeSpanValue(string paramId, short suid)
```

Վերադարձնում է ժամ տիպի ([TIME](../types/system_types.md#timefieldtype), [TIMELONG](../types/system_types.md#timefieldtype)) պարամետրի արժեքը՝ ըստ պարամետրի ներքին անվան և օգտագործողի համարի։  
Տիպի անհամապատասխանության դեպքում առաջանում է սխալ։  
Պարամետրի սահմանված չլինելու դեպքում առաջանում է սխալ։

**Պարամետրեր**

* `paramId` - Պարամետրի ներքին անուն (id):
* `suid` - Օգտագործողի ներքին համար (կոդ)։

### OperEnd

```c#
public Task<DateTime> OperEnd()
```

Վերադարձնում է **OPEREND** ներքին անունով [ամսաթիվ տիպի](../types/system_types.md#datefieldtype) պարամետրի արժեքը, որը ցույց է տալիս գործառնական ժամանակահատվածի վերջի ամսաթիվը ընթացիկ օգտագործողի համար։

### OperEnd

```c#
public Task<DateTime> OperEnd(short suid)
```

Վերադարձնում է **OPEREND** ներքին անունով [ամսաթիվ տիպի](../types/system_types.md#datefieldtype) պարամետրի արժեքը, որը ցույց է տալիս գործառնական ժամանակահատվածի վերջի ամսաթիվը `suid` ներքին համարով օգտագործողի համար։

**Պարամետրեր**

* `suid` - Օգտագործողի ներքին համար (կոդ)։

### OPERHOLIDAYS

```c#
public Task<bool> OPERHOLIDAYS()
```

Վերադարձնում է **OPERHOLIDAYS** ներքին անունով [տրամաբանական տիպի](../types/system_types.md#booleanfieldtype) պարամետրի արժեքը, որը ցույց է տալիս, արդյոք բաց գործառնական ժամանակահատվածում հանգստյան օրերի արգելումը ակտիվ է։

### OperStart

```c#
public Task<DateTime> OperStart()
```

Վերադարձնում է **OPERSTART** ներքին անունով [ամսաթիվ տիպի](../types/system_types.md#datefieldtype) պարամետրի արժեքը, որը ցույց է տալիս գործառնական ժամանակահատվածի սկզբի ամսաթիվը ընթացիկ օգտագործողի համար։

### OperStart

```c#
public Task<DateTime> OperStart(short suid)
```

Վերադարձնում է **OPERSTART** ներքին անունով [ամսաթիվ տիպի](../types/system_types.md#datefieldtype) պարամետրի արժեքը, որը ցույց է տալիս գործառնական ժամանակահատվածի սկզբի ամսաթիվը `suid` ներքին համարով օգտագործողի համար։

**Պարամետրեր**

* `suid` - Օգտագործողի ներքին համար (կոդ)։

### REPEND

```c#
public Task<DateTime> REPEND()
```

Վերադարձնում է **REPEND** ներքին անունով [ամսաթիվ տիպի](../types/system_types.md#datefieldtype) պարամետրի արժեքը, որը ցույց է տալիս հաշվետու ժամանակահատվածի վերջի ամսաթիվը ընթացիկ օգտագործողի համար։

### REPEND

```c#
public Task<DateTime> REPEND(short suid)
```

Վերադարձնում է **REPEND** ներքին անունով [ամսաթիվ տիպի](../types/system_types.md#datefieldtype) պարամետրի արժեքը, որը ցույց է տալիս հաշվետու ժամանակահատվածի վերջի ամսաթիվը `suid` ներքին համարով օգտագործողի համար։

**Պարամետրեր**

* `suid` - Օգտագործողի ներքին համար (կոդ)։

### REPSTART

```c#
public Task<DateTime> REPSTART()
```

Վերադարձնում է **REPSTART** ներքին անունով [ամսաթիվ տիպի](../types/system_types.md#datefieldtype) պարամետրի արժեքը, որը ցույց է տալիս հաշվետու ժամանակահատվածի սկզբի ամսաթիվը ընթացիկ օգտագործողի համար։

### REPSTART

```c#
public Task<DateTime> REPSTART(short suid)
```

Վերադարձնում է **REPSTART** ներքին անունով [ամսաթիվ տիպի](../types/system_types.md#datefieldtype) պարամետրի արժեքը, որը ցույց է տալիս հաշվետու ժամանակահատվածի սկզբի ամսաթիվը `suid` ներքին համարով օգտագործողի համար։

**Պարամետրեր**

* `suid` - Օգտագործողի ներքին համար (կոդ)։

### SetHiPar

```c#
public Task SetHiPar(string parID, DateTime changeDate, 
                     int isn, string newValue, 
                     string errMsg = "", DateTime? creationDate = null)
```

Գրանցում է ժամանակագրական պարամետրի նոր արժեք տրված ամսաթվով:

**Պարամետրեր**

* `parID` - Պարամետրի ներքին անուն (id)։
* `changeDate` - Նոր արժեքի նշանակման ամսաթիվ։
* `isn` - Նոր արժեքը նշանակող հիմքային փաստաթղթի ներքին նույնականացման համար։
* `newValue` - Նոր արժեք։
* `errMsg` - Կրկնվող տվյալների առկայության դեպքում ցույց տրվող սխալի հաղորդագրություն: 
  Եթե արժեք տրված չէ, ապա կառաջանա ստանդարտ սխալի հաղորդագրություն։ 
  Կրկնությունը ստուգվում է ըստ պարամետրի ներքին անվան, արժեքի նշանակման ամսաթվի և հիմքային փաստաթղթի (`parID`, `changeDate`, `isn`)։
* `creationDate` - Արժեքի ստեղծման ամսաթիվ։

### SetValue

```c#
public Task SetValue(string name, object value)
```

Փոխում է համակարգային պարամետրի արժեքը։  
Նոր արժեքի և պարամետրի տիպի անհամապատասխանության դեպքում առաջանում է սխալ։  
Պարամետրի սահմանված չլինելու դեպքում առաջանում է սխալ։

**Պարամետրեր**

* `name` - Պարամետրի ներքին անուն (id)։ 
* `value` - Վերագրվող արժեք։ 

### SetValueWithAdditionalConnection

```c#
public Task SetValueWithAdditionalConnection(string name, object value)
```

Փոխում է համակարգային պարամետրի արժեքը [լրացուցիչ sql միացման](IDBService.md#createadditionalconnection) միջոցով։  
Նոր արժեքի և պարամետրի տիպի անհամապատասխանության դեպքում առաջանում է սխալ։  
Պարամետրի սահմանված չլինելու դեպքում առաջանում է սխալ։

**Պարամետրեր**

* `name` - Պարամետրի ներքին անուն (id)։ 
* `value` - Վերագրվող արժեք։ 