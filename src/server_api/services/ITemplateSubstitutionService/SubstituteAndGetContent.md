---
title: ITemplateSubstitutionService.SubstituteAndGetContent(IPrintTemplateSubstitution, byte[], SubstitutionType, HtmlImageOption, bool, bool) մեթոդ
---

```c#
public string SubstituteAndGetContent(IPrintTemplateSubstitution printTemplateSubstitution, 
                                      byte[] file, SubstitutionType type, 
                                      HtmlImageOption htmlImageOption = default,
                                      bool isUnicode = false, bool check = false)
```

Լրացնում Է տպելու ձևանմուշը `printTemplateSubstitution`-ում պարունակվող նախապես հաշվարկված տվյալներով և վերադարձնում որպես տեքստ։

**Պարամետրեր**

* `printTemplateSubstitution` - Տպելու ձևանմուշի տեղադրվող արժեքները պարունակող օբյեկտ։
* `file` - Տպելու ձևանմուշի պարունակությունը որպես byte տիպի զանգված։
* `type` - [Տպելու ձևանմուշի տիպ][4XTemplateSubstitution]:
* `htmlImageOption` - Html տպվող տեսքերի [պատկերների տեղադրման եղանակ](../../types/HtmlImageOption.md)։
* `isUnicode` - Տպելու ձևանմուշի տվյալների `Unicode` կոդավորմամբ լրացման հայտանիշ։
* `check` - Տպելու ձևանմուշում առկա կոդերի ճիշտ շարահյուսության ստուգման հայտանիշ։

<!-- ### SubstituteAndGetContent

```c#
public Task<string> SubstituteAndGetContent(IPrintTemplateSubstitution printTemplateSubstitution, 
                                            StorageInfo file, SubstitutionType type, 
                                            HtmlImageOption htmlImageOption = default,
                                            bool isUnicode = false, bool check = false)
```

Լրացնում Է տպելու ձևանմուշը `printTemplateSubstitution`-ում պարունակվող նախապես հաշվարկված տվյալներով և վերադարձնում որպես տեքստ։

**Պարամետրեր**

* `printTemplateSubstitution` - Տպելու ձևանմուշի տեղադրվող արժեքները պարունակող օբյեկտ։
* `file` - Տպելու ձևանմուշը պարունակող ֆայլի և թղթապանակի անունները։
* `type` - [Տպելու ձևանմուշի տիպ][4XTemplateSubstitution]:
* `htmlImageOption` - Html տպվող տեսքերի [պատկերների տեղադրման եղանակ](../../types/HtmlImageOption.md)։
* `isUnicode` - Տպելու ձևանմուշի տվյալների `Unicode` կոդավորմամբ լրացման հայտանիշ։
* `check` - Տպելու ձևանմուշում առկա կոդերի ճիշտ շարահյուսության ստուգման հայտանիշ։ -->
