using System;
using System.Threading;
using System.Threading.Tasks;
using ArmSoft.AS8X.Common.Extensions;
using ArmSoft.AS8X.Common.FieldTypes;
using ArmSoft.AS8X.Core.DS;
using ArmSoft.AS8X.Core.Tree;

namespace ArmSoft.AS8X.Core.DSImplementation
{
    [DataSource(nameof(TreeNode))]
    public class TreeNode : DataSource<TreeNode.DataRow, TreeNode.Param>
    {
        private readonly IDBService dBService;
        private readonly TreeElementService treeElementService;
        
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

        public override bool IsSQLBased => false;

        protected override async Task FillData(DataSourceArgs<Param> args, CancellationToken stoppingToken)
        {
            string treeId = args.Parameters.TreeId;
            if (!string.IsNullOrWhiteSpace(treeId))
            {
                var treeNodes = await this.treeElementService.GetTreeElements(treeId, args.Parameters.NodeType);
                foreach (var (code, treeNode) in treeNodes)
                {
                    var row = new DataRow
                    {
                        Code = treeNode.Key,
                        Name = treeNode.Comment
                    };
                    this.Rows.Add(row);
                }
            }
        }

    }
}
