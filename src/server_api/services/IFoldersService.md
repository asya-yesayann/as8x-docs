---
title: "IFoldersService սերվիս"
---

## Ներածություն

FolderService դասը նախատեսված է [FOLDERS](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/Folders.html) աղյուսակից թղթապանակի տարրերի հետ աշխատանքը ապահովելու համար։

Աղյուսակում գրանցման համար օգտագործվում է [IDocumentService](IDocumentService.md).[StoreInFolder](IDocumentService/StoreInFolder.md) ֆունկցիայով։

## Մեթոդներ

| Անվանում | Նկարագրություն |
|----------|----------------|
| [Exists](IFoldersService/Exists.md) | Ստուգում է որևէ տարրի առկայությունը տվյալների պահոցի [FOLDERS](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/Folders.html) աղյուսակում։ |
| [GetElement](IFoldersService/GetElement.md) | Վերադարձնում է [թղթապանակի տարրը](../types/FolderElement.md)՝ ըստ թղթապանակի ներքին անվան և փաստաթղթի ներքին նույնականացման համարի։ |
| [GetElement](IFoldersService/GetElement1.md) | Վերադարձնում է [թղթապանակի տարրը](../types/FolderElement.md)՝ ըստ թղթապանակի ներքին անվան և բանալու։ |
| [GetElements](IFoldersService/GetElements.md) | Վերադարձնում է թղթապանակի բոլոր [տարրերը](../types/FolderElement.md): |
| [GetElements](IFoldersService/GetElements1.md) | Վերադարձնում է թղթապանակի նշված բանալիներով [տարրերը](../types/FolderElement.md): |
| [GetISN](IFoldersService/GetISN.md) | Վերադարձնում է թղթապանակում գրանցված փաստաթղթի ներքին նույնականացման համարը՝ ըստ թղթապանակի ներքին անվան և բանալու։ |
