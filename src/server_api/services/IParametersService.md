---
title: "IParametersService սերվիս"
---

## Ներածություն

Համակարգում նկարագրվում են պարամետրեր, որոնց միջոցով հնարավոր է սահմանել օգտագործողների որոշ իրավասություններ, ծրագրի կարգավորումներ։
Պարամետրերի արժեքները կարող են լինել [համակարգային տիպի](../types/system_types.md)։  
Պարամետրի արժեքը կարող է պահվել մեկը, կամ ըստ օգտագործողի կտրվածքի՝ այս դեպքում ամեն օգտագործող կարող է ունենալ պարամետրի սեփական արժեքը։  
Համակարգային պարամետրերը պահվում են տվյալների պահոցի [PARAMS](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/Params.html) աղյուսակում։ Ըստ օգտագործողի արժեքները պահվում են [USERPARAMS](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/User%20Params.html) աղյուսակում:  
Համակարգային պարամետրերը ստեղծվում են տեքստային ֆայլով [ներմուծման միջոցով](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Import_Files/Parameter_Import.html)։

Բացի համակարգային պարամետրերից առկա են նաև ժամանակագրական պարամետրեր։ Արժեքներ պահվում են ըստ ամսաթվի, և մեկ օրվա ընթացքում կարող է գրանցվել մի քանի արժեք։  
Պարամետրերի արժեքները կարող են լինել միայն տողային։
Ժամանակագրական պարամետրերը պահվում են տվյալների պահոցի [HIPAR](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Database/HiPar.html) աղյուսակում։

ՀԾ-Բանկի, ՀԾ-Ձեռնարկության և ՀԾ-Աշխատավարձի պրոյեկտներում առկա են բազային IParametersService-ի ժառանգ դասեր (BankParametersService, EnterpriseParametersService, WagesParametersService), որոնցում առկա են խիստ տիպիզացված մեթոդներ պարամետրերի արժեքները ստանալու համար։

## Մեթոդներ

