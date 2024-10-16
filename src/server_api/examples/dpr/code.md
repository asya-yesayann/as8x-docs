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
using ArmSoft.AS8X.Core.TextReport;
using ArmSoft.AS8X.Models;

namespace ArmSoft.AS8X.Bank.DPR;

public class DeleteDocsByIsnRequest
{
    public List<int> DocumentIsns { get; set; }
}

[DPR(DPRType = DPRType.Other, ArmenianCaption = "Փաստաթղթերի հեռացում", EnglishCaption = "Deletion of documents")]
public class DeleteDocsByIsnDPR : DataProcessingRequest<StorageInfo, DeleteDocsByIsnRequest>
{
    private readonly IDocumentService documentService;
    private readonly IStorageService storageService;

    public DeleteDocsByIsnDPR(IDocumentService documentService, IStorageService storageService)
    {
        this.documentService = documentService;
        this.storageService = storageService;
    }

    public override async Task<StorageInfo> Execute(DeleteDocsByIsnRequest request, CancellationToken stoppingToken)
    {
        //սխալների հավաքագրման համար տեքստային հաշվետվության ստեղծում
        using var report = new TextReport(this.storageService)
        {
            ArmenianCaption = "Կատարման ընթացքում առաջացած սխալներ".ToArmenianANSI(),
            EnglishCaption = "Errors which occured during execution"
        };

        // 80 լայնությամբ ֆրագմենտի ավելացում հաշվետվությունում
        const int fragmentLength = 80;
        report.AddFragment(fragmentLength);

        // հաշվետվությունում գլխագիր տողի ավելացում թավ տառաոճով
        var formattedText = TextReport.ApplyStyle("Փաստաթղթերի հեռացման սխալներ".ToArmenianANSI(), TextReportStyle.Bold);
        report.AddHeader(formattedText);

        // DPR-ի կատարման պրոգրեսի պատուհանում "Հարցման կատարում" անունով փուլի ավելացում
        this.Progress.Add("Հարցման կատարում".ToArmenianANSI());
        var isns = request.DocumentIsns;

        // պրոգրեսի ընթացիկ փուլում մշակվող տվյալների քանակը տալով
        // պրոգրեսի պատուհանում հնարավոր է ցույց տալ մշակման ենթակա տվյալներից քանիսն են մշակվել
        this.Progress.CurrentPhase.Total = isns.Count;

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
                //հերթական փաստաթղթի մասնակի հեռացում
                await this.documentService.Delete(isn, false, "Փաստաթղթի հեռացում".ToArmenianANSI());
            }
            catch (Exception ex)
            {
                report.AddRow($"Առաջացել է սխալ {0} փաստաթղթի ջնջման ժամանակ։".ToArmenianANSI(), isn);

                // առաջացած սխալի հաղորդագրությունների ավելացում որպես տող տեքստային հաշվետվությունում
                foreach (var line in ex.Message.Split('\n'))
                {
                    report.AddRow(line, isn);
                }
                report.AddRow(string.Empty);
            }
        }

        // բոլոր փաստաթղթերի մշակումից հետո հաշվետվությունը պահվում է որպես ֆայլ SaveToStorageAndClose մեթոդի միջոցով,
        // որը վերադարձնում է StorageInfo, որը պարունակում է տվյալներ սերվերից ֆայլը բեռնելու համար
        return await report.SaveToStorageAndClose();
    }
}
```

## DPR-ի սկրիպտից կանչի եղանակ

```vb
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
   ' Մեթոդը վերադարձնում է բուլյան տիպի արժեք, որը ցույց է տալիս արդյոք ընդհատվել է DPR-ի կանչը UI-ից
   ' Ընդհատվելու դեպքում առաջացվում է սխալ
   If Not ExecuteDPR(DPRType.Other, "DeleteDocByIsnDPR", dictISNs, dictResponse) Then
      BreakError
   End If
	
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
