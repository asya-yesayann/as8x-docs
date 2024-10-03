---
layout: page
title: "Տվյալների աղբյուրի օգտագործման օրինակներ"
sublinks:
- { title: "Չտիպիզացված կատարում", ref: չտիպիզացված-կատարում }
- { title: "Տիպիզացված կատարում", ref: տիպիզացված-կատարում }
---

## Ներածություն

AS-8X համակարգում տվյալների աղբյուրի կատարման երկու հիմնական մեթոդ կա՝ **չտիպիզացված** և **տիպիզացված**: 
Այս երկու մեթոդները տարբերվում են իրենց իրականացման, օգտագործման և վերադարձվող արդյունքի առումով:

Խորհուրդ է տրվում միշտ օգտագործել **տիպիզացված** կատարման մեթոդը։

## Հիմնական տարբերությունները

1. **Պարամետրերի փոխանցում**
   * Չտիպիզացված՝ օգտագործում է `Dictionary<string, object>`՝ պարամետրերի արժեքների պահման համար
   * Տիպիզացված՝ օգտագործում է պարամետրերը նկարագրող դասը
2. **Կատարման մեթոդ**
   * Չտիպիզացված՝ [DataSourceService](../services/DataSourceService.md) դասի [ExecuteDataSource](../services/DataSourceService.md#executedatasource) մեթոդը
   * Տիպիզացված՝ տվյալների աղբյուրի օբյեկտի [Execute](../definitions/ds.md#execute) մեթոդը
3. **Վերադարձվող արդյունք**
   * Չտիպիզացված՝ `List<R>`՝ որպես `R` վերադարձնելով տվյալների աղբյուրի տողը նկարագրող դասը
   * Տիպիզացված՝ `DataSourceResult<R>`` որպես `R` վերադարձնելով տվյալների աղբյուրի տողը նկարագրող դասը
4. **Տիպի անվտանգություն**
   * Չտիպիզացված՝ ցածր, հնարավոր են runtime սխալներ
   * Տիպիզացված՝ բարձր, compile-time ստուգումներ են իրականացվում
5. **Լրացուցիչ մետատվյալներ**
   * Չտիպիզացված՝ չի տրամադրում
   * Տիպիզացված՝ տրամադրում է (տվյալների աղբյուրի [սխեմա](../types/schema.md), կատարման ընթացքում առաջացած սխալների մասին ինֆորմացիա և այլն)

Օրինակներում օգտագործված տվյալների աղբյուրի նկարագրող դասին ծանոթանալու համար [տես](ds/sql_based_code.cs)։

## Չտիպիզացված կատարում

1. Ստեղծել `Dictionary<string, object>` տիպի օբյեկտ՝ փոխանցելով կատարման համար անհրաժեշտ պարամետրերը՝ որպես key գրելով պարամետրի անունը, իսկ որպես value` արժեքը:
2. Կանչել [DataSourceService](../services/DataSourceService.md) դասի [ExecuteDataSource](../services/DataSourceService.md#executedatasource) մեթոդը՝ փոխանցելով տվյալների աղբյուրի ներքին անունը և պարամետրերի ցանկը:

```csharp
// 1. Ստեղծել Dictionary և լրացնել պարամետրերը
var dsParams = new Dictionary<string, object>()
{
    {"TreeId", "PARGROUP" },
    {"NodeType", "Install" }
};

// 2. Կատարել տվյալների աղբյուրը
List<TreeNode.DataRow> dsResult = await this.dataSourceService.ExecuteDataSource<TreeNode.DataRow>("TreeNode", dsParams);

// ցիկլով անցնել տողերի վրայով և տպել արժեքները
foreach (TreeNode.DataRow row in dsResult)
{
    Debug.WriteLine("Code - " + row.Code);
    Debug.WriteLine("Name - " + row.Name);
    Debug.WriteLine(string.Empty);
}
```

## Տիպիզացված կատարում

1. Ստանալ տվյալների աղբյուրի նկարագրող դասը [DataSourceService](../services/DataSourceService.md).[GetDataSource](../services/DataSourceService.md#getdatasource) մեթոդով:
2. Ստեղծել տվյալների աղբյուրի պարամետրերը նկարագրող դասի օբյեկտ՝ փոխանցելով կատարման համար անհրաժեշտ պարամետրերը։
3. Կանչել տվյալների աղբյուրի դասի [Execute](../definitions/ds.md#execute) մեթոդը՝ փոխանցելով պարամետրերը նկարագրող դասը:

```csharp
// 1. Ստանալ տվյալների աղբյուրը 
TreeNode dsTreeNode = this.dataSourceService.GetDataSource<TreeNode>(); 

// 2. Ստեղծել և լրացնել պարամետրերի նկարագրող դասի օբյեկտը 
var dsParams = new TreeNode.Param { 
    TreeId = "PARGROUP", 
    NodeType = "Install"
}; 

// 3. Կատարել տվյալների աղբյուրը 
DataSourceResult<TreeNode.DataRow> dsResult = await dsTreeNode.Execute(dsParams);

// ցիկլով անցնել տողերի վրայով և տպել արժեքները
foreach (TreeNode.DataRow row in dsResult.Rows)
{
  Debug.WriteLine("Code - " + row.Code);
  Debug.WriteLine("Name - " + row.Name);
  Debug.WriteLine(string.Empty);
}
```
