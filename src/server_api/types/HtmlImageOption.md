---
layout: page
title: "HtmlImageOption" 
---

Այս enum-ը նախատեսված է Html տպելու ձևանմուշների լրացման ժամանակ պատկերների տեղադրման եղանակի սահմանման համար։

```c#
public enum HtmlImageOption
{
    None = -1,
    RelativePath,
    AbsolutePath,
    Base64
}
```

**Արժեքների բազմություն**

* `None` - Պատկերները չեն տեղադրվելու։
* `RelativePath` - Տրված ճանապարհից ստացվում և տեղադրվում է միայն պատկերի անվանումը (օր.՝ "HtmlImage.jpg")
* `AbsolutePath` - Տեղադրվում է տրված ճանապարհը ամբողջությամբ (օր.՝ "C:\\HtmlImage.jpg")
* `Base64` - Տեղադրվում է PrintTemplateSubstitutionImage-ում տրված File base64 ֆորմատով։
