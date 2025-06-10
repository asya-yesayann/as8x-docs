---
layout: page
title: "RejectDocumentChangeRequestEventArgs" 
tags: OnRejectDCR
---

Այս դասը պարունակում է փաստաթղթի փոփոխման հայտի մերժման տվյալներ և օգտագործվում է [PreOnRejectDocumentChangeRequest](../../../extensions/definitions/document_extender.md#preonrejectdocumentchangerequest), [OnRejectDocumentChangeRequest](../../definitions/document.md#onrejectdocumentchangerequest), [PostOnRejectDocumentChangeRequest](../../../extensions/definitions/document_extender.md#postonrejectdocumentchangerequest) մեթոդներում։

```c#
public class RejectDocumentChangeRequestEventArgs
{
    public DocumentChangeRequest DCR { get; }
    public string RejectComment { get; }
}
```

* `DCR` - [Փաստաթղթի փոփոխման հայտը](../DocumentChangeRequest.md)։
* `RejectComment` - [Փաստաթղթի փոփոխման հայտի](../DocumentChangeRequest.md) մերժման մեկնաբանությունը: