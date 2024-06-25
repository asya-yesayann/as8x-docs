---
layout: page
title: "(DataSource) Տվյալների աղբյուր ձեռնարկ"
tags: [DataSource, DS]
---

## Բովանդակություն
* [Ընդհանուր](#ընդհանուր)
* [Sql-based տվյալների աղբյուրի նկարագրման ձեռնարկ](#sql-based-տվյալների-աղբյուրի-նկարագրման-ձեռնարկ)
  * [.as ընդլայնմամբ ֆայլի սահմանում](#as-ընդլայնմամբ-ֆայլի-սահմանում)
  * [.cs ընդլայնմամբ ֆայլի սահմանում](#cs-ընդլայնմամբ-ֆայլի-սահմանում)
    * [Կոնստրուկտորի ձևավորում](#կոնստրուկտորի-ձևավորում)
    * [Sql հարցման ձևավորում](#sql-հարցման-ձևավորում)
* [Array-based տվյալների աղբյուրի նկարագրման ձեռնարկ](#array-based-տվյալների-աղբյուրի-նկարագրման-ձեռնարկ)
  * [.as ընդլայնմամբ ֆայլի սահմանում](#as-ընդլայնմամբ-ֆայլի-սահմանում)
  * [.cs ընդլայնմամբ ֆայլի սահմանում](#cs-ընդլայնմամբ-ֆայլի-սահմանում)
    * [Կոնստրուկտորի ձևավորում](#կոնստրուկտորի-ձևավորում)
    * [Տվյալների ձևավորում](#տվյալների-ձևավորում)

## Ընդհանուր

8X-ում տվյալների աղբյուրի նկարագրության համար հարկավոր է ունենալ 
- .as ֆայլ սկրիպտերի մեջ, որը պարունակում է մետատվյալներ տվյալների աղբյուրի մասին,
- .cs ֆայլ, որը պարունակում է սերվերում աշխատող տրամաբանությունը։ 

## Sql-based տվյալների աղբյուրի նկարագրման ձեռնարկ

Ամբողջական կոդը դիտելու համար [տե՛ս](/src/server_api/examples/ds/sql_based_code.cs)։

## .as ընդլայնմամբ ֆայլի սահմանում
- Ստեղծել .as ընդլայնմամբ ֆայլ՝ ավելացնելով DATA տիպի նկարագրություն, որը պարունակում է տվյալների աղբյուրի՝
  - NAME - ներքին անվանումը,
  - CAPTION - հայերեն անվանումը՝ `ANSI` կոդավորմամբ,
  - ECAPTION - անգլերեն անվանումը,
  - PROCESSINGMODE - կատարման ռեժիմը։
- Ստեղծված ֆայլը ներմուծել տվյալների բազա `Syscon` գործիքով։

```c#
DATA {
NAME = TreeNode;
CAPTION = "Ծառի հանգույցներ";
ECAPTION = "Tree Nodes";
PROCESSINGMODE = 1;
}
```

## .cs ընդլայնմամբ ֆայլի սահմանում
- Ստեղծել տվյալների աղբյուրի սյուները նկարագրող դաս՝ որպես հատկություններ ավելացնելով սյուները, որը պարտադիր պետք է իրականացնի `IExtendableRow` ինտերֆեյսը։
```c#
public class DataRow : IExtendableRow
{
    public string Code { get; set; }
    public string Name { get; set; }
    public object Extend { get; set; }
}
```

- Ստեղծել տվյալների աղբյուրի պարամետրերը նկարագրող դաս՝ որպես հատկություններ ավելացնելով պարամետրերը։
```c#
public class Param
{
    public string TreeId { get; set; }
    public string NodeType { get; set; }
}
```

- Հայտատարել դաս, որը ունի տվյալների աղբյուրի ներքին անվանումը պարունակող `DataSource` ատրիբուտը և  ժառանգում է `DataSource<R, P>` դասը՝ որպես R փոխանցելով տվյալների աղբյուրի սյուները նկարագրող դասը, իսկ որպես P՝ պարամետրերը նկարագրող դասը։ Եթե տվյալների աղբյուրը չի պարունակում պարամետրեր, ապա որպես P անհրաժեշտ է փոխանցել `NoParam` դասը։

```c#
[DataSource(nameof(TreeNode))]
public class TreeNode : DataSource<TreeNode.DataRow, TreeNode.Param>
```

### Կոնստրուկտորի ձևավորում

- Ձևավորել տվյալների աղբյուրի կոնստրուկտորը՝ IServiceProvider տիպի պարտադիր պարամետրով, որը պիտի կանչի base DataSource<R, P> դասի կոնստրուկտորը և փոխանցի IServiceProvider տիպի պարամետրը: Կոնստուկտորում անհրաժեշտ է [ինյեկցիա](https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection) անել աշխատանքի համար անհրաժեշտ service-ները։

```c#
private readonly IDBService dBService;

public TreeNode(IDBService dbService, IServiceProvider serviceProvider) : base(serviceProvider)
{
    this.dBService = dbService;
    ...
}
```
- Կոնստրուկտորում ավելացնել տվյալների աղբյուրի սխեման, որը պարունակում է ամբողջական ինֆորմացիա տվյալների աղբյուրի սյուների ու պարամետրերի մասին։
Դա անելու համար անհրաժեշտ է base դասի Schema հատկությանը վերագրել [Schema](/src/server_api/definitions/schema.md#schema) դասի նոր օբյեկտ ՝ կոնստրուկտորին փոխանցելով սխեմայի՝

  - name - ներքին անվանումը,
  - armenianCaption - հայերեն անվանումը,
  - englishCaption - անգլերեն անվանումը,
  - rowType - տվյալների աղբյուրի սյուները նկարագրող դասի տիպը,
  - paramType - տվյալների աղբյուրի պարամետրերը  նկարագրող դասի տիպը:

```c#
this.Schema = new Schema(name: this.Name, armenianCaption: "Ծառի հանգույցներ".ToArmenianANSI(), englishCaption: "Tree nodes", rowType: typeof(DataRow), paramType: typeof(Param));
```

- Սխեմայում ավելացնել տվյալների աղբյուրի սյուների նկարագրությունները Schema դասի [AddColumn](/src/server_api/definitions/schema.md#addcolumn) մեթոդի միջոցով, որին փոխանցված է սյան՝
  
  - name - ներքին անվանումը,
  - source - SQL-ից կարդացվող սյան անունը,
  - armenianCaption - հայերեն անվանումը,
  - englishCaption - անգլերեն անվանումը,
  - columnType - համակարգային տիպը։
  
```c#
this.Schema.AddColumn(name։ nameof(DataRow.Code), source։ "Code", armenianCaption։ "Կոդ".ToArmenianANSI(), englishCaption։ "Code", columnType։ FieldTypeProvider.GetStringFieldType(20));
this.Schema.AddColumn(name։ nameof(DataRow.Name), source։ "Name", armenianCaption։ "Անվանում".ToArmenianANSI(), englishCaption։ "Name", columnType։ FieldTypeProvider.GetStringFieldType(50));
```

- Սխեմայում ավելացնել պարամետրերի նկարագրությունները Schema դասի [AddParam](/src/server_api/definitions/schema.md#addparam) մեթոդի միջոցով, որին փոխանցված է պարամետրի՝

  - name - ներքին անվանումը,
  - description - հայերեն նկարագրությունը,
  - eDescription - անգլերեն անվանումը,
  - columnType - համակարգային տիպը։

```c#
this.Schema.AddParam(name: nameof(Param.TreeId), description: "Ծառի իդենտիֆիկատոր".ToArmenianANSI(), fieldType։ FieldTypeProvider.GetStringFieldType(4), eDescription: "TreeId");
this.Schema.AddParam(name: nameof(Param.NodeType), description: "Ծառի հանգույցներ".ToArmenianANSI(), fieldType։ FieldTypeProvider.GetStringFieldType(1), eDescription: "Tree nodes");
```

### Sql հարցման ձևավորում
Տվյալների աղբյուրը ըստ տվյալների բեռնման աղբյուրի լինում է 2 տեսակի՝ sql-based և array-based:
Տվյալների աղբյուրի տվյալների բեռնման տեսակը որոշվում է `IsSQLBased` boolean տիպի հատկության միջոցով, որի լռությամբ արժեքը true է։

- Եթե տվյալների աղբյուրը `sql-based` է (տվյալների աղբյուրի տվյալները ստացվում են sql հարցման միջոցով), ապա sql հարցումը ձևավորելու համար անհրաժեշտ է գերբեռնել `MakeSQLCommand` մեթոդը՝ DataSourceArgs<P> պարամետրին որպես P փոխանցելով տվյալների աղբյուրի պարամետրերը նկարագրող դասը։

```c#
protected override Task<SqlCommand> MakeSQLCommand(DataSourceArgs<Param> args, CancellationToken stoppingToken)
{
    var cmd = this.dBService.Connection.CreateCommand();
    cmd.CommandText = $@"SELECT fCODE AS Code, fNAME AS [Name]
                        FROM TREES 
                        WHERE t.fTREEID = @TreeId";

cmd.Parameters.Add("@TreeId", SqlDbType.Char, 8).Value = args.Parameters.TreeId;
if (!string.IsNullOrWhiteSpace(args.Parameters.NodeType))
{
    cmd.CommandText += " AND fLEAF = @NodeType";
    cmd.Parameters.Add("@NodeType", SqlDbType.Char, 1).Value = args.Parameters.NodeType;
}

cmd.CommandText += "\n ORDER BY Code";
return Task.FromResult(cmd);
}
```
MakeSQLCommand մեթոդում անհրաժեշտ է ստեղծել [SqlCommand](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlcommand?view=sqlclient-dotnet-standard-5.2) դասի օբյեկտ՝ IDBService դասի [Connection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlconnection?view=sqlclient-dotnet-standard-5.2) հատկության [CreateCommand](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlconnection.createcommand?view=sqlclient-dotnet-standard-5.2#microsoft-data-sqlclient-sqlconnection-createcommand) մեթոդի միջոցով, որը ընթացիկ sql միացման համար ստեղծում է [SqlCommand](https://learn.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlcommand?view=netframework-4.8.1)` sql հարցումը ձևավորվելու համար։

Ստեղծված [SqlCommand](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlcommand?view=sqlclient-dotnet-standard-5.2) դասի օբյեկտի [CommandText](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlcommand.commandtext?view=sqlclient-dotnet-standard-5.2) հատկությանը հարկավոր է փոխանցել հարցման տեքստը։
MakeSQLCommand մեթոդի վերջում անհրաժեշտ է վերադարձնել ձևավորված sql հարցումը։



## Array-based տվյալների աղբյուրի նկարագրման ձեռնարկ

Ամբողջական կոդը դիտելու համար [տե՛ս](/src/server_api/examples/ds/array_based_code.cs)։

## .as ընդլայնմամբ ֆայլի սահմանում
- Ստեղծել .as ընդլայնմամբ ֆայլ՝ ավելացնելով DATA տիպի նկարագրություն, որը պարունակում է տվյալների աղբյուրի՝
  - NAME - ներքին անվանումը,
  - CAPTION - հայերեն անվանումը՝ `ansi` կոդավորմամբ,
  - ECAPTION - անգլերեն անվանումը,
  - ARRAYBASED - տիպը՝ array-based թե sql-based,
  - PROCESSINGMODE - կատարման ռեժիմը։
- Ստեղծված ֆայլը ներմուծել տվյալների բազա `Syscon` գործիքով։

```c#
DATA {
NAME = DocFlds;
CAPTION = "Փաստաթղթի դաշտեր";
ECAPTION = "Document's fields";
ARRAYBASED = 1;
PROCESSINGMODE = 1;
}
```

## .cs ընդլայնմամբ ֆայլի սահմանում
- Ստեղծել տվյալների աղբյուրի սյուները նկարագրող դաս՝ որպես հատկություններ ավելացնելով սյուները, որը պարտադիր պետք է իրականացնի `IExtendableRow` ինտերֆեյսը։
```c#
public class DataRow : IExtendableRow
{
    public string Code { get; set; }
    public string Caption { get; set; }
    public object Extend { get; set; }
}
```

- Ստեղծել տվյալների աղբյուրի պարամետրերը նկարագրող դաս՝ որպես հատկություններ ավելացնելով պարամետրերը։
```c#
public class Param
{
    public string DocType { get; set; }
}
```

- Հայտատարել դաս, որը ունի տվյալների աղբյուրի ներքին անվանումը պարունակող `DataSource` ատրիբուտը և  ժառանգում է `DataSource<R, P>` դասը՝ որպես R փոխանցելով տվյալների աղբյուրի սյուները նկարագրող դասը, իսկ որպես P՝ պարամետրերը նկարագրող դասը։ Եթե տվյալների աղբյուրը չի պարունակում պարամետրեր, ապա որպես P անհրաժեշտ է փոխանցել `NoParam` դասը։

```c#
[DataSource("DocFlds")]
public class DocumentFields : DataSource<DocumentFields.DataRow, DocumentFields.Param>
```

### Կոնստրուկտորի ձևավորում

- Ձևավորել տվյալների աղբյուրի կոնստրուկտորը՝ IServiceProvider տիպի պարտադիր պարամետրով, որը պիտի կանչի base DataSource<R, P> դասի կոնստրուկտորը և փոխանցի IServiceProvider տիպի պարամետրը: Կոնստուկտորում անհրաժեշտ է [ինյեկցիա](https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection) անել աշխատանքի համար անհրաժեշտ service-ները։

```c#
private readonly IDBService dBService;

public DocumentFields(IDBService dbService, IServiceProvider serviceProvider) : base(serviceProvider)
{
    this.dBService = dbService;
    ...
}
```

- Կոնստրուկտորում ավելացնել տվյալների աղբյուրի սխեման, որը պարունակում է ամբողջական ինֆորմացիա տվյալների աղբյուրի սյուների ու պարամետրերի մասին։
Դա անելու համար անհրաժեշտ է base դասի Schema հատկությանը վերագրել [Schema](/src/server_api/definitions/schema.md#schema) դասի նոր օբյեկտ ՝ կոնստրուկտորին փոխանցելով սխեմայի՝

  - name - ներքին անվանումը,
  - armenianCaption - հայերեն անվանումը` ANSI կոդավորմամբ,
  - englishCaption - անգլերեն անվանումը,
  - rowType - տվյալների աղբյուրի սյուները նկարագրող դասի տիպը,
  - paramType - տվյալների աղբյուրի պարամետրերը  նկարագրող դասի տիպը։

```c#
this.Schema = new Schema(this.Name, "Փաստաթղթի դաշտեր".ToArmenianANSI(), "Document's fields", typeof(DataRow), typeof(Param));
```

- Սխեմայում ավելացնել տվյալների աղբյուրի սյուների նկարագրությունները Schema դասի [AddColumn](/src/server_api/definitions/schema.md#addcolumn) մեթոդի միջոցով, որին փոխանցված է սյան՝
  
  - name - ներքին անվանումը,
  - source - տալ դատարկ արժեք,
  - armenianCaption - հայերեն անվանումը,
  - englishCaption - անգլերեն անվանումը,
  - columnType - համակարգային տիպը։
  
```c#
this.Schema.AddColumn(nameof(DataRow.Code), "", "Կոդ".ToArmenianANSI(), "Code", FieldTypeProvider.GetStringFieldType(25));
this.Schema.AddColumn(nameof(DataRow.Caption), "", "Անվանում".ToArmenianANSI(), "Name", FieldTypeProvider.GetStringFieldType(30));
```

- Սխեմայում ավելացնել պարամետրերի նկարագրությունները Schema դասի [AddParam](/src/server_api/definitions/schema.md#addparam) մեթոդի միջոցով, որին փոխանցված է պարամետրի՝

  - name - ներքին անվանումը,
  - description - հայերեն նկարագրությունը,
  - eDescription - անգլերեն անվանումը,
  - columnType - համակարգային տիպը։

```c#
this.Schema.AddParam(nameof(Param.DocType), "Փաստաթղթի տեսակ".ToArmenianANSI(), FieldTypeProvider.GetStringFieldType(8), eDescription: "Document's type");
```

### Տվյալների ձևավորում
Տվյալների աղբյուրը ըստ տվյալների բեռնման աղբյուրի լինում է 2 տեսակի՝ sql-based և array-based:
Տվյալների աղբյուրի տվյալների բեռնման տեսակը որոշվում է `IsSQLBased` boolean տիպի հատկության միջոցով, որի լռությամբ արժեքը true է։

- Եթե տվյալների աղբյուրը `array-based` է (տվյալների աղբյուրի տվյալները ստացվում են sql հարցման միջոցով), ապա գերբեռնել `IsSQLBased` հատկությունը՝ վերադարձնելով false արժեք և `FillData` մեթոդը՝ տվյալները ձևավորելու համար։

```c#
public override bool IsSQLBased
{
    get
    {
      return false;
    }
}

protected override async Task FillData(DataSourceArgs<Param> args, CancellationToken stoppingToken)
{
    var documentDescription = await DocumentHelper.DocumentDescription(this.dBService.Connection, args.Parameters.DocType);
    foreach (var field in documentDescription.Fields)
    {
        var row = new DataRow
        {
            Name = field.Key,
            Caption = field.Value.Caption
        };
    this.Rows.Add(row);
    }
}
```

FillData մեթոդում անհրաժեշտ է ստեղծել տվյալների աղբյուրը նկարագրող դասի օբյեկտներ, լրացնել սյուների արժեքները և ստեղծված տողերը ավելացնել տվյալների աղբյուրի `Rows` տողերի ցուցակին։
