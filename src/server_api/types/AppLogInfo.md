---
layout: page
title: "AppLogInfo" 
---

Այդ դասը նախատեսված է հատուկ իրադարձության (տարբերակի փոփոխություն, Debug-ի գործարկում...) մանրամասների նկարագրման համար։

Օգտագործվում է [AppLogService](../services/AppLogService.md).[Write](../services/AppLogService.md) մեթոդում։

```c#
public class AppLogInfo
{
    public string ModuleCode { get; set; }
    public string OperationCode { get; set; }
    public string Comment { get; set; }
    public int ObjectISN { get; set; }
    public int BaseISN { get; set; }
}
```

* `ModuleCode` - Հատուկ իրադարձության մոդուլի կոդ։
* `OperationCode` - Հատուկ իրադարձության գործողության կոդ։
* `Comment` - Հատուկ իրադարձությունը նկարագրող մեկնաբանություն։
* `ObjectISN` - Իրադարձությունը իրականացրած երկրորդային փաստաթղթի ներքին նույնականացման համար (isn)։
* `BaseISN` - Իրադարձությունը իրականացրած հիմքային փաստաթղթի ներքին նույնականացման համար (isn)։
