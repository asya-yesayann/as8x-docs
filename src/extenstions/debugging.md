---
layout: page
title: "Debug" 
---

## Բովանդակություն
* [Ներածություն](#ներածություն)
* [Visual Studio ծրագրում կատարվող Կարգավորումները](#visual-studio-ծրագրում-կատարվող-կարգավորումները)
* [Local service-ի կարգավորում](#Local-service-ի-կարգավորում)
* [Break Point-ի տեղադրում]
* [Սերվիսի գործարկում]
* [Աշխատանք Debugger-ի հետ]

## 	Ներածություն

Debug-ը թույլ է տալիս գործարկել ծրագրերը վերահսկվող միջավայրում, որի ընթացքում հնարավոր է Կատարել կոդը քայլ առ քայլ վերլուծելով այն, գտնել և շտկել սխալներ: Նախքան Debug-ը գործընթացը անհրաժեշտ է որոշակի կարգավորումներ անել Visual Studio ծրագրում։


## Visual Studio ծրագրում կատարվող կարգավորումները 

Debugger-ի օգտագործման համար անհրաժեշտ է կարգավորել ներքին մատակարարման Nuget սերվերի ճանապարհը։
Սահմանվելով այն ՝ https://tfs/Armsoft/Armsoft.Nuget/_packaging/ArmsoftNuget/nuget/v3/index.json։

![Nuget սերվերի կարգավորում](package_sources.png)

Սահմանեք Startup Project -ը Set as Startup Project գործողության միջոցով  Օրինակ՝ ArmSoft.AS8X.BankService

## Local service-ի կարգավորում
