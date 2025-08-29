---
title: "Մեկ ֆայլում մի քանի ընդլայնում ավելացնելու ձեռնարկ" 
---

Տրվել է հնարավորություն Syscon գործիքով ներմուծվող ֆայլերում ավելացնել մի քանի [ընդլայնում](../../extensions.md) և ունենալ ընդհանուր տրամաբանությունը պարունակող բազային դաս, որից կժառանգվեն ընդլայնումները նկարագրող դասերը։

Անհրաժեշտ է՝
* ստեղծել .cs ընդլայնմամբ ֆայլ, որը պարունակում է [ընդլայնումները](../../extensions.md) նկարագրող դասերը և ընդհանուր տրամաբանությունը պարունակող բազային դասը,
* յուրաքանչյուր դասին համապատասխան ատրիբուտում ավելացնել այն նկարագրության ներքին անունը, որը ընդայնվելու է (օրինակ [DocumentExtender("C1Univer")]):
* ստեղծել բոլոր նկարագրությունների մետատվյալները պարունակող .as ընդլայնմամբ ֆայլ, որպեսզի .cs ընդլայնմամբ ֆայլում փոփոխություններ կատարելիս անհրաժեշտ լինի ներմուծել միայն նշված ֆայլը:

Հնարավոր է ստեղծել նաև մեկական .as ֆայլ՝ յուրաքանչյուր նկարագրության համար։

**Օրինակ**

```as4x
DOCUMENTEXTENDER {
  NAME = "Doc1";
  CAPTION = "Doc1 փաստաթղթի ընդլայնում"; 
  ECAPTION = "Doc1 document's extension";
  CSSOURCE = "Extenders.cs";
};

DOCUMENTEXTENDER {
  NAME = "Doc2";
  CAPTION = "Doc2 փաստաթղթի ընդլայնում"; 
  ECAPTION = "Doc2 document's extension";
  CSSOURCE = "Extenders.cs";
};
```

```c#
public class ExtendersBase : DocumentExtender
{
    public override Task PostDeserializeComplexObjectsProperties(Document sender, DeserializeComplexObjectsEventArgs args)
    {
        if (args.ComplexObjectsJson.ContainsKey("ParentLinks"))
        {
            sender.Properties.Add("ParentLinks", args.Deserialize<int[]>("ParentLinks"));
        }
        return Task.CompletedTask;
    }
}

[DocumentExtender("Doc1")]
public class Doc1Extended : ExtendersBase
{
    public override Task PostValidate(Document sender, ValidateEventArgs args)
    {
        if (sender is Doc1 document)
        {
            if (document.AutoNumber.Value == "111")
            {
                throw new InvalidOperationException("Համարանիշը չի կարող լինել 111");
            }
        }
        return Task.CompletedTask;
    }
}


[DocumentExtender("Doc2")]
public class Doc2Extended : ExtendersBase
{
    private readonly ISessionInfoService sessionInfoService;
    public Doc2Extended(ISessionInfoService sessionInfoService)
    {
        this.sessionInfoService = sessionInfoService;
    }

    public override Task PreDelete(Document sender, DeleteEventArgs args)
    {
        var isAdminUser = this.sessionInfoService.GetInfo().IsAdmin;
        if (sender.State.InList(2, 3) && !isAdminUser)
        {
            throw new RESTException("Պայմանագիրը հեռացնելու իրավասություն չունեք".ToArmenianANSI());
        }
        return Task.CompletedTask;
    }
}
```