---
title: TemplateService.Copy(TemplateDefinition) մեթոդ
---

```c#
public Task<int> Copy(TemplateDefinition definition)
```

Պատճենում է `definition` պարամետրում նշված տպելու ձևանմուշի նկարագրությունը, գրանցում տվյալների պահոցի `TEMPLATES` աղյուսակում և վերադարձնում գրանցված նկարագրության ներքին նույնականացման համարը (rowId):

**Պարամետրեր**

* `definition` - Պատճենման ենթակա տպելու ձևանմուշի նկարագրությունը։
