---
layout: page
title: "Տվյալների աղբյուր պարամետրերի ընդլայնման ամբողջական օրինակ" 
---

Բերված օրինակում որպես նոր պարամետր ավելացնում ենք հաճախորդի կոդը։ 
Տվյալ կոդի միջոցով կատարվում է SQL հարցում, որի արդյունքում վերադարձվում են նշված հաճախորդի հաշիվները։ 
`ProcessRow` ֆունկցիայում տվյալ հաճախորդի յուրաքանչյուր հաշիվը ստուգվում է կա արդյոք դեբետում կամ կրեդիտում, և դրական պատասխանի դեպքում ֆունկցիան վերադարձնում է `true` որպեսզի տողը արտացոլվի վերջնական արդյունքում։ 

``` cs
using ArmSoft.AS8X.Bank;
using ArmSoft.AS8X.Bank.General.DS;
using ArmSoft.AS8X.Common;
using ArmSoft.AS8X.Common.FieldTypes;
using ArmSoft.AS8X.Core;
using ArmSoft.AS8X.Core.DS;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSpecific.DSExtenders
{
    [DataSourceExtender]
    public class AllOperExtended : Extender<NoColumns, AllOperExtended.Params>
    {
        private readonly IDBService dbService;
        private HashSet<string> accounts;

        public class Params
        {
            public string CliCode { get; set; }
        }
        public AllOperExtended(IDBService dbService)
        {
            this.dbService = dbService;
            AddParam(nameof(Params.CliCode), "Հաճախորդի կոդ".ToArmenianANSI(), FieldTypeProvider.GetStringFieldType(8));
        }

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
    }
}
```
