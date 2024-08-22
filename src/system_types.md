---
layout: page
title: "Համակարգային տիպեր"
tags: [FieldType, FieldTypes, type]
---

## Բովանդակություն
- [Բովանդակություն](#բովանդակություն)
- [Ներածություն](#ներածություն)
- [AmAccFieldType](#amaccfieldtype)
- [AmountFieldType](#amountfieldtype)
- [AmountPositiveFieldType](#amountpositivefieldtype)
- [BooleanFieldType](#booleanfieldtype)
- [CHFieldType](#chfieldtype)
- [DateFieldType](#datefieldtype)
- [FileFieldType](#filefieldtype)
- [FolderFieldType](#folderfieldtype)
- [NumericFieldType](#numericfieldtype)
- [NumericPositiveFieldType](#numericpositivefieldtype)
- [NumPairFieldType](#numpairfieldtype)
- [PathFieldType](#pathfieldtype)
- [StringFieldType](#stringfieldtype)
- [TimeFieldType](#timefieldtype)
- [TreeFieldType](#treefieldtype)

## Ներածություն

Համակարգում սահմանված են ներքին տիպեր, որոնք հնարավորություն են տալիս սահմանափակել լրացվող արժեքի երկարությունը, լրացվող արժեքների բազմությունը, ...։

Համակարգային տիպերը օգտագործվում են

* փաստաթղթերի մուտքագրվող դաշտերի տիպերի որոշման համար,
* տվյալների աղբյուրների սյունակների և պարամետրերի տիպերի որոշման համար,
* և այլ տեղերում։

## AmAccFieldType

Հանդիսանում է 4x-ում նկարագրված [AmAcc](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Types/Amacc.html) համակարգային տիպի համարժեքը 8x-ում։
Համարժեք c#-ական ներդրված տիպը [string](https://learn.microsoft.com/en-us/dotnet/api/system.string)-ն է:

Տիպի նոր օբյեկտ ստեղծելու համար անհրաժեշտ է կանչել `FieldTypeProvider` ստատիկ դասի `AmAcc` հատկությունը։

**Օրինակ**

```c#
AmAccFieldType accounting = FieldTypeProvider.AmAcc;
```

## AmountFieldType

Հանդիսանում է 4x-ում նկարագրված [Summa](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Types/Summa.html) համակարգային տիպի համարժեքը 8x-ում։
Համարժեք c#-ական ներդրված տիպը [decimal](https://learn.microsoft.com/en-us/dotnet/api/system.decimal)-ն է։

Տիպի նոր օբյեկտ ստեղծելու համար անհրաժեշտ է կանչել `FieldTypeProvider` ստատիկ դասի `Amount` հատկությունը։

**Օրինակ**

```c#
AmountFieldType summa = FieldTypeProvider.Amount;
```

## AmountPositiveFieldType

Հանդիսանում է 4x-ում նկարագրված [SummaP](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Types/Summap.html) համակարգային տիպի համարժեքը 8x-ում։
Համարժեք c#-ական ներդրված տիպը [decimal](https://learn.microsoft.com/en-us/dotnet/api/system.decimal)-ն է։

Տիպի նոր օբյեկտ ստեղծելու համար անհրաժեշտ է կանչել `FieldTypeProvider` ստատիկ դասի `AmountPositive` հատկությունը։

**Օրինակ**

```c#
AmountPositiveFieldType investmentAmount = FieldTypeProvider.AmountPositive;
```

## BooleanFieldType

Հանդիսանում է 4x-ում նկարագրված [Boolean](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Types/Boolean.html) համակարգային տիպի համարժեքը 8x-ում։
Համարժեք c#-ական ներդրված տիպը [bool](https://learn.microsoft.com/en-us/dotnet/api/system.boolean)-ն է։

Տիպի նոր օբյեկտ ստեղծելու համար անհրաժեշտ է կանչել `FieldTypeProvider` ստատիկ դասի `Boolean` հատկությունը։

**Օրինակ**

```c#
BooleanFieldType isConfirmed = FieldTypeProvider.Boolean;
```

## CHFieldType

Հանդիսանում է 4x-ում նկարագրված [Ch()](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Types/Ch.html) համակարգային տիպի համարժեքը 8x-ում։
Համարժեք c#-ական ներդրված տիպը [string](https://learn.microsoft.com/en-us/dotnet/api/system.string)-ն է:

Տիպի նոր օբյեկտ ստեղծելու համար անհրաժեշտ է կանչել `FieldTypeProvider` ստատիկ դասի `GetCHFieldType` մեթոդը։

**Օրինակ**

```c#
// STDCOM ներքին անունով թղթապանակից առավելագույն 3 երկարություն ունեցող էլեմենտները ներկայացնող CHFieldType դասի օբյեկտ
CHFieldType stdCom = FieldTypeProvider.GetCHFieldType("STDCOM", 3));
```

## DateFieldType

Հանդիսանում է 4x-ում նկարագրված [Date](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Types/Date.html) և [DateLong](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Types/DateLong.html) համակարգային տիպերի համարժեքը 8x-ում։
Համարժեք c#-ական ներդրված տիպը [DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)-ն է։

[Date](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Types/Date.html) տիպի օբյեկտ ստեղծելու համար անհրաժեշտ է կանչել `FieldTypeProvider` ստատիկ դասի `Date` հատկությունը, իսկ [DateLong](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Types/DateLong.html) տիպի օբյեկտ ստեղծելու համար անհրաժեշտ է կանչել `FieldTypeProvider` ստատիկ դասի `DateLong` հատկությունը։

**Օրինակ**

```c#
DateFieldType startDate = FieldTypeProvider.Date;
DateFieldType endDate = FieldTypeProvider.DateLong;
```

## FileFieldType

Հանդիսանում է 4x-ում նկարագրված [File](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Types/File.html) համակարգային տիպի համարժեքը 8x-ում։
Համարժեք c#-ական ներդրված տիպը [string](https://learn.microsoft.com/en-us/dotnet/api/system.string)-ն է:

Տիպի նոր օբյեկտ ստեղծելու համար անհրաժեշտ է կանչել `FieldTypeProvider` ստատիկ դասի `File` հատկությունը։

## FolderFieldType

Հանդիսանում է 4x-ում նկարագրված [Folder()](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Types/Folder.html) համակարգային տիպի համարժեքը 8x-ում։
Համարժեք c#-ական ներդրված տիպը [string](https://learn.microsoft.com/en-us/dotnet/api/system.string)-ն է:

Տիպի նոր օբյեկտ ստեղծելու համար անհրաժեշտ է կանչել `FieldTypeProvider` ստատիկ դասի `GetFolderFieldType` մեթոդը։

**Օրինակ**

```c#
// ACC ներքին անունով թղթապանակի 11 երկարությամբ կոդ ունեցող տարրերը ներկայացնող FolderFieldType դասի օբյեկտի ստեղծում
FolderFieldType folder = Provider.GetFolderFieldType("ACC", 11));
```

## NumericFieldType

Հանդիսանում է 4x-ում նկարագրված [N()](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Types/N.html) համակարգային տիպի համարժեքը 8x-ում։
Համարժեք c#-ական ներդրված տիպը 5-ից փոքր երկարությամբ, կոտորակային մաս չունեցող արժեքների համար short-ն է, 
5-ից 10 երկարությամբ, կոտորակային մաս չունեցող արժեքների համար int-ն է, 
հակառակ դեպքում [decimal](https://learn.microsoft.com/en-us/dotnet/api/system.decimal)-ն է։

Տիպի նոր օբյեկտ ստեղծելու համար անհրաժեշտ է կանչել `FieldTypeProvider` ստատիկ դասի `GetNumericFieldType` մեթոդը։

**Օրինակ**

```c#
// առավելագունը 10 երկարությամբ և կոտորակային մաս չունեցող NumericFieldType դասի օբյեկտի ստեղծում
NumericFieldType isn = FieldTypeProvider.GetNumericFieldType(10, 0);

// առավելագունը 10 երկարությամբ և 2 երկարությամբ կոտորակային մաս ունեցող NumericFieldType դասի օբյեկտի ստեղծում
NumericFieldType number = FieldTypeProvider.GetNumericFieldType(7, 2);
```

## NumericPositiveFieldType

Հանդիսանում է 4x-ում նկարագրված [NP()](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Types/Np.html) համակարգային տիպի համարժեքը 8x-ում։
Համարժեք c#-ական ներդրված տիպը 5-ից փոքր երկարությամբ, կոտորակային մաս չունեցող արժեքների համար short-ն է, 
5-ից 10 երկարությամբ, կոտորակային մաս չունեցող արժեքների համար int-ն է, 
հակառակ դեպքում [decimal](https://learn.microsoft.com/en-us/dotnet/api/system.decimal)-ն է։

Տիպի նոր օբյեկտ ստեղծելու համար անհրաժեշտ է կանչել `FieldTypeProvider` ստատիկ դասի `GetNumericPositiveFieldType` մեթոդը։

**Օրինակ**

```c#
// առավելագունը 10 երկարությամբ և կոտորակային մաս չունեցող NumericPositiveFieldType դասի օբյեկտի ստեղծում
NumericPositiveFieldType isn = FieldTypeProvider.GetNumericPositiveFieldType(10, 0);

// առավելագունը 10 երկարությամբ և 2 երկարությամբ կոտորակային մաս ունեցող NumericPositiveFieldType դասի օբյեկտի ստեղծում
NumericPositiveFieldType number = FieldTypeProvider.GetNumericPositiveFieldType(7, 2);
```

## NumPairFieldType

Հանդիսանում է 4x-ում նկարագրված [NumPair()](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Types/NumPair.html) համակարգային տիպի համարժեքը 8x-ում։
Համարժեք c#-ական ներդրված տիպը [string](https://learn.microsoft.com/en-us/dotnet/api/system.string)-ն է:

Տիպի նոր օբյեկտ ստեղծելու համար անհրաժեշտ է կանչել `FieldTypeProvider` ստատիկ դասի `GetNumPairFieldType` մեթոդը։

**Օրինակ**

```c#
NumPairFieldType period =  FieldTypeProvider.GetNumPairFieldType(
                              FieldTypeProvider.GetNumericPositiveFieldType(3, 0),
                              FieldTypeProvider.GetNumericPositiveFieldType(4, 0), 
                              "ամիս , օր , months , days".ToArmenianANSI()));
```

## PathFieldType

Հանդիսանում է 4x-ում նկարագրված [Path](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Types/Path.html) համակարգային տիպի համարժեքը 8x-ում։
Համարժեք c#-ական ներդրված տիպը [string](https://learn.microsoft.com/en-us/dotnet/api/system.string)-ն է:

Տիպի նոր օբյեկտ ստեղծելու համար անհրաժեշտ է կանչել `FieldTypeProvider` ստատիկ դասի `Path` հատկությունը։

**Օրինակ**

```c#
PathFieldType path = FieldTypeProvider.Path;
```

## StringFieldType

Հանդիսանում է 4x-ում նկարագրված [C()](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Types/C.html) համակարգային տիպի համարժեքը 8x-ում։
Համարժեք c#-ական ներդրված տիպը [string](https://learn.microsoft.com/en-us/dotnet/api/system.string)-ն է:

Տիպի նոր օբյեկտ ստեղծելու համար անհրաժեշտ է կանչել `FieldTypeProvider` ստատիկ դասի `GetStringFieldType` մեթոդը։

**Օրինակ**

```c#
// առավելագույն 50 երկարությամբ StringFieldType դասի օբյեկտի ստեղծում
StringFieldType name = FieldTypeProvider.GetStringFieldType(50);
```

## TimeFieldType

Հանդիսանում է 4x-ում նկարագրված [Time](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Types/Time.html) և [TimeLong](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Types/TimeLong.html) համակարգային տիպերի համարժեքը 8x-ում։
Համարժեքը c#-ական ներդրված տիպը [DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)-ն է։

[Time](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Types/Time.html) տիպի օբյեկտ ստեղծելու համար անհրաժեշտ է կանչել `FieldTypeProvider` ստատիկ դասի `Time` հատկությունը, իսկ [TimeLong](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Types/TimeLong.html) տիպի օբյեկտ ստեղծելու համար անհրաժեշտ է կանչել `FieldTypeProvider` ստատիկ դասի `TimeLong` հատկությունը։

**Օրինակ**

```c#
TimeFieldType creationTime = FieldTypeProvider.Time;
TimeFieldType checkTime = FieldTypeProvider.TimeLong;
```

## TreeFieldType

Հանդիսանում է 4x-ում նկարագրված [Tree()](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Types/Tree.html) և [FullTree()](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Types/FULLTREE.html) համակարգային տիպերի համարժեքը 8x-ում։
Համարժեք c#-ական ներդրված տիպը [string](https://learn.microsoft.com/en-us/dotnet/api/system.string)-ն է:

Տիպի նոր օբյեկտ ստեղծելու համար անհրաժեշտ է կանչել `FieldTypeProvider` ստատիկ դասի `GetTreeFieldType` մեթոդը։


```c#
// USERS ներքին անունով TreeFieldType դասի օբյեկտի ստեղծում
TreeFieldType users = FieldTypeProvider.GetTreeFieldType("USERS");

// PARGROUP ներքին անունով FullTree տիպի TreeFieldType դասի օբյեկտի ստեղծում
TreeFieldType groups = FieldTypeProvider.GetTreeFieldType("PARGROUP", true);
```
