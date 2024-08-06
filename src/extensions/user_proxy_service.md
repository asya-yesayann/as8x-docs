---
layout: page
title: "UserProxyService - ՀԾ-Բանկի ընդլայնման յուրահատուկ սերվիս" 
---

# UserProxyService - ՀԾ-Բանկի ընդլայնման յուրահատուկ սերվիս

## Բովանդակություն
* [Ներածություն](#ներածություն)
* [LoadDoc](#LoadDoc)
* [LoadDocFromFolder](#LoadDocFromFolder)
* [LoadContractDoc](#LoadContractDoc)
* [LoadClientDoc](#LoadClientDoc)
* [LoadClientDescByISN](#LoadClientDescByISN)
* [LoadClientDescByCode](#LoadClientDescByCode)
* [LoadClientDocRObyISN](#LoadClientDocRObyISN)
* [LoadClientDocROByCode](#LoadClientDocROByCode)
* [GetClientISN](#GetClientISN)
* [GetClientISNByAcc](#GetClientISNByAcc)
* [GetClientFullName](#GetClientFullName)



  



GetClientFullName
GetClientAMDAcc
GetClientRezJurVolortByAccount
GetCliContractNamesByISN
GetCliContractNamesByCode
LoadAccountDescByIsn
LoadAccountDescByCode
LoadShortAccountDescByIsn
LoadShortAccountDescByCode
LoadAccountDoc
LoadNBAccountDescByCode
LoadNBAccountDesc
GetAccountISN
GetCliCodeByAcc
IsKasAcc
IsIncExpAcc
CalculateAtmInd
CalculateOlapFormula
Udf
TreeElProp
TreeElPropComment
TreeElPropEComment
FolderElProp
FolderElPropSpec
LoadContractDescByISN
LoadContractDescByCode
GetAgrRem
GetAgrTurn
GetSSFactValueDate
GetSSFactValueString
GetSSFactValueInt
GetSSFactValueDecimal
GetSSFactValuePercent
GetSSFactValueStringDecimal
GetAgrFactValueDate
GetAgrFactValuePercent
GetAgrFactValueDecimal
GetAgrFactValueString
GetRemSS
GetRemHI2
SSLastOpDate
AgrSchedule
GetFutPerDbt
GetFutServFeeDbt
GetPCardData
GetPCardDoc
AsCCur
DealRate
SumInWordsAsync
WKDATE
CURRENT_DATE
WEEK_BEGIN
WEEK_END
MONTH_BEGIN
MONTH_END
PREVIOUS_MONTH_BEGIN
PREVIOUS_MONTH_END
QUARTE_BEGIN
QUARTE_END
PREVIOUS_QUARTE_BEGIN
PREVIOUS_QUARTE_END
YEAR_BEGIN

GetExchangeRate
SERVER_DATE
FormatDDMMYY
FormatDDMMYYYY
FormatYYYYMMDD
CurrencyFormat
FormatToPrint
TryAddAtomicAsync
TryAddAtomic
InList
GetBranchParam
AcName
AcEName
LoadAccountDescByCode
LoadClientDescByCode
CliName
CliEName
GetAccCodeByAgrISN
GetGuaranteeISNsByAgrISN
GetLinkedMortSum
GetLinkedGuarSum
GetPenJDaysCount
GetRating
GetRatingCode
ExistsContractByCliISN
ExistsContractByCliCode
GetAgrTypeByISN
GetAllDayAgrJ
GetAllDayJCount
GetDayAgrJ
GetDayPerJ
MaxOverdueDaysCount




## Ներածություն

UserProxyService պարունակում է մեթոդներ, որոնք հնարավորություն տալիս կատարել ստորև թվարկված գործողություններ։ 

 1. Տվյալների բազայից բեռնել փաստաթղթեր այդ թվում՝ հաճախորդի քարտ, հաշիվ, պլաստիկ քարտ, ներգրավված / տեղաբաշխված միջոցների պայմանագիր:
 2. Սահմանված ամսաթվերով ստանալ հաշիվների, պայմանագրերի հաշվառումների մնացորդները:
 3. Ֆորմատավորել ամսաթվեր, գումարներ:
 4. Հաշվարկել OLAP-ի, ատոմար ցուցանիշների կամ օգտագործողի կողմից նկարագրված ֆունկցիաներ։

UserProxyService -ը հնարավոր է ինյեկցիայի միջոցավ փոխանցել և կիրառել օգտագործողի կողմից ստեղծվող ընդլայնումների դասերում։

## Մեթոդներ

### LoadDoc

```c#
public Task<Document> LoadDoc(int isn, GridLoadMode gridLoadMode = GridLoadMode.Full,
                                bool loadParents = false,
                                bool throwExceptionIfDeleted = true, bool lookInArc = true,
                                bool loadImagesAndMemos = false)
```

Վերադարձնում է սահմանված ISN -ով փաստաթուղթը։ 

**Պարամետրեր**

* `isn` - Պարտադիր։ Փաստաթղթի ISN։
* `gridLoadMode` -  Ոչ պարտադիր։ Բեռնել նաև փաստաթղթի գրիդերը թե ոչ, հնարավոր արժեքներն են 	**GridLoadMode.Full** կամ **GridLoadMode.None**։ Լռությամբ՝ **GridLoadMode.Full**։
* `loadParents` - Ոչ պարտադիր։ Բեռնել նաև փաստաթղթի ծնող-փաստաթղթերը։ Լռությամբ՝ **false**։
* `throwExceptionIfDeleted` - Ոչ պարտադիր: Փաստաթղթի հեռացված լինելու դեպքում արտացոլել սխալի վերաբերյալ հաղորդագրություն։ **false** արժեքի դեպքում կբեռնվի հեռացված փաստաթուղթը 999 վիճակով։ Լռությամբ՝ **true**:
* `lookInArc` - Ոչ պարտադիր։ Փնտրել փաստաթուղթը նաև արխիվացվածների մեջ։ Լռությամբ՝ **false**:
* `loadImagesAndMemos` - Ոչ պարտադիր։ Բեռնել նաև փաստաթղթի մեմոները և նկարները։ Լռությամբ՝ **false**:


### LoadDocFromFolder

```c#
public Task<Document> LoadDocFromFolder(string folder, string key,
                                          GridLoadMode gridLoadMode = GridLoadMode.Full,
                                          bool loadParents = false,
                                          bool loadImagesAndMemos = false)
```

Վերադարձնում է փաստաթուղթը սահմանված ֆոլդերից: Չհաջողվելու դեպքում վերադարձնում է **null**։ Արխիվացված փաստաթղթերը չեն դիտարկվում։

> [!TIP]
> Համակարգում առկա ֆոլդեռները ինչպես նաև այնտեղ գրանցված փաստաթղթերը հնարավոր է տեսնել հիմնական բազայի **FOLDERS** աղյուսակում։ Աղյուսակի հիմնական սյունենրն են՝ fFOLDERID - ֆոլդեռի ներքին անվանումը, fKEY - փաստաթղթի նույնացուցիչը, fISN - փաստաթղթի ISN-ը։ 

<br>


**Պարամետրեր**

* `folder`- Պարտադիր։ Ֆոլդեռի ID -ն։ 
* `key` - Պարտադիր։  ֆոլդեռում փաստաթղթի նույնացուցիչը։
* `gridLoadMode` -  Ոչ պարտադիր։ Բեռնել նաև փաստաթղթի գրիդերը թե ոչ, հնարավոր արժեքներն են 	**GridLoadMode.Full** կամ **GridLoadMode.None**։ Լռությամբ՝ **GridLoadMode.Full**։
* `loadParents` -  Ոչ պարտադիր։ Բեռնել նաև փաստաթղթի ծնող-փաստաթղթերը։ Լռությամբ՝ **false**։
* `loadImagesAndMemos` -Ոչ պարտադիր։ Բեռնել նաև փաստաթղթի մեմոները և նկարները։ Լռությամբ՝ **false**: 

### LoadContractDoc

```c#
public Task<Document> LoadContractDoc(string agrType, string agrCode, string agrLevelCheck = "")
```
Վերադարձնում է պայմանագիրը ըստ պայմանագրի համարի:


**Պարամետրեր**

* `agrType`- Պարտադիր։ Ենթահամակարգի տեսակ` C,D,M,N,B,Q։
* `agrCode`- Պարտադիր։ Պայմանագրի համար։
* `agrLevelCheck`- Ոչ պարտադիր։ Հնարավոր արժեքներն են ՝"AGRPARENTS","AGREEMENTS","AGRCHILDREN"։ Լռությամբ՝ ""։


> [!TIP]
> ՀԾ-Բանկ համակարգում ենթահամակարգերի կոդերը հնարավոր է դիտել SubSys ծառում (այն հասանելի է "Ադմինիստրատորի ԱՇՏ 4.0" &#8594; "Համակարգային աշխատանքներ" &#8594; "Համակարգային նկարագրություններ" տեղեկատուի մեջ։ Ծառը դիտելու համար անհրաժեշտ է կոնտեքստային մենյուի մեջ գործարկել "Բացել ծառը" հրամանը)։
<br>


## LoadClientDoc

```c#
public Task<Client> LoadClientDoc(string clientCode)
```

Վերադարձնում է հաճախորդ տեսակի փաստաթուղթը։

**Պարամետրեր**

* `clientCode`- Պարտադիր։ Հաճախորդի կոդը։


## LoadClientDescByISN

```c#
public Task<ClientDesc> LoadClientDescByISN(int isn)
```

Վերադարձնում է հաճախորդ տեսակի փաստաթղթի հիմնական դաշտերը։ Այս մեթոդի կատարման ժամանակը ավելի փոքր է համեմատած LoadClientDoc - ի։

**Պարամետրեր**

* `isn`- Պարտադիր։ Հաճախորդ փաստաթղթի ISN-ը։

## LoadClientDescByCode

```c#
public Task<ClientDesc> LoadClientDescByCode(string code)
```

Վերադարձնում է հաճախորդ տեսակի փաստաթղթի հիմնական դաշտերը։ Այս մեթոդի կատարման ժամանակը ավելի փոքր է համեմատած LoadClientDoc - ի։

**Պարամետրեր**

* `code`- Պարտադիր։ Հաճախորդի կոդը։

## LoadClientDocRObyISN
 
```c#
public Task<ClientRO> LoadClientDocRObyISN(int isn)

```
Վերադարձնում է հաճախորդ տեսակի փաստաթղթը, որտեղ դաշտերը գրահաս չեն։ 

**Պարամետրեր**

* `isn`- Պարտադիր։ Հաճախորդ փաստաթղթի ISN-ը։

## LoadClientDocROByCode
 
```c#
public Task<ClientRO> LoadClientDocROByCode(string cliCode)

```

**Պարամետրեր**

* `code`- Պարտադիր։ Հաճախորդի կոդը։


## GetClientISN

```c#
public Task<int> GetClientISN(string cliCode)

```
Վերադարձնում է հաճախորդի քարտի ISN-ը։

**Պարամետրեր**

* `cliCode`- Պարտադիր։ Հաճախորդի կոդը։

## GetClientISNByAcc

```c#
public Task<int> GetClientISNByAcc(string acc)
```
Վերադարձնում է հաճախորդի ISN -ը ըստ հաճախորդի հաշվեհամարի։

**Պարամետրեր**

* `acc`- Պարտադիր։ Հաճախորդի հաշիվեհամարներից որևէ մեկը։

## GetClientFullName

```c#
public Task<string> GetClientFullName(string firstName, string lastName, string ptronymic, bool arm)
```
Վերադարձնում է հաճախորդի անուն, ազգանուն, հայրանունը համակարգում սահմանված հերթականությամբ (հերթականությունը սահմանվում է ՝ CLINAMEORDER, CLINAMEORDERENG պարամետրերով) ։

**Պարամետրեր**

* `firstName`- Պարտադիր։ Հաճախորդի անուն։
* `lastName`- Պարտադիր։ Հաճախորդի ազգանուն։
* `ptronymic`- Պարտադիր։ Հաճախորդի հայրանուն։
* `arm`- Պարտադիր։ վերադարձնել հայերեն անվանումը։ **false** արժեքի դեպքում կվերադարձվի անգլերեն անվանումը։ 



GetClientAMDAcc
GetClientRezJurVolortByAccount
GetCliContractNamesByISN
GetCliContractNamesByCode
LoadAccountDescByIsn
LoadAccountDescByCode
LoadShortAccountDescByIsn
LoadShortAccountDescByCode
LoadAccountDoc
LoadNBAccountDescByCode
LoadNBAccountDesc
GetAccountISN
GetCliCodeByAcc
IsKasAcc
IsIncExpAcc
CalculateAtmInd
CalculateOlapFormula
Udf
TreeElProp
TreeElPropComment
TreeElPropEComment
FolderElProp
FolderElPropSpec
LoadContractDescByISN
LoadContractDescByCode
GetAgrRem
GetAgrTurn
GetSSFactValueDate
GetSSFactValueString
GetSSFactValueInt
GetSSFactValueDecimal
GetSSFactValuePercent
GetSSFactValueStringDecimal
GetAgrFactValueDate
GetAgrFactValuePercent
GetAgrFactValueDecimal
GetAgrFactValueString
GetRemSS
GetRemHI2
SSLastOpDate
AgrSchedule
GetFutPerDbt
GetFutServFeeDbt
GetPCardData
GetPCardDoc
AsCCur
DealRate
SumInWordsAsync
WKDATE
CURRENT_DATE
WEEK_BEGIN
WEEK_END
MONTH_BEGIN
MONTH_END
PREVIOUS_MONTH_BEGIN
PREVIOUS_MONTH_END
QUARTE_BEGIN
QUARTE_END
PREVIOUS_QUARTE_BEGIN
PREVIOUS_QUARTE_END
YEAR_BEGIN

GetExchangeRate
SERVER_DATE
FormatDDMMYY
FormatDDMMYYYY
FormatYYYYMMDD
CurrencyFormat
FormatToPrint
TryAddAtomicAsync
TryAddAtomic
InList
GetBranchParam
AcName
AcEName
LoadAccountDescByCode
LoadClientDescByCode
CliName
CliEName
GetAccCodeByAgrISN
GetGuaranteeISNsByAgrISN
GetLinkedMortSum
GetLinkedGuarSum
GetPenJDaysCount
GetRating
GetRatingCode
ExistsContractByCliISN
ExistsContractByCliCode
GetAgrTypeByISN
GetAllDayAgrJ
GetAllDayJCount
GetDayAgrJ
GetDayPerJ
MaxOverdueDaysCount





