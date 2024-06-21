# sql-based տվյալների աղբյուրի նկարագրման ձեռնարկ

Ամբողջական կոդը դիտելու համար [տես](definition_code.cs)։

- Անհրաժեշտ է հայտատարել դաս, որը ժառանգում է DataSource<R, P> դասը՝ որպես R փոխանցելով տվյալների աղբյուրի սյուները նկարագրող դասը, իսկ որպես P ` տվյալների աղբյուրի պարամետրերը նկարագրող դասը։

```c#
public class TreeNode : DataSource<TreeNode.DataRow, TreeNode.Param>
```

Եթե տվյալների աղբյուրը չի պարունակում պարամետրեր, ապա որպես P անհրաժեշտ է փոխանցել NoParam դասը։

- Տվյալների աղբյուրի սյուները նկարագրող դասը պարտադիր պետք է իրականացնի `IExtendableRow` ինտերֆեյսը։ Այդ դասում անհրաժեշտ է որպես հատկություններ ավելացնել տվյալների աղբյուրի սյուները։
```c#
 public class DataRow : IExtendableRow
{
    public string Code { get; set; }
    public string Name { get; set; }
    public object Extend { get; set; }
}
```

- Տվյալների աղբյուրի պարամետրերը նկարագրող դասում պետք է որպես հատկություններ ավելացնել պարամետրերը։
```c#
public class Param
{
    public string TreeId { get; set; }
    public string NodeType { get; set; }
}
```
## Կոնստրուկտորի ձևավորում

- Հետո անհրաժեշտ է ձևավորել տվյալների աղբյուրի կոնստրուկտորը, որը իր հերթին պիտի կանչի base DataSource<R, P> դասի կոնստրուկտորը: Կոնստուկտորում անհրաժեշտ է inject անել բոլոր այն service-ները, որոնք հետագայում հարկավոր են լինելու աշխատանքի համար։
Տվյալների աղբյուրի կոնստրուկտորում պարտադիր պետք է ունենալ IServiceProvider տիպի պարամետր, որն էլ պետք է փոխանցել base դասի կոնստրուկտորին։
```c#
private readonly IDBService dBService;

public TreeNode(IDBService dbService, IServiceProvider serviceProvider) : base(serviceProvider)
{
    this.dBService = dbService;
    ...
}
```
Կոնստրուկտորում անհրաժեշտ է ձևավորել տվյալների աղբյուրի սխեման, որը պարունակում է ամբողջական ինֆորմացիա տվյալների աղբյուրի սյուների ու պարամետրերի մասին։
Դա անելու համար անհրաժեշտ է base դասի Schema հատկությանը վերագրել [Schema](https://github.com/armsoft/as8x-docs/blob/main/src/server_api/definitions/schema.md#schema) դասի նոր օբյեկտ։

```c#
this.Schema = new Schema(this.Name, "Ծառի հանգույցներ".ToArmenianANSICached(), "Tree nodes", typeof(DataRow), typeof(Param));
```

- Հետո անհրաժեշտ է սխեմայում ավելացնել տվյալների աղբյուրի սյուների նկարագրությունները Schema դասի [AddColumn](https://github.com/armsoft/as8x-docs/blob/main/src/server_api/definitions/schema.md#addcolumn) մեթոդի միջոցով։
```c#
this.Schema.AddColumn(nameof(DataRow.Code), "Code", "Կոդ".ToArmenianANSICached(), "Code", FieldTypeProvider.GetStringFieldType(20));
this.Schema.AddColumn(nameof(DataRow.Name), "Name", "Անվանում".ToArmenianANSICached(), "Name", FieldTypeProvider.GetStringFieldType(50));
```

Եթե տվյալների աղբյուրը պարունակում է պարամետրեր, ապա սխեմայում անհրաժեշտ է ավելացնել նաև պարամետրերի նկարագրությունը Schema դասի [AddParam](https://github.com/armsoft/as8x-docs/blob/main/src/server_api/definitions/schema.md#addparam) մեթոդի միջոցով։

```c#
this.Schema.AddParam(nameof(Param.TreeId), "Ծառի իդենտիֆիկատոր".ToArmenianANSICached(), FieldTypeProvider.GetStringFieldType(4), eDescription: "TreeId");
this.Schema.AddParam(nameof(Param.NodeType), "Ծառի հանգույցներ".ToArmenianANSICached(), FieldTypeProvider.GetStringFieldType(1), eDescription: "Tree nodes");
```

Տվյալների աղբյուրը ըստ տվյալների բեռնման աղբյուրի լինում է 2 տեսակի՝ sql-based և array-based:
Տվյալների աղբյուրի տվյալների բեռնման տեսակը որոշվում է `IsSQLBased` boolean տիպի հատկության միջոցով, որի լռությամբ արժեքը true է։

Եթե տվյալների աղբյուրը `sql-based` է(տվյալների աղբյուրի տվյալները ստացվում են sql հարցման միջոցով), ապա sql հարցումը ձևավորելու համար անհրաժեշտ է գերբեռնել `MakeSQLCommand(DataSourceArgs<P> args, CancellationToken stoppingToken)` մեթոդը՝ որպես P փոխանցելով տվյալների աղբյուրի պարամետրերը նկարագրող դասը։

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
MakeSQLCommand-ում անհրաժեշտ է ունենալ [SqlCommand](https://learn.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlcommand?view=netframework-4.8.1) դասի օբյեկտ, որի մեջ կլրացվի հարցումը։

Դա կարելի է անել IDBService դասի Connection հատկության [CreateCommand](https://learn.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlconnection.createcommand?view=netframework-4.8.1&viewFallbackFrom=dotnet-plat-ext-8.0) մեթոդի միջոցով, որը ընթացիկ sql connection-ի համար բացում է [SqlCommand](https://learn.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlcommand?view=netframework-4.8.1)sql հարցումը ձևավորվելու է համար։

Հետո ստեղծված SqlCommand դասի օբյեկտի CommandText հատկությանը հարկավոր է փոխանցել հարցման տեքստը։
Եթե տվյալների աղբյուրը պարունակում է պարամետրեր, ապա sql հարցման մեջ չի թույլատրվում միանգամից ավելացնել այդ պարամետրերը։
Այդ պարամետրերը ավելացնելու համար անհրաժեշտ է @-ով ավելացնել պարամետրի անունը, հետո ստեղծված SqlCommand դասի օբյեկտի Parameters հատկությանը [Add](https://learn.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlparametercollection.add?view=netframework-4.8.1#system-data-sqlclient-sqlparametercollection-add(system-string-system-data-sqldbtype)) մեթոդը կանչել, որտեղ պետք է փոխանցել պարամետրի անունը ու sql-ական տվյալի տիպը։

```c#
cmd.Parameters.Add("@TreeId", SqlDbType.Char, 8).Value = args.Parameters.TreeId;
if (!string.IsNullOrWhiteSpace(args.Parameters.NodeType))
{
   cmd.CommandText += " AND fLEAF = @NodeType";
   cmd.Parameters.Add("@NodeType", SqlDbType.Char, 1).Value = args.Parameters.NodeType;
}
```

Ու MakeSQLCommand մեթոդի վերջում անհրաժեշտ է վերադարձնել ձևավորված sql հարցումը։
