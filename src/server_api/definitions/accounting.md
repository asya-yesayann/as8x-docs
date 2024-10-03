---
layout: page
title: "Հաշվառման նկարագրություն" 
tags: [Accounting]
---

## Բովանդակություն

- [Ներածություն](#ներածություն)
- [Օրինակներ](#օրինակներ)
- [ACCOUNTING նկարագրություն](#accounting-նկարագրություն)
- [Accounting դաս](#accounting-դաս)
- [Մեթոդներ](#մեթոդներ)
  - [OnAdd](#onadd)
  - [OnDelete](#ondelete)
- [IAccountingOnLimitFault ինտերֆեյս](#iaccountingonlimitfault-ինտերֆեյս)
- [Մեթոդներ](#մեթոդներ-1)
  - [OnLimitFault](#onlimitfault)
- [IAccountingOnHI2LimitFault ինտերֆեյս](#iaccountingonhi2limitfault-ինտերֆեյս)
- [Մեթոդներ](#մեթոդներ-2)
  - [OnLimitFault](#onlimitfault-1)

## Ներածություն

Եթե փաստաթղթի համար հարկավոր է վարել որևիցե տվյալի ժամանակագրական հաշվառում, ապա այն պետք է նկարագրել համակարգում:

8X համակարգում հաշվառում նկարագրելու համար հարկավոր է ունենալ
* .as ընդլայնմամբ ֆայլ սկրիպտերում [ACCOUNTING](#accounting-նկարագրություն) նկարագրությամբ։ Այն անհրաժեշտ է ներմուծել տվյալների բազա `Syscon` գործիքի միջոցով։
* .cs ընդլայնմամբ ֆայլ, որը պարունակում է սերվերում աշխատող տրամաբանությունը։

## Օրինակներ

* [Հաշվառման ընդլայնման նկարագրություն](../../extensions/definitions/acc_extender.md)
* [Հաշվառման ընդլայնման ձեռնարկ](../../extensions/definitions/acc_extender_guide.md)

## ACCOUNTING նկարագրություն

.as ընդլայնմամբ ֆայլում անհրաժեշտ է ավելացնել [ACCOUNTING](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Defs/Accounting.html) նկարագրություն, որը պարունակում է հաշվառման միայն նկարագրման հատվածը (Definition):

## Accounting դաս

Հաշվառման համար անհրաժեշտ է սահմանել դաս, որը ժառանգում է `Accounting` դասը և ունի հաշվառման ներքին անունը պարունակող `Accounting` ատրիբուտը։

**Օրինակ**

```c#
[Accounting("01")]
public class BalanceAccounting01 : Accounting
```

`Accounting` դասը տրամադրում է միջուկի կողմից կանչվող վիրտուալ մեթոդներ՝ սեփական սերվերային տրամաբանության սահմանման համար և հատկություններ հաշվառման մետատվյալների ու նկարագրության ստացման համար։

## Մեթոդներ

### OnAdd

```c#
public virtual Task OnAdd(OnAddEventArgs args);
```

Մեթոդը կանչվում է միջուկի կողմից [DocumentService](../services/IDocumentService.md) դասի [StoreFact](../services/IDocumentService.md#storefact) մեթոդով հաշվառումները գրանցելիս։

**Պարամետրեր**

* `args` - Գրանցման ենթակա հաշվառումը նկարագրող դասը։

### OnDelete

```c#
public virtual Task OnDelete(OnDeleteEventArgs args);
```

OnDelete մեթոդը կանչվում է միջուկի կողմից [DocumentService](../services/IDocumentService.md) դասի [HiDelete](../services/IDocumentService.md#hidelete), [HiDeleteAll](../services/IDocumentService.md#hideleteall) մեթոդներով հաշվառումները ջնջելիս կամ փաստաթուղթը [Delete](../services/IDocumentService.md#delete) մեթոդով իր հաշվառումների հետ ջնջելիս։

**Պարամետրեր**

* `args` - Հեռացման ենթակա հաշվառումը նկարագրող դասը։

## IAccountingOnLimitFault ինտերֆեյս

[HI2](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/Hi2.html) աղյուակում գրանցված հաշվառումների սահմանաչափերի խախտման ժամանակ լրացուցիչ մշակումներ իրականացնելու համար անհրաժեշտ է իրականացնել այս ինտերֆեյսը։

## Մեթոդներ

### OnLimitFault

```c#
public Task<bool> OnLimitFault(int isn, decimal overrunning, decimal overrunningLinked = -1, bool isDeleting = false, Document.Document baseDocument = null);
```

Մեթոդը կանչվում է միջուկի կողմից [HI](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/Hi.html) աղյուակում գրանցված հաշվառման սահմանաչափերի խախտման ժամանակ, որոնք դրված են հաշվառում օբյեկտի վրա։

**Պարամետրեր**

* `isn` - Հաշվառման օբյեկտի ներքին նույնականացման համար։
* `overrunning` - Սահմանաչապերից դուրս գալու գումարի չափ։ Եթե արժեքը բացասական է, ապա խախտվել է ստորին սահմանաչափը, դրականի դեպքում՝ վերին սահմանաչափը։
* `overrunningLinked` - Կից հաշվառման սահմանաչափերից դուրս գալու գումարի չափ։ Լռությամբ արժեքը **-1** է։
* `isDeleting` - Ցույց է տալիս, որ սահմանաչափի խախտումը առաջացել է փաստաթղթի ջնջման ժամանակ։ Լռությամբ արժեքը **false** է։
* `baseDocument` - Հաշվառումը ստեղծող փաստաթղթը նկարագրող դասը։ Լռությամբ արժեքը **null** է։

## IAccountingOnHI2LimitFault ինտերֆեյս

[HI2](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/Hi2.html) աղյուակում գրանցված հաշվառումների սահմանաչափերի խախտման ժամանակ լրացուցիչ մշակումներ իրականացնելու համար անհրաժեշտ է իրականացնել այս ինտերֆեյսը։

## Մեթոդներ

### OnLimitFault

```c#
public Task OnLimitFault(int isn, int glIsn, bool isDeleting = false, Document.Document baseDocument = null);
```

Մեթոդը կանչվում է միջուկի կողմից [HI2](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/Hi2.html) աղյուակում գրանցված հաշվառման սահմանաչափերի խախտման ժամանակ, որոնք դրված են հաշվառում օբյեկտի վրա։

**Պարամետրեր**

* `isn` - Հաշվառման օբյեկտի ներքին նույնականացման համար։
* `glIsn` - Հաշվառման երկրորդ օբյեկտի ներքին նույնականացման համար։ Այս պարամետրը անհրաժեշտ է [HIREST2](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/Hirest2.html) աղյուսակում սահմանաչափերի ստուգման համար։
* `isDeleting` - Ցույց է տալիս, որ սահմանաչափի խախտումը առաջացել է փաստաթղթի ջնջման ժամանակ։ Լռությամբ արժեքը **false** է։
* `baseDocument` - Հաշվառումը ստեղծող փաստաթղթը նկարագրող դասը։ Լռությամբ արժեքը **null** է։
