---
title: TemplateService.GetRowId(string, string) մեթոդ
---

```c#
public Task<int> GetRowId(string name, string type)
```

Վերադարձնում է տպելու ձևանմուշի ներքին նույնականացման համարը (rowId) տվյալների պահոցի `TEMPLATES` աղյուսակից՝ ըստ տպելու ձևանմուշի ներքին անվան և տիպի։

**Պարամետրեր**

* `name` - Տպելու ձևանմուշի ներքին անուն:
* `type` - [Տպելու ձևանմուշի տիպ][4XTemplateSubstitution]: