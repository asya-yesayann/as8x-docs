---
layout: page
title: "IDocumentNestedTransaction ինտերֆեյս" 
---

## Մեթոդներ

### NestedTransaction

```c#
public Task NestedTransaction(NestedTransactionEventArgs<T> args)
```

Մեթոդը կանչվում է [IDocumentService](../services/IDocumentService.md)-ի [NestedTransactions](../services/IDocumentService.md#nestedtransactions) մեթոդի **values** ցուցակի յուրաքանչյուր տարրի մշակման ընթացում:

**Պարամետրեր**
* `args` - **NestedTransactionEventArgs** դասի օբյեկտ, որը պարունակում է **values** ցուցակի ընթացիկ մշակվող տարրը։