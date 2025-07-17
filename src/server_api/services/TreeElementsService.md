---
title: "TreeElementsService սերվիս"
---

## Ներածություն

TreeElementService դասը նախատեսված է ծառի հանգույցների հետ աշխատանքը ապահովելու համար։

Ծառի հանգույցները ծրագրային ստեղծվում են երկու ձևով, 
- փաստաթղթերի հետ կապված [IDocumentService](IDocumentService.md).[StoreInTree](IDocumentService.md#storeintree) ֆունկցիայով,
- անկախ հանգույցներ [AddNode](#addnode) ֆունկցիայով։

Ծառի հանգույցները պահվում են [TREES](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/Trees.html) աղյուսակում։

## Մեթոդներ

| Անվանում | Նկարագրություն |
|----------|----------------|
| [AddNode](TreeElementsService/AddNode.md) | Ավելացնում է ծառի նոր հանգույց տվյալների պահոցում։ |
| [DeleteNode](TreeElementsService/DeleteNode.md) | Հեռացնում է ծառի հանգույցը տվյալների պահոցից։ |
| [EditNode](TreeElementsService/EditNode.md) | Խմբագրում է ծառի հանգույցը և գրանցում տվյալների պահոցում։ |
| [ExistsInDB](TreeElementsService/ExistsInDB.md) | Ստուգում է ծառի հանգույցի առկայությունը տվյալների պահոցում։ |
| [Get](TreeElementsService/Get.md) | Բեռնում է [ծառի տարրը](../types/TreeElement.md) տվյալների պահոցից կամ քեշից, եթե ծառը քեշավոևվող է։ |
| [GetTreeElements](TreeElementsService/GetTreeElements.md) | Վերադարձնում է ծառի տարրերը տվյալների պահոցից կամ քեշից, եթե ծառը քեշավորվող է։ |
