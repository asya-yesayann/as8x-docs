---
layout: page
title: "UserProxyService - ՀԾ-Բանկի ընդլայնման յուրահատուկ սերվիս" 
---

# UserProxyService - ՀԾ-Բանկի ընդլայնման յուրահատուկ սերվիս

Բովանդակություն
LoadDoc
LoadDocFromFolder
LoadContractDoc
LoadClientDoc
LoadClientDesc
LoadClientDescByCode
LoadClientDocRObyISN
LoadClientDocRO
GetClientISN
GetClientISNByAcc
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




## ներածություն

UserProxyService պարունակում է մեթոդներ, որոնք հնարավորություն են տալիս. 

 1. տվյալների բազայից բեռնել՝ փաստաթղթեր այդ թվում հաճախորդի քարտ, հաշիվ, պլաստիկ քարտ, ներգրավված / տեղաբաշխված միջոցների պայմանագիր
 2. սահմանված ամսաթվերով ստանալ հաշիվների, պայմանագրերի հաշվառումների մնացորդները
 3. ֆորմատավորել ամսաթվեր, գումարներ
 4. հաշվարկել OLAP-ի, ատոմար ցուցանիշների կամ օգտագործողի կողմից նկարագրված ֆունկցիաներ

UserProxyService -ը ինյեկցիայի միջոցավ հնարավոր փոխանցել և կիրառել օգտագործողի կողմից ստեղծվող ընդլայնումների դասերում։



## Մեթոդներ

### LoadDoc

```c#
public Task<Document> LoadDoc(int isn, GridLoadMode gridLoadMode = GridLoadMode.Full,
                                bool loadParents = false,
                                bool throwExceptionIfDeleted = true, bool lookInArc = true,
                                bool loadImagesAndMemos = false)
```

Բեռնում է սահմանված ISN -ով փաստաթուղթը։ 

**Պարամետրեր**

* `isn` - Պարտադիր։ Փաստաթղթի ISN։
* `gridLoadMode` -  Ոչ պարտադիր։ Բեռնել նաև փաստաթղթի գրիդերը թե ոչ, հնարավոր արժեքներն են 	**GridLoadMode.Full** կամ **GridLoadMode.None**։ Լռությամբ՝ **GridLoadMode.Full**
* `loadParents` - Ոչ պարտադիր։ Բեռնել նաև փաստաթղթի ծնող-փաստաթղթերը։ Հնարավոր արժեքներն են **true**, **false**։ Լռությամբ՝ **false**
* `throwExceptionIfDeleted` - Ոչ պարտադիր: Փաստաթղթի հեռացված լինելու դեպքում արտացոլել սխալի վերաբերյալ հաղորդագրություն, կամ բեռնել հեռացված փաստաթուղթը 999 վիճակով։ Հնարավոր արժեքներն են **true**, **false**։ Լռությամբ՝ **true**:
* `lookInArc` -
* `loadImagesAndMemos` - 




LoadDocFromFolder
LoadContractDoc
LoadClientDoc
LoadClientDesc
LoadClientDescByCode
LoadClientDocRObyISN
LoadClientDocRO
GetClientISN
GetClientISNByAcc
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





