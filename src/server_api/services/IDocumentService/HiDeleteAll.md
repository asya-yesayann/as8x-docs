---
title: IDocumentService.HiDeleteAll(Document) մեթոդ
---

```c#
public Task HiDeleteAll(Document doc);
```

Ջնջում է փաստաթղթի նախկինում գրանցած հաշվառումները [HI](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/Hi.html), [HI2](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/Hi2.html) և այլ համարժեք աղյուսակներից։  
Եթե մեթոդը կանչում են [Action](../../definitions/document.md#action) իրադարձության մշակիչից, ապա սահմանաչափերի ստուգումները կկատարվեն Action-ի ավարտից հետո։ 
Իսկ եթե այլ տեղից է կանչած, ապա ստուգումները կկատարվեն անմիջապես։

**Պարամետրեր**

* `doc` - [Փաստաթղթի օբյեկտ](../../definitions/document.md)։
