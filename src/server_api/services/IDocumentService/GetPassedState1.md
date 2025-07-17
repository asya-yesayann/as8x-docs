---
title: IDocumentService.GetPassedState(int, string, bool, bool) մեթոդ
---

```c#
public short GetPassedState(int isn, string statesSubQuery, bool lastState = true, bool inStates = true)
```

Ստուգում է և վերադարձնում փաստաթղթի վերջին կամ առաջին նշանակված վիճակը վիճակների ցուցակը սահմանող sql հարցում արդյունքից։

Համապատասխանող վիճակ չգտնելու դեպքում վերադարձնում է `-1`։


**Պարամետրեր**

* `isn` - Փաստաթղթի ներքին նույնականացման համար։
* `statesSubQuery` - Փաստաթղթի վիճակները սահմանող sql հարցում:
* `lastState` - `true` արժեքի դեպքում վերադարձնում է վերջին նշանակված վիճակը, հակառակ դեպքում՝ առաջինը։
* `inStates` - `true` արժեքի դեպքում փնտրվում է վիճակ, վիճակների ցուցակը սահմանող sql հարցում արդյունքից։ 
  Հակառակ դեպքում՝ արդյունքից դուրս։

**Օրինակ**
```c#
var lastConfirmationState = documentService.GetPassedState(doc.ISN, 
      $"Select fSTATE From DOCLOG WHERE fISN = {doc.ISN} and fSTATE Between 100 and 200");
```
