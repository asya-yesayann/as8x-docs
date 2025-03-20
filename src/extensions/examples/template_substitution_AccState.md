---
layout: page
title: "Տպելու ձևի ընդլայնման օրինակ" 
tags: TemplateSubstitution
---

Ստորև բերված է հաշվի քաղվածքում կիրառվող լրացուցիչ պարամետրերի հաշվարկման համար նախատեսված դասը։ 
Ի տարբերություն այլ դեպքերի ՀԾ-Բանկում հաշվի քաղվածքում նոր պարամետրեր ավելացնելուց արժեքը պետք է լինի Unicode կոդավորմամբ, երբ ձևանմուշը պետք է արտահանվի Unicode, այսինքն գրեթե միշտ։

Օրինակում օգտագործվում է [UserProxyService](../bank/user_proxy_service.md), որը հասանելի է միայն ՀԾ-Բանկում։

```c#
using ArmSoft.AS8X.Bank.General.Account.DOCS;
using ArmSoft.AS8X.Bank.UserProxy;
using ArmSoft.AS8X.Common.Extensions;
using ArmSoft.AS8X.Core.Templates;
using System.Threading.Tasks;

namespace ArmSoft.AS8X.Bank.CustomerSpecific.MyCompany
{
    [TemplateSubstitutionExtender]
    public class AccStateAdr_stamp : ITemplateSubstitutionExtender 
    {
        private readonly UserProxyService proxyService;

        public AccStateAdr_stamp(UserProxyService proxyService)
        {
            this.proxyService = proxyService;
        }

        public async Task Calculate(TemplateSubstitutionExtenderArgs args)
        {
            //Վերադարձնում է այն փաստաթուղթը, որի վրայից տպվում է քաղվածքը։ Այս դեպքում հաշիվը
            var accountDoc = (Account)args.Document;

            //Վերադարձնում է հաճախորդ փաստաթուղը
            var cliDoc = await this.proxyService.LoadClientDoc(accountDoc.CLICOD);

            //Ստեղծում է հասցեի տպելու պարամետր
            await proxyService.TryAddAtomicAsync("hasce", async () =>
            {
                var marz = cliDoc.DISTRICT != "001" ? (await this.proxyService.TreeElPropComment("LRDistr", cliDoc.DISTRICT)) + ", " : "";
                var bnakavayr = cliDoc.DISTRICT != "001" ? (await this.proxyService.TreeElPropComment("COMMUNTY", cliDoc.COMMUNITY)) + ", " : "";
                var index = cliDoc.POSTIND != "" ? ", Փոստային ինդեքս` ".ToArmenianANSI() + cliDoc.POSTIND : "";
                return (marz + cliDoc.CITY + ", " + bnakavayr + cliDoc.ADDRESS + index).ToArmenianUnicode();
            }, args);

            //Ստեղծում է անգլերեն հասցեի տպելու պարամետր
            await proxyService.TryAddAtomicAsync("ehasce", async () =>
            {
                var emarz = cliDoc.DISTRICT != "001" ? (await this.proxyService.TreeElPropEComment("LRDistr", cliDoc.DISTRICT)) + ", " : "";
                var ebnakavayr = cliDoc.DISTRICT != "001" ? (await this.proxyService.TreeElPropEComment("COMMUNTY", cliDoc.COMMUNITY)) + ", " : "";
                var eindex = cliDoc.POSTIND != "" ? "Post Index " + cliDoc.POSTIND : "";
                return emarz + cliDoc.ECITY + ", " + ebnakavayr + cliDoc.EADDRESS + eindex;
            }, args);
        }
    }
}
```
