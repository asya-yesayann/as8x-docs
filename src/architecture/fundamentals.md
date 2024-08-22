---
layout: page
title: "8x-ի ճարտարապետության հիմունքները" 
---

8x-ը ծրագրային միջավայր է եռամակարդակ (client, application server, database) բիզնես ավտոմատացման ծրագիր
ստեղծելու համար։ 
Մասնավորապես ՀԾ-Բանկ, ՀԾ-Ձեռնարկություն, ՀԾ-Աշխատավարձ համակարգերի համար։

8x ծրագրային միջավայրը հիմնված է Microsoft-ի տեխնոլոգյաների վրա՝ 
* 8x Windows կլիենտը (client) իրականացված է որպես  Windows Presentation Foundation (WPF) կիրառություն։
* Կիրառությունների սերվերը (application server) իրականացված որպես է ASP.NET Core Web API։
* Տվյալների բազան (database) օգտագործում է Microsoft SQL Server-ը։

![8x Ճարտարապետությունը](fundamentals_architecture_simple.png)  
*8x ճարտարապետությունը պարզեցված*

8x Windows կլիենտը աշխատում է կիրառությունների սերվերը հետ ստանդարտ REST(http,json) արձանագրությամբ։ Օգտագործելով 8x REST API-ը այլ համակարգեր նույն պես կարող են աշխատել կիրառությունների սերվերի հետ, օրինակ ինտեգման նպատակով։ 4x Windows կլիենտը օգտագործում է 8x REST API-ը 4x-ից դեպի 8x անցման ժամանակ։ 

![8x Ճարտարապետությունը](fundamentals_architecture_rest_usage.png)  
*8x REST API-ի օգտագործման օրինակ*
