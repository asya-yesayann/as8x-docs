---
layout: page
title: "Փաստաթղթի ընդլայնման ձեռնարկ" 
---

# Փաստաթղթի ընդլայնման ձեռնարկ



## Բովանդակություն
* [Ներածություն](#ներածություն)
* [Ֆայլերի ներմուծում](#ֆայլերի-ներմուծում)

## Ներածություն

8X համակարգում նախատեսված է հնարավորություն ընդլայնելու համակարգում առկա փաստաթղթերի մշակման գործընթացը ավելացնելով լրացուցիչ ստուգումներ, իրականացնելով դաշտերի ավտոմատ լրացում, ինչպես նաև կատարելով ցանկացած այլ գործողություններ, որոնք պետք է կատարվեն փաստաթղթի ստեղծման, խմբագրման կամ հեռացման ընթացքում։

Փաստաթղթերի ընդլայնման համար անհչաժեշտ է ստեղծել երկու ֆայլ՝ ընդլայնման c# դասերը պարունակող ```.cs``` ընդլայնումով ֆայլը և ուղեկցող ```.as``` ֆայլը, որը պետք է պարունակի ներմուծվող DOCUMENTEXTENDER -ի մետատվյալները։ Ընդլայնման ֆայլերի նկարագրությունը հասանելի է [Փաստաթղթի ընդլայնման նկարագրություն](document_extender.md) բաժնում։

## Փաստաթղթի ընդլայնման օրինակ

Ստորև ներկայացված է փաստաթղթի ընդլայնման օրինակ, որի միջոցով ապահովվել է Երկիր տեսակի փաստաթղթի վրա՝ Կոդ, Անգլերեն անվանում և Կրճատ անվանում դաշտերի ավտոմատ լրացումը բեռնելով պահանջվող տվյալները https://restcountries.com REST API-ի միջոցով։

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
           երկրի տվյալները բեռնելու համար։ Դատարկ լինելու դեպքում ձևավորում ենք սխալի մասին հաղորդագրություն։ */
           throw new RESTException("ISO Կոդ դաշտը լրացված չէ:");         }

         // Ստուգում ենք փաստաթղթում լրացվող դաշտերից առնվազն մեկի չլրացված լինելը հակառակ դեպքում դուրս ենք գալիս մեթոդից։ 
        if (!string.IsNullOrEmpty(country.SHRTNAME) && !string.IsNullOrEmpty(country.ENAME) && !string.IsNullOrEmpty(country.CODE))
        {
            return;
        }

        // Բեռնում ենք երկրի մասին տվյալները արտաքին վեբ սերվիսից դեսերիալիզանելով պահանջվող տվյալները
        var response = await httpClient.GetAsync("https://restcountries.com/v3.1/alpha/" + country.ISO);
        var json = await response.Content.ReadAsStringAsync();
        var data = JsonSerializer.Deserialize<List<CountryData>>(json);

        List<string> updatedFields = new();

        /* Ստուգում ենք՝ Կրճատ անվանում, Կոդ, Անգլերեն անվանում դաշտերի լրացված լինելը փաստաթղթում, դատարկ լինելու 
           պարագայում  լրացնում ենք համապատասխան դաշտը միաժամանակ ավելացնելով նրա անվանումը updatedFields List տիպի
           փոփոխականում։ Այն անհրաժեշտ է մեզ վերջում լրացված դաշտերի վերաբերյալ հաղորդագրություն ձևավորելու ժամանակ։ */
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

/* Ստորև տողը անջատում է մասին նշումը Visual Studio -ում CountryData դասում հատկությունների անվանումները փոքրատառով
սկսվելու վերաբերյալ սխալնելի արտացոլումը, քանի որ հատկությունների անվանումները համապատասխանացվել են JSON ֆորմատի դաշտերի անավնումներին։ */
[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "json դաշտեր")]

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


## Ֆայլերի ներմուծում 

Ֆայլերի ներմուծումը հնարավոր է կատարել SYSCON, Script Editor կամ Visual Studio ծրագրերի միջոցով։  
SYSCON ծրագրի միջոցով ներմուծելու համար անհրաժեշտ է ստեղծված ```.cs``` և ```.as``` ֆայլերը տեղադրել config.as ֆայլում BASEFOLDER պարամետրով նկարագրված ճանապարհով կամ ներդրված որևէ պանակում իրար կողքի, այնուհետև գործարկելով SYSCON ծրագիրը ներմուծել "Նկարագրությունների ներմուծում" հանգույցի ներքո արտացոլվող .as ընդլայնումով ֆայլը։
