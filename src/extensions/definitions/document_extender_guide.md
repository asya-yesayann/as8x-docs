---
layout: page
title: "Փաստաթղթի ընդլայնման ձեռնարկ" 
---

# Փաստաթղթի ընդլայնման ձեռնարկ



## Բովանդակություն
* [Ներածություն](#Ներածություն)
* [cs ֆայլի ստեղծում](#cs-ֆայլի-ստեղծում)
* [Ֆայլերի ներմուծում](#ֆայլերի-ներմուծում)

## Ներածություն

8X համակարգում նախատեսված է հնարավորություն ընդլայնելու համակարգում առկա փաստաթղթերի մշակման գործընթացը ավելացնելով լրացուցիչ ստուգումներ, իրականացնելով դաշտերի ավտոմատ լրացում, ինչպես նաև կատարելով ցանկացած այլ գործողություններ, որոնք պետք է կատարվեն փաստաթղթի ստեղծման, խմբագրման կամ հեռացման ընթացքում։

Փաստաթղթերի ընդլայնման համար անհչաժեշտ է ստեղծել երկու ֆայլ՝ ընդլայնման c# դասերը պարունակող ```.cs``` ընդլայնումով ֆայլը և ուղեկցող ```.as``` ֆայլը, որը պետք է պարունակի ներմուծվող DOCUMENTEXTENDER -ի մետատվյալները։ Ընդլայնման ֆայլերի ինչպես նաև DocumentExtender դասի նկարագրությունը հասանելի է [Փաստաթղթի ընդլայնման նկարագրություն](document_extender.md) բաժնում։

## cs ֆայլի ստեղծում

Ֆայլում պարունակվող դասը ժառանգում է [DocumentExtender](document_extender.md) դասը, և կարող է ընդլայնել դասում նկարագրված մեթոդները։ Նշված մեթոդները ավտոմատ կերպով, սահմանված հերթականությամբ կանչվում են փաստաթղթի պահպանման կամ հեռացման ընթացքում։ Մեթոդները, որպես պարամետր (Document sender) ստանում են մշակվող փաստաթղթի օբյեկտը, որի միջոցով հնարավոր է մշակման տարբեր փուլերում կատարել լրացված դաշտերի ստուգում, ավտոմատ լրացում, առաջացնել բացառություններ (exceptions) ընդհատելով փաստաթղթի մշակումը, ինչպես նաև կատարել ցանկացած այլ գործողություն։ 
Մեթոդներում հնարավոր է կատարել նաև ասինխրոն գործողություններ, այդ դեպքում անհրաժեշտ է մեթոդը հայտարարել որպես async:
Անհրաժեշտույան դեպքում դասում կարող է սահմանված լինել կոնստրուկտոր, որի միջոցով հնարավոր է ինյեկցիայի միջոցով 
փոխանցել լրացուցիչ 8x սերվիսներ, որոնց օգտագործումը անհրաժեշտ է ընդլայնվող մեթոդներում։

```c#
namespace DocExtensions;

[DocumentExtender]
public class MyDocExtension : DocumentExtender
{
    private readonly IParametersService paramService;
     
    public MyDocExtension(IParametersService paramService)
    {
        this.paramService = paramService;
    }
    public override Task PostAction(Document sender, ActionEventArgs args)
    {

    }

    public async override Task PreValidate(Document sender, ValidateEventArgs args)
    {
        
    }
    
    public override Task PostAction(Document sender, ActionEventArgs args)
    {

    }
}
```


## Փաստաթղթի ընդլայնման օրինակ

Ստորև ներկայացված է փաստաթղթի ընդլայնման օրինակ, որի միջոցով ապահովվել է Երկիր տեսակի փաստաթղթի վրա՝ Կոդ, Անգլերեն անվանում և Կրճատ անվանում դաշտերի ավտոմատ լրացումը բեռնելով պահանջվող տվյալները https://restcountries.com REST API-ի միջոցով։
Փաստաթղթի լրացումը կատարվում է տրանզակցիայի մեջ, մինչև հիմնական վալիդացիայի աշխատելը։

```c#
using ArmSoft.AS8X.Bank.General.Country.DOCS;
using ArmSoft.AS8X.Common.Exceptions;
using ArmSoft.AS8X.Common.Extensions;
using ArmSoft.AS8X.Core.Document;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ArmSoft.AS8X.Bank.Samples.DocExtensions;

[DocumentExtender]
public class CountryEx : DocumentExtender
{
    private static readonly HttpClient httpClient = new();
    public async override Task PreValidate(Document sender, ValidateEventArgs args)
    {
        var country = (Country)sender;
        if (string.IsNullOrEmpty(country.ISO))
        {
           /* Ստուգում ենք ISO կոդ դաշտի լրացված լինելը, այդ արժեքը օգտագործվում է
           երկրի տվյալները բեռնելու համար։ Դատարկ լինելու դեպքում ձևավորում ենք սխալի մասին
           հաղորդագրություն։

           Exception-ի առաջացման դեպքում փաստաթղթի պահպանման գործընթացը կընդհատվի ՀԾ-Բանկ-ում դուրս բելեով
           համապատսխան սխալի մասին հաղորդագրությունը  */
           throw new RESTException("ISO Կոդ դաշտը լրացված չէ:");         }

         // Ստուգում ենք փաստաթղթում լրացվող դաշտերից առնվազն մեկի չլրացված լինելը հակառակ դեպքում դուրս ենք գալիս մեթոդից։ 
        if (!string.IsNullOrEmpty(country.SHRTNAME) && !string.IsNullOrEmpty(country.ENAME) && !string.IsNullOrEmpty(country.CODE))
        {
            return;
        }

        // Բեռնում ենք երկրի մասին տվյալները արտաքին վեբ սերվիսից։
        var response = await httpClient.GetAsync("https://restcountries.com/v3.1/alpha/" + country.ISO);
        var json = await response.Content.ReadAsStringAsync();

        // Կատարում ենք դեսերիալիզացիա օգտագործելով ստորև նկարագրված CountryData դասը։
        var data = JsonSerializer.Deserialize<List<CountryData>>(json);

        List<string> updatedFields = new();

        /* Ստուգում ենք՝ Կրճատ անվանում, Կոդ, Անգլերեն անվանում դաշտերի լրացված լինելը փաստաթղթում,
           դատարկ լինելու պարագայում լրացնում ենք համապատասխան դաշտը միաժամանակ ավելացնելով նրա
           անվանումը updatedFields List տիպի փոփոխականում։ Այն անհրաժեշտ է դաշտերի լրացումից
           հետո հաղորդագրություն ձևավորելու համար։ */
        if (string.IsNullOrEmpty(country.SHRTNAME))
        {
            country.SHRTNAME = data[0].cca3;
            updatedFields.Add("Կրճատ անվանում".ToArmenianANSI());
        }

        if (string.IsNullOrEmpty(country.ENAME))
        {
            country.ENAME = data[0].name.official;
            updatedFields.Add("Անգլերեն անվանում".ToArmenianANSI());
        }

        if (string.IsNullOrEmpty(country.CODE))
        {
            country.CODE = data[0].ccn3;
            updatedFields.Add("Կոդ".ToArmenianANSI());
        }

        if (sender.IsUIOrigin && updatedFields.Count > 0)
        {
            // Հաղորդագրություն ենք ձևավորում լրացված դաշտերի վերաբերյալ 
            await sender.Progress.MessageBox(string.Join(", ", updatedFields) + " դաշտը/դաշտերը լրացվել են փաստաթղթի վրա։".ToArmenianANSI(), Common.MessageBoxButtons.OK, Common.MessageBoxIconType.Information);
        }
    }
}

/* Ստորև տողը անջատում է Visual Studio -ում CountryData դասում հատկությունների
անվանումները փոքրատառով սկսվելու վերաբերյալ սխալնելի արտացոլումը, քանի որ հատկությունների
անվանումները համապատասխանացվել են JSON ֆորմատի դաշտերի անավնումներին։ */
[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "json դաշտեր")]

/* CountryData, CountryName դասերը օգտագործվում են ստացված JSON պատասխանը դեսերիալիզացնելու
համար։ CountryData դասը ունի ստացված JSON պատասխանի դաշտերին համապատասխան
հատկություններ՝ ccn3, cca3 և name։ Վերջինս ներկայացնում է ներդրված, բազմաթիվ
հատկություններով օբյեկտ, որոնցից մեզ անհրաժեշտ է միայն  official - ը։
Այդ նպատակով նկարագրել ենք CountryName դասը official հատկությամբ։ Դեսերիալիզացիա անելիս
մենք ստանալու ենք CountryData տիպի օբյեկտ, որը պարունակում է միայն անհրաժեշտ տվյալները։
*/
public class CountryData
{

    public string ccn3 { get; set; }
    public CountryName name { get; set; }
    public string cca3 { get; set; }

    public class CountryName
    {
        public string official { get; set; }
    }
}
```
Ստորև ներկայացված է արտաքին վեբ սերվիսից ստացվող պատասխանի հատվածը։

```json
[
  {
    "name": {
      "common": "Austria",
      "official": "Republic of Austria",
      "nativeName": {
        "bar": {
          "official": "Republik Österreich",
          "common": "Österreich"
        }
      }
    },
    "tld": [
      ".at"
    ],
    "cca2": "AT",
    "ccn3": "040",
    "cca3": "AUT",
    "cioc": "AUT",
...
  }
]
```

## .as ֆայլի ստեղծում

՝՝՝.as ՝՝՝ ֆայլը պարունակում է տվյալներ ընդլայնվող փաստաթղթի և ներմուծվող ընդլայնման վերաբերյալ։ ```NAME``` պարամետրով սահմանվում է ընդլայնվող փաստաթղթի ներքին անվանումը։ ```CAPTION``` և ```ECAPTION```  պարամետրով սահմանվում է ՀԾ-Բանկ համակարգում արտացոլվող ընդլայնման հայերեն և անգլերեն անվանումները (հայերենանվանումը սահմանվում է ANSI կոդավորմամբ)։  ```CSSOURCE``` -ով սահմանվում է ներմուծվող ```.cs``` ֆայլի անվանումը։ Այն դեպքում երբ ներմուծելիս ```.as``` և ```.cs``` ֆայլերը գտնվում են նույն պանակի մեջ սահմանվում է միայն ```.cs``` ֆայլի անվանումը։

```
DOCUMENTEXTENDER {
  NAME = "COUNTRY";
  CAPTION = "Երկիր փաստ. ընդլայնում";
  CAPTION = "Country doc extension";
  CSSOURCE = ="CountryEx.cs";
};
```

եթե c# դասը պարունակող ֆայլը գտնվում է այլ պանակում, սահմանվում է   
ամբողջական կամ հարաբերական ճանապահը՝

```
  CSSOURCE = ="..\..\CsFiles\CountryEx.cs";
կամ
  CSSOURCE = ="C:\CsFiles\CountryEx.cs";

```

## Ֆայլերի ներմուծում 

Ֆայլերի ներմուծումը հնարավոր է կատարել SYSCON, Script Editor կամ Visual Studio ծրագրերի միջոցով։  
SYSCON ծրագրի միջոցով ներմուծելու համար անհրաժեշտ է ստեղծված  ```.as``` և ```.cs``` և  ֆայլերը տեղադրել config.as ֆայլում BASEFOLDER պարամետրով նկարագրված ճանապարհով, այնուհետև գործարկելով SYSCON ծրագիրը ներմուծել "Նկարագրությունների ներմուծում" հանգույցի ներքո արտացոլվող .as ընդլայնումով ֆայլը։ ```.cs``` ֆայլը այլ պանակում տեղադրված լինելու դեպքում ```.as``` ֆայլի ```CSSOURCE``` ապարմերը պետք է պարունակի ամբողջական կամ հարաբերական ճանապարհը դեպի  ```.cs```  ֆայլը ինչպես նկարագրված է [.as ֆայլի ստեղծում](#.as-ֆայլի-ստեղծում)
։
