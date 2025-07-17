---
title: ITemplateSubstitutionService.MergeFile(SubstitutionType, byte[], byte[], bool, bool) մեթոդ
---

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
