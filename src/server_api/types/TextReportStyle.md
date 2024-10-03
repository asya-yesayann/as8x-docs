---
layout: page
title: "TextReportStyle" 
tags: [AsRepViewer, textReport]
---

Այս enum-ը նախատեսված է տեքստային հաշվետվությունում (TextReport) ավելացող տողի ոճավորման համար։

Պարունակում է HTML թեգերի բազմություն, որոնք կարելի է ավելացնել տեքստին [TextReport](TextReport.md).[ApplyStyle](TextReport.md#applystyle) մեթոդի միջոցով։

```c#
public enum TextReportStyle
{
    Normal = 0,
    Bold = 1,
    Italic = 2,
    Strikethru = 8,
    Underline = 16
}
```

**Արժեքների բազմություն**

* `Normal` - Ոչ մի թեգ տեքստին չի ավելանում։
* `Bold` - Թավ տեքստ։ Օրինակ` **տեքստ**։ 
* `Italic` - Շեղատառ տեքստ։ Օրինակ` *տեքստ*։ 
* `Strikethru` - Վրագծված տեքստ։ Օրինակ` ~~տեքստ~~։
* `Underline` - Ընդգծված տեքստ։ Օրինակ` <u>տեքստ</u>։
