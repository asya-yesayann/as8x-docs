---
title: ITemplateSubstitutionService.IsTemplateAvailable(string, string, Document) մեթոդ
---

```c#
public Task<bool> IsTemplateAvailable(
    string templateName, string templateType, Document document)
```

Ստուգում է արդյոք նշված ձևանմուշը հասանելի է նշված փաստաթղթի համար, այսինքն փաստաթղթի տիպը նշված է տպվող ձևանմուշի փաստաթղթերի ցանկում և բավարարվում է ակտիվացման բանաձևը սերվիսում։

**Պարամետրեր**

* `templateName` - Տպելու ձևանմուշի ներքին անունը։
* `templateType` - [Տպելու ձևանմուշի տիպ][4XTemplateSubstitution]:
* `document` - Տպելու ձևանմուշի հետ կապակցված [փաստաթղթի օբյեկտ](../../definitions/document.md)։

**Օգտագործում**

Սերվիսում ակտիվացման բանաձևի սահմանման համար անհրաժեշտ է ստեղծել [սերվերային մոդուլ](../../../extensions/definitions/server_side_module.md), որում C# դաս ու ֆունկցիա, որը հաշվարկում է ակտիվացման բանաձևը։

Ակտիվացման բանաձևը հաշվարկող ֆունկցիայի վերադարձվող արժեքի տիպը պետք է լինի `bool` և որպես պարամետր պետք է ստանա [Document](../../definitions/document.md) դասի օբյեկտ։

Սերվերային մոդուլի և C# դասի լրացումից հետո անհրաժեշտ է սերվերային մոդուլը նկարագրող .as ընդլայնմամբ ֆայլը ներմուծել տվյալների բազա `Syscon` գործիքի միջոցով։

Դասի ու ֆունկցիայի սահմանումից հետո «Փաստաթղթի տպելու ձևանմուշներ» դիտելու ձևում տպելու ձևանմուշի վրայից սեղմելով «Խմբագրել» ֆունկցիայով բացվող պատուհանի «Ակտիվացման բանաձև սերվիսում» դաշտում անհրաժեշտ է այն լրացնել սերվերային մոդուլի անունը, դասի անունը և ֆունկցիայի անւնը՝ իրարից անջատելով կետերով՝ **server_side_module_name.class_name.function_name**:  

Օրինակ՝
``` c#
//SERVERSIDEMODULE { NAME = MyModule;
//public class MyClass {
public bool IsAvailable(Document doc)
```

Ակտիվացման բանաձև սերվիսում կլինի `MyModule.MyClass.IsAvailable`
