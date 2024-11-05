---
layout: page
title: "Օրինակ ITemplateSubstitutionService" 
sublinks:
- { title: "Օրինակ IMailService, PostBeforeCommit", ref: օրինակ-1 }
---

## Բովանդակություն
- [ITemplateSubstitutionService, IMailService, PostBeforeCommit օգտագործման օրինակ](#օրինակ-1)

## Օրինակ 1

ITemplateSubstitutionService, IMailService, PostBeforeCommit օգտագործման օրինակ։

Հետևյալ օրինակում մշակված է փաստաթղթի ընդլայնման [PostBeforeCommit](../../extensions/definitions/document_extender.md#postbeforecommit) իրադարձության մշակիչը, որը կանչվում է փաստաթղթի տվյալների պահոցում գրանցվելուց անմիջապես հետո, այդ փաստաթղթի համար հաշվարկվում է [տպելու ձևանմուշի լրացվող արժեքները](ITemplateSubstitutionService.md#getreadytemplatesubstitution), [լրացնում](ITemplateSubstitutionService.md#loadsubstituteandgetcontent) է նախապես որոշված HTML ձևանմուշում, ապա ստեղծում է էլ.նամակ որի մարիմը ձևավորված HTML-ն է և [ուղարկվում](#sendmail) է այն փաստաթուղթը ստեղծողի էլեկտրոնային հասցեին։

```c#
public override async Task PostBeforeCommit(Document document, BeforeCommitEventArgs args)
{
    if (document is { Description.DocType: "SOOrder" } orderDocument)
    {
        var templateCode = "Order_Purchase"; //HTML ձևանմուշ

        // ստանում է փաստաթուղթը ստեղծողի էլեկտրոնային հասցեն
        var userEmail = await this.parametersService.EmailAddress(orderDocument.CreatorSUID);

        // հաշվարկում է տպելու ձևանմուշի լրացվող արժեքները 
        var ts = await this.templateSubstitutionService.GetReadyTemplateSubstitution(
            orderDocument, templateCode, SubstitutionType.HTML, null);

        // լրացնում է տպելու ձևանմուշը նախապես հաշվարկված տվյալներով և վերադարձնում որպես HTML ֆորմատի տեքստ, 
        //որը հանդիսանալու է ուղարկվող հաղորդագրության տեքստ
        var body = await this.templateSubstitutionService.LoadSubstituteAndGetContent(
            ts.PrintTemplateSubstitution, templateCode, SubstitutionType.HTML);

        var mailArgs = new MailArgs()
        {
            Recipients = [userEmail], // էլ.նամակը ստացողների էլ.հասցեների ցուցակ
            Subject = "Ձեր կողմից ստեղծված պատվեր մատակարարին փաստաթուղթը հաստատվել է:", // էլ.նամակի թեման
            BodyFormat = BodyFormatSE.Html, // էլ.նամակի տեքստի ձևաչափը
            Body = body, // էլ.նամակի մարմինը/տեքստը
        };

        // ուղարկում է էլ.նամակը
        await this.mailService.SendMail(mailArgs);
    }
}
```
