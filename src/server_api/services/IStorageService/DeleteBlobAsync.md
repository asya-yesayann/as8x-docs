---
title: IStorageService.DeleteBlobAsync(string, string, CancellationToken) մեթոդ
---

```c#
public virtual Task<bool> DeleteBlobAsync(string container, string blobName, CancellationToken cancellationToken = default)
```

Հեռացնում է ֆայլը ժամանակավոր ֆայլերի պահոցից` ըստ անվան և կոնտեյների։ 

**Պարամետրեր**

* `container` - Կոնտեյների անունը։ 
* `blobName` - Ֆայլի անունը` ներառյալ ֆայլի ընդլայնումը։
* `cancellationToken` - Ընդհատման օբյեկտ։
