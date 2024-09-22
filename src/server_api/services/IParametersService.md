---
layout: page
title: "IParametersService սերվիս" 
---

## Բովանդակություն

- [Ներածություն](#ներածություն)
  - [Exists](#exists)
  - [ExistsHiPar](#existshipar)
  - [GetBooleanValue](#getbooleanvalue)
  - [GetBooleanValue](#getbooleanvalue-1)
  - [GetDateTimeValue](#getdatetimevalue)
  - [GetDateTimeValue](#getdatetimevalue-1)
  - [GetDecimalValue](#getdecimalvalue)
  - [GetDecimalValue](#getdecimalvalue-1)
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
  - [SetHiPar](#sethipar)
  - [SetValue](#setvalue)
  - [SetValueWithAdditionalConnection](#setvaluewithadditionalconnection)

## Ներածություն

Համակարգում նկարագրվում են պարամետրեր, որոնց միջոցով հնարավոր է սահմանել օգտագործողների որոշ իրավասություններ, ծրագրի կարգավորումներ...։

Պարամետրերը պահվում են տվյալների պահոցի [PARAMS](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/Params.html), [USERPARAMS](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/User%20Params.html), [HIPAR](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/HiPar.html) աղյուսակներում։

### Exists

```c#
public bool Exists(string paramId)
```

Ստուգում է համակարգային պարամետրի առկայությունը` ըստ պարամետրի ներքին անվան։

**Պարամետրեր**

* `paramId` - Պարամետրի ներքին անուն (id)։

### ExistsHiPar

```c#
public Task<bool> ExistsHiPar(string paramID, 
                              DateTime date, 
                              bool softGet, 
                              string searchValue = null)
```

Ստուգում է ժամանակագրական պարամետրի առկայությունը [HIPAR](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/HiPar.html) աղյուսակում:

**Պարամետրեր**

* `paramID` - Պարամետրի ներքին անուն (id)։
* `date` - Պարամետրի որոնման ամսաթիվ։
* `softGet` - **true** արժեքի դեպքում մեթոդը ստուգում է `date` ամսաթվի դրությամբ պարամետրի որևէ արժեքի նշանակված լինելը, հակառակ դեպքում՝ միմիայն `date` ամսաթվին նշանակված արժեքի գոյությունը։
* `searchValue` - 

### GetBooleanValue

```c#
public Task<bool> GetBooleanValue(string paramId);
```

Վերադարձնում է bool տիպի պարամետրի արժեքը՝ ըստ պարամետրի ներքին անվան։

**Պարամետրեր**

* `paramId` - Պարամետրի ներքին անուն (id):

### GetBooleanValue

```c#
public Task<bool> GetBooleanValue(string paramId, short suid);
```

Վերադարձնում է պարամետրի արժեքը՝ ըստ պարամետրի ներքին անվան և օգտագործողի համարի։

**Պարամետրեր**

* `paramId` - Պարամետրի ներքին անուն (id)։
* `suid` - Օգտագործողի ներքին համար (կոդ)։

### GetDateTimeValue

```c#
public Task<DateTime?> GetDateTimeValue(string paramId);
```

Վերադարձնում է պարամետրի արժեքը՝ ըստ պարամետրի ներքին անվան։

**Պարամետրեր**

* `paramId` - 

### GetDateTimeValue

```c#
public Task<DateTime?> GetDateTimeValue(string paramId, short suid);
```

Վերադարձնում է պարամետրի արժեքը՝ ըստ պարամետրի ներքին անվան և օգտագործողի համարի։

**Պարամետրեր**

* `paramId` - Պարամետրի ներքին անուն (id)։
* `suid` - Օգտագործողի ներքին համար (կոդ)։

### GetDecimalValue

```c#
public Task<decimal> GetDecimalValue(string paramId);
```

Վերադարձնում է պարամետրի արժեքը՝ ըստ պարամետրի ներքին անվան։

**Պարամետրեր**

* `paramId` - Պարամետրի ներքին անուն (id)։

### GetDecimalValue

```c#
public Task<decimal> GetDecimalValue(string paramId, short suid);
```

Վերադարձնում է պարամետրի արժեքը՝ ըստ պարամետրի ներքին անվան և օգտագործողի համարի։

**Պարամետրեր**

* `paramId` - Պարամետրի ներքին անուն (id):
* `suid` - Օգտագործողի ներքին համար (կոդ)։

### GetDetailedDescription

```c#
public Task<string> GetDetailedDescription(string paramId)
```

Վերադարձնում է պարամետրի մանրամասն հայերեն նկարագրությունը։

**Պարամետրեր**

* `paramId` - Պարամետրի ներքին անուն (id)։

### GetHiPar

```c#
public Task<(string Value, DateTime? SoftDate)> GetHiPar(string paramID, DateTime date, bool softGet, string exceptionMessage = "", bool notThrowExeption = false, DateTime? maxCreationDate = null);
```

Վերադարձնում է ժամանակագրական պարամետրի արժեքը նշված ամսաթվով տվյալների պահոցի [HIPAR](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/HiPar.html) աղյուսակից։

**Պարամետրեր**

* `paramID` - Պարամետրի ներքին անուն (id)։
* `date` - Պարամետրի որոնման ամսաթիվ։
* `softGet` - **true** արժեքի դեպքում մեթոդը ստուգում է `date` ամսաթվի դրությամբ պարամետրի որևէ արժեքի նշանակված լինելը, հակառակ դեպքում՝ միմիայն `date` ամսաթվին նշանակված արժեքի գոյությունը։
* `exceptionMessage` - Արժեքի չգտնելու դեպքում ցույց տրվող սխալի հաղորդագրությունը: Եթե արժեք տրված չէ, ապա կառաջանա ստանդարտ սխալի հաղորդագրություն։ 
* `notThrowExeption` - Արժեքի չգտնելու դեպքում սխալի գեներացման հայտանիշ։ `true` արժեքի դեպքում տվյալների պահոցում պարամետրի արժեքի բացակայության դեպքում վերադարձնում է դատարկ տող, հակառակ դեպքում գեներացնում է սխալ։
`maxCreationDate` -	Փոխանցված լինելու դեպքում մեթոդը փնտրում է արժեք, որի ստեղծման ամսաթիվը չի գերազանցում փոխանցված ամսաթիվը:

### GetIntegerValue

```c#
public Task<int> GetIntegerValue(string paramId);
```

Վերադարձնում է պարամետրի արժեքը՝ ըստ պարամետրի ներքին անվան։

**Պարամետրեր**

* `paramId` - Պարամետրի ներքին անուն (id):

### GetIntegerValue

```c#
public Task<int> GetIntegerValue(string paramId, short suid);
```

Վերադարձնում է պարամետրի արժեքը՝ ըստ պարամետրի ներքին անվան և օգտագործողի համարի։

**Պարամետրեր**

* `paramId` - Պարամետրի ներքին անուն (id):
* `suid` - Օգտագործողի ներքին համար (կոդ)։

### GetShortValue

```c#
public Task<short> GetShortValue(string paramId);
```

Վերադարձնում է պարամետրի արժեքը՝ ըստ պարամետրի ներքին անվան։

**Պարամետրեր**

* `paramId` - Պարամետրի ներքին անուն (id):

### GetShortValue

```c#
public Task<short> GetShortValue(string paramId, short suid);
```

Վերադարձնում է պարամետրի արժեքը՝ ըստ պարամետրի ներքին անվան և օգտագործողի համարի։

**Պարամետրեր**

* `paramId` - Պարամետրի ներքին անուն (id):
* `suid` - Օգտագործողի ներքին համար (կոդ)։

### GetStringValue

```c#
public Task<string> GetStringValue(string paramId);
```

Վերադարձնում է պարամետրի արժեքը՝ ըստ պարամետրի ներքին անվան։

**Պարամետրեր**

* `paramId` - Պարամետրի ներքին անուն (id):

### GetStringValue

```c#
public Task<string> GetStringValue(string paramId, short suid);
```

Վերադարձնում է պարամետրի արժեքը՝ ըստ պարամետրի ներքին անվան և օգտագործողի համարի։

**Պարամետրեր**

* `paramId` - Պարամետրի ներքին անուն (id):
* `suid` - Օգտագործողի ներքին համար (կոդ)։

### GetTimeSpanValue

```c#
public Task<TimeSpan> GetTimeSpanValue(string paramId);
```

Վերադարձնում է պարամետրի արժեքը՝ ըստ պարամետրի ներքին անվան։

**Պարամետրեր**

* `paramId` - Պարամետրի ներքին անուն (id):

### GetTimeSpanValue

```c#
public Task<TimeSpan> GetTimeSpanValue(string paramId, short suid);
```

Վերադարձնում է պարամետրի արժեքը՝ ըստ պարամետրի ներքին անվան և օգտագործողի համարի։

**Պարամետրեր**

* `paramId` - Պարամետրի ներքին անուն (id):
* `suid` - Օգտագործողի ներքին համար (կոդ)։

### SetHiPar

```c#
public Task SetHiPar(string parID, DateTime changeDate, 
                     int isn, string newValue, 
                     string errMsg = "", DateTime? creationDate = null)
```

Գրանցում է ժամանակագրական պարամետրի նոր արժեք տրված ամսաթվով տվյալների պահոցի [HIPAR](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/HiPar.html) աղյուսակում:

**Պարամետրեր**

* `parID` - Պարամետրի ներքին անուն (id)։
* `changeDate` - Նոր արժեքի նշանակման ամսաթիվ։
* `isn` - Նոր արժեքը նշանակող հիմքային փաստաթղթի ներքին նույնականացման համար։
* `newValue` - Պարամետրի նոր արժեք։
* `errMsg` - Կրկնվող տվյալների առկայության դեպքում ցույց տրվող սխալի հաղորդագրություն: Եթե արժեք տրված չէ, ապա կառաջանա ստանդարտ սխալի հաղորդագրություն։ Կրկնությունը ստուգվում է ըստ պարամետրի ներքին անվան,  արժեքի նշանակման ամսաթվի և հիմքային փաստաթղթի փաստաթղթի (`parID`, `changeDate`, `isn`)։
* `creationDate` - Արժեքի ստեղծման ամսաթիվ։

### SetValue

```c#
public Task SetValue(string name, object value)
```

Փոխում է համակարգային պարամետրի արժեքը տվյալների պահոցում։

**Պարամետրեր**

* `name` - Պարամետրի ներքին անուն (id)։ Նշված ներքին անունով պարամետրի բացակայության դեպքում առաջանում է սխալ։
* `value` - Վերագրվող արժեք։ Տիպի անհամապատասխանության դեպքում առաջանում է սխալ։

### SetValueWithAdditionalConnection

```c#
public Task SetValueWithAdditionalConnection(string name, object value)
```

Փոխում է համակարգային պարամետրի արժեքը տվյալների պահոցում լրացուցիչ sql միացման միջոցով։

**Պարամետրեր**

* `name` - Պարամետրի ներքին անուն (id)։ Նշված ներքին անունով պարամետրի բացակայության դեպքում առաջանում է սխալ։
* `value` - Վերագրվող արժեք։ Տիպի անհամապատասխանության դեպքում առաջանում է սխալ։

