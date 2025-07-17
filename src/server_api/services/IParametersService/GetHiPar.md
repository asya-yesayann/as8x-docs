---
title: IParametersService.GetHiPar(string, DateTime, bool, string, bool, DateTime?) մեթոդ
---

```c#
public Task<(string Value, DateTime? SoftDate)> GetHiPar(
    string paramID, DateTime date, bool softGet, string exceptionMessage = "", 
    bool notThrowExeption = false, DateTime? maxCreationDate = null)
```

Վերադարձնում է ժամանակագրական պարամետրի արժեքը և նշանակման ամսաթիվը։

**Պարամետրեր**

* `paramID` - Պարամետրի ներքին անուն (id)։
* `date` - Պարամետրի որոնման ամսաթիվ։
* `softGet` - **true** արժեքի դեպքում մեթոդը ստուգում է `date` ամսաթվի դրությամբ պարամետրի որևէ արժեքի նշանակված լինելը, հակառակ դեպքում՝ միմիայն `date` ամսաթվին նշանակված արժեքի գոյությունը։
* `exceptionMessage` - Արժեքի չգտնելու դեպքում ցույց տրվող սխալի հաղորդագրությունը: 
  Եթե արժեք տրված չէ, ապա կառաջանա ստանդարտ սխալի հաղորդագրություն։ 
* `notThrowExeption` - `true` արժեքի դեպքում տվյալների պահոցում պարամետրի արժեքի բացակայության դեպքում վերադարձնում է դատարկ տող, հակառակ դեպքում առաջացնում է սխալ։
* `maxCreationDate` -	Փոխանցված լինելու դեպքում մեթոդը փնտրում է արժեք, որի նշանակման ամսաթիվը չի գերազանցում փոխանցված ամսաթիվը:
