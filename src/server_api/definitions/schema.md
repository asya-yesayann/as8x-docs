# Schema դասի նկարագրություն

Schema դասը նախատեսված է տվյալների աղբյուրի սյուների ու պարամետրերի կառուցվածքի մասին ամբողջական ինֆորմացիայի պահման համար։

Schema դասի կոնստրուկտորը ունի հետևյալ շարահյուսությունը՝
```c#
        public Schema(string name, string armenianCaption, string englishCaption, Type rowType, Type paramType,
                      bool supportedExtendedFeatures = false)
```

Կոնստրուկտորի պարամետրերի մասին ամբողջական ինֆորմացիան ներկայացված է ստորև՝

| Անվանում | Տեսակ | **Նկարագրություն** |
| --- | --- | --- |
| name | string | Սխեմայի ներքին անվանում| 
| armenianCaption | string | Սխեմայի հայերեն անվանում(անվանումը անհրաժեշտ է փոխանցել Ansi կոդավորմամբ)| 
| englishCaption | string | Սխեմայի անգլերեն անվանում| 
| rowType | Type | Տվյալների աղբյուրի սյուները նկարագրող դասի տիպը| 
| paramType | Type | Տվյալների աղբյուրի պարամետրերը նկարագրող դասի տիպը| 
| supportedExtendedFeatures | bool | Ցույց է տալիս թե տվյալների աղբյուրը կարող է պարունակել Unicode կոդավորմամբ սյուներ թե ոչ։ Այս հատկությամբ տվյալների աղբյուրի օգտագործումը արգելվում է 4X-ից։ Լռությամբ արժեքը false է։| 

Օրինակ՝
```c#
this.Schema = new Schema(this.Name, ConstantsArmenian.ParamLog.ToArmenianANSICached(), ConstantsEnglish.ParamLog, typeof(DataRow), typeof(Param));
```
## Մեթոդներ

### AddColumn

Սխեմայում տվյալների աղբյուրի սյան նկարագրության մասին ինֆորմացիան ավելացնելու համար պետք է կանչել AddColumn մեթոդը, որն ունի հետևյալ շարահյուսությունը՝

```c#
        public void AddColumn(string name, string source, string armenianCaption, string englishCaption, FieldType columnType,
                              bool isPermanent = false, short start = 0, bool autoProcess = true,
                              string armenianDescription = null, string englishDescription = null,
                              FieldType showType = null, short width = 0,
                              short headlines = 2, bool isTrimEnd = false, bool mayNotExistInSQL = false,
                              SupportedEncoding supportedEncoding = SupportedEncoding.ArmenianAnsi)
```

Մեթոդի պարամետրի մասին ամբողջական ինֆորմացիան ներկայացված է ստորև՝

| Անվանում | Տեսակ | **Նկարագրություն** | Լռությամբ արժեք|
| --- | --- | --- | --- |
| name | string | Սյան ներքին անվանում| Չունի, արժեքը պարտադիր է լրացնել |
| source | string | sql-based տվյալների աղբյուրի դեպքում նշվում է SQL-ից կարդացվող սյան անունը, իսկ array-based տվյալների աղբյուրի դեպքում՝ սյան համարը| Չունի, արժեքը պարտադիր է լրացնել |
| armenianCaption | string | Սյան հայերեն անվանում(անվանումը անհրաժեշտ է փոխանցել Ansi կոդավորմամբ)| Չունի, արժեքը պարտադիր է լրացնել |
| englishCaption | string | Սյան անգլերեն անվանում| Չունի, արժեքը պարտադիր է լրացնել | 
| columnType | FieldType | Սյան համակարգային տիպ| Չունի, արժեքը պարտադիր է լրացնել | 
| isPermanent | bool | Սյունը հավերժական է թե ոչ: Ընթացիկ դիտելու ձևից ծրագրային կարելի է կարդալ միայն հավերժական սյունակները։| false |
| start | short | Սահմանում է մեկնարկային դիրքը, որից սկսած ցույց է տալիս արժեք որևէ ձևաչափված դաշտից։ Նախատեսված է fSPEC-ից կամ այլ տողային դաշտերից տվյալը ճիշտ տիպով կարդալու և ցույց տալու համար։ Կարդացվող արժեքի երկարությունը որոշվում է columnType-ից կախված։| 0 |
| autoProcess | bool |Այս հատկության false արժեքի դեպքում սյունը համարվում է հաշվարկային։ Սյան արժեքների հաշվարկը կարելի է իրականացնել գերբեռնելով `ProcessRow` կամ `AfterDataReaderClose` մեթոդը։ Իսկ այս հատկությունը ունեցող սյան համար որպես source կարելի է նշել կամայական տեքստ։| true |
| armenianDescription | string | Սյան հայերեն նկարագրություն(անվանումը անհրաժեշտ է փոխանցել Ansi կոդավորմամբ)| null |
| englishDescription | string | Սյան անգլերեն նկարագրություն | null |
| showType | FieldType | Սահմանում է համակարգային տիպը ցուցադրման ժամանակ։ Եթե այս պարամետրը բացակայում է, ապա օգտագործվում է columnType հատկության արժեքը։ Սովորոբար այս հատկությունը օգտագործում են, եթե տվյալների տիպը, որը համապատասխանում է սյունակի արժեքներին, հարմար չի ցուցադրման համար։ Օրինակ եթե columnType = new StringFieldType(150) է, բայց շատ դեպքերում բավական է տեսնել տողի սկիզբը, ապա կարելի է սահմանել showType = new StringFieldType(32):| null |
| width | short | Սյունակի լայնությունը: Արժեք չփոխանցելու դեպքում որոշվում է կախված սյան armenianCaption, englishCaption, columnType, showType հատկություններից| 0 | 
| headlines | short | Սյան անվանման մեջ տողերի քանակ | 2 | 
| isTrimEnd | bool | Սյան արժեքները վերջից trim են արվում թե ոչ| false |
| mayNotExistInSQL | bool | sql-based տվյալների աղբյուրի sql հարցման մեջ սյան արժեքների լրացման համար նախատեսված սյան վերադարձը պարտադիր է թե ոչ։ Սյան արժեքների լրացման համար անհրաժեշտ sql-ական սյան անվանումը նշվում է source դաշտում։| false |
| supportedEncoding | SupportedEncoding | Սյան կոդավորման տեսակը։ Լռությամբ արժեքը false է։ SupportedEncoding-ը կարող է լինել երեք տեսակի՝ ArmenianAnsi, RussionAnsi և Unicode, լռելյան ArmenianAnsi է։ Unicode արժեքի դեպքում անհրաժեշտ է սխեմայի SupportedExtendedFeatures հատկության արժեքը լինի true:| SupportedEncoding.ArmenianAnsi |

