---
title: "TemplateSubstitutionEventArgs դաս" 
---

## Ներածություն

Այս դասը պարունակում է փաստաթղթի տպելու ձևանմուշի տվյալներ և օգտագործվում է [DocumentExtender](../../definitions/document_extender.md)-ի [PostTemplateSubstitution](../../definitions/document_extender/PostTemplateSubstitution.md), [PostTemplateSubstitutionEx](../../definitions/document_extender/PostTemplateSubstitutionEx.md) մեթոդներում։

Տե՛ս օգտագործման [օրինակը](../../examples/PostTemplateSubstitution.md):

## Հատկություններ 

| Անվանում | Նկարագրություն |
|----------|----------------|
| [Mode](TemplateSubstitutionEventArgs/Mode.md) | Վերադարձնում կամ նշանակում է տպելու ձևանմուշի տվյալների խմբերի և յուրաքանչյուր խմբի թույլատրված լինելու հայտանիշների բազմությունը։ |
| [Parameters](TemplateSubstitutionEventArgs/Parameters.md) | Վերադարձնում կամ նշանակում է փաստաթղթի [TemplateSubstitutionParameters](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/TemplateSubstitutionParameters.html) մեթոդի կանչի արդյունքում ձևավորված տպելու ձևանմուշի լրացվող արժեքների բազմությունը։ |
| [Result](TemplateSubstitutionEventArgs/Result.md) | Վերադարձնում կամ նշանակում է փաստաթղթի [TemplateSubstitution](../../../server_api/definitions/document#templatesubstitution) մեթոդի կանչի արդյունքում ձևավորված տպելու ձևանմուշի լրացվող արժեքների բազմությունը։ |

## Մեթոդներ

| Անվանում | Նկարագրություն |
|----------|----------------|
| [AddSubstitutedFile(StorageInfo)](TemplateSubstitutionEventArgs/AddSubstitutedFile.md) | Մեթոդը տալիս է հնարավորություն փաստաթղթին կապակցված տպելու ձևանմուշը տպելիս տպել նաև այլ ձևանմուշներ։ |