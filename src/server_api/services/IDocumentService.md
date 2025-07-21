---
title: "IDocumentService սերվիս"
---

## Ներածություն

IDocumentService դասը նախատեսված է փաստաթղթի ([Document](../definitions/document.md)) հետ աշխատանքը ապահովելու համար։

## Մեթոդներ

| Անվանում | Նկարագրություն |
|----------|----------------|
| [Approve](IDocumentService/Approve.md) | Հաստատում է փաստաթուղթը և գրանցում տվյալների պահոցում։ |
| [CheckProcessingMode](IDocumentService/CheckProcessingMode.md) | Ստուգում է տրված տեսակի փաստաթղթերի գրանցման/հեռացման հնարավորությունը 8X սերվիսում (փաստաթղթի կատարման ռեժիմը (ProcessingMode) չլինի `0`)։ |
| [CleanDeleted](IDocumentService/CleanDeleted.md) | Ջնջված փաստաթղթերը լրիվ հեռացնում է համակարգից ըստ ջնջման ժամանակահատվածի։ |
| [Copy](IDocumentService/Copy.md) | Ստեղծում է արդեն գոյություն ունեցող փաստաթղթի պատճեն օբյեկտը։ |
| [Create](IDocumentService/Create2.md) | Ստեղծում է նշված ներքին անունով (տեսակի) փաստաթղթի նոր օբյեկտ։ |
| [CreateFactsUsingStateMoverFrom](IDocumentService/CreateFactsUsingStateMoverFrom.md) | Ֆունկցիան կանչելուց հետո [Action](../definitions/document.md#action)-ում [StoreFact](IDocumentService/StoreFact.md) ֆունկցիայով գրանցվող հաշվառումների ստեղծող օգատգործող է լրացվում այն օգտագործողը, որը վերջինն է փաստաթուղթը բերել նշված վիճակ։ |
| [CreateParentLinkDB](IDocumentService/CreateParentLinkDB.md) | Փաստաթղթերի միջև ստեղծում է ծնող-զավակ կապ։ |
| [CreateParentLinksDB](IDocumentService/CreateParentLinksDB.md) | Փաստաթղթի և տրված ծնող փաստաթղթերի միջև ստեղծում է ծնող-զավակ կապ։ |
| [CutChildLink](IDocumentService/CutChildLink.md) | Ջնջում է փաստաթղթի և իրա զավակների միջև կապերը, կամ մեկ նշված զավակ փաստաթղթի հետ կապը։ |
| [CutParentLink](IDocumentService/CutParentLink.md) | Ջնջում է փաստաթղթի և իրա ծնողների միջև կապերը, կամ մեկ նշված ծնող փաստաթղթի հետ կապը։ |
| [Delete](IDocumentService/Delete.md) | Ջնջում է փաստաթուղթը համակարգից։ |
| [Delete](IDocumentService/Delete1.md) | Ջնջում է փաստաթուղթը համակարգից։ |
| [DeserializeRequestBody](IDocumentService/DeserializeRequestBody.md) | նախատեսված է կլիենտից դեպի սերվեր փաստաթղթի ուղարկման ժամանակ դեսերիալիզազիայի և [Document](../definitions/document.md) տիպի օբյեկտի վերածեու համար։ |
| [ExistInDb](IDocumentService/ExistInDb.md) | Ստուգում է փաստաթղթի առկայությունը տվյալների պահոցում։ |
| [FieldToAnsi](IDocumentService/FieldToAnsi.md) | Ձևափոխում է ցանցով փոխանցված արժեքը ANSI կոդավորման համարելով, որ այն պետք է լինի փաստաթղթի դաշտի արժեք։ |
| [GetDocsInfo](IDocumentService/GetDocsInfo.md) | Վերադարձնում է փաստաթղթերի արխիվը պարունակող տվյալների պահոցի անունը և Sql միացումը դեպի այդ տվյալների պահոց։ |
| [GetDocumentState](IDocumentService/GetDocumentState.md) | Վերադարձնում է փաստաթղթի վիճակը։ |
| [GetDocumentStatus](IDocumentService/GetDocumentStatus.md) | Վերադարձնում է թղթապանակի տարրի վիճակը։ |
| [GetDocumentType](IDocumentService/GetDocumentType.md) | Վերադարձնում է նշված ներքին նույնականացման համարով փաստաթղթի ներքին անունը (տեսակը)։ |
| [GetDocumentTypeFromFolder](IDocumentService/GetDocumentTypeFromFolder.md) | Վերադարձնում է նշված թղթապանակից փաստաթղթի ներքին անունը (տեսակը): |
| [GetGrandChildren](IDocumentService/GetGrandChildren.md) | Նշված փաստաթղթի համար վերադարձնում է «թոռնիկների» ցուցակը։ |
| [GetParentIsn](IDocumentService/GetParentIsn.md) | Վերադարձնում է փաստաթղթի միակ(առաջին) ծնող փաստաթղթի ներքին նույնականացման համարը։ |
| [GetParentIsn](IDocumentService/GetParentIsn1.md) | Վերադարձնում է փաստաթղթի առաջին ծնող փաստաթղթի ներքին նույնականացման համարը, որը ունի նշված ներքին անունը (տեսակը)։ |
| [GetPassedState](IDocumentService/GetPassedState.md) | Ստուգում է և վերադարձնում փաստաթղթի վերջին կամ առաջին նշանակված վիճակը տրված վիճակների ցուցակից։ |
| [GetPassedState](IDocumentService/GetPassedState1.md) | Ստուգում է և վերադարձնում փաստաթղթի վերջին կամ առաջին նշանակված վիճակը վիճակների ցուցակը սահմանող sql հարցում արդյունքից։ |
| [GetPassedState](IDocumentService/GetPassedState2.md) | Ստուգում է տրված վիճակը հանդիանում է փաստաթղթի վերջին կամ առաջին նշանակված վիճակը, թե ոչ։ |
| [GetPassedState](IDocumentService/GetPassedState3.md) | Վերադարձնում է փաստաթղթի վերջին կամ առաջին նշանակված վիճակը։ |
| [GetProcessingModes](IDocumentService/GetProcessingModes.md) | Վերադարձնում է փաստաթղթի կատարման ռեժիմները ըստ փաստաթղթի ներքին անվան (տեսակի)։ |
| [HiDeleteAll](IDocumentService/HiDeleteAll.md) | Ջնջում է փաստաթղթի նախկինում գրանցած հաշվառումները [HI](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/Hi.html), [HI2](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/Hi2.html) և այլ համարժեք աղյուսակներից։ |
| [HiParDelete](IDocumentService/HiParDelete.md) | [HIPAR](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/HiPar.html) աղյուսակից ջնջում է այս փաստաթղթի նախկինում գրանցած պարամետրերի արժեքները։ |
| [IsArchived](IDocumentService/IsArchived.md) | Ստուգում է փաստաթղթի արխիվացված լինելը։ |
| [Load](IDocumentService/Load.md) | Բեռնում է տվյալների պահոցում գոյություն ունեցող փաստաթուղթը ըստ ներքին նույնականացման համարի։ |
| [LoadFromFolder](IDocumentService/LoadFromFolder.md) | Բեռնում է փաստաթուղթը ըստ թղթապանակի և բանալու։ |
| [MakeParentLink](IDocumentService/MakeParentLink.md) | Ընթացիկ փաստաթղթի համար սահմանում է ծնողի հետ կապ։ |
| [ReFolder](IDocumentService/ReFolder.md) | Իրականացնում է փաստաթղթի վերաինդեքսավորումը թղթապանակներում: |
| [SetGridDefaultValues](IDocumentService/SetGridDefaultValues.md) | Վերագրում է լռությամբ արժեքներ փաստաթղթի տրված աղյուսակների տրված սյուներին։ |
| [Store](IDocumentService/Store.md) | Անցկացնում է պարտադիր ստուգումներ և գրանցում փաստաթուղթը տվյալների պահոցում։ |
| [StoreFact](IDocumentService/StoreFact.md) | Գրանցում է փաստաթղթի հաշվառումը տվյալների պահոցում: |
| [StoreInFolder](IDocumentService/StoreInFolder.md) | Գրանցում է թղթապանակի տարրը տվյալների պահոցում: |
| [StoreInTree](IDocumentService/StoreInTree.md) | Գրանցում է ծառի տարրը տվյալների պահոցում: |

## Հատկություններ

| Անվանում | Նկարագրություն |
|----------|----------------|
| [Create](IDocumentService/Create.md) | Ստեղծում է նշված տիպի փաստաթղթի նոր օբյեկտ։ |
| [Create](IDocumentService/Create1.md) | Ստեղծում է նշված տիպի փաստաթղթի նոր օբյեկտ։ |
| [CreationDate](IDocumentService/CreationDate.md) | Վերադարձնում է փաստաթղթի ստեղծման ամսաթիվը և ստեղծողի ներքին համարը։ |
| [FieldsToAnsi](IDocumentService/FieldsToAnsi.md) | Ձևափոխում է ցանցով փոխանցված արժեքների բազմությունը ANSI կոդավորման համարելով, որ դրանք պետք է լինեն փաստաթղթի դաշտերի արժեքներ։ |
| [GetDocumentChildren](IDocumentService/GetDocumentChildren.md) | Վերադարձնում է փաստաթղթի զավակ փաստաթղերի isn-ների ու ներքին անունների (տեսակների) ցուցակը: |
| [GetDocumentParents](IDocumentService/GetDocumentParents.md) | Վերադարձնում է փաստաթղթի ծնող փաստաթղերի isn-ների ու ներքին անունների (տեսակների) ցուցակը: |
| [GetSUIDAndDate](IDocumentService/GetSUIDAndDate.md) | Փնտրում է նշված վիճակին համապատասխան տողի առկայությունը փաստաթղթի պատմության մեջ ([DOCLOG](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/DocLog.html) աղյուսակում) և վերադարձնում ստեղծողին և ամսաթիվը։ |
| [HiDelete](IDocumentService/HiDelete.md) | Ջնջում է փաստաթղթի նախկինում գրանցած հաշվառումները [HI](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/Hi.html) աղյուսակից։ |
| [Load](IDocumentService/Load1.md) | Բեռնում է տվյալների պահոցում գոյություն ունեցող փաստաթուղթը ըստ ներքին նույնականացման համարի։ |
| [LoadFromFolder](IDocumentService/LoadFromFolder1.md) | Բեռնում է փաստաթուղթը ըստ թղթապանակի և բանալու։ |
| [NestedTransactions](IDocumentService/NestedTransactions.md) | Մեթոդը անցնում է `values` ցուցակի բոլոր տարրերով, յուրաքանչյուրի համար սկսում տրանզակցիա, կանչում [IDocumentNestedTransaction](../types/IDocumentNestedTransaction.md)-ի [NestedTransaction](../types/IDocumentNestedTransaction.md#nestedtransaction)` մեթոդը և ավարտում տրանզակցիան։ Այն անհրաժեշտ է կանչել փաստաթղթի [Action](../definitions/document.md#action) մեթոդում։ |