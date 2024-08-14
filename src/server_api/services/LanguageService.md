---
layout: page
title: "LanguageService" 
tags: [LanguageService, language]
---

## Բովանդակություն
- [Ներածություն](#ներածություն)
- [Հատկություններ](#հատկություններ)
  - [CurrentUICultureName](#currentuiculturename)
  - [IsArmenian](#isarmenian)
  - [IsEnglish](#isenglish)
  - [Language](#language)

## Ներածություն

LanguageService-ը ստատիկ դաս է, որը նախատեսված է 8X Service և 8X Client ծրագրերի լեզվի կարգավորումները կառավարելու համար: Այն տրամադրում է ֆունկցիոնալություն՝ ընթացիկ լեզուն սահմանելու, ստուգելու, ստանալու  և ընթացիկ UI Culture-ի անվանումը ստանալու համար:

## Հատկություններ

### CurrentUICultureName

```c#
public static string CurrentUICultureName { get; }
```

Վերադարձնում է ծրագրի ընթացիկ UI Culture-ի անունը:

### IsArmenian

```c#
public static bool IsArmenian { get; }
```

Ցույց է տալիս արդյոք ծրագրի ընթացիկ լեզուն անգլերենն է։

### IsEnglish

```c#
public static bool IsEnglish { get; }
```

Ցույց է տալիս արդյոք ծրագրի ընթացիկ լեզուն անգլերենն է։

### Language

```c#
public static Language Language { get; set; }
```

Վերադարձնում կամ նշանակում է ծրագրի [ընթացիկ լեզուն](Language.md)։
