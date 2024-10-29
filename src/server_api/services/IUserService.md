---
layout: page
title: "IUserService սերվիս" 
sublinks:
- { title: "UserElProp", ref: userelprop }
- { title: "GetList", ref: getlist }
---

## Բովանդակություն

- [Ներածություն](#ներածություն)
- [Մեթոդներ](#մեթոդներ)
  - [UserElProp](#userelprop)
  - [GetList](#getlist)
  <!-- - [ChangeName](#changename)
  - [ValidateNewUsername](#validatenewusername)
  - [SetAccess](#setaccess) -->

## Ներածություն

IUserService դասը նախատեսված է համակարգի օգտագործողների նկարագրությունների հետ աշխատանքը ապահովելու համար։

## Մեթոդներ

### UserElProp

```c#
public Task<UserDescription> UserElProp(short suid)
```

Վերադարձնում է համակարգի [օգտագործողի նկարագրությունը](../types/UserDescription.md)։

**Պարամետրեր**

* `suid` - օգտագործողի ներքին համար (կոդ)։

### GetList

```c#
public Task<List<UserDescription>> GetList()
```

Վերադարձնում է համակարգի բոլոր [օգտագործողների նկարագրությունները](../types/UserDescription.md)։

<!-- ### ChangeName

```c#
public Task ChangeName(short suid, string newName, string oldName)
```

Փոխում է համակարգի օգտագործողի ներքին անունը։

Անվան դատարկ լինելու կամ նշված ներքին անունով օգտագործողի գոյության դեպքում առաջացնում է սխալ։

**Պարամետրեր**

* `suid` - Օգտագործողի ներքին համար (կոդ)։ 
* `newName` -Օգտագործողի նոր ներքին անունը։
* `oldName` - Օգտագործողի նախկին ներքին անունը։

### ValidateNewUsername

```c#
public Task ValidateNewUsername(string username)
```

Վավերացնում է օգտագործողի նշանակվող ներքին անունը։

Անվան դատարկ լինելու կամ նշված ներքին անունով օգտագործողի գոյության դեպքում առաջացնում է սխալ։

**Պարամետրեր**

* `username` - Օգտագործողի նշանակվող անունը։

### SetAccess

```c#
public Task SetAccess(short suid, bool hasAccess)
```

Թույլատրում կամ արգելում է օգտագործողի մուտքը համակարգ։

**Պարամետրեր**

* `suid` - Օգտագործողի ներքին համար (կոդ)։
* `hasAccess` - Ցույց է տալիս օգտագործողը համակարգ մուտք գործելու իրավասություն թե ոչ։ `true` արժեքի դեպքում արգելում է օգտագործողի մուտքը համակարգ, հակառակ դեպքում՝ թույլատրում։ -->