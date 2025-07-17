---
title: ITemplateSubstitutionService.LoadSubstituteAndGetContent(IPrintTemplateSubstitution, string, SubstitutionType, HtmlImageOption, bool) մեթոդ
---

```c#
public Task<string> LoadSubstituteAndGetContent(
    IPrintTemplateSubstitution printTemplateSubstitution, 
    string name, SubstitutionType type, 
    HtmlImageOption htmlImageOption = default,
    bool check = false)
```

Բեռնում է տպելու ձևանմուշը տվյալների պահոցից, լրացնում `printTemplateSubstitution`-ում պարունակվող նախապես հաշվարկված տվյալներով և ստացված ֆայլը վերադարձնում որպես տեքստ։

Նախատեսված է `htm` և `txt` տիպի ձևանմուշների լրացումից հետո վերջնական տեքստը ստանալու համար։

Տե՛ս [օրինակը](../../examples/ITemplateSubstitutionService.md#օրինակ-1)։

**Պարամետրեր**

* `printTemplateSubstitution` - Տպելու ձևանմուշի տեղադրվող արժեքները պարունակող օբյեկտ։
* `name` - Տպելու ձևանմուշի ներքին անուն:
* `type` - [Տպելու ձևանմուշի տիպ][4XTemplateSubstitution]:
* `htmlImageOption` - Html տպվող տեսքերի [պատկերների տեղադրման եղանակ](../../types/HtmlImageOption.md)։
* `check` - Տպելու ձևանմուշում առկա կոդերի ճիշտ շարահյուսության ստուգման հայտանիշ։
