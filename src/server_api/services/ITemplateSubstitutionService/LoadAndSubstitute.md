---
title: ITemplateSubstitutionService.LoadAndSubstitute(IPrintTemplateSubstitution, string, SubstitutionType, HtmlImageOption, string, bool) մեթոդ
---

```c#
public Task<Stream> LoadAndSubstitute(
    IPrintTemplateSubstitution printTemplateSubstitution, 
    string name, SubstitutionType type, 
    HtmlImageOption htmlImageOption = default,
    string outputPassword = "", bool check = false)
```

Բեռնում է տպելու ձևանմուշը տվյալների պահոցից, լրացնում `printTemplateSubstitution`-ում պարունակվող նախապես հաշվարկված տվյալներով և ստացված ֆայլը վերադարձնում որպես [Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream):

**Պարամետրեր**

* `printTemplateSubstitution` - Տպելու ձևանմուշի տեղադրվող արժեքները պարունակող օբյեկտ։
* `name` - Տպելու ձևանմուշի ներքին անուն:
* `type` - [Տպելու ձևանմուշի տիպ][4XTemplateSubstitution]:
* `htmlImageOption` - Html տպվող տեսքերի [պատկերների տեղադրման եղանակ](../../types/HtmlImageOption.md)։
* `outputPassword` - Վերջնական ֆայլի բացման գաղտնաբառը։
* `check` - Տպելու ձևանմուշում առկա կոդերի ճիշտ շարահյուսության ստուգման հայտանիշ։
