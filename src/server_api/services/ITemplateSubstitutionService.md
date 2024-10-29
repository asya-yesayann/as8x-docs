---
layout: page
title: "ITemplateSubstitutionService սերվիս" 
sublinks:
- { title: "EvalAndAddUserDefinedParameters", ref: evalandadduserdefinedparameters }
- { title: "EvalAndAddUserDefinedParametersEx", ref: evalandadduserdefinedparametersex }
- { title: "GetReadyTemplateSubstitution", ref: getreadytemplatesubstitution }
- { title: "IsTemplateAvailable", ref: istemplateavailable }
- { title: "LoadAndSubstitute", ref: loadandsubstitute }
- { title: "LoadSubstituteAndGetContent", ref: loadsubstituteandgetcontent }
- { title: "LoadSubstitutionAndGetStorage", ref: loadsubstitutionandgetstorage }
- { title: "LoadTemplateFile", ref: loadtemplatefile }
- { title: "MergeFile", ref: mergefile }
- { title: "MergeFile", ref: mergefile-1 }
- { title: "Substitute", ref: substitute }
- { title: "SubstituteAndGetContent", ref: substituteandgetcontent }
---

[4XTemplateSubstitution]: https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Functions/TemplateSubstitution.html

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
  <!-- - [Substitute](#substitute-1) -->
  - [SubstituteAndGetContent](#substituteandgetcontent)
  <!-- - [SubstituteAndGetContent](#substituteandgetcontent-1) -->


## Ներածություն

ITemplateSubstitutionService դասը նախատեսված է տպելու ձևանմուշների լրացման հետ աշխատանքը ապահովելու համար։

Այս դասը օգտագործվում է այն դեպքերում, երբ հարկավոր է տպելու ձևանմուշ լրացնել ոչ կոնկրետ փաստաթղթի համար. օրինակ՝ քաղվածքի ձևավորում, ծանուցման ձևավորում, էլ.նամակի տեքստի ձևավորում։

Տե՛ս նաև [TemplateService](TemplateService.md) տպելու ձևանմուշների հետ աշխատանքի համար։

## Մեթոդներ

### EvalAndAddUserDefinedParameters

```c#
public Task EvalAndAddUserDefinedParameters(string name, SubstitutionType type,
                                            PrintTemplateSubstitution printTemplateSubstitution,
                                            Document.Document document)
```

Հաշվարկում է տպելու ձևանմուշի օգտագործողի կողմից նկարագրված պարամետրերը և ավելացնում տպելու ձևանմուշի տեղադրվող արժեքները պարունակող օբյեկտում՝ `printTemplateSubstitution`:

Տե՛ս [Տպելու ձևանմուշի ընդլայնման ձեռնարկ](../../extensions/definitions/template_substitution_guide.md)։

**Պարամետրեր**

* `name` - Տպելու ձևանմուշի ներքին անուն:
* `type` - [Տպելու ձևանմուշի տիպ][4XTemplateSubstitution]:
* `printTemplateSubstitution` - Տպելու ձևանմուշի տեղադրվող արժեքները պարունակող օբյեկտ։
* `document` - Տպելու ձևանմուշի հետ կապակցված [փաստաթղթի օբյեկտ](../definitions/document.md)։
  Կարող է փոխանցվել `null`, եթե տպելու ձևը կապված չէ փաստաթղթի հետ։

### EvalAndAddUserDefinedParametersEx

```c#
public Task EvalAndAddUserDefinedParametersEx(string name, SubstitutionType type,
                                              PrintTemplateSubstitutionEx printTemplateSubstitutionEx,
                                              Document.Document document)
```

Հաշվարկում է տպելու ձևանմուշի օգտագործողի կողմից նկարագրված պարամետրերը և ավելացնում տպելու ձևանմուշի տեղադրվող արժեքները պարունակող օբյեկտում՝ `printTemplateSubstitution`:

Տե՛ս [Տպելու ձևանմուշի ընդլայնման ձեռնարկ](../../extensions/definitions/template_substitution_guide.md)։

**Պարամետրեր**

* `name` - Տպելու ձևանմուշի ներքին անուն:
* `type` - [Տպելու ձևանմուշի տիպ][4XTemplateSubstitution]:
* `printTemplateSubstitutionEx` - Տպելու ձևանմուշի տեղադրվող արժեքները տիպիզացված ձևով պարունակող օբյեկտ։
* `document` - Տպելու ձևանմուշի հետ կապակցված [փաստաթղթի օբյեկտ](../definitions/document.md)։
  Կարող է փոխանցվել `null`, եթե տպելու ձևը կապված չէ փաստաթղթի հետ։

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
* `templateType` - [Տպելու ձևանմուշի տիպ][4XTemplateSubstitution]:
* `parameters` - Տպելու ձևանմուշի լրացման պարամետրերի Dictionary, որտեղ բանալին՝ պարամետրի անունն է, իսկ արժեքը՝ պարամետրի արժեքը: 
  Այս պարամետրի արժեքը փոխանցվելու է տպելու ձևանմուշի տեղադրվող արժեքները հաշվարկող [TemplateSubstitution](../definitions/document.md#templatesubstitution) իրադարձության մշակիչին։

### IsTemplateAvailable

```c#
public Task<bool> IsTemplateAvailable(string templateName, string templateType, Document.Document document)
```

Ստուգում է արդյոք նշված ձևանմուշը հասանելի է նշված փաստաթղթի համար, այսինքն փաստաթղթի տիպը նշված է տպվող ձևանմուշի փաստաթղթերի ցանկում և բավարարվում է ակտիվացման բանաձևը սերվիսում։

**Պարամետրեր**

* `templateName` - Տպելու ձևանմուշի ներքին անունը։
* `templateType` - [Տպելու ձևանմուշի տիպ][4XTemplateSubstitution]:
* `document` - Տպելու ձևանմուշի հետ կապակցված [փաստաթղթի օբյեկտ](../definitions/document.md)։

**Օգտագործում**

Սերվիսում ակտիվացման բանաձևի սահմանման համար անհրաժեշտ է ստեղծել [սերվերային մոդուլ](../../extensions/definitions/server_side_module.md), որում C# դաս ու ֆունկցիա, որը հաշվարկում է ակտիվացման բանաձևը։

Ակտիվացման բանաձևը հաշվարկող ֆունկցիայի վերադարձվող արժեքի տիպը պետք է լինի `bool` և որպես պարամետր պետք է ստանա [Document](../definitions/document.md) դասի օբյեկտ։

Դասի ու ֆունկցիայի սահմանումից հետո «Փաստաթղթի տպելու ձևանմուշներ» դիտելու ձևում տպելու ձևանմուշի վրայից սեղմելով «Խմբագրել» ֆունկցիայով բացվող պատուհանի «Ակտիվացման բանաձև սերվիսում» դաշտում անհրաժեշտ է այն լրացնել սերվերային մոդուլի անունը, դասի անունը և ֆունկցիայի անւնը՝ իրարից անջատելով կետերով՝ **server_side_module_name.class_name.function_name**:  

Օրինակ՝
``` c#
//SERVERSIDEMODULE { NAME = MyModule;
//public class MyClass {
public bool IsAvailable(Document doc)
```

Ակտիվացման բանաձև սերվիսում կլինի `MyModule.MyClass.IsAvailable` 


### LoadAndSubstitute

```c#
public Task<Stream> LoadAndSubstitute(IPrintTemplateSubstitution printTemplateSubstitution, 
                                      string name, SubstitutionType type, 
                                      HtmlImageOption htmlImageOption = default,
                                      string outputPassword = "", bool check = false)
```

Բեռնում է տպելու ձևանմուշը տվյալների պահոցից, լրացնում `printTemplateSubstitution`-ում պարունակվող նախապես հաշվարկված տվյալներով և ստացված ֆայլը վերադարձնում որպես [Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream):

**Պարամետրեր**

* `printTemplateSubstitution` - Տպելու ձևանմուշի տեղադրվող արժեքները պարունակող օբյեկտ։
* `name` - Տպելու ձևանմուշի ներքին անուն:
* `type` - [Տպելու ձևանմուշի տիպ][4XTemplateSubstitution]:
* `htmlImageOption` - Html տպվող տեսքերի [պատկերների տեղադրման եղանակ](../types/HtmlImageOption.md)։
* `outputPassword` - Վերջնական ֆայլի բացման գաղտնաբառը։
* `check` - Տպելու ձևանմուշում առկա կոդերի ճիշտ շարահյուսության ստուգման հայտանիշ։

### LoadSubstituteAndGetContent

```c#
public Task<string> LoadSubstituteAndGetContent(IPrintTemplateSubstitution printTemplateSubstitution, 
                                                string name, SubstitutionType type, 
                                                HtmlImageOption htmlImageOption = default,
                                                bool check = false)
```

Բեռնում է տպելու ձևանմուշը տվյալների պահոցից, լրացնում `printTemplateSubstitution`-ում պարունակվող նախապես հաշվարկված տվյալներով և ստացված ֆայլը վերադարձնում որպես տեքստ։

Նախատեսված է `htm` և `txt` տիպի ձևանմուշների լրացումից հետո վերջնական տեքստը ստանալու համար։

**Պարամետրեր**

* `printTemplateSubstitution` - Տպելու ձևանմուշի տեղադրվող արժեքները պարունակող օբյեկտ։
* `name` - Տպելու ձևանմուշի ներքին անուն:
* `type` - [Տպելու ձևանմուշի տիպ][4XTemplateSubstitution]:
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

Բեռնում է տպելու ձևանմուշը տվյալների պահոցից, լրացնում `printTemplateSubstitution`-ում պարունակվող նախապես հաշվարկված տվյալներով, պահում ֆայլում և վերադարձնում ֆայլի նույնականացուցիչը սերվերում։

**Պարամետրեր**

* `printTemplateSubstitution` - Տպելու ձևանմուշի տեղադրվող արժեքները պարունակող օբյեկտ։
* `name` - Տպելու ձևանմուշի ներքին անուն:
* `type` - [Տպելու ձևանմուշի տիպ][4XTemplateSubstitution]:
* `htmlImageOption` - Html տպվող տեսքերի [պատկերների տեղադրման եղանակ](../types/HtmlImageOption.md)։
* `outputPassword` - Վերջնական ֆայլի բացման գաղտնաբառը։
* `check` - Տպելու ձևանմուշում առկա կոդերի ճիշտ շարահյուսության ստուգման հայտանիշ։

### LoadTemplateFile

```c#
public Task<(bool IsUnicode, byte[] File, bool Updatable)> LoadTemplateFile(string name, SubstitutionType type)
```

Բեռնում է տպելու ձևանմուշի տվյալները պահոցի `TEMPLATES` աղյուսակից։
Այս մեթոդով ստացված տվյալները փոխանցվում են [EvalAndAddUserDefinedParameters](#evalandadduserdefinedparameters), ապա [Substitute](#substitute) կամ [SubstituteAndGetContent](#substituteandgetcontent) մեթոդներին։

Վերադարձնում կորտեժ
* `IsUnicode` - Տպելու ձևանմուշը հարկավոր է արտահանել յունիկոդ կոդավորմամբ։
* `File` - Տպելու ձևանմուշի պարունակությունը որպես բայտերի զանգված։
* `Updatable` - Տպելու ձևանմուշը լրացնելուց հետո հարկավոր է դարձնել ոչ խմբագրելի։

**Պարամետրեր**

* `name` - Տպելու ձևանմուշի ներքին անուն:
* `type` - [Տպելու ձևանմուշի տիպ][4XTemplateSubstitution]:

### MergeFile

```c#
public Task MergeFile(SubstitutionType type, StorageInfo targetFile, 
                      StorageInfo sourceFile, bool insertPageBreak,
                      bool check = false)
```

Միավորում է երկու տպելու ձևանմուշից ստեղծված `docx` ֆայլեր՝ տեղադրելով մեկ ընդհանուր ֆայլի մեջ։
Միավորված ֆայլը գրանցում է `targetFile`-ի մեջ։

**Պարամետրեր**

* `type` - [Տպելու ձևանմուշի տիպ][4XTemplateSubstitution]: 
* `targetFile` - Առաջին ֆայլի նույնականացուցիչը սերվերում, որին կավելանա երկրորդ ֆայլը։
* `sourceFile` - Երկրորդ ֆայլի նույնականացուցիչը սերվերում։
* `insertPageBreak` - Երկու ֆայլերի պարունակությունների միջև break-ի նշանի տեղադրման հայտանիշ։
* `check` - Տպելու ձևանմուշում առկա կոդերի ճիշտ շարահյուսության ստուգման հայտանիշ։

### MergeFile

```c#
public Task<Stream> MergeFile(SubstitutionType type, byte[] targetFile, 
                              byte[] sourceFile, bool insertPageBreak, 
                              bool check = false)
```

Միավորում է երկու տպելու ձևանմուշից ստեղծված `docx` ֆայլեր՝ տեղադրելով մեկ ընդհանուր ֆայլի մեջ։ 
Միավորված ֆայլը վերադարձնում է որպես [Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream):

**Պարամետրեր**

* `type` - [Տպելու ձևանմուշի տիպ][4XTemplateSubstitution]:
* `targetFile` - Առաջին ֆայլի նույնականացուցիչը սերվերում։
* `sourceFile` - Երկրորդ ֆայլի նույնականացուցիչը սերվերում։
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
* `file` - Տպելու ձևանմուշի պարունակությունը որպես բայտերի զանգված։
* `type` - [Տպելու ձևանմուշի տիպ][4XTemplateSubstitution]:
* `htmlImageOption` - Html տպվող տեսքերի [պատկերների տեղադրման եղանակ](../types/HtmlImageOption.md)։
* `isUnicode` - Տպելու ձևանմուշը արտահանել յունիկոդ կոդավորմամբ։
* `outputPassword` - Վերջնական ֆայլի բացման գաղտնաբառը։
* `protect` - `true` արժեքի դեպքում տպելու ձևանմուշի ֆայլը բացվում է միայն կարդալու թույլտվությամբ, հակառակ դեպքում՝ կարդալու/խմբագրելու թույլտվությամբ։
* `check` - Տպելու ձևանմուշում առկա կոդերի ճիշտ շարահյուսության ստուգման հայտանիշ։

<!-- ### Substitute

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
* `type` - [Տպելու ձևանմուշի տիպ][4XTemplateSubstitution]:
* `htmlImageOption` - Html տպվող տեսքերի [պատկերների տեղադրման եղանակ](../types/HtmlImageOption.md)։
* `isUnicode` - Տպելու ձևանմուշի տվյալների `Unicode` կոդավորմամբ լրացման հայտանիշ։
* `protect` - `true` արժեքի դեպքում տպելու ձևանմուշի ֆայլը բացվում է միայն կարդալու թույլտվությամբ, հակառակ դեպքում՝ կարդալու/խմբագրելու թույլտվությամբ։
* `check` - Տպելու ձևանմուշում առկա կոդերի ճիշտ շարահյուսության ստուգման հայտանիշ։ -->

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
* `type` - [Տպելու ձևանմուշի տիպ][4XTemplateSubstitution]:
* `htmlImageOption` - Html տպվող տեսքերի [պատկերների տեղադրման եղանակ](../types/HtmlImageOption.md)։
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
* `htmlImageOption` - Html տպվող տեսքերի [պատկերների տեղադրման եղանակ](../types/HtmlImageOption.md)։
* `isUnicode` - Տպելու ձևանմուշի տվյալների `Unicode` կոդավորմամբ լրացման հայտանիշ։
* `check` - Տպելու ձևանմուշում առկա կոդերի ճիշտ շարահյուսության ստուգման հայտանիշ։ -->
