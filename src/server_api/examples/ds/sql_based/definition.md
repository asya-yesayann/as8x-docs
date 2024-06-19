# Ինչպես նկարագրել sql-based տվյալների աղբյուր

Ամբողջական կոդը դիտելու համար [տես](definition_code.cs)։

- Անհրաժեշտ է հայտատարել դաս, որը ժառանգում է DataSource<R, P> դասը՝ որպես R փոխանցելով տվյալների աղբյուրի սյուները նկարագրող դասը, իսկ որպես P ` տվյալների աղբյուրի պարամետրերը նկարագրող դասը։

```c#
    public class DocCap : DataSource<DocCap.DataRow, DocCap.Param>
```

Եթե տվյալների աղբյուրը չի պարունակում պարամետրեր, ապա որպես P անհրաժեշտ է փոխանցել NoParam դասը։
```c#
    public class DocCap : DataSource<DocCap.DataRow, NoParam>
```

- Տվյալների աղբյուրի սյուները նկարագրող դասը պարտադիր պետք է իմպլեմենտացնի `IExtendableRow` ինտերֆեյսը։ Այդ դասում անհրաժեշտ է որպես հատկություններ ավելացնել տվյալների աղբյուրի սյուները։
```c#
        public class DataRow : IExtendableRow
        {
            public string DocType { get; set; }
            public string fCAPTION { get; set; }
            public object Extend { get; set; }
        }
```

- Տվյալների աղբյուրի պարամետրերը նկարագրող դասում պետք է որպես հատկություններ ավելացնել պարամետրերը։
```c#
        public class Param
        {
            public string DocType { get; set; }
        }
```

- Հետո անհրաժեշտ է ձևավորել տվյալների աղբյուրի կոնստրուկտորը, որը իր հերթին պիտի կանչի base DataSource<R, P> դասի կոնստրուկտորը: Կոնստուկտորում անհրաժեշտ է inject անել բոլոր այն service-ները, որոնք հետագայում հարկավոր են լինելու աշխատանքի համար։
Տվյալների աղբյուրի կոնստրուկտորում պարտադիր պետք է ունենալ IServiceProvider տիպի պարամետր, որն էլ պետք է փոխանցել base դասի կոնստրուկտորին։
```c#
        public readonly IDBService dbService;
        public DocCap(IDBService dbService, IServiceProvider serviceProvider) : base(serviceProvider)
        {
           this.dbService = dbService;
       }
```
Կոնստրուկտորում անհրաժեշտ է ձևավորել տվյալների աղբյուրի սխեման, որը պարունակում է ամբողջական ինֆորմացիա տվյալների աղբյուրի սյուների ու պարամետրերի մասին։
Դա անելու համար անհրաժեշտ է base դասի Schema հատկությանը վերագրել [Schema](https://github.com/armsoft/as8x-docs/blob/main/src/server_api/definitions/schema.md#schema) դասի նոր օբյեկտ։

```c#
this.Schema = new Schema(this.Name, ConstantsArmenian.ParamLog.ToArmenianANSICached(), ConstantsEnglish.ParamLog, typeof(DataRow), typeof(Param));
```

- Հետո անհրաժեշտ է սխեմայում ավելացնել տվյալների աղբյուրի սյուների նկարագրությունները Schema դասի [AddColumn](https://github.com/armsoft/as8x-docs/blob/main/src/server_api/definitions/schema.md#addcolumn) մեթոդի միջոցով։
```c#
            this.Schema.AddColumn(nameof(DataRow.DocType), "DocType", ConstantsArmenian.DocType.ToArmenianANSICached(), ConstantsEnglish.DocType, FieldTypeProvider.GetStringFieldType(SYSDEF.DocNameLength));

            this.Schema.AddColumn(nameof(DataRow.fCAPTION), "DocTypeName", ConstantsArmenian.Name.ToArmenianANSICached(), ConstantsEnglish.Name, FieldTypeProvider.GetStringFieldType(SYSDEF.fCAPTIONLength));
