---
layout: page
title: "config.as Կարգավորման ֆայլ" 
tags: [config]
---

[Config.as](https://armsoft.github.io/as4x-docs/HTM/Config_as_struct.html) ֆայլը նախատեսված է AS-4X հարթակի ծրագրերը կարգավորելու համար։ 
Մասանավորապես ՀԾ-Բանկի (asbank.exe), ՀԾ-Ձեռնարկության (asbux.exe), ՀԾ-Աշխատավարձի (aswages.exe), Սկրիպտերի խմբագրիչի (scriped.exe) և Համակարգի կարգավորիչի (syscon.exe) համար։

Config.as ֆայլի ամբողջական նկարագրությանը ծանոթանալու համար [տես](https://armsoft.github.io/as4x-docs/HTM/Config_as_struct.html):

AS-4X համակարգի ծրագրերի 8X սերվիսի հետ աշխատելու համար ավելացնել են հետևյալ կարգավորումները։ 
* `CONFIGURATIONSERVICE`  
  Ուր նշվում է կոնֆիգուրացիաների սերվիսի web հասցեն։
  Նշված լինելու դեպքում առանձին `Config` բաժիններ կարելի է չգրել և ծրագրերը կօգտվեն միայն կոնֆիգուրացիաների սերվիսում նշված տվյալների պահոցներից։
* `SERVICE`  
  `CONFIG` բաժնում ավելացնել `SERVICE` հատկությունը, ուր նշվում է 8X սերվիսի web հասցեն։
  Այն հիմնականում օգտագործվում է 8X սերվիսը local աշխատացնելու և [Debugging-ի](../extensions/debugging.md) համար։

Config.as ֆայլի նկարագրության մնացած մասը ամբողջությամբ համընկնում է նախկին` 4X ռեժիմով աշխատող ծրագրի համար նկարագրված Config.as ֆայլի պարունակության հետ։

**Օրինակ**

```as4x
COMMON {
   CONFIGURATIONSERVICE = "https://services8x/configuration";

   CONFIG{ NAME = "bank1 local";   SERVER = SQLSERVER1;   DATABASE = bank1;   CONTEXT = ASBANK;   SERVICE = "https://localhost:1027"; };
   CONFIG{ NAME = "bank2 local";   SERVER = SQLSERVER1;   DATABASE = bank2;   CONTEXT = ASBANK;   SERVICE = "https://localhost:1027"; };
};   
```
