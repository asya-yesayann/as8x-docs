---
layout: page
title: "IDocumentChangeRequest ինտերֆեյս"
---

## Մեթոդներ

### ChangeRequest

```c#
public Task ChangeRequest(ChangeRequestEventArgs args)
```

Մեթոդը կանչվում է փաստաթղթի փոփոխման հայտի մշակման ընթացքում։ 

**Պարամետրեր**

* `args` - [ChangeRequestEventArgs](args/ChangeRequestEventArgs.md) դասի օբյեկտ, որը պարունակում է փաստաթղթի [փոփոխման հայտը](DocumentChangeRequest.md) և սահմանում է հայտի վիճակը մեթոդի կանչից հետո։

## Կարևոր

Փաստաթղթի փոփոխման հայտը հաստատելիս կանչվում են հետևյալ մեթոդները նշված հերթականությամբ՝  
* [ChangeRequest](#changerequest),
* [PreOnConfirmDocumentChangeRequest](../../extensions/definitions/document_extender.md#preonconfirmdocumentchangerequest),
* [OnConfirmDocumentChangeRequest](../definitions/document.md#onconfirmdocumentchangerequest),
* [PostOnConfirmDocumentChangeRequest](../../extensions/definitions/document_extender.md#postonconfirmdocumentchangerequest):

Մեթոդները կանչվում են դրանց մշակման դեպքում և յուրաքանչյուր մեթոդի պարամետրերը կանչից հետո փոխանցվում են հաջորդին։

[PreOnConfirmDocumentChangeRequest](../../extensions/definitions/document_extender.md#preonconfirmdocumentchangerequest), [OnConfirmDocumentChangeRequest](../definitions/document.md#onconfirmdocumentchangerequest), [PostOnConfirmDocumentChangeRequest](../../extensions/definitions/document_extender.md#postonconfirmdocumentchangerequest) մեթոդները կանչվում են միայն այն դեպքում, երբ [ChangeRequest](#changerequest) մեթոդի [ChangeRequestEventArgs](args/ChangeRequestEventArgs.md) պարամետրի `DCRResult` հատկության արժեքը **CreatedAndConfirmedWithOnConfirm** է։