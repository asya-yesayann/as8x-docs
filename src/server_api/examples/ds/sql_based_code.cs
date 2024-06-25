using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using ArmSoft.AS8X.Common.Extensions;
using ArmSoft.AS8X.Common.FieldTypes;
using ArmSoft.AS8X.Core.DS;
using Microsoft.Data.SqlClient;

namespace ArmSoft.AS8X.Core.DSImplementation
{
    [DataSource(nameof(TreeNode))]
    public class TreeNode : DataSource<TreeNode.DataRow, TreeNode.Param>
    {
        private readonly IDBService dBService;
        public class DataRow : IExtendableRow
        {
            public string Code { get; set; }
            public string Name { get; set; }
            public object Extend { get; set; }
        }

        public class Param
        {
            public string TreeId { get; set; }
            public string NodeType { get; set; }
        }

        public TreeNode(IDBService dbService, IServiceProvider serviceProvider) : base(serviceProvider)
        {
            this.dBService = dbService;
            this.Schema = new Schema(this.Name, "Ծառի հանգույցներ".ToArmenianANSI(), "Tree nodes", typeof(DataRow), typeof(Param));

            this.Schema.AddColumn(nameof(DataRow.Code), "Code", "Կոդ".ToArmenianANSI(), "Code", FieldTypeProvider.GetStringFieldType(20));
            this.Schema.AddColumn(nameof(DataRow.Name), "Name", "Անվանում".ToArmenianANSI(), "Name", FieldTypeProvider.GetStringFieldType(50));
            // Parameters
            this.Schema.AddParam(nameof(Param.TreeId), "Ծառի իդենտիֆիկատոր".ToArmenianANSI(), FieldTypeProvider.GetStringFieldType(4), eDescription: "TreeId");
            this.Schema.AddParam(nameof(Param.NodeType), "Ծառի հանգույցներ".ToArmenianANSI(), FieldTypeProvider.GetStringFieldType(1), eDescription: "Tree nodes");
        }

        protected override Task<SqlCommand> MakeSQLCommand(DataSourceArgs<Param> args, CancellationToken stoppingToken)
        {
            var cmd = this.dBService.Connection.CreateCommand();
            cmd.CommandText = $@"SELECT fCODE AS Code, fNAME AS [Name]
                                 FROM TREES 
                                 WHERE fTREEID = @TreeId";
            cmd.Parameters.Add("@TreeId", SqlDbType.Char, 8).Value = args.Parameters.TreeId;
            if (!string.IsNullOrWhiteSpace(args.Parameters.NodeType))
            {
                cmd.CommandText += " AND fLEAF = @NodeType";
                cmd.Parameters.Add("@NodeType", SqlDbType.Char, 1).Value = args.Parameters.NodeType;
            }
            cmd.CommandText += "\n ORDER BY Code";

            return Task.FromResult(cmd);
        }
    }
}
