---
layout: page
title: "(DataSource) Տվյալների աղբյուր ձեռնարկ"
tags: [Data, DS]
sublinks:
- { title: "Տվյալների աղբյուրի նկարագրման համար անհրաժեշտ ընդհանուր քայլեր", ref: տվյալների-աղբյուրի-նկարագրման-համար-անհրաժեշտ-ընդհանուր-քայլեր }
- { title: ".as ընդլայնմամբ ֆայլի սահմանում", ref: as-ընդլայնմամբ-ֆայլի-սահմանում }
- { title: "C# դասի սահմանում", ref: c-դասի-սահմանում }
- { title: "Օժանդակ դասերի սահմանում", ref: օժանդակ-դասերի-սահմանում }
- { title: "Կոնստրուկտորի ձևավորում", ref: կոնստրուկտորի-ձևավորում }
- { title: "Sql-based տվյալների աղբյուրի նկարագրման ձեռնարկ", ref: sql-based-տվյալների-աղբյուրի-նկարագրման-ձեռնարկ }
- { title: "Sql հարցման ձևավորում", ref: sql-հարցման-ձևավորում }
- { title: "Տողերի լրացուցիչ մշակում", ref: տողերի-լրացուցիչ-մշակում }
- { title: "Array-based տվյալների աղբյուրի նկարագրման ձեռնարկ", ref: array-based-տվյալների-աղբյուրի-նկարագրման-ձեռնարկ }
- { title: "Տվյալների ձևավորում", ref: տվյալների-ձևավորում }
---

[CodeGenDS]: ../CodeGen/CodeGen.md#տվյալների-աղբյուրի-նկարագրությունը-տեղափոխելու-համար-անհրաժեշտ-քայլեր

## Բովանդակություն

