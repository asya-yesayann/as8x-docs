---
title: IParametersService.SetValueWithAdditionalConnection(string, object) մեթոդ
---

```c#
public Task SetValueWithAdditionalConnection(string name, object value)
```

Փոխում է համակարգային պարամետրի արժեքը [լրացուցիչ sql միացման](../IDBService/CreateAdditionalConnection.md) միջոցով։  
Նոր արժեքի և պարամետրի տիպի անհամապատասխանության դեպքում առաջանում է սխալ։  
Պարամետրի սահմանված չլինելու դեպքում առաջանում է սխալ։

**Պարամետրեր**

* `name` - Պարամետրի ներքին անուն (id)։ 
* `value` - Վերագրվող արժեք։
