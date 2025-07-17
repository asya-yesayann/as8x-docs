---
title: IDocumentService.FieldToAnsi(string, string, object) մեթոդ
---

```c#
public  Task<object> FieldToAnsi(string docType, string name, object value)
```

<!-- Վերադարձնում է փաստաթղթի դաշտի արժեքը՝ձևափոխված համապատասխան լեզվի ANSI կոդավորման։ -->
Ձևափոխում է ցանցով փոխանցված արժեքը ANSI կոդավորման համարելով, որ այն պետք է լինի փաստաթղթի դաշտի արժեք։  

Հաշվի է առնվում  
- դաշտը լրացվում է հայերեն, թե ռուսերեն,
- փոխանցող կլինետը օգտագործում է յունկոդ տվյալներ, թե ANSI տվյալներ։

**Պարամետրեր**

* `docType` - Փաստաթղթի ներքին անունը (տեսակը)։  
* `name` - Դաշտի ներքին անուն։
* `value` - Ցանցով փոխանցված արժեք։

**Օրինակ**
Երբ ունենք [Տվյալների մշակման հարցում](../../definitions/dpr.md), որը պարամետրեր է ստանում թե՛ յունիկոդով աշխատող կիենտից, թե՛ ANSI-ով աշխատող կլիենտից, ապա ստացված պարամետրերը կարիք է լինում ձևափոխել ANSI-ի կախված կլիենտի տեսակից։

<!-- CreateFinalCalculationsForSelectedRows DPR-ի մեջ  -->
**Օրինակ**
```c#
private async Task CreateVacationFromHR(Request.EmployeeFinalCalculation emplData, Request request)
{
    var docWgLvOrd = await this.documentService.Create<WgLvOrd>();
    docWgLvOrd.Code.Value = (string)await this.documentService.FieldToAnsi(nameof(WgLvOrd), nameof(WgLvOrd.Code), emplData.EmployeeNumber);
    docWgLvOrd.LvScheme.Value = (string)await this.documentService.FieldToAnsi(nameof(WgLvOrd), nameof(WgLvOrd.LvScheme), request.LeaveScheme);
    docWgLvOrd.fCalc.Value = true;
    docWgLvOrd.DedReCalc.Value = emplData.FinalCalculationDays < 0;
    docWgLvOrd.bPlan.Value = "f";
    docWgLvOrd.BuildEmbeddedUIRequest(this.Progress);
    await docWgLvOrd.Store();
}
```
