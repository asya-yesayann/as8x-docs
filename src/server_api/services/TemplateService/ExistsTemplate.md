---
title: TemplateService.ExistsTemplate(string, string) մեթոդ
---

```c#
public Task<bool> ExistsTemplate(string name, string type)
```

Ստուգում է տպելու ձևանմուշի նկարագրության առկայությունը տվյալների պահոցի `TEMPLATES` աղյուսակում։

**Պարամետրեր**

* `name` - Տպելու ձևանմուշի ներքին անուն:
* `type` - [Տպելու ձևանմուշի տիպ][4XTemplateSubstitution]:

**Օրինակ**

```c#
// templateNameType  =>  "AgrState\7"

var (_, templateName, templateType) = TemplateService.GetTemplateNameAndType(templateNameType);
if (!await templateService.ExistsTemplate(templateName, templateType))
{
  throw new RESTException(string.Format("'{0}' անունով և '{1}' տիպով ձևանմուշ գոյություն չունի".ToArmenianANSI(), templateName, templateType));
}
```

<!-- ### GetCount

```c#
public Task<int> GetCount(string name)
```

Վերադարձնում է նշված ներքին անունով տպելու ձևանմուշների քանակը։

**Պարամետրեր**

* `name` - Տպելու ձևանմուշի ներքին անուն:
