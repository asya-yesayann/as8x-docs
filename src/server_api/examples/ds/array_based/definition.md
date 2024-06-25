# Array-based տվյալների աղբյուրի նկարագրման ձեռնարկ

Ամբողջական կոդը դիտելու համար [տես](definition_code.cs)։

# .as ընդլայնմամբ ֆայլի սահմանում
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
# .cs ընդլայնմամբ ֆայլի սահմանում
- Ստեղծել տվյալների աղբյուրի սյուները նկարագրող դաս՝ որպես հատկություններ ավելացնելով սյուները, որը պարտադիր պետք է իրականացնի `IExtendableRow` ինտերֆեյսը։
```c#
public class DataRow : IExtendableRow
{
    public string Name { get; set; }
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

## Կոնստրուկտորի ձևավորում

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
Դա անելու համար անհրաժեշտ է base դասի Schema հատկությանը վերագրել [Schema](https://github.com/armsoft/as8x-docs/blob/main/src/server_api/definitions/schema.md#schema) դասի նոր օբյեկտ ՝ կոնստրուկտորին փոխանցելով սխեմայի՝

  - name - ներքին անվանումը,
  - armenianCaption - հայերեն անվանումը` ANSI կոդավորմամբ,
  - englishCaption - անգլերեն անվանումը,
  - rowType - տվյալների աղբյուրի սյուները նկարագրող դասի տիպը,
  - paramType - տվյալների աղբյուրի պարամետրերը  նկարագրող դասի տիպը։

```c#
this.Schema = new Schema(this.Name, "Փաստաթղթի դաշտեր".ToArmenianANSI(), "Document's fields", typeof(DataRow), typeof(Param));
```

- Սխեմայում ավելացնել տվյալների աղբյուրի սյուների նկարագրությունները Schema դասի [AddColumn](https://github.com/armsoft/as8x-docs/blob/main/src/server_api/definitions/schema.md#addcolumn) մեթոդի միջոցով, որին փոխանցված է սյան՝
  
  - name - ներքին անվանումը,
  - source - տալ դատարկ արժեք,
  - armenianCaption - հայերեն անվանումը,
  - englishCaption - անգլերեն անվանումը,
  - columnType - համակարգային տիպը։
  
```c#
this.Schema.AddColumn(nameof(DataRow.Name), "", "Կոդ".ToArmenianANSI(), "Code", FieldTypeProvider.GetStringFieldType(25));
this.Schema.AddColumn(nameof(DataRow.Caption), "", "Անվանում".ToArmenianANSI(), "Name", FieldTypeProvider.GetStringFieldType(30));
```

- Սխեմայում ավելացնել պարամետրերի նկարագրությունները Schema դասի [AddParam](https://github.com/armsoft/as8x-docs/blob/main/src/server_api/definitions/schema.md#addparam) մեթոդի միջոցով, որին փոխանցված է պարամետրի՝

  - name - ներքին անվանումը,
  - description - հայերեն նկարագրությունը,
  - eDescription - անգլերեն անվանումը,
  - columnType - համակարգային տիպը։

```c#
this.Schema.AddParam(nameof(Param.DocType), "Փաստաթղթի տեսակ".ToArmenianANSI(), FieldTypeProvider.GetStringFieldType(8), eDescription: "Document's type");
```
## Տվյալների ձևավորում
Տվյալների աղբյուրը ըստ տվյալների բեռնման աղբյուրի լինում է 2 տեսակի՝ sql-based և array-based:
Տվյալների աղբյուրի տվյալների բեռնման տեսակը որոշվում է `IsSQLBased` boolean տիպի հատկության միջոցով, որի լռությամբ արժեքը true է։

- Եթե տվյալների աղբյուրը `array-based` է (տվյալների աղբյուրի տվյալները ստացվում են sql հարցման միջոցով), ապա տվյալները ձևավորելու համար անհրաժեշտ է գերբեռնել `FillData` մեթոդը։
```c#
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
