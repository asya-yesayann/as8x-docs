---
title: IDocumentService.Copy(int, object, int) մեթոդ
---

```c#
public Task<Document> Copy(int isn, object beforeCopyParam = null, int copyDocMode = 0)
```

Ստեղծում է արդեն գոյություն ունեցող փաստաթղթի պատճեն օբյեկտը։
Տրված ISN-ով փաստաթուղթը բեռնում է տվյալների պահոցից, որի հիման վրա ստեղծում է պատճեն օբյեկտը։

**Պարամետրեր**

* `isn` - Պատճենման ենթակա փաստաթղթի ներքին նույնականացման համար:
* `beforeCopyParam` - Տվյալ պարամետրի արժեքը փոխանցվում է փաստաթղթի [BeforeCopy](../../definitions/document.md#beforecopy) իրադարձության մշակիչին։ 
* `copyDocMode` - Փաստաթղթի պատճենման ռեժիմ։ 
  `0` - Պատճենվում են բոլոր դաշտերի արժեքները։  
  `1` - Պատճենման ռեժիմը կախված է փաստաթղթի նկարագրության [CopyAsRepeatable](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Defs/doc.md) հատկության արժեքից։  
  `2` - Պատճենվում են միայն այն դաշտերը, որոնք պարունակում են `N` հայտանիշը։
