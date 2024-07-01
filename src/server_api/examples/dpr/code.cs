using System.Data;
using System.Threading;
using System.Threading.Tasks;
using ArmSoft.AS8X.Common;
using ArmSoft.AS8X.Core.DPR;
using ArmSoft.AS8X.Models.DPR.Implementation;

namespace ArmSoft.AS8X.Core.DPRImplementation
{
    [DPR(nameof(IndexDefragment), DPRType = DPRType.Other, ArmenianCaption = "Ինդեքսների դեֆրագմենտացիա",
                                      EnglishCaption = "Index defragment")]
    public class IndexDefragment : DataProcessingRequest<NoResult, IndexDefragmentRequest>
    {
        private readonly IDBService dbService;

        public IndexDefragment(IDBService dbService)
        {
            this.dbService = dbService;
        }

        public override async Task<NoResult> Execute(IndexDefragmentRequest request, CancellationToken stoppingToken)
        {
            using var cmd = this.dbService.Connection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "asp_IndexDefrag";
            cmd.Parameters.Add("@withupdateusage", SqlDbType.Bit).Value = request.UpdateUsage;
            await cmd.ExecuteNonQueryAsync(stoppingToken);
            return new NoResult();
        }
    }
}
