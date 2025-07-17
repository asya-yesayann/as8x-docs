---
title: TemplateService.GetPrintDataGroups(string) մեթոդ
---

```c#
public Task<List<DocumentPrintDataGroupDefinition>> GetPrintDataGroups(string docType)
```

Վերադարձնում է նշված տեսակի փաստաթղթին կապակցված տպելու ձևանմուշների տվյալների խմբերի նկարագրությունների ցուցակը։

Տվյալների խմբերը օգտագործվում են այն ձևանմուշներում, որոնք պարունակում են մեծ քանակությամբ կոդեր՝ նպատակ ունենալով կոդերը բաժանել խմբերի և հաշվարկել միայն անհրաժեշտ մասը։

Տես նա՛և [PrintDataGroup](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/PrintDataGroup.html):

**Պարամետրեր**

* `docType` - Փաստաթղթի տեսակ (ներքին անուն)։
