---
layout: page
title: "IMailService սերվիս" 
tags: mail
---

## Բովանդակություն

- [Ներածություն](#ներածություն)
- [Մեթոդներ](#մեթոդներ)
  - [SendMail](#sendmail)
- [Օրինակ](#օրինակ)


## Ներածություն

IMailService դասը նախատեսված է էլեկտրոնային հաղորդագրություններ ուղարկելու համար։

## Մեթոդներ

### SendMail

```c#
public Task SendMail(MailArgs args)
```

Ուղարկում է էլեկտրոնային հաղորդագրություն (mail) `args` օբյեկտում պարունակվող օգտագատեր(եր)ին։

**Պարամետրեր**

* `args` - [Հաղորդագրությունը և ստացողները նկարագրող դասի օբյեկտ](../types/MailArgs.md)։

## Օրինակ

Հետևյալ օրինակում մշակված է փաստաթղթի ընդլայնման [PostBeforeCommit](../../extensions/definitions/document_extender.md#postbeforecommit) իրադարձության մշակիչը, որը կանչվում է փաստաթղթի տվյալների պահոցում գրանցվելուց անմիջապես հետո, [հաշվարկվում տպելու ձևանմուշի լրացվող արժեքները](ITemplateSubstitutionService.md#getreadytemplatesubstitution), [լրացվում](ITemplateSubstitutionService.md#loadsubstituteandgetcontent) և [ուղարկվում որպես մեյլ](#sendmail) փաստաթուղթը ստեղծողի էլեկտրոնային հասցեին։

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

        // լրացնում է տպելու ձևանմուշը նախապես հաշվարկված տվյալներով և վերադարձնում որպես HTML ֆորմատի տեքստ, 
        //որը հանդիսանալու է ուղարկվող հաղորդագրության տեքստ
        var body = await this.templateSubstitutionService.LoadSubstituteAndGetContent(templateSubstitution.PrintTemplateSubstitution, templateCode, SubstitutionType.HTML);

        var mailArgs = new MailArgs()
        {
            Recipients = userEmails, // հաղորդագրությունը ստացողների էլեկտրոնային հասցեների ցուցակ
            Body = body, // հաղորդագրության տեքստը
            Subject = "Ձեր կողմից ստեղծված պատվեր մատակարարին փաստաթուղթը հաստատվել է:", // հաղորդագրության թեման
            BodyFormat = BodyFormatSE.Html // հաղորդագրության տեքստի ֆորմատը
        };

        // ուղարկում է հաղորդագրությունը նշված էլեկտրոնային հասցեներին 
        await this.mailService.SendMail(mailArgs);
    }       
}
```
