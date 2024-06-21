# sql-based տվյալների աղբյուրի նկարագրման ձեռնարկ

Ամբողջական կոդը դիտելու համար [տես](definition_code.cs)։

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

- Հայտատարել դաս, որը ժառանգում է DataSource<R, P> դասը՝ որպես R փոխանցելով տվյալների աղբյուրի սյուները նկարագրող դասը, իսկ որպես P ` տվյալների աղբյուրի պարամետրերը նկարագրող դասը։ Եթե տվյալների աղբյուրը չի պարունակում պարամետրեր, ապա որպես P անհրաժեշտ է փոխանցել NoParam դասը։

```c#
public class TreeNode : DataSource<TreeNode.DataRow, TreeNode.Param>
```

## Կոնստրուկտորի ձևավորում

- Ձևավորել տվյալների աղբյուրի կոնստրուկտորը՝ IServiceProvider տիպի պարտադիր պարամետրով, որը պիտի կանչի base DataSource<R, P> դասի կոնստրուկտորը և փոխանցի IServiceProvider տիպի պարամետրը: Կոնստուկտորում անհրաժեշտ է [ինյեկցիա](https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection) անել աշխատանքի համար անհրաժեշտ service-ները։

```c#
private readonly IDBService dBService;

public TreeNode(IDBService dbService, IServiceProvider serviceProvider) : base(serviceProvider)
{
    this.dBService = dbService;
    ...
}
```
- Կոնստրուկտորում ձևավորել տվյալների աղբյուրի սխեման, որը պարունակում է ամբողջական ինֆորմացիա տվյալների աղբյուրի սյուների ու պարամետրերի մասին։
Դա անելու համար անհրաժեշտ է base դասի Schema հատկությանը վերագրել [Schema](https://github.com/armsoft/as8x-docs/blob/main/src/server_api/definitions/schema.md#schema) դասի նոր օբյեկտ։

```c#
this.Schema = new Schema(this.Name, "Ծառի հանգույցներ".ToArmenianANSICached(), "Tree nodes", typeof(DataRow), typeof(Param));
```

- Սխեմայում ավելացնել տվյալների աղբյուրի սյուների նկարագրությունները Schema դասի [AddColumn](https://github.com/armsoft/as8x-docs/blob/main/src/server_api/definitions/schema.md#addcolumn) մեթոդի միջոցով։
```c#
this.Schema.AddColumn(nameof(DataRow.Code), "Code", "Կոդ".ToArmenianANSICached(), "Code", FieldTypeProvider.GetStringFieldType(20));
this.Schema.AddColumn(nameof(DataRow.Name), "Name", "Անվանում".ToArmenianANSICached(), "Name", FieldTypeProvider.GetStringFieldType(50));
```

- Սխեմայում ավելացնել պարամետրերի նկարագրությունները Schema դասի [AddParam](https://github.com/armsoft/as8x-docs/blob/main/src/server_api/definitions/schema.md#addparam) մեթոդի միջոցով։

```c#
this.Schema.AddParam(nameof(Param.TreeId), "Ծառի իդենտիֆիկատոր".ToArmenianANSICached(), FieldTypeProvider.GetStringFieldType(4), eDescription: "TreeId");
this.Schema.AddParam(nameof(Param.NodeType), "Ծառի հանգույցներ".ToArmenianANSICached(), FieldTypeProvider.GetStringFieldType(1), eDescription: "Tree nodes");
```
## sql հարցման ձևավորում
Տվյալների աղբյուրը ըստ տվյալների բեռնման աղբյուրի լինում է 2 տեսակի՝ sql-based և array-based:
Տվյալների աղբյուրի տվյալների բեռնման տեսակը որոշվում է `IsSQLBased` boolean տիպի հատկության միջոցով, որի լռությամբ արժեքը true է։

- Եթե տվյալների աղբյուրը `sql-based` է (տվյալների աղբյուրի տվյալները ստացվում են sql հարցման միջոցով), ապա sql հարցումը ձևավորելու համար անհրաժեշտ է գերբեռնել `MakeSQLCommand(DataSourceArgs<P> args, CancellationToken stoppingToken)` մեթոդը՝ որպես P փոխանցելով տվյալների աղբյուրի պարամետրերը նկարագրող դասը։

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

Ստեղծված SqlCommand դասի օբյեկտի [SqlCommand](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlcommand?view=sqlclient-dotnet-standard-5.2) հատկությանը հարկավոր է փոխանցել հարցման տեքստը։
Ու MakeSQLCommand մեթոդի վերջում անհրաժեշտ է վերադարձնել ձևավորված sql հարցումը։
