---
layout: page
title: "Տվյալների մշակման հարցման (DPR-ի) նկարագրման և սկրիպտից կանչի օրինակ" 
---

Այս օրինակում բերված են DPR-ի նկարագրման համար անհրաժեշտ սերվերային տրամաբանությունը պարունակող c# ֆայլը և սկրիպտից կանչման եղանակը։

## DPR-ի նկարագրություն

```c#
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
using static ArmSoft.AS8X.Core.TextReport.TextReport;

namespace ArmSoft.AS8X.Core.DPRImplementation.DocumentOperations
{
    public class DeleteDocsByIsnResponse
    {
        public StorageInfo StorageInfo { get; set; }
    }

    public class DeleteDocsByIsnRequest
    {
        public List<int> DocumentIsns { get; set; }
    }

    [DPR(DPRType = DPRType.Report, ArmenianCaption = "Փաստաթղթերի հեռացում", EnglishCaption = "Deletion of documents")]
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
            var formattedText = ApplyStyle("Փաստաթղթերի հեռացման սխալներ", TextReportStyle.Bold);
            report.AddHeader(formattedText);

            // DPR-ի կատարման պրոգրեսի պատուհանում "Հարցման կատարում" անունով փուլի ավելացում
            this.Progress.Add("Հարցման կատարում");
            var isns = request.DocumentIsns;

            this.Progress.CurrentPhase.Total = isns.Count; // պրոգրեսի ընթացիկ փուլում մշակվող տվյալների քանակը տալով
                                                           // պրոգրեսի պատուհանում հնարավոր է ցույց տալ մշակման ենթակա տվյալներից քանիսն են մշակվել

            this.Progress.CurrentPhase.Row = 0; // ընթացիկ պահին մշակվել է 0 փաստաթուղթ

            foreach (int isn in isns)
            {

                if (stoppingToken.IsCancellationRequested)
                {
                    break; // եթե DPR-ի կատարման պրոգրեսի պատուհանից սեղմվել է "Ընդհատել կոճակը", ապա ընդհատվում է կատարումը
                }
                this.Progress.CurrentPhase.Row++; // ամեն փաստաթղթի մշակման հետ պատուհանում փոխվում է մշակված փաստաթղթերի քանակը, օրինակ 7/11
                try
                {
                    //հերթական փաստաթղթի ամբողջական հեռացում
                    await this.documentService.Delete(isn, true, "Փաստաթղթի հեռացում");
                }
                catch (Exception ex)
                {
                    // առաջացած սխալի հաղորդագրությունների ավելացում որպես տող տեքստային հաշվետվությունում
                    foreach (string line in ex.Message.Split(['\n']))
                    {
                        report.AddRow(line, isn);
                    }
                    report.AddHeader(string.Empty);
                    continue;
                }
            }

            // բոլոր փաստաթղթերի մշակումից հետո հաշվետվությունը պահվում է որպես ֆայլ SaveToStorageAndClose մեթոդի միջոցով,
            // որը վերադարձնում է StorageInfo, որը պարունակում է ֆայլի և ֆայլը պարունակող թղթապանակի անունները
            return new DeleteDocsByIsnResponse { StorageInfo = await report.SaveToStorageAndClose() };
        }

    }
}
```

## DPR-ի սկրիպտից կանչի եղանակ

```as4x
Public Sub DeleteDocs()
	Dim ErrReport As AsRepViewer

	Dim arrISNs() As Long
	Dim dictResponse As Dictionary
	Dim dictISNs    As Dictionary
	Dim oStorageInfo As StorageInfo

	Set ErrReport = CreateRepViewer
	Set dictISNs = New Dictionary
	Set dictResponse = New Dictionary

	' Հեռացման համար անհրաժեշտ փաստաթղթերի ISN-ների ավելացում զանգվածում
	ReDim arrISNs(2)
	arrISNs(0) = 301785190
	arrISNs(1) = 212262708
	arrISNs(2) = 526482501

	' Ձևավորված զանգվածի ավելացում Dictionary-ում, որը փոխանցվելու է DPR-ի կատարման ժամանակ որպես պարամետեր
	dictISNs.Add("DocumentIsns", arrISNs)

	' DPR-ը կատարելու համար անհրաժեշտ է կանչել ExecuteDPR մեթոդը՝ նշելով DPR-ի տեսակը, ներքին անունը,
    ' կատարման համար անհրաժեշտ պարամետրերը ու արդյունքում առաջացող տվյալների լրացման համար օբյեկտ
	ExecuteDPR(DPRType.Other, "DeleteDocByIsnDPR", dictISNs, dictResponse)

	' Այս DPR-Ի կատարման արդյունքում վերադարձվում է StorageInfo, որը պարունակում է փաստաթղթերի հեռացման ընթացքում առաջացած սխալները
    ' պարունակող TextReport-ը պարունակող կոնտեյների ու ֆայլի անունները
    ' StorageInfo-ի container ու blobName դաշտերը վերագրվում են oStorageInfo օբյեկտի համապատասխան դաշտերին
	oStorageInfo.Container = dictResponse.Item("container")
	oStorageInfo.BlobName = dictResponse.Item("blobName")

	'Բեռնում է TextReport-ը սերվերից ըստ oStorageInfo և վերագրվում ErrReport-ին
	With ErrReport
		.LoadFromStorageInService(oStorageInfo)
	End With

	' Եթե բեռնված TextReport-ը պարունակում է գոնե 1 տող, ապա այն ցուցադրվում է 4X կլիենտում Show մեթոդի միջոցով
	If ErrReport.RowCount <> 0 Then
		ErrReport.Show
	End If

End Sub
```
