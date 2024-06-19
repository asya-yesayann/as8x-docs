using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using ArmSoft.AS8X.Common.Extensions;
using ArmSoft.AS8X.Common.FieldTypes;
using ArmSoft.AS8X.Common.Language;
using ArmSoft.AS8X.Core;
using ArmSoft.AS8X.Core.Constants;
using ArmSoft.AS8X.Core.DS;
using ArmSoft.AS8X.Core.Properties;
using Microsoft.Data.SqlClient;

namespace ArmSoft.AS8X.Bank.DS.Common
{
    [DataSource(nameof(DocCap))]
    public class DocCap : DataSource<DocCap.DataRow, DocCap.Param>
    {
        public readonly IDBService dbService;

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

        #region Definition

        public class DataRow : IExtendableRow
        {
            public string DocType { get; set; }
#pragma warning disable IDE1006 // Naming Styles
            public string fCAPTION { get; set; }
#pragma warning restore IDE1006 // Naming Styles
            public object Extend { get; set; }
        }

        public class Param
        {
            public string DocType { get; set; }
        }

        public DocCap(IDBService dbService, IServiceProvider serviceProvider) : base(serviceProvider)
        {
            this.dbService = dbService;
            this.Schema = new Schema(this.Name, ConstantsArmenian.DocType.ToArmenianANSICached(), ConstantsEnglish.DocType, typeof(DataRow), typeof(Param));

            this.Schema.AddColumn(nameof(DataRow.DocType), "DocType", ConstantsArmenian.DocType.ToArmenianANSICached(), ConstantsEnglish.DocType, FieldTypeProvider.GetStringFieldType(SYSDEF.DocNameLength));
            this.Schema.AddColumn(nameof(DataRow.fCAPTION), "DocTypeName", ConstantsArmenian.Name.ToArmenianANSICached(), ConstantsEnglish.Name, FieldTypeProvider.GetStringFieldType(SYSDEF.fCAPTIONLength));
            this.Schema.AddParam(nameof(Param.DocType), ConstantsArmenian.DocType.ToArmenianANSICached(), FieldTypeProvider.GetStringFieldType(DSConstantsLength.DocCapDocType), eDescription: ConstantsEnglish.DocType);
        }
        #endregion
    }
}
