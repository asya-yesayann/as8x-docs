---
title: ITemplateSubstitutionService.LoadSubstitutionAndGetStorage(IPrintTemplateSubstitution, string, SubstitutionType, HtmlImageOption, string, bool) մեթոդ
---

```c#
public Task<StorageInfo> LoadSubstitutionAndGetStorage(
    IPrintTemplateSubstitution printTemplateSubstitution, 
    string name, SubstitutionType type, 
    HtmlImageOption htmlImageOption = default,
    string outputPassword = "", bool check = false)
```

Բեռնում է տպելու ձևանմուշը տվյալների պահոցից, լրացնում `printTemplateSubstitution`-ում պարունակվող նախապես հաշվարկված տվյալներով, պահում ֆայլում և վերադարձնում ֆայլի նույնականացուցիչը սերվերում։

**Պարամետրեր**

* `printTemplateSubstitution` - Տպելու ձևանմուշի տեղադրվող արժեքները պարունակող օբյեկտ։
* `name` - Տպելու ձևանմուշի ներքին անուն:
* `type` - [Տպելու ձևանմուշի տիպ][4XTemplateSubstitution]:
* `htmlImageOption` - Html տպվող տեսքերի [պատկերների տեղադրման եղանակ](../../types/HtmlImageOption.md)։
* `outputPassword` - Վերջնական ֆայլի բացման գաղտնաբառը։
* `check` - Տպելու ձևանմուշում առկա կոդերի ճիշտ շարահյուսության ստուգման հայտանիշ։
