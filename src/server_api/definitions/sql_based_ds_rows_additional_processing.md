## Sql-based տվյալների աղբյուրի տողերի հավելյալ մշակում

`Sql-based` տվյալների աղբյուրի տողերի հավելյալ մշակման, ֆիլտրման, հաշվարկային սյուների արժեքների հաշվման համար անհրաժեշտ է override անել 
[ProcessRow](ds.md#processrow) մեթոդը, 
որը կանչվում է **յուրաքանչյուր** տողի համար։ Այն հանդիսանում է 4x համակարգում նկարագրված [OnEachRow](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/OnEachRow.html) + 
[Valid](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/Valid_Data.html) իրադարձությունների միավորումը մեկ մեթոդում։ Մեթոդի կանչը տեղի է
ունենում տվյալների աղբյուրի sql հարցման հրամանի կատարումից հետոո՝ երբ հարցման պատասխանի սյուները կարդացող [SqlDataReader](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqldatareader?view=sqlclient-dotnet-standard-5.2) տիպի reader-ը դեռ բաց է: Այդ պատճառով մեթոդի կանչի ժամանակ
հնարավոր չէ կատարել այլ sql հարցումներ։

ProcessRow մեթոդը որպես մուտքային պարամետրեր ստանում է ընթացիկ տողը, [SqlDataReader](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqldatareader?view=sqlclient-dotnet-standard-5.2) տիպի reader-ը և արդյունքում վերադարձնում է bool տիպի արժեք, որը ցույց է տալիս թե ընթացիկ տողը ընդգրկվի տվյալների աղբյուրի տողերի ցուցակում թե ոչ։

## ProcessRow-ի օգտագործման օրինակներ

### Օրինակ 1

Այս օրինակում fSTATENAME string տիպի հաշվարկային սյան արժեքը որոշվում fSTATE short տիպի ոչ հաշվարկային սյան արժեքներից ելնելով:

```c#
protected override bool ProcessRow(DataSourceArgs<Param> args, DataRow row, SqlDataReader reader)
{
  switch (row.fSTATE)
  {
    case 998:
        row.fSTATENAME = "Մերժված";
        break;
    case 999:
        row.fSTATENAME = "Հեռացված";
        break;
    default:
        row.fSTATENAME = "Անհայտ";
        break;
  }
  return true;
}
```
