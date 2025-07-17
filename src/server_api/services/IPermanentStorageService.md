---
title: "IPermanentStorageService սերվիս"
---

## Ներածություն

IPermanentStorageService դասը նախատեսված է ծրագրի աշխատանքի ընթացքում ձևավորվող մշտական ֆայլերի պահպանման և բեռնման համար։
Համակարգը կարող է կարգավորվել այնպես, որ ֆայլերի պահպանում կատարվի կա՛մ ֆայլային համակարգում, կա՛մ ամպային պահոցում։

Կարգավորվում է [appsettings.json](../../project/appsettings_json.md) կոնֆիգուրացիոն ֆայլի [Storage](../../project/appsettings_json.md#storage) բաժնի `Permanent` ենթաբաժնում։

## Մեթոդներ

| Անվանում | Նկարագրություն |
|----------|----------------|
| [GetBlobAsync](IPermanentStorageService/GetBlobAsync.md) | Վերադարձնում է ֆայլի պարունակությունը մշտական ֆայլերից պահոցից՝ որպես [Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream): |
| [UploadBlobAsync](IPermanentStorageService/UploadBlobAsync.md) | Պահպանում է `value` պարամետրի պարունակությունը մշտական ֆայլերի պահոցում՝ նշված կոնտեյների նշված ֆայլում։ |
| [UploadBlobAsync](IPermanentStorageService/UploadBlobAsync1.md) | Պահպանում է `value` պարամետրի պարունակությունը մշտական ֆայլերի պահոցի [Container](#container) հատկությամբ նշված թղթապանակում՝ `blobName` պարամետրում նշված ֆայլում։ |
| [UploadBlobAsync](IPermanentStorageService/UploadBlobAsync2.md) | Պահպանում է `stream` պարամետրի պարունակությունը մշտական ֆայլերի պահոցում՝ նշված կոնտեյների նշված ֆայլում։ |
| [UploadTempBlobAsync](IPermanentStorageService/UploadTempBlobAsync.md) | Պահպանում է `stream` պարամետրի պարունակությունը մշտական ֆայլերի պահոցի [Container](#container) հատկությամբ նշված թղթապանակում` տրված ընդլայնմամբ ֆայլում, որի անունը ձևավորվում է ավտոմատ։ |

## Հատկություններ

| Անվանում | Նկարագրություն |
|----------|----------------|
| [Container](IPermanentStorageService/Container.md) | Վերադարձնում կամ նշանակում է մշտական ֆայլերի պահպանման ընթացիկ թղթապանակը, որը հանդիսանում է մշտական ֆայլերի պահոցի ենթաթղթապանակ։ |
| [DeleteBlobAsync](IPermanentStorageService/DeleteBlobAsync.md) | Հեռացնում է ֆայլը մշտական ֆայլերի պահոցից՝ ըստ անվան և կոնտեյների։ |
| [DeleteBlobAsync](IPermanentStorageService/DeleteBlobAsync1.md) | Հեռացնում է ֆայլը մշտական ֆայլերի պահոցի [Container](#container) հատկությամբ նշված թղթապանակից։ |