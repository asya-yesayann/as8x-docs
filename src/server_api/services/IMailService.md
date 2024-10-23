---
layout: page
title: "IMailService սերվիս" 
tags: mail
---

## Ներածություն

IMailService դասը նախատեսված է էլեկտրոնային հաղորդագրություններ ուղարկելու համար։

## Մեթոդներ

### SendMail

```c#
public Task SendMail(MailArgs args)
```

Ուղարկում է էլեկտրոնային հաղորդագրություն (mail) `args` օբյեկտում պարունակվող օգտագատեր(եր)ին։

**Պարամետրեր**

* `args` - Հաղորդագրությունը և ստացողները նկարագրող դասի օբյեկտ։

**Օրինակ**

Հետևյալ օրինակում մշակված է փաստաթղթի ընդլայնման [PostBeforeCommit](../../extensions/definitions/document_extender.md#postbeforecommit) իրադարթության մաշկիչը, որը կանչվում է փաստաթղթի տվյալերի պահոցում գրանցվելուց անմիջապես հետո, հաշվարկվում, լրացվում է փաստաթղթի տպելու ձևանմուշը և ուղարկվում որպես մեյլ փաստաթուղթը ստեղծողի էլեկտրոնային հասցեին։

```c#
public override async Task PostBeforeCommit(Document document, BeforeCommitEventArgs args)
{
    if (document is Doc.SCM.SOOrder orderDocument)
    {
        var templateCode = "Order_Purchase";

        // ստանում է փաստաթուղթը ստեղծողի էլեկտրոնային հասցեն parametersService-ի EMailAddress պարամետրի միջոցով
        var userEmails = new[] { await this.parametersService.EMailAddress(orderDocument.CreatorSUID) };

        // հաշվարկում է տպելու ձևանմուշի լրացվող արժեքները 
        var templateSubstitution = await this.templateSubstitutionService.GetReadyTemplateSubstitution(orderDocument, templateCode, SubstitutionType.HTML, null);

        // լրացնում է տպելու ձևանմուշը նախապես հաշվարված տվյալներով և վերադարնում որպես տեքստ, որը հանդիսանալու է ուղարկվող հաղորդագրության տեքստ
        var body = await this.templateSubstitutionService?.LoadSubstituteAndGetContent(templateSubstitution.PrintTemplateSubstitution, templateCode, SubstitutionType.HTML);

        var mailArgs = new MailArgs()
        {
            Recipients = userEmails, // հաղորդագրությունը ստացողների էլեկտրոնային հասցեների ցուցակ
            Body = body, // հաղորդագրության տեքստը
            Subject = "Ձեր կողմից ստեղծված պատվեր մատակարարին փաստաթուղթը հաստատվել է:", // հաղորդագրության թեման
            BodyFormat = BodyFormatSE.Html // հաղորդագրության ֆորմատը
        };

        // ուղարկում է մեյլը նշված էլեկտրոնային հասցեներին 
        await this.mailService.SendMail(mailArgs);
    }       
}
```


