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
    await docWgLvOrd.SetEmployeeData();
    docWgLvOrd.DateR.NullableValue = request.OrderDate;
    docWgLvOrd.Number.Value = (string)await this.documentService.FieldToAnsi(nameof(WgLvOrd), nameof(WgLvOrd.Number), request.OrderNumber);
    docWgLvOrd.DateS.Value = request.FinalCalculationDate;
    docWgLvOrd.DateE.Value = request.FinalCalculationDate;
    docWgLvOrd.DateSC.Value = new DateTime(request.AverageYear, request.AverageMonth, 1);
    docWgLvOrd.CalcDate.Value = new DateTime(request.CalculationYear, request.CalculationMonth, 1);
    docWgLvOrd.LvType.Value = (string)await this.documentService.FieldToAnsi(nameof(WgLvOrd), nameof(WgLvOrd.LvType), request.LeaveType);
    docWgLvOrd.LvScheme.Value = (string)await this.documentService.FieldToAnsi(nameof(WgLvOrd), nameof(WgLvOrd.LvScheme), request.LeaveScheme);
    docWgLvOrd.TabType.Value = request.DaysCalculationType;
    docWgLvOrd.fCalc.Value = true;
    docWgLvOrd.fDni.Value = Math.Abs(emplData.FinalCalculationDays);
    docWgLvOrd.DedReCalc.Value = emplData.FinalCalculationDays < 0;
    docWgLvOrd.Coment.Value = (string)await this.documentService.FieldToAnsi(nameof(WgLvOrd), nameof(WgLvOrd.Coment), request.Comment);
    docWgLvOrd.bPlan.Value = "f";
    docWgLvOrd.Dni.Value = (short)Math.Abs(emplData.FinalCalculationDays);
    docWgLvOrd.MaxDni.Value = (short)Math.Abs(emplData.FinalCalculationDays);
    docWgLvOrd.SetPeriodAndYear();
    docWgLvOrd.bISN.Value = docWgLvOrd.ISN;
    docWgLvOrd.Property_LeaveGr = true;
    docWgLvOrd.Property_DontCheckPeriodCrossing = true;
    docWgLvOrd.BuildEmbeddedUIRequest(this.Progress);
    await docWgLvOrd.Store();
}
```
