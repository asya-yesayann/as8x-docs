---
title: IDocumentService.HiDelete(Document, bool) մեթոդ
---

```c#
public Task<(bool had01AccRow, bool hadHIRow)> HiDelete(Document doc, bool deleteDoc)
```

Ջնջում է փաստաթղթի նախկինում գրանցած հաշվառումները [HI](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/Hi.html) աղյուսակից։  
Եթե մեթոդը կանչում են [Action](../../definitions/document.md#action) իրադարձության մշակիչից, ապա սահմանաչափերի ստուգումները կկատարվեն Action-ի ավարտից հետո։  
Իսկ եթե այլ տեղից է կանչած, ապա ստուգումները կկատարվեն անմիջապես։

Վերադարձնում է կորտեժ  
`hadHIRow` - ջնջվում են որևէ հաշվառման տողեր,  
`had01AccRow` - ջնջվում են `01` հաշվառման տողեր։

**Պարամետրեր**

* `doc` - [Փաստաթղթի օբյեկտ](../../definitions/document.md)։
* `deleteDoc` - հարկավոր է փոխանցել `true`, երբ ֆունկցիան կանչվում է որևէ փաստաթղթի ջնջման ժամանակ։
  Պարամետրը փոխանցվում է OnLimitFault իրադարձության մշակիչին։
