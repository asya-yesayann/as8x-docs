---
title: IKernelService.GetExchangeRate(string, DateTime, DateTime?) մեթոդ
---

```c#
public Task<ExchangeRate> GetExchangeRate(string codCurrency, 
                                          DateTime date, 
                                          DateTime? maxCreationDate = null)
```

Վերադարձնում է արտարժույթի ՀՀ ԿԲ փոխարժեքը։
Եթե նշված ամսաթվին արտարժույթը բացակայում է, ապա բերվում է արտարժույթի վերջին առկա տվյալը։

**Պարամետրեր**

* `codCurrency` - Արտարժույթի կոդ։
* `date` - Փոխարժեքի նշանակման ամսաթիվ/ժամանակ։
* `maxCreationDate` - Փոխանցված լինելու դեպքում մեթոդը փնտրում է փոխարժեք, որի նշանակման ամսաթիվը չի գերազանցում փոխանցված ամսաթիվը:
