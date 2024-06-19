# Ինչպես նկարագրել array-based տվյալների աղբյուր

Ամբողջական կոդը դիտելու համար [տես](array_based_definition_code.cs)։ 

- Անհրաժեշտ է հայտատարել դաս, որը ժառանգում է DataSource<R, P> դասը՝ որպես R փոխանցելով տվյալների աղբյուրի սյուները նկարագրող դասը, իսկ որպես P ` տվյալների աղբյուրի պարամետրերը նկարագրող դասը։

```c#
    public class ProcMode : DataSource<ProcMode.DataRow, ProcMode.Param>
```

Եթե տվյալների աղբյուրը չի պարունակում պարամետրեր, ապա որպես P անհրաժեշտ է փոխանցել NoParam դասը։
```c#
public class ApiClientInfo : DataSource<ApiClientInfo.DataRow, NoParam>
```

Տվյալների աղբյուրի սյուները նկարագրող դասը պետք է իրականացնի IExtendableRow ինտերֆեյսը։ Այդ դասում անհրաժեշտ է որպես հատկություններ ավելացնել տվյալների աղբյուրի սյուները։

```c#
        public class DataRow : IExtendableRow
        {
            public short CODE { get; set; }
            public string DESC { get; set; }
            public object Extend { get; set; }
        }
```

Տվյալների աղբյուրի պարամետրերը նկարագրող դասում նույնպես պետք է որպես հատկություններ պետք է ավելացնել պարամետրը։

```c#
        public class Param
        {
            public short SourceType { get; set; }
        }
```

- Հետո անհրաժեշտ է ձևավորել տվյալների աղբյուրի կոնստրուկտորը, որը իր հերթին պիտի կանչի base DataSource<R, P> դասի կոնստրուկտորը: Կոնստուկտորում անհրաժեշտ է աշխատանքի համար անհրաժեշտ service-ները։
Տվյալների աղբյուրի կոնստրուկտորում պարտադիր պետք է ունենալ IServiceProvider տիպի պարամետր, որն էլ պետք է փոխանցել base դասի կոնստրուկտորին։
```c#
       public ProcMode(IServiceProvider serviceProvider) : base(serviceProvider)
       {
              ․․․․․
       }
```
Կոնստրուկտորում անհրաժեշտ է ձևավորել տվյալների աղբյուրի սխեման, որը պարունակում է ամբողջական ինֆորմացիա տվյալների աղբյուրի սյուների ու պարամետրերի մասին։
Դա անելու համար անհրաժեշտ է base դասի Schema հատկությանը վերագրել [Schema](https://github.com/armsoft/as8x-docs/blob/main/src/server_api/definitions/schema.md#schema) դասի նոր օբյեկտ։

```c#
            this.Schema = new Schema(this.Name, ConstantsArmenian.ProcessingMode.ToArmenianANSICached(), ConstantsEnglish.ProcessingMode, typeof(DataRow), typeof(Param));
```

- Հետո անհրաժեշտ է սխեմայում ավելացնել տվյալների աղբյուրի սյուների նկարագրությունները Schema դասի [AddColumn](https://github.com/armsoft/as8x-docs/blob/main/src/server_api/definitions/schema.md#addcolumn) մեթոդի միջոցով։

```c#
            this.Schema.AddColumn(nameof(DataRow.CODE), "0", ConstantsArmenian.Code.ToArmenianANSICached(), ConstantsEnglish.Code, FieldTypeProvider.GetNumericFieldType(3), true);
            this.Schema.AddColumn(nameof(DataRow.DESC), "1", ConstantsArmenian.Descript.ToArmenianANSICached(), ConstantsEnglish.Descript, FieldTypeProvider.GetStringFieldType(DSConstantsLength.PrModeDesc), true
                        , showType: FieldTypeProvider.GetStringFieldType(DSConstantsLength.PrModeDescShow));
```

Եթե տվյալների աղբյուրը պարունակում է պարամետրեր, ապա սխեմայում անհրաժեշտ է ավելացնել նաև պարամետրերի նկարագրությունը Schema դասի [AddParam](https://github.com/armsoft/as8x-docs/blob/main/src/server_api/definitions/schema.md#addparam) մեթոդի միջոցով։

```c#
            this.Schema.AddParam(nameof(Param.SourceType), ConstantsArmenian.Type.ToArmenianANSICached(), FieldTypeProvider.GetNumericFieldType(2), eDescription: ConstantsEnglish.Type);
```

Տվյալների աղբյուրը ըստ տվյալների բեռնման աղբյուրի լինում է 2 տեսակի՝ sql-based և array-based:
Տվյալների աղբյուրի տվյալների բեռնման տեսակը որոշվում է `IsSQLBased` boolean տիպի հատկության միջոցով, որի լռությամբ արժեքը true է։

Եթե տվյալների աղբյուրը array-based է, ապա անհրաժեշտ է գերբեռնել IsSQLBased հատկությունը՝ վերադարձնելով false արժեք ու գերբեռնել `Task FillData(DataSourceArgs<P> args, CancellationToken stoppingToken)` մեթոդը` տվյալների աղբյուրի տվյալները ձևավորելու համար, որտեղ որպես P անհրաժեշտ է փոխանցել տվյալների աղբյուրի պարամետրերը նկարագրող դասը։

```c#
        public override bool IsSQLBased
        {
            get
            {
                return false;
            }
        }

        protected override Task FillData(DataSourceArgs<Param> args, CancellationToken stoppingToken)
        {
            this.Rows.AddRange(
            [
                new DataRow
                {
                    CODE = 0,
                    DESC = Resources.WithoutService
                },
                new DataRow
                {
                    CODE = 1,
                    DESC = args.Parameters.SourceType == 0 ? Resources.DSProcessingMode1 : Resources.DocTemplateProcessingMode1
                },
                new DataRow
                {
                    CODE = 2,
                    DESC = Resources.RunOnServer
                }
            ]
            );
            return Task.CompletedTask;
        }
```
FillData մեթոդում ստեղծում ենք տվյալների աղբյուրի տողերը,որոնք հետո ավելացնում ենք տվյալների աղբյուրի `Rows` հատկությանը։ Յուրաքանչյուր տող տվյալների աղբյուրի սյուները նկարագրող դասի տիպի է։
