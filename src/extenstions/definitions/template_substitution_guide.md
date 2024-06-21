---
layout: page
title: "Տպելու ձևերի ընդլայնման ձեռնարկ"
---

# Տպելու ձևերի ընդլայնման ձեռնարկ


## 1	Ներածություն

Տպելու ձևանմուշների ընդլայնումը իրականացվում է ծրագրավորման միջոցով օգտագորելով C# լեզուն: Տպելու ձևանմուշի ընդլայնման համար անհրաժեշտ է ստեղծել երկու ֆայլ՝
1.	պարամետրերի հաշվարկի ծրագրերը պարունակող C# ֆայլը,
2.	as ընդլայնումով ֆայլը, որը օգտագործվում է SYSCON ծրագրի կողմից 1-ին կետում նկարագրված ֆայլը ներմուծելիս համար։

Ստեղծված ֆայլերը ներմուծվում են համակարգ օգտագործելով SYSCON ծրագիրը։
Ընդլայնվող տպելու ձևանմուշում օգտագործման ենթակա բոլոր լրացուցիչ պարամետրերը պետք է ծրագրավորված լինեն մեկ ֆայլում։ Միևնույն ընդլայնման ֆայլը կարող են կապակցվել բազմաթիվ տպելու ձևանմուշների։

## 2	C# ֆայլի նկարագրություն
C# ֆայլը կարող է պարունակել մեկ կամ ավել դասեր, որոնց միջոցով իրականացվում է ավելացվող պարամետրերի հաշվարկը։ Դասերը պետք է իրագործած լինեն բոլոր այն լրացուցիչ պարամետրերը, որոնք անհրաժեշտ են կապակցվող ձևանմուշի հիման վրա տպվող ձևի ստացման համար։

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
        public async Task Calculate(TemplateSubstitutionExtenderArgs templateSubstitutionArgs)
        {
            //Վերադարձնում է այն փաստաթուղթը, որի վրայից տպվում է քաղվածքը։ Այս դեպքում հաշիվը
            var accountDoc = (Account)templateSubstitutionArgs.Document;


            //Վերադարձնում է հաճախորդ փաստաթուղը
            var cliDoc = await this.proxyService.LoadClientDoc(accountDoc.CLICOD);


            //Վերադարձնում է հաճախորդ փոստային ինդեքսը
            var index = cliDoc.POSTIND != "" ? ", Փոստային ինդեքս` " + cliDoc.POSTIND : "";

            //Վերադարձնում է հաճախորդ փոստային ինդեքսը անգլերեն
            var eindex = cliDoc.POSTIND != "" ? "Post Index " + cliDoc.POSTIND : "";


            //Ստեղծում է հասցեի տպելու պարամետր
            await proxyService.TryAddAtomicAsync("hasce", async () =>
            {
                var bnakavayr = cliDoc.DISTRICT != "001" ? (await proxyService.TreeElPropComment("COMMUNTY", cliDoc.COMMUNITY)) + ", " : "";
                var marz = cliDoc.DISTRICT != "001" ? (await proxyService.TreeElPropComment("LRDistr", cliDoc.DISTRICT)) + ", " : "";
                return (marz + cliDoc.CITY + ", " + bnakavayr + cliDoc.ADDRESS + index).ToArmenianUnicode();

            }, templateSubstitutionArgs);


            //Ստեղծում է անգլերեն հասցեի տպելու պարամետր
            await proxyService.TryAddAtomicAsync("ehasce", async () =>
            {
                var ebnakavayr = cliDoc.DISTRICT != "001" ? (await proxyService.TreeElPropEComment("COMMUNTY", cliDoc.COMMUNITY)) + ", " : "";
                var emarz = cliDoc.DISTRICT != "001" ? (await proxyService.TreeElPropEComment("LRDistr", cliDoc.DISTRICT)) + ", " : "";
                return emarz + cliDoc.ECITY + ", " + ebnakavayr + cliDoc.EADDRESS + eindex;

            }, templateSubstitutionArgs);


        }
    }
}
```
Վերևում բերված է հաշվի քաղվածքում կիրառվող լրացուցիչ պարամետրերի հաշվարկման համար նախատեսված դասը։ Այն կարելի է օգտագործել որպես ձևանմուշ այլ տպվող ձևերի / քաղվածքների համար պարամետրերի նկարագրության համար։

Բոլոր տպելու ձևանմուշների ընդլայնման դասերը պարտադիր պետք է ունենան [TemplateSubstitutionExtender] ատրիբուտը և իրագործեն ITemplateSubstitutionExtender ինտերֆեյսը։ Ինտերֆեյսի միջոցով սահնանվում են բոլոր այն մեթոդները և հատկությունները, որոնք պետք է ունենա տվյալ դասը։

Պարամետրերի հաշվարկի համար 8x համակարգում առկա սերվիսները օգտագործելու համար անհրաժեշտ է հայտարարել համապատասխան տիպերի դաշտեր (private readonly UserProxyService proxyService;) և կոնստրուկտորի միջոցով իրանանացնել սերվիսների injection -ը.

```c#
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
....
```

Ավելացվող տպելու պարամետրերի հաշվարկը և ավելացումը իրականացվում է Calculate ֆունկցիայի միջոցով։
```c#

