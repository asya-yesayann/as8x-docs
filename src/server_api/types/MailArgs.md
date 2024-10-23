---
layout: page
title: "MailArgs" 
---

Այս դասը նախատեսված է էլեկտրոնային հասցեներին ուղարկվող հաղորդագրության տեքստի, հատկությունների և ստացողների նկարագրման համար։

Օգտագործվում է [IMailService](../services/IMailService.md).[SendMail](../services/IMailService.md#sendmail) էլեկտրոնային հաղորդագրություն ուղարկելիս։

```c#
public class MailArgs
{
    public BodyFormatSE BodyFormat { get; set; } = BodyFormatSE.Text;
    public ImportanceSE Importance { get; set; } = ImportanceSE.Normal;
    public SensitivitySE Sensitivity { get; set; } = SensitivitySE.Normal;
    public string SmptParameterNamePrefix { get; set; } = string.Empty;
    public string ProfileName { get; set; }
    public IEnumerable<string> Recipients { get; set; }
    public IEnumerable<string> CopyRecipients { get; set; }
    public IEnumerable<string> BlindCopyRecipients { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public string FileAttachments { get; set; }
    public bool RequestReceipt { get; set; }
}
```

**Պարամետրեր**

* `BodyFormat` - Հաղորդագրության տեքստի ձևաչափը։
                 BodyFormatSE.Text - Ստանդարտ, ոչ ֆորմատավորված տեքստ
                 BodyFormatSE.Html - HTML ձևաչափի տեքստ
* `Importance` - Հաղորդագրության կարևորության աստիճանը։
                 ImportanceSE.Low - ցածր կարևորության
                 ImportanceSE.Normal - միջին կարևորության
                 ImportanceSE.High - բարձր կարևորության
* `Sensitivity` - Հաղորդագրության գաղտինության աստիճանը։
                  SensitivitySE.Normal - Ստանդարտ
                  SensitivitySE.Personal - Պարունակում է անձնական տվյալներ
                  SensitivitySE.Private - Պարունակում է անձնական/գաղտնի տվյալներ
                  SensitivitySE.Confidential - Պարունակում է խիստ գաղտնի տվյալներ
* `SmptParameterNamePrefix` - Օգտագործվում է `MailKitMailService`-ով հաղորդագրություն ուղարկելիս։
* `ProfileName` - Պրոֆիլի անունը, որը օգտագործվում է `DBMailService`-ով [Database Mail](https://learn.microsoft.com/en-us/sql/relational-databases/database-mail/database-mail) ուղարկելիս։
* `Recipients` - Հաղորդագրությունը ստացողների էլեկտրոնային հասցեների ցուցակը։
* `CopyRecipients` - Հաղորդագրության պատճենը ստացողների էլեկտրոնային հասցեների ցուցակը։
* `BlindCopyRecipients` - Հաղորդագրության պատճենը ստացողների էլեկտրոնային հասցեների ցուցակը, որոնց չեն տեսնելու այն էլեկտրոնային հասցեները (`Recipients`, `CopyRecipients`), որոնց նույնպես ուղարկվելու է հաղորդագրությունը։
* `Subject` - Հաղորդագրության թեման։
* `Body` - Հաղորդագրության տեքստը։
* `FileAttachments` - Հաղորդագրության կցվող ֆայլերի ամբողջական ճանապարհները։ Մի քանի ֆայլ կցելու դեպքում անհրաժեշտ է ճանապարհները իրարից անջատել `;` նշանով։
* `RequestReceipt` - Ցույց է տալիս, արդյոք հաղորդագրություն ուղարկողը կստանա ծանուցում ստացող(ներ)ի կողմից հաղորդագրությունը բացելիս։
