---
layout: page
title: "Փաստաթղթի օգտագործման օրինակներ" 
tags: [Doc, Document]
---

## Օրինակ 1

Բեռնել 2319 isn-ով փաստաթուղթը DocumentService դասի Load մեթոդով։ Ստանալ փաստաթղթի մուտքագրման դաշտերը Description հատկության  Fields հատկության միջոցով, առանձնացնել և պահել պարտադիր լրացման դաշտերը։

```c#
// Պարտադիր լրացման դաշտերի պահման համար dictionary-ի սահմանում
var requiredFields = new Dictionary<string, DocumentFieldDefinition>();

// 2319 id-ով փաստաթղթի բեռնում
var doc = await this.documentService.Load(2319);

// Բոլոր դաշտերի ստացում
var allFields = doc.Description.Fields;

// Անցում բոլոր դաշտերի վրայով և պարատադիր լրացման դաշտերի առանձնացում
foreach (KeyValuePair<string, DocumentFieldDefinition> field in allFields)
{
// Դաշտը համարվում է պարտադիր լրացման, եթե պարունակում է R ատրիբուտը
    if (field.Value.Attributes.Contains('R'))
    {
        requiredFields.Add(field.Key, field.Value);
    }
}
```

## Օրինակ 2

Ստեղծել "TemplGrp" տիպի փաստաթուղթ DocumentService դասի Create մեթոդով, լրացնել դաշտերի արժեքները ու փաստաթուղթը գրանցել տվյալների պահոցում DocumentService դասի Store մեթոդով։

```c#
// TemplGrp տիպի փաստաթղթի ստեղծում
var doc = await this.documentService.Create("TemplGrp");

// Փաստաթղթի մուտքագրման դաշտերի լրացում փաստաթղթի indexer-ին փոխանցելով դաշտի ներքին անունը և վերագրելով անհրաժեշտ արժեքը
doc["CODE"] = "PaymentOrder";
doc["NAME"] = "Վճարման հանձնարարական";
doc["ENAME"] = "Payment order";

// Փաստաթղթի գրանցում տվյալների պահոցում Store մեթոդով
await this.documentService.Store(doc);
```
