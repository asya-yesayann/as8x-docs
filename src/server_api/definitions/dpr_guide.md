---
layout: page
title: "Տվյալների մշակման հարցման (DPR) նկարագրման ձեռնարկ"
tags: [DPR]
sublinks:
- { title: "Օժանդակ դասերի սահմանում", ref: օժանդակ-դասերի-սահմանում }
- { title: "Հիմնական դասի սահմանում", ref: հիմնական-դասի-սահմանում }
- { title: "Կոնստրուկտորի ձևավորում", ref: կոնստրուկտորի-ձևավորում }
- { title: "Execute", ref: execute }
---

## Բովանդակություն

- [Ներածություն](#ներածություն)
 - [C# ֆայլի նկարագրություն](#c-ֆայլի-նկարագրություն)
  - [Օժանդակ դասերի սահմանում](#օժանդակ-դասերի-սահմանում)
  - [Հիմնական դասի սահմանում](#հիմնական-դասի-սահմանում)
  - [Կոնստրուկտորի ձևավորում](#կոնստրուկտորի-ձևավորում)
  - [Execute](#execute)

## Ներածություն

Սերվիսային երկար տևող հարցումներ կատարելու և կատարման ընթացքին հետևելու համար նկարագրվում է Տվյալների մշակման հարցում (DPR - Data Processing Request): 
Տե՛ս [Ասինխրոն մշակում կիրառությունների սերվերի վրա](../../architecture/appserver_async.md)։

Տվյալների մշակման հարցման նկարագրության համար հարկավոր է իրականացնել սերվերում աշխատող տրամաբանությունը C# դասում (`.cs` ֆայլում)։  
Հարկավոր է սահմնել մուտքային և ելթային պարամետրերի դասեր (կարող ենք օգտագործվել գոյություն ունեցողները)։

Կազմակերպության սեփական Տվյալների մշակման հարցումների ստեղծման համար տե՛ս [այստեղ](../../extensions/definitions/dpr_new_guide.md):

## C# ֆայլի նկարագրություն

Ձեռնարկի ամբողջական կոդը ինչպես նաև սկրիպտից կանչի ձևը տե՛ս [այստեղ](../examples/dpr/code.cs):

### Օժանդակ դասերի սահմանում

- Ստեղծել հարցման կատարման համար անհրաժեշտ պարամետրերը նկարագրող դաս։
  ```c#
  public class DeleteDocsByIsnRequest
  {
      public List<int> DocumentIsns { get; set; }
  }
  ```

- Ստեղծել հարցման կատարման արդյունքում ստացվող տվյալները նկարագրող դասը։
  ```c#
  public class DeleteDocsByIsnResponse
  {
      public StorageInfo StorageInfo { get; set; }
  }
  ```

### Հիմնական դասի սահմանում

- Հայտատարել դաս, որը ունի `DPR` ատրիբուտը և ժառանգում է `DataProcessingRequest<R, P>` դասը՝ որպես `R` փոխանցելով հարցման կատարման արդյունքում ստացվող տվյալները նկարագրող դասը, իսկ որպես `P`՝ պարամետրերը նկարագրող դասը։ 
  Պարամետրերի բացակայության դեպքում անհրաժեշտ է փոխանցել `NoParam` դասը, իսկ արդյունքի բացակայության դեպքում՝ `NoResult` դասը։
  ```c#
  [DPR(DPRType = DPRType.Other, ArmenianCaption = "Փաստաթղթերի հեռացում", EnglishCaption = "Deletion of documents")]
  public class DeleteDocsByIsnDPR : DataProcessingRequest<DeleteDocsByIsnResponse, DeleteDocsByIsnRequest>
  ```
  `DPR` ատրիբուտում հարկավոր է նշել տեսակը, հայերեն անվանումը յունիկոդ կոդավորմամբ և անգլերեն անվանումը։

### Կոնստրուկտորի ձևավորում

- Ձևավորել կոնստրուկտորը, որտեղ անհրաժեշտ է [ինյեկցիա](../../project/injection.md) անել աշխատանքի համար անհրաժեշտ սերվիսները։
  ```c#
  private readonly IDocumentService documentService;
  private readonly IStorageService storageService;
  
  public DeleteDocsByIsnDPR(IDocumentService documentService, IStorageService storageService)
  {
      this.documentService = documentService;
      this.storageService = storageService;
  }
  ```

### Execute

Հիմնական տրամաբանությունը հարկավոր է իրականացնել [Execute](dpr.md#execute) մեթոդում, այն ստանում է մուտքային պարամետրերը նկարագրող դասը և պետք է վերադարձնի կատարման արդյունքում ստացվող տվյալները նկարագրող դասը։

Ստորև օրինակում նկարագրված Տվյալների մշակման հարցումը հեռացնում է կատարման պարամետրում տրված ISN-ներով փաստաթղթերը համակարգից [IDocumentService](../services/IDocumentService.md).[Delete](../services/IDocumentService.md#delete) մեթոդի միջոցով, ստեղծում է [TextReport](../types/TextReport.md), որում լրացնում է կատարման ընթացքում առաջացած սխալները և վերադարձնում է կլիենտին։

```c#
public override async Task<DeleteDocsByIsnResponse> Execute(DeleteDocsByIsnRequest request, CancellationToken stoppingToken)
{
    // սխալների հավաքագրման համար տեքստային հաշվետվության ստեղծում
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
```