```

Եթե տվյալների աղբյուրը պարունակում է պարամետրեր, ապա սխեմայում անհրաժեշտ է ավելացնել նաև պարամետրերի նկարագրությունը Schema դասի [AddParam](https://github.com/armsoft/as8x-docs/blob/main/src/server_api/definitions/schema.md#addparam) մեթոդի միջոցով։

```c#
            this.Schema.AddParam(nameof(Param.DocType), ConstantsArmenian.DocType.ToArmenianANSICached(), FieldTypeProvider.GetStringFieldType(DSConstantsLength.DocCapDocType), eDescription: ConstantsEnglish.DocType);
```

Տվյալների աղբյուրը ըստ տվյալների բեռնման աղբյուրի լինում է 2 տեսակի՝ sql-based և array-based:
Տվյալների աղբյուրի տվյալների բեռնման տեսակը որոշվում է `IsSQLBased` boolean տիպի հատկության միջոցով, որի լռությամբ արժեքը true է։

Եթե տվյալների աղբյուրը `sql-based` է(տվյալների աղբյուրի տվյալները ստացվում են sql հարցման միջոցով), ապա sql հարցումը ձևավորելու համար անհրաժեշտ է override անել `Task<SqlCommand> MakeSQLCommand(DataSourceArgs<P> args, CancellationToken stoppingToken)` մեթոդը՝ որպես P փոխանցելով տվյալների աղբյուրի պարամետրերը նկարագրող դասը։

```c#
        protected override Task<SqlCommand> MakeSQLCommand(DataSourceArgs<Param> args, CancellationToken stoppingToken)
        {
            using var cmd = this.dbService.Connection.CreateCommand();
            cmd.CommandText = $"""
                               SELECT fNAME AS DocType
                                       , {(LanguageService.IsArmenian ? "fCAPTION" : "fECAPTION")} AS DocTypeName
                               FROM SYSDEF
                               WHERE fSYSTYPE = 0
                               """;
            if (!string.IsNullOrWhiteSpace(args.Parameters.DocType))
            {
                cmd.CommandText += " AND fNAME IN (SELECT item FROM asf_Split_to_table(@DocType, default))";
                cmd.Parameters.Add("@DocType", SqlDbType.VarChar).Value = args.Parameters.DocType;
            }
            return Task.FromResult(cmd);
        }
```
MakeSQLCommand-ում անհրաժեշտ է ունենալ [SqlCommand](https://learn.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlcommand?view=netframework-4.8.1) դասի օբյեկտ, որի մեջ կլրացվի հարցումը։

Դա կարելի է անել IDBService դասի Connection հատկության [CreateCommand](https://learn.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlconnection.createcommand?view=netframework-4.8.1&viewFallbackFrom=dotnet-plat-ext-8.0) մեթոդի միջոցով, որը ընթացիկ sql connection-ի համար բացում է [SqlCommand](https://learn.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlcommand?view=netframework-4.8.1)sql հարցումը ձևավորվելու է համար։

Հետո ստեղծված SqlCommand դասի օբյեկտի CommandText հատկությանը հարկավոր է փոխանցել հարցման տեքստը։
Եթե տվյալների աղբյուրը պարունակում է պարամետրեր, ապա sql հարցման մեջ չի թույլատրվում միանգամից ավելացնել այդ պարամետրերը։
Այդ պարամետրերը ավելացնելու համար անհրաժեշտ է @-ով ավելացնել պարամետրի անունը, հետո ստեղծված SqlCommand դասի օբյեկտի Parameters հատկությանը [Add](https://learn.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlparametercollection.add?view=netframework-4.8.1#system-data-sqlclient-sqlparametercollection-add(system-string-system-data-sqldbtype)) մեթոդը կանչել, որտեղ պետք է փոխանցել պարամետրի անունը ու sql-ական տվյալի տիպը։

```c#
            if (!string.IsNullOrWhiteSpace(args.Parameters.DocType))
            {
                cmd.CommandText += " AND fNAME IN (SELECT item FROM asf_Split_to_table(@DocType, default))";
                cmd.Parameters.Add("@DocType", SqlDbType.VarChar).Value = args.Parameters.DocType;
            }
```

Ու MakeSQLCommand մեթոդի վերջում անհրաժեշտ է վերադարձնել ձևավորված sql հարցումը։
