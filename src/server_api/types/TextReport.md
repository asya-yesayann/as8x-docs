---
layout: page
title: "TextReport" 
tags: AsRepViewer
---

## Բովանդակություն

- [Ներածություն](#ներածություն)
- [Հատկություններ](#հատկություններ)
  - [ArmenianCaption](#armeniancaption)
  - [Caption](#caption)
  - [DocBased](#docbased)
  - [EnglishCaption](#englishcaption)
  - [FileName](#filename)
  - [MaxLength](#maxlength)
  - [PrintStyle](#printstyle)
  - [RowCount](#rowcount)
  - [UnmoveFragment](#unmovefragment)
  - [UnmoveHeadCount](#unmoveheadcount)
  - [UseFormatting](#useformatting)
- [Մեթոդներ](#մեթոդներ)
  - [AddFooter](#addfooter)
  - [AddFragment](#addfragment)
  - [AddHeader](#addheader)
  - [AddRow](#addrow)
  - [ApplyStyle](#applystyle)
  - [Break](#break)
  - [GetRows](#getrows)
  - [InsertRows](#insertrows)
  - [SaveToStorageAndClose](#savetostorageandclose)

## Ներածություն

Համակարգում տեղեկատուի տեսքով հաշվետվություն ցույց տալու համար նկարագրվում է TextReport։

TextReport-ի ստեղծման, լրացման ու պահման օրինակի համար [տե՛ս](../definitions/dpr_guide.md):

## Հատկություններ

### ArmenianCaption

```c#
public string ArmenianCaption { get; set; } = string.Empty;
```

Վերադարձնում կամ նշանակում է հաշվետվության հայերեն անվանումը։

### Caption

```c#
public string Caption { get; }
```

Վերադարձնում է հաշվետվության անվանումը ծրագրի ընթացիկ լեզվով։

### DocBased

```c#
public bool DocBased { get; set; }
```

Վերադարձնում կամ նշանակում է հաշվետվությունում փաստաթղթեր ունենալու հայտանիշը։ 

`true` արժեքի դեպքում այն տողերում, որտեղ նշվում է փաստաթղթի ներքին նույնականացման համարը (isn), հասանելի կդառնան փաստաթղթի գործողությունները կոնտեքստային մենյույում։

### EnglishCaption

```c#
public string EnglishCaption { get; set; } = string.Empty;
```

Վերադարձնում կամ նշանակում է հաշվետվության անգլերեն անվանումը։

### FileName

```c#
public string FileName { get; protected set; }
```

Վերադարձնում է հաշվետվությունը պարունակող ֆայլի ճանապարհը։

### MaxLength

```c#
public int MaxLength { get; protected set; }
```

Վերադարձնում է հաշվետվություն [AddFragment](#addfragment) մեթոդի միջոցով ավելացված բոլոր հատվածների լայնությունների գումարը։

### PrintStyle

```c#
public string PrintStyle { get; set; } = string.Empty;
```

Վերադարձնում կամ նշանակում է հաշվետվության տպելու կարգավորումները (լուսանցքներ, տառաչափ, պատճենների քանակ...) պարունակող [PrintStyle](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Defs/PrintStyle.html) տիպի համակարգային նկարագրության ներքին անունը։

Անհրաժեշտ է նախօրոք նկարագրել [PrintStyle](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Defs/PrintStyle.html) տիպի համակարգային նկարագրություն, ներմուծել տվյալների պահոց `Syscon` գործիքի միջոցով և նկարագրության ներքին անունը փոխանցել այս հատկությանը։

### RowCount

```c#
public long RowCount { get; protected set; }
```

Վերադարձնում կամ նշանակում է հաշվետվության տողերի քանակը։

### UnmoveFragment

```c#
public bool UnmoveFragment { get; set; }
```

Վերադարձնում կամ նշանակում է չշարժվող հատվածի առկայությունը (հատվածը մնում է նույն դիրքում հորիզոնական շարժման ժամանակ)։

Չշարժվող հատված միշտ դառնում է [AddFragment](#addfragment) մեթոդի միջոցով ավելացված հատվածներից առաջինը։

### UnmoveHeadCount

```c#
public int UnmoveHeadCount { get; set; }
```

Վերադարձնում կամ նշանակում է չտեղափոխվող գլխագրերի քանակը, եթե առկա է [անշարժ հատված](#unmovefragment)։

Այս դաշտին հարկավոր է արժեք վերագրել [AddHeader](#addheader) մեթոդի կանչերից հետո և նշել այն գլխագրերի քանակը, որ հարկավոր է չշարժել հորիզոնական շարժման ժամանակ։

**Օրինակ**

```c#
var report = new TextReport(storageService);
report.AddHeader("Հաշվետվություն");
report.AddHeader("Շահառուի եկամուտների և ծախսերի վերաբերյալ");
report.UnmoveHeadCount = 1;
```

### UseFormatting

```c#
public bool UseFormatting { get; set; }
```

Վերադարձնում կամ նշանակում է հաշվետվությունում տեքստի ձևաչափեր օգտագործելու հայտանիշը։
 
`true` արժեքի դեպքում հնարավոր է հաշվետվությունում ավելացնել հատուկ թեգեր (`<b>`, `<i>`, `<s>`, `<u>`) պարունակող տեքստ, որը հնարավորությունը է տալիս տեքստը դարձնել թավ, շեղատառ, վրագծված կամ ընդգծված։

Հաշվետվությունում թեգավորված տեքստ ավելացնելու համար տե՛ս [ApplyStyle](#applystyle):

## Մեթոդներ

### AddFooter

```c#
public void AddFooter(string footer)
```

Ավելացնում է նոր տող հաշվետվության ստորին հատվածում։

**Պարամետրեր**

* `footer` - Ավելացվող տողի տեքստ։

### AddFragment

```c#
public void AddFragment(int width)
```

Ավելացնում է նշված լայնությամբ հատված հաշվետվությունում։

**Պարամետրեր**

* `width` - Հատվածի լայնություն (նիշերի քանակ)։

### AddHeader

```c#
public void AddHeader(string header)
```

Ավելացնում է գլխագրի նոր տող հաշվետվության վերին հատվածում։

**Պարամետրեր**

* `width` - Ավելացվող տողի տեքստ։

**Օրինակ**

```c#
report.AddHeader("Հաշվետվություն");
report.AddHeader("Շահառուի եկամուտների և ծախսերի վերաբերյալ");
```

### AddRow

```c#
public void AddRow(string row, int isn = -1, string rowDesc = "", int splitSize = -1)
```

Ավելացնում է նոր տող հաշվետվությունում։

Տողը ավելացնելուց հնարավոր է նշել տողի հետ կապված փաստաթուղթը, որի համար կարող են բացվել փաստաթղթի գործողությունները, եթե միացված է հաշվետվության [DocBased](#docbased) հայտանիշը։

**Պարամետրեր**

* `row` - Ավելացվող տողի տեքստ։
* `isn` - Հաշվետվությանը կապակցված փաստաթղթի ներքին նույնականացման համար։
* `rowDesc` - Ավելացվող տողի նկարագրություն։
* `splitSize` - Ավելացվող տեքստի մասնատման երկարություն։ Ավելացվող տեքստը բաժանվում է այս պարամետրում նշված երկարությամբ մասերի և յուրաքանչյուր մասը ավելացվում է նոր տողից։ Արժեք չփոխանցելու դեպքում տեքստը ավելանում է որպես մեկ ամբողջական տող։

**Օրինակ**

```c#
var report = new TextReport(storageService);
report.AddRow("Հաշվետվություն");
report.AddRow(new string('-', 20));
report.AddRow("Տրման ամսաթիվ" + DateTime.Now);
```

### ApplyStyle

```c#
public static string ApplyStyle(string source, TextReportStyle style)
```

Ֆորմատավորում է նշված տեքստը՝ ավելացնելով հատուկ թեգեր, որի միջոցով տեքստը հնարավոր է դարձնել թավ, շեղատառ, վրագծված կամ ընդգծված։

Այս մեթոդը կիրառելուց առաջ անհրաժեշտ է հաշվետվության [UseFormatting](#useformatting) հատկության արժեքը դնել `true`:

Ֆորմատավորված տեքստը ավելացվում է հաշվետվությանը [AddRow](#addrow), [AddHeader](#addheader), [AddFooter](#addfooter) մեթոդների միջոցով։

**Պարամետրեր**

* `source` - Ֆորմատավորման ենթակա տեքստը։
* `style` - [Ավելացվող թեգի տեսակը](TextReportStyle.md)։

**Օրինակ**

```c#
var report = new TextReport(storageService);
var formattedText = TextReport.ApplyStyle("Հաճախորդի հաշիվ", TextReportStyle.Bold);
report.AddRow(formattedText);
```

### Break

```c#
public void Break()
```

Ավելացնում է դատարկ նոր տող հաշվետվությունում։

### GetRows

```c#
public Task<List<TextReportRow>> GetRows(long startRow, long rowCount)
```

Վերադարձնում է հաշվետվության նշված տողերի ցուցակը։

**Պարամետրեր**

* `startRow` - Տողի համար, որից սկսած վերադարձվում են հաշվետվության տողերը։
* `rowCount` - Վերադարձվող տողերի քանակը՝ սկսած `startRow` համարի տողից։

### InsertRows

```c#
public Task InsertRows(TextReport textReport, long begin = 0, long rowCount = 0)
```

Ավելացնում է `textReport` հաշվետվության նշված տողերը ընթացիկ հաշվետվությունում։ 

**Պարամետրեր**

* `textReport` - Այն հաշվետվությունը, որի տողերը պետք է ավելացվեն ընթացիկ հաշվետվությունում։
* `begin` - `textReport` հաշվետվության տողի համար, որից սկսած ավելացվում են տողերը ընթացիկ հաշվետվությունում։ 
* `rowCount` - Ավելացվող տողերի քանակը՝ սկսած `begin` համարի տողից։ 

### SaveToStorageAndClose

```c#
public Task<StorageInfo> SaveToStorageAndClose()
```

Փակում է հաշվետվությունը և պահպանում [ընթացիկ սեսսիայի կոնտեյներում](../services/IStorageService.md#container):

Վերադարձնում է հաշվետվությունը պարունակող [կոնտեյների](../services/IStorageService.md#container) և ֆայլի անունները։ 
