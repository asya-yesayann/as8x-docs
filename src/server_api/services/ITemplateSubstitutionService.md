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
  - [MergeFile](#mergefile)
  - [MergeFile](#mergefile-1)
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

Հաշվարկում է տպելու ձևանմուշի օգտագործողի կողմից նկարագրված պարամետրերը և ավելացնում տպելու ձևանմուշի տեղադրվող արժեքները պարունակող օբյեկտում՝ `printTemplateSubstitution`:

Տպելու ձևանմուշի օգտագործողի կողմից նկարագրված պարամետրերի հաշվարկի տրամաբանության սահմանման համար անհրաժեշտ է ստեղծել 
[սերվերային մոդուլ](../../extensions/definitions/server_side_module.md), որին համապատասխան c# ֆայլում ունենալ դաս `ITemplateSubstitutionExtender` ինտերֆեյսը և այն [կապակցել տպելու ձևանմուշին](../../extensions/definitions/template_substitution_guide.md#ընդլայնման-կապակցում-տպելու-ձևանմուշին)։

Տես նա՛և

* [Տպելու ձևանմուշի ընդլայնման նկարագրություն](../../extensions/definitions/template_substitution.md)
* [Տպելու ձևանմուշի ընդլայնման ձեռնարկ](../../extensions/definitions/template_substitution.md)

**Պարամետրեր**

* `name` - Տպելու ձևանմուշի ներքին անուն:
* `type` - Տպելու ձևանմուշի տիպ:
* `printTemplateSubstitution` - Տպելու ձևանմուշի տեղադրվող արժեքները պարունակող օբյեկտ։
* `document` - Տպելու ձևանմուշի հետ կապակցված [փաստաթղթի օբյեկտ](../definitions/document.md)։

### EvalAndAddUserDefinedParametersEx

```c#
public Task EvalAndAddUserDefinedParametersEx(string name, SubstitutionType type,
                                              PrintTemplateSubstitutionEx printTemplateSubstitutionEx,
                                              Document.Document document)
```

Հաշվարկում է տպելու ձևանմուշի օգտագործողի կողմից նկարագրված պարամետրերը և ավելացնում տպելու ձևանմուշի տեղադրվող արժեքները պարունակող օբյեկտում՝ `printTemplateSubstitution`:

Տպելու ձևանմուշի օգտագործողի կողմից նկարագրված պարամետրերի հաշվարկի տրամաբանության սահմանման համար անհրաժեշտ է ստեղծել 
[սերվերային մոդուլ](../../extensions/definitions/server_side_module.md), որին համապատասխան c# ֆայլում ունենալ դաս `ITemplateSubstitutionExtender` ինտերֆեյսը և այն [կապակցել տպելու ձևանմուշին](../../extensions/definitions/template_substitution_guide.md#ընդլայնման-կապակցում-տպելու-ձևանմուշին)։

Տես նա՛և

* [Տպելու ձևանմուշի ընդլայնման նկարագրություն](../../extensions/definitions/template_substitution.md)
* [Տպելու ձևանմուշի ընդլայնման ձեռնարկ](../../extensions/definitions/template_substitution.md)

**Պարամետրեր**

* `name` - Տպելու ձևանմուշի ներքին անուն:
* `type` - Տպելու ձևանմուշի տիպ:
* `printTemplateSubstitutionEx` - Տպելու ձևանմուշի տեղադրվող արժեքները տիպիզացված ձևով պարունակող օբյեկտ։
* `document` - Տպելու ձևանմուշի հետ կապակցված [փաստաթղթի օբյեկտ](../definitions/document.md)։

### GetReadyTemplateSubstitution

```c#
public Task<ITemplateSubstitution> GetReadyTemplateSubstitution(Document.Document document,
                                                                string templateName,
                                                                SubstitutionType templateType,
                                                                Dictionary<string, object> parameters)
```

Հաշվարկում է փաստաթղթին կապակցված տպելու ձևանմուշի տեղադրվող արժեքները, օգտագործողի կողմից նկարագրված պարամետրերը և վերադարձնում տպելու ձևանմուշի տեղադրվող արժեքները պարունակող օբյեկտը։

**Պարամետրեր**

* `document` - Տպելու ձևանմուշի հետ կապակցված [փաստաթուղթ](../definitions/document.md)։
* `templateName` - Տպելու ձևանմուշի ներքին անունը։
* `templateType` - Տպելու ձևանմուշի տիպը։
* `parameters` - Տպելու ձևանմուշի լրացման պարամետրերի Dictionary, որտեղ բանալին՝ պարամետրի անունն է, իսկ արժեքը՝ պարամետրի արժեքը: Այս պարամետրի արժեքը փոխանցվելու է տպելու ձևանմուշի տեղադրվող արժեքները հաշվարկող [TemplateSubstitution](../definitions/document.md#templatesubstitution) իրադարձության մշակիչին։

### IsTemplateAvailable

```c#
public Task<bool> IsTemplateAvailable(string templateName, string templateType, Document.Document document)
```

Ստուգում է արդյոք նշված ձևանմուշը հասանելի է նշված փաստաթղթի համար, այսինքն փաստաթղթի տիպը նշված է տպվող ձևանմուշի փաստաթղթերի ցանկում և բավարարվում է ակտիվացման բանաձևը սերվիսում։

Սերվիսում ակտիվացման բանաձևի սահմանման համար անհրաժեշտ է ստեղծել [սերվերային մոդուլ](../../extensions/definitions/server_side_module.md), որին համապատասխան c# ֆայլում ունենալ դաս ու ֆունկցիա, որը հաշվարկում է ակտիվացման բանաձևը։

Ակտիվացման բանաձևը հաշվարկող ֆունկցիայի վերադարձվող արժեքի տիպը պետք է լինի `bool` և որպես պարամետր պետք է ստանա [Document](../definitions/document.md) դասի օբյեկտ։

Դասի ու ֆունկցիայի սահմանումից հետո "Փաստաթղթի տպելու ձևանմուշներ" դիտելու ձևի անհրաժեշտ տպելու ձևանմուշի վրայից սեղմելով "Խմբագրել" 
ֆունկցիայով բացվող պատուհանի "Ակտիվացման բանաձև սերվիսում դաշտում" անհրաժեշտ է այն լրացնել սերվերային մոդուլի անունը, դասի անունը և 
ֆունկցիայի անւնը՝ իրարից անջատելով կետերով՝ **server_side_module_name.class_name.function_name**:

**Պարամետրեր**

* `templateName` - Տպելու ձևանմուշի ներքին անունը։
* `templateType` - Տպելու ձևանմուշի տիպը։
* `document` - Տպելու ձևանմուշի հետ կապակցված [փաստաթղթի օբյեկտ](../definitions/document.md)։

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
* `htmlImageOption` - Html տպվող տեսքերի [պատկերների տեղադրման եղանակ](../types/HtmlImageOption.md)։
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
* `htmlImageOption` - Html տպվող տեսքերի [պատկերների տեղադրման եղանակ](../types/HtmlImageOption.md)։
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
* `htmlImageOption` - Html տպվող տեսքերի [պատկերների տեղադրման եղանակ](../types/HtmlImageOption.md)։
* `outputPassword` - Տպելու ձևանմուշի ֆայլի բացման գաղտնաբառը։
* `check` - Տպելու ձևանմուշում առկա կոդերի ճիշտ շարահյուսության ստուգման հայտանիշ։

### LoadTemplateFile

```c#
public Task<(bool IsUnicode, byte[] File, bool Updatable)> LoadTemplateFile(string name, SubstitutionType type)
```

Բեռնում է տպելու ձևանմուշի տվյալները պահոցի `TEMPLATES` աղյուսակից և վերադարձնում
* `IsUnicode` - Տպելու ձևանմուշը կարող է պարունակել `Unicode` կոդավորմամբ տվյալներ թե ոչ։
* `File` - Տպելու ձևանմուշի պարունակությունը որպես byte տիպի զանգված։
* `Updatable` - Տպելու ձևանմուշը լրացնելուց հետո կարելի է խմբագրել, թե ոչ։

**Պարամետրեր**

* `name` - Տպելու ձևանմուշի ներքին անուն:
* `type` - Տպելու ձևանմուշի տիպ:

### MergeFile

```c#
public Task MergeFile(SubstitutionType type, StorageInfo targetFile, 
                      StorageInfo sourceFile, bool insertPageBreak,
                      bool check = false)
```

Միավորում է երկու տպելու ձևանմուշի ֆայլեր՝ տեղադրելով մեկ ընդհանուր ֆայլի մեջ։

**Պարամետրեր**

* `type` - Տպելու ձևանմուշի տիպ:
* `targetFile` - Առաջին ֆայլի և ֆայլը պարունակող թղթապանակի անունները, որին կավելանա երկրորդ ֆայլը։
* `sourceFile` - Երկրորդ ֆայլի և ֆայլը պարունակող թղթապանակի անունները, որը կավելանա առաջինի վերջում։
* `insertPageBreak` - Երկու ֆայլերի պարունակությունների միջև break-ի նշանի տեղադրման հայտանիշ։
* `check` - Տպելու ձևանմուշում առկա կոդերի ճիշտ շարահյուսության ստուգման հայտանիշ։

### MergeFile

```c#
public Task<Stream> MergeFile(SubstitutionType type, byte[] targetFile, 
                              byte[] sourceFile, bool insertPageBreak, 
                              bool check = false)
```

Միավորում է երկու տպելու ձևանմուշի ֆայլեր՝ տեղադրելով մեկ ընդհանուր ֆայլի մեջ և վերադարձնում միավորված ֆայլը որպես [Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream):

**Պարամետրեր**

* `type` - Տպելու ձևանմուշի տիպ:
* `targetFile` - Առաջին ֆայլը որպես byte տիպի զանգված, որին կավելանա երկրորդ ֆայլը։
* `sourceFile` - Երկրորդ ֆայլը որպես byte տիպի զանգված, որը կավելանա առաջինի վերջում։
* `insertPageBreak` - Երկու ֆայլերի պարունակությունների միջև break-ի նշանի տեղադրման հայտանիշ։
* `check` - Տպելու ձևանմուշում առկա կոդերի ճիշտ շարահյուսության ստուգման հայտանիշ։

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
* `htmlImageOption` - Html տպվող տեսքերի [պատկերների տեղադրման եղանակ](../types/HtmlImageOption.md)։
* `isUnicode` - Տպելու ձևանմուշի տվյալների `Unicode` կոդավորմամբ լրացման հայտանիշ։
* `outputPassword` - Տպելու ձևանմուշի ֆայլի բացման գաղտնաբառը։
* `protect` - `true` արժեքի դեպքում տպելու ձևանմուշի ֆայլը բացվում է միայն կարդալու թույլտվությամբ, հակառակ դեպքում՝ կարդալու/խմբագրելու թույլտվությամբ։
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
* `htmlImageOption` - Html տպվող տեսքերի [պատկերների տեղադրման եղանակ](../types/HtmlImageOption.md)։
* `isUnicode` - Տպելու ձևանմուշի տվյալների `Unicode` կոդավորմամբ լրացման հայտանիշ։
* `protect` - `true` արժեքի դեպքում տպելու ձևանմուշի ֆայլը բացվում է միայն կարդալու թույլտվությամբ, հակառակ դեպքում՝ կարդալու/խմբագրելու թույլտվությամբ։
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
* `htmlImageOption` - Html տպվող տեսքերի [պատկերների տեղադրման եղանակ](../types/HtmlImageOption.md)։
* `isUnicode` - Տպելու ձևանմուշի տվյալների `Unicode` կոդավորմամբ լրացման հայտանիշ։
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
* `htmlImageOption` - Html տպվող տեսքերի [պատկերների տեղադրման եղանակ](../types/HtmlImageOption.md)։
* `isUnicode` - Տպելու ձևանմուշի տվյալների `Unicode` կոդավորմամբ լրացման հայտանիշ։
* `check` - Տպելու ձևանմուշում առկա կոդերի ճիշտ շարահյուսության ստուգման հայտանիշ։
