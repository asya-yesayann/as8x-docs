---
title: "IMailService սերվիս"
---

## Ներածություն

IMailService ինտերֆեյսը նախատեսված է էլեկտրոնային հաղորդագրություններ ուղարկելու համար։

Առկա է ինտերֆեյսի երկու իրականացում՝ `DBMailService` և `MailKitMailService`, ինյեկցիա հարկավոր է կատարել դրանցից որևէ մեկը։

- `DBMailService` - Էլ. նակաների ուղարկումը կատարվում է SQL սերվերի sp_send_dbmail պրոցեդուրայով։
- `MailKitMailService` - Էլ. նակաների ուղարկումը կատարվում է 8X սերվիսից։

Տե՛ս [օրինակը](../examples/ITemplateSubstitutionService.md#օրինակ-1)։

## Մեթոդներ

| Անվանում | Նկարագրություն |
|----------|----------------|
| [SendMail](IMailService/SendMail.md) | Ուղարկում է էլեկտրոնային նամակ (email) ըստ `args` տվյալների։ |
