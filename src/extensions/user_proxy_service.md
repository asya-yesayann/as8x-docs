---
layout: page
title: "UserProxyService - ՀԾ-Բանկի ընդլայնման յուրահատուկ սերվիս" 
---

# UserProxyService - ՀԾ-Բանկի ընդլայնման յուրահատուկ սերվիս

## Բովանդակություն
* [Ներածություն](#ներածություն)
* [LoadDoc](#loaddoc)
* [LoadDocFromFolder](#loaddocfromfolder)
* [LoadContractDoc](#loadcontractdoc)
* [LoadClientDoc](#loadclientdoc)
* [LoadClientDescByISN](#loadclientdescbyisn)
* [LoadClientDescByCode](#loadclientdescbycode)
* [LoadClientDocRObyISN](#loadclientdocrobyisn)
* [LoadClientDocROByCode](#loadclientdocrobycode)
* [GetClientISN](#getclientisn)
* [GetClientISNByAcc](#getclientisnbyacc)
* [GetClientFullName](#getclientfullname)
* [GetClientAMDAcc](#getclientamdacc)
* [GetClientRezJurVolortByAccount](#getclientrezjurvolortbyaccount)
* [GetCliContractNamesByISN](#getclicontractnamesbyisn)
* [GetCliContractNamesByCode](#getclicontractnamesbycode)
* [LoadAccountDescByIsn](#loadaccountdescbyisn)
* [LoadAccountDescByCode](#loadaccountdescbycode)
* [LoadShortAccountDescByIsn](#loadshortaccountdescbyisn)
* [LoadShortAccountDescByCode](#loadshortaccountdescbycode)
* [LoadAccountDoc](#loadaccountdoc)
* [LoadNBAccountDescByCode](#loadnbaccountdescbycode)
* [LoadNBAccountDesc](#loadnbaccountdesc)
* [GetAccountISN](#getaccountisn)
* [GetCliCodeByAcc](#getclicodebyacc)
* [IsKasAcc](#iskasacc)
* [IsIncExpAcc](#isincexpacc)
* [CalculateAtmInd](#calculateatmind)
* [CalculateOlapFormula](#calculateolapformula)
* [Udf](#udf)
* [TreeElProp](#treeelprop)
* [TreeElPropComment](#treeelpropcomment)
* [TreeElPropEComment](#treeelpropecomment)
* [FolderElProp](#folderelprop)
* [FolderElPropSpec](#folderelpropspec)
* [LoadContractDescByISN](#loadcontractdescbyisn)
* [LoadContractDescByCode](#loadcontractdescbycode)
* [GetAgrRem](#getagrrem)
* [GetAgrTurn](#getagrturn)
* [GetSSFactValueDate, GetSSFactValueString, GetSSFactValueInt, GetSSFactValueDecimal, GetSSFactValuePercent, GetSSFactValueStringDecimal](#getssfactvaluedate-getssfactvaluestring-getssfactvalueint-getssfactvaluedecimal-getssfactvaluepercent-getssfactvaluestringdecimal)
* [GetAgrFactValueDate, GetAgrFactValuePercent, GetAgrFactValueDecimal, GetAgrFactValueString](#getagrfactvaluedate-getagrfactvaluepercent-getagrfactvaluedecimal-getagrfactvaluestring)
* [GetRemSS](#getremss)
* [GetRemHI2](#getremhi2)
* [SSLastOpDate](#sslastopdate)
* [AgrSchedule](#agrschedule)
* [GetFutPerDbt](#getfutperdbt)
* [GetFutServFeeDbt](#getfutservfeedbt)
* [GetPCardData](#getpcarddata)
* [GetPCardDoc](#GetPCardDoc)
* [AsCCur](#AsCCur)
* [DealRate](#DealRate)
* [SumInWordsAsync](#SumInWordsAsync)
* [WKDATE](#WKDATE)
* [CURRENT_DATE](#CURRENT_DATE)
* [WEEK_BEGIN](#WEEK_BEGIN)
* [WEEK_END](#WEEK_END)
* [MONTH_BEGIN](#MONTH_BEGIN)
* [MONTH_END](#MONTH_END)
* [PREVIOUS_MONTH_BEGIN](#PREVIOUS_MONTH_BEGIN)
* [PREVIOUS_MONTH_END](#PREVIOUS_MONTH_END)
* [QUARTE_BEGIN](#QUARTE_BEGIN)
* [QUARTE_END](#QUARTE_END)
* [PREVIOUS_QUARTE_BEGIN](#PREVIOUS_QUARTE_BEGIN)
* [PREVIOUS_QUARTE_END](#PREVIOUS_QUARTE_END)
* [YEAR_BEGIN](#YEAR_BEGIN)
* [GetExchangeRate](#GetExchangeRate)
* [SERVER_DATE](#SERVER_DATE)
* [FormatDDMMYY, FormatDDMMYYYY, FormatYYYYMMDD](#FormatDDMMYY-FormatDDMMYYYY-FormatYYYYMMDD)
* [CurrencyFormat](#CurrencyFormat)
* [FormatToPrint](#FormatToPrint)
* [TryAddAtomicAsync, TryAddAtomic](#TryAddAtomicAsync-TryAddAtomic)
* [InList](#InList)
* [GetBranchParam](#GetBranchParam)
* [AcName, AcEName](#AcName-AcEName)
* [LoadAccountDescByCode](#LoadAccountDescByCode)
* [CliName CliEName](#CliName-CliEName)
* [GetAccCodeByAgrISN](#GetAccCodeByAgrISN)
* [GetPerSumPayDate, GetAgrSumPayDate](#GetPerSumPayDate-GetAgrSumPayDate)  
* [GetCollateralISNsByAgrNum](#GetCollateralISNsByAgrNum)
* [GetLinkedMortSum, GetLinkedGuarSum](#GetLinkedMortSum-GetLinkedGuarSum)
* [GetRating](#GetRating)
* [GetRatingCode](#GetRatingCode)
* [ExistsContractByCliISN, ExistsContractByCliCode](#ExistsContractByCliISN-ExistsContractByCliCode)
* [GetAgrTypeByISN](#GetAgrTypeByISN)
* [GetAllDayAgrJ](#GetAllDayAgrJ)
* [GetAllDayJCount](#GetAllDayJCount)
* [GetDayAgrJ](#GetDayAgrJ)
* [GetDayPerJ](#GetDayPerJ)
* [MaxOverdueDaysCount](#MaxOverdueDaysCount)
* [GetContractISN](#GetContractISN)
* [LoadClientDocRO](#LoadClientDocRO)
* [YEAR_END](#YEAR_END)
* [CurrencyName](#CurrencyName)
* [CurrencyISOCode](#CurrencyISOCode)
* [CliName](#CliName)
* [CliEName](#CliEName)
* [GetPenJDaysCount](#GetPenJDaysCount)
* [GetPerFutur](#GetPerFutur)
* [GetFutAgrDbt](#GetFutAgrDbt)
* [GetPerSumJ](#GetPerSumJ)
* [GetAgrSumJ](#GetAgrSumJ)




  
* [Պայմանագրերի հաշվառումների կոդեր](#պայմանագրերի-հաշվառումների-կոդեր)
* [Հաշվառումների գործողությունների կոդեր](#հաշվառումների-գործողությունների-կոդեր)
  



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

* `agrType`- Պարտադիր։ Ենթահամակարգի տեսակ` C, D, M, N, B, Q։
* `agrCode`- Պարտադիր։ Պայմանագրի համար։
* `agrLevelCheck`- Ոչ պարտադիր։ Հնարավոր արժեքներն են ՝"AGRPARENTS", "AGREEMENTS", "AGRCHILDREN"։ Որտեղ AGRPARENTS = 2 Մայր-պայմանագրեր, AGREEMENTS = 2 Պայմանագրեր, AGRCHILDREN = 0 Պարզ պայմանագրեր։ Լռությամբ՝ ""։ Սահմանված լինելու դեպքում, կստուգվի արդյոք փնտրվող պայմանագիրը համապատասխանում է սահմանված մակարդակին։ Չբավարարելու դեպքում ֆունկցիան կվերադարձնի -1։

> [!TIP]
> ՀԾ-Բանկ համակարգում ենթահամակարգերի կոդերը հնարավոր է դիտել SubSys ծառում (այն հասանելի է "Ադմինիստրատորի ԱՇՏ 4.0" &#8594; "Համակարգային աշխատանքներ" &#8594; "Համակարգային նկարագրություններ" տեղեկատուի մեջ։ Ծառը դիտելու համար անհրաժեշտ է կոնտեքստային մենյուի մեջ գործարկել "Բացել ծառը" հրամանը)։
<br>

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
Վերադարձնում է հաճախորդի հիմնական դաշտերը պարունակով օբյեկտ ըստ հաճախորդի կոդի։ 

**Պարամետրեր**

* `code` - Պարտադիր։ Հաճախորդի կոդ։

```c#
Օրինակում ստանում ենք 00006473 կոդով հաճախորդի հեռախոսահամարը։
ClientDesc cl = await proxyService.LoadClientDescByCode("00006473");
proxyService.TryAddAtomic("param1", () => cl.Tel.ToString(), templateSubstitutionArgs);
```



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


## CalculateOlapFormula

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

Բերված օրինակում ստանում ենք մարզերի տեղեկատուի 001 կոդով հանգույցի անվանումը օգտագործելով քեշավորված տվյալները։  

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
* `useCache` = Ոչ պարտադիր։ Վերադարձնել քեշավորված արժեքը։ Լռությամբ՝ true: Լռությամբ քեշի թարմացումը տեղի է ունենում 10 րոպեն մեկ, սակայն այդ ժամանակահատվածը հնարավոր է փոփոխել խմբագրելով appsettings.json ֆայլը (CacheRefreshPeriods պարամետր)։ false արժեքի դեպքում տվյալները կվերցվեն տվյալների բազայից։


## TreeElPropEComment

```c#
public async Task<string> TreeElPropComment(string treeId, string key, bool useCache = true)
```

Վերադարձնում է սահմանված կոդով, ծառ-տեղեկատուի հանգույցի անգլերեն անվանումը։ 

**Պարամետրեր**

* `treeId`- Պարտադիր։ Ծառի ներքին անվանումը։
* `key` - Պարտադիր։ Հանգույցի կոդը։
* `useCache` = Ոչ պարտադիր։ Վերադարձնել քեշավորված արժեքը։ Լռությամբ քեշի թարմացումը տեղի է ունենում 10 րոպեն մեկ, սակայն այդ ժամանակահատվածը հնարավոր է փոփոխել խմբագրելով appsettings.json ֆայլը (CacheRefreshPeriods պարամետր)։ false արժեքի դեպքում տվյալները կվերցվեն տվյալների բազայից։


## FolderElProp

```c#
public Task<FolderElement> FolderElProp(string folderId, string key, bool noLock = true)
```

Վերադարձնում է FolderElement տիպի օբյեկտ ըստ ֆոլդեռի անվան և բանալու։ Ֆոլդեռները գրանցվում են հիմնական բազայի FOLDERS աղյուսակում։

**Պարամետրեր**

* `folderId`- Պարտադիր։ Ծառի ներքին անվանումը։ Համապատասխանում է FOLDERS աղյուսակի fFOLDERID դաշտին։
* `key` - Պարտադիր։ Հանգույցի կոդը։ Համապատասխանում է FOLDERS աղյուսակի fKEY դաշտին։
* `noLock` = Ոչ պարտադիր։ Լռությամբ՝ true: false արժեքի դեպքում հաշվարկի ժամանակ տվյալների փոփոխման տրանզակցիաների առկայության դեպքում տվյալների ստացումը կկատարվի նրանց ավարտից հետո ապահովվելով նրանց վերջնական վիճակը։ true արժեքի՝ հակառակը։ Վերջինի դեպքում աշվարկը կկատարվի ավելի արագ։

Բերված օրինակում ստանում ենք վարկային պայմանագրի ընթացիկ գրաֆիկի ISN -ը, պայմանագրի թղթապանակից։ Agr.243335599 -ն հանդիսանում է 243335599 ISN -ով պայմանագրի թղթապանակը, C1TSDtUn -ն հանդիսանում է թղթապանակում ընթացիկ գրաֆիկի բանալին։

```c#
int schedISN = (await proxyService.FolderElProp("Agr.243335599", "C1TSDtUn")).ISN;
```



## FolderElPropSpec

```c#
public async Task<string> FolderElPropSpec(string folderId, string key, bool noLock = true)
```

Վերադարձնում է FOLDERS աղյուսակի fSPEC դաշտի արժեքը ըստ ֆոլդեռ-ի անվան և հղման բանալու։

**Պարամետրեր**

* `folderId`- Պարտադիր։ Ծառի ներքին անվանումը։ Համապատասխանում է FOLDERS աղյուսակի fFOLDERID դաշտին։
* `key` - Պարտադիր։ Հանգույցի կոդը։ Համապատասխանում է FOLDERS աղյուսակի fKEY դաշտին։
* `noLock` - Ոչ պարտադիր։ Լռությամբ՝ true: false արժեքի դեպքում հաշվարկի ժամանակ տվյալների փոփոխման տրանզակցիաների առկայության դեպքում տվյալների ստացումը կկատարվի նրանց ավարտից հետո ապահովվելով նրանց վերջնական վիճակը։ true արժեքի՝ հակառակը։ Վերջինի դեպքում աշվարկը կկատարվի ավելի արագ։




## LoadContractDescByISN

```c#
public Task<ContractDesc> LoadContractDescByISN(int isn)
```
Վերադարձնում է ContractDesc տիպի օբյեկտ ըստ պայմանագրի ISN -ի, որը պարունակում է պայմանագրի հիմնական դաշտերը։

**Պարամետրեր**

* `isn`- Պարտադիր։ Պայմանագրի ISN։



## LoadContractDescByCode

```c#
public Task<ContractDesc> LoadContractDescByCode(string agrType, string code)
```
Վերադարձնում է ContractDesc տիպի օբյեկտ ըստ պայմանագրի համարի, որը պարունակում է պայմանագրի հիմնական դաշտերը։

**Պարամետրեր**

* `agrType` -  Պարտադիր։ Ենթահամակարգի տեսակ` C, D, M, N, B, Q։
* `code` - Պարտադիր։ Պայմանագրի համար։

> [!TIP]
> ՀԾ-Բանկ համակարգում ենթահամակարգերի կոդերը հնարավոր է դիտել SubSys ծառում (այն հասանելի է "Ադմինիստրատորի ԱՇՏ 4.0" &#8594; "Համակարգային աշխատանքներ" &#8594; "Համակարգային նկարագրություններ" տեղեկատուի մեջ։ Ծառը դիտելու համար անհրաժեշտ է կոնտեքստային մենյուի մեջ գործարկել "Բացել ծառը" հրամանը)։
<br>



## GetAgrRem

```c#
public async Task<decimal> GetAgrRem(int isn, Rem accType, DateTime requestDate, string agrTypeName = null, string sourceCur = "", string targetCur  = "")
```
Վերադարձնում է պայմանագրի հաշվառման մնացորդը (ըստ բոլոր ենթապայմանագրերի)։

**Պարամետրեր**

* `isn` -  Պարտադիր։ Պայմանագրի ISN։
* `accType` - Պարտադիր։ Հաշվառման կոդ։ Սահմանվում է Subsystems.Enums.Accountings.Rem դասի համապատասխան հատկությունը։ Նշված դասի հատկությունների անվանումները համապատասխանում են [պայմանագրերի հաշվառման կոդերին](#պայմանագրերի-հաշվառումների-կոդեր)։
* `requestDate` - Պարտադիր։ Մնացորդի ամսաթիվ։
* `agrTypeName` - Ոչ պարտադիր։ Պայմանագրի փաստաթղթի տեսակ։ Լռությամբ՝ null: Սահմանելու դեպքում ֆունկցիայի կատարման ժամանակը կկրճատվի։
* `sourceCur` - Ոչ պարտադիր։ Լռությամբ ""։ Պայմանագրի մնացորդի արժույթի թվային կոդը։ Օրինակ՝ "000", "001"։ Կիրառվում է `targetCur` պարամետրի հետ միասին։ 
* `targetCur ` - Ոչ պարտադիր, Լռությամբ ""։ Վերահաշվակվի արժույթի թվային կոդը։ Օրինակ՝ "000", "001"։ Այս պարամետրը սահմանվում է `sourceCur` պարամետրի հետ միասին։ Սահմանված լինելու դեպքում մնացորդը կվերահաշվարկվի ըստ տվյալ արժույթի համար `requestDate` ապարամետրով սահմանված ամսաթվով ՀՀ ԿԲ հաշվարկային փոխարժեքի։ Սահմանված չլինելու դեպքում գումարը կվերադարձվի հաշվառման արժությով։


Բերված օրինակում կհաշվարկվի 653013562 ISN-ով, ԱՄՆ- դոլարով պայմանագրի մնացորդը 13/08/24 -ի դրությամբ վերահաշվարկված ԵՎՐՈ-ով։
```c#
decimal agrRem = await proxyService.GetAgrRem(653013562, Subsystems.Enums.Accountings.Rem.R1, DateTime.Parse("2024-08-13"), "C1Univer", "001", "049");
```



## GetAgrTurn

```c#
public Task<decimal> GetAgrTurn(int isn, DateTime startDate, DateTime endDate, Rem accType,
                                               string accOp, string dbCr, string opCur = "", string convertCur = "")
```
Վերադարձնում է պայմանագրի շրջանառաությունը ըստ սահմանված գործողության տեսակի (բոլոր ենթապայմանագրերով) և ժամանակահատվածի։

**Պարամետրեր**

* `isn` -  Պարտադիր։ Պայմանագրի ISN։
* `startDate` - Պարտադիր։ Սկզբի ամսաթիվ։
* `endDate` - Պարտադիր։ Վերջի ամսաթիվ։
* `accType` - Պարտադիր։ Հաշվառման կոդ։
* `accOp` - Պարտադիր։ [Գործողության կոդ](#հաշվառումների-գործողությունների-կոդեր)։ 
* `dbCr` - Պարտադիր։ Լրացվում է "D" եթե տվյալ գործողության արդյունքում տեղի է ունենում հաշվառման ավելացում և "C" նվազման դեպքում։
* `opCur` - Ոչ պարտադիր։ Լռությամբ ""։ Գործողության կատարման արժույթի թվային կոդը։ Օրինակ՝ "001", "000" Կիրառվում է `convertCur` պարամետրի հետ միասին։ Սահմանված չլինելու դեպքում գումարը կվերադարձվի գործողության արժույթով։
* `convertCur` - Ոչ պարտադիր։ Լռությամբ ""։ Վերահաշվակվի արժույթի թվային կոդը։ Այս պարամետրը սահմանվում է `opCur` պարամետրի հետ միասին։  Սահմանված չլինելու դեպքում գումարը կվերադարձվի գործողության արժույթով։

Բերված օրինակում հաշվարկվում է 812735354 ISN-ով, դրամային պայմանագրի գծով, սահմանված ժամանակահատվածում կատարված տրամադրումների ընդհանուր գումարը վերահաշվարկված ԱՄՆ դոլարի։

```c#
decimal agrRem = await proxyService.GetAgrTurn(812735354, DateTime.Parse("2009-07-10"), DateTime.Parse("2009-07-25"), Subsystems.Enums.Accountings.Rem.R1,"AGR","D", "000", "001");
```




## GetSSFactValueDate GetSSFactValueString GetSSFactValueInt GetSSFactValueDecimal GetSSFactValuePercent GetSSFactValueStringDecimal

```c#
public Task<string> GetSSFactValueString(int isn, NoRem accType, string accOp, DateTime requestDate)

public Task<int?> GetSSFactValueInt(int isn, NoRem accType, string accOp, DateTime requestDate)

public Task<decimal?> GetSSFactValueDecimal(int isn, NoRem accType, string accOp, DateTime requestDate)

public Task<InterestRate> GetSSFactValuePercent(int isn, NoRem accType, string accOp, DateTime requestDate)

```

Ֆունկցիաները վերադարձնում են պայմանագրի, սահմանված ամսաթվով, ոչ [ոչ մնացորդային հաշվառումների](#ոչ-մնացորդային-հաշվառումներ) արժեքները։

**Պարամետրեր**

* `isn` -  Պարտադիր։ Պայմանագրի ISN։
* `accType` - Պարտադիր։ Հաշվառման կոդ։ Սահմանվում է Subsystems.Enums.Accountings.Rem դասի համապատասխան հատկությունը։ Նշված դասի հատկությունների անվանումները համապատասխանում են [պայմանագրերի հաշվառման կոդերին](#պայմանագրերի-հաշվառումների-կոդեր)։
* `accOp` - Պարտադիր։ Սահմանվում է Subsystems.Enums.Accountings.NoRem դասի համապատասխան հատկությունը։ Նշված դասի հատկությունների անվանումները համապատասխանում են [գործողությունների կոդերին](#հաշվառումների-գործողությունների-կոդեր)։ 
* `requestDate` - Պարտադիր։ Մնացորդի ամսաթիվը։

Բերված օրինակում ստանում ենք 812735354 ISN -ով պայմանագրի տոկոսադրույքը 15/08/24 ամսաթվի դրությամբ։ 

```c#
deciaml perc = (await proxyService.GetSSFactValuePercent(812735354, Subsystems.Enums.Accountings.NoRem.N0, "PAG", DateTime.Parse("2024-08-15"))).Rate;
```



## GetAgrFactValueDate GetAgrFactValuePercent GetAgrFactValueDecimal GetAgrFactValueString

```c#
public Task<DateTime?> GetAgrFactValueDate(int isn, NoRem accType, string accOp, DateTime requestDate, MinMax minMax, bool 
                                                  onlyOpenChildren, string agrTypeName)
public Task<InterestRate> GetAgrFactValuePercent(int isn, NoRem accType, string accOp, DateTime requestDate, MinMaxLast 
                                                  minMaxLast, bool onlyOpenChildren, string agrTypeName)
public Task<decimal?> GetAgrFactValueDecimal(int isn, NoRem accType, string accOp, DateTime requestDate, MinMax minMax, 
                                                  bool onlyOpenChildren, string agrTypeName)
public Task<string> GetAgrFactValueString(int isn, NoRem accType, string accOp, DateTime requestDate, MinMax minMax, bool 
                                                   onlyOpenChildren, string agrTypeName)
```
Ֆունկցիաները վերադարձնում են պայմանագրի, սահմանված ամսաթվով, ոչ [ոչ մնացորդային հաշվառումների](#ոչ-մնացորդային-հաշվառումներ) արժեքները։
Ի տարբերություն GetSSFactValue անվամբ սկսվող ֆունկցիաների այս ֆունկցիաները նախատեսված են բարդ պայմանագրերի հետ աշխատելու համար։ Կապված 
MinMax, MinMaxLast enum -ների արժներից վերադարձվող արժեքները կարող են լինել ենթապայմանագրի գծով, սահմանված ամսաթվով, առավելագույն (MinMax.Max, MinMaxLast.Max) նվազագույն (MinMax.Min, MinMaxLast.Min) կամ վերջին նշակաված արժեքները (MinMaxLast.Last)։ 


**Պարամետրեր**

* `isn` -  Պարտադիր։ Պայմանագրի ISN։
* `accType` - Պարտադիր։ Հաշվառման կոդ։ Սահմանվում է Subsystems.Enums.Accountings.Rem դասի համապատասխան հատկությունը։ Նշված դասի հատկությունների անվանումները համապատասխանում են [պայմանագրերի հաշվառման կոդերին](#պայմանագրերի-հաշվառումների-կոդեր)։
* `accOp` - Պարտադիր։ Սահմանվում է Subsystems.Enums.Accountings.NoRem դասի համապատասխան հատկությունը։ Նշված դասի հատկությունների անվանումները համապատասխանում են [գործողությունների կոդերին](#հաշվառումների-գործողությունների-կոդեր)։ 
* `requestDate` - Պարտադիր։ Մնացորդի ամսաթիվը։
* `MinMax`, `MinMaxLast` - Պարտադիր։ Նվազագույն, առավելագույն կամ վերջին նշանակված արժեքը ըստ ենթապայմանագրերի։
* `onlyOpenChildren` - Պարտադիր։ Դիտարկել միայն հարցման ամսաթվով գործող ենթապայմանագրերը։
* `agrTypeName` - Ոչ պարտադիր։ Հասանելի չէ GetAgrFactValueDate ֆունկցիայի համար։ Սահմանվում է `isn` պարամետրով սահմանված պայմանագրի փաստաթղթի տեսակը։ 

Բերված օրինակում ստանում ենք 307245031 ISN -ով բարդ պայմանագրի ենթապայմանագրերի գծով 29/12/24 ամսաթվի դրությամբ նշանակված վերջին տոկոսադրույքը։ 

```c#
deciaml perc = ( await proxyService.GetAgrFactValuePercent(307245031, Subsystems.Enums.Accountings.NoRem.N0, "PAG", DateTime.Parse("2024-12-29"), MinMaxLast.Last, true, "C1Compl")).Rate;
```



## GetRemSS

```c#
public Task<decimal> GetRemSS(int isn, Rem accType, DateTime requestDate)
```

Վերադարձնում է պայմանագրի մնացորդը։ Չի նախատեսված բարդ պայմանագրերի համար։ Բարդ պայմանագրերի ենթապայմանագրերի հաշվառումների մնացորդների ստացման համար նախատեսված է [GetAgrRem](#GetAgrRem) ֆունկցիան։

**Պարամետրեր**

* `isn` -  Պարտադիր։ Պայմանագրի ISN։
* `accType` - Պարտադիր։ Հաշվառման կոդ։ Սահմանվում է Subsystems.Enums.Accountings.Rem դասի համապատասխան հատկությունը։ Նշված դասի հատկությունների անվանումները համապատասխանում են [պայմանագրերի հաշվառման կոդերին](#պայմանագրերի-հաշվառումների-կոդեր)։
* `requestDate` - Պարտադիր։ Մնացորդի ամսաթիվը։



## GetRemHI2
```c#
  public Task<(decimal CRem, decimal NCRem)> GetRemHI2(string accounting, int isn = -1,
                                                  int isnGl = -1, DateTime? remDate = null)
```
Օգտագործվում է, միաժամանակ երկու օբյեկտի հետ կապակցված հաշվառումների մնացորդները ստանալու համար։ Օրինակ HA - "Ռեպո համ-ով ձեռք բերված արժ.հակ.ռեպոյով վաճառված մաս" հաշվառումը զուգահեռ կապված է արժեթղթի և ռեպո պայմանագրերի հետ։ Բոլոր նմանատիպ հաշվառումների շրջանառությունը գրանցվում է HI2 աղյուսակում (իսկ սկզբնական և վերջնական հասանելի մնացորդները HIREST2 աղյուսակում)։ Այս ֆինկցիայով որոշակի հաշվառման մնացորդի ստացման հնարավորությունը կարելի է ստուգել տվյալ հաշվառման առկայությամբ HI2 կամ HIREST2 աղյուսակներում (fTYPE դաշտ)։ 

Մնացորդի հաշվարկը կատարվում է HI2-ում գրանցված շրջանառության և HIREST2-ի սկզբնական և վերջնական մնացորդների հիման վրա։  Ֆունկցիան վերադարձնում է tuple երկու արժեքով՝ մնացորդ արժույթով (հաշվարկվում է HIREST2 աղյուսակի fCURREM և HI2 աղյուսակի fCURSUM դաշտերի միջոցով) և մնացորդ ՀՀ դրամով (fSUM / fREM դաշտեր)։ 

HI2 / HIREST2 աղյուսակներում  fCURSUM, fSUM / fCURREM, fREM  դաշտերի լրացումը կատարվում է հաշվի առնելով իրագործման առանձնահատկությունները, որի պատճառով հնարավոր են դեպքեր երբ դաշտերից մեկն է լրացված։



**Պարամետրեր**

* `accounting` -  Պարտադիր։ Հաշվառման կոդը։
* `isn` -   Ոչ Պարտադիր։ Համապատասխանում է HI2 աղյուսակի fOBJECT դաշտի արժեքին: 
* `isnGl ` - Ոչ պարտադիր։ Համապատասխանում է HI2 աղյուսակի fGLACC դաշտի արժեքին:
* `remDate` - Ոչ պարտադիր։ Մնացորդի ամսաթիվ։ Նշված չլինելու դեպքում կվերադարձվի վերջին գրանցված մնացորդը։

> [!IMPORTANT]
> Ֆունկցիան կանչելիս անհրաժեշտ է փոխանցել առնվազն `isn` կամ `isnGl` պարամետրերից մեկը։


Ստորև բերված օրինակում հաշվարկվում է 13047440 ISN -ով հաճախորդի քարտի գծով 100095 ISN -ով արժույթով (տվյալ դեպքում ՀՀ դրամ) կանխիկի հաշվառման ("10") մնացորդը 06/12/2018-ով։
```c#
(decimal CRem, decimal NCRem) = (await proxyService.GetRemHI2("10", 13047440, 100095,  DateTime.Parse("2018-12-06")));
```

<br>

## SSLastOpDate

```c#
  public Task<(DateTime? Date, string Time)> SSLastOpDate(int isn, NoRem accType, DateTime requestDate,
                                                              string accOp = "", int baseISN = -1)
  public Task<DateTime?> SSLastOpDate(int isn, Rem accType, DateTime requestDate,
                                                              string accOp = "", int baseISN = -1)
  public Task<DateTime?> SSLastOpDate(int isn, Turn accType, DateTime requestDate,
                                                              string accOp = "", int baseISN = -1)
```

ֆունկցիան ունի կանչի երեք տարբերակ, որոնք  վերադարձնում են սահմանված գործողության վերջին կատարման ամսաթիվը (ոչ մնացորդային հաշվառումների գործողությունների դեպքում նաև որոշ դեպքերում ժամանակը)։ 

Վերևում բերված կանչի տարբերակները նախատեսված են ստանալու

1. Ոչ մնացորդային հաշվառումների գծով կատարված վերջին գործողության ամսաթիվն ու ժամը։
2. Մնացորդային հաշվառումների գծով կատարված վերջին գործողության ամսաթիվը։
3. HIT աղյուսակում գրանցվող հաշվառումների գծով կատարված վերջին գործողության ամսաթիվը։ նշված հաշվառումները հիմնականում վերաբերվում են տոկոսների, տույժերի հաշվեգրումներին և սկսվում են N-ով (բացառությամբ N0)։ Օրինակ՝ N2, N3: Տոկոսների տույժերի մնացորդային հաշվառումներից տարբերվում են նրանով որ այս դեպքում նրանց գրանցումը կատարվում է հաշվարկման ամսաթվով այլ ոչ թե ձևակերպման։ Օրինակ ՝ կիրակի օրվա տոկոսի կուտակումը, որը ձևակերպվել է երկուշաբթի օրով R2 մնացորդային հաշվառման դեպքում կգրանցվի երկուշաբթի օրով, այն դեպքում երբ N2 հաշվառման դեպքում կիրակի օրվա ամսաթվով։


**Պարամետրեր**

* `isn` -   Պարտադիր։ Փաստաթղթի ISN։ 
* `accType` -  Պարտադիր։ Հաշվառման կոդը, որը համապատասխանում է՝ ArmSoft.AS8X.Bank.Subsystems.Enums.Accountings.NoRem, ArmSoft.AS8X.Bank.Subsystems.Enums.Accountings.Rem կամ ArmSoft.AS8X.Bank.Subsystems.Enums.Accountings.Turn enum-ների արժեքներից մեկին։  
* `requestDate` - Պարտադիր։ Ամսաթիվը, որին նախորդող մոտոկա գործողության ամսաթիվն պետք է գտնել։ 
* `accOp` - Ոչ պարտադիր։ Սահմանված հաշվառման [գործողության կոդը](#hաշվառումների-գործողությունների-կոդեր)։ Նշված չլինելու դեպքում կվերադարձվի տվյալ հաշվառման գծով վերջին կատարված ցանկացած գործողության ամսաթիվը։
* `baseISN` - Ոչ պարտադիր։ Հնարավոր է սահմանել գործողության փաստաթղթի ISN -ը, որը պետք է անտեսել ֆունկցիայի աշխատանքի ժամանակ։


```c#
// Հաշվարկվում է 28/01/2024-ին նախորդող տտկոսների հաշվարկման վերջին ամսաթիվը 
    DateTime? opDate = await proxyService.SSLastOpDate(812735354, Turn.N2, DateTime.Parse("2024-01-28"), "N2");

// Հաշվարկվում է 28/01/2024-ին նախորդող տտկոսների ձևակերպման վերջին ամսաթիվը 
    DateTime? opDate2 = await proxyService.SSLastOpDate(812735354, Rem.R2, DateTime.Parse("2024-01-28"), "PER");

/* Հաշվարկվում է 28/01/2024-ին նախորդող տոկոսադրույքի վերանայման ամսաթիվը։ Տվյալ դեպքում անտեսում ենք ֆունկցիայի
կողմից վերադարձվող գործողության ժամը, որը հասանելի է միայն հետևյալ գործողությունների դեպքում (LIM - Սահմանաչափ,
DUA - Պայմանագրի ժամկետ, PNE - Բանկի արդյունավետ տոկոսադրույք)։ */
    DateTime? opDate3 = (await proxyService.SSLastOpDate(812735354, NoRem.N0, DateTime.Parse("2024-01-28"), "PAG")).Item1;
 
```
## AgrSchedule

```c#
public Task<List<AgrScheduleRow>> AgrSchedule(int isn, DateTime requestDate, ScheduleValueType valueType, ScheduleBasis schKind = ScheduleBasis.Any)
```
Ֆունկցիան կիրառելի է միայն Univer տեսակի պայմանագրերի համար։ Վերադարձնում է AgrScheduleRow տիպի օբյեկտների ցուցակ (List), որտեղ յուրաքանչյուր էլեմենտը պարունակում է հետևյալ հատկությունները՝

* `Date` 
* `Summa`

**Պարամետրեր**

- `isn` - Պարտադիր։ Փաստաթղթի ISN։
- `requestDate` -Պարտադիր։ Ամսաթվիվ, որի դրությամբ պահանջվում է ստանալ ընթացիկ գրաֆիկը 
- `valueType` - Պարտադիր։ Հնարավոր արժեքներն են՝
    ``` c#
      public enum ScheduleValueType : short
      {
          Agr = 1, // մայր գումարի գրաֆիկ
          Base = 11, // հիմնական ամսաթվերի գրաֆիկ 
          Per = 2, // տոկոսների գրաֆիկ
          PerProl = 22, // երկարաձգված տոկոսների գրաֆիկ
          ServFee = 7, // վարձավճարի գրաֆիկ
          ServFeeProl = 27, // երկարաձգված վարձավճարի գրաֆիկ
          Lim = 6, // սահմանաչափի գրաֆիկ
          Dis = 8 զեղջատոկոսի գրաֆիկ  
      }

- `schKind` - Ոչ պարտադիր։ Հնարավոր արժեքներն են՝
     ``` c#
          public enum ScheduleBasis : short
          {
              Any = -2, // Կամայական: Լռությամբ արժեք։ 
              AnySchRevision = -1,   // Կամայական վերանայում  0, 9, 10, 11, 12, 13, 14, 15
              RevisionProl = 0, // Վերանայում (Համարելով երկարաձգված)
              RevisionNotProl = 9, // Վերանայում (Չհամարելով երկարաձգված)
              RevisionProlNotLR = 10, // Վերանայում (Չհամարելով երկարաձգված միայն ՎՌ-ում)
              RevDisbNotProl = 13, // Վերանայումով տրամադրում (Համարելով երկարաձգված)
              RevDisbProl = 14, // Վերանայումով տրամադրում (Չհամարելով երկարաձգված)
              RevDisbProlNotLR = 15, // Վերանայումով տրամադրում (Չհամարելով երկարաձգված միայն ՎՌ-ում)
              InterestRate = 1, // Տոկոսադրույքի փոփոխություն
              Repayment = 2,   // Մարում
              Disbursement = 3, // Տրամադրում
              InterestAdjustment = 4, // Տոկոսագումարի ճշգրտում
              SecurityOut = 5,   // Արժեթղթի ելք
              SecurityIn = 6,   // Արժեթղթի մուտք
              InterestAccum = 7, // Տոկոսների հաշվարկում
              LimitSchRevision = 11, // Սահմանաչափի գրաֆիկի վերանայում
              WorkingDayChange = 12, // Ոչ աշխատանքային օրերի փոփոխում
              IntAccumStartDate = 16, // Տոկոսների հաշվարկման սկզբի ամսաթիվ
              EndOfLease = 17, // Վարձակալության ավարտ
              EmergIntProlong = 22 // Տոկոսների արտակարգ երկարաձգում
          }   
          
          ```

``` c#

// Օրինակում հաշվարկվում է 1433755346 isn -ով պայմանագրի, 21/01/20-ի դրությամբ գործող գրաֆիկում առկա տոկոսագումարների հանրագումարը։

      List<ScheduleRow> sched = await proxyService.AgrSchedule(1433755346, DateTime.Parse("2020-01-21"), ScheduleValueType.Per);
      decimal PerSum = 0;
      foreach (ScheduleRow sc in sched)
      {
          PerSum += sc.Sum;
      }

```

## GetFutPerDbt

```c#
public Task<decimal> GetFutPerDbt(int agrISN, DateTime dateStart, DateTime dateEnd)
```

Վերադարձնում է Univer տեսակի պայմանագրի, նշված ժամանակահատվածում ընկած, մարման ենթակա տոկոսագումարը հաշվի առնելով տոկոսագումարի կանխավճարը։

**Պարամետրեր**

* `agrISN` - Պարտադիր։ Պայմանագրի ISN։
* `dateStart` - Պարտադիր։ Սկզբի ամսաթիվ։
* `dateEnd` - Պարտադիր։ Վերջի ամսաթիվ։



## GetFutServFeeDbt

```c#
 public Task<decimal> GetFutServFeeDbt(int agrISN, DateTime begDate, DateTime endDate)
```

Վերադարձնում է Univer տեսակի պայմանագրի, նշված ժամանակահատվածում ընկած, մարման ենթակա վարձավճարը հաշվի առնելով վարձավճարի կանխավճարը։

**Պարամետրեր**

* `agrISN` - Պարտադիր։ Պայմանագրի ISN։
* `dateStart` - Պարտադիր։ Սկզբի ամսաթիվ։
* `dateEnd` - Պարտադիր։ Վերջի ամսաթիվ։



## GetPCardData
```c#
 public Task<Dictionary<string, object>> GetPCardData(string fieldList,
                                 string cardNum = "",
                                 string cardAcc = "",
                                 long isn = 0,
                                 bool includeClosed = true,
                                 bool throwException = true)
```
Վերադարձնում է dictionary, որը պարունակում է վճարային քարտի fieldList պարամետրով փոխանցված CARDS աղյուսակի դաշտերի արժեքներով։ Պլաստիկ քարտի փնտրումը հնարավոր է իրականացնել՝ քարտի համարով, քարտային հաշվով կամ isn- ով։

**Պարամետրեր**

* `fieldList` - Պարտադիր։ CARDS աղյուսակի դաշտերի անվանումները բաժանված ստորակետով որոնք անհրաժեշտ է վերադարձնել։
* `cardNum` - Ոչ պարտադիր։ Քարտի համար։
* `cardAcc` - Ոչ պարտադիր։ Քարտի հաշիվ:
* `isn` - Ոչ պարտադիր։ Քարտի isn: 
* `includeClosed` - Ոչ պարտադիր։ Փնտրել նաև փակվածների մեջ։ Լռությամբ փնտրվում է։
* `throwException` - Ոչ պարտադիր։ Սահմանված պայմաններով քարտ չգտնելու դեպքում բերել սխալի հաղորդագրություն։ Լռությամբ՝ այո։


```c#
using System.Collections.Generic;

//Ստանում ենք 80662376 isn ով վճարային քարտի արժույթը և հաճախորդի կոդը պարունակով dictionary: 
Dictionary<string, object> pcard = await proxyService.GetPCardData("fCUR, fCLICODE", isn: 80662376);


await proxyService.TryAddAtomicAsync("param1", async () => (string) pcard["fCUR"], templateSubstitutionArgs);
await proxyService.TryAddAtomicAsync("param2", async () => (string) pcard["fCLICODE"], templateSubstitutionArgs);

```

## GetPCardDoc
```c#
public Task<Card> GetPCardDoc(string cardNum = "", string cardAcc = "", bool throwException = true)
```

Վերադարձնում է պլաստիկ քարտի փաստաթղթի օբյեկտը քարտի համարով կամ քարտային հաշվի միջոցով։

**Պարամետրեր**

* `cardNum` - Ոչ պարտադիր։ Քարտի համարը։
* `cardAcc` - Ոչ պարտադիր։ Քարտային հաշիվ։
* `throwException` - Ոչ պարտադիր։ Բերել սխալի հաղորդագրություն փնտրվող պայմաններով քարտի բացակայության դեպքում։ Լռությամբ true:

## AsCCur

```c#
public static decimal AsCCur(string stringValue)
```
Վերափոխում է տողով (string) փոխանցված թիվը տասնորդական թվի (decimal)։ Դատարկ տող փոխանցելու դեպքում կրերադարձվի 0։ 

**Պարամետրեր**

* `stringValue` - Պարտադիր։ Թիվ պարունակով տող։

``` c#
decimal cur = UserProxyService.AsCCur("158832.26");
```

## DealRate

```c#
public decimal DealRate(string curCode1, string curCode2, string pusa, string cash, DateTime calcdate, string sMaxCreationDate = "")
```

Վերադարձնում է տրված արժույթների համար սահմված կանխիկ / անկանխիկ, առքի / վաճառքի դիլինգային փոխարժեքները։ Հնարավոր է սահմանել նաև ժամանակը, որի դրությամբ գործող փոխարժեքները անհրաժեշտ է վերադարձնել։

**Պարամետրեր**

* `curCode1` - Պարտադիր։ Արժույթ 1։
* `curCode2` - Պարտադիր։ Արժույթ 2։
* `pusa` -  Պարտադիր։ Առք / վաճառք։ Հնարավոր արժեքներն են՝ 1 - առք, 2 - վաճառք։
* `cash` -  Պարտադիր։ Կանխիկ / անկանխիկ։ Հնարավոր արժեքներն են՝ 0 - կանխիկ, 1 - անկանխիկ։
* `calcdate` - Պարտադիր։ Փոխարժեքի ամսաթիվ։ 
* `sMaxCreationDate` - Ոչ պարտադիր։ Օգտագործվում է այն ժամանակ երբ նույն օրվա ընթացքում սահմանվել են մի քանի փոխարժեքներ և անհրաժեշտ է ստանալ սահմանված ժամին գործողը։

```c#
// Ստանում ենք ԱՄՆ դոլարի  առքի և վաճառքի, կանխիկի և անկանխիկի համար սահմանված ՀՀ դրամով փոխարժեքը, որոնք գործել են   05/09/24-ի 15։00 դրությամբ։

decimal CashBuyRate = proxyService.DealRate("001", "000", "1", "0", DateTime.Parse("2024-09-05"), "2024-09-05 15:00");
decimal NonCashBuyRate = proxyService.DealRate("001", "000", "1", "1", DateTime.Parse("2024-09-05"), "2024-09-05 15:00");
decimal CashSellRate = proxyService.DealRate("001", "000", "2", "0", DateTime.Parse("2024-09-05"), "2024-09-05 15:00");
decimal NonCashSellRate = proxyService.DealRate("001", "000", "2", "1", DateTime.Parse("2024-09-05"), "2024-09-05 15:00");

```

## SumInWordsAsync

```c#
public async Task<string> SumInWordsAsync(decimal value, string integerCurrency = "", string precisionCurrency = "", bool toUpperFirstChar = true, bool isArmenian = true, bool isUnicode = false)
```

Վերադարձնում է գումարը բառերով հայերեն կամ անգլերեն լեզվով։

**Պարամետրեր**

* `value` - Պարտադիր։ Թիվը, որի համար անհրաժեշտ է ստանալ բառերեվ արտահայտությունը։
* `integerCurrency` - Ոչ Պարտադիր։ Արժույթի անվանումը պահանջվող լեզվով։  
* `precisionCurrency` - Ոչ Պարտադիր։ Մանրադրամի անվանումը պահանջվող լեզվով։ 
* `toUpperFirstChar` - Ոչ Պարտադիր։ Առաջին բառը գրել մեծատառով։ Լռությամբ true: 
* `isArmenian` - Ոչ պարտադիր։ Լռությամբ true: Տեքստը վերադարձնել հայերեն։ false արժեքի դեպքում տեքստը կարտացոլվի անգլերեն լեզվով։ 
* `isUnicode` - Ոչ պարտադիր։ Վերադարձնել Unicode կոդավորմամբ։ Լռությամբ true:

```c#
// Օրինակում վերադարձվում է գումարը բառերով անգլերեն ANSI կոդավորմամբ։
string sumInW = await proxyService.SumInWordsAsync(15.66m, "Dram", "Luma", isArmenian: false, isUnicode: false);
```

## WKDATE

```c#
public DateTime WKDATE()
```

Վերադարձնում է ՀԾ-Բանկ համակարգի դրույթներում սահմանված "ընթացիկ օրը"։

```c#
DateTime dt = proxyService.WKDATE();
```

## CURRENT_DATE

```c#
public DateTime CURRENT_DATE()
```

Վերադարձնում է ընթացիկ օրը և ժամը:

```
DateTime dt = proxyService.CURRENT_DATE();
```

## WEEK_BEGIN

```c#
public DateTime WEEK_BEGIN(object parDate = null)
```
Վերադարձնում է ընթացիկ կամ parDate պարամետրով փոխանցված ամսաթվի շաբաթվա առաջին օրվա ամսաթիվը։

**Պարամետրեր**

* `parDate` - Պարտադիր։ Ամսաթիվը, որի դրությամբ պետք է հաշվարկել շաբաթվա սկիզվը։

```c#
// Ստանում ենք ընթացիկ շաբաթվա առաջին օրը։
DateTime dt = proxyService.WEEK_BEGIN();
```


## WEEK_END

```c#
public DateTime WEEK_END(object parDate = null)
```

Վերադարձնում է ընթացիկ կամ parDate պարամետրով փոխանցված ամսաթվի շաբաթվա վերջին օրվա ամսաթիվը։

**Պարամետրեր**

* `parDate` - Պարտադիր։ Ամսաթիվը, որի դրությամբ պետք է հաշվարկել շաբաթվա վերջը։

```c#
// Ստանում ենք ընթացիկ շաբաթվա վերջին օրը։
DateTime dt = proxyService.WEEK_END();
```

## MONTH_BEGIN 

```c#
public DateTime MONTH_BEGIN(object parDate = null)
```

Վերադարձնում է parDate պարամետրով փոխանցած ամսաթվի կամ ընթացիկ ամսաթվի ամսվա առաջին օրը։

**Պարամետրեր**

* `parDate` - Պարտադիր։ Ամսաթիվը, որի դրությամբ պետք է հաշվարկել ամսվա սկիզվը։

```c#
// Ստորև բերված դեպքում կվերադրաձվի՝ 01/08/2024 0:00:00։  
DateTime dt = proxyService.MONTH_BEGIN(DateTime.Parse("2024-08-17"));
```

## MONTH_END 
```c#
public DateTime MONTH_END(object parDate = null)
```

Վերադարձնում է parDate պարամետրով փոխանցած ամսաթվի կամ ընթացիկ ամսաթվի ամսվա վերջին օրը։

**Պարամետրեր**

* `parDate` - Պարտադիր։ Ամսաթիվը, որի դրությամբ պետք է հաշվարկել ամսվա վերջը։

```c#
// Ստորև բերված դեպքում կվերադրաձվի՝ 31/08/2024 0:00:00։  
DateTime dt = proxyService.MONTH_END(DateTime.Parse("2024-08-17"));
```

## PREVIOUS_MONTH_BEGIN
```c#
public DateTime PREVIOUS_MONTH_BEGIN(object parDate = null)
```
Վերադարձնում է parDate պարամետրով փոխանցած կամ ընթացիկ ամսաթվին նախորդող ամսվա առաջին օրը։

**Պարամետրեր**

* `parDate` - Պարտադիր։ Ամսաթիվը, որի դրությամբ պետք է հաշվարկել նախորդ ամսվա սկիզվը։

```c#
// Ֆունկցիան կվերադարձնի 01/07/2024 0:00:00 ամսաթիվը։
DateTime dt = proxyService.PREVIOUS_MONTH_BEGIN(DateTime.Parse("2024-08-17"));
```

## PREVIOUS_MONTH_END
```c#
public DateTime PREVIOUS_MONTH_END(object parDate = null)
```
Վերադարձնում է parDate պարամետրով փոխանցած կամ ընթացիկ ամսաթվին նախորդող ամսվա վերջին օրը։

**Պարամետրեր**

* `parDate` - Պարտադիր։ Ամսաթիվը, որի դրությամբ պետք է հաշվարկել նախորդ ամսվա վերջը։

```c#
// Ֆունկցիան կվերադարձնի  31/07/2024 0:00:00 ամսաթիվը։
DateTime dt = proxyService.PREVIOUS_MONTH_END(DateTime.Parse("2024-08-17"));
```

## QUARTE_BEGIN
```c#
public DateTime QUARTE_BEGIN(object parDate = null)
```
Վերադարձնում է parDate պարամետրով փոխանցած կամ ընթացիկ ամսաթվի եռամսյակի սկզբի օրը։

**Պարամետրեր**

* `parDate` - Պարտադիր։ Ամսաթիվը, որի դրությամբ պետք է հաշվարկել եռամսյակի սկիզբը։

```c#
// Ֆունկցիան կվերադարձնի 01/08/2024 0:00:00 ամսաթիվը։
DateTime dt = proxyService.QUARTE_BEGIN(DateTime.Parse("2024-08-17"));
```

## QUARTE_END
```c#
public DateTime QUARTE_END(object parDate = null)
```
Վերադարձնում է parDate պարամետրով փոխանցած կամ ընթացիկ ամսաթվի եռամսյակի վերջին օրը։

**Պարամետրեր**

* `parDate` - Պարտադիր։ Ամսաթիվը, որի դրությամբ պետք է հաշվարկել եռամսյակի վերջը։

```c#
// Ֆունկցիան կվերադարձնի 30/09/2024 0:00:00 ամսաթիվը։
DateTime dt = proxyService.QUARTE_END(DateTime.Parse("2024-08-17"));
```

## PREVIOUS_QUARTE_BEGIN
```c#
public DateTime PREVIOUS_QUARTE_BEGIN(object parDate = null)
```
Վերադարձնում է parDate պարամետրով փոխանցած կամ ընթացիկ ամսաթվին նախորդող եռամսյակի սկզբի օրը։

**Պարամետրեր**

* `parDate` - Պարտադիր։ Ամսաթիվը, որի դրությամբ պետք է հաշվարկել նախորդող եռամսյակի սկիզբը։

```c#
// Ֆունկցիան կվերադարձնի 01/04/2024 0:00:00 ամսաթիվը։
DateTime dt = proxyService.PREVIOUS_QUARTE_BEGIN(DateTime.Parse("2024-08-17"));
```

## PREVIOUS_QUARTE_END
```c#
public DateTime PREVIOUS_QUARTE_END(object parDate = null)
```
Վերադարձնում է parDate պարամետրով փոխանցած կամ ընթացիկ ամսաթվին նախորդող եռամսյակի վերջին օրը։

**Պարամետրեր**

* `parDate` - Պարտադիր։ Ամսաթիվը, որի դրությամբ պետք է հաշվարկել նախորդող եռամսյակի վերջը։

```c#
// Ֆունկցիան կվերադարձնի 30/06/2024 0:00:00 ամսաթիվը։
DateTime dt = proxyService.PREVIOUS_QUARTE_END(DateTime.Parse("2024-08-17"));
```

## YEAR_BEGIN
```c#
public DateTime YEAR_BEGIN(object parDate = null)
```
Վերադարձնում է parDate պարամետրով փոխանցած կամ ընթացիկ ամսաթվի տարվա սկզբի օրը։

**Պարամետրեր**

* `parDate` - Պարտադիր։ Ամսաթիվը, որի դրությամբ պետք է հաշվարկել տարվա սկիզբը։

```c#
// Ֆունկցիան կվերադարձնի 01/01/2024 0:00:00 ամսաթիվը։
DateTime dt = proxyService.YEAR_BEGIN(DateTime.Parse("2024-08-17"));
```

## GetExchangeRate
```c#
public async Task<decimal> GetExchangeRate(string codCurrency, DateTime date, DateTime? maxCreationDate = null)
```
Վերադարձնում է ՀՀ ԿԲ հաշվարկային փոխարժեքը ըստ արժույթի և ամսաթվի։

**Պարամետրեր**

* `codCurrency` - Պարտադիր։ արժույթի կոդը։
* `date` - Պարտադիր։ Փոխարժեքի ամսաթիվը։
* `maxCreationDate` - Ոչ պարտադիր։ Սահմանվում է ամսաթիվը և ժամը, որի դրությամբ պետք է վերադարձնել գործող փոխարժեքը։ Օգտագործվում է այն դեպքում երբ մեկ օրվա ընթացքում սահմանվել է մի քանի փոխարժեք։
```c#
// Վերադարձվում է 06/09/24 -ի 15։12 դրությամբ գործող ԱՄՆ դոլարի հաշվարկային փոխարժեքը։
decimal cur = await proxyService.GetExchangeRate("001", DateTime.Parse("2024-09-06"), DateTime.Parse("2024-09-06 15:12"));
```

## SERVER_DATE
```c#
public async Task<DateTime> SERVER_DATE()
```

Վերադարձնում է տվյալների բազաների սերվերի անվանումը։

```c#
DateTime dt = await proxyService.SERVER_DATE();
```

## FormatDDMMYY FormatDDMMYYYY FormatYYYYMMDD
```C#
public string FormatDDMMYY(DateTime? date)
public string FormatDDMMYYYY(DateTime? date)
public string FormatYYYYMMDD(DateTime? date)
```
Վերադարձնում է ֆորմատավորված ամսաթվի տող։ Առաջին երկու դեպքերում տարեթիվը կարտացոլվի երկու, մյուս դեպքում չորս նիշերով։ Պարամետրի ՝null՝ արժեքի դեպքում կվերադարձվի դատարկ ամսաթվի ՝ " / / " տողը։ FormatYYYYMMDD ֆունկցիայի վերադարձրած տողի օրինակ է՝ "20240906"։ ՝null՝ արժեքի դեպքում տողը կունենա հետևյալ տեսքը՝ "00000000"

**Պարամետրեր**

* `date` - Ոչ պարտադիր։ Ամսաթվի օբյեկտը։


```C#
// Բերված օրինակում dt փոփոխականը կստանա ընթացիկ ամսաթվի տողը, օրինակ՝ "06/09/24"։ dt2 -ի արժեքը կլինի " / / "։ dt3 -ի արժեքը կլինի 20240906


DateTime dtObj = DateTime.Now;
string dt = proxyService.FormatDDMMYY(dtObj);
string dt2 = proxyService.FormatDDMMYYYY(null);
string dt3 = proxyService.FormatYYYYMMDD(dtObj);
```

## CurrencyFormat
```c#
public string CurrencyFormat(decimal value, short length = 20, short precision = 2)
```
Վերադարձնում է ֆորմատավորված գումարի տող։ Սահմանված երկարությունից նիշերի քանակը ավելի փոքր լինելու պակասող նիշերը ձախից կհամալրվեն բացատներով"

**Պարամետրեր**

* `value` - Պարտադիր։ Տասնորդական թիվ, որի համար ձևավորվում է ֆորմատավորված տող։
* `length` - Ոչ պարտադիր։ Տողի երկարությունը։ Լռությամբ 20։
* `precision` - Ոչ պարտադիր։ Ստորակետից հետո նիշերի քանակը։

```c#
// Բերված օրինակում st փոփոխականի արժեքը կլինի՝ "             1,500.3"
decimal amount = 1500.266m;
string st = proxyService.CurrencyFormat(amount, precision:1);
```

## FormatToPrint
```c#
public string FormatToPrint(decimal value)
```
Վերադարձնում է տասնորդական թվի, տպելու համար նախատեսված, ֆորմատավորված տող։

**Պարամետրեր**

* `value` - Պարտադիր։ Տասնորդական թիվ, որի համար ձևավորվում է ֆորմատավորված տող։

```c#
// st փոփոխականի արժեքը կլինի՝ "1,500.266"
decimal amount = 1500.266m;
string st = proxyService.FormatToPrint(amount);
```

## TryAddAtomicAsync TryAddAtomic
```c#
public async Task TryAddAtomicAsync(string key, Func<Task<string>> operation, TemplateSubstitutionExtenderArgs templateSubstitutionArgs)

public void TryAddAtomic(string key, Func<string> operation, TemplateSubstitutionExtenderArgs templateSubstitutionArgs)
```

TryAddAtomicAsync և TryAddAtomic ֆունկցիաները օգտագործվում են տպվող ձևերում օգտագործողի կողմից նկարագրվող պարամետրերի ավելացման համար։

TryAddAtomicAsync ֆունկցիան օգտագործվում է այն դեպքում երբ երկրորդ պարամետրով պետք է փոխանցել ֆունկցիա (սովորական, static, լոկալ, լամբդա արտահայտություն), որը վերադարձնում է Task<string>։ Նշված ֆունկցիայի միջոցով հաշվարկվում է պարամետրի արժեքը։

TryAddAtomic ֆունկցիան օգտագործվում է այն դեպքում երբ երկրորդ պարամետրով փոխանցված ֆունկցիան (սովորական, static, լոկալ, լամբդա արտահայտություն) վերադարձնում է string։

**Պարամետրեր**

* `key` - Պարտադիր։ Տպվող պարամետրի կոդը։
* `operation` - Պարտադիր։ ֆունկցիա որը վերադարձնում է պարամետրի արժեքը։
* `templateSubstitutionArgs` - TemplateSubstitutionExtenderArgs տեսակի օբյեկտ, որը ստանում է Calculate ֆունկցիան։


```c#
{
    [TemplateSubstitutionExtender]
    public class Test : ITemplateSubstitutionExtender
    {
        private readonly UserProxyService proxyService;
        
        private string clicode;

        public Test(UserProxyService proxyService)
        {
            this.proxyService = proxyService;
        }

        public async Task Calculate(TemplateSubstitutionExtenderArgs templateSubstitutionArgs)
        {
            clicode = "00000418";
            await proxyService.TryAddAtomicAsync("param1", Bnak, templateSubstitutionArgs);
        }

        public async Task<string> Bnak()
        {
            var cl = await proxyService.LoadClientDoc(clicode);
            return (string) cl["COMMUNITY"];

        }
    }
}
```

```c#
    [TemplateSubstitutionExtender]
    public class Test : ITemplateSubstitutionExtender
    {
        private readonly UserProxyService proxyService;
        
        private string clicode;

        public Test(UserProxyService proxyService)
        {
            this.proxyService = proxyService;
        }

        public async Task Calculate(TemplateSubstitutionExtenderArgs templateSubstitutionArgs)
        {
            string yb = proxyService.YEAR_BEGIN().ToString();
            proxyService.TryAddAtomic("param1", () => yb, templateSubstitutionArgs);
        }
     
    }
}
```

## InList
```c#
public static bool InList(string sValue, params string[] lValues)
public static bool InList(string sValue, IEnumerable<string> lValues)
```

Ստուգում է ենթատողի առկայությունը տողի / տողերի կամ որևէ կոլեկցիայի մեջ։

**Պարամետրեր**

* `sValue` - Պարտադիր։ Փնտրվող ենթատող։
* `lValues` - Պարտադիր։ Տող / տողեր, զանգված կամ այլ տեսակի կոլեկցիա, որտեղ փնտրվում է ենթատողը։

```c#
bool abcExist = UserProxyService.InList("abc", "ab", "cd", "abc");
bool abcExist = UserProxyService.InList("abc", ["ab", "cd", "abc"]);
```

## GetBranchParam
```c#
public Task<string> GetBranchParam(string paramCode, string branchCode = "")
```
Գրասենյակի կոդը փոխանցված լինելու դեպքում վերադարձնում է սահմանված կոդով գրասենյակի փաստաթղթի (ACSBRANCH տեսակի փաստաթուղթ) դաշտի արժեքը։ Փոխանցված չլինելու դեպքում կվերադարձվի առաջին պարամետրով փոխանցված Գրասենյակ փաստաթղթի դաշտի նույնանուն համակարգային պարամետրերի արժեքը։

**Պարամետրեր**

* `paramCode` - Պարտադիր։ Գրասենյակ փաստաթղթի դաշտի ներքին անվանում կամ նույնանուն համակարգային պարամետրի կոդ։
* `branchCode` - Ոչ պարտադիր։ Գրասենյակի կոդը՝ համապատասխանում է Գրասենյակ տեսակի փաստաթղթի Կոդ դաշտի արժեքին։


```c#
// Ստանում ենք B01 կոդով գրասենյակի գլխավոր հաշվապահի անունը։ 
string accountantName = await proxyService.GetBranchParam("CHIEFACCTNT", "B01"); 

```


## AcName AcEName
```c#
public async Task<string> AcName(string code)
public async Task<string> AcEName(string code)
```
Վերադարձնում է փոխանցված հաշվի համարի անվանումը / անգլերեմ անվանումը։

**Պարամետրեր**

* `code` - Պարտադիր։ Հաշվի համար։

```c#
// Ստանում ենք 004438799 հաշվի անվանումը։ 
string accName = await proxyService.AcName("004438799"); 
```

## LoadAccountDescByCode

```c#
public Task<AccountDesc> LoadAccountDescByCode(string code, bool throwException = false)
```
Վերադարձնում է հաշվի հիմնական դաշտերը պարունակով օբյեկտ ըստ հաշվի համարի։ throwException պարամետրի ```true``` արժեքի դեպքում հաշվի համարի բացակայության դեպքում կառաջանա սխալ, հակառակ դեպքում կվերադարձվի ```null```:

**Պարամետրեր**

* `code` - Պարտադիր։ Հաշվի համար։
* `throwException` - Ոչ պարտադիր։ Հաշվի համարի բացակայության դեպքում արտացոլել հաշվի բացակայության մասին սխալի հաղորդագրություն։


```c#
// Ստանում ենք 004438700 հաշվի տվյալները պարունակող օբյեկտ։ Հաշվի համարը սխալ փոխանցված լինելու դեպքում կարտացոլվի սխալի մասին հաղորդագրություն։ 
AccountDesc acc= await proxyService.LoadAccountDescByCode("004438700", true);
```

## CliName CliEName
```c#
public async Task<string> CliName(string code)
public async Task<string> CliEName(string code)
```
Վերադարձնում է հաճախորդի անվանումը / անգլերեն անվանումը ըստ կոդի։

**Պարամետրեր**

* `code` - Պարտադիր։ Հաճախորդի կոդը։

```c#
// Ստանում ենք 00006473 կոդով հաճախորդի անվանումը։
string clName = await proxyService.CliName("00006473");
```

## GetAccCodeByAgrISN
```c#
public Task<string> GetAccCodeByAgrISN(int agrISN, string accName, string agrType = "", string agrRisk = "", bool accFormat = true)
```
Վերադարձնում է պայմանագրի հաշվապահական հավելվածի համապատասխան դաշտում լրացված հաշվեհամարը, որի ներքին անվանումը փոխանցվում է accName պարամետրի միջոցով։

**Պարամետրեր**

* `agrISN` - Պարտադիր։ Պայմանագրի ISN-ը։
* `accName` - Պարտադիր։ Հաշվապահական հավելվածի համապատասխան դաշտի ներքին անվանումը։
* `agrType` - Ոչ պարտադիր։ Ենթահամակարգի տեսակ` C, D, M, N, B, Q։ Պարամետրի լրացված լինելու դեպքում հաշվարկը հաշվարկը կկատարվի ավելի արագ։
* `agrRisk` - Ոչ պարտադիր։ Պայմանագրի ռիսկի դասիչը։ Օգտագործվում է միայն պահուստավորման հետ կապված հաշիվների ստացման համար (Հաշվապաահական հավելվածի "Պահուստավորման հաշիվներ" աղյուսակ)։ 
* `accFormat` - Ոչ պարտադիր։ true արժեքի դեպքում հետհաշվեկշռային հաշիվները կվերադարձվեն 20 իսկ հաշվեկշռային հաշիվները 11 երկարությամբ։ Եթե հաշվեհամարը ավելի կարճ է բացակայող նիշերը աջից կհամալրվեմ բացատներով։ false արժեքի դեպքում հաշվեհամարները կվերադարձվեն առանց բացատների։

> [!TIP]
> ՀԾ-Բանկ համակարգում ենթահամակարգերի կոդերը հնարավոր է դիտել SubSys ծառում (այն հասանելի է "Ադմինիստրատորի ԱՇՏ 4.0" &#8594; "Համակարգային աշխատանքներ" &#8594; "Համակարգային նկարագրություններ" տեղեկատուի մեջ։ Ծառը դիտելու համար անհրաժեշտ է կոնտեքստային մենյուի մեջ գործարկել "Բացել ծառը" հրամանը)։
<br>

```c#
// Ստանում ենք 253711148 ISN-ով պայմանագրի տոկոսների հաշվարկման հաշիվը։
string acc = await proxyService.GetAccCodeByAgrISN(253711148, "ACCAGR","C");
```


## GetPerSumPayDate, GetAgrSumPayDate
```c#
public async Task<DateTime?> GetAgrSumPayDate(bool previous, int agrIsn, DateTime requestDate)
public async Task<DateTime?> GetPerSumPayDate(bool previous, int agrIsn, DateTime requestDate)
```
Ֆունկցիաները վերադարձնում են սահմանված ամսաթվին նախորդող կամ հաջորդող վարկի կամ տոկոսի մարման ամսաթվերը եթե նրանք առկա են։ Ֆունկցիաները հնարավոր է կիրառել միայն գրաֆիկով (Univer) տեսակի պայմանագրերի համար։

**Պարամետրեր**

* `previous` - Պարտադիր։ `true` արժեքի դեպքում կվերադարձվի `requestDate` պարամետրով սահմանված ամսաթվին նախորդող, իսկ `false` արեժքի դեպքում հաջորդող մարման ամսաթիվը։
* `agrIsn` - Պարտադիր։ Պայմանագրի ISN-ը։
* `requestDate` - Պարտադիր։ Հարցման ամսաթիվ։

```c#

// Օրինակում հաշվարկվում է 1081528567 ISN -ով պայմանագրի 12/03/24-ին հաջորդող վարկի և տոկոսի մարման ամսաթվերը։
DateTime? dt1 = await proxyService.GetAgrSumPayDate(false, 1081528567, DateTime.Parse("2024-03-12"));
DateTime? dt2 = await proxyService.GetPerSumPayDate(false, 1081528567, DateTime.Parse("2024-03-12"));
```


## GetCollateralISNsByAgrNum
``` c#
public Task<List<int>> GetCollateralISNsByAgrNum(string agreemCode, string agreemType)
```
Վերադարձնում է տվյալ պայմանագրին կապակցված գրավների ISN-ները (ավանդային գրավի դեպքում վերադարձնում Է N3DepMor պայմանագիրը, ոչ թե ավանդային գրավի ենթապայմանագրերը):

**Պարամետրեր**

* `agreemCode` - Պարտադիր։ Պայմանագրի համարը։
* `agreemType` - Պարտադիր։ Հնարավոր արժեքներն են "C", "D", "M"(տրամադրված երաշխավորությունների դեպքում) ։

```c#
// Ստանում ենք TV-8900 վարկային պայմանագրին կապակցված գրավի և երաշխավորությունների պայմանագրերի ISN-ները:
List<int> cISNs = await proxyService.GetCollateralISNsByAgrNum("TV-8900", "C");
```
## GetLinkedMortSum, GetLinkedGuarSum
```c#
public async Task<decimal> GetLinkedMortSum(int agrISN, DateTime date, string agrType, string returnCurr)
public async Task<decimal> GetLinkedGuarSum(int agrISN, DateTime date, string agrType, string returnCurr)
```

Վերադարձնում է պայմանագրին կապակցված գրավների / երաշխավորությունների ընդհանուր գումարը սահմանված ամսաթվով։

**Պարամետրեր**

* `agrISN` - Պարտադիր։ Պայմանագրի ISN։
* `date` - Պարտադիր։ Հարցման ամսաթիվ։
* `agrType` - Պարտադիր։ Առաջին ապարամետրով սահմանված isn ով պայմանագրի Ենթահամակարգի կոդը։ Օրինակ` "C1", "C3": Պարամետրի արժեքը փոխանցվում է արագագործության համար։
* `returnCurr` - Պարտադիր։ Արժույթի կոդը, որով պետք է արտացոլված լինի վերադարձվող գումարը։ 

```c#
/* Օրինակում հաշվակվում են 253711148 isn-ով պայմանագրին կապակցված գրավի և երաշխավությունների
ընդհանուր գումարները։ Երաշխավորության դեպքում գումարը կարտացոլվի ԱՄՆ դոլարով։ */
decimal am1 = await proxyService.GetLinkedMortSum(253711148, DateTime.Parse("2024-09-16"), "C1", "000");
decimal am2 = await proxyService.GetLinkedGuarSum(253711148, DateTime.Parse("2024-09-16"), "C1", "001");
```


## GetRating
```c#
public Task<string> GetRating(string clientCode, DateTime dateIn, string operation)
```
Վերադարձնում է հաճախորդի համապատասխան վարկանիշը (սահմանվում է Վարկանշման ԱՇՏ-ում) սահմանված ամսաթվով։

**Պարամետրեր**

* `clientCode` - Պարտադիր։ Հաճախորդի կոդը։
* `dateIn` - Պարտադիր։ Հարցման ամսաթիվը։
* `operation` - Վարկանիշի կոդը։ Հնարավոր արժեքները թվարկված են ստորև աղյուսակում։


Կոդ | Վարկանիշ
-|-
MDS | Կարճաժամկետ Մուդիզ|
MDL | Երկարաժամկետ Մուդիզ  |
SPS | Կարճաժամկետ Ստանդարտ և Փուրզ |
SPL | Երկարաժամկետ Ստանդարտ և Փուրզ |
FTS | Կարճաժամկետ Ֆիթչ |
FTL | Երկարաժամկետ Ֆիթչ |
CBR | Կենտրոնական Բանկի |
INR | Բանկի Ներքին|
   

```c#
// Օրինակում հաշվարկվում է 00007776 կոդով հաճախորդի Կարճաժամկետ Մուդիզ վարկանշի արժեքը 19/09/24 ամսաթվի դրությամբ։ Վերադարձված արժեքը՝ Պ-1։
 
string mdsr = await proxyService.GetRating("00007776", DateTime.Parse("2024-09-19"), "MDS");

```

## GetRatingCode
```c#
public Task<string> GetRatingCode(string clientCode, DateTime dateIn, string operation)
```

**Պարամետրեր**

* `clientCode` - Պարտադիր։ Հաճախորդի կոդը։
* `dateIn` - Պարտադիր։ Հարցման ամսաթիվը։
* `operation` - Վարկանիշի կոդը։ Հնարավոր արժեքները թվարկված են [GetRating](#GetRating) ֆունկցիայի նկարագրության մեջ։

Վերադարձնում է տվյալ հաճախորդին համապատասխանող վարկանիշին համապատասխանող "Վարկանիշային սիմվոլներ" փաստաթղթի "Դաշտի արժեքը"։

```c#
/* Օրինակում հաշվարկվում է 00007776 կոդով հաճախորդի Կարճաժամկետ Մուդիզ վարկանշի արժեքը 19/09/24 ամսաթվի դրությամբ և վերադարձվում է
համապատասխան "Վարկանիշային սիմվոլներ" փաստաթղթի "Համար" դաշտի արժեքը։ Վերադարձված արժեքը՝ 20։ */
 
string mdsr = await proxyService.GetRating("00007776", DateTime.Parse("2024-09-19"), "MDS");
```
## ExistsContractByCliISN, ExistsContractByCliCode
```c#
public bool ExistsContractByCliISN(int cliISN, string contractKey, bool checkClosed = false)
public async Task<bool> ExistsContractByCliCode(string cliCode, string contractKey, bool checkClosed = false)
```
Ստուգվում է սահմանված isn -ով / հաճախորդի կոդով հաճախորդին կից սահմանված տեսակի պայմանագրերի առկայությունը։

**Պարամետրեր**

* `cliISN` /  `cliCode` - Պարտադիր։ Հաճախորդի isn / հաճախորդի կոդ։
* `contractKey` - Պարտադիր։ Ենթահամակարգի կոդ։
* `checkClosed` - Ոչ պարտադիր։ Ստուգել փակվածները թե ոչ։

> [!TIP]
> ՀԾ-Բանկ համակարգում ենթահամակարգերի կոդերը հնարավոր է դիտել SubSys ծառում (այն հասանելի է "Ադմինիստրատորի ԱՇՏ 4.0" &#8594; "Համակարգային աշխատանքներ" &#8594; "Համակարգային նկարագրություններ" տեղեկատուի մեջ։ Ծառը դիտելու համար անհրաժեշտ է կոնտեքստային մենյուի մեջ գործարկել "Բացել ծառը" հրամանը)։
<br>

```c#
/* Օրինակում agrExist / agrExist2 փոփոխականները կստանան true կամ false արժեքը կապված 898692403 ins-ով / "00101953" կոդով հաճախորդի
գծով բացված, գործող տրամադրված երաշխավորության պայմանագրերի առկայությունից։ */

bool agrExist = proxyService.ExistsContractByCliISN(898692403, "N2");
bool agrExist2 = await proxyService.ExistsContractByCliCode("00101953", "N2");     
```

## GetAgrTypeByISN

```c#
public string GetAgrTypeByISN(int docISN)
```
Վերադարձնում է սահմանված isn -ով պայմանագրի համապատասխան ենթահամակարգերին պատկանելու հայտանիշը։ Օրիանակ՝ C, D, N:  

**Պարամետրեր**

* `docISN` - Պարտադիր։ Պայմանագրի isn:

```c#
// Օրինակում agType փոփոխականը կստանա "C" արժեքը քանի որ, 607802582 isn -ով պայմանագիրը հանդիսանում է տեղաբաշխված վարկ։
string agType = proxyService.GetAgrTypeByISN(607802582);
```

## GetAllDayAgrJ
```c#
public Task<short> GetAllDayAgrJ(int agrIsn, DateTime getDate)
```

Վերադարձնում է պայմանագրի ընդհանուր ժամկետանց օրերի քանակը։

**Պարամետրեր**

* `agrIsn` - Պարտադիր։ Պայմանագրի isn:
* `getDate` - Պարտադիր։ Հարցման ամսաթիվը:

```c#
// Հաշվարկվում է 905721123 պայմանագրի ընդհանուր ժամկետանց օրերի քանակը ընթացիկ ամսաթվի դրությամբ։
short agrJ = await proxyService.GetAllDayAgrJ(905721123, DateTime.Now);
```

## GetAllDayJCount

```c#
public Task<short> GetAllDayJCount(int agrIsn, DateTime repDate)
```
Վերադարձնում է տվյալ isn -ով պայմանագրի անընդմեջ ժամկետանց լինելու քանակը։

**Պարամետրեր**

* `agrIsn` - Պարտադիր։ Պայմանագրի isn:
* `getDate` - Պարտադիր։ Հարցման ամսաթիվը:

```c#
// Հաշվարկվում է 905721123 isn-ով պայմանագրի գծով անընդմեջ ժամկետանց լինելու քանակը ընթացիկ ամսաթվի դրությամբ։
short agrJc = await proxyService.GetAllDayJCount(905721123, DateTime.Now); 
```

## GetDayAgrJ
```c#
public async Task<short> GetDayAgrJ(int agrIsn, string agrType, DateTime getDate)
```
Վերադարձնում է պայմանագրի մայր-գումարի ժամկետանց օրերի քանակը։

**Պարամետրեր**

* `agrIsn` - Պարտադիր։ Պայմանագրի isn:
* `agrType` - Պարտադիր։ Պայմանագրի տիպը։ Օրինակ՝ C1Univer, C5Univer, C1Simpl: Դատարկ տող փոխանցելու դեպքում փաստաթղթի տեսակի կորոշվի ավտոմատ։
* `getDate` - Պարտադիր։ Հարցման ամսաթիվը։
  
```c#
// Հաշվարկվում է 905721123 isn-ով պայմանագրի գծով մայր-գումարի ժամկետանց օրերի քանակը ընթացիկ ամսաթվի դրությամբ։
short overdDays = await proxyService.GetDayAgrJ(815929352,"", DateTime.Parse("2024-10-15")); 
```

## GetDayPerJ
```c#
public async Task<short> GetDayPerJ(int agrIsn, DateTime getDate)
```
Վերադարձնում է պայմանագրի տոկոսների ժամկետանց օրերի քանակը։

**Պարամետրեր**

* `agrIsn` - Պարտադիր։ Պայմանագրի isn:
* `getDate` - Պարտադիր։ Հարցման ամսաթիվը։

```c#
// Հաշվարկվում է 836420323 isn-ով պայմանագրի գծով տոկոսների ժամկետանց օրերի քանակը ընթացիկ ամսաթվի դրությամբ։
short overdPerDays = await proxyService.GetDayPerJ(836420323, DateTime.Parse("2024-10-15"));
```
## MaxOverdueDaysCount
```c#
public Task<short> MaxOverdueDaysCount(int agrIsn, DateTime dateB, DateTime dateE)
```
Վերադարձնում է dateB և dateE պարամետրերով սահմանված ժամանակահատվածում վարկի մայր-գումարի և տոկոսկների առավելագույն ժամկետանց օրերի քանակը։ 

**Պարամետրեր**

* `agrIsn` - Պարտադիր։ Պայմանագրի isn:
* `dateB` - Պարտադիր։ Ժամանակահատվածի սկիզբ։
* `dateE` - Պարտադիր։ Ժամանակահատվածի վերջ։

```c#
// Հաշվարկվում է 30/08/24 -ից 15/01/25 ժամանակահատվածում 822631021 isn-ով պայմանագրի գծով եղած վարկի կամ տոկոսի առավելագույն ժամկետանց օրերի քանակը։
short maxOverd = await proxyService.MaxOverdueDaysCount(822631021, DateTime.Parse("2024-08-30"), DateTime.Parse("2025-01-15"));
```

## GetContractISN
```c#
public Task<int> GetContractISN(string agrType, string agrCode, string agrLevelCheck = "")
```
Վերադարձնում է պայմանագրի isn-ը ըստ պաիմանագրի համարի։

**Պարամետրեր**

* `agrType` - Պարտադիր։ Պայմանագրի տեսակ:
* `agrCode` - Պարտադիր։ Պայմանագրի N։
* `agrLevelCheck` - Պարտադիր։ "AGRPARENTS","AGREEMENTS","AGRCHILDREN"։

> [!TIP]
> ՀԾ-Բանկ համակարգում ենթահամակարգերի կոդերը հնարավոր է դիտել SubSys ծառում (այն հասանելի է "Ադմինիստրատորի ԱՇՏ 4.0" &#8594; "Համակարգային աշխատանքներ" &#8594; "Համակարգային նկարագրություններ" տեղեկատուի մեջ։ Ծառը դիտելու համար անհրաժեշտ է կոնտեքստային մենյուի մեջ գործարկել "Բացել ծառը" հրամանը)։
<br>

```
// Ստանում ենք AS80-001 համարով վարկային պայմանագրի isn-ը։
int agIsn = await proxyService.GetContractISN("C", "AS80-001", "AGRPARENTS");
```


LoadClientDocRO
YEAR_END
CurrencyName
CurrencyISOCode
CliName
CliEName
GetPenJDaysCount
GetPerFutur
GetFutAgrDbt
GetPerSumJ
GetAgrSumJ









## Պայմանագրերի հաշվառումների կոդեր
### Մնացորդային հաշվառումներ

Կոդ|Անվանում
-|-
R0 | Արտոնյալ ժամկետով (հին) օվերդրաֆտի ժամկետային գումար    |
R1 | Հիմնական գումար    |
R2 | Տոկոս    |
R3 | Մայր գումարի տույժ    |
R4 | Պահուստավորված գումար    |
R5 | Դուրս գրված հիմնական գումար    |
R6 | Դուրս գրված տոկոս    |
R7 | Դուրս գրված մայր գումարի տույժ    |
R8 | Զեղչատոկոս/Հավելավճար    |
R9 | Ռեպո համաձայնագրով ձեռք բերված արժեթղթերի գումար    |
RA | Արտոնյալ ժամկետով (հին) օվերդրաֆտի ժամկետանց գումար    |
RB | Դուրս գրված զեղչատոկոս/հավելավճար    |
RC | Վերադասակարգումից առաջացած դիսկոնտ    |
RD | Կոմիսիոն գումար    |
RE | Վերջնահաշվարկ    |
RF | ԲՏՀԴ տոկոս    |
RG | Գրավադրված արժեթուղթ    |
RH | Չօգտագործված մասի տոկոս    |
RI | Եկամուտներ/Ծախսեր    |
RJ | Դուրս գրված տոկոսային տույժ    |
RK | Դուրս գրված ԲՏՀԴ տոկոս    |
RL | Ժամկետանց գումարի տոկոս    |
RM | Արժեթղթի վերագնահատում    |
RN | Գնման գին    |
RO | Չօգտագործված մասի պահուստավորված գումար    |
RQ | Ռեպո համաձայնագրով ձեռք բերված արժեթղթերի վերագնահատում    |
RR | Ռեպո համաձայնագրով ձեռք բերված արժեթղթերի վաճառված մասի վերագնահատում    |
RS | Ռեպո համաձայնագրով ձեռք բերված արժեթղթերի վաճառված գումար    |
RT | Տոկոսի տույժ    |
RW | Դուրս գրված ժամկետանց գումարի տոկոս    |
RE | Փոխարժեքային տարբերությունից գանձում    |
RF | Վարձավճար    |
RF | Վարձավճարի պահուստավորված գումար     |
RH | Դուրս գրված չօգտագործված մասի տոկոս    |
RP | Գանձում    |
RԱ | Սվոպով գնված/վաճառված արժույթի գումար    |
RԲ | Ապահովագրավճար    |
RԳ | Դուրս գրված վարձավճար    |
RԴ | Ժամկետանց տոկոս    |
RԶ | Գրավի շուկայական արժեք    |
RԷ | Արդյունավետ տոկոս    |
RԸ | Դուրսգրված արդյունավետ տոկոս    |
RԹ | Ժամկետանց չօգտագործված մասի տոկոս    |
RԺ | ժամկետանց հիմնական գումար    |
RԻ | Ժամկետանց վճարվելիք տոկոս    |
RԼ | Օվերդրաֆտի մնացորդի անկանխիկ մաս    |
RԽ | Տրամադրման գծով ծախսեր    |
RԾ | Դատական ծախսեր    |
BԾ | Դատական ծախսեր    |
RՀ | Կանխիկի հաշվառում    |
RՁ | Հիմնական միջոցի գնահատում    |
MՁ | Լիզինգի առարկայի քանակ    |
RՂ | Դուրս գրված չօգտագործված մասի ժամկետանց տոկոսի տույժ    |
RՃ | Չօգտագործված մաս    |
RՄ | Զեղչատոկոս/Հավելավճարի մաշեցում    |
RՅ | Արժեթղթի վերագնահատում (ԱԴՄ)    |
RՇ | Չօգտագործված մասի ժամկետանց տոկոսի տույժ    |
RՌ | Լրացուցիչ պահուստավորված գումար    |
RՎ | Ածանցյալ գործիքի վերագնահատում    |
RՏ | Վճարվելիք տոկոս    |
RՖ | Չօգտագործված մասի լրացուցիչ պահուստավորված գումար    |
LP | Հաճախորդից կանխավճար    |
LT | Հաճախորդից կանխավճարի տոկոսի    |
LA | Հիմնական միջոցի մնացորդ    |
L9 | Հիմնական միջոցի տոկոս    |
L1 | Լիզինգի գծով փոխանցումներ (AMD)    |
L2 | Կանխավճարի տոկոս (AMD)    |
L3 | Լիզինգի գծով փոխանցումներ (USD)    |
L4 | Կանխավճարի տոկոս (USD)    |
L5 | Լիզինգի գծով փոխանցումներ (EUR)    |
L6 | Կանխավճարի տոկոս (EUR)    |
L7 | Լիզինգի գծով փոխանցումներ (RUB)    |
L8 | Կանխավճարի տոկոս (RUB)    |
LI | Լիզինգի փոխանցումներից հիմնական միջոցի ձևավորում    |
BN | Պարտատոմսերի քանակ    |
BC | Պարտատոմսեր    |
HL | Ռեպո համաձայնագրով ձեռք բերված արժեթղթի վաճառված մասի գին    |
HN | Ռեպո համաձայնագրով ձեռք բերված արժեթուղթ    |
HP | Ռեպո համաձայնագրով ձեռք բերված արժեթղթի գին    |
HQ | Ռեպո համաձայնագրով ձեռք բերված արժեթղթի վերագնահատում    |
HR | Ռեպո համաձայնագրով ձեռք բերված արժեթղթի վաճառված մասի վերագնահատում    |
HS | Ռեպո համաձայնագրով ձեռք բերված արժեթղթի վաճառված մաս    |
M2 | Գրավի քանակ    |
NN | Վճարված գումար(տոկոս)    |
XX | Դուրս գրված տոկոսի/տույժի տեղափոխում    |
ZZ | Հաշվառում չկա    |

### Ոչ մնացորդային հաշվառումներ

Կոդ | Անվանում
-|-
A0 | Հաշիվների խմբագրում
C0 | Հաճախորդի ռիսկի դասիչ
C1 | Հաճախորդի շահառուներ
C2 | Շահառուի հաճախորդներ
CA | Վարկային հայտի հաշվառումներ
N0 | Պայմաններ և վիճակներ
NA | Հայտի ծանուցումների ամսաթվեր
NB | Պարտատոմսի տեղաբաշխման ավարտ
NP | Եկամտաբերության կորեր
OA | Լրացուցիչ հաշվառումներ


## Հաշվառումների գործողությունների կոդեր

ՀԾ-Բանկ համակարգում հաշվառումների գործողությունների կոդերը հնարավոր է դիտել "Համակարգային նկարագրություններ" տեղեկատուի միջոցով (այն հասանելի է "Ադմինիստրատորի ԱՇՏ 4.0" &#8594; "Համակարգային աշխատանքներ" &#8594; "Համակարգային նկարագրություններ" տեղեկատուի մեջ։ Համապատասխան հաշվառումը գտնելու համար մուտքագրեք հաշվառման կոդը տեղեկատուի երկխոսության պատուհանի "Նկարագրության ներքին անուն" դաշտում իսկ "նկարագրության տիպ" դաշտում ընտրեք "հաշվառում" արժեքը։   Գործողությունների կոդերը դիտելու համար գործարկեք համապատասխան հաշվառման տողի կոնտեքստային մենյուի "Դիտել" հրամանը)։

![Գործողությունների կոդեր](user_proxy_oper_codes.png)