| Անվանում | Նկարագրություն |
|----------|----------------|
| [DefaultBranch](IParametersService/DefaultBranch.md) | Վերադարձնում է **DEFBRANCH** ներքին անունով [տող տիպի](../types/system_types.md#stringfieldtype) պարամետրի արժեքը, որը ցույց է տալիս ընթացիկ օգտագործողի համար առաջարկվող գրասենյակի կոդը։ |
| [DefaultBranch](IParametersService/DefaultBranch1.md) | Վերադարձնում է **DEFBRANCH** ներքին անունով [տող տիպի](../types/system_types.md#stringfieldtype) պարամետրի արժեքը, որը ցույց է տալիս `suid` ներքին համարով օգտագործողի համար առաջարկվող գրասենյակի կոդը։ |
| [Exists](IParametersService/Exists.md) | Ստուգում է համակարգային պարամետրի գոյությունը՝ ըստ պարամետրի ներքին անվան։ |
| [ExistsHiPar](IParametersService/ExistsHiPar.md) | Ստուգում է ժամանակագրական պարամետրի նշանակված արժեքի առկայությունը: |
| [GetBooleanValue](IParametersService/GetBooleanValue.md) | Վերադարձնում է [տրամաբանական տիպի](../types/system_types.md#booleanfieldtype) պարամետրի արժեքը՝ ըստ պարամետրի ներքին անվան։ |
| [GetBooleanValue](IParametersService/GetBooleanValue1.md) | Վերադարձնում է [տրամաբանական տիպի](../types/system_types.md#booleanfieldtype) պարամետրի արժեքը՝ ըստ պարամետրի ներքին անվան և օգտագործողի համարի։ |
| [GetDecimalValue](IParametersService/GetDecimalValue.md) | Վերադարձնում է կոտորակային թիվ տիպի ([N](../types/system_types.md#numericfieldtype), [NP](../types/system_types.md#numericpositivefieldtype), [SUMMA](../types/system_types.md#amountfieldtype), [SUMMAP](../types/system_types.md#amountpositivefieldtype)) պարամետրի արժեքը՝ ըստ պարամետրի ներքին անվան։ |
| [GetDecimalValue](IParametersService/GetDecimalValue1.md) | Վերադարձնում է կոտորակային թիվ տիպի ([N](../types/system_types.md#numericfieldtype), [NP](../types/system_types.md#numericpositivefieldtype), [SUMMA](../types/system_types.md#amountfieldtype), [SUMMAP](../types/system_types.md#amountpositivefieldtype)) պարամետրի արժեքը՝ ըստ պարամետրի ներքին անվան և օգտագործողի համարի։ |
| [GetDescriptor](IParametersService/GetDescriptor.md) | Վերադարձնում է համակարգային [պարամետրի նկարագրությունը](../types/Descriptor.md): |
| [GetDetailedDescription](IParametersService/GetDetailedDescription.md) | Վերադարձնում է պարամետրի մանրամասն նկարագրությունը։ |
| [GetIntegerValue](IParametersService/GetIntegerValue.md) | Վերադարձնում է ամբողջ թիվ տիպի ([N](../types/system_types.md#numericfieldtype), [NP](../types/system_types.md#numericpositivefieldtype)) պարամետրի արժեքը՝ ըստ պարամետրի ներքին անվան։ |
| [GetIntegerValue](IParametersService/GetIntegerValue1.md) | Վերադարձնում է ամբողջ թիվ տիպի ([N](../types/system_types.md#numericfieldtype), [NP](../types/system_types.md#numericpositivefieldtype)) պարամետրի արժեքը՝ ըստ պարամետրի ներքին անվան և օգտագործողի համարի։ |
| [GetShortValue](IParametersService/GetShortValue.md) | Վերադարձնում է կարճ ամբողջ թիվ տիպի ([N](../types/system_types.md#numericfieldtype), [NP](../types/system_types.md#numericpositivefieldtype)) պարամետրի արժեքը՝ ըստ պարամետրի ներքին անվան։ |
| [GetShortValue](IParametersService/GetShortValue1.md) | Վերադարձնում է կարճ ամբողջ թիվ տիպի ([N](../types/system_types.md#numericfieldtype), [NP](../types/system_types.md#numericpositivefieldtype)) պարամետրի արժեքը՝ ըստ պարամետրի ներքին անվան և օգտագործողի համարի։ |
| [GetStringValue](IParametersService/GetStringValue.md) | Վերադարձնում է տող տիպի ([C](../types/system_types.md#stringfieldtype), [CH](../types/system_types.md#chfieldtype), [FOLDER](../types/system_types.md#folderfieldtype), [AMACC](../types/system_types.md#amaccfieldtype), [TREE](../types/system_types.md#treefieldtype), [FULLTREE](../types/system_types.md#treefieldtype), [PATH](../types/system_types.md#pathfieldtype), [FILE](../types/system_types.md#filefieldtype)) պարամետրի արժեքը՝ ըստ պարամետրի ներքին անվան։ |
| [GetStringValue](IParametersService/GetStringValue1.md) | Վերադարձնում է տող տիպի ([C](../types/system_types.md#stringfieldtype), [CH](../types/system_types.md#chfieldtype), [FOLDER](../types/system_types.md#folderfieldtype), [AMACC](../types/system_types.md#amaccfieldtype), [TREE](../types/system_types.md#treefieldtype), [FULLTREE](../types/system_types.md#treefieldtype), [PATH](../types/system_types.md#pathfieldtype), [FILE](../types/system_types.md#filefieldtype)) պարամետրի արժեքը՝ ըստ պարամետրի ներքին անվան և օգտագործողի համարի։ |
| [GetTimeSpanValue](IParametersService/GetTimeSpanValue.md) | Վերադարձնում է ժամ տիպի ([TIME](../types/system_types.md#timefieldtype), [TIMELONG](../types/system_types.md#timefieldtype)) պարամետրի արժեքը՝ ըստ պարամետրի ներքին անվան։ |
| [GetTimeSpanValue](IParametersService/GetTimeSpanValue1.md) | Վերադարձնում է ժամ տիպի ([TIME](../types/system_types.md#timefieldtype), [TIMELONG](../types/system_types.md#timefieldtype)) պարամետրի արժեքը՝ ըստ պարամետրի ներքին անվան և օգտագործողի համարի։ |
| [OperEnd](IParametersService/OperEnd.md) | Վերադարձնում է **OPEREND** ներքին անունով [ամսաթիվ տիպի](../types/system_types.md#datefieldtype) պարամետրի արժեքը, որը ցույց է տալիս գործառնական ժամանակահատվածի վերջի ամսաթիվը ընթացիկ օգտագործողի համար։ |
| [OperEnd](IParametersService/OperEnd1.md) | Վերադարձնում է **OPEREND** ներքին անունով [ամսաթիվ տիպի](../types/system_types.md#datefieldtype) պարամետրի արժեքը, որը ցույց է տալիս գործառնական ժամանակահատվածի վերջի ամսաթիվը `suid` ներքին համարով օգտագործողի համար։ |
| [OPERHOLIDAYS](IParametersService/OPERHOLIDAYS.md) | Վերադարձնում է **OPERHOLIDAYS** ներքին անունով [տրամաբանական տիպի](../types/system_types.md#booleanfieldtype) պարամետրի արժեքը, որը ցույց է տալիս, արդյոք բաց գործառնական ժամանակահատվածում հանգստյան օրերի արգելումը ակտիվ է։ |
| [OperStart](IParametersService/OperStart.md) | Վերադարձնում է **OPERSTART** ներքին անունով [ամսաթիվ տիպի](../types/system_types.md#datefieldtype) պարամետրի արժեքը, որը ցույց է տալիս գործառնական ժամանակահատվածի սկզբի ամսաթիվը ընթացիկ օգտագործողի համար։ |
| [OperStart](IParametersService/OperStart1.md) | Վերադարձնում է **OPERSTART** ներքին անունով [ամսաթիվ տիպի](../types/system_types.md#datefieldtype) պարամետրի արժեքը, որը ցույց է տալիս գործառնական ժամանակահատվածի սկզբի ամսաթիվը `suid` ներքին համարով օգտագործողի համար։ |
| [REPEND](IParametersService/REPEND.md) | Վերադարձնում է **REPEND** ներքին անունով [ամսաթիվ տիպի](../types/system_types.md#datefieldtype) պարամետրի արժեքը, որը ցույց է տալիս հաշվետու ժամանակահատվածի վերջի ամսաթիվը ընթացիկ օգտագործողի համար։ |
| [REPEND](IParametersService/REPEND1.md) | Վերադարձնում է **REPEND** ներքին անունով [ամսաթիվ տիպի](../types/system_types.md#datefieldtype) պարամետրի արժեքը, որը ցույց է տալիս հաշվետու ժամանակահատվածի վերջի ամսաթիվը `suid` ներքին համարով օգտագործողի համար։ |
| [REPSTART](IParametersService/REPSTART.md) | Վերադարձնում է **REPSTART** ներքին անունով [ամսաթիվ տիպի](../types/system_types.md#datefieldtype) պարամետրի արժեքը, որը ցույց է տալիս հաշվետու ժամանակահատվածի սկզբի ամսաթիվը ընթացիկ օգտագործողի համար։ |
| [REPSTART](IParametersService/REPSTART1.md) | Վերադարձնում է **REPSTART** ներքին անունով [ամսաթիվ տիպի](../types/system_types.md#datefieldtype) պարամետրի արժեքը, որը ցույց է տալիս հաշվետու ժամանակահատվածի սկզբի ամսաթիվը `suid` ներքին համարով օգտագործողի համար։ |
| [SetHiPar](IParametersService/SetHiPar.md) | Գրանցում է ժամանակագրական պարամետրի նոր արժեք տրված ամսաթվով: |
| [SetValue](IParametersService/SetValue.md) | Փոխում է համակարգային պարամետրի արժեքը։ |
| [SetValueWithAdditionalConnection](IParametersService/SetValueWithAdditionalConnection.md) | Փոխում է համակարգային պարամետրի արժեքը [լրացուցիչ sql միացման](IDBService/CreateAdditionalConnection.md) միջոցով։ |

## Հատկություններ

| Անվանում | Նկարագրություն |
|----------|----------------|
| [GetDateTimeValue](IParametersService/GetDateTimeValue.md) | Վերադարձնում է ամսաթիվ տիպի ([DATE](../types/system_types.md#datefieldtype), [DATELONG](../types/system_types.md#datefieldtype)) պարամետրի արժեքը՝ ըստ պարամետրի ներքին անվան։ |
| [GetDateTimeValue](IParametersService/GetDateTimeValue1.md) | Վերադարձնում է ամսաթիվ տիպի ([DATE](../types/system_types.md#datefieldtype), [DATELONG](../types/system_types.md#datefieldtype)) պարամետրի արժեքը՝ ըստ պարամետրի ներքին անվան և օգտագործողի համարի։ |
| [GetHiPar](IParametersService/GetHiPar.md) | Վերադարձնում է ժամանակագրական պարամետրի արժեքը և նշանակման ամսաթիվը։ |