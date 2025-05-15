---
layout: page
title: "ChangeRequestEventArgs" 
tags: ChangeRequest
---

Այս դասը օգտագործվում է փաստաթղթի [IDocumentChangeRequest](../IDocumentChangeRequest.md)-ի [ChangeRequest](../IDocumentChangeRequest.md#changerequest) մեթոդում։

```c#
public class ChangeRequestEventArgs
{
    public DocumentChangeRequest DCR { get; }
    public DCRResult DCRResult { get; set; } = DCRResult.NotCreated;
}
```

* `DCR` - [Փաստաթղթի փոփոխման հայտը](../DocumentChangeRequest.md)։
* `DCRResult` - Որոշում է [փաստաթղթի փոփոխման հայտի](../DocumentChangeRequest.md) վիճակը [ChangeRequest](../IDocumentChangeRequest.md#changerequest) մեթոդի կանչից հետո՝
  * **DCRResult.NotCreated** - փոփոխման հայտը ստեղծվել է,
  * **DCRResult.CreatedAndConfirmed** - փոփոխման հայտը ստեղծվել և հաստատվել է,
  * **DCRResult.CreatedAndNotConfirmed** - փոփոխման հայտը ստեղծվել է և չի հաստատվել,
  * **DCRResult.CreatedAndConfirmedWithOnConfirm** - փոփոխման հայտը ստեղծվել և ուղարկվել է կրկնակի հաստատման [PreOnConfirmDocumentChangeRequest](../../../extensions/definitions/document_extender.md#preonconfirmdocumentchangerequest), [OnConfirmDocumentChangeRequest](../../definitions/document.md#onconfirmdocumentchangerequest), [PostOnConfirmDocumentChangeRequest](../../../extensions/definitions/document_extender.md#postonconfirmdocumentchangerequest) մեթոդների միջոցով։