Օրինակ՝
```c#
            this.Schema.AddColumn(nameof(DataRow.DocType), "DocType", ConstantsArmenian.DocType.ToArmenianANSICached(), ConstantsEnglish.DocType, FieldTypeProvider.GetStringFieldType(SYSDEF.DocNameLength));
```

### AddParam

Սխեմայում տվյալների աղբյուրի պարամետրի նկարագրության մասին ինֆորմացիան ավելացնելու համար պետք է կանչել AddParam մեթոդը, որն ունի հետևյալ շարահյուսությունը՝

```c#
        public void AddParam(string name, string description, FieldType fieldType, string userReportValue = null,
                     long? supportedFilterType = null, bool required = false, string eDescription = "",
                     bool nullable = false, bool allowTime = false)
```

Մեթոդի պարամետրի մասին ամբողջական ինֆորմացիան ներկայացված է ստորև՝

| Անվանում | Տեսակ | **Նկարագրություն** | Լռությամբ արժեք|
| --- | --- | --- | --- |
| name | string | Պարամետրի ներքին անվանում| Չունի, արժեքը պարտադիր է լրացնել | 
| description | string | Պարամետրի հայերեն նկարագրություն(նկարագրությունը անհրաժեշտ է փոխանցել Ansi կոդավորմամբ)| Չունի, արժեքը պարտադիր է լրացնել | 
| fieldType | FieldType | Պարամետրի համակարգային տիպ | Չունի, արժեքը պարտադիր է լրացնել | 
| userReportValue | string | Սահմանում է պարամետրի արժեքը օգտագործողի կողմից նկարագրվող հաշվետվություններում։ Այս արժեքը չի կարող փոփոխվել օգտագործողի կողմից | null |
| supportedFilterType | long? | Եթե պարամետրի տիպը ժառանգ է  ParamValuePair<T> դասից, ապա պետք է նշել պարամետրի ֆիլտրման հասանելի  տիպերը | null |
| required | bool |  Պարամետրի արժեքի լրացումը պարտադիր է թե ոչ| false |
| eDescription | string | Պարամետրի անգլերեն նկարագրություն| string.Empty | 
| nullable | bool | Պարամետրը կարող է ընդունել null տիպի արժեք թե ոչ | false |
| allowTime | bool | Եթե պարամետրի համակարգային տիպը ամսաթվային տիպի է(Date, DateLong, DateRep), ապա ամսաթվի հետ միասին լինի ժամանակը թե ոչ| false |

Օրինակ՝
```c#
            this.Schema.AddParam(nameof(Param.DocType), ConstantsArmenian.DocType.ToArmenianANSICached(), FieldTypeProvider.GetStringFieldType(DSConstantsLength.DocCapDocType), eDescription: ConstantsEnglish.DocType);
``՝
