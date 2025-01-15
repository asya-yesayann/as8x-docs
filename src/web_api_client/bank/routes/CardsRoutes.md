---
layout: page
title: "CardsRoutes դաս" 
sublinks:
- { title: "AttachReservedCardToClient", ref: attachreservedcardtoclient }
- { title: "GetCardAgreementFiles", ref: getcardagreementfiles }
---

## Բովանդակություն

- [Ներածություն](#ներածություն)
- [Մեթոդներ](#մեթոդներ)
  - [AttachReservedCardToClient](#attachreservedcardtoclient)
  - [GetCardAgreementFiles](#getcardagreementfiles)

## Ներածություն

ClientsRoutes դասը պարունակում է մեթոդներ քարտերի հետ աշխատանքը ապահովելու համար։
Այն հասանելի է [BankApiClient](../types/BankApiClient.md) դասի միջից։

## Մեթոդներ

### AttachReservedCardToClient

```c#
public Task<AttachReservedCardToClientResponse> AttachReservedCardToClient(
    AttachReservedCardToClientRequest request)
```

Ռեզերվացրած քարտը կցում է տրված հաճախորդին։  
Քարտը պետք է նախապես բացված լինի ՀԾ-Բանկ համակարգում և պրոցեսինգում։  
Այն պետք է բացված լինի տեխնիկական հաճախորդի կոդով (սահմանվում է RESERVEDCARDSCLIENTS պարամետրով)։

**Պարամետրեր**

* `request` - Պարունակում է հաճախորդի կոդը և քարտի համարը։

**Վերադարձվող արժեքներ**

* `CardISN` - քարտի ISN
* `RespCode` - պատասխանի կոդ (բարեհաջող աշխատանքի դեպքում 00)
* `ErrorMessage` - սխալի հաղորդագրություն:  
  Հնարավոր արժեքներն են`
  | RespCode | ErrorMessage |
  | -- | -- |
  | 00 | |
  | 01 | 12345678 client mobile is not filled |
  | 02 | 9051010203040506 card is not a reserved card |
  | 03 | CreateVirtualCard call is failed |
  | 04 | Incorrect card is attached to client by CreateVirtualCard |
  | 05 | Other error |

**Օրինակ**

Տե՛ս օգտագործման [օրինակը](../examples/CardsRoutes.md#օրինակ-1)։

### GetCardAgreementFiles

```c#
public Task<List<string>> GetCardAgreementFiles(int cardIsn, 
                                                Language language, 
                                                string directoryPath)
```

Ներբեռնում է տրված քարտի համար անհրաժեշտ պայմանագրերը։  
Պայմանագրերի ձևանմուշները կարգավորվում են հետևյալ կետով՝ «Պլաստիկ քարտերի պայմանագրերի ձևանմուշների կարգավորում»։  
Մեթոդի կանչի ժամանակ նշված ձևանմուշներում լրացվում են տրված քարտի և հաճախորդի տվյալները և ֆայլերը գրանցվում են `directoryPath` պարամետրով նշված թղթապանակում։  
Մեթոդը վերադարձնում է նաև ֆայլերի անունների ցուցակը՝ ամբողջական ճանապարհով։

**Պարամետրեր**

* `cardIsn` - Քարտի ISN։
* `language` - Պայմանագրի լեզու։
* `directoryPath` - ֆայլերի ներբեռնման թղթապանակ։

**Օրինակ**

Տե՛ս օգտագործման [օրինակը](../examples/CardsRoutes.md#օրինակ-2)։

