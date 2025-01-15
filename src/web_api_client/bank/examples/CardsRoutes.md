---
layout: page
title: "Օրինակ CardsRoutes" 
sublinks:
- { title: "Օրինակ AttachReservedCardToClient", ref: օրինակ-1 }
- { title: "Օրինակ GetCardAgreementFiles", ref: օրինակ-2 }
---

## Բովանդակություն
- [AttachReservedCardToClient-ի օգտագործման օրինակ](#օրինակ-1)
- [GetCardAgreementFiles-ի օգտագործման օրինակ](#օրինակ-2)

## Օրինակ 1
Ռեզերվացրած քարտը հաճախորդի կցման օրինակ։

```c#
private static async Task AttachReservedCardToClient(BankApiClient apiClient)
{
    try
    {
        // տրված հաճախորդին կցում է տրված ռեզերվացրած քարտը
        var res = await apiClient.Cards.AttachReservedCardToClient(new()
        {
            ClientCode = "12345678", // հաճախորդի կոդ
            CardNumber = "9051010203040506", // քարտի համար
        });

        // տպում է քարտի ISN-ը
        Console.WriteLine(res.CardISN);
        
        // տպում է պատասխանի կոդը և սխալի հաղորդագրությունը
        // բարեհաջող աշխատանքի դեպքում RespCode-ի արժեքը կլինի "00" և ErrorMessage-ը կլինի դատարկ
        Console.WriteLine(res.RespCode);
        Console.WriteLine(res.ErrorMessage);
    }
    catch (ApiException ex)
    {
        // մեթոդի կանչի ընթացքում սխալի առաջացման դեպքում տպում է սխալի մանրամասները
        Console.WriteLine(ex.Code); // սխալի կոդ
        Console.WriteLine(ex.Message); // սխալի հաղորդագրություն
        Console.WriteLine(ex.StatusCode); // սխալի վիճակի կոդ
    } 
}
```

## Օրինակ 2

Քարտի համար կարգավորված անհրաժեշտ պայմանագրերի ներբեռնման օրինակ։

```c#
private static async Task GetCardAgreementFiles(BankApiClient apiClient)
{
    try
    {
        // Ներբեռնում է 123456789 ISN-ով քարտի համար կարգավորված անհրաժեշտ պայմանագրերի փաստաթղթերը նշված թղթապանակ
        var res = await apiClient.Cards.GetCardAgreementFiles(123456789, Language.Armenian, @"C:\CardAgreements\");

        foreach (var fileName in res)
        {
            // տպում է ֆայլի ամբողջական անունը
            Console.WriteLine(fileName);
        }
    }
    catch (ApiException ex)
    {
        // մեթոդի կանչի ընթացքում սխալի առաջացման դեպքում տպում է սխալի մանրամասները
        Console.WriteLine(ex.Code); // սխալի կոդ
        Console.WriteLine(ex.Message); // սխալի հաղորդագրություն
        Console.WriteLine(ex.StatusCode); // սխալի վիճակի կոդ
    } 
}
```