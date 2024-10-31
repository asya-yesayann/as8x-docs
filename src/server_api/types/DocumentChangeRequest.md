---
layout: page
title: "DocumentChangeRequest" 
tags: [DocChangeRequest, DCR]
---

Այս դասը նախատեսված է փաստաթղթի փոփոխման հայտի նկարագրման համար։

Օգտագործվում է [IDocumentChangeRequestService](../services/IDocumentChangeRequestService.md) սերվիսի ֆունկցիաներում։

```c#
public class DocumentChangeRequest
{
    public int DCRID { get; internal set; } = -1;
    public int ISN { get; internal set; }
    public short SUID { get; internal set; }
    public string Comment { get; internal set; } = string.Empty;
    public DateTime CreationDate { get; internal set; } = DateTime.Now;
    public short State { get; set; }
    public string EmptyMessage { get; set; }
    public bool ReFolderDocument { get; set; }
    public string CreationLogMessage { get; set; }
}
```

* `DCRID` - Փաստաթղթի փոփոխման հայտի համարը։
* `ISN` - Այն փաստաթղթի ներքին նույնականացման համարը (isn), որի համար ուղարկվել է փոփոխման հայտ։
* `SUID` - Փաստաթղթի փոփոխման հայտը ստեղծած օգտատիրոջ ներքին համարը (id)։
* `Comment` - Փաստաթղթի փոփոխման հայտի մեկնաբանությունը։
* `CreationDate` - Փաստաթղթի փոփոխման հայտի ստեղծման ամսաթիվը/ժամանակը։
* `State` - Փաստաթղթի փոփոխման հայտի վիճակը։
    * 0 - Նոր ստեղծված փաստաթղթի փոփոխման հայտ
    * 1 - Փաստաթղթի փոփոխման հայտը հաստատվել է
    * 2 - Փաստաթղթի փոփոխման հայտը մերժվել է
* `EmptyMessage` - Դատարկ փաստաթղթի հայտ գրանցել փորձելիս առաջացող սխալի հաղորդագրությունը։ Եթե արժեքը դատարկ տող է, ապա առաջանում է ստանդարտ տեքստով սխալ։
* `ReFolderDocument` - `true` արժեքի դեպքում փաստաթղթի փոփոխման հայտը մերժելիս փաստաթուղթը [վերաինդեքսավորում է թղթապանակներում](../services/IDocumentService.md#refolder):
* `CreationLogMessage` - Փաստաթղթի փոփոխման հայտի ստեղծման ժամանակ [փաստաթղթի պատմությունում](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/DocLog.html) գրանցվող հաղորդագրությունը։
