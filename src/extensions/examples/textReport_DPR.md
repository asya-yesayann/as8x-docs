---
layout: page
title: "Տեքստային հաշվետվության տվյալների մշակման հարցման (DPR-ի) օրինակ" 
---

Այս օրինակում բերված են DPR-ի տեքստային հաշվետվության նկարագրման համար անհրաժեշտ սերվերային տրամաբանությունը պարունակող c# ֆայլը և սկրիպտից կանչման եղանակը։

## DPR-ի նկարագրություն

```c#
using ArmSoft.AS8X.Bank.Subsystems.DAL;
using ArmSoft.AS8X.Bank.UserProxy;
using ArmSoft.AS8X.Common;
using ArmSoft.AS8X.Common.Extensions;
using ArmSoft.AS8X.Core;
using ArmSoft.AS8X.Core.Document;
using ArmSoft.AS8X.Core.DPR;
using ArmSoft.AS8X.Core.Storage;
using ArmSoft.AS8X.Core.TextReport;
using ArmSoft.AS8X.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ArmSoft.AS8X.Bank.Samples.ExampleDPRTextReport;

public class ExampleTextReportDPRRequest
{
    public int DocumentIsn { get; set; }
}

[DPR(DPRType = DPRType.Report, ArmenianCaption = "Տեստային հաշվետվություն 1", EnglishCaption = "Test report 1")]
public class ExampleTextReportDPR : DataProcessingRequest<StorageInfo, ExampleTextReportDPRRequest>
{
    private readonly IStorageService storageService;
    private readonly AgrService agrService;
    private readonly IDocumentService documentService;
    private readonly UserProxyService proxyService;

    public const char Vertical = '‹'; // │
    public const char Horizontal = '‰'; // ─
    public const char Cross = 'Š'; // ┼
    public const char DownRight = '‚'; // ┌
    public const char UpRight = '‡'; // └
    public const char DownLeft = 'ƒ'; // ┐
    public const char UpLeft = 'ˆ'; // ┘
    public const char RightVertical = '†'; // ├
    public const char LeftVertical = '…'; // ┤
    public const char UpHorizontal = '„'; // ┴
    public const char DownHorizontal = 'Œ'; // ┬

    public ExampleTextReportDPR(IStorageService storageService, AgrService agrService,
                            IDocumentService documentService, UserProxyService proxyService)
    {
        this.storageService = storageService;
        this.agrService = agrService;
        this.documentService = documentService;
        this.proxyService = proxyService;
    }

    public async override Task<StorageInfo> Execute(ExampleTextReportDPRRequest request, CancellationToken stoppingToken)
    {
        const int lenCaptionCell = 23;
        const int lenAgrCodeCell = 17;

        var parentDoc = await this.agrService.GetAgrDoc(await this.documentService.Load(request.DocumentIsn));

        using var testRep = new TextReport(this.storageService);
        testRep.AddFragment(100);
        testRep.UseFormatting = true;
        testRep.DocBased = true;
        testRep.ArmenianCaption = "Համավարկառուների մանկ. չափ".ToArmenianANSI();
        testRep.AddHeader("Գրաֆիկով վարկային պայմանագրի համավարկառուների մասնկ. չափը".ToArmenianANSI());
        testRep.AddFooter("Աղյուսակը տրված է առ՝ ".ToArmenianANSI() + proxyService.WKDATE().FormatDDMMYY());
        testRep.AddRow(DownRight + new string(Horizontal, lenCaptionCell) +
                          DownHorizontal + new string(Horizontal, lenCaptionCell) +
                          DownLeft);
        testRep.AddRow((Vertical + TextReport.ApplyStyle("Անվանում".ToArmenianANSI().PadRight(lenCaptionCell), TextReportStyle.Bold) +
                          Vertical + TextReport.ApplyStyle("Պայմանագիր".ToArmenianANSI().PadRight(lenCaptionCell), TextReportStyle.Bold) +
                          Vertical));
        testRep.AddRow(RightVertical + new string(Horizontal, lenCaptionCell) +
                          Cross + new string(Horizontal, lenCaptionCell) +
                          LeftVertical);
        testRep.AddRow(Vertical + parentDoc["NAME"].ToString().PadRight(lenCaptionCell) +
                          Vertical + parentDoc["CODE"].ToString().PadRight(lenCaptionCell) +
                          Vertical);
        testRep.AddRow(UpRight + new string(Horizontal, lenCaptionCell) +
                          UpHorizontal + new string(Horizontal, lenCaptionCell) +
                          UpLeft);
        testRep.AddRow("Կնքման ամսաթիվ՝ ".ToArmenianANSI() + " " + ((DateTime)parentDoc["DATE"]).FormatDDMMYY());
        testRep.AddRow("");
        testRep.Break();
        testRep.AddRow("");
        testRep.AddRow(DownRight + TextReport.ApplyStyle("Համավարկառուներ".ToArmenianANSI() + new string(Horizontal, 8), TextReportStyle.Bold) +
                          DownHorizontal + TextReport.ApplyStyle("Մասն.չափ".ToArmenianANSI() + new string(Horizontal, 9), TextReportStyle.Bold) +
                          DownLeft);
        testRep.AddRow(RightVertical + new string(' ', 23) +
                          Vertical + new string(' ', 17) +
                          LeftVertical);
        if (parentDoc.ExistsGrid("CODEBTORS"))
        {
            for (int i = 0; i < parentDoc.Grid("CODEBTORS").RowCount; i++)
            {
                var cliDesc = await this.proxyService.LoadClientDescByCode(parentDoc.Grid("CODEBTORS")[i]["CLICOD"].ToString());
                if (cliDesc != null)
                {
                    testRep.AddRow(Vertical + cliDesc.Caption.PadRight(lenCaptionCell) +
                          Vertical + $"{parentDoc.Grid("CODEBTORS")[i]["PROPORTION"]} %".PadRight(lenAgrCodeCell) +
                          Vertical);
                }
            }
        }
        testRep.AddRow(UpRight + new string(Horizontal, lenCaptionCell) +
                          UpHorizontal + new string(Horizontal, lenAgrCodeCell) +
                          UpLeft);
        testRep.AddRow(Horizontal + "Կնքման ամսաթիվ՝ ".ToArmenianANSI() + " " + ((DateTime)parentDoc["DATE"]).FormatDDMMYY() +
                          new string(Horizontal, lenAgrCodeCell));

        return await testRep.SaveToStorageAndClose();
    }
}
```

## DPR-ի սկրիպտից կանչի եղանակ

```vb
Public Sub ExecuteTestReport()
	Dim dictRequest As Dictionary
	Dim dictResponse As Dictionary
	Dim oStorageInfo As StorageInfo
	Dim oRepViewer As AsRepViewer


	Set dictRequest = New Dictionary
	dictRequest.Add("DocumentIsn", 1855129777)

	Set dictResponse = New Dictionary

	If Not ExecuteDPR(DPRType.Report, "ExampleTextReportDPR", dictRequest, dictResponse) Then
		BreakError
	End If
	oStorageInfo.BlobName = dictResponse("BlobName")
	oStorageInfo.Container = dictResponse("Container")

	Set oRepViewer = CreateRepViewer()
	oRepViewer.LoadFromStorageInService(oStorageInfo)

	oRepViewer.Show()
End Sub
```
