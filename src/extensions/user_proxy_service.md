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
* [GetClientAMDAcc](#GetClientAMDAcc)
* [GetClientRezJurVolortByAccount](#GetClientRezJurVolortByAccount)
* [GetCliContractNamesByISN](#GetCliContractNamesByISN)
* [GetCliContractNamesByCode](#GetCliContractNamesByCode)
* [LoadAccountDescByIsn](#LoadAccountDescByIsn)
* [LoadAccountDescByCode](#LoadAccountDescByCode)
* [LoadShortAccountDescByIsn](#LoadShortAccountDescByIsn)
* [LoadShortAccountDescByCode](#LoadShortAccountDescByCode)
* [LoadAccountDoc](#LoadAccountDoc)
* [LoadNBAccountDescByCode](#LoadNBAccountDescByCode)
* [LoadNBAccountDesc](#LoadNBAccountDesc)
* [GetAccountISN](#GetAccountISN)
* [GetCliCodeByAcc](#GetCliCodeByAcc)
* [IsKasAcc](#IsKasAcc)
* [IsIncExpAcc](#IsIncExpAcc)
* [CalculateAtmInd](#CalculateAtmInd)
* [CalculateOlapFormula](#CalculateOlapFormula)
* [Udf](#Udf)
* [TreeElProp](#TreeElProp)
* [TreeElPropComment](#TreeElPropComment)
* [TreeElPropEComment](#TreeElPropEComment)
* [FolderElProp](#FolderElProp)















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

UserProxyService -ը օգտագործվում է ընդլայնումներ ստեղծելիս։ Այն թույլ է տալիս. 

 1. տվյալների պահոցից ստանալ փաստաթղթեր այդ թվում՝ հաճախորդի քարտ, հաշիվ, պլաստիկ քարտ, ներգրավված / տեղաբաշխված միջոցների պայմանագրեր,
 2. սահմանված ամսաթվերով ստանալ հաշիվների, պայմանագրերի հաշվառումների մնացորդները,
 3. ֆորմատավորել ամսաթվեր, գումարներ,
 4. Հաշվարկել OLAP-ի, ատոմար ցուցանիշների կամ օգտագործողի կողմից նկարագրված ֆունկցիաներ։
 
Ընդլայնումներում UserProxyService-ն օգտագործելու համար անհրաժեշտ է կատարել նշված սերվիսի ինյեկցիան։



``` c#
[TemplateSubstitutionExtender]
public class AccStatements : ITemplateSubstitutionExtender
{

    private readonly UserProxyService proxyService;
    Account accountDoc;

    public AccStatements(UserProxyService proxyService)
    {
        this.proxyService = proxyService;
    }

```
UserProxyService -ն պարունակում է՝ ինչպես Task-եր, այնպես էլ սովորական մեթոդներ։ Task-երը անհրաժեշտ է օգտագործվել await բանալի բառի հետ։

```c#
/* public Task<Document> LoadDoc(int isn, GridLoadMode gridLoadMode = GridLoadMode.Full,
                                 bool loadParents = false,
                                 bool throwExceptionIfDeleted = true, bool lookInArc = true,
                                 bool loadImagesAndMemos = false) */

var agrDoc =  await proxyService.LoadDoc(docISN);  
```

```c#
// public DateTime WKDATE()
DateTime curDate = proxyService.WKDATE(); 
```

static մեթոդները կանչվում են անմիջապես դասի վրայից։

```c#
// public static decimal AsCCur(string stringValue)
decimal sum = UserProxyService.AsCCur("15.86") 
```


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
* `gridLoadMode` -  Ոչ պարտադիր։ Բեռնել նաև փաստաթղթում առկա աղյուսակները, հնարավոր արժեքներն են 	**GridLoadMode.Full** կամ **GridLoadMode.None**։ Լռությամբ՝ **GridLoadMode.Full** (բեռնել)։
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
> Համակարգում առկա ֆոլդեռները ինչպես նաև այնտեղ գրանցված փաստաթղթերը հնարավոր է տեսնել հիմնական բազայի **FOLDERS** աղյուսակում։ Աղյուսակի հիմնական սյունենրն են՝ fFOLDERID - ֆոլդեռի ներքին անվանումը, fKEY - փաստաթղթի բանալին ֆոլդեռում, fISN - փաստաթղթի ISN-ը։ 
<br>

**Պարամետրեր**

* `folder`- Պարտադիր։ Ֆոլդեռի ID -ն։ 
* `key` - Պարտադիր։  ֆոլդեռում փաստաթղթի բանալին։
* `gridLoadMode` -  Ոչ պարտադիր։ Բեռնել նաև փաստաթղթի աղյուսակները, հնարավոր արժեքներն են	**GridLoadMode.Full** կամ **GridLoadMode.None**։ Լռությամբ՝ **GridLoadMode.Full** (բեռնել)։
* `loadParents` -  Ոչ պարտադիր։ Բեռնել նաև փաստաթղթի ծնող-փաստաթղթերը։ Լռությամբ՝ **false**։
* `loadImagesAndMemos` -Ոչ պարտադիր։ Բեռնել նաև փաստաթղթի մեմոները և նկարները։ Լռությամբ՝ **false**: 




### LoadContractDoc

```c#
public Task<Document> LoadContractDoc(string agrType, string agrCode, string agrLevelCheck = "")
```

Վերադարձնում է պայմանագրի օբյեկտը ըստ պայմանագրի համարի:

**Պարամետրեր**

* `agrType`- Պարտադիր։ Ենթահամակարգի տեսակ` C,D,M,N,B,Q։
* `agrCode`- Պարտադիր։ Պայմանագրի համար։
* `agrLevelCheck`- Ոչ պարտադիր։ Հնարավոր արժեքներն են ՝"AGRPARENTS","AGREEMENTS","AGRCHILDREN"։ Լռությամբ՝ ""։

> [!TIP]
> ՀԾ-Բանկ համակարգում ենթահամակարգերի կոդերը հնարավոր է դիտել SubSys ծառում (այն հասանելի է "Ադմինիստրատորի ԱՇՏ 4.0" &#8594; "Համակարգային աշխատանքներ" &#8594; "Համակարգային նկարագրություններ" տեղեկատուի մեջ։ Ծառը դիտելու համար անհրաժեշտ է կոնտեքստային մենյուի մեջ գործարկել "Բացել ծառը" հրամանը)։
<br>


## GetContractISN

```c#
public Task<int> GetContractISN(string agrType, string agrCode, string agrLevelCheck = "")??????????????
```

Վերադարձնում է պայմանագրի ISN-ը։



## LoadClientDoc

```c#
public Task<Client> LoadClientDoc(string clientCode)
```

Վերադարձնում է հաճախորդի քարտի օբյեկտը։ Oգտագործվում է `await` բանալի բառով:

**Պարամետրեր**

* `clientCode`- Պարտադիր։ Հաճախորդի կոդը։



## LoadClientDescByISN

```c#
public Task<ClientDesc> LoadClientDescByISN(int isn)
```

Վերադարձնում է հաճախորդ տեսակի փաստաթղթի հիմնական դաշտերը պարունակող օբյեկտ ըստ հաճախորդի քարտի ISN-ի։ Այս մեթոդի կատարման ժամանակը ավելի փոքր է համեմատած LoadClientDoc - ի։ 

**Պարամետրեր**

* `isn`- Պարտադիր։ Հաճախորդ փաստաթղթի ISN-ը։



## LoadClientDescByCode

```c#
public Task<ClientDesc> LoadClientDescByCode(string code)
```

Վերադարձնում է հաճախորդ տեսակի փաստաթղթի հիմնական դաշտերը պարունակող օբյեկտ ըստ հաճախորդի կոդի։ Այս մեթոդի կատարման ժամանակը ավելի փոքր է համեմատած LoadClientDoc - ի։

**Պարամետրեր**

* `code`- Պարտադիր։ Հաճախորդի կոդը։



## LoadClientDocRObyISN
 
```c#
public Task<ClientRO> LoadClientDocRObyISN(int isn)
```

Վերադարձնում է համապատասխան ISN-ով հաճախորդ տեսակի փաստաթուղթը, որտեղ դաշտերը գրահաս չեն։ 

**Պարամետրեր**

* `isn`- Պարտադիր։ Հաճախորդ փաստաթղթի ISN-ը։



## LoadClientDocROByCode
 
```c#
public Task<ClientRO> LoadClientDocROByCode(string cliCode)
```

Վերադարձնում է համապատասխան հաճախորդի կոդով հաճախորդ տեսակի փաստաթուղթը, որտեղ դաշտերը գրահաս չեն։ 

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

Վերադարձնում է հաճախորդի անուն, ազգանուն, հայրանունը համակարգում սահմանված հերթականությամբ (հերթականությունը սահմանվում է ՝ CLINAMEORDER -"Հաճախորդի անվան հերթականություն", CLINAMEORDERENG - "Հաճախորդի անգլ. անվան հերթականություն" պարամետրերով)։

**Պարամետրեր**

* `firstName`- Պարտադիր։ Հաճախորդի անուն։
* `lastName`- Պարտադիր։ Հաճախորդի ազգանուն։
* `ptronymic`- Պարտադիր։ Հաճախորդի հայրանուն։
* `arm`- Պարտադիր։ Անվանումը հայերեն է։ Այս դեպքում անուն, ազգանունի, հայրանունի հերթականությունը կորոշվի CLINAMEORDER պարամետրով կատարված կարգավորմամբ։ **false** արժեքը օգտագոևծվում է այն դեպքում երբ անվանումը անգլերեն է։ Այս դեպքում անվան հերթականությունը կորորշվի CLINAMEORDERENG պարամետրով։ 



## GetClientAMDAcc

```c#
public Task<string> GetClientAMDAcc(string cliCode)
```

Վերադարձնում է հաճախորդի քարտում լրացված հիմնական դրամային հաշիվը ("Պայմաններ" էջ, "Հիմնական դրամային հաշիվ (գանձ. պայմ% մար-տրմդր)")։

**Պարամետրեր**

* `cliCode`- Պարտադիր։ Հաճախորդի կոդ։



## GetClientRezJurVolortByAccount

```c#
public Task<(string residence, string jurState, string volort)>GetClientRezJurVolortByAccount(string accCode)
```

Վերադարձնում է հաճախորդի ռեզիդենտությունը (1-ռեզիդենտ, 2-ոչ ռեզիդենտ), իրավաբանական կարգավիճակի և ոլորտի համապատասխան ծառի կոդերը ըստ հաճախորդի հաշվեհամարի։

**Պարամետրեր**

* `acc`- Պարտադիր։ Հաճախորդի հաշիվեհամարներից որևէ մեկը։



## GetCliContractNamesByISN

```c#
public async Task<string> GetCliContractNamesByISN(int cliISN, bool showClosed = false)
```

Վերադարձնում է հաճախորդի թղթապանակում առկա փաստաթղթերի տեսակների ներքին անվանումների ցանկը ըստ հաճախորդի ISN-ի։

**Պարամետրեր**

* `cliISN`- Պարտադիր։ Հաճախորդի քարտի ISN -ը։
* `showClosed` - Ոչ պարտադիր։ Ցույց տալ նաև փակվածները։

  

## GetCliContractNamesByCode

```c#
public async Task<string> GetCliContractNamesByCode(string cliCode, bool showClosed = false)
```

Վերադարձնում է հաճախորդի թղթապանակում առկա փաստաթղթերի տեսակների ներքին անվանումների ցանկը ըստ հաճախորդի կոդի։

**Պարամետրեր**

* `cliCode`- Պարտադիր։ Հաճախորդի քարտի ISN -ը։
* `showClosed` - Ոչ պարտադիր։ Ցույց տալ նաև փակվածները։ Լռությամբ՝ **false**։



## LoadAccountDescByIsn

```c#
public Task<AccountDesc> LoadAccountDescByIsn(int isn, bool throwException = false)
```

Վերադարձնում է հաշվի հիմնական դաշտերը պարունակող օբյեկտ ըսռ հաշվի ISN-ի։ 

**Պարամետրեր**

* `isn`- Պարտադիր։ Հաշվի ISN -ը։
* `throwException`- Ոչ պարտադիր։ Առաջացնել սխալ հաշվեհամարի բացակության դեպքում։ Լռությամբ՝ **false**։



## LoadAccountDescByCode

```c#
public Task<AccountDesc> LoadAccountDescByCode(string code, bool throwException = false)
```

Վերադարձնում է հաշվի հիմնական դաշտերը պարունակող օբյեկտ ըսռ հաշվեհամարի։ 

**Պարամետրեր**

* `code`- Պարտադիր։ Հաշվի համար։
* `throwException`- Ոչ պարտադիր։ Առաջացնել սխալ հաշվեհամարի բացակության դեպքում։ Լռությամբ՝ **false**։




## LoadShortAccountDescByIsn

```c#
public Task<AccountDescShort> LoadShortAccountDescByIsn(int isn, bool throwException = false)
```

Վերադարձնում է հաշվի սահմանափակ դաշտերը (ISN, "Հաշվի համար","Արժույթ","Գրասենյակ","Բաժին","Հասանելիության տիպ") պարունակող օբյեկտ ըսռ հաշվի ISN-ի։ 

**Պարամետրեր**

* `isn`- Պարտադիր։ Հաշվի ISN։
* `throwException` -  Ոչ պարտադիր։ Առաջացնել սխալ հաշվի բացակության դեպքում։ Լռությամբ՝ **false**։



## LoadShortAccountDescByCode

```c#
public Task<AccountDescShort> LoadShortAccountDescByCode(string code, bool throwException = false)
```

Վերադարձնում է հաշվի սահմանափակ դաշտերը (ISN, "Հաշվի համար","Արժույթ","Գրասենյակ","Բաժին","Հասանելիության տիպ") պարունակող օբյեկտ ըսռ հաշվեհամարի։ 

**Պարամետրեր**

* `code`- Պարտադիր։ Հաշվի համար։
* `throwException` - Ոչ պարտադիր։ Առաջացնել սխալ հաշվի բացակության դեպքում։ Լռությամբ՝ **false**։


## LoadAccountDoc

```c#
public Task<Account> LoadAccountDoc(string accCode)
```

Վերադարձնում է հաշվի ամբողջական դաշտերը պարունակող օբյեկտ ըստ հաշվեհամարի։ 

**Պարամետրեր**

* `code`- Պարտադիր։ Հաշվի համար։



## LoadNBAccountDescByCode

```c#
public Task<NBAccountDesc> LoadNBAccountDescByCode(string code, bool throwException = false)
```

Վերադարձնում է ետհաշվեկշռային հաշվի հիմնական դաշտերը պարունակող օբյետ ըստ ետհաշվեկշռային հաշվի համարի։ 

**Պարամետրեր**

* `code`- Պարտադիր։ Ետհաշվեկշռային հաշվի համար։ Ետհաշվեկշռային հաշվի համարը պետք փոխանցել հետևյալ ֆորմատով՝ "հաշվային_պլանի_հաշիվ/անալիտիկ_հաշիվ"։ Օրինակ՝ "8000001/803813"
* `throwException` - Ոչ պատադիր։ Առաջացնել սխալ հաշվի բավակայության դեպքում։ Լռությամբ՝ **false**: 



## LoadNBAccountDesc

```c#
public Task<NBAccountDesc> LoadNBAccountDesc(int isn, bool throwException = false)
```

Վերադարձնում է ետհաշվեկշռային հաշվի հիմնական դաշտերը պարունակող օբյետ ըստ ետհաշվեկշռային հաշվի ISN-ի։ 

**Պարամետրեր**

* `isn`- Պարտադիր։ Ետհաշվեկշռային հաշվի ISN-ը։
* `throwException` - Ոչ պատադիր։ Առաջացնել սխալ հաշվի բավակայության դեպքում։ Լռությամբ՝ **false**: 



## GetAccountISN

```c#
public Task<int> GetAccountISN(string acc)
```

Վերադարձնում է հաշվի հիմնական ISN-ը ըստ հաշվի համարի։ 

**Պարամետրեր**

* `acc`- Պարտադիր։ Հաշվի համար։



## GetCliCodeByAcc

```c#
public Task<string> GetCliCodeByAcc(string account)
```

Վերադարձնում է Հաճախորդի կոդը ըստ հաշվի համարի։ 

**Պարամետրեր**

* `account`- Պարտադիր։ Հաշվի համար։



## IsKasAcc

```c#
public Task<bool> IsKasAcc(string account)
```

Վերադարձնում է **true** երբ փոխանցված հաշվի համարը դրամարկղային է։ 

**Պարամետրեր**

* `account`- Պարտադիր։ Հաշվի համար։



## IsIncExpAcc

```c#
public Task<bool> IsIncExpAcc(string account)
```

Վերադարձնում է **true** երբ փոխանցված հաշվի համարը եկամտի կամ ծախսի հաշիվ է։ 

**Պարամետրեր**

* `account`- Պարտադիր։ Հաշվի համար։



## CalculateAtmInd

```c#
public decimal CalculateAtmInd(string codFormList, DateTime dateFirst, DateTime dateLast, string acsBranch = "",
        string skv = "", string calcCurCode = "", int precision = 2)
```

Վերադարձնում է **true** երբ փոխանցված հաշվի համարը եկամտի կամ ծախսի հաշիվ է։ 

**Պարամետրեր**

* `codFormList`- Պարտադիր։ Հաշվի համար։
* `branch`- Պարտադիր։ Հաշվի համար։
* `dateFirst`- Պարտադիր։ Ժամանակաշրջանի սկիզբ։
* `dateLast`- Պարտադիր։ Ժամանակաշրջանի վերջ
* `skv`- Ոչ պարտադիր։ Լռությամբ՝ ""։
* `calcCurCode`- Ոչ պարտադիր։ Լռությամբ՝ ""։
* `precision`- Ոչ պարտադիր։ Լռությամբ՝ 2։


CalculateOlapFormula

```c#
public decimal CalculateOlapFormula(string codFormList, string branch, DateTime dateFirst, DateTime dateLast,
                string skv = "", string calcCurCode = "", int precision = 2)
```

Վերադարձնում է **true** երբ փոխանցված հաշվի համարը եկամտի կամ ծախսի հաշիվ է։ 

**Պարամետրեր**

* `codFormList`- Պարտադիր։ Հաշվի համար։
* `branch`- Պարտադիր։ Հաշվի համար։
* `dateFirst`- Պարտադիր։ Ժամանակաշրջանի սկիզբ։
* `dateLast`- Պարտադիր։ Ժամանակաշրջանի վերջ
* `skv`- Ոչ պարտադիր։ Լռությամբ՝ ""։
* `calcCurCode`- Ոչ պարտադիր։ Լռությամբ՝ ""։
* `precision`- Ոչ պարտադիր։ Լռությամբ՝ 2։



## Udf
```c#
public decimal Udf(string codeForm, params object[] @params)
```

Հաշվարկում է օգտագործողի կողմից նկարագրված բանաձևը։ Մեթոդը հնարավոր է օգտագործել միայն այն դեպքում երբ բանաձևը վերադարձնում է decimal տիպի թիվ։

**Պարամետրեր**

* `codeForm`- Պարտադիր։ բանաձևի կոդը։
* `params object[] @params` - Պարտադիր։ Օգտոգործողի կողմից նկարագրվող բանաձևի բոլոր պարամետրերի արժեքները։

Բերված օրինակում հաշվարկվում է AvRem բանաձևը, որը վերադարձնում է 01 տիպի 006 Նշում ունեցող հաշիվների միջին մնացորդը 
01/07/24-31/07/24 ժամանակահատվածի համար։

```c#
decimal agrs = proxyService.Udf("AvRem", DateTime.Parse("2024-07-01"), DateTime.Parse("2024-07-31"),  "01", "006");
```

  

## TreeElProp

```c#
public Task<TreeElement> TreeElProp(string treeId, string key, bool useCache = true)
```

Վերադարձնում է սահմանված կոդով, ծառ-տեղեկատուի հանգույցի օբյեկտը։ 

**Պարամետրեր**

* `treeId`- Պարտադիր։ Ծառի ներքին անվանումը։
* `key` - Պարտադիր։ Հանգույցի կոդը։
* `useCache` = Ոչ պարտադիր։ Վերադարձնել քեշավորված արժեքը։ Լռությամբ՝ true:

Բերված օրինակում ստացվում է մարզերի տեղեկատուի 001 կոդով հանգույցի անվանումը օգտագործելով քեշավորված տվյալները։  

```c#
string DistrName = (await proxyService.TreeElProp("LRDistr", "001")).Comment;
```



## TreeElPropComment

```c#
public async Task<string> TreeElPropComment(string treeId, string key, bool useCache = true)
```

Վերադարձնում է սահմանված կոդով, ծառ-տեղեկատուի հանգույցի անվանումը։ 

**Պարամետրեր**

* `treeId`- Պարտադիր։ Ծառի ներքին անվանումը։
* `key` - Պարտադիր։ Հանգույցի կոդը։
* `useCache` = Ոչ պարտադիր։ Վերադարձնել քեշավորված արժեքը։ Լռությամբ՝ true: Լռությամբ քեշի թարմացումը տեղի է ունենում 10 րոպեն մեկ, սակայն այդ ժամանակահատվածը հնարավոր է փոփոխել խմբագրելով appsettings.json ֆայլը (CacheRefreshPeriods պարամետր)։


## TreeElPropEComment

```c#
public async Task<string> TreeElPropComment(string treeId, string key, bool useCache = true)
```

Վերադարձնում է սահմանված կոդով, ծառ-տեղեկատուի հանգույցի անգլերեն անվանումը։ 

**Պարամետրեր**

* `treeId`- Պարտադիր։ Ծառի ներքին անվանումը։
* `key` - Պարտադիր։ Հանգույցի կոդը։
* `useCache` = Ոչ պարտադիր։ Վերադարձնել քեշավորված արժեքը։ Լռությամբ՝ true: Լռությամբ քեշի թարմացումը տեղի է ունենում 10 րոպեն մեկ, սակայն այդ ժամանակահատվածը հնարավոր է փոփոխել խմբագրելով appsettings.json ֆայլը (CacheRefreshPeriods պարամետր)։


## FolderElProp

```c#
public Task<FolderElement> FolderElProp(string folderId, string key, bool noLock = true)
```

Վերադարձնում է համակարգային թղթապանակ տիպի օբյեկտների հղումներն՝ ըստ օբյեկտի անվանման և հղման բանալու։

**Պարամետրեր**

* `folderId`- Պարտադիր։ Ծառի ներքին անվանումը։
* `key` - Պարտադիր։ Հանգույցի կոդը։
* `noLock` = Ոչ պարտադիր։ Վերադարձնել քեշավորված արժեքը։ Լռությամբ՝ true: 

Բերված օրինակում ստանում ենք վարկային պայմանագրի ընթացիկ գրաֆիկի ISN -ը, պայմանագրի թղթապանակից։ Agr.243335599 -ն հանդիսանում է 243335599 ISN -ով պայմանագրի թղթապանակը, C1TSDtUn -ն հանդիսանում է թղթապանակում ընթացիկ գրաֆիկի բանալին։
```c#
int schedISN = (await proxyService.FolderElProp("Agr.243335599", "C1TSDtUn")).ISN;
```

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





