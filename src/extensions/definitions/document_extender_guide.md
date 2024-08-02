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
            throw new RESTException("ISO Կոդ դաշտը լրացված չէ:");
        }

        if (!string.IsNullOrEmpty(country.SHRTNAME) && !string.IsNullOrEmpty(country.ENAME) && !string.IsNullOrEmpty(country.CODE))
        {
            return;
        }

        var response = await httpClient.GetAsync("https://restcountries.com/v3.1/alpha/" + country.ISO);
        var json = await response.Content.ReadAsStringAsync();
        var data = JsonSerializer.Deserialize<List<CountryData>>(json);
        List<string> updatedFields = new();

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
            await sender.Progress.MessageBox(string.Join(", ", updatedFields) + " դաշտը/դաշտերը լրացվել են փաստաթղթի վրա։".ToArmenianANSI(), Common.MessageBoxButtons.OK, Common.MessageBoxIconType.Information);
        }
    }
}

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




## Ֆայլերի ներմուծում 

Ֆայլերի ներմուծումը հնարավոր է կատարել SYSCON, Script Editor կամ Visual Studio ծրագրերի միջոցով։  
SYSCON ծրագրի միջոցով ներմուծելու համար անհրաժեշտ է ստեղծված ```.cs``` և ```.as``` ֆայլերը տեղադրել config.as ֆայլում BASEFOLDER պարամետրով նկարագրված ճանապարհով կամ ներդրված որևէ պանակում իրար կողքի, այնուհետև գործարկելով SYSCON ծրագիրը ներմուծել "Նկարագրությունների ներմուծում" հանգույցի ներքո արտացոլվող .as ընդլայնումով ֆայլը։
