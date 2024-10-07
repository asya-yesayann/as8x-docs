using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ArmSoft.AS8X.Common;
using ArmSoft.AS8X.Common.Extensions;
using ArmSoft.AS8X.Core.Document;
using ArmSoft.AS8X.Core.DPR;
using ArmSoft.AS8X.Core.Storage;
using ArmSoft.AS8X.Models;

namespace ArmSoft.AS8X.Core.DPRImplementation.DocumentOperations;

public class DeleteDocsByIsnResponse
{
    public StorageInfo StorageInfo { get; set; }
}

public class DeleteDocsByIsnRequest
{
    public List<int> DocumentIsns { get; set; }
}

[DPR(DPRType = DPRType.Other, ArmenianCaption = "Փաստաթղթերի հեռացում", EnglishCaption = "Deletion of documents")]
public class DeleteDocsByIsnDPR : DataProcessingRequest<DeleteDocsByIsnResponse, DeleteDocsByIsnRequest>
{
    private readonly IDocumentService documentService;
    private readonly IStorageService storageService;

    public DeleteDocsByIsnDPR(IDocumentService documentService, IStorageService storageService)
    {
        this.documentService = documentService;
        this.storageService = storageService;
    }

    public override async Task<DeleteDocsByIsnResponse> Execute(DeleteDocsByIsnRequest request, CancellationToken stoppingToken)
    {
        //սխալների հավաքագրման համար տեքստային հաշվետվության ստեղծում
        using var report = new TextReport.TextReport(this.storageService)
        {
            ArmenianCaption = "Կատարման ընթացքում առաջացած սխալներ".ToArmenianANSI(),
            EnglishCaption = "Errors which occured during execution"
        };

        // 80 լայնությամբ ֆրագմենտի ավելացում հաշվետվությունում
        const int fragmentLength = 80;
        report.AddFragment(fragmentLength);

        // հաշվետվությունում գլխագիր տողի ավելացում թավ տառաոճով
        var formattedText = TextReport.TextReport.ApplyStyle("Փաստաթղթերի հեռացման սխալներ".ToArmenianANSI(), TextReportStyle.Bold);
        report.AddHeader(formattedText);

        // DPR-ի կատարման պրոգրեսի պատուհանում "Հարցման կատարում" անունով փուլի ավելացում
        this.Progress.Add("Հարցման կատարում".ToArmenianANSI());
        var isns = request.DocumentIsns;

        this.Progress.CurrentPhase.Total = isns.Count; // պրոգրեսի ընթացիկ փուլում մշակվող տվյալների քանակը տալով
                                                       // պրոգրեսի պատուհանում հնարավոր է ցույց տալ մշակման ենթակա տվյալներից քանիսն են մշակվել

        this.Progress.CurrentPhase.Row = 0; // ընթացիկ պահին մշակվել է 0 փաստաթուղթ

        foreach (int isn in isns)
        {
            if (stoppingToken.IsCancellationRequested)
            {
                break; // եթե DPR-ի կատարման պրոգրեսի պատուհանից սեղմվել է «Ընդհատել» կոճակը, ապա ընդհատվում է կատարումը
            }
            this.Progress.CurrentPhase.Row++; // ամեն փաստաթղթի մշակման հետ պատուհանում փոխվում է մշակված փաստաթղթերի քանակը, օրինակ 7/11
            try
            {
                //հերթական փաստաթղթի ամբողջական հեռացում
                await this.documentService.Delete(isn, false, "Փաստաթղթի հեռացում".ToArmenianANSI());
            }
            catch (Exception ex)
            {
                report.AddRow($"Առաջացել է սխալ {0} փաստաթղթի ջնջման ժամանակ։".ToArmenianANSI(), isn);

                // առաջացած սխալի հաղորդագրությունների ավելացում որպես տող տեքստային հաշվետվությունում
                foreach (string line in ex.Message.Split('\n'))
                {
                    report.AddRow(line, isn);
                }
                report.AddRow(string.Empty);
            }
        }

        // բոլոր փաստաթղթերի մշակումից հետո հաշվետվությունը պահվում է որպես ֆայլ SaveToStorageAndClose մեթոդի միջոցով,
        // որը վերադարձնում է StorageInfo, որը պարունակում է տվյալներ սերվերից ֆայլը բեռնելու համար
        return new DeleteDocsByIsnResponse { StorageInfo = await report.SaveToStorageAndClose() };
    }
}