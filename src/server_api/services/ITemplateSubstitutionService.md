---
layout: page
title: "ITemplateSubstitutionService" 
tags: [Template, TemplateSubstitution]
---

## Բովանդակություն

- [Ներածություն](#ներածություն)
- [Մեթոդներ](#մեթոդներ)
  - [EvalAndAddUserDefinedParameters](#evalandadduserdefinedparameters)
  - [EvalAndAddUserDefinedParametersEx](#evalandadduserdefinedparametersex)
  - [GetReadyTemplateSubstitution](#getreadytemplatesubstitution)
  - [IsTemplateAvailable](#istemplateavailable)
  - [LoadAndSubstitute](#loadandsubstitute)
  - [LoadSubstituteAndGetContent](#loadsubstituteandgetcontent)
  - [LoadSubstitutionAndGetStorage](#loadsubstitutionandgetstorage)
  - [LoadTemplateFile](#loadtemplatefile)
  <!-- - [MergeFile](#mergefile) --> 
  <!-- - [MergeFile](#mergefile) --> 
  - [Substitute](#substitute)
  - [Substitute](#substitute-1)
  - [SubstituteAndGetContent](#substituteandgetcontent)
  - [SubstituteAndGetContent](#substituteandgetcontent-1)


## Ներածություն

ITemplateSubstitutionService դասը նախատեսված է տպելու ձևանմուշների լրացման հետ աշխատանքը ապահովելու համար։
 
## Մեթոդներ

### EvalAndAddUserDefinedParameters

```c#
public Task EvalAndAddUserDefinedParameters(string name, SubstitutionType type,
                                            PrintTemplateSubstitution printTemplateSubstitution,
                                            Document.Document document)
```

Հաշվարկում է տպելու ձևանմուշի օգտագործողի կողմից նկարագրված պարամետրերը։

Տպելու ձևանմուշի օգտագործողի կողմից նկարագրված պարամետրերի հաշվարկի տրամաբանության սահմանման համար անհրաժեշտ է սահմանել տպելու ձևանմուշի ընդլայնման դաս և այն կապակցել տպելու ձևանմուշին։

Տես նա՛և

* [Տպելու ձևանմուշի ընդլայնման նկարագրություն](../../extensions/definitions/template_substitution.md)
* [Տպելու ձևանմուշի ընդլայնման ձեռնարկ](../../extensions/definitions/template_substitution.md)

**Պարամետրեր**

* `name` - Տպելու ձևանմուշի ներքին անուն:
* `type` - Տպելու ձևանմուշի տիպ:
* `printTemplateSubstitution` - Տպելու ձևանմուշի տեղադրվող արժեքները պարունակող օբյեկտ։
* `document` - Տպելու ձևանմուշի հետ կապակցված [փաստաթուղթը նկարագրող դասը](../definitions/document.md)։

### EvalAndAddUserDefinedParametersEx

```c#
public Task EvalAndAddUserDefinedParametersEx(string name, SubstitutionType type,
                                              PrintTemplateSubstitutionEx printTemplateSubstitutionEx,
                                              Document.Document document)
```

Հաշվարկում է տպելու ձևանմուշի օգտագործողի կողմից նկարագրված պարամետրերը։

Տպելու ձևանմուշի օգտագործողի կողմից նկարագրված պարամետրերի հաշվարկի տրամաբանության սահմանման համար անհրաժեշտ է սահմանել տպելու ձևանմուշի ընդլայնման դաս և այն կապակցել տպելու ձևանմուշին։

Տես նա՛և

* [Տպելու ձևանմուշի ընդլայնման նկարագրություն](../../extensions/definitions/template_substitution.md)
* [Տպելու ձևանմուշի ընդլայնման ձեռնարկ](../../extensions/definitions/template_substitution.md)

**Պարամետրեր**

* `name` - Տպելու ձևանմուշի ներքին անուն:
* `type` - Տպելու ձևանմուշի տիպ:
* `printTemplateSubstitutionEx` - Տպելու ձևանմուշի տեղադրվող արժեքները տիպիզացված ձևով պարունակող օբյեկտ։
* `document` - Տպելու ձևանմուշի հետ կապակցված [փաստաթուղթը նկարագրող դասը](../definitions/document.md)։

### GetReadyTemplateSubstitution

```c#
public Task<ITemplateSubstitution> GetReadyTemplateSubstitution(Document.Document document,
                                                                string templateName,
                                                                SubstitutionType templateType,
                                                                Dictionary<string, object> parameters)
```

Հաշվարկում է փաստաթղթին կապակցված տպելու ձևանմուշի տեղադրվող արժեքները, օգտագործողի կողմից նկարագրված պարամետրերը և վերադարձնում տպելու ձևանմուշի տեղադրվող արժեքները պարունակող օբյեկտը։

**Պարամետրեր**

* `document` - Տպելու ձևանմուշի հետ կապակցված [փաստաթուղթը նկարագրող դասը](../definitions/document.md)։
* `templateName` - Տպելու ձևանմուշի ներքին անունը։
* `templateType` - Տպելու ձևանմուշի տիպը։
* `parameters` - Տպելու ձևանմուշի լրացման պարամետրեր։

### IsTemplateAvailable

```c#
public Task<bool> IsTemplateAvailable(string templateName, string templateType, Document.Document document)
```

Ստուգում է տպելու ձևանմուշի նշված տպելու ձևանմուշի առկայությունը տվյալների պահոցի `TEMPLATES` աղյուսակում։

**Պարամետրեր**

* `templateName` - Տպելու ձևանմուշի ներքին անունը։
* `templateType` - Տպելու ձևանմուշի տիպը։
* `document` - Տպելու ձևանմուշի հետ կապակցված [փաստաթուղթը նկարագրող դասը](../definitions/document.md)։

### LoadAndSubstitute

```c#
public Task<Stream> LoadAndSubstitute(IPrintTemplateSubstitution printTemplateSubstitution, 
                                      string name, SubstitutionType type, 
                                      HtmlImageOption htmlImageOption = default,
                                      string outputPassword = "", bool check = false)
```

Բեռնում է տպելու ձևանմուշը տվյալների պահոցից, լրացնում `printTemplateSubstitution`-ում պարունակվող նախապես հաշվարկված տվյալներով և վերադարձնում որպես [Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream):

**Պարամետրեր**

* `printTemplateSubstitution` - Տպելու ձևանմուշի տեղադրվող արժեքները պարունակող օբյեկտ։
* `name` - Տպելու ձևանմուշի ներքին անուն:
* `type` - Տպելու ձևանմուշի տիպ:
* `htmlImageOption` - Նախատեսված է Html տպվող տեսքերի [պատկերների տեղադրման եղանակի](../types/HtmlImageOption.md) սահմանման համար։
* `outputPassword` - Տպելու ձևանմուշի ֆայլի բացման գաղտնաբառը։
* `check` - Տպելու ձևանմուշում առկա կոդերի ճիշտ շարահյուսության ստուգման հայտանիշ։

### LoadSubstituteAndGetContent

```c#
public Task<string> LoadSubstituteAndGetContent(IPrintTemplateSubstitution printTemplateSubstitution, 
                                                string name, SubstitutionType type, 
                                                HtmlImageOption htmlImageOption = default,
                                                bool check = false)
```

Բեռնում է տպելու ձևանմուշը տվյալների պահոցից, լրացնում `printTemplateSubstitution`-ում պարունակվող նախապես հաշվարկված տվյալներով և վերադարձնում որպես տեքստ։

**Պարամետրեր**

* `printTemplateSubstitution` - Տպելու ձևանմուշի տեղադրվող արժեքները պարունակող օբյեկտ։
* `name` - Տպելու ձևանմուշի ներքին անուն:
* `type` - Տպելու ձևանմուշի տիպ:
* `htmlImageOption` - Նախատեսված է Html տպվող տեսքերի [պատկերների տեղադրման եղանակի](../types/HtmlImageOption.md) սահմանման համար։
* `check` - Տպելու ձևանմուշում առկա կոդերի ճիշտ շարահյուսության ստուգման հայտանիշ։

### LoadSubstitutionAndGetStorage

```c#
public Task<StorageInfo> LoadSubstitutionAndGetStorage(IPrintTemplateSubstitution printTemplateSubstitution, 
                                                       string name,
                                                       SubstitutionType type, 
                                                       HtmlImageOption htmlImageOption = default,
                                                       string outputPassword = "", bool check = false)
```

Բեռնում է տպելու ձևանմուշը տվյալների պահոցից, լրացնում `printTemplateSubstitution`-ում պարունակվող նախապես հաշվարկված տվյալներով, պահում ֆայլում և վերադարձնում ֆայլի, ֆայլը պարունակող թղթապանակի անունները։

**Պարամետրեր**

* `printTemplateSubstitution` - Տպելու ձևանմուշի տեղադրվող արժեքները պարունակող օբյեկտ։
* `name` - Տպելու ձևանմուշի ներքին անուն:
* `type` - Տպելու ձևանմուշի տիպ:
* `htmlImageOption` - Նախատեսված է Html տպվող տեսքերի [պատկերների տեղադրման եղանակի](../types/HtmlImageOption.md) սահմանման համար։
* `outputPassword` - Տպելու ձևանմուշի ֆայլի բացման գաղտնաբառը։
* `check` - Տպելու ձևանմուշում առկա կոդերի ճիշտ շարահյուսության ստուգման հայտանիշ։

### LoadTemplateFile

```c#
public Task<(bool IsUnicode, byte[] File, bool Updatable)> LoadTemplateFile(string name, SubstitutionType type)
```

Բեռնում է տպելու ձևանմուշի տվյալների պահոցի `TEMPLATES` աղյուսակից և վերադարձնում
* `IsUnicode` - Տպելու ձևանմուշը կարող է պարունակել `Unicode` կոդավորմամբ տվյալներ թե ոչ։
* `File` - Տպելու ձևանմուշի պարունակությունը որպես byte տիպի զանգված։
* `Updatable` - Տպելու ձևանմուշը կարելի է փոփոխել թե ոչ։

**Պարամետրեր**

* `name` - Տպելու ձևանմուշի ներքին անուն:
* `type` - Տպելու ձևանմուշի տիպ:

### Substitute

```c#
public Task<Stream> Substitute(IPrintTemplateSubstitution printTemplateSubstitution, 
                               byte[] file, SubstitutionType type,
                               HtmlImageOption htmlImageOption = default, 
                               bool isUnicode = false, string outputPassword = "",
                               bool protect = false, bool check = false)
```

Լրացնում Է տպելու ձևանմուշը `printTemplateSubstitution`-ում պարունակվող նախապես հաշվարկված տվյալներով և վերադարձնում որպես [Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream):

**Պարամետրեր**

* `printTemplateSubstitution` - Տպելու ձևանմուշի տեղադրվող արժեքները պարունակող օբյեկտ։
* `file` - Տպելու ձևանմուշի պարունակությունը որպես byte տիպի զանգված։
* `type` - Տպելու ձևանմուշի տիպ:
* `htmlImageOption` - Նախատեսված է Html տպվող տեսքերի [պատկերների տեղադրման եղանակի](../types/HtmlImageOption.md) սահմանման համար։
* `isUnicode` - Տպելու ձևանմուշը կարող է պարունակել `Unicode` կոդավորմամբ տվյալներ թե ոչ։
* `outputPassword` - Տպելու ձևանմուշի ֆայլի բացման գաղտնաբառը։
* `protect` - Տպելու ձևանմուշի ֆայլը կարելի է բացել միան կարդալու թույլտվությամբ թե ոչ։
* `check` - Տպելու ձևանմուշում առկա կոդերի ճիշտ շարահյուսության ստուգման հայտանիշ։

### Substitute

```c#
public Task Substitute(IPrintTemplateSubstitution printTemplateSubstitution, 
                       StorageInfo file, SubstitutionType type,
                       HtmlImageOption htmlImageOption = default, 
                       bool isUnicode = false, bool protect = false,
                       bool check = false)
```

Լրացնում Է տպելու ձևանմուշը `printTemplateSubstitution`-ում պարունակվող նախապես հաշվարկված տվյալներով։

**Պարամետրեր**

* `printTemplateSubstitution` - Տպելու ձևանմուշի տեղադրվող արժեքները պարունակող օբյեկտ։
* `file` - Տպելու ձևանմուշը պարունակող ֆայլի և թղթապանակի անունները։
* `type` - Տպելու ձևանմուշի տիպ:
* `htmlImageOption` - Նախատեսված է Html տպվող տեսքերի [պատկերների տեղադրման եղանակի](../types/HtmlImageOption.md) սահմանման համար։
* `isUnicode` - Տպելու ձևանմուշը կարող է պարունակել `Unicode` կոդավորմամբ տվյալներ թե ոչ։
* `protect` - Տպելու ձևանմուշի ֆայլը կարելի է բացել միան կարդալու թույլտվությամբ թե ոչ։
* `check` - Տպելու ձևանմուշում առկա կոդերի ճիշտ շարահյուսության ստուգման հայտանիշ։

### SubstituteAndGetContent

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
* `type` - Տպելու ձևանմուշի տիպ:
* `htmlImageOption` - Նախատեսված է Html տպվող տեսքերի [պատկերների տեղադրման եղանակի](../types/HtmlImageOption.md) սահմանման համար։
* `isUnicode` - Տպելու ձևանմուշը կարող է պարունակել `Unicode` կոդավորմամբ տվյալներ թե ոչ։
* `check` - Տպելու ձևանմուշում առկա կոդերի ճիշտ շարահյուսության ստուգման հայտանիշ։

### SubstituteAndGetContent

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
* `type` - Տպելու ձևանմուշի տիպ:
* `htmlImageOption` - Նախատեսված է Html տպվող տեսքերի [պատկերների տեղադրման եղանակի](../types/HtmlImageOption.md) սահմանման համար։
* `isUnicode` - Տպելու ձևանմուշը կարող է պարունակել `Unicode` կոդավորմամբ տվյալներ թե ոչ։
* `check` - Տպելու ձևանմուշում առկա կոդերի ճիշտ շարահյուսության ստուգման հայտանիշ։
