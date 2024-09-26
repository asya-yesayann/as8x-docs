---
layout: page
title: "IHolidaysService սերվիս" 
---

## Բովանդակություն

- [Ներածություն](#ներածություն)
- [Մեթոդներ](#մեթոդներ)
  - [GetNextWorkDay](#getnextworkday)
  - [GetPreviousWorkDay](#getpreviousworkday)
  - [IsHoliday](#isholiday)
  - [IsWorkday](#isworkday)

## Ներածություն

IHolidaysService դասը նախատեսված է աշխատանքային և տոն օրերի որոշման և ստացման համար։

## Մեթոդներ

### GetNextWorkDay

```c#
public Task<DateTime> GetNextWorkDay(DateTime value)
```

Վերադարձնում է տրված ամսաթվին հաջորդող առաջին աշխատանքային օրը:

**Պարամետրեր**

* `value`- Ամսաթիվ, որից սկսած որոնվում է հաջորդ աշխատանքային օրը:

### GetPreviousWorkDay

```c#
public Task<DateTime> GetPreviousWorkDay(DateTime value)
```

Վերադարձնում է տրված ամսաթվին նախորդող առաջին աշխատանքային օրը:

**Պարամետրեր**

* `value`- Ամսաթիվ, որից սկսած որոնվում է նախորդ աշխատանքային օրը:

### IsHoliday

```c#
public Task<bool> IsHoliday(DateTime value)
```

Ստուգում է արդյոք տրված ամսաթիվը տոն/ոչ աշխատանքային օր է։

**Պարամետրեր**

* `value`- Ստուգման ենթակա ամսաթիվը։

### IsWorkday

```c#
public Task<bool> IsWorkday(DateTime value)
```

Ստուգում է արդյոք տրված ամսաթիվը աշխատանքային օր է։

**Պարամետրեր**

* `value`- Ստուգման ենթակա ամսաթիվը։
