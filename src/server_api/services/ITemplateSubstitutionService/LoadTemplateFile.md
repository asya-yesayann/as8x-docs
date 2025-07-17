---
title: ITemplateSubstitutionService.LoadTemplateFile(string, SubstitutionType) մեթոդ
---

```c#
public Task<(bool IsUnicode, byte[] File, bool Updatable)> LoadTemplateFile(
    string name, SubstitutionType type)
```

Բեռնում է տպելու ձևանմուշի տվյալները պահոցի `TEMPLATES` աղյուսակից։ Բեռնման ընթացքում կատարվում է լրացուցիչ ստուգումներ, որից հետո հնարավոր է լրացնել ֆայլը։ 
Ստացված տվյալները ենթակա են փոխանցման [EvalAndAddUserDefinedParameters](#evalandadduserdefinedparameters), ապա [Substitute](#substitute) կամ [SubstituteAndGetContent](#substituteandgetcontent) մեթոդներին։

Վերադարձնում է կորտեժ
* `IsUnicode` - Տպելու ձևանմուշը հարկավոր է արտահանել յունիկոդ կոդավորմամբ։
* `File` - Տպելու ձևանմուշի պարունակությունը որպես բայտերի զանգված։
* `Updatable` - Տպելու ձևանմուշը լրացնելուց հետո հարկավոր է դարձնել ոչ խմբագրելի։

**Պարամետրեր**

* `name` - Տպելու ձևանմուշի ներքին անուն:
* `type` - [Տպելու ձևանմուշի տիպ][4XTemplateSubstitution]:
