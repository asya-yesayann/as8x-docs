---
layout: page
title: "AS-8X համակարգի պրոյեկտների նկարագրություն"
tags: [structure]
---

## Բովանդակություն

* [Նախաբան](#նախաբան)
* Պրոյեկտներ
  * [ArmSoft.AS8X.Client](#armsoft.as8x.client)
  * [ArmSoft.AS8X.Common](#armsoft.as8x.common)
  * [ArmSoft.AS8X.Configuration.Service](#armsoft.as8x.configuration.service)
  * [ArmSoft.AS8X.Core](#armsoft.as8x.core)
  * [ArmSoft.AS8X.Core.UI](#armsoft.as8x.core.ui)
  * [ArmSoft.AS8X.Models](#armsoft.as8x.models)
  * [ArmSoft.AS8X.Service](#armsoft.as8x.service)

## ArmSoft.AS8X.Client

Պարունակում է Routes տիպի դասեր, որոնց օգնությամբ կարելի է դիմել սերվիսային մեթոդներին(DocumentRoutes, ParametersRoutes, ...), փաստաթղթի, dpr-ի կլիենտական նկարագրությունները, որոնք կանչում են սերվերային տրամաբանությունը Route-ների միջոցով։

## ArmSoft.AS8X.Common

Պարունակում է բոլոր պրոյեկտների կողմից օգտագործվող ծրագրային կտորները, ինչպիսիք են constant-ները, c#-ի ներդրված տիպերի extension մեթոդներ պարունակող դասերը(DateExtensions, StringExtensions, ...), համակարգային տիպերը(BooleanFieldType, NumPairFieldType, ...), .... :

## ArmSoft.AS8X.Configuration.Service

Պրոյեկտի կարգավորումների որոշ մասը պահվում են տվյալների բազայում։ Տվյալների բազայից այդ տվյալների բեռնման, լիցենզաների ղեկավարման մեխանիզմի, appsettings.json-ում ներառված կարգավորումների համար սահմանված է այս պրոյեկտը

## ArmSoft.AS8X.Core

Պարունակում է բոլոր պրոյեկտների կողմից օգտագործվող 8x սերվիսում օգտագործվող կտորները, ինչպիսիք են base դասերը, որոնք հիմք են հանդիսանում համակարգային նկարագրությունների սեփական օրինակների ստեղծման համար(Document, DataSource, DPR, ...), սերվիսները(DocumentService, ParametersService, ), ... :

## ArmSoft.AS8X.Core.UI

Պարունակում է բոլոր պրոյեկտների կողմից օգտագործվող UI-ական կտորները, ինչպիսիք են Control-ները(ButtonEditExt, ComboBoxEditExt, CheckEditExt, ...), ինչպիսիք են base դասերը, որոնք հիմք են հանդիսանում համակարգային նկարագրությունների(DataView, DropDownView, DPR, ...) և պատուհանների(DialogWindow,DataViewDialogWindow, ...) սեփական օրինակների ստեղծման համար, ... :

## ArmSoft.AS8X.Models

## ArmSoft.AS8X.Service

Այս պրոյեկտը նախատեսված է ծրագրի API-ների նկարագրման համար։ Նույն գաղափարը կրող API-ները գտնվում են միևնույն Controller դասում։

Օրինակ 
```c#
using ...;
...

namespace ArmSoft.AS8X.Service.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class DPRController : Controller
    {
        [HttpGet()]
        public async Task<IEnumerable<DPRInfo>> GetList([FromServices] IApiClientInfoService clientInfoService)
        {
            ...
        }
       
        [HttpPost("stop")]
        public Task Stop([FromBody] JobProgressRequest request,
                               [FromServices] IJobServerClient jobServerClient)
        {
            ...        
         }

        ...
    }
}
```
