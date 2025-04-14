---
layout: page
title: "IDocumentNestedTransactionWithError ինտերֆեյս" 
---

## Մեթոդներ

### NestedTransaction

```c#
public Task NestedTransaction(NestedTransactionEventArgs<T> args)
```

Մեթոդը կանչվում է [IDocumentService](../services/IDocumentService.md)-ի [NestedTransactions](../services/IDocumentService.md#nestedtransactions) մեթոդի **values** ցուցակի յուրաքանչյուր տարրի մշակման ընթացում:

**Պարամետրեր**

* `args` - **NestedTransactionEventArgs** դասի օբյեկտ, որը պարունակում է **values** ցուցակի ընթացիկ մշակվող տարրը։

### NestedTransactionError

```c#
public Task NestedTransactionError(NestedTransactionErrorEventArgs<T> args)
```

Մեթոդը կանչվում է [IDocumentService](../services/IDocumentService.md)-ի [NestedTransactions](../services/IDocumentService.md#nestedtransactions) մեթոդի **values** ցուցակի տարրերի մշակման ընթացում՝ սխալներ առաջանալու դեպքում։ Նախատեսված է սխալները պարունակող [տեքստային հաշվետվությունում](TextReport.md) սխալների լրացուցիչ մշակման և այլ հաղորդագրությունների ավելացման համար։

**Պարամետրեր**

* `args` - **NestedTransactionErrorEventArgs** դասի օբյեկտ, որը պարունակում է **values`** ցուցակի այն տարրը, որի մշակման ընթացքում առաջացել է սխալը և սխալները պարունակող [տեքստային հաշվետվությունը](TextReport.md)։