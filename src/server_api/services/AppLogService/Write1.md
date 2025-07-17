---
title: AppLogService.Write(string, string, string, int, int) մեթոդ
---

```c#
public Task Write(string moduleCode, string operationCode, string comment, int objectISN, int baseISN)
```

Գրանցում է հատուկ իրադարձության (տարբերակի փոփոխություն, Debug-ի գործարկում...) մանրամասները տվյալների պահոցում։

**Պարամետրեր**

* `moduleCode` - Իրադարձության մոդուլի կոդ։
* `operationCode` - Իրադարձության գործողության կոդ։
* `comment` - Իրադարձությունը նկարագրող մեկնաբանություն։
* `objectISN` - Իրադարձությունը իրականացրած երկրորդային փաստաթղթի ներքին նույնականացման համար (isn)։
* `baseISN` - Իրադարձությունը իրականացրած հիմքային փաստաթղթի ներքին նույնականացման համար (isn)։
