---
layout: page
title: "IKernelService սերվիս" 
tags: Accounting
sublinks:
- { title: "GetExchangeRate", ref: getexchangerate }
- { title: "GetRem", ref: getrem }
- { title: "GetRemHI2", ref: getremhi2 }
- { title: "GetTurn", ref: getturn }
- { title: "GetTurnHI2", ref: getturnhi2 }
- { title: "GetTurnFull", ref: getturnfull }
- { title: "GetTurnBetween", ref: getturnbetween }
- { title: "LastOpDate", ref: lastopdate }
- { title: "LastOpDate2", ref: lastopdate2 }
- { title: "LastHI2OpDate", ref: lasthi2opdate }
- { title: "LastHI2OpDate", ref: lasthi2opdate-1 }
- { title: "UserPositionAndMask", ref: userpositionandmask }
---

## Բովանդակություն

- [Մեթոդներ](#մեթոդներ)
  - [GetExchangeRate](#getexchangerate)
  - [GetRem](#getrem)
  - [GetRemHI2](#getremhi2)
  - [GetTurn](#getturn)
  - [GetTurnHI2](#getturnhi2)
  - [GetTurnFull](#getturnfull)
  - [GetTurnBetween](#getturnbetween)
  - [LastOpDate](#lastopdate)
  - [LastOpDate2](#lastopdate2)
  - [LastHI2OpDate](#lasthi2opdate)
  - [LastHI2OpDate](#lasthi2opdate-1)
  - [UserPositionAndMask](#userpositionandmask)

## Մեթոդներ

### GetExchangeRate

```c#
public Task<ExchangeRate> GetExchangeRate(string codCurrency, 
                                          DateTime date, 
                                          DateTime? maxCreationDate = null)
```

Վերադարձնում է արտարժույթի ՀՀ ԿԲ փոխարժեքը։
Եթե նշված ամսաթվին արտարժույթը բացակայում է, ապա բերվում է արտարժույթի վերջին առկա տվյալը։

**Պարամետրեր**

* `codCurrency` - Արտարժույթի կոդ։
* `date` - Փոխարժեքի նշանակման ամսաթիվ/ժամանակ։
* `maxCreationDate` - Փոխանցված լինելու դեպքում մեթոդը փնտրում է փոխարժեք, որի նշանակման ամսաթիվը չի գերազանցում փոխանցված ամսաթիվը:

### GetRem

```c#
public Task<(decimal CRem, decimal NCRem)> GetRem(string accounting, 
                                                  int isn, 
                                                  DateTime? remDate = null)
```

Վերադարձնում է փաստաթղթի հաշվառման մնացորդը նշված ամսաթվի դրությամբ։

Վերադարձնում է կորտեժ`
* `CRem` - Մնացորդը։
* `NCRem` - Մնացորդի դրամային համարժեքը։ 
  Այս թիվը ձևավորվում է մնացորդի ձևավորման ժամանակ, այլ ոչ թե վերահաշվարկվում մեթոդի կանչի ժամանակ։

**Պարամետրեր**

* `accounting` - Հաշվառման կոդ (ներքին անուն):
* `isn` - Հաշվառվող օբյեկտի ներքին նույնականացման համար։
* `remDate` - Մնացորդը բերելու ամսաթիվը։ 
  Եթե պարամետրը փոխանցված չէ, ապա բերվում է վերջնական մնացորդը։

### GetRemHI2

```c#
public Task<(decimal CRem, decimal NCRem)> GetRemHI2(string accounting, 
                                                     int isn = -1, 
                                                     int isnGl = -1, 
                                                     DateTime? remDate = null)
```

Վերադարձնում է փաստաթղթի [HI2](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/Hi2.html) աղյուսակում գրանցվող հաշվառման մնացորդը նշված ամսաթվի դրությամբ։ 
Մնացորդը կա՛մ գումարային ըստ բոլոր կուտակող օբյեկտների է, կա՛մ միայն փոխանցված `isnGl`-ով։

Վերադարձնում է կորտեժ`
* `CRem` - Մնացորդը։
* `NCRem` - Մնացորդի դրամային համարժեքը։ 
  Այս թիվը ձևավորվում է մնացորդի ձևավորման ժամանակ, այլ ոչ թե վերահաշվարկվում մեթոդի կանչի ժամանակ։

**Պարամետրեր**

* `accounting` - Հաշվառման կոդ (ներքին անուն):
* `isn` - Հաշվառվող հիմնական օբյեկտի ներքին նույնականացման համար։
* `isnGl` - Հաշվառվող կուտակող օբյեկտի ներքին նույնականացման համար։
* `remDate` - Մնացորդը բերելու ամսաթիվը։ 
  Եթե պարամետրը փոխանցված չէ, ապա բերվում է վերջնական մնացորդը։

### GetTurn

```c#
public Task<(decimal DbTurn, decimal DbTurnAMD, decimal CrTurn, decimal CrTurnAMD)> GetTurn(
    string accounting, int isn, DateTime startDate, DateTime endDate, string codeOperList = "")
```

Վերադարձնում է փաստաթղթի հաշվառման դեբետային և կրեդիտային շրջանառության արժեքները տրված ժամանակաշրջանի համար։

Վերադարձնում է կորտեժ`
* `DbTurn` - Դեբետային շրջանառության արժեքը։
* `DbTurnAMD` - Դեբետային շրջանառության արժեքը դրամային համարժեքը։
* `CrTurn` - Կրեդիտային շրջանառության արժեքը։
* `CrTurnAMD` - Կրեդիտային շրջանառության արժեքը դրամային համարժեքը։

**Պարամետրեր**

* `accounting` - Հաշվառման կոդ (ներքին անուն):
* `isn` -  Հաշվառվող օբյեկտի ներքին նույնականացման համար։
* `startDate` - Ժամանակաշրջանի սկզբի ամսաթիվ։
* `endDate` - ժամանակաշրջանի վերջին ամսաթիվ։
* `codeOperList` - Գործողությունների կոդերի ցանկ։ 
  Եթե ցանկը սկսվում է `+` նշանով, ապա հաշվի են առնվում գործողությունների բոլոր կոդերը, որոնք թվարկվում են նրանից հետո։ 
  `-` նշանի դեպքում անտեսվում են այն գործողությունները, որոնց կոդերը թվարկված են ցանկի մեջ։ 
  Գործողությունների կոդերը թվարկվում են մեկը մյուսի հետևից բացատների միջոցով։ 
  Ցանկը նաև կարող է պարունակել առանց նշանի միակ տարր։

### GetTurnHI2

```c#
public Task<(decimal DbTurn, decimal DbTurnAMD, decimal CrTurn, decimal CrTurnAMD)> GetTurnHI2(
    string accounting, int isn, int isnGl, DateTime startDate, DateTime endDate, 
    string codeOper = "", int baseIsn = -1)
```

Վերադարձնում է փաստաթղթի [HI2](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/Hi2.html) աղյուսակում գրանցվող հաշվառման դեբետային և կրեդիտային շրջանառության արժեքները ըստ տրված կուտակող օբյեկտի և տրված ժամանակաշրջանի համար։

Վերադարձնում է կորտեժ`
* `DbTurn` - Դեբետային շրջանառության արժեքը։
* `DbTurnAMD` - Դեբետային շրջանառության արժեքը դրամային համարժեքը։
* `CrTurn` - Կրեդիտային շրջանառության արժեքը։
* `CrTurnAMD` - Կրեդիտային շրջանառության արժեքը դրամային համարժեքը։

**Պարամետրեր**

* `accounting` - Հաշվառման կոդ (ներքին անուն):
* `isn` - Հաշվառվող օբյեկտի ներքին նույնականացման համար։
* `isnGl` - Կուտակող օբյեկտի ներքին նույնականացման համար։
* `startDate` - Ժամանակաշրջանի սկզբի ամսաթիվ։
* `endDate` - ժամանակաշրջանի վերջին ամսաթիվ։
* `codeOper` - Հաշվառման գործողության կոդը, որի շրջանառությունները կվերադարձվի։
* `baseIsn` - Հիմքային փաստաթղթի ներքին նույնականացման համար։ 

### GetTurnFull

```c#
public Task<(decimal DbTurn, decimal DbTurnAMD, 
            decimal CrTurn, decimal CrTurnAMD, 
            decimal Rem, decimal RemAMD, 
            decimal StartRem, decimal StartRemAMD)> GetTurnFull(
    string accounting, int isn, DateTime startDate, DateTime endDate)
```

Վերադարձնում է փաստաթղթի հաշվառման դեբետային և կրեդիտային շրջանառության արժեքները տրված ժամանակաշրջանի համար, ինչպես նաև սկզբնական և վերջնական մնացորդները։

Վերադարձնում է կորտեժ`
* `DbTurn` - Դեբետային շրջանառությունը։
* `DbTurnAMD` - Դեբետային շրջանառության դրամային համարժեքը։
* `CrTurn` - Կրեդիտային շրջանառությունը։
* `CrTurnAMD` - Կրեդիտային շրջանառության դրամային համարժեքը։
* `Rem` - Ժամանակաշրջանի վերջնական մնացորդը։
* `RemAMD` - Ժամանակաշրջանի վերջնական մնացորդի դրամային համարժեքը։
* `StartRem` - Ժամանակաշրջանի սկզբնական մնացորդը։
* `StartRemAMD` - Ժամանակաշրջանի սկզբնական մնացորդի դրամային համարժեքը։

**Պարամետրեր**

* `accounting` - Հաշվառման կոդ (ներքին անուն):
* `isn` - Հաշվառվող օբյեկտի ներքին նույնականացման համար։
* `startDate` - Ժամանակաշրջանի սկզբի ամսաթիվ։
* `endDate` - ժամանակաշրջանի վերջին ամսաթիվ։

### GetTurnBetween

```c#
public Task<List<(DateTime Date, decimal DbTurn, decimal DbTurnAMD, 
                  decimal CrTurn, decimal CrTurnAMD)>> GetTurnBetween(
    string accounting, int isn, DateTime startDate, DateTime endDate, 
    string codeOper = "", bool bNotShowSameClAccTurn = false)
```

Վերադարձնում է փաստաթղթի հաշվառվման ամենօրյա շրջանառությունների ցուցակ նշված ժամանակահատվածի համար։

Վերադարձնում է կորտեժների ցուցակ՝
* `Date` - Միջակայքից ամսաթիվ, որով առկա է շրջանառություն։
* `DbTurn` - Դեբետային շրջանառությունը նշված ամսաթվով։
* `DbTurnAMD` - Դեբետային շրջանառության դրամային համարժեքը նշված ամսաթվով։
* `CrTurn` - Կրեդիտային շրջանառությունը նշված ամսաթվով։
* `CrTurnAMD` - Կրեդիտային շրջանառության դրամային համարժեքը նշված ամսաթվով։

**Պարամետրեր**

* `accounting` - Հաշվառման կոդ (ներքին անուն):
* `isn` - Հաշվառվող օբյեկտի ներքին նույնականացման համար։
* `startDate` - Ժամանակաշրջանի սկզբի ամսաթիվ։
* `endDate` - ժամանակաշրջանի վերջին ամսաթիվ։
* `codeOper` - Հաշվառման գործողության կոդը, որի շրջանառությունները կվերադարձվի։
* `bNotShowSameClAccTurn` - **true** արժեքի դեպքում ֆիլտրվում են և չեն վերադարձվում հաճախորդի սեփական հաշիվների միջև գործողությունները։

### LastOpDate

```c#
public Task<DateTime?> LastOpDate(string accCode, int isn, 
                                  DateTime? upToDate, string op = "", 
                                  int discardISN = -1)
```

Վերադարձնում է փաստաթղթի հաշվառման վերջին նշանակված գործողության ամսաթիվը, որը ստեղծվել է հաշվառման նշված կոդով մինչև նշված ամսաթիվը ներառյալ։

**Պարամետրեր**

* `accCode` - Հաշվառման կոդ (ներքին անուն):
* `isn` - Հաշվառվող օբյեկտի ներքին նույնականացման համար։
* `upToDate` - Ամսաթիվը, մինչև որը կատարվում է որոնումը։ 
  Եթե պարամետրը տրված չէ, ապա վերադառնում է տվյալ հաշվառման մեջ վերջին գործողության ամսաթիվը։
* `op` - 	Հաշվառման որոնվող գործողություն։
* `discardISN` - Փաստաթղթի ներքին նույնականացման համար, որի գործողությունները չեն դիտարկվում։

### LastOpDate2

```c#
public Task<DateTime?> LastOpDate2(string accountings, int isn, 
                                   DateTime? upToDate, bool inOp = true, 
                                   string ops = "", string dbcr = "")
```

Վերադարձնում է փաստաթղթի հաշվառման վերջին նշանակված գործողության ամսաթիվը, որը ստեղծվել է հաշվառման նշված կոդերով մինչև նշված ամսաթիվը ներառյալ։

Ի տարբերություն [LastOpDate](#lastopdate) մեթոդի, այս մեթոդը կարող է ֆիլտրել ներառող կամ բացառող գործողությունների կոդերով։

**Պարամետրեր**

* `accountings` - Հաշվառումների կոդերի ցուցակ ստորակետով բաժանված:
* `isn` - Հաշվառվող օբյեկտի ներքին նույնականացման համար։
* `upToDate` - Ամսաթիվը, մինչև որը կատարվում է որոնումը։ 
  Եթե պարամետրը տրված չէ, ապա վերադառնում է տվյալ հաշվառման մեջ վերջին գործողության ամսաթիվը։
* `inOp` - Ցույց է տալիս, թե արդյոք որոնվող գործողությունը պետք է լինի `ops`-ից, թե չլինի `ops`-ից։
* `ops` - Հաշվառման որոնվող գործողությունների ցանկ։ 
  Գործողությունների կոդերը ստորակետով բաժանված։
* `dbcr` - Դեբետային("D") կամ կրեդիտային("C") գործողությունների որոնման ֆիլտր։
  Դատարկ արժեքի դեպքում դիտարկվում են բոլոր գործողությունները։

### LastHI2OpDate

```c#
public Task<DateTime?> LastHI2OpDate(string accCode, int isn = -1, 
                                     int glIsn = -1, DateTime? upToDate = null, 
                                     string op = "")
```

Վերադարձնում է փաստաթղթի [HI2](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/Hi2.html) աղյուսակում գրանցվող հաշվառման վերջին նշանակված գործողության ամսաթիվը, որը ստեղծվել է հաշվառման նշված կոդով մինչև նշված ամսաթիվը ներառյալ։

**Պարամետրեր**

* `accCode` - Հաշվառման կոդ (ներքին անուն):
* `isn` - Հաշվառվող օբյեկտի ներքին նույնականացման համար։
* `glIsn` - Կուտակող օբյեկտի ներքին նույնականացման համար։
* `upToDate` - Ամսաթիվը, մինչև որը կատարվում է որոնումը։ 
  Եթե պարամետրը տրված չէ, ապա վերադառնում է տվյալ հաշվառման մեջ վերջին գործողության ամսաթիվը։
* `op` - Հաշվառման որոնվող գործողություն։

### LastHI2OpDate

```c#
public Task<DateTime?> LastHI2OpDate(List<string> accCodes, int isn = -1, 
                                     int glIsn = -1, DateTime? upToDate = null, 
                                     string op = "")
```

Վերադարձնում է փաստաթղթի [HI2](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/Hi2.html) աղյուսակում գրանցվող հաշվառման վերջին նշանակված գործողության ամսաթիվը, որը ստեղծվել է հաշվառման նշված կոդերով մինչև նշված ամսաթիվը ներառյալ։

**Պարամետրեր**

* `accCodes` - Հաշվառումների կոդերի ցուցակ:
* `isn` - Հաշվառվող օբյեկտի ներքին նույնականացման համար։
* `glIsn` - Կուտակող օբյեկտի ներքին նույնականացման համար։
* `upToDate` - Ամսաթիվը, մինչև որը կատարվում է որոնումը։ 
  Եթե պարամետրը տրված չէ, ապա վերադառնում է տվյալ հաշվառման մեջ վերջին գործառույթի ամսաթիվը։
* `op` - Հաշվառման որոնվող գործողություն։

### UserPositionAndMask

```c#
public void UserPositionAndMask(out byte number, out byte mask, short suid = -1)
```

Վերադարձնում է համակարգի օգտագործողի դիրքի համարը և դիմակը։ 
Նախատեսված է տվյալների աղբյուրների SQL հարցումներում օգտագործողի իրավասությունների ստուգման համար։

**Պարամետրեր**

* `number` - Վերադարձնում է օգտագործողի դիրքի համարը։
* `mask` - Վերադարձնում է օգտագործողի դիմակը։
* `suid` - Համակարգի օգտագործողի ներքին համարը, որի համար վերադարձվելու են տվյալները։ 
  Չփոխանցելու դեպքում վերադարձվում են ընթացիկ օգտագործողի համար։