namespace ArmSoft.AS8X.Bank.CustomerSpecific.MyCompany
{
    [TemplateSubstitutionExtender]
    public class AccStateAdr_stamp : ITemplateSubstitutionExtender
    {
....
        
        public async Task Calculate(TemplateSubstitutionExtenderArgs templateSubstitutionArgs)
        {
            //Վերադարձնում է այն փաստաթուղթը, որի վրայից տպվում է քաղվածքը։ Այս դեպքում հաշիվը
            var accountDoc = (Account)templateSubstitutionArgs.Document;

            //Վերադարձնում է հաճախորդ փաստաթուղը
            var cliDoc = await this.proxyService.LoadClientDoc(accountDoc.CLICOD);

            //Վերադարձնում է հաճախորդ փոստային ինդեքսը
            var index = cliDoc.POSTIND != "" ? ", Փոստային ինդեքս` " + cliDoc.POSTIND : "";

            //Ստեղծում է հասցեի տպելու պարամետր
            await proxyService.TryAddAtomicAsync("hasce", async () =>
            {
                var bnakavayr = cliDoc.DISTRICT != "001" ? (await proxyService.TreeElPropComment("COMMUNTY", cliDoc.COMMUNITY)) + ", " : "";
                var marz = cliDoc.DISTRICT != "001" ? (await proxyService.TreeElPropComment("LRDistr", cliDoc.DISTRICT)) + ", " : "";
                return (marz + cliDoc.CITY + ", " + bnakavayr + cliDoc.ADDRESS + index).ToArmenianUnicode();

            }, templateSubstitutionArgs);

....
```
Այն որպես պարամետր ստանում է TemplateSubstitutionExtenderArgs տիպի օբյեկտ, որի միջոցով հնարավոր է հասանելիություն ստանալ 
տպվող փաստաթղթին, ինչպես նաև որոշ դեպքերում իրականացնել պարամետրերի ավելացում։

```c#
  public async Task Calculate(TemplateSubstitutionExtenderArgs templateSubstitutionArgs)
  {

      //Վերադարձնում է ատոմար տպելու պարամետրերի ցուցակը
      var atomics = templateSubstitutionArgs.Substitution.AtomicSubstitutions;

      //Վերադարձնում է այն փաստաթուղթը, որի վրայից տպվում է քաղվածքը։ Այս դեպքում պայմանագիրը
      var agrDoc = templateSubstitutionArgs.Document;
....
      //Վերադարձնում է պայմանագրի վրա լրացված Նպատակ դաշտի արժեքի նկարագրությունը 
      var STAIM = !string.IsNullOrWhiteSpace((string)agrDoc["AIM"]) ? (await proxyService.TreeElProp("LoanPrps", (string)agrDoc["AIM"])).Comment : "";

     //Ստեղծում է տպելու պարամետրեր
     atomics.Add("STAIM", STAIM);
....

```

Հաշվարկից հետո պարամետրի ավելացումը հնարավոր է կատարել նաև UserProxyService ի միջոցով։ Այս տարբերակը ավելի ապահով է այն պատճառով, որ հաշվարկի արդյունքում առաջացած սխալի դեպքում ծրագրի աշխատանքը չի ընդհատվի շարունակելով մնացած բոլոր պարամետրերի հաշվակը։

```c#
[TemplateSubstitutionExtender]
public class AccStatements : ITemplateSubstitutionExtender
{

    private readonly UserProxyService proxyService;
    Account accountDoc;

    public AccStatements(UserProxyService proxyService)
    {
        this.proxyService = proxyService;

    }
    public async Task Calculate(TemplateSubstitutionExtenderArgs templateSubstitutionExtenderArgs)
    {

        this.accountDoc = (Account)templateSubstitutionExtenderArgs.Document;
        await proxyService.TryAddAtomicAsync("pass", async () =>
        {
            var cliCod = await this.proxyService.LoadClientDescByCode(accountDoc.CLICOD);
            return cliCod.PasCode;
        }, templateSubstitutionExtenderArgs);
    }
....

```

## 3. AS ֆայլի նկարագրություն

C# ֆայլը տվյալների բազա ներմուծելու համար անհրաժեշտ է ստեղծել .as ընդլայնումով ֆայլ, որը պետք է պարունակը ներմուծվող ընդլայնման վերաբերյալ հետևյալ տեղեկությունները՝

* Ընդլայնման անվանումը
* ՀԾ-Բանկ համակարգում արտացոլվող վերնագրերը (հայերոն, անգլերեն)
* C# ֆայլի անումը

```vbnet

COMMENT {};
TEMPSUBEXTENDER {Name = AgrMortTemplate_12;
Caption = "AgrMortTemplate_12";
ECaption= "AgrMortTemplate_12";
CSsource = AgrMortTemplate_12.cs;
};
```



[Տպելու ձևերի ընդլայնման նկարագրություն](template_substitution.md)
