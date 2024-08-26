---
layout: page
title: "FieldTypeProvider"
---

- [Ներածություն](#ներածություն)
- [Մեթոդներ](#մեթոդներ)
  - [GetCHFieldType](#getchfieldtype)
  - [GetFileFieldType](#getfilefieldtype)
  - [GetFolderFieldType](#getfolderfieldtype)
  - [GetNumericFieldType](#getnumericfieldtype)
  - [GetNumericPositiveFieldType](#getnumericpositivefieldtype)
  - [GetNumPairFieldType](#getnumpairfieldtype)
  - [GetStringFieldType](#getstringfieldtype)
- [Հատկություններ](#հատկություններ)
  - [AmAcc](#amacc)
  - [Amount](#amount)
  - [AmountPositive](#amountpositive)
  - [Boolean](#boolean)
  - [Date](#date)
  - [DateLong](#datelong)
  - [File](#file)
  - [Path](#path)
  - [Time](#time)
  - [TimeLong](#timelong)


## Ներածություն

FieldTypeProvider ստատիկ դասը նախատեսված է համակարգային տիպերը ներկայացնող դասերի օբյեկտների ստեղծման համար և քեշավորման համար։

```c#
public static class FieldTypeProvider
```

## Մեթոդներ

### GetCHFieldType

```c#
public static CHFieldType GetCHFieldType(string name, short length, short commentLength = 0, bool isNullable = false)
```

Վերադարձնում է [CHFieldType](system_types.md#chfieldtype) դասի օբյեկտ քեշից կամ ստեղծում նորը քեշում բացակայության դեպքում և քեշավորում։

**Պարամետրեր**

* `name` - Ծառ-տեղեկատուի կամ թղթապանակի ներքին անունը, որը համարվում է մեկնաբանության աղբյուր։
* `length` - Թույլատրելի նիշերի քանակը։ Առավելագույնը 512։
* `commentLength` - Դաշտի կողքից գրվող տեքստի նիշերի քանակ։ Լռությամբ արժեքը **0** է, այլ կերպ ասած ուղեկցող տեքստը բացակայում է։
* `isNullable` - Կարող է ընդունել null արժեք, թե ոչ։ Լռությամբ արժեքը **false** է։

### GetFileFieldType

```c#
public static FileFieldType GetFileFieldType(string fileTypes, bool isNullable = false)
```

Վերադարձնում է FileFieldType դասի օբյեկտ քեշից կամ ստեղծում նորը քեշում բացակայության դեպքում և քեշավորում։

**Պարամետրեր**

* `fileTypes` - 
* `isNullable` - Կարող է ընդունել null արժեք, թե ոչ։ Լռությամբ արժեքը **false** է։

### GetFolderFieldType

```c#
public static FolderFieldType GetFolderFieldType(string name, short length, bool isNullable = false)
```

Վերադարձնում է [FolderFieldType](system_types.md#folderfieldtype) դասի օբյեկտ քեշից կամ ստեղծում նորը քեշում բացակայության դեպքում և քեշավորում։

**Պարամետրեր**

* `name` - Թղթապանակի ներքին անուն, որի առավելագույն թույլատրելի երկարությունը 20 նիշ է։
* `length` - Թղթապանակի բանալու երկարություն։
* `isNullable` - Կարող է ընդունել null արժեք, թե ոչ։ Լռությամբ արժեքը **false** է։

### GetNumericFieldType

```c#
public static NumericFieldType GetNumericFieldType(short fieldLength, short fractionalPartLength = 0,
                                                   bool useCurrencyFormat = false, string csType = "", bool isNullable = false)
```

Վերադարձնում է [NumericFieldType](system_types.md#numericfieldtype) դասի օբյեկտ քեշից կամ ստեղծում նորը քեշում բացակայության դեպքում և քեշավորում։

**Պարամետրեր**

* `fieldLength` - Թվի նիշերի ընդհանուր քանակ։ Նիշերի առավելագույն քանակը կարող է լինել 19 (ներառյալ կետի նշանը)։
* `fractionalPartLength` - Նիշերի քանակը կետից հետո, այսինքն կոտորակային մասի երկարությունը։ Կետից հետո նիշերի առավելագույն քանակը կարող է լինել 4։
* `useCurrencyFormat` - 1 արժեքի դեպքում դաշտի մեջ ցույց են տրվում հազարականների բաժանող ստորակետները։ Լռությամբ արժեքը 0։
* `csType` - 
* `isNullable` - Կարող է ընդունել null արժեք, թե ոչ։ Լռությամբ արժեքը **false** է։

### GetNumericPositiveFieldType

```c#
public static NumericPositiveFieldType GetNumericPositiveFieldType(short fieldLength,
                                                                   short fractionalPartLength = 0, bool useCurrencyFormat = false,
                                                                   string csType = "", bool isNullable = false)
```

Վերադարձնում է [NumericPositiveFieldType](system_types.md#numericpositivefieldtype) դասի օբյեկտ քեշից կամ ստեղծում նորը քեշում բացակայության դեպքում և քեշավորում։

**Պարամետրեր**

* `fieldLength` - Թվի նիշերի ընդհանուր քանակ։ Նիշերի առավելագույն քանակը կարող է լինել 19 (ներառյալ կետի նշանը)։
* `fractionalPartLength` - Նիշերի քանակը կետից հետո, այսինքն կոտորակային մասի երկարությունը։ Կետից հետո նիշերի առավելագույն քանակը կարող է լինել 4։
* `useCurrencyFormat` - 1 արժեքի դեպքում դաշտի մեջ ցույց են տրվում հազարականների բաժանող ստորակետները։ Լռությամբ արժեքը 0։
* `csType` - 
* `isNullable` - Կարող է ընդունել null արժեք, թե ոչ։ Լռությամբ արժեքը **false** է։

### GetNumPairFieldType

```c#
public static NumPairFieldType GetNumPairFieldType(NumericFieldType numericField1, NumericFieldType numericField2, string comment, bool isNullable = false)
```

Վերադարձնում է [NumPairFieldType](system_types.md#numericpositivefieldtype) դասի օբյեկտ քեշից կամ ստեղծում նորը քեշում բացակայության դեպքում և քեշավորում։

**Պարամետրեր**

* `numericField1` - NumericFieldType դասի օբյեկտ։
* `numericField2` - NumericFieldType դասի օբյեկտ։
* `comment` - Երկու արժեքների բաժանարար տեքստը։ Չփոխանցելու դեպքում կիրառվում է / նշանը։
* `isNullable` - Կարող է ընդունել null արժեք, թե ոչ։ Լռությամբ արժեքը **false** է։

### GetStringFieldType

```c#
public static StringFieldType GetStringFieldType(short fieldLength, bool isNullable = false)
```

Վերադարձնում է [StringFieldType](system_types.md#stringfieldtype) դասի օբյեկտ քեշից կամ ստեղծում նորը քեշում բացակայության դեպքում և քեշավորում։

**Պարամետրեր**

* `fieldLength` - Տողային արժեքի մեջ առավելագույն նիշերի քանակ։ Առավելագույնը՝ 512։
* `isNullable` - Կարող է ընդունել null արժեք, թե ոչ։ Լռությամբ արժեքը **false** է։

## Հատկություններ

### AmAcc

```c#
public static AmAccFieldType AmAcc { get; }
```

Վերադարձնում է [AmAccFieldType](system_types.md#amaccfieldtype) դասի օբյեկտ քեշից կամ ստեղծում նորը քեշում բացակայության դեպքում և քեշավորում։

### Amount

```c#
public static AmountFieldType Amount { get; }
```

Վերադարձնում է [AmountFieldType](system_types.md#amaccfieldtype) դասի օբյեկտ քեշից կամ ստեղծում նորը քեշում բացակայության դեպքում և քեշավորում։

### AmountPositive

```c#
public static AmountPositiveFieldType AmountPositive { get; }
```

Վերադարձնում է [AmountPositiveFieldType](system_types.md#amountpositivefieldtype) դասի օբյեկտ քեշից կամ ստեղծում նորը քեշում բացակայության դեպքում և քեշավորում։

### Boolean

```c#
public static BooleanFieldType Boolean { get; }
```

Վերադարձնում է [BooleanFieldType](system_types.md#booleanfieldtype) դասի օբյեկտ քեշից կամ ստեղծում նորը քեշում բացակայության դեպքում և քեշավորում։

### Date

```c#
public static DateFieldType Date { get; }
```

Վերադարձնում է [DateFieldType](system_types.md#datefieldtype) դասի օբյեկտ քեշից կամ ստեղծում նորը քեշում բացակայության դեպքում և քեշավորում։

### DateLong

```c#
public static DateFieldType DateLong { get; }
```

Վերադարձնում է Long տիպի [DateFieldType](system_types.md#datefieldtype) դասի օբյեկտ քեշից կամ ստեղծում նորը քեշում բացակայության դեպքում և քեշավորում։

### File

```c#
public static FileFieldType File { get; }
```

Վերադարձնում է [FileFieldType](system_types.md#filefieldtype) դասի օբյեկտ քեշից կամ ստեղծում նորը քեշում բացակայության դեպքում և քեշավորում։

### Path

```c#
public static PathFieldType Path { get; }
```

Վերադարձնում է [PathFieldType](system_types.md#pathfieldtype) դասի օբյեկտ քեշից կամ ստեղծում նորը քեշում բացակայության դեպքում և քեշավորում։

### Time

```c#
public static TimeFieldType Time { get; }
```

Վերադարձնում է [TimeFieldType](system_types.md#timefieldtype) դասի օբյեկտ քեշից կամ ստեղծում նորը քեշում բացակայության դեպքում և քեշավորում։

### TimeLong

```c#
public static TimeFieldType Time { get; }
```

Վերադարձնում է Long տիպի [TimeFieldType](system_types.md#timefieldtype) դասի օբյեկտ քեշից կամ ստեղծում նորը քեշում բացակայության դեպքում և քեշավորում։
