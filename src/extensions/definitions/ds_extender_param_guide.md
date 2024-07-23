---
layout: page
title: "Տվյալների աղբյուր պարամետրերի ընդլայնման ձեռնարկ" 
---

# Տվյալների աղբյուրի պարամետրերի ընդլայնում 8X-ում և ՀԾ-Բանկ համակարգում

## Բովանդակություն
* [Տվյալների աղբյուրի պարամետրերի ընդլայնում 8X-ում](#տվյալների-աղբյուրի-պարամետրերի-ընդլայնում-8X)
* [Պարամետրերի ընդլայնում ՀԾ-Բանկ համակարգում](#պարամետրերի-ընդլայնում-ՀԾ-Բանկ-համակարգում)

## Տվյալների աղբյուրի պարամետրերի ընդլայնում 8X-ում

Տվյալների աղբյուրի պարամետրերը նկարագրող դասը սահմանվում է ընդլայնվող սյունյակների նման։ Տես նաև՝ [Տվյալների աղբյուրի ընդլայնում 8X-ում](/src/extensions/definitions/ds_extender_guide.md)

.cs ֆայլում հարկավոր է ստեղծել `class`, որը ժառանգում է `Extender<R, P>` դասը՝ որպես R փոխանցելով տվյալների աղբյուրի սյուները նկարագրող դասը, իսկ որպես P՝ պարամետրերը նկարագրող դասը։ Եթե տվյալների աղբյուրը չի պարունակում սյուներ, ապա որպես R անհրաժեշտ է փոխանցել NoColumns դասը։ Հարկավոր է նաև ավելացնել `[DataSourceExtender]` ատրիբուտը։ Օրինակ՝

```cs
[DataSourceExtender]
public class AllOperExtended : Extender<NoColumns, AllOperExtended.Params>
```

Ավելացվող պարամետրը հարկավոր է սահմանել երկու տեղ
1. Նոր class, որը պարունակում է ընդլայնվող պարամետրերը որպես հատկություններ  (Օրինակում Params)

``` cs
public class Params
{
    public string CliCode { get; set; }
}
```
2. Ընդլայնող դասի կոնստրուկտորի մեջ՝ `AddParam` ֆունկցիայի միջոցով։
``` cs
public AllOperExtended()
{
    AddParam(nameof(Params.CliCode), Resources.CliCode, FieldTypeProvider.GetStringFieldType(Constants.LenClient ));           
}
```

Ստորև բերված օրինակում, որպես նոր պարամետր հայտարարված է հաճախորդի կոդը։ Պարամետրին դիմելու համար հարկավոր է `BeforeProcess` ֆունկցիայում հայտարարել `extenderParametrs` փոփոխական.

``` cs
var extenderParameters = (Params)args.ExtenderParameters;
```
Ըստ հաճախորդի կոդի `BeforeProcess` ֆունկցիայում կատարվում է SQL հարցում, որի արդյունքում վերադարձվում են տվյալ հաճախորդի հաշիվները։

``` cs
public override async Task BeforeProcess(IList<IExtendableRow> rows, IDataSourceArgs args)
    {
        var extenderParameters = (Params)args.ExtenderParameters;
        if (string.IsNullOrWhiteSpace(extenderParameters.CliCode))
        {
            return;
        }
        string sqlQuery = "SELECT fCODE from ACCOUNTS with (nolock) where fCLICODE = @CliCode";
        this.accounts = (await this.dbService.Connection.QueryAsync<string>(sqlQuery,
              new { CliCode = extenderParameters.CliCode })).ToHashSet();
    }
```

`ProcessRow` ֆունկցիայում տվյալ հաճախորդի յուրաքանչյուր հաշիվը ստուգվում է կա արդյոք դեբետում կամ կրեդիտում, և դրական պատասխանի դեպքում վերադարձնում է տվյալ հաշիվը։

``` cs
public override Task<bool> ProccessRow(IExtendableRow row, IDataSourceArgs args)
    {
        var extenderParameters = (Params)args.ExtenderParameters;
        if (string.IsNullOrWhiteSpace(extenderParameters.CliCode))
        {
            return Task.FromResult(true);
        }
        var dsRow = (AllOperations.DataRow)row;
        bool result = this.accounts.Contains(dsRow.ACCDB) || this.accounts.Contains(dsRow.ACCCR);

        return Task.FromResult(result);
    }
```

## Պարամետրերի ընդլայնում ՀԾ-Բանկ համակարգում

Նոր պարամետր ավելացնելուց առաջ նախ հարկավոր է "Համակարգային նկարագրությունների ընդլայնումներ"-ի  «Դիալոգների ընդլայնում»-ներ թղթապանակում ավելացնել մեզ անհրաժեշտ ընդլայնումը։

![alt pic](https://github.com/armsoft/as8x-docs/blob/main/src/extensions/definitions/ds_extender_param_guide_dialog_extensions.png)

Պարտադիր է, որպեսզի "Ավելացվող դաշտեր" աղյուսակում նշված "Դաշտի կոդը" և "Համակարգային տիպը" սյուներում ավելացվող արժեքները համընկնեն .cs ֆայլում հայտարարված պարամետրերի անվան և տիպի հետ։

![alt pic](https://github.com/armsoft/as8x-docs/blob/main/src/extensions/definitions/ds_extender_param_guide_dialog_extensions_create.png)

Դիալոգի անունը անհրաժեշտ է, որպեսզի համընկնի դիտելու ձևի անվան հետ։ Այն հնարավոր է տեսնել անհրաժեշտ թղթապանակի պարամետրերում։ Օրինակում բերված է «Ընդհանուր դիտում» թղթապանակի դիտելու ձևի անունը` AllOpers:

![alt pic](https://github.com/armsoft/as8x-docs/blob/main/src/extensions/definitions/ds_extender_param_guide_folder_param.png)

![alt pic](https://github.com/armsoft/as8x-docs/blob/main/src/extensions/definitions/ds_extender_param_guide_folder_param_name.png)

8X սերվիսի ռեժիմում, երբ նոր ստեղծված դիտելու ձևում "Տվյալների աղբյուրի ընդլայնիչ"-ը լրացնելուց հետո, նոր ավելացված պարամետրերը կարելի է տեսնել "Պարամետրերի սկզբնական արժեքներ" էջի աղյուսակում։
Տվյալ օրինակում, որպես նոր պարամետր ավելացվում է հաճախորդի կոդը.

![alt pic](https://github.com/armsoft/as8x-docs/blob/main/src/extensions/definitions/ds_extender_param_guide_extend_params.png)










