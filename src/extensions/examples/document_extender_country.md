---
layout: page
title: "«Երկիր» Փաստաթղթի ընդլայնման օրինակ" 
---

Ստորև ներկայացված է փաստաթղթի ընդլայնման օրինակ, որի միջոցով ապահովվել է Երկիր տեսակի փաստաթղթի վրա՝ "Կոդ", "Անգլերեն անվանում" և "Կրճատ անվանում" դաշտերի ավտոմատ լրացումը բեռնելով պահանջվող տվյալները https://restcountries.com REST API-ի միջոցով։ 

Նշված հնարավորությունը ակտիվանում է միայն նոր ստեղծված` FILLCOUNTRYFIELDS (Ավտոմատ լրացնել "Երկրի Կոդ", "Անգլերեն անվանում" և "Կրճատ անվանում" դաշտերը երկիր փաս-ում) պարամետրի "Այո" արժեքի դեպքում։

Փաստաթղթի իրադարձությունների ընդլայնման օրինակը տե՛ս [այստեղ](/src/extensions/definitions/document_extender_guide.md)։

Օրինակում բերված են 3 ֆայլեր։

## CountryEx.cs ֆայլի պարունակություն

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

    private readonly IParametersService paramService;

    /* Կատարում ենք IParametersService սերվիսի ինյեկցիա, որի միջոցով կստանանք FILLCOUNTRYFIELDS
    համակարգային պարամետրերի արժեքը։ */
    public CountryEx(IParametersService paramService)
    {
        this.paramService = paramService;
    }

    public async override Task PreValidate(Document sender, ValidateEventArgs args)
    {
        //Ստանում ենք FILLCOUNTRYFIELDS համակարգային պարամետրի արժեքը
        bool isCountryAutofillAllowed = await this.paramService.GetBooleanValue("FILLCOUNTRYFIELDS");

        // Մեթոդի աշխատանքը կավարտվի պարամետրի արժեքի Ոչ արժեքի դեպքում
        if (!isCountryAutofillAllowed)
        {
            return;
        }
        var country = (Country)sender;
        if (string.IsNullOrEmpty(country.ISO))
        {
            /* Ստուգում ենք ISO կոդ դաշտի լրացված լինելը, այդ արժեքը օգտագործվում է
            երկրի տվյալները բեռնելու համար։ Դատարկ լինելու դեպքում ձևավորում ենք սխալի մասին
            հաղորդագրություն։
            Exception-ի առաջացման դեպքում փաստաթղթի պահպանման գործընթացը կընդհատվի ՀԾ-Բանկ-ում դուրս բելեով
            համապատսխան սխալի մասին հաղորդագրությունը  */
            throw new RESTException("ISO Կոդ դաշտը լրացված չէ:".ToArmenianANSI());
        }

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
           անվանումը List տիպի updatedFields  փոփոխականում։ Այն անհրաժեշտ է դաշտերի լրացումից
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
            // Ձևավորում ենք հաղորդագրություն լրացված դաշտերի վերաբերյալ։ 
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

## CountryEx.as ֆայլի պարունակությունը

Պետք է գրված լինի ANSI կոդավորմամբ։

```as4x
DOCUMENTEXTENDER {
  NAME = "COUNTRY";
  CAPTION = "Երկիր փաստաթղթի ընդլայնում"; 
  ECAPTION = "Country doc extension";
  CSSOURCE = "CountryEx.cs";
};
```

SYSCON-ի միջոցով ֆայլերի ներմուծման ժամանակ `CountryEx.as` և `CountryEx.cs` ֆայլերը տեղադրվել են `config.as` ֆայլում BASEFOLDER պարամետրով սահմանված պանակում։

## NewParam.txt ֆայլի պարունակություն

Նոր FILLCOUNTRYFIELDS համակարգային պարամետրի ավելացման համար ստեղծվել է տեքստային ֆայլ հետևյալ պարունակությամբ։
Պետք է գրված լինի ANSI կոդավորմամբ։

```
#AS3XX# EXPORT-IMPORT DATA FILE

PARAMETER {
PARAMID:FILLCOUNTRYFIELDS
TYPE:0
VALUETYPE:Boolean
VALUE:1
DESCRIPTION:Ավտոմատ լրացնել Երկրի Կոդ, Անգլերեն անվանում և Կրճատ անվանում դաշտերը երկիր փաս-ում
EDESCRIPTION:Automatically fill Country Code, Short Name and English name fields on Country 
PERMANENT:1
GROUP:General
UPDATEACCESS:1
KIND:          
MEMO:«Այո» արժեքի դեպքում  Երկրի Կոդ, Անգլերեն անվանում և Կրճատ անվանում դաշտերը դաշտերը կլրացվեն համապատսխան  https://restcountries.com REST API- ից ստացված տվյալների:
}
```
