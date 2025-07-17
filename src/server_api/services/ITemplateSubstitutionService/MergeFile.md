---
title: ITemplateSubstitutionService.MergeFile(SubstitutionType, StorageInfo, StorageInfo, bool, bool) մեթոդ
---

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
