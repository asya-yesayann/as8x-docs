---
title: IDocumentService.GetSUIDAndDate(int, int, bool) մեթոդ
---

```c#
public Task<(bool exists, short suid, string dateTime)> GetSUIDAndDate(int isn, int state, bool sort = true)
```

Փնտրում է նշված վիճակին համապատասխան տողի առկայությունը փաստաթղթի պատմության մեջ ([DOCLOG](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/DocLog.html) աղյուսակում) և վերադարձնում ստեղծողին և ամսաթիվը։

Առկայության դեպքում վերադարձնում է  
`exists` -> **true**,  
`suid` -> այդ վիճակ տեղափոխած օգտագործողի համարը,  
`dateTime` -> այդ վիճակ տեղափոխած օրը/ժամը: Արժեքը գրվում է հետևյալ ձևաչափով `yyyy-MM-dd hh:mm:ss`։

Բացակայության դեպքում  
`exists` -> **false**:

**Պարամետրեր**

* `isn` - Փաստաթղթի ներքին նույնականացման համար:
* `state` - Փնտրվող վիճակ։
* `sort` - Փաստաթուղթը նշված վիճակին բերած առաջին (`true`) կամ վերջին (`false`) անգամ վիճակը հասնելը։