- [Ներածություն](#ներածություն)
- [Տվյալների աղբյուրի նկարագրման համար անհրաժեշտ ընդհանուր քայլեր](#տվյալների-աղբյուրի-նկարագրման-համար-անհրաժեշտ-ընդհանուր-քայլեր)
  - [.as ընդլայնմամբ ֆայլի սահմանում](#as-ընդլայնմամբ-ֆայլի-սահմանում)
  - [C# դասի սահմանում](#c-դասի-սահմանում)
    - [Օժանդակ դասերի սահմանում](#օժանդակ-դասերի-սահմանում)
    - [Կոնստրուկտորի ձևավորում](#կոնստրուկտորի-ձևավորում)
- [Sql-based տվյալների աղբյուրի նկարագրման ձեռնարկ](#sql-based-տվյալների-աղբյուրի-նկարագրման-ձեռնարկ)
  - [Sql հարցման ձևավորում](#sql-հարցման-ձևավորում)
  - [Տողերի լրացուցիչ մշակում](#տողերի-լրացուցիչ-մշակում)
- [Array-based տվյալների աղբյուրի նկարագրման ձեռնարկ](#array-based-տվյալների-աղբյուրի-նկարագրման-ձեռնարկ)
  - [Տվյալների ձևավորում](#տվյալների-ձևավորում)

## Ներածություն

Տվյալների պահոցից աղյուսակային տեսքով տվյալներ կարդալու և ցույց տալու համար նկարագրվում է տվյալների աղբյուր։

Տվյալների աղբյուրը ըստ տվյալների բեռնման աղբյուրի լինում է 2 տեսակի՝
- sql-based (տվյալները ստացվում են տվյալների բազայից՝ sql հարցման միջոցով),
- array-based (տվյալները ստացվում են այլ աղբյուրներից և ավելացվում տվյալների աղբյուրի տողերի զանգվածին):
  
Տեսակը որոշվում է տվյալների աղբյուրը նկարագրող դասի [IsSQLBased](ds.md#issqlbased) հատկության միջոցով, որի լռությամբ արժեքը **true** է։

8X-ում տվյալների աղբյուրի նկարագրության համար հարկավոր է ունենալ [DATA](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Defs/Data.html) նկարագրություն `.as` ֆայլում, սահմանել պարամետրերի և տողերի դասերը, սահմանել կառուցվածքի սխեման և իրականացնել հաշվարկները C# դասում (`.cs` ֆայլում)։  

Պարամետրերի և տողերի դասերի սահմանումը ինչպես նաև կառուցվածքի սխեմայի սահմանումը կարող է ավտոմատացվել [CodeGen][CodeGenDS] գործիքի միջոցով, եթե DATA նկարագրությունը սահմանված է 4X գործիքներով, և պարունակում է պարամետրերի և սյուների նկարագրությունները, ինչը պարտադիր չէ։

Արդյունքում կունենանք կա՛մ 2 ֆայլ, եթե C# դասը ստեղծվում է ձեռքով
- *definition*.as
- *definition*.cs

կա՛մ 4 ֆայլ, եթե մասնակի ավոտմատացվում է C# դասի ստեղծումը
- *definition*.as
- *definition*.cs
- *definition*.CodeGen.tt
- *definition*.CodeGen.cs

Ստորև նկարագրված է քայլերը երկու ֆայլի համար են։

## Տվյալների աղբյուրի նկարագրման համար անհրաժեշտ ընդհանուր քայլեր

## .as ընդլայնմամբ ֆայլի սահմանում
- Ստեղծել .as ընդլայնմամբ ֆայլ՝ ավելացնելով DATA տիպի նկարագրություն, որը պարունակում է տվյալների աղբյուրի՝
  - NAME - ներքին անվանումը,
  - CAPTION - հայերեն անվանումը ANSI կոդավորմամբ,
  - ECAPTION - անգլերեն անվանումը,
  - PROCESSINGMODE - կատարման ռեժիմը։
  ``` as4x
  DATA {
  NAME = TreeNode;
  CAPTION = "Ծառի հանգույցներ";
  ECAPTION = "Tree Nodes";
  PROCESSINGMODE = 1;
  }
  ```

## C# դասի սահմանում

### Օժանդակ դասերի սահմանում

*Ստորև նկարագրված դասերը ավտոմատ կարող են ձևավորվել [CodeGen][CodeGenDS] գործիքով։*

Ստորև նկարագրված դասերը որպես կանոն սահմանվում են Տվյալների աղբյուրի ստեղծվող դասի ներքին դասեր։

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

- Հայտատարել դաս, որը ունի տվյալների աղբյուրի ներքին անունը պարունակող `DataSource` ատրիբուտը և  ժառանգում է `DataSource<R, P>` դասը՝ որպես `R` փոխանցելով տվյալների աղբյուրի տողը նկարագրող դասը, իսկ որպես `P`՝ պարամետրերը նկարագրող դասը։ Եթե տվյալների աղբյուրը չի պարունակում պարամետրեր, ապա որպես `P` անհրաժեշտ է փոխանցել `NoParam` դասը։

  ```c#
  [DataSource("TreeNode")]
  public class TreeNode : DataSource<TreeNode.DataRow, TreeNode.Param>
  ```

### Կոնստրուկտորի ձևավորում

*Ստորև նկարագրված կոնստրուկտորը և սխեման կարող են ձևավորվել [CodeGen][CodeGenDS] գործիքով։*

- Ձևավորել տվյալների աղբյուրի կոնստրուկտորը՝ `IServiceProvider` տիպի պարտադիր պարամետրով, որը պիտի կանչի բազային `DataSource<R, P>` դասի կոնստրուկտորը և փոխանցի `IServiceProvider` տիպի պարամետրը: 
  Կոնստուկտորում անհրաժեշտ է [ինյեկցիա](../../project/injection.md) անել աշխատանքի համար անհրաժեշտ սերվիսները։

  ```c#
  private readonly IDBService dbService;
  
  public TreeNode(IDBService dbService, IServiceProvider serviceProvider) : base(serviceProvider)
  {
      this.dbService = dbService;
      //...
  }
  ```

- Կոնստրուկտորում ավելացնել տվյալների աղբյուրի սխեման, որը նախատեսված է տվյալների աղբյուրի սյուների ու պարամետրերի հատկությունները պահման համար։
  Դա անելու համար անհրաժեշտ է բազային դասի [Schema](ds.md#schema) հատկությանը վերագրել [Schema](schema.md) տիպի նոր օբյեկտ՝ կոնստրուկտորին փոխանցելով հետևյալ պարամետրերը՝
  - `name` - Սխեմայի ներքին անունը։
  - `armenianCaption` - Սխեմայի հայերեն անվանումը ANSI կոդավորմամբ։
  - `englishCaption` - Սխեմայի անգլերեն անվանումը։
  - `rowType` - Տվյալների աղբյուրի տողը նկարագրող դասի տիպը։
  - `paramType` - Տվյալների աղբյուրի պարամետրերը նկարագրող դասի տիպը:

  ```c#
  this.Schema = new Schema(this.Name, "Ծառի հանգույցներ".ToArmenianANSI(), "Tree nodes", typeof(DataRow), typeof(Param));
  ```

- Սխեմայում ավելացնել տվյալների աղբյուրի սյուների հատկությունները [Schema](schema.md) դասի [AddColumn](schema.md#addcolumn) մեթոդի միջոցով` փոխանցելով հետևյալ պարամետրերը՝
  - `name` - Սյան ներքին անունը, որի պետք է համընկնի սյուները նկարագրող դասում ավելացված համապատասխան սյան անվան հետ:
  - `source` - SQL-ից կարդացվող սյան անունը:
  - `armenianCaption` - Սյան հայերեն անվանումը ANSI կոդավորմամբ։
  - `englishCaption` - Սյան անգլերեն անվանումը։
  - `columnType` - Սյան համակարգային տիպը։

  ```c#
  this.Schema.AddColumn(nameof(DataRow.Code), "Code", "Կոդ".ToArmenianANSI(), "Code", FieldTypeProvider.GetStringFieldType(20));
  this.Schema.AddColumn(nameof(DataRow.Name), "Name", "Անվանում".ToArmenianANSI(), "Name", FieldTypeProvider.GetStringFieldType(50));
  ```

- Սխեմայում ավելացնել պարամետրերի հատկությունները [Schema](schema.md) դասի [AddParam](schema.md#addparam) մեթոդի միջոցով` փոխանցելով հետևյալ պարամետրերը՝
  - `name` - Պարամետրի ներքին անունը, որի պետք է համընկնի պարամետրերը նկարագրող դասում ավելացված համապատասխան պարամետրի անվան հետ:
  - `description` - Պարամետրի հայերեն անվանումը ANSI կոդավորմամբ։
  - `eDescription` - Պարամետրի անգլերեն անվանումը։
  - `columnType` - Պարամետրի համակարգային տիպը։
  
  ```c#
  this.Schema.AddParam(nameof(Param.TreeId), "Ծառի իդենտիֆիկատոր".ToArmenianANSI(), FieldTypeProvider.GetStringFieldType(4), eDescription:   "TreeId");
  this.Schema.AddParam(nameof(Param.NodeType), "Ծառի հանգույցներ".ToArmenianANSI(), FieldTypeProvider.GetStringFieldType(1), eDescription:   "Tree nodes");
  ```

## Sql-based տվյալների աղբյուրի նկարագրման ձեռնարկ

Ամբողջական կոդը դիտելու համար [տե՛ս](../examples/ds/sql_based_code.cs):

### Sql հարցման ձևավորում

Վերևում նշված [ընդհանուր քայլերից](#տվյալների-աղբյուրի-նկարագրման-համար-անհրաժեշտ-ընդհանուր-քայլեր) կատարումից հետո անհրաժեշտ է override անել [MakeSQLCommand](ds.md#makesqlcommand) մեթոդը։

[MakeSQLCommand](ds.md#makesqlcommand) մեթոդում անհրաժեշտ է ստեղծել և վերադարձնել [SqlCommand](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlcommand) դասի օբյեկտ՝ [IDBService](../services/IDBService.md) դասի [CreateCommand](../services/IDBService.md#createcommand) մեթոդի միջոցով։  
Այստեղ հարկավոր է ձևավորել sql հարցման տեքստը հաշվի առնելով նաև փոխանցված պարամետրերի արժեքները։

```c#
protected override Task<SqlCommand> MakeSQLCommand(DataSourceArgs<Param> args, CancellationToken stoppingToken)
{
    var cmd = this.dbService.CreateCommand();
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

### Տողերի լրացուցիչ մշակում

Sql հարցման կատարումից բացի հնարավոր է նաև լրացուցիչ մշակում կատարել ստացված արդյունքի։
Տե՛ս [Sql-based տվյալների աղբյուրի տողերի հավելյալ մշակում](ds_guide_row_processing.md):

## Array-based տվյալների աղբյուրի նկարագրման ձեռնարկ

Ամբողջական կոդը դիտելու համար [տե՛ս](../examples/ds/array_based_code.cs):

### Տվյալների ձևավորում

Վերևում նշված [ընդհանուր քայլերից](#տվյալների-աղբյուրի-նկարագրման-համար-անհրաժեշտ-ընդհանուր-քայլեր) կատարումից հետո անհրաժեշտ է override անել [IsSQLBased](ds.md#issqlbased) հատկությունը՝ վերադարձնելով false արժեք և [FillData](ds.md#filldata) մեթոդը՝ տվյալները ձևավորելու համար։  

[FillData](ds.md#filldata) մեթոդում անհրաժեշտ է ստեղծել տվյալների աղբյուրի սյուները նկարագրող դասի օբյեկտներ, լրացնել սյուների   արժեքները և ստեղծված տողերը ավելացնել տվյալների աղբյուրի [Rows](ds.md#rows) տողերի ցուցակին։

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
