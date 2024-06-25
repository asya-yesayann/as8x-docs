using System;
using System.Threading;
using System.Threading.Tasks;
using ArmSoft.AS8X.Common.Extensions;
using ArmSoft.AS8X.Common.FieldTypes;
using ArmSoft.AS8X.Core.Document;
using ArmSoft.AS8X.Core.DS;

namespace ArmSoft.AS8X.Core.DSImplementation
{
    [DataSource("DocFlds")]
    public class DocumentFields : DataSource<DocumentFields.DataRow, DocumentFields.Param>
    {
        public class DataRow : IExtendableRow
        {
            public string Code { get; set; }
            public string Caption { get; set; }
            public object Extend { get; set; }
        }

        public class Param
        {
            public string DocType { get; set; }
        }

        public override bool IsSQLBased
        {
            get
            {
                return false;
            }
        }

        private readonly IDBService dBService;
        public DocumentFields(IDBService dBService, IServiceProvider serviceProvider) : base(serviceProvider)
        {
            this.dBService = dBService;
            this.Schema = new Schema(this.Name, "Փաստաթղթի դաշտեր".ToArmenianANSI(), "Document's fields", typeof(DataRow), typeof(Param));

            this.Schema.AddColumn(nameof(DataRow.Code), "", "Կոդ".ToArmenianANSI(), "Code", FieldTypeProvider.GetStringFieldType(25));
            this.Schema.AddColumn(nameof(DataRow.Caption), "", "Անվանում".ToArmenianANSI(), "Name", FieldTypeProvider.GetStringFieldType(30));

            this.Schema.AddParam(nameof(Param.DocType), "Փաստաթղթի տեսակ".ToArmenianANSI(), FieldTypeProvider.GetStringFieldType(8), eDescription: "Document's type");
        }

        protected override async Task FillData(DataSourceArgs<Param> args, CancellationToken stoppingToken)
        {
            if (!string.IsNullOrWhiteSpace(args.Parameters.DocType))
            {
                var documentDescription = await DocumentHelper.DocumentDescription(this.dBService.Connection, args.Parameters.DocType);
                foreach (var field in documentDescription.Fields)
                {
                    var row = new DataRow
                    {
                        Code = field.Key,
                        Caption = field.Value.Caption
                    };
                    this.Rows.Add(row);
                }
            }
        }
    }
}

