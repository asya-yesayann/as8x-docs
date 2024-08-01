---
layout: page
title: "config.as Կարգավորման ֆայլ" 
tags: [config]
---

[Config.as](https://armsoft.github.io/as4x-docs/HTM/Config_as_struct.html) ֆայլը նախատեսված է AS-4X հարթակի ծրագրերը կարգավորելու համար։ Մասանավորապես ՀԾ-Բանկի (asbank.exe), ՀԾ-Ձեռնարկության (asbux.exe), ՀԾ-Աշխատավարձի (aswages.exe), Սկրիպտերի խմբագրիչի (scriped.exe), Համակարգի կարգավորիչի (syscon.exe) և Ծրագրի մեկնարկիչի (launcher.exe) համար։

Config.as ֆայլի ամբողջական նկարագրությանը ծանոթանալու համար [տես](https://armsoft.github.io/as4x-docs/HTM/Config_as_struct.html):

AS-4X համակարգի ծրագրերը կարող են աշխատել 8X սերվիսով։ Դրա համար անհրաժեշտ է նախապես նկարագրված Config.as ֆայլում անհրաժեշտ է ավելացնել հետևյալ կարգավորումները՝
* `CONFIGURATIONSERVICE` - Տվյալների պահոցների կոնֆիգուրացիաների սերվիսի web հասցեն։ Նշված լինելու դեպքում առանձին `Config` բաժիններ կարելի է չգրել և ծրագրերը կօգտվեն միայն կոնֆիգուրացիաների սերվիսում նշված տվյալների պահոցներից։
* Յուրաքանչյուր տվյալների բազայի պարամետրերը որոշող `CONFIG` բաժնում ավելացնել `SERVICE` հատկությունը՝ նշել 8X սերվիսի web հասցեն։
Config.as ֆայլի նկարագրության մնացած մասը ամբողջությամբ համընկնում է նախկին` 4X ռեժիմով աշխատող ծրագրի համար նկարագրված Config.as ֆայլի պարունակության հետ։

**Օրինակ**

```as4x
COMMON {
   DESCRIPTION = "Initialization";
   LANGUAGE = 1;
   MODE = 4.0;
   CONFIGURATIONSERVICE = "https://services8x/configuration";

   BASEFOLDER{PATH="D:\TFS\W\Bank\asbank";  SS = YES;  CONTEXT = ASBANK; };


   CONFIG{ NAME = "Daily build d_bank1";   SERVER = Bank-Server;   DATABASE = d_bank1;   CONTEXT = ASBANK;   SERVICE = "https://localhost:1027";};
   CONFIG{ NAME = "Daily build d_bank2";   SERVER = Bank-Server;   DATABASE = d_bank2;   CONTEXT = ASBANK;   SERVICE = "https://localhost:1027";};
...
   
SCRIPED {
     TFS ="http://tfserver:8080/Armsoft";
};

```
