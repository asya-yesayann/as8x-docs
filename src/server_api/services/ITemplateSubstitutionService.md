---
title: "ITemplateSubstitutionService սերվիս"
---

## Ներածություն

ITemplateSubstitutionService դասը նախատեսված է տպելու ձևանմուշների լրացման հետ աշխատանքը ապահովելու համար։

Այս դասը օգտագործվում է այն դեպքերում, երբ հարկավոր է տպելու ձևանմուշ լրացնել ոչ կոնկրետ փաստաթղթի համար. օրինակ՝ քաղվածքի ձևավորում, ծանուցման ձևավորում, էլ.նամակի տեքստի ձևավորում։

Տե՛ս նաև [TemplateService](TemplateService.md) տպելու ձևանմուշների հետ աշխատանքի համար։

Տե՛ս [օրինակը](../examples/ITemplateSubstitutionService.md)։

## Մեթոդներ

| Անվանում | Նկարագրություն |
|----------|----------------|
| [EvalAndAddUserDefinedParameters](ITemplateSubstitutionService/EvalAndAddUserDefinedParameters.md) | Հաշվարկում է տպելու ձևանմուշի օգտագործողի կողմից նկարագրված պարամետրերը և ավելացնում տպելու ձևանմուշի տեղադրվող արժեքները պարունակող օբյեկտում՝ `printTemplateSubstitution`: |
| [EvalAndAddUserDefinedParametersEx](ITemplateSubstitutionService/EvalAndAddUserDefinedParametersEx.md) | Հաշվարկում է տպելու ձևանմուշի օգտագործողի կողմից նկարագրված պարամետրերը և ավելացնում տպելու ձևանմուշի տեղադրվող արժեքները պարունակող օբյեկտում՝ `printTemplateSubstitution`: |
| [GetReadyTemplateSubstitution](ITemplateSubstitutionService/GetReadyTemplateSubstitution.md) | Հաշվարկում է փաստաթղթին կապակցված տպելու ձևանմուշի տեղադրվող արժեքները, օգտագործողի կողմից նկարագրված պարամետրերը և վերադարձնում տպելու ձևանմուշի տեղադրվող արժեքները պարունակող օբյեկտը։ |
| [IsTemplateAvailable](ITemplateSubstitutionService/IsTemplateAvailable.md) | Ստուգում է արդյոք նշված ձևանմուշը հասանելի է նշված փաստաթղթի համար, այսինքն փաստաթղթի տիպը նշված է տպվող ձևանմուշի փաստաթղթերի ցանկում և բավարարվում է ակտիվացման բանաձևը սերվիսում։ |
| [LoadAndSubstitute](ITemplateSubstitutionService/LoadAndSubstitute.md) | Բեռնում է տպելու ձևանմուշը տվյալների պահոցից, լրացնում `printTemplateSubstitution`-ում պարունակվող նախապես հաշվարկված տվյալներով և ստացված ֆայլը վերադարձնում որպես [Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream): |
| [LoadSubstituteAndGetContent](ITemplateSubstitutionService/LoadSubstituteAndGetContent.md) | Բեռնում է տպելու ձևանմուշը տվյալների պահոցից, լրացնում `printTemplateSubstitution`-ում պարունակվող նախապես հաշվարկված տվյալներով և ստացված ֆայլը վերադարձնում որպես տեքստ։ |
| [LoadSubstitutionAndGetStorage](ITemplateSubstitutionService/LoadSubstitutionAndGetStorage.md) | Բեռնում է տպելու ձևանմուշը տվյալների պահոցից, լրացնում `printTemplateSubstitution`-ում պարունակվող նախապես հաշվարկված տվյալներով, պահում ֆայլում և վերադարձնում ֆայլի նույնականացուցիչը սերվերում։ |
| [MergeFile](ITemplateSubstitutionService/MergeFile.md) | Միավորում է երկու տպելու ձևանմուշից ստեղծված `docx` ֆայլեր՝ տեղադրելով մեկ ընդհանուր ֆայլի մեջ։ |
| [MergeFile](ITemplateSubstitutionService/MergeFile1.md) | Միավորում է երկու տպելու ձևանմուշից ստեղծված `docx` ֆայլեր՝ տեղադրելով մեկ ընդհանուր ֆայլի մեջ։ |
| [Substitute](ITemplateSubstitutionService/Substitute.md) | Լրացնում Է տպելու ձևանմուշը `printTemplateSubstitution`-ում պարունակվող նախապես հաշվարկված տվյալներով և վերադարձնում որպես [Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream): |
| [SubstituteAndGetContent](ITemplateSubstitutionService/SubstituteAndGetContent.md) | Լրացնում Է տպելու ձևանմուշը `printTemplateSubstitution`-ում պարունակվող նախապես հաշվարկված տվյալներով և վերադարձնում որպես տեքստ։ |

## Հատկություններ

| Անվանում | Նկարագրություն |
|----------|----------------|
| [LoadTemplateFile](ITemplateSubstitutionService/LoadTemplateFile.md) | Բեռնում է տպելու ձևանմուշի տվյալները պահոցի `TEMPLATES` աղյուսակից։ Բեռնման ընթացքում կատարվում է լրացուցիչ ստուգումներ, որից հետո հնարավոր է լրացնել ֆայլը։ |