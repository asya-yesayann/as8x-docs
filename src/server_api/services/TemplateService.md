---
layout: page
title: "TemplateService սերվիս" 
sublinks:
- { title: "ExistsTemplate", ref: existstemplate }
- { title: "GetDefinition", ref: getdefinition }
- { title: "GetTemplateNameAndType", ref: gettemplatenameandtype }
---

[4XTemplateSubstitution]: https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Functions/TemplateSubstitution.html

## Բովանդակություն

- [Ներածություն](#ներածություն)
  <!-- - [Copy](#copy) -->
  <!-- - [Delete](#delete) -->
  <!-- - [Edit](#edit) -->
  - [ExistsTemplate](#existstemplate)
  <!-- - [GetCount](#getcount) -->
  <!-- - [GetDataGroups](#getdatagroups) -->
  - [GetDefinition](#getdefinition)
  <!-- - [GetFileContent](#getfilecontent) -->
  <!-- - [GetMappingCount](#getmappingcount) -->
  <!-- - [GetPrintDataGroups](#getprintdatagroups) -->
  <!-- - [GetRowId](#getrowid) -->
  - [GetTemplateNameAndType](#gettemplatenameandtype)
  <!-- - [GetType](#gettype) -->
  <!-- - [Store](#store) -->
  <!-- - [UpdateDataGroups](#updatedatagroups) -->

## Ներածություն

TemplateService դասը նախատեսված է տպելու ձևանմուշների նկարագրության հետ աշխատանքը ապահովելու համար։

Տե՛ս նաև [ITemplateSubstitutionService](ITemplateSubstitutionService.md) տպելու ձևանմուշների լրացման համար։

<!-- ### Copy

```c#
public Task<int> Copy(TemplateDefinition definition)
```

Պատճենում է `definition` պարամետրում նշված տպելու ձևանմուշի նկարագրությունը, գրանցում տվյալների պահոցի `TEMPLATES` աղյուսակում և վերադարձնում գրանցված նկարագրության ներքին նույնականացման համարը (rowId):

**Պարամետրեր**

* `definition` - Պատճենման ենթակա տպելու ձևանմուշի նկարագրությունը։

### Delete

```c#
public Task Delete(string name, string type)
```

Հեռացնում է տպելու ձևանմուշի նկարագրությունը տվյալների պահոցի `TEMPLATES` աղյուսակից՝ ըստ տպելու ձևանմուշի ներքին անվան և տիպի։

**Պարամետրեր**

* `name` - Տպելու ձևանմուշի ներքին անուն:
* `type` - [Տպելու ձևանմուշի տիպ][4XTemplateSubstitution]:

### Edit

```c#
public Task Edit(TemplateDefinition definition)
```

Խմբագրում է տվյալների պահոցի `TEMPLATES` աղյուսակում գոյություն ունեցող տպելու ձևանմուշի նկարագրությունը:

**Պարամետրեր**

* `description` - Տպելու ձևանմուշի նկարագրություն:
 -->
### ExistsTemplate

```c#
public Task<bool> ExistsTemplate(string name, string type)
```

Ստուգում է տպելու ձևանմուշի նկարագրության առկայությունը տվյալների պահոցի `TEMPLATES` աղյուսակում։

**Պարամետրեր**

* `name` - Տպելու ձևանմուշի ներքին անուն:
* `type` - [Տպելու ձևանմուշի տիպ][4XTemplateSubstitution]:

**Օրինակ**

```c#
// templateNameType  =>  "AgrState\7"

var (_, templateName, templateType) = TemplateService.GetTemplateNameAndType(templateNameType);
if (!await templateService.ExistsTemplate(templateName, templateType))
{
  throw new RESTException(string.Format("'{0}' անունով և '{1}' տիպով ձևանմուշ գոյություն չունի".ToArmenianANSI(), templateName, templateType));
}
```

<!-- ### GetCount

```c#
public Task<int> GetCount(string name)
```

Վերադարձնում է նշված ներքին անունով տպելու ձևանմուշների քանակը։

**Պարամետրեր**

* `name` - Տպելու ձևանմուշի ներքին անուն:

### GetDataGroups

```c#
public Task<string> GetDataGroups(int rowId)
```

Վերադարձնում է տպելու ձևանմուշի տվյալների խմբերի անունները որպես տեքստ, որտեղ խմբերը իրարից տարանջատված են ստորակետերով։

Տվյալների խմբերը օգտագործվում են այն ձևանմուշներում, որոնք պարունակում են մեծ քանակությամբ կոդեր՝ նպատակ ունենալով կոդերը բաժանել խմբերի և հաշվարկել միայն անհրաժեշտ մասը։

**Պարամետրեր**

* `rowId` - Տպելու ձևանմուշի ներքին նույնականացման համար։
 -->
### GetDefinition

```c#
public Task<TemplateDefinition> GetDefinition(string name, string type)
```

Վերադարձնում է տպելու ձևանմուշի նկարագրությունը տվյալների պահոցի `TEMPLATES` աղյուսակից՝ ըստ տպելու ձևանմուշի ներքին անվան և տիպի։

Ֆայլի արժքների տեղադրման համար տե՛ս [LoadTemplateFile](ITemplateSubstitutionService.md#loadtemplatefile)։

**Պարամետրեր**

* `name` - Տպելու ձևանմուշի ներքին անուն:
* `type` - [Տպելու ձևանմուշի տիպ][4XTemplateSubstitution]:

<!-- ### GetFileContent

```c#
public Task<StorageInfo> GetFileContent(int rowId)
```

Բեռնում է տպելու ձևանմուշը տվյալների պահոցի `TEMPLATES` աղյուսակից, պահում [ընթացիկ սեսիայի կոնտեյներում](#container) և վերադարձնում [կոնտեյների](#container), ֆայլի անունները։

**Պարամետրեր**

* `rowId` - Տպելու ձևանմուշի ներքին նույնականացման համար:

### GetMappingCount

```c#
public Task<int> GetMappingCount(int rowId)
```

Վերադարձնում է տպելու ձևանմուշին կապակցված փաստաթղթերի քանակը։

**Պարամետրեր**

* `rowId` - Տպելու ձևանմուշի ներքին նույնականացման համար։

### GetPrintDataGroups

```c#
public Task<List<DocumentPrintDataGroupDefinition>> GetPrintDataGroups(string docType)
```

Վերադարձնում է նշված տեսակի փաստաթղթին կապակցված տպելու ձևանմուշների տվյալների խմբերի նկարագրությունների ցուցակը։

Տվյալների խմբերը օգտագործվում են այն ձևանմուշներում, որոնք պարունակում են մեծ քանակությամբ կոդեր՝ նպատակ ունենալով կոդերը բաժանել խմբերի և հաշվարկել միայն անհրաժեշտ մասը։

Տես նա՛և [PrintDataGroup](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/PrintDataGroup.html):

**Պարամետրեր**

* `docType` - Փաստաթղթի տեսակ (ներքին անուն)։

### GetRowId

```c#
public Task<int> GetRowId(string name, string type)
```

Վերադարձնում է տպելու ձևանմուշի ներքին նույնականացման համարը (rowId) տվյալների պահոցի `TEMPLATES` աղյուսակից՝ ըստ տպելու ձևանմուշի ներքին անվան և տիպի։

**Պարամետրեր**

* `name` - Տպելու ձևանմուշի ներքին անուն:
* `type` - [Տպելու ձևանմուշի տիպ][4XTemplateSubstitution]:
 -->
### GetTemplateNameAndType

```c#
public static (bool result, string templateName, string templateType) 
    GetTemplateNameAndType(string templateNameWithType, bool isBackSlash = true)
```

Բաժանում է `templateNameWithType` պարամետրում միավորված տպելու ձևանմուշի ներքին անունը (կոդը) և տիպը:  
Վերադարձնում է՝
* `result` - Ցույց է տալիս, արդյոք բաժանումը հաջողվել է:
* `templateName` - Տպելու ձևանմուշի ներքին անուն: Բաժանման չհաջողվելու դեպքում վերադարձնում է `templateNameWithType` պարամետրի արժեքը։
* `templateType` - [Տպելու ձևանմուշի տիպ][4XTemplateSubstitution]: Բաժանման չհաջողվելու դեպքում վերադարձնում է `string.Empty`։

**Պարամետրեր**

* `templateNameWithType` - Տպելու ձևանմուշի միավորված ներքին անուն (կոդ) և տիպ։
* `isBackSlash` - `true` արժեքի դեպքում բաժանումը կատարվում է ըստ `"\"` նիշի, հակառակ դեպքում՝ ըստ `"/"` նիշի։


**Օրինակ**

```c#
// templateNameType  =>  "AgrState\7"

var (_, templateName, templateType) = TemplateService.GetTemplateNameAndType(templateNameType);
// templateName  =>  "AgrState"
// templateType  =>  "7"

if (templateType != Constants.TempTypeHTML) 
{
  throw new RESTException("Ձևանմուշի տիպը պետք է լինի Html".ToArmenianANSI());
}
```

<!-- ### GetType

```c#
public Task<string> GetType(string name)
```

Վերադարձնում է [տպելու ձևանմուշի տիպը][4XTemplateSubstitution]՝ ըստ տպելու ձևանմուշի ներքին անվան։

**Պարամետրեր**

* `name` - Տպելու ձևանմուշի ներքին անուն:

### Store

```
public Task Store(TemplateDefinition description)
```

Գրանցում է տպելու ձևանմուշի նկարագրությունը տվյալների պահոցի `TEMPLATES` աղյուսակում։

**Պարամետրեր**

* `description` - Տպելու ձևանմուշի նկարագրություն:

### UpdateDataGroups

```c#
public Task UpdateDataGroups(int rowId, string dataGroups)
```

Թարմացնում է տպելու ձևանմուշի տվյալների խմբերը։

Տվյալների խմբերը օգտագործվում են այն ձևանմուշներում, որոնք պարունակում են մեծ քանակությամբ կոդեր՝ նպատակ ունենալով կոդերը բաժանել խմբերի և հաշվարկել միայն անհրաժեշտ մասը։

**Պարամետրեր**

* `rowId` - Տպելու ձևանմուշի ներքին նույնականացման համար։
* `dataGroups` - Տպելու ձևանմուշի տվյալների խմբերի անունները որպես տեքստ, որտեղ խմբերը անհրաժեշտ է իրարից տարանջատել ստորակետերով։ Օրինակ **TRN,TRNAMD**:
 -->