---
title: IDocumentService.NestedTransactions(Document, List<T>, TextReport,bool, bool) մեթոդ
---

```c#
public Task<int> NestedTransactions<T>(Document document, 
                                       List<T> values, 
                                       TextReport report,
                                       bool checkDocExistence = true, 
                                       bool checkTimeStamp = true)
```

Մեթոդը անցնում է `values` ցուցակի բոլոր տարրերով, յուրաքանչյուրի համար սկսում տրանզակցիա, կանչում [IDocumentNestedTransaction](../../types/IDocumentNestedTransaction.md)-ի [NestedTransaction](../../types/IDocumentNestedTransaction.md#nestedtransaction)` մեթոդը և ավարտում տրանզակցիան։ Այն անհրաժեշտ է կանչել փաստաթղթի [Action](../../definitions/document.md#action) մեթոդում։

Վերադարձնում է այն տարրերի քանակը, որոնց մշակման ընթացքում առաջացել է սխալ։

Եթե մեթոդը կանչվում է այնպիսի փաստաթղթի համար, որը չի իրականացնում [IDocumentNestedTransaction](../../types/IDocumentNestedTransaction.md) ինտերֆեյսը, ապա առաջանում է սխալ։ 

**Պարամետրեր**

* `T` - **values** ցուցակի տարրերի տիպը։
* `document` - Մշակման ենթակա փաստաթուղթը։
* `values` - **T** տիպի արժեքների ցուցակ, որոնցից յուրաքանչյուրը մշակվելու է [IDocumentNestedTransaction](../../types/IDocumentNestedTransaction.md)-ի [NestedTransaction](../../types/IDocumentNestedTransaction.md#nestedtransaction) մեթոդի միջոցով։
* `report` - [Տեքստային հաշվետվություն](../../types/TextReport.md), որտեղ լրացվում են մեթոդի կատարման ընթացքում առաջացած սխալների մասին հաղորդագրությունները։ [Տեքստային հաշվետվություն](../../types/TextReport.md)-ում սխալների լրացուցիչ մշակման և այլ հաղորդագրությունների ավելացման համար անհրաժեշտ է, որ **document** պարամետրում նշված փաստաթուղթը իրականացնի [IDocumentNestedTransactionWithError](../../types/IDocumentNestedTransactionWithError.md) ինտերֆեյսը։
* `checkDocExistence` - **document** պարամետրում նշված փաստաթղթի տվյալների պահոցում առկայության ստուգման հայտանիշ։ Եթե պարամետրի արժեքը **true** է, փաստաթուղթը առկա է տվյալների պահոցում և [State](../../definitions/document.md#state) փոքր է 100-ից, ապա առաջանում է սխալ։ Ստուգումը իրականացվում է մինչև **values** ցուցակի մշակումը։
* `checkTimeStamp` - **document** պարամետրում նշված փաստաթղթի timestampt-ի ստուգման հայտանիշ։ Եթե պարամետրի արժեքը **true** է և timestamp-ը փոփոխվել է, ապա ընդհատում է `values` ցուցակի մշակումը։ Ստուգումը իրականացվում է յուրաքանչյուր իտերացիայի վերջում։
