---
layout: page
title: "8X համակարգի պրոյեկտների նկարագրություն"
tags: [structure]
sublinks:
- { title: "ՀԾ-Բանկի 8X սերվիսի պրոյեկտներ", ref: հծ-բանկի-8x-սերվիսի-պրոյեկտներ }
- { title: "ArmSoft.AS8X.BankService", ref: armsoftas8xbankservice }
- { title: "ArmSoft.AS8X.Bank", ref: armsoftas8xbank }
- { title: "ArmSoft.AS8X.BankModels", ref: armsoftas8xbankmodels }
- { title: "ArmSoft.AS8X.BankOLAP", ref: armsoftas8xbankolap }
- { title: "ArmSoft.AS8X.Bank.Samples", ref: armsoftas8xbanksamples }
- { title: "8X հարթակի միջուկային պրոյեկտներ", ref: 8x-հարթակի-միջուկային-պրոյեկտներ }
- { title: "ArmSoft.AS8X.Service", ref: armsoftas8xservice }
- { title: "ArmSoft.AS8X.Core", ref: armsoftas8xcore }
- { title: "ArmSoft.AS8X.Common", ref: armsoftas8xcommon }
- { title: "ArmSoft.AS8X.Models", ref: armsoftas8xmodels }
- { title: "8X հարթակի REST API տիպիզացված գրադարան", ref: 8x-հարթակի-rest-api-տիպիզացված-գրադարան }
- { title: "ArmSoft.AS8X.Client", ref: armsoftas8xclient }
- { title: "8X հարթակի կոնֆիգուրացիոն սերվիս", ref: 8x-հարթակի-կոնֆիգուրացիոն-սերվիս }
- { title: "ArmSoft.AS8X.Configuration.Service", ref: armsoftas8xconfigurationservice }
---

## Բովանդակություն

- [Ներածություն](#ներածություն)
- [ՀԾ-Բանկի 8X սերվիսի պրոյեկտներ](#հծ-բանկի-8x-սերվիսի-պրոյեկտներ)
  - [ArmSoft.AS8X.BankService](#armsoftas8xbankservice)
  - [ArmSoft.AS8X.Bank](#armsoftas8xbank)
  - [ArmSoft.AS8X.BankModels](#armsoftas8xbankmodels)
  - [ArmSoft.AS8X.BankOLAP](#armsoftas8xbankolap)
  - [ArmSoft.AS8X.Bank.Samples](#armsoftas8xbanksamples)
- [8X հարթակի միջուկային պրոյեկտներ](#8x-հարթակի-միջուկային-պրոյեկտներ)
  - [ArmSoft.AS8X.Service](#armsoftas8xservice)
  - [ArmSoft.AS8X.Core](#armsoftas8xcore)
  - [ArmSoft.AS8X.Common](#armsoftas8xcommon)
  - [ArmSoft.AS8X.Models](#armsoftas8xmodels)
- [8X հարթակի REST API տիպիզացված գրադարան](#8x-հարթակի-rest-api-տիպիզացված-գրադարան)
  - [ArmSoft.AS8X.Client](#armsoftas8xclient)
- [8X հարթակի կոնֆիգուրացիոն սերվիս](#8x-հարթակի-կոնֆիգուրացիոն-սերվիս)
  - [ArmSoft.AS8X.Configuration.Service](#armsoftas8xconfigurationservice)

## Ներածություն
Ստորև ներկայացված են ՀԾ-Բանկի 8X սերվիսի բաղադրիչ պրոյեկտները։

## ՀԾ-Բանկի 8X սերվիսի պրոյեկտներ

### ArmSoft.AS8X.BankService
Պրոյեկտը մուտքային կետն է 8X սերվիսի միացման համար։ Այն ASP.NET-ով պրոյեկտ է։  
Այն կարելի է ինչպես միացնել Debugging ռեժիմում այնպես էլ կառուցել և տեղադրել IIS-ում։

Պրոյեկտը պարունակում է ՀԾ-Բանկին յուրահատուկ REST API-ների նկարագրությունները Controller-ներով իրականացված։  

### ArmSoft.AS8X.Bank
Պրոյեկտը պարունակում է ՀԾ-Բանկին յուրահատուկ նկարագրությունները (փաստաթղթթերի, տվյալների աղբյուրներ...) և սերվիսները։ 

### ArmSoft.AS8X.BankModels
Պրոյեկտը պարունակում է ՀԾ-Բանկին յուրահատուկ 8X հարթակի REST API-ին փոխանցվող և դրանից վերադարձվող դասերը։

### ArmSoft.AS8X.BankOLAP
Պրոյեկտը պարունակում է OLAP հաշվետվությունների, OLAP բանաձևերին վերաբերող տրամաբանություններ։ 

### ArmSoft.AS8X.Bank.Samples
Պրոյեկտը պարունակում է ընդլայնումների օրինակներ՝  
- Փաստաթղթերի իրադարձություների ընլայնում,
- Տվյալների աղբյուրի ընդլայնում,
- Տպելու ձևերի ընդլայնում,
- Նոր Տվյալների աղբյուր,
- Նոր փաստաթուղթ,
- Վարկային հայտերի ցուցանիշ և պայման։

## 8X հարթակի միջուկային պրոյեկտներ

### ArmSoft.AS8X.Service
Պրոյեկտը պարունակում է 8X հարթակի միջուկային/գլխավոր REST API-ների նկարագրությունները Controller-ներով իրականացված։  

### ArmSoft.AS8X.Core
Պրոյեկտը պարունակում է 8X հարթակի 
- ընդհանուր տրամաբանությունները (նույնականացում, սեսիաների կառավարում, sql միացումների ղեկավարում, սխալների մշակում, մոնիտորինգ, դիագնոստիկա, ֆայլային համակարկ, էլ.փոստ ...),
- համակարգային նկարագրությունների (Document, DataSource, DPR ...) բազային դասերը,
- նկարագրությունների ընդլայնման ինտերֆեյսները (DocumentExtender, DataSource Extender ...), 
- հիմնական սերվիսները(IDBService, IDocumentService, IParametersService ...) և դրանց կարգավորող տրամաբանությունը,
- միջուկային փաստաթղթերի և տվյալների աղբյուրների իրականացումները։

### ArmSoft.AS8X.Common
Պրոյեկտը պարունակում է 8X հարթակի 
- միջուկային հաստատուններ,
- համակարգային տիպերը(BooleanFieldType, NumPairFieldType ...),
- միջուկային տրամաբանություն չիրականացնող դասեր (RESTException, ատտրիբուտներ, NoParam, NoColumns, NoResult ...)
- .as ֆայլերի վերծանման դասերը (Parser) և ստացված նկարագրությունները,
- C#-ի ներդրված տիպերի extension մեթոդներ պարունակող դասերը(DateExtensions, StringExtensions ...)։

### ArmSoft.AS8X.Models
Պրոյեկտը պարունակում է 8X հարթակի REST API-ին փոխանցվող և դրանից վերադարձվող դասերը։

## 8X հարթակի REST API տիպիզացված գրադարան

### ArmSoft.AS8X.Client
Պրոյեկտը պարունակում է 8X հարթակի REST API-ին դիմող դասերը։

## 8X հարթակի կոնֆիգուրացիոն սերվիս

### ArmSoft.AS8X.Configuration.Service
Պրոյեկտը առաձին սերվիս է, որի միջոցով հնարավոր է ստանալ տարբեր տվյալներ տեղադրված 8X սերվիսների վերաբերյալ։ Այն ASP.NET-ով պրոյեկտ է։  
