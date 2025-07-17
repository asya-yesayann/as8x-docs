---
title: "IStorageService սերվիս"
---

## Ներածություն

IStorageService դասը նախատեսված է ծրագրի աշխատանքի ընթացքում ձևավորվող ժամանակավոր ֆայլերի պահպանման և բեռնման համար։
Համակարգը կարող է կարգավորվել այնպես, որ ֆայլերի պահպանում կատարվի կա՛մ ֆայլային համակարգում, կա՛մ ամպային պահոցում։

Կարգավորվում է [appsettings.json](../../project/appsettings_json.md) կոնֆիգուրացիոն ֆայլի [Storage](../../project/appsettings_json.md#storage) բաժնում։

## Մեթոդներ

| Անվանում | Նկարագրություն |
|----------|----------------|
| [GetTempBlobUrl](IStorageService/GetTempBlobUrl.md) | Վերադարձնում է [ընթացիկ սեսիայի կոնտեյներում](#container) գոյություն չունեցող, պատահականության սկզբունքով ընտրված ֆայլի անուն՝ ներառյալ ընդլայնումը և ֆայլի ամբողջական ճանապարհը։ |
| [UploadBlobAsync](IStorageService/UploadBlobAsync.md) | Պահպանում է `value` պարամետրի պարունակությունը ժամանակավոր ֆայլերի պահոցում` ըստ կոնտեյների և ֆայլի անվան։ |
| [UploadBlobAsync](IStorageService/UploadBlobAsync1.md) | Պահպանում է `stream` պարամետրի պարունակությունը [ընթացիկ սեսիայի կոնտեյների](#container) նշված ֆայլում։ |
| [UploadBlobAsync](IStorageService/UploadBlobAsync2.md) | Պահպանում է `stream` պարամետրի պարունակությունը ժամանակավոր ֆայլերի պահոցում՝ նշված կոնտեյների նշված ֆայլում։ |
| [UploadTempBlobAsync](IStorageService/UploadTempBlobAsync.md) | Պահպանում է `stream` պարամետրի պարունակությունը [ընթացիկ սեսիայի կոնտեյների](#container) նշված ընդլայնմամբ ֆայլում, որի անունը ձևավորվում է ավտոմատ։ |

## Հատկություններ

| Անվանում | Նկարագրություն |
|----------|----------------|
| [Container](IStorageService/Container.md) | Վերադարձնում է այն կոնտեյների/թղթապանակի անունը, որտեղ պահվում են ընթացիկ սեսիայի ժամանակավոր ստեղծվող ֆայլերը։ |
| [DeleteBlobAsync](IStorageService/DeleteBlobAsync.md) | Հեռացնում է ֆայլը ժամանակավոր ֆայլերի պահոցից` ըստ անվան և կոնտեյների։ |
| [DeleteBlobAsync](IStorageService/DeleteBlobAsync1.md) | Հեռացնում է ֆայլը [ընթացիկ սեսիայի կոնտեյներից](#container)։ |
| [GetBlobAsync](IStorageService/GetBlobAsync.md) | Վերադարձնում է ֆայլի պարունակությունը ժամանակավոր ֆայլերի պահոցից` որպես [Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream): |