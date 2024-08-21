---
layout: page
title: "(DataSource) Տվյալների աղբյուր ձեռնարկ"
tags: [Data, DS]
---

## Բովանդակություն
- [Բովանդակություն](#բովանդակություն)
- [ներածություն](#ներածություն)
- [Տվյալների աղբյուրի նկարագրման համար անհրաժեշտ ընդհանուր քայլեր](#տվյալների-աղբյուրի-նկարագրման-համար-անհրաժեշտ-ընդհանուր-քայլեր)
- [.as ընդլայնմամբ ֆայլի սահմանում](#as-ընդլայնմամբ-ֆայլի-սահմանում)
- [.cs ընդլայնմամբ ֆայլի սահմանում](#cs-ընդլայնմամբ-ֆայլի-սահմանում)
  - [Օժանդակ դասերի սահմանում](#օժանդակ-դասերի-սահմանում)
  - [Կոնստրուկտորի ձևավորում](#կոնստրուկտորի-ձևավորում)
- [Sql-based տվյալների աղբյուրի նկարագրման ձեռնարկ](#sql-based-տվյալների-աղբյուրի-նկարագրման-ձեռնարկ)
  - [Sql հարցման ձևավորում](#sql-հարցման-ձևավորում)
- [Array-based տվյալների աղբյուրի նկարագրման ձեռնարկ](#array-based-տվյալների-աղբյուրի-նկարագրման-ձեռնարկ)
  - [Տվյալների ձևավորում](#տվյալների-ձևավորում)

## ներածություն

Տվյալների պահոցից աղյուսակային տեսքով տվյալներ կարդալու և ցույց տալու համար նկարագրվում է տվյալների աղբյուր։

Տվյալների աղբյուրը ըստ տվյալների բեռնման աղբյուրի լինում է 2 տեսակի՝
- sql-based (տվյալները ստացվում են տվյալների բազայից՝ sql հարցման միջոցով),
- array-based (տվյալները ստացվում են այլ աղբյուրներից և ավելացվում տվյալների աղբյուրի տողերի զանգվածին):
  
Տեսակը որոշվում է տվյալների աղբյուրը նկարագրող դասի [IsSQLBased](ds.md#issqlbased) boolean տիպի հատկության միջոցով, որի լռությամբ արժեքը **true** է։

8X-ում տվյալների աղբյուրի նկարագրության համար հարկավոր է ունենալ 
- .as ընդլայնմամբ ֆայլ սկրիպտերում, որը պարունակում է մետատվյալներ տվյալների աղբյուրի մասին,
- .cs ընդլայնմամբ ֆայլ, որը պարունակում է սերվերում աշխատող տրամաբանությունը։ 

## Տվյալների աղբյուրի նկարագրման համար անհրաժեշտ ընդհանուր քայլեր

## .as ընդլայնմամբ ֆայլի սահմանում

```c#
DATA {
NAME = TreeNode;
CAPTION = "Ծառի հանգույցներ";
ECAPTION = "Tree Nodes";
PROCESSINGMODE = 1;
}
```

- Ստեղծել .as ընդլայնմամբ ֆայլ՝ ավելացնելով DATA տիպի նկարագրություն, որը պարունակում է 
  - NAME - Տվյալների աղբյուրի ներքին անունը։
  - CAPTION - Տվյալների աղբյուրի հայերեն անվանումը `ANSI` կոդավորմամբ։
  - ECAPTION - Տվյալների աղբյուրի անգլերեն անվանումը։
  - PROCESSINGMODE - Տվյալների աղբյուրի կատարման ռեժիմը։
- Ստեղծված ֆայլը ներմուծել տվյալների բազա `Syscon` գործիքով։

## .cs ընդլայնմամբ ֆայլի սահմանում

4X-ում նկարագրված տվյալների աղբյուրը 8X տեղափոխելիս այս գլխում նկարագրված քայլերը (տվյալների աղբյուրը, պարամետրերը, սյուները նկարագրող դասերի ստեղծում ու կոնստրուկտերի ձևավորում, լրացում) կարելի է կատարել ավտոմատ [CodeGen](/src/server_api/CodeGen/CodeGen.md#ներածություն) գործիքի միջոցով։

Տե՛ս նաև

* [Ի՞նչ է CodeGen-ը](/src/server_api/CodeGen/CodeGen.md#ներածություն):
* [4X-ում նկարագրված տվյալների աղբյուրի 8X տեղափոխման մասնակի ավտոմատացում CodeGen գործիքի միջոցով](/src/server_api/CodeGen/CodeGen.md#տվյալների-աղբյուրի-նկարագրությունը-տեղափոխելու-համար-անհրաժեշտ-քայլեր):
* [DSParser դաս](/src/server_api/CodeGen/DSParser.md):

Իսկ եթե տվյալների աղբյուրը նկարագրվելու է միայն 8X-ում, իսկ 4X-ում լինելու են միայն մետատվյալները, ապա անհրաժեշտ է կատարել այս գլխում նկարագրված քայլերը։ 


### Օժանդակ դասերի սահմանում

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

- Ձևավորել տվյալների աղբյուրի կոնստրուկտորը՝ IServiceProvider տիպի պարտադիր պարամետրով, որը պիտի կանչի base DataSource<R, P> դասի կոնստրուկտորը և փոխանցի IServiceProvider տիպի պարամետրը: Կոնստուկտորում անհրաժեշտ է [ինյեկցիա](/src/project/injection.md) անել աշխատանքի համար անհրաժեշտ service-ները։

```c#
private readonly IDBService dBService;

 public TreeNode(IDBService dbService, TreeElementService treeElementService, IServiceProvider serviceProvider) : base(serviceProvider)
{
    this.dBService = dbService;
    this.treeElementService = treeElementService;
    ...
}
```

- Կոնստրուկտորում ավելացնել տվյալների աղբյուրի սխեման, որը նախատեսված է տվյալների աղբյուրի սյուների ու պարամետրերի հատկությունները պահման համար։
Դա անելու համար անհրաժեշտ է base դասի [Schema](ds.md#schema) հատկությանը վերագրել [Schema](schema.md#schema) դասի նոր օբյեկտ ՝ կոնստրուկտորին փոխանցելով հետևյալ պարամետրերը՝

  - `name` - Սխեմայի ներքին անունը։
  - `armenianCaption` - Սխեմայի հայերեն անվանումը։
  - `englishCaption` - Սխեմայի անգլերեն անվանումը։
  - `rowType` - Տվյալների աղբյուրի սյուները նկարագրող դասի տիպը։
  - `paramType` - Տվյալների աղբյուրի պարամետրերը նկարագրող դասի տիպը:

```c#
this.Schema = new Schema(this.Name, "Ծառի հանգույցներ".ToArmenianANSI(), "Tree nodes", typeof(DataRow), typeof(Param));
```

- Սխեմայում ավելացնել տվյալների աղբյուրի սյուների հատկությունները [Schema](schema.md#schema) դասի [AddColumn](schema.md#addcolumn) մեթոդի միջոցով` փոխանցելով հետևյալ պարամետրերը՝
  
  - `name` - Սյան ներքին անունը, որի պետք է համընկնի սյուները նկարագրող դասում ավելացված համապատասխան սյան անվան հետ:
  - `source` - SQL-ից կարդացվող սյան անունը:
  - `armenianCaption` - Սյան հայերեն անվանումը։
  - `englishCaption` - Սյան անգլերեն անվանումը։
  - `columnType` - Սյան համակարգային տիպը։
  
```c#
this.Schema.AddColumn(nameof(DataRow.Code), "Code", "Կոդ".ToArmenianANSI(), "Code", FieldTypeProvider.GetStringFieldType(20));
this.Schema.AddColumn(nameof(DataRow.Name), "Name", "Անվանում".ToArmenianANSI(), "Name", FieldTypeProvider.GetStringFieldType(50));
```

- Սխեմայում ավելացնել պարամետրերի հատկությունները [Schema](schema.md#schema) դասի [AddParam](schema.md#addparam) մեթոդի միջոցով` փոխանցելով հետևյալ պարամետրերը՝

  - `name` - Պարամետրի ներքին անունը, որի պետք է համընկնի պարամետրերը նկարագրող դասում ավելացված համապատասխան պարամետրի անվան հետ:
  - `description` - Պարամետրի հայերեն անվանումը։
  - `eDescription` - Պարամետրի անգլերեն անվանումը։
  - `columnType` - Պարամետրի համակարգային տիպը։

```c#
this.Schema.AddParam(nameof(Param.TreeId), "Ծառի իդենտիֆիկատոր".ToArmenianANSI(), FieldTypeProvider.GetStringFieldType(4), eDescription: "TreeId");
this.Schema.AddParam(nameof(Param.NodeType), "Ծառի հանգույցներ".ToArmenianANSI(), FieldTypeProvider.GetStringFieldType(1), eDescription: "Tree nodes");
```

## Sql-based տվյալների աղբյուրի նկարագրման ձեռնարկ

Ամբողջական կոդը դիտելու համար [տե՛ս](/src/server_api/examples/ds/sql_based_code.cs)։

### Sql հարցման ձևավորում
Վերևում նշված [ընդհանուր քայլերից](#տվյալների-աղբյուրի-նկարագրման-համար-անհրաժեշտ-ընդհանուր-քայլեր) կատարումից հետո անհրաժեշտ է override անել [MakeSQLCommand](ds.md#makesqlcommand) մեթոդը՝ DataSourceArgs<P> տիպի args պարամետրին որպես P փոխանցելով տվյալների աղբյուրի պարամետրերը նկարագրող դասը։

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

[MakeSQLCommand](ds.md#makesqlcommand) մեթոդում անհրաժեշտ է ստեղծել [SqlCommand](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlcommand?view=sqlclient-dotnet-standard-5.2) դասի օբյեկտ՝ IDBService դասի [Connection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlconnection?view=sqlclient-dotnet-standard-5.2) հատկության [CreateCommand](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlconnection.createcommand?view=sqlclient-dotnet-standard-5.2#microsoft-data-sqlclient-sqlconnection-createcommand) մեթոդի միջոցով, որը ընթացիկ sql միացման համար ստեղծում է [SqlCommand](https://learn.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlcommand?view=netframework-4.8.1)` sql հարցումը ձևավորվելու համար։

Ստեղծված [SqlCommand](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlcommand?view=sqlclient-dotnet-standard-5.2) դասի օբյեկտի [CommandText](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlcommand.commandtext?view=sqlclient-dotnet-standard-5.2) հատկությանը հարկավոր է փոխանցել հարցման տեքստը։
[MakeSQLCommand](ds.md#makesqlcommand) մեթոդի վերջում անհրաժեշտ է վերադարձնել ձևավորված sql հարցումը։

## Array-based տվյալների աղբյուրի նկարագրման ձեռնարկ

Ամբողջական կոդը դիտելու համար [տե՛ս](/src/server_api/examples/ds/array_based_code.cs)։

### Տվյալների ձևավորում
- Վերևում նշված [ընդհանուր քայլերից](#տվյալների-աղբյուրի-նկարագրման-համար-անհրաժեշտ-ընդհանուր-քայլեր) կատարումից հետո անհրաժեշտ է override անել [IsSQLBased](ds.md#issqlbased) հատկությունը՝ վերադարձնելով false արժեք և `FillData` մեթոդը՝ տվյալները ձևավորելու համար։

```c#
public override bool IsSQLBased => false;

protected override async Task FillData(DataSourceArgs<Param> args, CancellationToken stoppingToken)
{
   string treeId = args.Parameters.TreeId;
   if (!string.IsNullOrWhiteSpace(treeId))
   {
      var treeNodes = await this.treeElementService.GetTreeElements(treeId, args.Parameters.NodeType);
      foreach (var (code, treeNode) in treeNodes)
      {
         var row = new DataRow
         {
            Code = treeNode.Key,
            Name = treeNode.Comment
         };
         this.Rows.Add(row);
     }
  }
}
```

FillData մեթոդում անհրաժեշտ է ստեղծել տվյալների աղբյուրի սյուները նկարագրող դասի օբյեկտներ, լրացնել սյուների արժեքները և ստեղծված տողերը ավելացնել տվյալների աղբյուրի [Rows](ds.md#rows) տողերի ցուցակին։
