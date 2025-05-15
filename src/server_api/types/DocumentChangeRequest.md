---
layout: page
title: "DocumentChangeRequest" 
tags: [DocChangeRequest, DCR]
---

Այս դասը նախատեսված է փաստաթղթի փոփոխման հայտի նկարագրման համար։

Օգտագործվում է `IDocumentChangeRequestService` սերվիսի ֆունկցիաներում։

```c#
public class DocumentChangeRequest
{
    public int DCRID { get; } = -1;
    public int ISN { get; }
    public short SUID { get; }
    public string Comment { get; } = string.Empty;
    public DateTime CreationDate { get; } = DateTime.Now;
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
    * **0** - նոր ստեղծված փոփոխման հայտ,
    * **1** - փոփոխման հայտը հաստատվել է,
    * **2** - փոփոխման հայտը մերժվել է։
* `EmptyMessage` - Դատարկ փաստաթղթի հայտ գրանցել փորձելիս առաջացող սխալի հաղորդագրությունը։ Եթե արժեքը դատարկ տող է, ապա առաջանում է ստանդարտ տեքստով սխալ։
* `ReFolderDocument` - `true` արժեքի դեպքում փաստաթղթի փոփոխման հայտը մերժելիս փաստաթուղթը [վերաինդեքսավորում է թղթապանակներում](../services/IDocumentService.md#refolder):
* `CreationLogMessage` - Փաստաթղթի փոփոխման հայտի ստեղծման ժամանակ [փաստաթղթի պատմությունում](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/DocLog.html) գրանցվող հաղորդագրությունը։
