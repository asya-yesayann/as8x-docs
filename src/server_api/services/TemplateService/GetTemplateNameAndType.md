---
title: TemplateService.GetTemplateNameAndType(string, bool) մեթոդ
---

```c#
public static (bool result, string templateName, string templateType) 
    GetTemplateNameAndType(string templateNameWithType, bool isBackSlash = true)
```

Բաժանում է `templateNameWithType` պարամետրում միավորված տպելու ձևանմուշի ներքին անունը (կոդը) և տիպը:  
Վերադարձնում է՝
* `result` - Ցույց է տալիս, արդյոք բաժանումը հաջողվել է:
* `templateName` - Տպելու ձևանմուշի ներքին անուն: Բաժանման չհաջողվելու դեպքում վերադարձնում է `templateNameWithType` պարամետրի արժեքը։
* `templateType` - [Տպելու ձևանմուշի տիպ][4XTemplateSubstitution]: Բաժանման չհաջողվելու դեպքում վերադարձնում է `string.Empty`։

**Պարամետրեր**

* `templateNameWithType` - Տպելու ձևանմուշի միավորված ներքին անուն (կոդ) և տիպ։
* `isBackSlash` - `true` արժեքի դեպքում բաժանումը կատարվում է ըստ `"\"` նիշի, հակառակ դեպքում՝ ըստ `"/"` նիշի։


**Օրինակ**

```c#
// templateNameType  =>  "AgrState\7"

var (_, templateName, templateType) = TemplateService.GetTemplateNameAndType(templateNameType);
// templateName  =>  "AgrState"
// templateType  =>  "7"

if (templateType != Constants.TempTypeHTML) 
{
  throw new RESTException("Ձևանմուշի տիպը պետք է լինի Html".ToArmenianANSI());
}
```

<!-- ### GetType

```c#
public Task<string> GetType(string name)
```

Վերադարձնում է [տպելու ձևանմուշի տիպը][4XTemplateSubstitution]՝ ըստ տպելու ձևանմուշի ներքին անվան։

**Պարամետրեր**

* `name` - Տպելու ձևանմուշի ներքին անուն:
