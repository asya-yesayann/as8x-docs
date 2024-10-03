---
layout: page
title: "LanguageService" 
sublinks:
- { title: "CurrentUICultureName", ref: currentuiculturename }
- { title: "IsArmenian", ref: isarmenian }
- { title: "IsEnglish", ref: isenglish }
- { title: "Language", ref: language }
---

## Բովանդակություն
- [Ներածություն](#ներածություն)
- [Հատկություններ](#հատկություններ)
  - [CurrentUICultureName](#currentuiculturename)
  - [IsArmenian](#isarmenian)
  - [IsEnglish](#isenglish)
  - [Language](#language)

## Ներածություն

LanguageService-ը ստատիկ դաս է, որը նախատեսված է ծրագրի ընթացիկ լեզվի կարգավորումները կառավարելու համար: 

8X-ի պրոյեկտներում գոյություն ունեցող ռեսուրսները (Resources) նայում են հենց այս դասի տված հատկություններին հայերեն/անգլերեն տեքստը վերադարձնելու համար։

## Հատկություններ

### CurrentUICultureName

```c#
public static string CurrentUICultureName { get; }
```

Վերադարձնում է ծրագրի ընթացիկ [UI Culture](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo.currentuiculture)-ի անունը:

### IsArmenian

```c#
public static bool IsArmenian { get; }
```

Ցույց է տալիս արդյոք ծրագրի ընթացիկ լեզուն հայերենն է։

### IsEnglish

```c#
public static bool IsEnglish { get; }
```

Ցույց է տալիս արդյոք ծրագրի ընթացիկ լեզուն անգլերենն է։

### Language

```c#
public static Language Language { get; set; }
```

Վերադարձնում կամ նշանակում է ծրագրի [ընթացիկ լեզուն](../types/Language.md)։
